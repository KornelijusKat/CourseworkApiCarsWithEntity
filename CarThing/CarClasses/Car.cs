using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarThing.CarClasses
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }

        public Car(Guid id, string model, string color)
        {
            Id = id;
            Model = model;
            Color = color;
        }
    }
}
