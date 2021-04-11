using cozaStore.DataAccessLayer;
using cozaStore.Models;

namespace cozaStore.BusinessLogicLayer
{
    public class UserServices : BaseServices<User>, IUserServieces
    {
        public UserServices(IUnitOfWork unitOfWork, IGenericReposistory<User> genericReposistory) : base(unitOfWork, genericReposistory) { }
    }
}
