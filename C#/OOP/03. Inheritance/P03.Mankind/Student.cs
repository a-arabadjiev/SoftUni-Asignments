namespace P03.Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber)
            :base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }

        public string FacultyNumber
        {
            get 
            { 
                return this.facultyNumber; 
            }
            set 
            {
                this.ValidateFacultyNumber(value);

                this.facultyNumber = value;
            }
        }

        private void ValidateFacultyNumber(string facultyNumber)
        {
            bool isBetweenFiveAndTenSymbols = facultyNumber.Length >= 5 && facultyNumber.Length <= 10;
            
            if (isBetweenFiveAndTenSymbols)
            {
                bool containsOnlyDigitsAndLetters = true;

                for (int i = 0; i < facultyNumber.Length; i++)
                {
                    if (!char.IsLetter(facultyNumber[i]) && !char.IsDigit(facultyNumber[i]))
                    {
                        containsOnlyDigitsAndLetters = false;
                        break;
                    }
                }

                if (!containsOnlyDigitsAndLetters)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }
            }
            else
            {
                throw new ArgumentException("Invalid faculty number!");
            }
        }

        public override string ToString()
        {
            string studentInfo = $"Faculty number: {this.FacultyNumber}";

            return base.ToString() + studentInfo;
        }
    }
}
