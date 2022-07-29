namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {

        [Test]
        public void CheckIfInInitialCapacityIs_16()
        {
            Database data = new Database(new int[16]);

            Assert.That(data.Count, Is.EqualTo(16));
        }


        [Test]
        public void CheckIfInInitialCapacityCannotBeMoreThan_16()
        {
            var array = new int[17];
            Assert.Throws<InvalidOperationException>(() => new Database(array));
        }

        [Test]
        public void ElementsSequentialAdditionVerification()
        {
            Database data = new Database();

            for (int i = 0; i < 16; i++)
            {
                data.Add(1);

                Assert.That(data.Count - 1, Is.EqualTo(i));
            }
        }

        [Test]
        public void CannotAddMoreThan_16_Elements()
        {
            Database data = new Database(new int[16]);

            Assert.Throws<InvalidOperationException>(() => data.Add(1));
        }

        [Test]
        public void RemovesElementAtTheLastPositon()
        {
            int[] array = new int[] { 1 };
            Database data = new Database(1, 2);
            
            data.Remove();
            var result = data.Fetch();

            CollectionAssert.AreEqual(array, result);
        }

        [Test]
        public void CannotRemoveElementIfEmpty()
        {
            Database data = new Database();

            Assert.Throws<InvalidOperationException>(() => data.Remove(), "The collection is empty!");
        }

        [Test]
        public void FetchMethodReturnsAnArray()
        {
            Database data = new Database(1, 2);

            var type = data.Fetch();

            Assert.IsInstanceOf(typeof(int[]), type);
        }

    }
}
