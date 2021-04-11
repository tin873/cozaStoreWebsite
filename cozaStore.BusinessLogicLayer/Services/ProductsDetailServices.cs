using cozaStore.DataAccessLayer;
using cozaStore.Models;

namespace cozaStore.BusinessLogicLayer
{
    public class ProductsDetailServices : BaseServices<ProductsDetail>, IProductsDetailServices
    {
        public ProductsDetailServices(IUnitOfWork unitOfWork, IGenericReposistory<ProductsDetail> genericReposistory) : base(unitOfWork, genericReposistory) { }
    }
}
