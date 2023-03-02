namespace P07.InfernoInfinity.Core.CommandInterpreter
{
    using P07.InfernoInfinity.Core.Commands;
    using P07.InfernoInfinity.Core.Commands.Contracts;

    using P07.InfernoInfinity.Repositories;

    public static class CommandInterpreter
    {
        public static void Create(string[] paramaters, WeaponRepository weaponRepository)
        {
            ICommand command = new CreateWeaponCommand();

            command.Execute(paramaters, weaponRepository);
        }

        public static void Add(string[] paramaters, WeaponRepository weaponRepository)
        {
            ICommand command = new AddGemCommand();

            command.Execute(paramaters, weaponRepository);
        }

        public static void Remove(string[] paramaters, WeaponRepository weaponRepository)
        {
            ICommand command = new RemoveGemCommand();

            command.Execute(paramaters, weaponRepository);
        }

        public static void Print(string[] paramaters, WeaponRepository weaponRepository)
        {
            ICommand command = new PrintWeaponCommand();

            command.Execute(paramaters, weaponRepository);
        }
    }
}
