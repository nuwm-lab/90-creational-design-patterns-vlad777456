using System;
using System.Collections.Generic;

namespace GameFactory
{
    // ----- Base interface -----
    /// <summary>
    /// Загальний інтерфейс для всіх героїв.
    /// </summary>
    public interface IHero
    {
        string Name { get; }
        int Health { get; }
        void PerformAction();
    }

    // ----- Hero types -----
    /// <summary>
    /// Клас Мага.
    /// </summary>
    public class Mage : IHero
    {
        public string Name { get; }
        public int Health { get; private set; }

        public Mage(string name, int health = 80)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");
            if (health <= 0)
                throw new ArgumentException("Health must be greater than zero.");

            Name = name;
            Health = health;
        }

        public void PerformAction() => Console.WriteLine($"{Name} (Mage) casts Fireball! - Health: {Health}");
    }

    /// <summary>
    /// Клас Воїна.
    /// </summary>
    public class Warrior : IHero
    {
        public string Name { get; }
        public int Health { get; private set; }

        public Warrior(string name, int health = 120)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");
            if (health <= 0)
                throw new ArgumentException("Health must be greater than zero.");

            Name = name;
            Health = health;
        }

        public void PerformAction() => Console.WriteLine($"{Name} (Warrior) strikes with a sword! - Health: {Health}");
    }

    /// <summary>
    /// Клас Лучника.
    /// </summary>
    public class Archer : IHero
    {
        public string Name { get; }
        public int Health { get; private set; }

        public Archer(string name, int health = 90)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");
            if (health <= 0)
                throw new ArgumentException("Health must be greater than zero.");

            Name = name;
            Health = health;
        }

        public void PerformAction() => Console.WriteLine($"{Name} (Archer) shoots an arrow! - Health: {Health}");
    }

    // ----- Abstract factory -----
    /// <summary>
    /// Базова фабрика для створення героїв.
    /// </summary>
    public abstract class HeroFactory
    {
        public abstract IHero CreateMage(string name);
        public abstract IHero CreateWarrior(string name);
        public abstract IHero CreateArcher(string name);
    }

    // ----- Concrete factories -----
    /// <summary>
    /// Фабрика для створення Людей.
    /// </summary>
    public class HumanHeroFactory : HeroFactory
    {
        public override IHero CreateMage(string name) => new Mage(name, 80);
        public override IHero CreateWarrior(string name) => new Warrior(name, 120);
        public override IHero CreateArcher(string name) => new Archer(name, 90);
    }

    /// <summary>
    /// Фабрика для створення Орків.
    /// </summary>
    public class OrcHeroFactory : HeroFactory
    {
        public override IHero CreateMage(string name) => new Mage(name, 70);
        public override IHero CreateWarrior(string name) => new Warrior(name, 150);
        public override IHero CreateArcher(string name) => new Archer(name, 85);
    }

    // ----- Client code -----
    public static class Program
    {
        public static void Main()
        {
            HeroFactory humanFactory = new HumanHeroFactory();
            HeroFactory orcFactory = new OrcHeroFactory();

            var heroes = new List<IHero>
            {
                humanFactory.CreateMage("Elena"),
                humanFactory.CreateWarrior("Borislav"),
                humanFactory.CreateArcher("Ilya"),

                orcFactory.CreateMage("Gor'uk"),
                orcFactory.CreateWarrior("Thrag"),
                orcFactory.CreateArcher("Rag"),
            };

            foreach (var hero in heroes)
            {
                hero.PerformAction();
            }
        }
    }
}
