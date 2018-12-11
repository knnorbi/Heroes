using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heroes
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game("Heroes.csv");

            for (int i = 0; i < 10; i++)
            {
                game.RandomAttack();
            }

            Console.ReadKey();
        }
    }
}
