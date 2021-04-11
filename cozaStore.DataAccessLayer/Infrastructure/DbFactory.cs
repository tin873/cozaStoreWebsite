namespace cozaStore.DataAccessLayer
{
    public class DbFactory : Disposable, IDbFactory
    {
        private cozaStoreDbContext _dbcontext;

        public cozaStoreDbContext Init() => _dbcontext ?? (_dbcontext = new cozaStoreDbContext());

        protected override void DisposeCore()
        {
            if(_dbcontext != null)
            {
                _dbcontext.Dispose();
            }
        }
    }
}
