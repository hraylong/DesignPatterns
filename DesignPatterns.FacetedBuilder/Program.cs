using System;

namespace DesignPatterns.FacetedBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
            .Info
              .WithType("BMW")
              .WithColor("Black")
              .WithNumberOfDoors(5)
            .Built
              .InCity("Leipzig ")
              .AtAddress("Some address 254")
            .Build();

            Console.WriteLine(car);

            Console.WriteLine("Press any key to close.");
            Console.ReadLine();
        }
    }

    public class Car
    {
        public string Type { get; set; }
        public string Color { get; set; }
        public int NumberOfDoors { get; set; }

        public string City { get; set; }
        public string Address { get; set; }

        public override string ToString()
        {
            return $"CarType: {Type}, Color: {Color}, Number of doors: {NumberOfDoors}, Manufactured in {City}, at address: {Address}";
        }
    }

    public class CarBuilderFacade
    {
        protected Car Car { get; set; }

        public CarBuilderFacade()
        {
            Car = new Car();
        }

        public Car Build() => Car;
        public CarInfoBuilder Info => new CarInfoBuilder(Car);
        public CarAddressBuilder Built => new CarAddressBuilder(Car);
    }

    public class CarInfoBuilder : CarBuilderFacade
    {
        public CarInfoBuilder(Car car)
        {
            Car = car;
        }

        public CarInfoBuilder WithType(string type)
        {
            Car.Type = type;
            return this;
        }

        public CarInfoBuilder WithColor(string color)
        {
            Car.Color = color;
            return this;
        }

        public CarInfoBuilder WithNumberOfDoors(int number)
        {
            Car.NumberOfDoors = number;
            return this;
        }
    }

    public class CarAddressBuilder : CarBuilderFacade
    {
        public CarAddressBuilder(Car car)
        {
            Car = car;
        }

        public CarAddressBuilder InCity(string city)
        {
            Car.City = city;
            return this;
        }

        public CarAddressBuilder AtAddress(string address)
        {
            Car.Address = address;
            return this;
        }
    }
}
