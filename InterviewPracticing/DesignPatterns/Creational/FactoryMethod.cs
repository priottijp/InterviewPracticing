using InterviewPracticing.DesignPatterns.Behavioral;
using InterviewPracticing.DesignPatterns.Structural;
using InterviewPracticing.Enumerators;

namespace InterviewPracticing.DesignPatterns.Creational
{
    public static class FactoryMethod
    {
        public static DesignPattern ResolvePattern(int intOp2)
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
                    break;
                default:
                    pattern = null;
                    break;
            }
            return pattern;
        }
    }
}
