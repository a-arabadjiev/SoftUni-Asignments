namespace P02.CarSalesman.Repositories
{
    using P02.CarSalesman.Models;

    using System;

    public class CarRepository
    {
        private List<Car> cars;

        public CarRepository()
        {
            this.cars = new List<Car>();
        }

        public void Add(Car car)
        {
            this.cars.Add(car);
        }

        public void PrintAllCars()
        {
            foreach (var car in this.cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
