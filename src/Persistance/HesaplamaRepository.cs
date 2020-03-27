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
    public class HesaplamaRepository : GenericRepository<Hesaplama>, IHesaplamaRepository
    {
        public HesaplamaRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Hesaplama>> GetAllAsync()
        {
            var hesaplamalar = await dbContext.Hesaplamalar.Include(h => h.HesaplamaSecenekleri).Include(h => h.HesaplamaUnvanlari).Where(h => !h.Disabled).OrderBy(h=>h.Id).ToListAsync();
            return hesaplamalar;
        }

        public async Task<ICollection<Hesaplama>> GetAllSummaryAsync()
        {
            var hesaplamalar = await dbContext.Hesaplamalar.Include(h => h.HesaplamaSecenekleri).Include(h => h.HesaplamaUnvanlari).Where(h => !h.Disabled && h.OzetGoster).OrderBy(h => h.Id).ToListAsync();
            return hesaplamalar;
        }
    }
}
