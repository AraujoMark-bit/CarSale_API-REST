using CarShop.Models;

namespace CarShop.Persistence {
    public class DbContext {


        public List<CarDescription> CarDescriptions { get; set; }

        public DbContext() {
            CarDescriptions = new List<CarDescription>();
        }
    }
}
