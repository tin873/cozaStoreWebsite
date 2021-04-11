using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cozaStore.DataAccessLayer
{
    public interface IDbFactory : IDisposable
    {
        cozaStoreDbContext Init();
    }
}
