using System;
using System.Collections.Generic;
using System.Linq;

namespace WeaponsReport
{
    internal class Program
    {
        static void Main()
        {
            SoldierFactory soldierFactory = new SoldierFactory();
            List<Soldier> soldiers = soldierFactory.Create();

            var soldiersInfo = soldiers.Select(soldier => new { soldier.Name, soldier.Rank });

            foreach (var soldierInfo in soldiersInfo)
                Console.WriteLine($"Имя - {soldierInfo.Name}, звание - {soldierInfo.Rank}.");
        }
    }

    class Soldier
    {
        public Soldier(string name, string weapon, string rank, int militaryServiceMonths)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            MilitaryServiceMonths = militaryServiceMonths;
        }

        public string Name { get; }
        private string Weapon { get; }
        public string Rank { get; }
        private int MilitaryServiceMonths { get; }
    }

    class SoldierFactory
    {
        private List<string> _names;
        private List<string> _weapons;
        private List<string> _ranks;
        private int[] _militaryServiceStatsMonths = { 2, 10 };

        Random _random = new Random();

        public SoldierFactory()
        {
            FillNames();
            FillWeapons();
            FillRanks();
        }

        public List<Soldier> Create()
        {
            List<Soldier> soldiers = new List<Soldier>();
            int soldiersQuantity = 10;

            for (int i = 0; i < soldiersQuantity; i++)
            {
                string name = _names[_random.Next(_names.Count)];
                string weapon = _weapons[_random.Next(_weapons.Count)];
                string rank = _ranks[_random.Next(_ranks.Count)];
                int militaryServiceMonths = _random.Next(_militaryServiceStatsMonths[0], _militaryServiceStatsMonths[1]);

                soldiers.Add(new Soldier(name, weapon, rank, militaryServiceMonths));
            }

            return soldiers;
        }

        private void FillNames() =>
            _names = new List<string>() { "Олег", "Борис", "Джонни", "Сигма", "Микоян" };

        private void FillWeapons() =>
            _weapons = new List<string> { "пистолет", "автомат", "гранатомет", "огнемет" };

        private void FillRanks() =>
            _ranks = new List<string> { "рядовой", "ефрейтор", "младший сержант", "сержант" };
    }
}
