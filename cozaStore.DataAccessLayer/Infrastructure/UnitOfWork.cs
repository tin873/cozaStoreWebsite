using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cozaStore.DataAccessLayer
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory _dbFactory;
        private cozaStoreDbContext _dbContext;

        public cozaStoreDbContext DbContext => _dbContext ?? (_dbContext = _dbFactory.Init());

        public UnitOfWork(IDbFactory dbFactory)
        {
            _dbFactory = dbFactory;
        }
        public int Commit()
        {
            return DbContext.SaveChanges();
        }

        public Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }
    }
}
