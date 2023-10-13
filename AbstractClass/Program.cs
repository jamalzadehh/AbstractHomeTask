namespace AbstractClass
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle[] vehicles = new Vehicle[4];

            vehicles[0] = new Car { FactoryName = "Mercedes", Model = "CLS 63 AMG", Color = "Black", DriveTime = 2, DrivePath = 245, DoorCount = 4, IsElectricCar = false };
            vehicles[1] = new Car { FactoryName = "Tesla", Model = "Model X", Color = "White", DriveTime = 3, DrivePath = 180, DoorCount = 4, IsElectricCar = false };
            vehicles[2] = new Bicycle { FactoryName = "Trek", Model = "FX", Color = "Blue", DriveTime = 1.5, DrivePath = 30, Type =  "Mountain" };
            vehicles[3] = new Bicycle { FactoryName = "Giant", Model = "Defy", Color = "Red", DriveTime = 2, DrivePath = 40, Type = "Road" };

            foreach (var vehicle in vehicles)
            {
                vehicle.GetInfo();
                Console.WriteLine($"AverageSpeed: {vehicle.AverageSpeed()}");
                Console.WriteLine($"NatureHarmness: {vehicle.DefineNatureHarmness()}");
                Console.WriteLine();
            }
        }
    }
    abstract class Vehicle
    {
        public string FactoryName { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double DriveTime { get; set; }
        public double DrivePath { get; set; }
        public readonly DateTime ProductionDate;

        public Vehicle()
        {
            ProductionDate = DateTime.Now;
        }

        public double AverageSpeed()
        {
            return DrivePath / DriveTime;
        }

        public virtual void GetInfo()
        {
            Console.WriteLine($"FactoryName: {FactoryName}");
            Console.WriteLine($"Model: {Model}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"DriveTime: {DriveTime}");
            Console.WriteLine($"DrivePath: {DrivePath}");
            Console.WriteLine($"ProductionDate: {ProductionDate}");
        }

        public override string ToString()
        {
            return $"{FactoryName} {Model}";
        }

        public abstract string DefineNatureHarmness();
    }

    class Car : Vehicle
    {
        public int DoorCount { get; set; }
        public bool IsElectricCar { get; set; }

        public override string DefineNatureHarmness()
        {
            return IsElectricCar ? "Low" : "High";
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"DoorCount: {DoorCount}");
            Console.WriteLine($"IsElectricCar: {IsElectricCar}");
        }
    }

    class Bicycle : Vehicle
    {
        public string Type { get; set; }

        public override string DefineNatureHarmness()
        {
            return " ";
        }

        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"Type: {Type}");
        }
    }
}