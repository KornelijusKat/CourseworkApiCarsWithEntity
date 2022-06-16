using AutoFixture.Xunit2;
using System;
using Xunit;
using CarThing.CarClasses;
using Moq;
using CarThing.Interface;
using CarThing.Controllers;
using Microsoft.Extensions.Logging;
//using CarThing.Tests.SpecimenBuilder;
using System.Collections.Generic;

namespace CarThing.Tests
{
    public class UnitTest1
    {
        //[Theory,CarData]
        //public void Test1(List<Car> car)
        //{
        //    //arrange
        //    var RepMock = new Mock<ICar>();
        //    var logMock = new Mock<ILogger<CarController>>();
        //    var sut = new CarController(RepMock.Object, logMock.Object);
        //    RepMock.Setup(x => x.GetCarsByColor(It.IsAny<string>())).Returns(car);
        //    //act
        //    var testResponse = sut.GetAllCarsByColor(It.IsAny<string>());
        //    //Assert
        //    Assert.NotNull(testResponse);
        //}

        [Theory, AutoData]
        public void Test2(CarDto car)
        {
            //arrange
            var RepMock = new Mock<ICar>();
            var logMock = new Mock<ILogger<CarController>>();
            var sut = new CarController(RepMock.Object, logMock.Object);
            RepMock.Setup(x => x.AddCar(It.IsAny<CarDto>())).Returns(car);
            //act
            var testResponse = sut.AddNewCar(car);
            //Assert
            Assert.NotNull(testResponse.Value);
        }
        //[Theory, AutoData]
        //public void Test_When_Record_Not_In_Repository()
        //{
        //    //arrange
        //    var RepMock = new Mock<ICar>();
        //    var logMock = new Mock<ILogger<CarController>>();
        //    var sut = new CarController(RepMock.Object, logMock.Object);
        //    RepMock.Setup(x => x.CarUpdater(It.IsAny<string>(), It.IsAny<CarDto>())).Returns((Car)null);
        //    //act
        //    var testResponse = sut.UpdateCar(It.IsAny<string>(),It.IsAny<CarDto>());
        //    //Assert
        //    var type = testResponse.Result.GetType();
        //    Assert.Equal("NotFoundResult", type.Name);
        //}

    }
}
