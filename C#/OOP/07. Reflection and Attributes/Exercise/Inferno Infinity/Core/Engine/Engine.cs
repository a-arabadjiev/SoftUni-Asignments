namespace P07.InfernoInfinity.Core.Engine
{
    using P07.InfernoInfinity.Core.CommandInterpreter;
    using P07.InfernoInfinity.Core.Engine.Contracts;

    using P07.InfernoInfinity.Repositories;

    using System.Reflection;
    using System;

    public class Engine : IEngine
    {
        public void Run()
        {
            var weapons = new WeaponRepository();

            string input = Console.ReadLine();

            while (input != "END")
            {
                List<string> inputSplit = input.Split(";").ToList();

                string command = inputSplit[0];
                inputSplit.RemoveAt(0);

                Type commandInterpreterType = typeof(CommandInterpreter);
                MethodInfo method = commandInterpreterType.GetMethod($"{command}");

                method.Invoke(null, new object[] { inputSplit.ToArray(), weapons });

                input = Console.ReadLine();
            }
        }
    }
}
