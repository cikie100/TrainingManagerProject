using DataLayer;

namespace DataLayer
{
   
    public class TrainingContextTests : TrainingContext
    {
        public TrainingContextTests(bool keepExistingDB = false) : base("Test") {
            if (keepExistingDB)
            {
                Database.EnsureCreated();
            }
            else {
                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        
        
        }
    }
}
