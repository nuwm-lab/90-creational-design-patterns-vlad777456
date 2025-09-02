using System;
using System.Collections.Generic;

namespace GameFactory
{
    // ----- Abstract product interfaces -----
    /// <summary>
    /// Common interface for Mages.
    /// </summary>
    public interface IMage
    {
        string Name { get; }
        int Health { get; }
        void CastSpell();
    }

    /// <summary>
    /// Common interface for Warriors.
    /// </summary>
    public interface IWarrior
    {
        string Name { get; }
        int Health { get; }
        void Strike();
    }

    /// <summary>
    /// Common interface for Archers.
    /// </summary>
    public interface IArcher
    {
        string Name { get; }
        int Health { get; }
        void Shoot();
    }

    // ----- Abstract factory -----
    /// <summary>
    /// Абстрактна фабрика, яка визначає створення сімейства героїв.
    /// </summary>
    public interface IHeroFactory
    {
        IMage CreateMage(string name);
        IWarrior CreateWarrior(string name);
        IArcher CreateArcher(string name);
    }

    // ----- Concrete factories -----
    /// <summary>
    /// Фабрика створює людських героїв (Human).
    /// </summary>
    public class HumanHeroFactory : IHeroFactory
    {
        public IMage CreateMage(string name) => new HumanMage(name);
        public IWarrior CreateWarrior(string name) => new HumanWarrior(name);
        public IArcher CreateArcher(string name) => new HumanArcher(name);
    }

    /// <summary>
    /// Фабрика створює орків (Orc) — інша «сім'я» продуктів.
    /// </summary>
    public class OrcHeroFactory : IHeroFactory
    {
        public IMage CreateMage(string name) => new OrcMage(name);
        public IWarrior CreateWarrior(string name) => new OrcWarrior(name);
        public IArcher CreateArcher(string name) => new OrcArcher(name);
    }

    // ----- Concrete products (Human) -----
    public class HumanMage : IMage
    {
        public string Name { get; }
        public int Health { get; private set; }

        public HumanMage(string name)
        {
            Name = name;
            Health = 80; // приклад початкового значення
        }

        public void CastSpell()
        {
            Console.WriteLine($"{Name} (Human Mage) casts Fireball! - Health: {Health}");
        }
    }

    public class HumanWarrior : IWarrior
    {
        public string Name { get; }
        public int Health { get; private set; }

        public HumanWarrior(string name)
        {
            Name = name;
            Health = 120;
        }

        public void Strike()
        {
            Console.WriteLine($"{Name} (Human Warrior) strikes with a sword! - Health: {Health}");
        }
    }

    public class HumanArcher : IArcher
    {
        public string Name { get; }
        public int Health { get; private set; }

        public HumanArcher(string name)
        {
            Name = name;
            Health = 90;
        }

        public void Shoot()
        {
            Console.WriteLine($"{Name} (Human Archer) shoots an arrow! - Health: {Health}");
        }
    }

    // ----- Concrete products (Orc) -----
    public class OrcMage : IMage
    {
        public string Name { get; }
        public int Health { get; private set; }

        public OrcMage(string name)
        {
            Name = name;
            Health = 70;
        }

        public void CastSpell()
        {
            Console.WriteLine($"{Name} (Orc Mage) curses the enemy! - Health: {Health}");
        }
    }

    public class OrcWarrior : IWarrior
    {
        public string Name { get; }
        public int Health { get; private set; }

        public OrcWarrior(string name)
        {
            Name = name;
            Health = 150;
        }

        public void Strike()
        {
            Console.WriteLine($"{Name} (Orc Warrior) performs a brutal strike! - Health: {Health}");
        }
    }

    public class OrcArcher : IArcher
    {
        public string Name { get; }
        public int Health { get; private set; }

        public OrcArcher(string name)
        {
            Name = name;
            Health = 85;
        }

        public void Shoot()
        {
            Console.WriteLine($"{Name} (Orc Archer) fires a heavy bolt! - Health: {Health}");
        }
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
            var heroes = new List<object>
            {
                humanFactory.CreateMage("Elena"),
                humanFactory.CreateWarrior("Borislav"),
                humanFactory.CreateArcher("Ilya"),

                orcFactory.CreateMage("Gor'uk"),
                orcFactory.CreateWarrior("Thrag"),
                orcFactory.CreateArcher("Rag"),
            };

            // Викликаємо поведінку продуктів (через їх конкретні інтерфейси)
            foreach (var hero in heroes)
            {
                switch (hero)
                {
                    case IMage mage:
                        mage.CastSpell();
                        break;
                    case IWarrior warrior:
                        warrior.Strike();
                        break;
                    case IArcher archer:
                        archer.Shoot();
                        break;
                }
            }

            // Зразок виходу програми
            // Elena (Human Mage) casts Fireball! - Health: 80
            // Borislav (Human Warrior) strikes with a sword! - Health: 120
            // Ilya (Human Archer) shoots an arrow! - Health: 90
            // Gor'uk (Orc Mage) curses the enemy! - Health: 70
            // Thrag (Orc Warrior) performs a brutal strike! - Health: 150
            // Rag (Orc Archer) fires a heavy bolt! - Health: 85
        }
    }
}
