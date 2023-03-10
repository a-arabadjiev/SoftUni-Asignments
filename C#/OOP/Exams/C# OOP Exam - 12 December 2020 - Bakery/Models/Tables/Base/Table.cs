namespace Bakery.Models.Tables.Base
{
    using System;
    using System.Text;
    using System.Linq;
    using System.Collections.Generic;

    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables.Contracts;
    using Bakery.Utilities.Messages;

    public abstract class Table : ITable
    {
        private readonly List<IBakedFood> foodOrders;
        private readonly List<IDrink> drinkOrders;

        private int capacity;
        private int numberOfPeople;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;
            this.IsReserved = false;

            this.foodOrders = new List<IBakedFood>();
            this.drinkOrders = new List<IDrink>();
        }

        public IReadOnlyCollection<IBakedFood> FoodOrders 
        { 
            get
            {
                return this.foodOrders;
            }
        }
        public IReadOnlyCollection<IDrink> DrinkOrders
        {
            get
            {
                return this.drinkOrders;
            }
        }

        public int TableNumber { get; }

        public int Capacity
        {
            get
            {
                return this.capacity;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get
            {
                return this.numberOfPeople;
            }
            protected set
            {
                this.numberOfPeople = value;
            }
        }

        public decimal PricePerPerson { get; }

        public bool IsReserved { get; private set; }

        public decimal Price
            => FoodOrders.Select(f => f.Price).Sum()
            + DrinkOrders.Select(f => f.Price).Sum()
            + this.NumberOfPeople * this.PricePerPerson;


        public void Clear()
        {
            this.foodOrders.Clear();
            this.drinkOrders.Clear();
            
            this.NumberOfPeople = 0;
            this.IsReserved = false;
        }

        public decimal GetBill()
        {
             return this.Price;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder tableToString = new StringBuilder();

            tableToString.AppendLine($"Table: {this.TableNumber}");
            tableToString.AppendLine($"Type: {this.GetType().Name}");
            tableToString.AppendLine($"Capacity: {this.Capacity}");
            tableToString.AppendLine($"Price per Person: {this.PricePerPerson}");

            return tableToString.ToString().Trim();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinkOrders.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foodOrders.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;

            if (numberOfPeople <= 0)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
            }

            this.NumberOfPeople = numberOfPeople;
        }
    }
}
