using NUnit.Framework;
using StorageMaster;
using StorageMaster.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StorageMester.Tests.Structure
{
    [TestFixture]
    public class VehicleTests
    {
        private Type vehicle;
        [SetUp]
        public void Setup()
        {
            this.vehicle = this.GetType("Vehicle");
        }
        [Test]
        public void ValidateAllVehicles()
        {
            var types = new[] { "Semi", "Van", "Truck", "Vehicle" };
            foreach (var type in types)
            {
                var currentType = GetType(type);
                Assert.IsNotNull(currentType, $"{type} does not exist");
            }
        }
        [Test]
        public void ValidateVehicleProperties()
        {
            
            var actualProperties = vehicle.GetProperties();
            var expectedProperties = new Dictionary<string, Type>() { };
            expectedProperties.Add("Capacity", typeof(int));
            expectedProperties.Add("Trunk", typeof(IReadOnlyCollection<Product>));
            expectedProperties.Add("IsFull", typeof(bool));
            expectedProperties.Add("IsEmpty", typeof(bool));
            foreach (var actualProperty in actualProperties)
            {
                bool IsValid = expectedProperties.Any(x => x.Key == actualProperty.Name && x.Value == actualProperty.PropertyType);
                Assert.That(IsValid);
            }
        }
        [Test]
        public void ValidateVehicleMethods()
        {
            
            var expectedMethods = new List<Method>();
            expectedMethods.Add(new Method(typeof(void), "LoadProduct", typeof(Product)));
            expectedMethods.Add(new Method(typeof(Product), "Unload"));

            foreach (var expectedMethod in expectedMethods)
            {
                var currentMethod = vehicle.GetMethod(expectedMethod.Name);
                Assert.IsNotNull(currentMethod, $"{expectedMethod.Name} does not exist");

                var currrentMethodReturnType = currentMethod.ReturnType == expectedMethod.ReturnType;
                Assert.That(currrentMethodReturnType, $"{expectedMethod.Name} invalid return type");

                var expextedMethodParams = expectedMethod.InputParameters;
                var actualParams = currentMethod.GetParameters();

                for (int i = 0; i < expextedMethodParams.Length; i++)
                {
                    var actualParam = actualParams[i].ParameterType;
                    var expectedParam = expextedMethodParams[i];
                    Assert.AreEqual(expectedParam, actualParam);
                }
            }

        }
        [Test]
        public void ValidateVehicleFields()
        {
           
            var trunkField = vehicle.GetField("trunk", BindingFlags.NonPublic | BindingFlags.Instance);
            Assert.IsNotNull(trunkField, $"Invalid field");
        }
        [Test]
        public void ValidateVehicleIsAbstract()
        {
            
            Assert.That(vehicle.IsAbstract);
        }
        [Test]
        public void ValidateVehicleChildClasses()
        {
            var derivedTypes = new [] {GetType("Semi"), GetType("Truck"), GetType("Van")};
            foreach (var derivedType in derivedTypes)
            {
                Assert.That(derivedType.BaseType, Is.EqualTo(vehicle), $"{derivedType} does not inherit vehicle");
            }

        }
        [Test]
        public void ValidateVehicleConstructor()
        {
            var flags = BindingFlags.NonPublic | BindingFlags.Instance;
            var constructor = this.vehicle.GetConstructors(flags).FirstOrDefault();
            Assert.IsNotNull(constructor, "Constructor does not exist");
            var constructorParams = constructor.GetParameters();

            Assert.That(constructorParams[0].ParameterType, Is.EqualTo(typeof(int)));
        }

        private class Method
        {
            public Method( Type returnType, string name,params Type[] inputParameters)
            {
                this.Name = name;
                this.ReturnType = returnType;
                this.InputParameters = inputParameters;
            }

            public string Name { get; set; }

            public Type ReturnType { get; set; }

            public Type[] InputParameters { get; set; }
        }
        private Type GetType(string type)
        {
            var targetType = typeof(StartUp).Assembly.GetTypes().FirstOrDefault(x => x.Name == type);
            return targetType;
        }
    }
}
