using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes
{
    class Hero
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Strength { get; private set; }
        double Charge { get; set; }
        public bool Evil { get; private set; }

        public bool IsAlive
        {
            get
            {
                return Health > 0;
            }
        }

        public bool Attack(Hero attacker)
        {
            if (this == attacker)
            {
                throw new Exception("Saját magát támadta meg!");
            }
            if (!IsAlive || !attacker.IsAlive) 
            {
                throw new Exception("Valaki már halott."); 
            }
            if (Evil == attacker.Evil) 
            {
                throw new Exception("Ilyet nem szép dolog csinálni!"); 
            }

            Health -= attacker.Strength;
            return !IsAlive;
        }

        public Hero(string name, int health, int strength, double charge, bool evil)
        {
            Name = name;
            Health = health;
            Strength = strength;
            Charge = charge;
            Evil = evil;
        }

        public override string ToString()
        {
            string[] asd = {Name, Health.ToString(), Strength.ToString(), Charge.ToString(), Evil.ToString()};
            return string.Join(" ", asd);

            //return Name + " " + Health + " " + Strength + " " + Charge + " " + Evil;
        }
    }
}
