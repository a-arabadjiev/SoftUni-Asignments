namespace P02.CarSalesman.Models
{
    public class Engine
    {
        public Engine(string model, double power)
        {
            this.Model = model;
            this.Power = power;
        }

        public Engine(string model, double power, string efficiency)
            : this(model, power)
        {
            this.Efficiency = efficiency;
        }

        public Engine(string model, double power, double displacement)
            : this(model, power)
        {
            this.Displacement = displacement;
        }

        public Engine(string model, double power, double displacement, string efficiency)
            :this(model, power, efficiency)
        {
            this.Displacement = displacement;
        }

        public string Model { get; set; }
        public double Power { get; set; }
        public string Efficiency { get; set; }
        public double Displacement { get; set; }
    }
}
