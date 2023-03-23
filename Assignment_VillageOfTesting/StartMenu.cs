using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_VillageOfTesting
{
    public class StartMenu
    {
        Village village = new Village();
        public void Run()
        {
            
            bool running = true;
            
            Console.WriteLine("Let´s build a village");
            Console.WriteLine("Have fun and take care of the workers");
            Console.WriteLine("");

            while (running)
            {
                Console.WriteLine("What do you want to do:");
                Console.WriteLine("1. Add Worker:");
                Console.WriteLine("2. Add Project:");
                Console.WriteLine("3. Bury Dead Workers:");
                Console.WriteLine("4. A days work! Starts the next day and everybody´s doing their jobs");
                Console.WriteLine("5: Check resources");
                Console.WriteLine("6: Who is working?");
                

                
                int userChoice = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                if (userChoice == 1)
                {
                    Console.WriteLine("Give the worker a name:");
                    string nameInput = Console.ReadLine();

                    if (!string.IsNullOrEmpty(nameInput))
                    {
                        Console.WriteLine($"Choose an occupation for {nameInput}");

                        Console.WriteLine(" Farmer | Lumberjack | Miner | Builder ");

                        string occupationInput = Console.ReadLine();

                        Console.Clear();

                        if (occupationInput.Equals("Farmer") |
                            occupationInput.Equals("miner") |
                            occupationInput.Equals("farmer") |
                            occupationInput.Equals("builder")) ;
                        {
                            village.AddWorker(nameInput, occupationInput);
                        }

                    
                    }                  

                }
                else if (userChoice == 2)
                {
                    Console.Clear();

                    Console.WriteLine("What projekt would like to start?");

                    Console.WriteLine("House");
                    Console.WriteLine("Woodmill");
                    Console.WriteLine("Quarry");
                    Console.WriteLine("Farm");
                    Console.WriteLine("Castle");

                    string projectInput = Console.ReadLine();

                    if (projectInput.Equals("House") |
                        projectInput.Equals("Woodmill") |
                        projectInput.Equals("Quarry") |
                        projectInput.Equals("Farm") |
                        projectInput.Equals("Castle"))
                    {
                        village.AddProject(projectInput);
                    }

                }
                else if (userChoice == 3)
                {
                    village.BuryDead();
                }
                else if (userChoice == 4)
                {
                    village.Day();
                }
                else if (userChoice == 5)
                {
                    village.CheckResources();
                }
                else if (userChoice == 6)
                {
                    village.PrintWorkers();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Press key to return");
                    Console.ReadKey();  
                }


            }
        }
          
    }
}
