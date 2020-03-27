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
    public class UnvanRepository : GenericRepository<Unvan>, IUnvanRepository
    {
        public UnvanRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<ICollection<Unvan>> GetAllAsync()
        {
            return await dbContext.Unvanlar.Where(u => !u.Disabled).OrderBy(h => h.Id).ToListAsync();
        }
    }
}
