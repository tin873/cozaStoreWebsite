using cozaStore.DataAccessLayer;
using cozaStore.Models;

namespace cozaStore.BusinessLogicLayer
{
    public class CategoryServices : BaseServices<Category>, ICategoryServices
    {
        public CategoryServices(IUnitOfWork unitOfWork, IGenericReposistory<Category> genericReposistory) : base(unitOfWork, genericReposistory) { }

    }
}
