using Assignment_VillageOfTesting;
using Xunit.Sdk;
using static Assignment_VillageOfTesting.Worker;

namespace Assignment_VillageOfTesting_Test;

public class VillageTest
{

    [Fact]
    public void AddOneWorker_ShouldHaveOneWorker()
    { //Given
        Village village = new Village();
        int expectedWorkers = 1;

        //When
        village.AddWorker("Bob", "Miner");
        int workerCount = village.workers.Count;

        Assert.Equal(expectedWorkers, workerCount);

    }

    [Fact]
    public void Add2Worker_ShouldHave2Worker()
    { //Given
        Village village = new Village();
        int expectedWorkers = 2;

        //When
        village.AddWorker("Bob", "Miner");
        village.AddWorker("Rob", "Farmer");
        int workerCount = village.workers.Count;

        Assert.Equal(expectedWorkers, workerCount);

    }
    [Fact]
    public void Add3Worker_ShouldHave3Worker()
    { //Given
        Village village = new Village();
        int expectedWorkers = 3;

        //When
        village.AddWorker("Bob", "Miner");
        village.AddWorker("Tob", "Builder");
        village.AddWorker("Rob", "Farmer");
        int workerCount = village.workers.Count;

        Assert.Equal(expectedWorkers, workerCount);

    }


    [Fact]
    public void AddingWorkersWhenNoSpace_NoWorkersShouldBeAdded()
    {
        //given
        Village village = new Village();
        village.buildings.Clear();
        int expectedWorkers = 0;

        //when
        village.AddWorker("Worker1", "Miner");
        village.AddWorker("Worker2", "Lumberjack");
        village.AddWorker("Worker3", "Builder");
        village.AddWorker("Worker4", "Farmer");
        int workerCount = village.workers.Count();

        //then
        Assert.Equal(expectedWorkers, workerCount);
    }

    [Fact]
    public void AddWorkerAndTestFunctionCallDay()
    {
        //Given
        Village village = new Village();
        village.AddWorker("Ali", "Lumberjack");
        int expectedWorkers = 1;
        int expectedactfood = 9;
        

        //When
        village.Day();
        int workerCount = village.workers.Count();
        int actfood = village.GetFood();

        //Then

        Assert.Equal(expectedWorkers, workerCount);
        Assert.Equal(expectedactfood, actfood);

    }
    [Fact]
    public void NoWorker_TryDayFunction()
    {
        // Given
        Village village = new Village();

        // When
        village.Day();
        int actual = village.GetFood();
        var workerList = village.GetWorkers();

        // Then
        Assert.Equal(10, actual);
        Assert.Empty(workerList);
    }
    [Fact]
    public void AddWorkerAndTestIfTheFoodIsEnough()
    {
        //Given
        Village village = new Village();
        village.AddWorker("Ali", "Lumberjack");
        village.AddWorker("Bob", "Lumberjack");
        village.AddWorker("Eva", "Lumberjack");
        village.AddWorker("Rob", "Lumberjack");

        int expectedWorkers = 3;
        int expectedactfood = 7;
        int expectedWood = 3;


        //When
        village.Day();
        int workerCount = village.workers.Count();
        int actfood = village.GetFood();
        int actWood = village.GetWood();

        //Then

        Assert.Equal(expectedWorkers, workerCount);
        Assert.Equal(expectedactfood, actfood);
        Assert.Equal(expectedWood, actWood);

    }
    [Fact]
    public void RunDayWithoutEnoughFood_ShouldNotCollectWood()
    {
        //Given
        Village village = new Village();
        village.AddWorker("Rob", "Lumberjack");
        village.food = 0;
        int expectedWood = 0;

        //When
        village.Day();
        int actWood = village.GetWood();

        //Then

        Assert.Equal(expectedWood, actWood);
    }
    [Fact]
    public void AddBuildingWithEnoughResources()
    {
        //Given
        Village village = new Village();
        village.SetWood(3);
        village.SetMetal(5);
        int expmetal = 5;
        int expWood = 0;
        int expBuilding = 1;

        //when
        var quarry = new Building("Quarry", 3, 5, 7);
        village.AddProject("Quarry");
        int woodAmount = village.GetWood();
        int metalAmount = village.GetMetal();
        int actBuilding = 1;

        //Then
        
        Assert.Equal(expmetal, metalAmount);
        Assert.Equal(expWood, woodAmount);
        Assert.Equal(expBuilding, actBuilding);
        
    }

    [Fact]
    public void AddBiuldingWithNoResources_ShouldNotWork()
    {
        //Given
        Village village = new Village();
        List<Building> projects = new List<Building>();
        village.SetWood(0);
        village.SetMetal(0);
        int expProject = 0;

        //When
        village.AddProject("Quarry");

        //Then

        Assert.Equal(expProject, projects.Count());
    }
    [Fact]
    public void WoodBeforeWoodmillAnd_OneDayAfter()
    {
        //given
        Village village = new Village();
        village.SetFood(100);
        village.SetMetal(100);
        village.SetWood(100);
        village.AddWorker("Bob", "Lumberjack");
        village.AddWorker("Rob", "Builder");
        int expWoodBeforeWoodmill = 1;
        int expWoodAfterWoodmill = 3;

        //When
        village.Day();
        int actWoodDayBeforeWoodmill =village.woodPerDay;
        Building DemoBuilding = new Building("Woodmill",1,1,1);
        village.buildings.Add(DemoBuilding);
        village.Day();
        int actWoodDayAfterWoodmill = village.woodPerDay;

        //Then
        Assert.Equal(expWoodBeforeWoodmill, actWoodDayBeforeWoodmill);
        Assert.Equal(expWoodAfterWoodmill, actWoodDayAfterWoodmill);
       
    }
    [Fact]
    public void FoodBeforeFarmAnd_OneDayAfter()
    {
        //given
        Village village = new Village();
        village.SetFood(100);
        village.SetMetal(100);
        village.SetWood(100);
        village.AddWorker("Bob", "Farmer");
        village.AddWorker("Rob", "Builder");
        int expFoodBeforeFarm = 15;
        int expFoodAfterFarm = 5;

        //When
        village.Day();
        int actFoodBeforeFarm = village.foodPerDay;
        Building DemoFarm = new Building("Farm", 1, 1, 1);
        village.buildings.Add(DemoFarm);
        village.Day();
        int actFoodAfterFarm = village.foodPerDay;

        //Then
        Assert.Equal(expFoodBeforeFarm, actFoodAfterFarm);
        Assert.Equal(expFoodAfterFarm, actFoodBeforeFarm);

    }
    [Fact]
    public void MetalBeforQuarryAnd_OneDayAfter()
    {
        //Given
        Village village = new Village();
        village.SetFood(100);
        village.SetMetal(100);
        village.SetWood(100);
        village.AddWorker("Bob", "Miner");
        village.AddWorker("Rob", "Builder");
        int expMetalBeforeQuarry = 3;
        int exMetalAfterQuarry = 1;

        //When
        village.Day();
        int actMetalBeforeQuarry = village.metalPerDay;
        Building DemoQuarry = new Building("Quarry", 1, 1, 1);
        village.buildings.Add(DemoQuarry);
        village.Day();
        int actMetalAfterQuarry = village.metalPerDay;

        //Then
        Assert.Equal(expMetalBeforeQuarry, actMetalAfterQuarry);
        Assert.Equal(exMetalAfterQuarry, actMetalBeforeQuarry);
    
    }
   
    [Fact]
    public void BuildingWithDay()
    {
        Village village = new Village();
        village.AddWorker("ola", "Builder");
        village.AddProject("House");
        village.Day();
        village.AddWorker("ola", "Builder");
        village.Day();

        int expDays = 2;
        int expBuildings = 3;

        Assert.Equal(expBuildings, village.buildings.Count);
        Assert.Equal(expDays, village.daysGone);


    }
    [Fact]
    public void HUngryWorkerWontWork()
    {
        //Given
        
        int expAddedWood = 0;
        Village village = new Village();
        village.AddWorker("Jack", "Lumberjack");
        //When
        village.SetFood(0);
        village.Day();
        int actAddedWood = 0;
        //Then
        Assert.Equal(expAddedWood, actAddedWood);
        
    }
    [Fact]
    public void NoFoodInFortyDays_ShouldNotBeAlive()
    {
        //Given
        Village village = new Village();
        Worker Worker = new Worker("Bob", "Lumberjack", () => village.AddWood());
        village.workers.Add(Worker);
        village.SetFood(0);
        Worker.daysHungry = 40;

        //When
        village.Day();

        //Then
        Assert.False(Worker.alive);
    }
    [Fact]
    public void DeadWorkersShallNotEat_FoodShouldBe10()
    {
        //Given
        Village village = new Village();
        Worker Worker = new Worker("Bob", "Lumberjack", () => village.AddWood());
        village.workers.Add(Worker);
        //village.SetFood(0);
        Worker.daysHungry = 40;
        int foodShouldBe = 10;
        //When
        village.Day();
        int actFood = village.GetFood();

        //Then
        Assert.Equal(actFood, foodShouldBe);
    }
    [Fact]
    public void BuryDeadWorkersAndRemoveFromWorkers()
    {
        Village village = new Village();
        Worker Worker = new Worker("Bob", "Lumberjack", () => village.AddWood());
        village.workers.Add(Worker);
        
        Worker.daysHungry = 40;
        int expLivingWorkers = 0;
        
        //When
        village.Day();
        
        village.BuryDead();
        int actLivingWorkers = village.workers.Count();

        //Then
        Assert.Equal(expLivingWorkers, actLivingWorkers);
        
    }
    
    [Fact]
    public void BuildCastle()
    {
        //Given
        Village village = new Village();
        Building building = new Building("Castle", 50, 50,0, 50, false);
        village.SetFood(100);
        village.SetMetal(100);
        village.SetWood(100);
        
        village.AddProject("Castle");
        
        village.AddWorker("Bob", "Builder");
        village.AddWorker("Rob", "Builder");
        village.AddWorker("Mob", "Builder");
        village.AddWorker("Bob", "Farmer");
        village.AddWorker("Bob", "Miner");
        int expDaysToComlete = 75;

        //When
        for (int i = 0; i < 100; i++)
        {
            village.Day();
        }
        
       
        int actDaysPassed = village.daysGone;
        bool actualStatus = building.Complete;

        Assert.Equal(expDaysToComlete, actDaysPassed);
        Assert.False(actualStatus);
    }
    [Fact]
    public void BuildACastle_ShouldTake50Days()
    {
        //Arrange
        Village village = new Village();
        Building building = new Building("Castle",50,50,0,50, false);
        
        var expectedDays = 50;

        //Act
       
        var actualDays = building.DaysToComlete;

        //Assert
   
        Assert.Equal(expectedDays, actualDays);
    }
    
    



}
