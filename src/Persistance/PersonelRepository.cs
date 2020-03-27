using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonelTakip.Controllers.Resources;
using PersonelTakip.Core;
using PersonelTakip.Core.Models;
using PersonelTakip.Extensions;

namespace PersonelTakip.Persistance
{
    public class PersonelRepository : GenericRepository<Personel>, IPersonelRepository
    {
        private readonly IUnvanRepository unvanRepository;
        public PersonelRepository(ApplicationDbContext dbContext, IUnvanRepository unvanRepository) : base(dbContext)
        {
            this.unvanRepository = unvanRepository;
        }

        public async Task<Personel> FindOneByTcNoAsync(string tcno)
        {
            var personel =  await dbContext.Personeller.FirstOrDefaultAsync(p=>p.TcNo==tcno);
            return personel;
        }

        public async Task<QueryResult<Personel>> GetsByQuery(IQueryObject queryObject, int year, int month, string filter = "current")
        {
            var day = DateTime.DaysInMonth(year, month);
            var aySonu = new DateTime(year, month, day);
            var ayBasi = new DateTime(year, month, 1);

            var sonuc = new QueryResult<Personel>();
            var collectionQuery = dbContext.Personeller.Include(x => x.Gorev).AsQueryable();

            if(filter.Equals("current"))
                collectionQuery = collectionQuery.Where(p => p.IseBaslamaTarihi <= aySonu && (p.IstenAyrilmaTarihi >= ayBasi || p.IstenAyrilmaTarihi == default(DateTime)));
            else if (filter.Equals("old"))
                collectionQuery = collectionQuery.Where(p => p.IseBaslamaTarihi > aySonu || (p.IstenAyrilmaTarihi < ayBasi && p.IstenAyrilmaTarihi != default(DateTime)));
            sonuc.TotalItems = await collectionQuery.CountAsync();
            if(queryObject != null)
                collectionQuery = collectionQuery.ApplyPaging(queryObject);
            sonuc.Items = await collectionQuery.ToListAsync();
            return sonuc;
        }

        public async Task<List<Tuple<string, int>>> GorevOzetleriGetir(int year, int month, string filter = "current")
        {
            var collectionQuery = await GetsByQuery(null, year, month, filter);
            var list = new List<Tuple<string, int>>();
            var unvanlar = await unvanRepository.GetAllAsync();
            foreach (var unvan in unvanlar)
            {
                var toplamSayi = collectionQuery.Items.Where(p => p.GorevId == unvan.Id).Count();
                list.Add(new Tuple<string, int>(unvan.UnvanAdi, toplamSayi));

            }
            return list;
        }

        

    }
}
