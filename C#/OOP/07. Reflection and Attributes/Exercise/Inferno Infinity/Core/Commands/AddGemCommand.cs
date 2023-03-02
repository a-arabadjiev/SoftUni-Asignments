namespace P07.InfernoInfinity.Core.Commands
{
    using P07.InfernoInfinity.Core.Commands.Contracts;
    using P07.InfernoInfinity.Core.Factories;

    using P07.InfernoInfinity.Models.Gems.Base;
    using P07.InfernoInfinity.Models.Weapons.Base;
    
    using P07.InfernoInfinity.Repositories;

    public class AddGemCommand : ICommand
    {
        public void Execute(string[] paramaters, WeaponRepository weaponRepository)
        {
            string weaponName = paramaters[0];
            int socketIndex = int.Parse(paramaters[1]);

            string[] gemParams = paramaters[2].Split().ToArray();
            GemFactory factory = new GemFactory();
            Gem gem = factory.Create(gemParams);

            Weapon weaponToAddGemTo = weaponRepository.ReturnFirstOrDefault(weaponName);

            weaponToAddGemTo.AddGem(gem, socketIndex);
        }
    }
}
