namespace OnlineShop.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Collections.Generic;

    using OnlineShop.Models.Products.Components;
    using OnlineShop.Models.Products.Peripherals;
    using OnlineShop.Models.Products.Computers;
    using OnlineShop.Common.Constants;

    public class Controller : IController
    {
        private readonly List<IComputer> computers;
        private readonly List<IComponent> components;
        private readonly List<IPeripheral> peripherals;

        public Controller()
        {
            this.computers = new List<IComputer>();
            this.components = new List<IComponent>();
            this.peripherals = new List<IPeripheral>();
        }

        public string AddComponent(int computerId, int id, string componentType, string manufacturer, string model, decimal price, double overallPerformance, int generation)
        {
            IComputer computer = this.ValidateComputerExists(computerId);

            if (this.components.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComponentId);
            }

            Type type = Type.GetType($"OnlineShop.Models.Products.Components.Children.{componentType}");

            if (type == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(int), typeof(string), typeof(string), typeof(decimal), typeof(double), typeof(int) });

            try
            {
                IComponent component = (IComponent)constructor.Invoke(new object[] { id, manufacturer, model, price, overallPerformance, generation });
                this.computers.FirstOrDefault(c => c == computer).AddComponent(component);
                this.components.Add(component);
            }
            catch (TargetInvocationException ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }

            return string.Format(SuccessMessages.AddedComponent, componentType, id, computerId);
        }

        public string AddComputer(string computerType, int id, string manufacturer, string model, decimal price)
        {
            if (this.computers.Any(c => c.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingComputerId);
            }

            Type type = Type.GetType($"OnlineShop.Models.Products.Computers.Children.{computerType}");

            if (type == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComputerType);
            }

            ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(int), typeof(string), typeof(string), typeof(decimal) });

            try
            {
                IComputer computer = (IComputer)constructor.Invoke(new object[] { id, manufacturer, model, price });
                this.computers.Add(computer);
            }
            catch (TargetInvocationException ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }

            return string.Format(SuccessMessages.AddedComputer, id);
        }

        public string AddPeripheral(int computerId, int id, string peripheralType, string manufacturer, string model, decimal price, double overallPerformance, string connectionType)
        {
            IComputer computer = this.ValidateComputerExists(computerId);

            if (this.peripherals.Any(p => p.Id == id))
            {
                throw new ArgumentException(ExceptionMessages.ExistingPeripheralId);
            }

            Type type = Type.GetType($"OnlineShop.Models.Products.Peripherals.Children.{peripheralType}");

            if (type == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            ConstructorInfo constructor = type.GetConstructor(new Type[] { typeof(int), typeof(string), typeof(string), typeof(decimal), typeof(double), typeof(string) });

            try
            {
                IPeripheral peripheral = (IPeripheral)constructor.Invoke(new object[] { id, manufacturer, model, price, overallPerformance, connectionType });

                this.computers.FirstOrDefault(c => c == computer).AddPeripheral(peripheral);
                this.peripherals.Add(peripheral);
            }
            catch (TargetInvocationException ex)
            {
                throw new ArgumentException(ex.InnerException.Message);
            }

            return string.Format(SuccessMessages.AddedPeripheral, peripheralType, id, computerId);
        }

        public string BuyBest(decimal budget)
        {
            int computerId = 0;

            foreach (var computer in this.computers.OrderByDescending(c => c.OverallPerformance))
            {
                if (computer.Price <= budget)
                {
                    computerId = computer.Id;
                    break;
                }
            }

            if (computerId == 0)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CanNotBuyComputer, budget));
            }

            IComputer computerToBuy = this.computers.First(c => c.Id == computerId);

            this.RemoveComponentsAndPeripherals(computerToBuy);
            this.computers.Remove(computerToBuy);

            return computerToBuy.ToString();
        }

        public string BuyComputer(int id)
        {
            IComputer computer = this.ValidateComputerExists(id);

            this.RemoveComponentsAndPeripherals(computer);
            this.computers.Remove(computer);

            return computer.ToString();
        }

        public string GetComputerData(int id)
        {
            IComputer computer = this.ValidateComputerExists(id);

            return computer.ToString();
        }

        public string RemoveComponent(string componentType, int computerId)
        {
            IComputer computer = this.ValidateComputerExists(computerId);

            Type type = Type.GetType($"OnlineShop.Models.Products.Components.Children.{componentType}");

            if (type == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidComponentType);
            }

            IComponent removedComponent = this.computers.FirstOrDefault(c => c.Id == computerId).RemoveComponent(componentType);
            this.components.Remove(removedComponent);

            return string.Format(SuccessMessages.RemovedComponent, componentType, removedComponent.Id);
        }

        public string RemovePeripheral(string peripheralType, int computerId)
        {
            IComputer computer = this.ValidateComputerExists(computerId);

            Type type = Type.GetType($"OnlineShop.Models.Products.Peripherals.Children.{peripheralType}");

            if (type == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPeripheralType);
            }

            IPeripheral removedPeripheral = this.computers.FirstOrDefault(c => c.Id == computerId).RemovePeripheral(peripheralType);
            this.peripherals.Remove(removedPeripheral);

            return string.Format(SuccessMessages.RemovedPeripheral, peripheralType, removedPeripheral.Id);
        }

        private IComputer ValidateComputerExists(int id)
        {
            IComputer computer = this.computers.FirstOrDefault(c => c.Id == id);

            if (computer == null)
            {
                throw new ArgumentException(ExceptionMessages.NotExistingComputerId);
            }

            return computer;
        }

        private void RemoveComponentsAndPeripherals(IComputer computer)
        {
            int[] componentIds = computer.Components.Select(c => c.Id).ToArray();

            this.components.RemoveAll(c => componentIds.Contains(c.Id));

            int[] peripheralIds = computer.Peripherals.Select(p => p.Id).ToArray();

            this.peripherals.RemoveAll(p => peripheralIds.Contains(p.Id));
        }
    }
}
