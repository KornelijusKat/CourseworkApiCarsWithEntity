using CarThing.CarClasses;
using CarThing.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarThing.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : Controller
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICar _cars;
        public CarController(ICar cars, ILogger<CarController> logger)
        {
            _cars = cars;
            _logger = logger;
        }
        [HttpGet("getter")]
        public IEnumerable<Car> GetAllCars()
        {
          
            foreach(var x in _cars.GetCars())
            {
                _logger.LogInformation(Convert.ToString(x.Id) + " " + x.Model +" " + x.Color);
            }
           
            return _cars.GetCars();
        }
        [HttpGet("Colorgetter")]
        public IEnumerable<Car> GetAllCarsByColor([FromQuery] string Color)
        {
            foreach (var x in _cars.GetCarsByColor(Color))
            {
                _logger.LogInformation(Convert.ToString(x.Id) + " " + x.Model + " " + x.Color);
            }
            return  _cars.GetCarsByColor(Color);
        }
        [HttpPost("Poster")]
        public ActionResult<CarDto>  AddNewCar(CarDto Carlio)
        {          
            _cars.AddCar(Carlio);
            _logger.LogInformation(Carlio.Model + " " + Carlio.Color);
            return Carlio;
        }
        [HttpPut("Putter")]
        public ActionResult<Car> UpdateCar([FromQuery]string Id,[FromBody]CarDto Carlio)
        {
          
            var terra =  _cars.CarUpdater(Id, Carlio);
            if(terra == null)
            {
                return NotFound();
            }
            _logger.LogInformation(Id + Carlio.Color + Carlio.Model);
            return terra;
        }
        [HttpDelete("Deleter")]
        public void DeleteCar([FromQuery] string Id)
        {

            _logger.LogInformation(Id);
            _logger.LogError(Id);
            _cars.CarDeleter(Id);
        }
    }
}
