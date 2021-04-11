using cozaStore.DataAccessLayer;
using cozaStore.Models;

namespace cozaStore.BusinessLogicLayer
{
    public class OrderDetailServices : BaseServices<OrderDetail>, IOrderDetailServices
    {
        public OrderDetailServices(IUnitOfWork unitOfWork, IGenericReposistory<OrderDetail> genericReposistory) : base(unitOfWork, genericReposistory) { }
    }
}
