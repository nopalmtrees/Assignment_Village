using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_VillageOfTesting
{
    public class Building
    {
        public string name;
        public int WoodCost;
        public int MetalCost;
        public int DaysWorkedOn;
        public int DaysToComlete;
        public bool Complete;

        public Building(string Name, int WoodCost, int MetalCost, int DaysWorkedOn, int DaysToComplete, bool Complete)
        {
            this.name = Name;
            this.WoodCost = WoodCost;
            this.MetalCost = MetalCost;
            this.DaysWorkedOn = 0;
            DaysToComlete = DaysToComplete;
            this.Complete = false;
        }

        public Building(string Name, int WoodCost, int MetalCost, int DaysToComplete)
        {
            this.name=Name;
            this.WoodCost = WoodCost;
            this.MetalCost =MetalCost;
            this.DaysWorkedOn = DaysToComplete;
        }


 
    }

    

}
