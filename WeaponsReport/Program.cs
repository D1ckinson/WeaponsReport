using System;
using System.Collections.Generic;
using System.Linq;

namespace WeaponsReport
{
    internal class Program
    {
        static void Main()
        {
            int soldierQuantity = 10;
            List<Soldier> soldiers = new List<Soldier>();
            SoldierFabrik soldierFabrik = new SoldierFabrik();

            for (int i = 0; i < soldierQuantity; i++)
                soldiers.Add(soldierFabrik.CreateSoldier());

            var soldiersInfo = soldiers.Select(soldier => new { soldier.Name, soldier.Rank });

            foreach (var soldierInfo in soldiersInfo)
                Console.WriteLine($"Имя - {soldierInfo.Name}, звание - {soldierInfo.Rank}.");
        }
    }

    class Soldier
    {
        public Soldier(string name, string weapon, string rank, int productionYear)
        {
            Name = name;
            Weapon = weapon;
            Rank = rank;
            MilitaryServiceMonths = productionYear;
        }

        public string Name { get; private set; }
        public string Weapon { get; private set; }
        public string Rank { get; private set; }
        public int MilitaryServiceMonths { get; private set; }
    }

    class SoldierFabrik
    {
        private List<string> _names;
        private List<string> _weapons;
        private List<string> _ranks;
        private int[] _militaryServiceStatsMonths = { 2, 10 };

        Random _random = new Random();

        public SoldierFabrik()
        {
            FillNames();
            FillWeapons();
            FillRanks();
        }

        public Soldier CreateSoldier()
        {
            string name = _names[_random.Next(_names.Count)];
            string weapon = _weapons[_random.Next(_weapons.Count)];
            string rank = _ranks[_random.Next(_ranks.Count)];
            int militaryServiceMonths = _random.Next(_militaryServiceStatsMonths[0], _militaryServiceStatsMonths[1]);

            return new Soldier(name, weapon, rank, militaryServiceMonths);
        }

        private void FillNames() =>
            _names = new List<string>() { "Олег", "Борис", "Джонни", "Сигма", "Микоян" };

        private void FillWeapons() =>
            _weapons = new List<string> { "пистолет", "автомат", "гранатомет", "огнемет" };

        private void FillRanks() =>
            _ranks = new List<string> { "рядовой", "ефрейтор", "младший сержант", "сержант" };
    }
}
