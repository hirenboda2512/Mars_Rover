using MarsConsole.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MarsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Grid Max X and Max Y Coordinate With space Ex(5 5):");
            string gridXY = Console.ReadLine();
            var gridPoint = gridXY.Split(' ');
            int maxX = Convert.ToInt32(gridPoint[0]);
            int maxY = Convert.ToInt32(gridPoint[1]);
            Console.WriteLine("Enter Number of Rover:");
            int numRover = Convert.ToInt32(Console.ReadLine());
            var rovers = new List<Rover>();
            for (int i = 0; i < numRover; i++)
            {
                Console.WriteLine("Enter Rover Postion:");
                string rvrPostionArg = Console.ReadLine().ToUpper();
                Console.WriteLine("Enter Rover Movement:");
                string rvrMovementArg = Console.ReadLine().ToUpper();
                string pattern = @"^[0-9]+ [0-9]+ [NSWE]$";
                Regex rg = new Regex(pattern);
                if (!rg.IsMatch(rvrPostionArg))
                {
                    Console.WriteLine("Rover Postion is wrong");
                    continue;
                }
                string movementPattern = @"^[LRM]+$";
                Regex mrg = new Regex(movementPattern);
                if (!mrg.IsMatch(rvrMovementArg))
                {
                    Console.WriteLine("Rover Movement is wrong");
                    continue;
                }
                //Another approch
                //var objRover = new Rover() { currentPos = rvrPostionArg, movement = rvrMovementArg };
                //objRover.ProcessInPutData(maxX, maxY);

                var objRover = new Rover(rvrPostionArg, rvrMovementArg, maxX, maxY);
                rovers.Add(objRover);
            }
            if (rovers.Count > 0)
            {
                foreach (var objRov in rovers)
                {
                    try
                    {
                        var outPut = objRov.Process();

                        //Another approch
                        // var outPut = objRov.Process(objRov.movement);
                        Console.WriteLine(outPut);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }

                }

            }

            Console.Read();
        }
    }
}
