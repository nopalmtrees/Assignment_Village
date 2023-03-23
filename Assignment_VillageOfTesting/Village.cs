using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Assignment_VillageOfTesting.Worker;

namespace Assignment_VillageOfTesting
{
    public class Village
    {
        public int food;
        private int wood;
        private int metal;
        public List<Worker> workers = new();
        public List<Building> buildings = new();
        public List<Building> projects = new();
        public int foodPerDay = 5;
        public int woodPerDay = 1;
        public int metalPerDay = 1;
        public int daysGone;
        Building house = new("House", 5, 0, 0, 3, false);
        Building woodmill = new("Woodmill", 5, 1, 0, 5, false);
        Building quarry = new("Qarry", 3, 5, 0, 7, false);
        Building farm = new("Farm", 5, 2, 0, 5, false);
        Building castle = new("Castle", 50, 50, 0, 50, false);

        //Constructor
        public Village()
        {
            food = 10;
            for (int i = 0; i < 3; i++)
            {
                buildings.Add(house);
                
            }
            foreach (Building house in buildings)
            {
                house.Complete = true;
            }
        }

        public void AddWorker(string name, string occupation)
        {
            int house = 0;

            foreach (Building building in buildings)
            {
                if (building.name == "House")
                {
                    house++;
                }

            }
            if (workers.Count < house)
            {
                if (occupation.Equals("Farmer"))
                {
                    Worker worker = new Worker(name, "Farmer", () => AddFood());
                    workers.Add(worker);
                }
                 else if (occupation.Equals("Lumberjack"))
                {
                    Worker worker = new Worker(name, "Lumberjack", () => AddWood());
                    workers.Add(worker);
                }
                else if (occupation.Equals("Miner"))
                {
                    Worker Worker = new Worker(name, "Miner", () => AddMetal());
                    workers.Add(Worker);
                }
                else if (occupation.Equals("Builder"))
                {
                    Worker Worker = new Worker(name, "Builder", () => Build());
                    workers.Add(Worker);
                }
            }
        }
       
        public void FeedWorkers(Worker worker)
        {
            if (food > 0)
            {
                worker.FeedWorkers();
                food--;
            }
            else
            {
                worker.AddHungryDay();
            }


        }
       
        public void BuryDead()
        {
            for (int i = 0; i < workers.Count(); i++)
            {
                if (!workers[i].Alive())
                {
                    workers.RemoveAt(i);
                    i--;
                }
            }
            if (workers.Count == 0)
            {
                Console.WriteLine("Everybody is dead - GAME OVER");
            }
        }
        public void AddProject(string name)
        {
            if (name.Equals("House"))
            {
                if (wood >= house.WoodCost && metal >= house.MetalCost)
                {
                    projects.Add(house);

                    wood -= house.WoodCost;
                    metal -= house.MetalCost;
                }
            }
            else if (name.Equals("Woodmill"))
            {
                if (wood >= woodmill.WoodCost && metal >= woodmill.MetalCost)
                {
                    projects.Add(woodmill);

                    wood -= woodmill.WoodCost;
                    metal -= woodmill.MetalCost;
                }
            }
            else if (name.Equals("Quarry"))
            {
                if (wood >= quarry.WoodCost && metal >= quarry.MetalCost)
                {
                    projects.Add(quarry);

                    wood -= quarry.WoodCost;
                    metal -= quarry.MetalCost;
                }
            }
            else if (name.Equals("Farm"))
            {
                if (wood >= farm.WoodCost && metal >= farm.MetalCost)
                {
                    projects.Add(farm);

                    wood -= farm.WoodCost;
                    metal -= farm.MetalCost;
                }
            }
            else if (name.Equals("Castle"))
            {
                if (wood >= castle.WoodCost && metal >= castle.MetalCost)
                {
                    projects.Add(castle);

                    wood -= castle.WoodCost;
                    metal -= castle.MetalCost;
                }
            }
        }
        public void CheckResources()
        {
            int food = GetFood();
            int wood = GetWood();
            int metal = GetMetal();
            Console.WriteLine($"You have {food} food, {wood} wood and {metal} metal.");
            Console.WriteLine("");
        }

        public void Day()
        {
            if (workers.Count != 0)
            {
                FeedWorkers();
                foreach (Worker workers in workers)
                {
                    if (workers.hungry == false)
                    {
                        workers.DoWork();
                    }
                }
                BuryDead(); 
                daysGone++;
            }
            else
            {
                Console.WriteLine("You don't have any workers to do any work\nPlease add some workers:");
            }
        }
        public void PrintWorkers()
        {
            var workerList = GetWorkers();
            if (workerList.Count == 0)
            {
                Console.WriteLine("There is no available worker.");
            }
            else
            {
                foreach (var worker in workerList)
                {
                    Console.WriteLine($"Name: {worker.name}, Occupation: {worker.occupation}");
                    Console.WriteLine("");
                }
            }
        }
        public void FeedWorkers()
        {
            foreach (var worker in workers)
            {
                if (worker.daysHungry >= 40)
                {
                    worker.alive = false;
                    Console.WriteLine($"{worker.name} is not alive. It's not available to feed.");
                }
                else if (food <= 0)
                {
                    worker.hungry = true;
                    worker.daysHungry++;
                }
                else
                {
                    food--;
                    worker.hungry = false;
                    worker.daysHungry = 0;
                }
            }
        }
        public void Build()
        {
            if (projects.Count > 0)
            {
                projects[0].DaysWorkedOn++;

                foreach (Building building in projects.ToList())
                {
                    if (building.DaysWorkedOn == building.DaysToComlete)
                    {
                        building.Complete = true;
                        buildings.Add(building);
                        projects.Remove(building);
                        Console.WriteLine("Building complete!");
                    }
                }
            }
        }
        public void AddFood()
        {
            foodPerDay = 0;
            int farms = 0;
            foreach (Building building in buildings)
            {
                if (building.name == "Farm")
                {
                    farms += 10;
                }
            }
            foodPerDay += 5 + farms;
            food += foodPerDay;
        }
        public void AddMetal()
        {
            metalPerDay = 0;
            int quarrys = 0;
            foreach (Building building in buildings)
            {
                if (building.name == "Quarry")
                {
                    // 2 xtra
                    quarrys += 2;
                }
            }
            metalPerDay += 1 + quarrys;
            metal += metalPerDay;
        }

        public void AddWood()
        {
            woodPerDay = 0;
            int woodmill = 0;
            foreach (Building building in buildings)
            {

                if (building.name == "Woodmill")
                {
                    woodmill += 2;
                }
            }
            woodPerDay += 1 + woodmill;

            wood += woodPerDay;
        }
       

        public int GetFood()
            { return food; }

        public void SetFood(int food)
            { this.food = food; }   

        public int GetWood() 
        { return wood; }

        public void SetWood(int wood) 
        { this.food = wood; }

        public int GetMetal() 
        { return metal; }

        public void SetMetal(int metal) 
        { this.metal = metal; }

        public List<Worker> GetWorkers() 
        { return workers; }

        public void SetWorkers(List<Worker> workers) 
        { this.workers = workers; }

        public void SetWorkers(Worker worker) 
        { workers.Add(worker); }

        public List<Building> GetBuildings() 
        { return buildings; }

        public void SetBuildings(List<Building> buildings) 
        { this.buildings = buildings; }

        public List<Building> GetProjects() 
        { return projects; }

        public void SetProjects(List<Building> projects) 
        { this.projects = projects; }
        
      
        
        public int DaysGone() 
        { return daysGone; }

        public void SetDaysGone(int daysGone) 
        { this.daysGone = daysGone; }
        






    }

    
}
