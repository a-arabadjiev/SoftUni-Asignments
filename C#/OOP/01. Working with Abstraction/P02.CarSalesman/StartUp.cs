namespace P02.CarSalesman
{
    using P02.CarSalesman.Repositories;
    using P02.CarSalesman.Factories;
    using P02.CarSalesman.Models;

    using System;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            EngineRepository engines = new EngineRepository();

            int engineInputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineInputsCount; i++)
            {
                string[] engineInput = Console.ReadLine().Split().ToArray();

                Engine engine = EngineFactory.Create(engineInput);
                engines.Add(engine);
            }

            CarRepository cars = new CarRepository();

            int carInputsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carInputsCount; i++)
            {
                string[] carInput = Console.ReadLine().Split().ToArray();

                Car car = CarFactory.Create(carInput, engines);
                cars.Add(car);
            }

            cars.PrintAllCars();
        }
    }
}