using cozaStore.DataAccessLayer;
using cozaStore.Models;

namespace cozaStore.BusinessLogicLayer
{
    public class ContactServices : BaseServices<Contact>, IContactServices
    {
        public ContactServices(IUnitOfWork unitOfWork, IGenericReposistory<Contact> genericReposistory) : base(unitOfWork, genericReposistory) { }
    }
}
