using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Creational.Factories.AbstractFactory
{
    public interface IHotDrink
    {
        void Consume();
    }

    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            WriteLine("Drinking tea.");
        }
    }

    internal class COffee : IHotDrink
    {
        public void Consume()
        {
            WriteLine("Drinking coffee.");
        }
    }

    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine("Preparing tea.");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            WriteLine("Preparing coffee.");
            return new COffee();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableDrink // violates open-closed
        {
            Coffee, Tea
        }

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories =
            new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach(AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
                var factory = (IHotDrinkFactory)Activator.CreateInstance(
                    Type.GetType($"Creational.Factories.AbstractFactory.{Enum.GetName(typeof(AvailableDrink), drink)}Factory")
                );
                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }

    public static class AbstractFactoryExample
    {
        public static void RunExample()
        {
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee, 10);
            drink.Consume();
        }
    }
}
