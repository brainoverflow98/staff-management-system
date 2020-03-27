using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonelTakip.Core;
using PersonelTakip.Core.IRepository;
using PersonelTakip.Core.Models;
using PersonelTakip.Extensions;

namespace PersonelTakip.Persistance
{
    public class GenericRepository<TEntity> :IGenericRepository<TEntity> where TEntity:BaseEntity
    {
        private readonly DbSet<TEntity> dbSet;
        protected  ApplicationDbContext dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
           await dbSet.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            dbSet.Remove(entity);
        }

        public async Task<TEntity> FindOneAsync(long id)
        {
            var entity = await dbSet.FirstOrDefaultAsync(e => e.Id == id);
            return entity;
        }

        public ICollection<TEntity> GetAll()
        {

            return dbSet.AsQueryable().ToList();
        }

        public async Task<QueryResult<TEntity>> GetsByQuery(IQueryObject queryObject)
        {
            var sonuc = new QueryResult<TEntity>();
            var collectionQuery = dbSet.AsQueryable();

            sonuc.TotalItems = await collectionQuery.CountAsync();

            collectionQuery = collectionQuery.ApplyPaging(queryObject);
            sonuc.Items = await collectionQuery.ToListAsync();
            return sonuc;



        }

        public void Update(TEntity entity)
        {
            dbSet.Attach(entity);

            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
