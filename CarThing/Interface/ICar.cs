using CarThing.CarClasses;
using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarThing.Interface
{
    public interface ICar
    {
        CarDto AddCar(CarDto car);
        IEnumerable<Car> GetCars();
        IEnumerable<Car> GetCarsByColor(string color);

        Car CarUpdater(string Id, CarDto car);
        void CarDeleter(string Id);
    }
}
