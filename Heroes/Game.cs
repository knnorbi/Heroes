using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Heroes
{
    class Game
    {
        List<Hero> heroes = new List<Hero>();
        Random random = new Random(1);

        public bool OnGoing
        {
            get
            {
                return NumberOfEvils > 0 && NumberOfGoodGuys > 0;
            }
        }

        public int NumberOfEvils { 
            get
            {
                int n = 0;
                foreach (var hero in heroes)
                {
                    if (hero.Evil)
                        n++;
                }
                return n;
            }
        }

        public int NumberOfGoodGuys 
        { 
            get 
            {
                int n = 0;
                foreach (var hero in heroes)
                {
                    if (!hero.Evil)
                        n++;
                }
                return n;
            } 
        }

        public Game(string path)
        {
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] data = lines[i].Split(';');

                string name = data[0];
                int health = int.Parse(data[1]);
                int strength = int.Parse(data[2]);
                double charge = double.Parse(data[3]);
                charge = charge / 10 + 1;
                bool evil = data[4] == "Yes" ? true : false;

                Hero hero = new Hero(name, health, strength, charge, evil);
                heroes.Add(hero);
            }
        }

        public void RandomAttack()
        {
            try
            {
                int aIdx = random.Next(0, heroes.Count);
                int vIdx = random.Next(0, heroes.Count);

                Console.WriteLine("{0} megtámadja {1}-t.", heroes[aIdx].Name, heroes[vIdx].Name);
                Console.WriteLine(heroes[aIdx]);
                Console.WriteLine(heroes[vIdx]);

                bool success = heroes[vIdx].Attack(heroes[aIdx]);

                Console.WriteLine("{0} {1}halott.", heroes[vIdx].Name, success ? "" : "nem ");
                Console.WriteLine(heroes[aIdx]);
                Console.WriteLine(heroes[vIdx]);
                Console.WriteLine("---------------------");

                if (success)
                    heroes.RemoveAt(vIdx);
            }
            catch (Exception e)
            {
                Console.WriteLine("HIBA: " + e.Message);
                Console.WriteLine("---------------------");
            }
        }

        public void AddHero(Hero hero)
        {
            heroes.Add(hero);

            //int elemek = heroes.Count;
            //Hero elso = heroes[0];
        }

        public void WhoWon()
        {
            if (OnGoing) return;
            Console.WriteLine("A {0} nyertek:", NumberOfEvils > NumberOfGoodGuys? "rosszak": "jók");
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.Name);
            }
        }
    }
}
