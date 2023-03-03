using System.Collections.Generic;
using System.Text;

namespace P03.Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string FirstName
        {
            get 
            { 
                return this.firstName;
            }
            set 
            {
                this.ValidateName(value, "firstName", 4);

                this.firstName = value; 
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.ValidateName(value, "lastName", 3);

                this.lastName = value;
            }
        }

        private void ValidateName(string name, string nameType, int symbolsCount)
        {
            if (char.IsLower(name[0]))
            {
                throw new ArgumentException($"Expected upper case letter! Argument: {nameType}");
            }
            if (name.Length < symbolsCount)
            {
                throw new ArgumentException($"Expected length at least {symbolsCount} symbols! Argument: {nameType}");
            }
        }

        public override string ToString()
        {
            var humanInfo = new StringBuilder();

            humanInfo.AppendLine($"First Name: {this.FirstName}");
            humanInfo.AppendLine($"Last Name: {this.LastName}");

            return humanInfo.ToString();
        }
    }
}
