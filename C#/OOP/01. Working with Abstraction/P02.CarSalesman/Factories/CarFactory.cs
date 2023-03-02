namespace P02.CarSalesman.Factories
{
    using P02.CarSalesman.Repositories;
    using P02.CarSalesman.Models;

    public static class CarFactory
    {
        public static Car Create(string[] carParams, EngineRepository engines)
        {
            string model = carParams[0];

            string engineModel = carParams[1];
            Engine engine = engines.ReturnFirstOrDefault(engineModel);

            if (carParams.Length == 2)
            {
                Car car = new Car(model, engine);

                return car;
            }
            // Second check is due to Judge system adding whitespace paramater as 4th element
            else if (carParams.Length == 3 || carParams.Length == 4 && string.IsNullOrWhiteSpace(carParams[3]))
            {
                if (char.IsLetter(carParams[2][0]))
                {
                    string color = carParams[2];

                    Car car = new Car(model, engine, color);

                    return car;
                }
                else
                {
                    double weight = double.Parse(carParams[2]);

                    Car car = new Car(model, engine, weight);

                    return car;
                }
            }
            else
            {
                double weight = double.Parse(carParams[2]);
                string color = carParams[3];

                Car car = new Car(model, engine, weight, color);

                return car;
            }
        }
    }
}
