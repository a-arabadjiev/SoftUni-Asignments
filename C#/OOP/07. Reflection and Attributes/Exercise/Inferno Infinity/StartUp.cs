namespace P07.InfernoInfinity
{
    using P07.InfernoInfinity.Core.Engine.Contracts;
    using P07.InfernoInfinity.Core.Engine;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();

            engine.Run();
        }
    }
}