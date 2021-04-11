using cozaStore.DataAccessLayer;
using cozaStore.Models;

namespace cozaStore.BusinessLogicLayer
{
    public class OrderServices : BaseServices<Order>, IOrderServices
    {
        public OrderServices(IUnitOfWork unitOfWork, IGenericReposistory<Order> genericReposistory) : base(unitOfWork, genericReposistory) { }
    }
}
