using System.ComponentModel.DataAnnotations;

namespace CarShop.Models {
    public class CarDescription {


        public CarDescription() {

            
            IsDeleted = false;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Color { get; set; }

        public string Brand { get; set; }

        public bool NewUsed { get; set; }

        public List<SalesMan> SalesMans { get; set; } = new();

        public bool IsDeleted { get; set; }

        public void Update(string name, string color, string brand, bool newused) {

            Name = name;
            Color = color;
            Brand = brand;
            NewUsed = newused;

        }

        public void Delete() {

            IsDeleted = true;
        }
    }


}
