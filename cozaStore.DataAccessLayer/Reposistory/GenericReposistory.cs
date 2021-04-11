using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace cozaStore.DataAccessLayer
{
    public class GenericReposistory<TEntity> : IGenericReposistory<TEntity> where TEntity : class
    {
        #region field
        private cozaStoreDbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        #endregion
        #region properties
        protected IDbFactory DbFactory { get; set; }
        protected cozaStoreDbContext DbContext => _dbContext ?? (_dbContext = DbFactory.Init());
        #endregion
        #region Contructor
        public GenericReposistory(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            _dbSet = DbContext.Set<TEntity>();
        }
        #endregion
        #region implement
        public virtual TEntity Add(TEntity entity)
        {
            return _dbSet.Add(entity);
        }

        public virtual int Count()
        {
            return _dbSet.Count();
        }

        public virtual Task<int> CountAsync()
        {
            return _dbSet.CountAsync();
        }

        public virtual TEntity Delete(TEntity entity)
        {
            if (_dbContext.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            return _dbSet.Remove(entity);
        }

        public virtual IEnumerable<TEntity> DeleteBy(Expression<Func<TEntity, bool>> filter)
        {
            IEnumerable<TEntity> entities = _dbSet.Where(filter).AsEnumerable();
            return _dbSet.RemoveRange(entities);
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter).ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _dbSet.Where(filter).FirstOrDefaultAsync();
        }

        public virtual IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> filter)
        {
            return _dbSet.Where(filter);
        }

        public virtual IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return orderBy != null ? orderBy(query) : query;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _dbSet;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual void Update(TEntity entity)
        {
             _dbSet.AddOrUpdate(entity);
        }

        #endregion
    }
}
