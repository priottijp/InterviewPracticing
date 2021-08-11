using System;

namespace InterviewPracticing.DesignPatterns.Creational
{

    // Source: https://exceptionnotfound.net/abstract-factory-pattern-in-csharp/
    public class AbstractFactory : DesignPattern
    {
        public override void TryPattern()
        {
            bool validOption = false;

            while (!validOption)
            {
                Console.WriteLine("Who are you? (A)dult or (C)hild?");
                char input = Console.ReadKey().KeyChar;
                switch (input.ToString().ToUpper())
                {
                    case "A":
                        CreateFactory(new AdultCuisineFactory());
                        validOption = true;
                        break;

                    case "C":
                        CreateFactory(new KidCuisineFactory());
                        validOption = true;
                        break;

                    default:
                        Console.WriteLine("Not a valid option, try again.");
                        break;
                }
            }
        }
        private static void CreateFactory(RecipeFactory factory)
        {
            var sandwich = factory.CreateSandwich();
            var dessert = factory.CreateDessert();

            Console.WriteLine("\nSandwich: " + sandwich.GetType().Name);
            Console.WriteLine("Dessert: " + dessert.GetType().Name);

            Console.ReadLine();

        }
    }
    /// <summary>
    /// An abstract object.
    /// </summary>
    abstract class Sandwich { }

    /// <summary>
    /// An abstract object.
    /// </summary>
    abstract class Dessert { }
    /// <summary>
    /// The AbstractFactory class, which defines methods for creating abstract objects.
    /// </summary>
    abstract class RecipeFactory
    {
        public abstract Sandwich CreateSandwich();
        public abstract Dessert CreateDessert();
    }
    /// <summary>
    /// A ConcreteProduct
    /// </summary>
    class BLT : Sandwich { }

    /// <summary>
    /// A ConcreteProduct
    /// </summary>
    class CremeBrulee : Dessert { }

    /// <summary>
    /// A ConcreteFactory which creates concrete objects by implementing the abstract factory's methods.
    /// </summary>
    class AdultCuisineFactory : RecipeFactory
    {
        public override Sandwich CreateSandwich()
        {
            return new BLT();
        }

        public override Dessert CreateDessert()
        {
            return new CremeBrulee();
        }
    }
    /// <summary>
    /// A concrete object
    /// </summary>
    class GrilledCheese : Sandwich { }

    /// <summary>
    /// A concrete object
    /// </summary>
    class IceCreamSundae : Dessert { }

    /// <summary>
    /// A concrete factory which creates concrete objects by implementing the abstract factory's methods.
    /// </summary>
    class KidCuisineFactory : RecipeFactory
    {
        public override Sandwich CreateSandwich()
        {
            return new GrilledCheese();
        }

        public override Dessert CreateDessert()
        {
            return new IceCreamSundae();
        }
    }
}
