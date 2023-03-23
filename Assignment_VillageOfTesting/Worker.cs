using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_VillageOfTesting
{
    public class Worker
    {
        public delegate void WorkerDelegate();
        public WorkerDelegate workerDelegate;

        public string name = "";
        public string occupation = "";
        public int daysHungry;

        public bool hungry;
        public bool alive;


        public Worker(string name, string occupation, WorkerDelegate workerDelegate)
        {
            this.name = name;
            this.occupation = occupation;
            this.workerDelegate = workerDelegate;
            daysHungry = 0;
            this.hungry = false;
            alive = true;
        }

    

        public void DoWork()
        {
            
            workerDelegate.Invoke();
        }
        public void FeedWorkers()
        {
            hungry = false;
            daysHungry = 0;
        }

        public void WorkerDead()
        {
            alive = false;
            daysHungry = 0;
        }

        public void AddHungryDay()
        {
            daysHungry++;
            hungry = true;
            if (daysHungry >= 40)
            {
                alive = false;
            }
        }

        public bool IsHungry()
        { return hungry; }

        public void SetHungry(bool hungry)
        { this.hungry = hungry; }

        public string GetOccuptaion()
        {
            return occupation;
        }
        public bool Alive()
        { return alive; }

        public void SetAlive(bool alive)
        { this.alive = alive; }





    }
}
