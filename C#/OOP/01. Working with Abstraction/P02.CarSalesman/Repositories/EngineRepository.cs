namespace P02.CarSalesman.Repositories
{
    using P02.CarSalesman.Models;

    public class EngineRepository
    {
        private List<Engine> engines;

        public EngineRepository()
        {
            this.engines = new List<Engine>();
        }

        public void Add(Engine engine)
        {
            this.engines.Add(engine);
        }

        public Engine ReturnFirstOrDefault(string model)
        {
            Engine engine = this.engines.FirstOrDefault(e => e.Model == model);

            return engine;
        }
    }
}
