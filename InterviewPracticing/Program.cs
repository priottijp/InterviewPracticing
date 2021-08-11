using InterviewPracticing.DesignPatterns;
using InterviewPracticing.DesignPatterns.Behavioral;
using InterviewPracticing.DesignPatterns.Creational;
using InterviewPracticing.DesignPatterns.Structural;
using InterviewPracticing.Enumerators;
using System;

namespace InterviewPracticing
{
    class Program
    {
        static void Main(string[] args)
        {
            string goOn = "Y";
            while (goOn.ToUpper() == "Y")
            {
                ShowMenuOptions();
                var op1 = Console.ReadLine();
                int intOp1;
                if (int.TryParse(op1, out intOp1))
                {
                    if (intOp1 == (int)MenuOption.DesignPatters)
                    {
                        ShowPatternOptions();
                        FactoryMethod.ResolvePattern(int.Parse(Console.ReadLine())).TryPattern();
                    }
                    else if (intOp1 == (int)MenuOption.WhatsTheDifference) ShowWtdOptions();

                    Console.WriteLine("Continue? Y/N");
                    goOn = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid option. Please retry.");
                    goOn = "Y";
                }
                while (goOn.ToUpper() != "Y" && goOn.ToUpper() != "N")
                {
                    Console.WriteLine("Invalid Option. Continue learning? Y/N");
                    goOn = Console.ReadLine();
                }
            }
        }

        #region Options
        private static void ShowMenuOptions()
        {
            Console.WriteLine("Select what to see today:");
            Console.WriteLine("1-Design Patterns");
            Console.WriteLine("2-What's the difference?");
        }
        private static void ShowWtdOptions()
        {
            Console.WriteLine("     1 - Constant and Readonly");
            Console.WriteLine("     2 - Break and Continue");
        }
        private static void ShowPatternOptions()
        {
            Console.WriteLine("  Creational:");
            Console.WriteLine("     1 - Singleton");
            Console.WriteLine("     2 - AbstractFactory");
            Console.WriteLine("");
            Console.WriteLine("  Structural:");
            Console.WriteLine("     3 - Facade");
            Console.WriteLine("     4 - Bridge");
            Console.WriteLine("");
            Console.WriteLine("  Behavioral:");
            Console.WriteLine("     5 - Strategy");
            Console.WriteLine("     6 - Observer");
        }

        #endregion Options
        
        #region Patterns
        private static void TryObserver()
        {
            // Create price watch for Carrots 
            // and attach restaurants that buy carrots from suppliers.
            Carrots carrots = new Carrots(0.82);
            carrots.Attach(new Restaurant("Mackay's", 0.77));
            carrots.Attach(new Restaurant("Johnny's Sports Bar", 0.74));
            carrots.Attach(new Restaurant("Salad Kingdom", 0.75));

            // Fluctuating carrot prices will notify subscribing restaurants.
            carrots.PricePerPound = 0.79;
            carrots.PricePerPound = 0.76;
            carrots.PricePerPound = 0.74;
            carrots.PricePerPound = 0.81;

            Console.ReadKey();
        }
        private static void TryStrategy()
        {
            SortedList studentRecords = new SortedList();

            studentRecords.SetSortStrategy(new QuickSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new ReverseSort());
            studentRecords.Sort();

            studentRecords.SetSortStrategy(new MergeSort());
            studentRecords.Sort();

            // Wait for user
            Console.ReadKey();
        }
        private static void TryBridge()
        {
            IMessageSender email = new EmailSender();

            Message message = new SystemMessage();
            message.Subject = "Test Message";
            message.Body = "Hi, This is a Test Message";

            message.SendMessage(new EmailSender());
            message.SendMessage(new MSMQSender());
            message.SendMessage(new WebServiceSender());

            UserMessage usermsg = new UserMessage();
            usermsg.Subject = "Test Message";
            usermsg.Body = "Hi, This is a Test Message";
            usermsg.UserComments = "I hope you are well";

            usermsg.MessageSender = email;
            usermsg.Send();

            Console.ReadKey();
        }
        private static void TrySingleton()
        {
            var b1 = LoadBalancer.GetLoadBalancer();
            var b2 = LoadBalancer.GetLoadBalancer();
            var b3 = LoadBalancer.GetLoadBalancer();
            var b4 = LoadBalancer.GetLoadBalancer();
            // Confirm these are the same instance
            if (b1 == b2 && b2 == b3 && b3 == b4)
            {
                Console.WriteLine("Same instance\n");
            }
            // Next, load balance 15 requests for a server
            var balancer = LoadBalancer.GetLoadBalancer();
            for (int i = 0; i < 15; i++)
            {
                string serverName = balancer.NextServer.Name;
                Console.WriteLine("Dispatch request to: " + serverName);
            }
            // Wait for user
            Console.ReadKey();
        }
        private static void TryAbstractFactory()
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
        private static void TryFacade()
        {
            Console.WriteLine("----------------------CLIENT ORDERS FOR PIZZA----------------------------\n");
            var facadeForClient = new RestaurantFacade();
            facadeForClient.GetNonVegPizza();
            facadeForClient.GetVegPizza();
            Console.WriteLine("\n----------------------CLIENT ORDERS FOR BREAD----------------------------\n");
            facadeForClient.GetGarlicBread();
            facadeForClient.GetCheesyGarlicBread();
        }
        private static void ResolvePattern(int intOp2)
        {
            DesignPattern pattern;
            switch (intOp2)
            {
                case (int)DesignPatternEnum.Singleton:
                    pattern = new Singleton();
                    break;
                case (int)DesignPatternEnum.AbstractFactory:
                    pattern = new AbstractFactory();
                    break;
                case (int)DesignPatternEnum.Facade:
                    pattern = new Facade();
                    break;
                case (int)DesignPatternEnum.Bridge:
                    pattern = new Bridge();
                    break;
                case (int)DesignPatternEnum.Strategy:
                    pattern = new Strategy();
                    break;
                case (int)DesignPatternEnum.Observer:
                    pattern = new Observer();
                    TryObserver();
                    break;
                default:
                    pattern = null;
                    break;
            }
            if (pattern != null)
            {
                pattern.TryPattern();
            }
        }
        #endregion Patterns
    }
}
