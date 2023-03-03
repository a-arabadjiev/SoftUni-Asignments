namespace P03.ShoppingSpree.Factories
{
    using P03.ShoppingSpree.Models;

    public static class PersonFactory
    {
        public static List<Person> CreatePersons(string[] personsInput)
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < personsInput.Length; i++)
            {
                string[] inputSplit = personsInput[i].Split("=", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = inputSplit[0];
                double money = double.Parse(inputSplit[1]);

                Person person = new Person(name, money);
                persons.Add(person);
            }

            return persons;
        }
    }
}
