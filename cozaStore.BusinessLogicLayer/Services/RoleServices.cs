using cozaStore.DataAccessLayer;
using cozaStore.Models;

namespace cozaStore.BusinessLogicLayer
{
    public class RoleServices : BaseServices<Role>, IRoleServices
    {
        public RoleServices(IUnitOfWork unitOfWork, IGenericReposistory<Role> genericReposistory) : base(unitOfWork, genericReposistory) { }

    }
}
