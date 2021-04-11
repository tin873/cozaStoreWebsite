using cozaStore.Common;
using cozaStore.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace cozaStore.BusinessLogicLayer
{
    public class BaseServices<TEntity> : IBaseServices<TEntity> where TEntity : class
    {
        #region fields
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IGenericReposistory<TEntity> _reposistory;
        #endregion
        #region contructor
        public BaseServices(IUnitOfWork unitOfWork, IGenericReposistory<TEntity> genericReposistory)
        {
            _unitOfWork = unitOfWork;
            _reposistory = genericReposistory;
        }
        #endregion
        #region implement
        public virtual int Count()
        {
            return _reposistory.Count();
        }

        public virtual async Task<int> CountAsync()
        {
            return await _reposistory.CountAsync();
        }

        public virtual int Create(TEntity entity)
        {
            _reposistory.Add(entity);
            return _unitOfWork.Commit();
        }

        public virtual async Task<int> CreateAsync(TEntity entity)
        {
            _reposistory.Add(entity);
            return await _unitOfWork.CommitAsync();
        }

        public bool Delete(object id)
        {
            var entity = _reposistory.GetById(id);
            if(entity == null)
            {
                throw new Exception("id không tồn tại!");
            }
            _reposistory.Delete(entity);
            return _unitOfWork.Commit() > 0;
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            var entity = await _reposistory.GetByIdAsync(id);
            if(entity == null)
            {
                throw new Exception("id không tồn tại");
            }
            _reposistory.Delete(entity);
            return await _unitOfWork.CommitAsync() > 0;
        }

        public virtual TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            return _reposistory.Find(filter);
        }

        public virtual IEnumerable<TEntity> FindAll(Expression<Func<TEntity, bool>> filter)
        {
            return _reposistory.FindAll(filter);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _reposistory.FindAllAsync(filter);
        }

        public virtual async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _reposistory.FindAsync(filter);
        }

        public virtual TEntity FindInclude(Expression<Func<TEntity, bool>> filter, string includeProperties = "")
        {
            var query = _reposistory.FindBy(filter);
            foreach (var item in includeProperties.Split(new[] { ","}, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(item);
            }
            return query.FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return _reposistory.GetAll();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _reposistory.GetAllAsync();
        }

        public virtual async Task<PaginatedList<TEntity>> 
            GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, 
            IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "", int page = 1, int pageSize = 10)
        {
            var query = _reposistory.Get(filter: filter, includeProperties: includeProperties);
            if(orderBy != null)
            {
                query = orderBy(query);
            }
            return await PaginatedList<TEntity>.CreateAsync(query.AsNoTracking(), page, pageSize);
        }

        public virtual TEntity GetById(object id)
        {
            return _reposistory.GetById(id);
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await _reposistory.GetByIdAsync(id);
        }

        public virtual IEnumerable<TEntity> GetTop(Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            var query = orderBy(_reposistory.GetAll());
            return query.Take(8);
        }

        public virtual bool Update(TEntity entity)
        {
            _reposistory.Update(entity);
            return _unitOfWork.Commit() > 0;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            _reposistory.Update(entity);
            return await _unitOfWork.CommitAsync()>0;
        }
        #endregion
    }
}
