using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonelTakip.Core.Models;

namespace PersonelTakip.Core
{
    public interface IPuantajRepository
    {
        Task AddAsync(PuantajGirdisi entity);
        void Delete(PuantajGirdisi entity);
        Task<ICollection<PuantajGirdisi>> GetAllMonthlyAsync(DateTime baslangic, DateTime bitis);
        Task<ICollection<PuantajGirdisi>> GetAllAnnualAsync(long personelId, DateTime baslangic, DateTime bitis);
        Task<ICollection<PuantajGirdisi>> GetAllSummaryAsync(DateTime baslangic, DateTime bitis);
        Task<QueryResult<PuantajGirdisi>> GetsByQueryAsync(IQueryObject queryObject);
         Task<ICollection<PuantajGirdisi>> GetAll(long personelId, DateTime baslangic, DateTime bitis);

        Task<PuantajGirdisi> FindOneAsync(long personelId, DateTime tarih);
        Task AddOrUpdateAsync(ICollection<PuantajGirdisi> puantajlar);
        void Update(PuantajGirdisi entity);        

    }
}
