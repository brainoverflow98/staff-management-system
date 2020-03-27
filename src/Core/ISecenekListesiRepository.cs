using System;
using System.Collections.Generic;
using PersonelTakip.Core.IRepository;
using PersonelTakip.Core.Models;
using System.Threading.Tasks;

namespace PersonelTakip.Core
{
    public interface ISecenekListesiRepository:IGenericRepository<SecenekListesi>
    {
        SecenekListesi FindOne(long id);
        Task<ICollection<SecenekListesi>> GetAllAsync();
    }
}
