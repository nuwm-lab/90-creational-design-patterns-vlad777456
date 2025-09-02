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
    public class Mage : IHero
    {
        public string Name { get; }
        public int Health { get; private set; }

        public Mage(string name, int health = 80)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            Name = name;
            Health = health;
        }

        public void PerformAction()
        {
            Console.WriteLine($"{Name} (Mage) casts Fireball! - Health: {Health}");
        }
    }

    public class Warrior : IHero
    {
        public string Name { get; }
        public int Health { get; private set; }

        public Warrior(string name, int health = 120)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            Name = name;
            Health = health;
        }

        public void PerformAction()
        {
            Console.WriteLine($"{Name} (Warrior) strikes with a sword! - Health: {Health}");
        }
    }

    public class Archer : IHero
    {
        public string Name { get; }
        public int Health { get; private set; }

        public Archer(string name, int health = 90)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be empty.");

            Name = name;
            Health = health;
        }

        public void PerformAction()
        {
            Console.WriteLine($"{Name} (Archer) shoots an arrow! - Health: {Health}");
        }
    }

    // ----- Abstract factory -----
    public interface IHeroFactory
    {
        IHero CreateMage(string name);
        IHero CreateWarrior(string name);
        IHero CreateArcher(string name);
    }

    // ----- Concrete factories -----
    public class HumanHeroFactory : IHeroFactory
    {
        public IHero CreateMage(string name) => new Mage(name, 80);
        public IHero CreateWarrior(string name) => new Warrior(name, 120);
        public IHero CreateArcher(string name) => new Archer(name, 90);
    }

    public class OrcHeroFactory : IHeroFactory
    {
        public IHero CreateMage(string name) => new Mage(name, 70);
        public IHero CreateWarrior(string name) => new Warrior(name, 150);
        public IHero CreateArcher(string name) => new Archer(name, 85);
    }

    // ----- Client code -----
    public static class Program
    {
        public static void Main()
        {
            // Демонстрація: створюємо дві "сім'ї" героїв
            IHeroFactory humanFactory = new HumanHeroFactory();
            IHeroFactory orcFactory = new OrcHeroFactory();

            // Створюємо партію героїв за допомогою фабрик
            var heroes = new List<IHero>
            {
                humanFactory.CreateMage("Elena"),
                humanFactory.CreateWarrior("Borislav"),
                humanFactory.CreateArcher("Ilya"),

                orcFactory.CreateMage("Gor'uk"),
                orcFactory.CreateWarrior("Thrag"),
                orcFactory.CreateArcher("Rag"),
            };

            // Викликаємо дії героїв через єдиний інтерфейс
            foreach (var hero in heroes)
            {
                hero.PerformAction();
            }

            // Зразок виходу програми
            // Elena (Mage) casts Fireball! - Health: 80
            // Borislav (Warrior) strikes with a sword! - Health: 120
            // Ilya (Archer) shoots an arrow! - Health: 90
            // Gor'uk (Mage) casts Fireball! - Health: 70
            // Thrag (Warrior) strikes with a sword! - Health: 150
            // Rag (Archer) shoots an arrow! - Health: 85
        }
    }
}
