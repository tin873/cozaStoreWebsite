using cozaStore.DataAccessLayer;
using cozaStore.Models;

namespace cozaStore.BusinessLogicLayer
{
    public class SupplierServices : BaseServices<Supplier>, ISupplierServices
    {
        public SupplierServices(IUnitOfWork unitOfWork, IGenericReposistory<Supplier> genericReposistory) : base(unitOfWork, genericReposistory) { }
    }
}
