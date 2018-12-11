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

            while(game.OnGoing)
            {
                game.RandomAttack();
            }
            game.WhoWon();
            Console.ReadKey();
        }
    }
}
