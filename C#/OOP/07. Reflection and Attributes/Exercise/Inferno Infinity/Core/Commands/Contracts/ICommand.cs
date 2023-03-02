using P07.InfernoInfinity.Repositories;

namespace P07.InfernoInfinity.Core.Commands.Contracts
{
    public interface ICommand
    {
        void Execute(string[] paramaters, WeaponRepository weaponRepository);
    }
}
