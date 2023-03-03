namespace P03.Mankind
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var studentInfo = Console.ReadLine().Split().ToArray();

                string studentFirstName = studentInfo[0];
                string studentLastName = studentInfo[1];
                string studentFacultyNumber = studentInfo[2];

                var student = new Student(studentFirstName, studentLastName, studentFacultyNumber);

                var workerInfo = Console.ReadLine().Split().ToArray();

                string workerFirstName = workerInfo[0];
                string workerLastName = workerInfo[1];
                decimal workerWeekSalary = decimal.Parse(workerInfo[2]);
                decimal workerHoursPerDay = decimal.Parse(workerInfo[3]);

                var worker = new Worker(workerFirstName, workerLastName, workerWeekSalary, workerHoursPerDay);

                Console.WriteLine();
                Console.WriteLine(student + Environment.NewLine);
                Console.WriteLine(worker);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}