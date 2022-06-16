using CarThing.CarClasses;
using CarThing.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarThing.CarRepository
{
    public class CarRepo : ICar
    {
        private readonly CarDbContext _conxtext;
        public CarRepo(CarDbContext context, ILogger<CarRepo> logger)
        {
            _conxtext = context;
            _logger = logger;
        }
        //private readonly List<TodoTask> _cars = new();
        public List<Car> carList = new List<Car>() { new Car(Guid.Parse("baadf369-c8ce-4f47-a470-43cc8c2b15b0"), "Mondeo", "Red"),
        new Car(Guid.Parse("423b3811-5790-432d-a9b9-6ef2cb72a67b"), "Kuga", "Red") ,
        new Car(Guid.Parse("1f7904b6-180b-4a5f-af02-1e684141a408"), "Focus", "Blue") ,
        new Car(Guid.NewGuid(), "Escape", "BucketColor") };
        private readonly ILogger<CarRepo> _logger;
        public CarDto AddCar(CarDto car)
        {
         
                var newCar = new Car(Guid.NewGuid(), car.Model, car.Color);
                carList.Add(newCar);
                _conxtext.Cars.Add(newCar);
                _conxtext.SaveChanges();
            return car;
           
        }

        public void CarDeleter(string Id)
        {
            //var DeleteCar = carList.First(x => x.Id == Guid.Parse(Id));
            //carList.Remove(DeleteCar);
            try
            {
                var DeleteCar = _conxtext.Cars.Where(x => x.Id == Guid.Parse(Id)).FirstOrDefault();
                _conxtext.Cars.Remove(DeleteCar);
                _conxtext.SaveChanges();
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message);
            }
           

        }

        public Car CarUpdater(string Id, CarDto car)
        {
            var updatedCar = _conxtext.Cars.Where(x => x.Id == Guid.Parse(Id)).FirstOrDefault();
            updatedCar.Model = car.Model;
            updatedCar.Color = car.Color;
            _conxtext.SaveChanges();
            return updatedCar;
        }

        public IEnumerable<Car> GetCars()
        {
            return _conxtext.Cars.ToList();
        }

        public IEnumerable<Car> GetCarsByColor(string Color)
        {
            var newList = _conxtext.Cars.ToList().FindAll(x => x.Color == Color);
            return newList;
        }
    }
}
