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

            }
        }

        public int NumberOfEvils { get { } }

        public int NumberOfGoodGuys { get {  } }

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

        public void AddHero(Hero hero)
        {
            heroes.Add(hero);

            //int elemek = heroes.Count;
            //Hero elso = heroes[0];
        }
    }
}
