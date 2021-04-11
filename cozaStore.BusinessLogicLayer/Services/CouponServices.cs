using cozaStore.DataAccessLayer;
using cozaStore.Models;

namespace cozaStore.BusinessLogicLayer
{
    public class CouponServices : BaseServices<Coupon>, ICouponServices
    {
        public CouponServices(IUnitOfWork unitOfWork, IGenericReposistory<Coupon> genericReposistory) : base(unitOfWork, genericReposistory) { }
    }
}
