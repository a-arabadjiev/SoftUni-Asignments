namespace Bakery.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    using Bakery.Core.Contracts;
    using Bakery.Models.BakedFoods.Contracts;
    using Bakery.Models.Drinks.Contracts;
    using Bakery.Models.Tables.Contracts;
    using Bakery.Utilities.Messages;

    public class Controller : IController
    {
        private readonly List<IBakedFood> bakedFoods;
        private readonly List<IDrink> drinks;
        private readonly List<ITable> tables;

        private decimal clearedTablesIncome;

        public Controller()
        {
            bakedFoods = new List<IBakedFood>();
            drinks = new List<IDrink>();
            tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            Type drinkType = Type.GetType($"Bakery.Models.Drinks.{type}");
            ConstructorInfo drinkTypeConstructor = drinkType.GetConstructor(new Type[] { typeof(string), typeof(int), typeof(string) });

            IDrink drink = (IDrink)drinkTypeConstructor.Invoke(new object[] { name, portion, brand });

            drinks.Add(drink);

            return string.Format(OutputMessages.DrinkAdded, name, brand);
        }

        public string AddFood(string type, string name, decimal price)
        {
            Type foodType = Type.GetType($"Bakery.Models.BakedFoods.{type}");
            ConstructorInfo foodTypeConstructor = foodType.GetConstructor(new Type[] { typeof(string), typeof(decimal) });

            IBakedFood food = (IBakedFood)foodTypeConstructor.Invoke(new object[] { name, price });
            bakedFoods.Add(food);

            return string.Format(OutputMessages.FoodAdded, name, type);
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            Type tableType = Type.GetType($"Bakery.Models.Tables.{type}");
            ConstructorInfo tableTypeConstructor = tableType.GetConstructor(new Type[] { typeof(int), typeof(int) });

            ITable table = (ITable)tableTypeConstructor.Invoke(new object[] { tableNumber, capacity });
            tables.Add(table);

            return string.Format(OutputMessages.TableAdded, tableNumber);
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> nonReservedTables = tables.Where(t => !t.IsReserved).ToList();

            StringBuilder tableInfo = new StringBuilder();

            foreach (var table in nonReservedTables)
            {
                tableInfo.AppendLine(table.GetFreeTableInfo());
            }

            return tableInfo.ToString().Trim();
        }

        public string GetTotalIncome()
        {
            decimal totalIncome = tables.Select(t => t.GetBill()).Sum() + clearedTablesIncome;

            return string.Format(OutputMessages.TotalIncome, totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            decimal bill = table.GetBill();
            clearedTablesIncome += bill;

            tables.FirstOrDefault(t => t.TableNumber == tableNumber).Clear();

            string output = $"Table: {tableNumber}\nBill: {bill:F2}";

            return output;
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IDrink drink = drinks.FirstOrDefault(d => d.Name == drinkName);

            if (drink == null)
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            tables.FirstOrDefault(t => t.TableNumber == tableNumber).OrderDrink(drink);

            return string.Format(OutputMessages.DrinkOrderSuccessful, tableNumber, drinkName, drinkBrand);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            IBakedFood food = bakedFoods.FirstOrDefault(f => f.Name == foodName);

            if (food == null)
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            tables.FirstOrDefault(t => t.TableNumber == tableNumber).OrderFood(food);

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(t => !t.IsReserved && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            tables.FirstOrDefault(t => t == table).Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}
