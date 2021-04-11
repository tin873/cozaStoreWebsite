using cozaStore.DataAccessLayer;
using cozaStore.Models;

namespace cozaStore.BusinessLogicLayer
{
    public class ProductDetailServices : BaseServices<ProductDetail>, IProductDetailServices
    {
        public ProductDetailServices(IUnitOfWork unitOfWork, IGenericReposistory<ProductDetail> genericReposistory) : base(unitOfWork, genericReposistory) { }

    }
}
