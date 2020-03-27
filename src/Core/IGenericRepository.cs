using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonelTakip.Core.Models;

namespace PersonelTakip.Core.IRepository
{
    public interface IGenericRepository<TEntity> where TEntity:BaseEntity
 
    {
        Task AddAsync(TEntity entity);
        void Delete(TEntity entity);
        ICollection<TEntity> GetAll();
        Task<QueryResult<TEntity>> GetsByQuery(IQueryObject queryObject);
        Task<TEntity> FindOneAsync(long id);
        void Update(TEntity entity);

    }
}
