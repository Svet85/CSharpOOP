namespace FightingArena.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class WarriorTests
    {
        [Test]
        public void ConstructorSetsCorrectValues()
        {
            var warrior = new Warrior("Jo", 10, 40);

            Assert.That(warrior.Name, Is.EqualTo("Jo"));
            Assert.That(warrior.Damage, Is.EqualTo(10));
            Assert.That(warrior.HP, Is.EqualTo(40));
        }

        [Test]
        public void NameCannotBeNullOrEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("", 10, 40), "Name should not be empty or whitespace!");
            Assert.Throws<ArgumentException>(() => new Warrior(null, 10, 40), "Name should not be empty or whitespace!");
        }

        [Test]
        public void DamageCannotBeNegativeOrZero()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Jo", -1, 40), "Damage value should be positive!");
            Assert.Throws<ArgumentException>(() => new Warrior("Jo", 0, 40), "Damage value should be positive!");
        }

        [Test]
        public void HPCannotBeNegative()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Jo", 10, -1), "HP should not be negative!");
        }

        [Test]
        public void ShouldNotBeAbleToAttckIfHPIsBelowOrEqualToMinimumThreshhold()
        {
            var warrior = new Warrior("Jo", 10, 30);
            var warrior_2 = new Warrior("Jo", 10, 20);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior_2), "Your HP is too low in order to attack other warriors!");
            Assert.Throws<InvalidOperationException>(() => warrior_2.Attack(warrior), "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void ShouldNotBeAbleToAttckIfOpponenetHPIsBelowOrEqualToMinimumThreshhold()
        {
            var warrior = new Warrior("Jo", 10, 40);
            var warrior_2 = new Warrior("Jo", 10, 20);
            var warrior_3 = new Warrior("Jo", 10, 30);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior_2), "Enemy HP must be greater than 30 in order to attack him!");
            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior_3), "Enemy HP must be greater than 30 in order to attack him!");
        }

        [Test]
        public void ShouldNotBeAbleToAttckStrongerOpponents()
        {
            var warrior = new Warrior("Jo", 10, 40);
            var warrior_2 = new Warrior("Jo", 50, 40);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(warrior_2), "You are trying to attack too strong enemy");
        }

        [Test]
        public void AttackShouldDecreaseHPCorrectly()
        {
            var warrior = new Warrior("Jo", 40, 50);
            var warrior_2 = new Warrior("Jo", 10, 45);
            var warrior_3 = new Warrior("Jo", 10, 35);

            warrior.Attack(warrior_2);
            warrior.Attack(warrior_3);

            Assert.That(warrior_2.HP, Is.EqualTo(5));
            Assert.That(warrior_3.HP, Is.EqualTo(0));
            Assert.That(warrior.HP, Is.EqualTo(30));

        }
    }
}