using System;
using System.Threading.Tasks;

namespace PersonelTakip.Core
{
    public interface IUnitOfWork
    {
        Task<int> CompleteAsync();
    }
}
