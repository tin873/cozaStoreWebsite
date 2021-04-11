using cozaStore.DataAccessLayer;
using cozaStore.Models;
using System.Collections.Generic;

namespace cozaStore.BusinessLogicLayer
{
    public class ProductServices : BaseServices<Product>, IProductServices
    {

        public ProductServices(IUnitOfWork unitOfWork, IGenericReposistory<Product> genericReposistory) : base(unitOfWork, genericReposistory) { }

    }
}
