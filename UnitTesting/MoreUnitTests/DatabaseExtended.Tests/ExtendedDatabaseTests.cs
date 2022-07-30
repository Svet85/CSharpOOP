namespace DatabaseExtended.Tests
{
    using ExtendedDatabase;
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class ExtendedDatabaseTests
    {
        [Test]
        public void ConstructorShouldTakeOnly16People()
        {
            var data = new Person[17];
            var person = new Person(1, "Pesho");

            for (int i = 1; i <= 17; i++)
            {
                var newPerson = new Person(1 + i, $"Sasho{i}");
                data[i - 1] = newPerson;
            }

            Assert.Throws<ArgumentException>(() => new Database(data));
        }
        
        
        [Test]
        public void AddMethodShouldBeAbleToAddAPerson()
        {
            var person = new Person(111, "Sasho");
            var data = new Database();

            int initialCount = data.Count;
            data.Add(person);
            int result = data.Count;

            Assert.That(initialCount, Is.EqualTo(0));
            Assert.That(result, Is.EqualTo(1));

        }

        [Test]
        public void AddMethodShouldNotBeAbleToAddMoreThan16People()
        {
            var data = new Database();
            var person = new Person(1, "Pesho");

            for (int i = 1; i <= 16; i++)
            {
                var newPerson = new Person(1 + i, $"Sasho{i}");
                data.Add(newPerson);
            }

            Assert.Throws<InvalidOperationException>(() => data.Add(person), "Array's capacity must be exactly 16 integers!");
        }


        [Test]
        public void AddMethodShouldNotBeAbleToAddTPersonWithSameId()
        {
            var person = new Person(111, "Sasho");
            var personWithSameId = new Person(111, "Pavel");

            var data = new Database(person);

            Assert.That(() => data.Add(personWithSameId), Throws.TypeOf<InvalidOperationException>(), "There is already user with this Id!");

        }

        [Test]
        public void AddMethodShouldNotBeAbleToAddTPersonWithSameName()
        {
            var person = new Person(111, "Sasho");
            var personWithSameName = new Person(222, "Sasho");

            var data = new Database(person);

            Assert.That(() => data.Add(personWithSameName), Throws.TypeOf<InvalidOperationException>(), "There is already user with this username!");
        }

        [Test]
        public void RemoveMethodShouldRemoveTheLastPerson()
        {
            var person = new Person(111, "Sasho");
            var person_2 = new Person(123, "Pavel");
            var data = new Database(person, person_2);

            data.Remove();
            var foundPerson = data.FindByUsername("Sasho");


            Assert.That(data.Count, Is.EqualTo(1));
            Assert.That(foundPerson, Is.EqualTo(person));
        }

        [Test]
        public void ShouldNotBeAbleToRemoveFromAnEmptyCollection()
        {
            var data = new Database();

            Assert.Throws<InvalidOperationException>(() => data.Remove());
        }

        [Test]
        public void FindByUserNameShouldFindTheRightPerson()
        {
            var person = new Person(111, "Sasho");
            var person_2 = new Person(123, "Pavel");
            var data = new Database(person, person_2);

            var foundPerson = data.FindByUsername("Pavel");

            Assert.That(foundPerson, Is.EqualTo(person_2));
        }

        [Test]
        public void FindByUserNameIsCaseSensitive()
        {
            var person = new Person(111, "Sasho");
            var person_2 = new Person(123, "Pavel");
            var data = new Database(person, person_2);

            Assert.Throws<InvalidOperationException>(() => data.FindByUsername("pavel"), "No user is present by this username!");
        }

        [Test]
        public void FindByUserNameShouldThrowIfPersonWithThatUserNameDoesNotExist()
        {
            var person = new Person(111, "Sasho");
            var person_2 = new Person(123, "Pavel");
            var data = new Database(person, person_2);

            Assert.Throws<InvalidOperationException>(() => data.FindByUsername("Pave"), "No user is present by this username!");
        }

        [Test]
        public void FindByUserNameIsThrowsIfParamIsNullOrEmpty()
        {
            var person = new Person(111, "Sasho");
            var person_2 = new Person(123, "Pavel");
            var data = new Database(person, person_2);

            Assert.Throws<ArgumentNullException>(() => data.FindByUsername(""), "Username parameter is null!");
            Assert.Throws<ArgumentNullException>(() => data.FindByUsername(null), "Username parameter is null!");
        }

        [Test]
        public void FindByIdThrowsifIdDoesNotExist()
        {
            var person = new Person(111, "Sasho");
            var person_2 = new Person(123, "Pavel");
            var data = new Database(person, person_2);

            Assert.Throws<InvalidOperationException>(() => data.FindById(124), "No user is present by this ID!");
        }

        [Test]
        public void FindByIdThrowsifParameterIsNegative()
        {
            var person = new Person(111, "Sasho");
            var person_2 = new Person(123, "Pavel");
            var data = new Database(person, person_2);

            Assert.Throws<ArgumentOutOfRangeException>(() => data.FindById(-123), "Id should be a positive number!");
        }

        [Test]
        public void FindByIdFindsTheRightPerson()
        {
            var person = new Person(111, "Sasho");
            var person_2 = new Person(123, "Pavel");
            var data = new Database(person, person_2);

            var foundPerson = data.FindById(111);

            Assert.That(foundPerson, Is.EqualTo(person));
        }
    }
}