namespace P02.CarSalesman.Models
{
    using P02.CarSalesman.Utility;

    using System.Text;

    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, double weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, double weight, string color)
            :this(model, engine, weight)
        {
            this.Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public double Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder carAsString = new StringBuilder();

            string engineDisplacement = ValueAssigner.ReturnDoubleOrNotFound(this.Engine.Displacement);
            string engineEfficiency = ValueAssigner.ReturnStringOrNotFound(this.Engine.Efficiency);

            string carWeight = ValueAssigner.ReturnDoubleOrNotFound(this.Weight);
            string carColor = ValueAssigner.ReturnStringOrNotFound(this.Color);

            carAsString.AppendLine($"{this.Model}:");
            carAsString.AppendLine($"  {this.Engine.Model}:");
            carAsString.AppendLine($"    Power: {this.Engine.Power}");
            carAsString.AppendLine($"    Displacement: {engineDisplacement}");
            carAsString.AppendLine($"    Efficiency: {engineEfficiency}");
            carAsString.AppendLine($"  Weight: {carWeight}");
            carAsString.AppendLine($"  Color: {carColor}");

            return carAsString.ToString();
        }
    }
}
