using System;

namespace InterviewPracticing.Differences
{
    public class BreakContinue
    {

        public void BreakOrContinue(string borc)
        {
            for (int i = 0; i <= 5; i++)
            {
                if (i == 4)
                {
                    if(borc == "break") break;
                    continue;
                }
                Console.WriteLine("The number is " + i);
                Console.ReadLine();
            }
        }
    }
}