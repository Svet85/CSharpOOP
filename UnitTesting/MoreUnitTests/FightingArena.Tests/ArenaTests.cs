namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class ArenaTests
    {
        [Test]
        public void ConstructorShouldSetCountToZero()
        {
            var arena = new Arena();

            int count = arena.Count;

            Assert.That(count, Is.EqualTo(0));
        }

        [Test]
        public void EnrollShouldNotAddWarriorWithTheSameName()
        {
            var arena = new Arena();
            var warrior = new Warrior("Jo", 10, 50);
            var warrior_2 = new Warrior("Jo", 20, 50);

            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(warrior_2), "Warrior is already enrolled for the fights!");
        }

        [Test]
        public void EnrollShouldAddWarriorToTheCollection()
        {
            var arena = new Arena();
            var warrior = new Warrior("Jo", 10, 50);
            var warrior_2 = new Warrior("Mo", 20, 50);

            arena.Enroll(warrior);
            arena.Enroll(warrior_2);
            var list = new List<Warrior> { warrior, warrior_2 };
            var result = arena.Warriors.ToList();

            CollectionAssert.AreEqual(list, result);
        }

        [Test]
        public void FightShouldNotWorkWithNonExistingWarriors()
        {
            var arena = new Arena();
            var warrior = new Warrior("Jo", 10, 50);
            var warrior_2 = new Warrior("Mo", 20, 50);

            arena.Enroll(warrior);
            arena.Enroll(warrior_2);

            Assert.Throws<InvalidOperationException>(() => arena.Fight("Jo", "Pada"), "There is no fighter with name Pada enrolled for the fights!");
            Assert.Throws<InvalidOperationException>(() => arena.Fight("Coco", "Mo"), $"There is no fighter with name Coco enrolled for the fights!");
            Assert.That(warrior.HP, Is.EqualTo(50));
            Assert.That(warrior_2.HP, Is.EqualTo(50));
        }

        [Test]
        public void FightingShouldRemoveTheCorrectAmountOfHP()
        {
            var arena = new Arena();
            var warrior = new Warrior("Jo", 10, 50);
            var warrior_2 = new Warrior("Mo", 20, 50);

            arena.Enroll(warrior);
            arena.Enroll(warrior_2);
            arena.Fight("Jo", "Mo");

            Assert.That(warrior.HP, Is.EqualTo(30));
            Assert.That(warrior_2.HP, Is.EqualTo(40));
        }
    }
}
