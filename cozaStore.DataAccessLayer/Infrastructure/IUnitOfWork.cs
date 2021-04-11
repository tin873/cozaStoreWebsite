using System.Threading.Tasks;

namespace cozaStore.DataAccessLayer
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
