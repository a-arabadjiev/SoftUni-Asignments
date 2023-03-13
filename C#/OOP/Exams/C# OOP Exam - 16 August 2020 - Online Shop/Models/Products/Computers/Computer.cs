namespace OnlineShop.Models.Products.Computers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using OnlineShop.Common.Constants;
    using OnlineShop.Models.Products.Components;
    using OnlineShop.Models.Products.Peripherals;

    public abstract class Computer : Product, IComputer
    {
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        protected Computer(int id, string manufacturer, string model, decimal price, double overallPerformance) 
            : base(id, manufacturer, model, price, overallPerformance)
        {
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public IReadOnlyCollection<IComponent> Components => this.components;

        public IReadOnlyCollection<IPeripheral> Peripherals => this.peripherals;

        public override decimal Price
        {
            get
            {
                return this.price + this.Components.Sum(c => c.Price) + this.Peripherals.Sum(p => p.Price);
            }
        }

        public override double OverallPerformance
        {
            get
            {
                if (this.Components.Count == 0)
                {
                    return this.overallPerformance;
                }
                return this.overallPerformance + this.Components.Average(c => c.OverallPerformance);
            }
        }

        public void AddComponent(IComponent component)
        {
            string componentType = component.GetType().Name;
            string computerType = this.GetType().Name;

            if (this.Components.Any(c => c.GetType().Name == componentType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingComponent, componentType, computerType, this.Id));
            }

            this.components.Add(component);
        }

        public void AddPeripheral(IPeripheral peripheral)
        {
            string peripheralType = peripheral.GetType().Name;
            string computerType = this.GetType().Name;

            if (this.Peripherals.Any(p => p.GetType().Name == peripheralType))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingPeripheral, peripheralType, computerType, this.Id));
            }

            this.peripherals.Add(peripheral);
        }

        public IComponent RemoveComponent(string componentType)
        {
            string computerType = this.GetType().Name;

            IComponent componentToRemove = this.Components.FirstOrDefault(c => c.GetType().Name == componentType);

            if (this.Components.Count == 0 || componentToRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingComponent, componentType, computerType, this.Id));
            }

            this.components.Remove(componentToRemove);

            return componentToRemove;
        }

        public IPeripheral RemovePeripheral(string peripheralType)
        {
            string computerType = this.GetType().Name;

            IPeripheral peripheralToRemove = this.Peripherals.FirstOrDefault(p => p.GetType().Name == peripheralType);

            if (this.Peripherals.Count == 0 || peripheralToRemove == null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.NotExistingPeripheral, peripheralType, computerType, this.Id));
            }

            this.peripherals.Remove(peripheralToRemove);

            return peripheralToRemove;
        }

        public override string ToString()
        {
            StringBuilder computerToString = new StringBuilder();

            computerToString.AppendLine($" Components ({this.Components.Count}):");

            foreach (var component in this.components)
            {
                computerToString.AppendLine($"  {component}");
            }

            double peripheralsOverallPerformance = this.Peripherals.Count != 0 ? this.Peripherals.Average(p => p.OverallPerformance) : 0.00;

            computerToString.AppendLine($" Peripherals ({this.Peripherals.Count}); Average Overall Performance ({peripheralsOverallPerformance:F2}):");

            foreach (var peripheral in this.peripherals)
            {
                computerToString.AppendLine($"  {peripheral}");
            }

            return base.ToString() + Environment.NewLine + computerToString.ToString().TrimEnd();
        }
    }
}
