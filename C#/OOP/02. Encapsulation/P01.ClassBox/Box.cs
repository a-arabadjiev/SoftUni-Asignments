namespace P01.ClassBox
{
    using System.Text;

    public class Box
    {
        private decimal length;
        private decimal width;
        private decimal height;

        public Box(decimal length, decimal width, decimal height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        public decimal Length 
        { 
            get
            {
                return this.length;
            }
            private set
            {
                this.ValidateValue(value, nameof(this.Length));
                this.length = value;
            }
        }
        public decimal Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.ValidateValue(value, nameof(this.Width));
                this.width = value;
            }
        }
        public decimal Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.ValidateValue(value, nameof(this.Height));
                this.height = value;
            }
        }

        public decimal GetSurfaceArea()
        {
            decimal resut =
                2 * this.Length * this.Width +
                2 * this.Length * this.Height +
                2 * this.Height * this.Width;

            return resut;
        }

        public decimal GetLateralSurfaceArea()
        {
            decimal result =
                2 * this.Length * this.Height +
                2 * this.Width * this.Height;

            return result;
        }

        public decimal GetVolume()
        {
            decimal result = this.Height * this.Length * this.Width;

            return result;
        }

        public override string ToString()
        {
            var boxToString = new StringBuilder();

            boxToString.AppendLine($"Surface Area - {this.GetSurfaceArea():F2}");
            boxToString.AppendLine($"Lateral Surface Area - {this.GetLateralSurfaceArea():F2}");
            boxToString.AppendLine($"Volume - {this.GetVolume():F2}");

            return boxToString.ToString().Trim();
        }

        private void ValidateValue(decimal value, string valueType)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{valueType} cannot be zero or negative.");
            }
        }
    }
}
