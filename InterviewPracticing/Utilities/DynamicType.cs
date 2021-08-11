using System;
using System.Collections;

namespace InterviewPracticing.Utilities
{
    public class DynamicType
    {
        public void UsingDynamic()
        {
            var a = 1;
            dynamic istrue = a is int;
            Console.WriteLine(istrue.GetType());
            Console.WriteLine(istrue);
            istrue = 1;
            Console.WriteLine(istrue.GetType());
            Console.WriteLine(istrue);
            istrue = "";
            Console.WriteLine(istrue.GetType());
            Console.WriteLine(istrue);
            istrue = DateTime.Now;
            Console.WriteLine(istrue.GetType());
            Console.WriteLine(istrue);
        }

        public void UsingAnonymous()
        {
            var anonymousData = new
            {
                Name = "JP",
                SurName = "Priotti"
            };
            Console.WriteLine("First Name : " + anonymousData.Name);
            Console.WriteLine("First Name : " + anonymousData.SurName);
        }

        public void UsingArraylist()
        {
            ArrayList obj = new ArrayList();
            obj.Add(50);
            obj.Add("Dog");
            obj.Add(DateTime.Now);
        }
    }
}
