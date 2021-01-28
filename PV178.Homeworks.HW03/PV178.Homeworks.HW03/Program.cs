using System;

namespace PV178.Homeworks.HW03
{
    class Program
    {
        static void Main()
        {
	        IGame game = new Game();
	        game.Run();
	        Console.ReadKey();
        }
    }
}
