using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonelTakip.Controllers.Resources;
using PersonelTakip.Core;
using PersonelTakip.Core.Models;
using PersonelTakip.Extensions;


namespace PersonelTakip.Persistance
{
    public class PuantajRepository : IPuantajRepository
    {
        private DbSet<PuantajGirdisi> puantajlar;
        readonly ApplicationDbContext dbContext;

        public PuantajRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.puantajlar = dbContext.Puantajlar;
        }

        public async Task AddAsync(PuantajGirdisi entity)
        {

            await puantajlar.AddAsync(entity);
        }

        public void Delete(PuantajGirdisi entity)
        {
            puantajlar.Remove(entity);
        }

        public async Task<PuantajGirdisi> FindOneAsync(long personelId, DateTime tarih)
        {
            var PuantajGirdisi = await puantajlar.
            Where(y => y.PersonelId == personelId && y.Tarih == tarih).FirstOrDefaultAsync();

            return PuantajGirdisi;
        }

        public async Task<ICollection<PuantajGirdisi>> GetAllAnnualAsync(long personelId, DateTime baslangic, DateTime bitis)
        {
            return await puantajlar.Where(p=>p.PersonelId == personelId && p.Tarih >= baslangic && p.Tarih <= bitis).ToListAsync();
        }
         public async Task<ICollection<PuantajGirdisi>> GetAll(long personelId, DateTime baslangic, DateTime bitis)
        {
        var puantajList =  await puantajlar.Where(p=>p.PersonelId == personelId && p.Tarih >= baslangic && p.Tarih <= bitis).AsNoTracking()
        .Include(p=>p.Secenek).ToListAsync();
        
        
        return puantajList;
        
        }
        

        public async Task<ICollection<PuantajGirdisi>> GetAllMonthlyAsync(DateTime baslangic, DateTime bitis)
        {
            return await puantajlar.Where(p => p.Tarih >= baslangic && p.Tarih <= bitis).ToListAsync();
        }

        public async Task<ICollection<PuantajGirdisi>> GetAllSummaryAsync(DateTime baslangic, DateTime bitis)
        {
            return await puantajlar.Include(p=>p.Personel).Where(p => p.Tarih >= baslangic && p.Tarih <= bitis).ToListAsync();
        }

        public async Task<QueryResult<PuantajGirdisi>> GetsByQueryAsync(IQueryObject queryObject)
        {
            var sonuc = new QueryResult<PuantajGirdisi>();
            var collectionQuery = puantajlar.AsQueryable();

            sonuc.TotalItems = await collectionQuery.CountAsync();

            collectionQuery = collectionQuery.ApplyPaging(queryObject);
            sonuc.Items = await collectionQuery.ToListAsync();
            return sonuc;
        }

        public void Update(PuantajGirdisi entity)
        {
            puantajlar.Attach(entity);

            dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task AddOrUpdateAsync(ICollection<PuantajGirdisi> puantajlar)
        {
            foreach (var puantaj in puantajlar)
            {
                var item = await this.FindOneAsync(puantaj.PersonelId, puantaj.Tarih);
                if (item != null)
                {
                    item.SecenekId = puantaj.SecenekId;
                }
                else
                {
                    dbContext.Add(puantaj);
                }

            }

        }

        
    }
}
