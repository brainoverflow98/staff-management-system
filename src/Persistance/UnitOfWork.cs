using System;
using System.Threading.Tasks;
using PersonelTakip.Core;

namespace PersonelTakip.Persistance
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<int> CompleteAsync()
        {
          var result = await  dbContext.SaveChangesAsync();
          return result;
        }
    }
}
