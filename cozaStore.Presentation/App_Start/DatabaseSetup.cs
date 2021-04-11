using cozaStore.DataAccessLayer;
using System.Data.Entity;

namespace cozaStore.Presentation.App_Start
{
    internal class DatabaseSetup
    {
        public static void Initialize()
        {
            Database.SetInitializer(new DbInitializer());
            using(var db = new cozaStoreDbContext())
            {
                db.Database.Initialize(true);
            }
        }
    }
}