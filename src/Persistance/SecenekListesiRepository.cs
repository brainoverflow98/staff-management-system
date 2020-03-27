using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonelTakip.Core;
using PersonelTakip.Core.IRepository;
using PersonelTakip.Core.Models;

namespace PersonelTakip.Persistance
{
    public class SecenekListesiRepository : GenericRepository<SecenekListesi>, ISecenekListesiRepository
    {
        public SecenekListesiRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public SecenekListesi FindOne(long id)
        {
            var secenek  =dbContext.Secenekler.FirstOrDefault(s=>s.Id==id);
            return secenek;
        }

        public async Task<ICollection<SecenekListesi>> GetAllAsync()
        {
            return await dbContext.Secenekler.Where(u => !u.Disabled).OrderBy(h => h.Id).OrderBy(s => s.Id).ToListAsync();
        }
    }
}
