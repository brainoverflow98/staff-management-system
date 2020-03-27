using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PersonelTakip.Core.IRepository;
using PersonelTakip.Core.Models;
using PersonelTakip.Persistance;

namespace PersonelTakip.Core
{
    public interface IHesaplamaRepository : IGenericRepository<Hesaplama>
    {
        Task<ICollection<Hesaplama>> GetAllAsync();
        Task<ICollection<Hesaplama>> GetAllSummaryAsync();
    }
}
