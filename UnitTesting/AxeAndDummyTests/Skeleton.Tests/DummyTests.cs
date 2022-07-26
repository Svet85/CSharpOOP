namespace Skeleton.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DummyTests
    {
        
        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            var dummy = new Dummy(10,10);
            dummy.TakeAttack(1);
            Assert.That(dummy.Health, Is.EqualTo(9));
        }

        [Test]
        public void DeadDummyThrowsAnExceptionIfAttacked()
        {
            var dummy = new Dummy(0, 10);
            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(1), "Dummy is dead.");
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            var dummy = new Dummy(0, 10);
            int result = dummy.GiveExperience();
            Assert.AreEqual(10, result);
        }

        [Test]
        public void AliveDummyCannotGiveXP()
        {
            var dummy = new Dummy(10, 10);
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience(), "Target is not dead.");
        }
    }
}
