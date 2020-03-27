using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonelTakip.Controllers.Resources;
using PersonelTakip.Core.IRepository;
using PersonelTakip.Core.Models;

namespace PersonelTakip.Core
{
    public interface IPersonelRepository:IGenericRepository<Personel>
    {
        Task<QueryResult<Personel>> GetsByQuery(IQueryObject queryObject, int year, int month, string filter = "current");
        Task<List<Tuple<string, int>>> GorevOzetleriGetir(int year, int month, string filter = "current");
        Task<Personel> FindOneByTcNoAsync(string tcno);

    }    
    
}
