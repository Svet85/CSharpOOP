namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        [Test]
        public void ConstructorAndSettersWorkCoorectlyAndSetsFuelAmountToZero()
        {
            var car = new Car("Ford", "Puma", 2.2, 60.0);

            Assert.That(car.Make, Is.EqualTo("Ford"));
            Assert.That(car.Model, Is.EqualTo("Puma"));
            Assert.That(car.FuelConsumption, Is.EqualTo(2.2));
            Assert.That(car.FuelCapacity, Is.EqualTo(60.0));
            Assert.That(car.FuelAmount, Is.EqualTo(0.0));
        }

        [Test]
        public void CarMakeCannotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Car("", "Puma", 2.2, 60.0), "Make cannot be null or empty!");
            Assert.Throws<ArgumentException>(() => new Car(null, "Puma", 2.2, 60.0), "Make cannot be null or empty!");
        }

        [Test]
        public void CarModelCannotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Car("Ford", "", 2.2, 60.0), "Model cannot be null or empty!");
            Assert.Throws<ArgumentException>(() => new Car("Ford", null, 2.2, 60.0), "Model cannot be null or empty!");
        }

        [Test]
        public void CarFuelConsumptionCannotBeZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new Car("Ford", "Puma", 0.0, 60.0), "Fuel consumption cannot be zero or negative!");
            Assert.Throws<ArgumentException>(() => new Car("Ford", "Puma", -2.2, 60.0), "Fuel consumption cannot be zero or negative!");
        }

        [Test]
        public void CarFuelCapacityCannotBeZeroOrNegative()
        {
            Assert.Throws<ArgumentException>(() => new Car("Ford", "Puma", 2.2, 0.0), "Fuel capacity cannot be zero or negative!");
            Assert.Throws<ArgumentException>(() => new Car("Ford", "Puma", 2.2, -60.0), "Fuel capacity cannot be zero or negative!");
        }

        [Test]
        public void RefuelShouldAddTheCoorectAmmountOfFule()
        {
            var car = new Car("Ford", "Puma", 2.2, 60.0);

            car.Refuel(10.0);

            Assert.That(car.FuelAmount, Is.EqualTo(10));
        }

        [Test]
        public void RefuelShouldNotAddOverTheCapacity()
        {
            var car = new Car("Ford", "Puma", 2.2, 60.0);

            car.Refuel(70.0);

            Assert.That(car.FuelAmount, Is.EqualTo(60));
        }

        [Test]
        public void RefuelShouldNotBeZero()
        {
            var car = new Car("Ford", "Puma", 2.2, 60.0);

            Assert.Throws<ArgumentException>(() => car.Refuel(0.0), "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void RefuelShouldNotBeNegative()
        {
            var car = new Car("Ford", "Puma", 2.2, 60.0);

            Assert.Throws<ArgumentException>(() => car.Refuel(-10.0), "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void DriveShouldThrowIfDistanceIsTooLong()
        {
            var car = new Car("Ford", "Puma", 100.0, 60.0);

            car.Refuel(10);

            Assert.Throws<InvalidOperationException>(() => car.Drive(100.0), "Fuel amount cannot be zero or negative!");
        }

        [Test]
        public void DriveShouldConsumeCorrextAmountOfFuel()
        {
            var car = new Car("Ford", "Puma", 100.0, 60.0);

            car.Refuel(10);
            car.Drive(10.0);

            Assert.That(car.FuelAmount, Is.EqualTo(0));
        }
    }
}