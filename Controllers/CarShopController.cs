using CarShop.Models;
using CarShop.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarShop.Controllers {

    [Route("api/carshop")]
    [ApiController]
    public class CarShopController : ControllerBase {

        private readonly DbContext _dbContext;

        public CarShopController(DbContext dbContext) {
            _dbContext = dbContext;
        }

        //api/carshop/ GET
        [HttpGet]
        public IActionResult GetAll() {

            var carDescription = _dbContext.CarDescriptions.Where(d => !d.IsDeleted).ToList();

            return Ok(carDescription);
        }

        //api/carshop/3fa85f64-5717-4562-b3fc-2c963f66afa6 GET
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) {

            var carDescription = _dbContext.CarDescriptions.Where(d => !d.IsDeleted).SingleOrDefault(d => d.Id == id);

            if (carDescription is null) { return NotFound(); }

            return Ok(carDescription);

        }

        //api/carshop/3fa85f64-5717-4562-b3fc-2c963f66afa6 POST
        [HttpPost]
        public IActionResult Post(CarDescription carDescription) {

            _dbContext.CarDescriptions.Add(carDescription);

            return CreatedAtAction(nameof(GetById), new { id = carDescription.Id }, carDescription);

        }

        //api/carshop/3fa85f64-5717-4562-b3fc-2c963f66afa6 PUT
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, CarDescription input) {

            var carDescription = _dbContext.CarDescriptions.SingleOrDefault(d => d.Id == id);

            if (carDescription is null) { return NotFound(); }

            carDescription.Update(input.Name, input.Color, input.Brand, input.NewUsed);

            return NoContent();
        }

        //api/carshop/3fa85f64-5717-4562-b3fc-2c963f66afa6 DELETE
        [HttpDelete("id")]
        public IActionResult Delete(Guid id) {
            var carDescription = _dbContext.CarDescriptions.SingleOrDefault(d => d.Id == id);

            if (carDescription is null) { return NotFound(); }

            carDescription.Delete();
            return NoContent();

        }

        //api/carshop/3fa85f64-5717-4562-b3fc-2c963f66afa6/salesman
        [HttpPost("{id}/salesman")]
        public IActionResult PostSalesMan(Guid id,SalesMan salesMan) {

            var carDescription = _dbContext.CarDescriptions.SingleOrDefault(d => d.Id == id);

            if (carDescription is null) { return NotFound(); }

            carDescription.SalesMans.Add(salesMan);

            return NoContent();
        }
    }
}
