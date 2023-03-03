namespace P01.ClassBox
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                decimal length = decimal.Parse(Console.ReadLine());
                decimal width = decimal.Parse(Console.ReadLine());
                decimal height = decimal.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                Console.WriteLine($"Surface Area - {box.GetSurfaceArea():F2}");
                Console.WriteLine($"Lateral Surface Area - {box.GetLateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.GetVolume():F2}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}