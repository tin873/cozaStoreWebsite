using cozaStore.DataAccessLayer;
using cozaStore.Models;

namespace cozaStore.BusinessLogicLayer
{
    public class CommentServices : BaseServices<Comment>, ICommentServices
    {
        public CommentServices(IUnitOfWork unitOfWork, IGenericReposistory<Comment> genericReposistory) :base(unitOfWork, genericReposistory) { }
    }
}
