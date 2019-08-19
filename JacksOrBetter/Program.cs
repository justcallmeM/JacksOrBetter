using Autofac;
using System;

namespace JacksOrBetter
{
    class Program
    {
        //The game should deal five cards and the player has the opportunity to discard one or more cards.
        //Discarded cards are replaced with the new ones. After the draw evaluate the current combination.
        //Different combinations should pay out a different prize.
        //Hand - Prize
        //Roayl flush - 800
        //Straight flush - 50
        //Four of a kind - 25
        //Full house - 9
        //Flush - 6
        //Straight - 4
        //Three of a kind - 3
        //Two pair - 2
        //Jacks or better - 1
        //All other - 0

        static void Main()
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IApplication>();

                app.Run();
            }

            Console.ReadKey(true);
        }
    }
}
