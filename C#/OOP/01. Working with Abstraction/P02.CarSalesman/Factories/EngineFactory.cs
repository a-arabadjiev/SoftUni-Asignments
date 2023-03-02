namespace P02.CarSalesman.Factories
{
    using P02.CarSalesman.Models;

    public static class EngineFactory
    {
        public static Engine Create(string[] engineParams)
        {
            string model = engineParams[0];
            double power = double.Parse(engineParams[1]);

            if (engineParams.Length == 2)
            {
                Engine engine = new Engine(model, power);

                return engine;
            }
            else if (engineParams.Length == 3)
            {
                if (char.IsLetter(engineParams[2][0]))
                {
                    string efficiency = engineParams[2];

                    Engine engine = new Engine(model, power, efficiency);

                    return engine;
                }
                else
                {
                    double displacement = double.Parse(engineParams[2]);

                    Engine engine = new Engine(model, power, displacement);

                    return engine;
                }
            }
            else
            {
                double displacement = double.Parse(engineParams[2]);
                string efficiency = engineParams[3];

                Engine engine = new Engine(model, power, displacement, efficiency);

                return engine;
            }
        }
    }
}
