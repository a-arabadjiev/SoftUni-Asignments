namespace P07.InfernoInfinity.Core.Factories
{
    using P07.InfernoInfinity.Models.Gems.Base;

    using System.Reflection;

    public class GemFactory
    {
        public Gem Create(string[] paramaters)
        {
            GemClarity gemClarity = (GemClarity)Enum.Parse(typeof(GemClarity), paramaters[0]);
            string gemName = paramaters[1];

            Type type = Type.GetType($"P07.InfernoInfinity.Models.Gems.{gemName}");
            ConstructorInfo constructor = type.GetConstructor(new[] { typeof(GemClarity) });

            Gem gem = (Gem)constructor.Invoke(new object[] { gemClarity });

            return gem;
        }
    }
}
