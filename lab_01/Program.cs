using System.Text;
using lab_1.Entities;
using lab_1.Entities.Animal;
using lab_1.Enums;
using lab_1.Services.Inventory;

Console.OutputEncoding = Encoding.UTF8;
var inventory = new InventoryService();
var reportGenerator = new InventoryReportGenerator(inventory);

var lionEnclosure = new Enclosure("Lion Enclosure", 200, EnclosureType.OpenAir, 5);
var birdAviary = new Enclosure("Bird Aviary", 150, EnclosureType.OpenAir, 20);
var terrarium = new Enclosure("Reptile Terrarium", 50, EnclosureType.Terrarium, 10);
var aquarium = new Enclosure("Aquarium", 100, EnclosureType.Aquarium, 1);

var lion = new Mammal("Simba", "Lion", FoodType.Meat, lionEnclosure, true);
var eagle = new Bird("TopGun", "Eagle", FoodType.Meat, birdAviary, true);
var python = new Reptile("Kaa", "Python", FoodType.Meat, terrarium, false);
var dolphin = new Mammal("Vasya", "Dolphin", FoodType.Fish, aquarium, false);
var cobra = new Reptile("Super Cobra", "Cobra", FoodType.Meat, terrarium, true);

var keeper = new Employee("John Doe", EmployeePosition.AnimalKeeper, new DateTime(2020, 5, 15), 3500, Department.Maintenance);
var veterinarian = new Employee("Jane Doe", EmployeePosition.Veterinarian, new DateTime(2019, 3, 10), 5000, Department.Veterinary);
var guard = new Employee("Joe Biden", EmployeePosition.Security, new DateTime(2021, 7, 1), 2800, Department.Security);

var meat = new Food("Meat", FoodType.Meat, 100, DateTime.Now.AddDays(5));
var vegetables = new Food("Vegetables", FoodType.Vegetables, 80, DateTime.Now.AddDays(7));
var fruits = new Food("Fruits", FoodType.Fruits, 60, DateTime.Now.AddDays(4));
var fish = new Food("Fish", FoodType.Fish, 120, DateTime.Now.AddDays(3));

lionEnclosure.AddAnimal(lion);
birdAviary.AddAnimal(eagle);
terrarium.AddAnimal(python);
aquarium.AddAnimal(dolphin);
terrarium.AddAnimal(cobra);

inventory.AddItem(lion);
inventory.AddItem(eagle);
inventory.AddItem(python);
inventory.AddItem(dolphin);
inventory.AddItem(cobra);
inventory.AddItem(lionEnclosure);
inventory.AddItem(birdAviary);
inventory.AddItem(terrarium);
inventory.AddItem(aquarium);
inventory.AddItem(keeper);
inventory.AddItem(veterinarian);
inventory.AddItem(guard);
inventory.AddItem(meat);
inventory.AddItem(vegetables);
inventory.AddItem(fruits);
inventory.AddItem(fish);

lion.Feed(meat);
eagle.Feed(meat);
python.Feed(meat);
dolphin.Feed(fish);
cobra.Feed(meat);
lion.PerformHealthCheck();
eagle.PerformHealthCheck();
python.PerformHealthCheck();
dolphin.PerformHealthCheck();
cobra.PerformHealthCheck();

lionEnclosure.Maintain();
birdAviary.Maintain();
terrarium.Maintain();
aquarium.Maintain();

meat.Consume(15);
fish.Consume(1);

Console.WriteLine("\n---> Initial Inventory <---");
Console.WriteLine(reportGenerator.GenerateInventoryReport());

guard.GiveRaise(99.49);
meat.Consume(12);
inventory.RemoveItem(cobra);
terrarium.RemoveAnimal(python);

Console.WriteLine("\n---> Updated Inventory <---");
Console.WriteLine(reportGenerator.GenerateInventoryReport());