using System;
using System.Text;

namespace InterviewPracticing.Differences
{
    public class StringBuilderString
    {
        public void StringBuilderOrString()
        {
            string a = "first string";
            a += "this creates another string";
            a += "and this other one.";
            Console.WriteLine(a);  

            StringBuilder sb = new StringBuilder();
            sb.Append("first stringbuilder instance");
            sb.Append("still the same instance");
            Console.WriteLine(sb.ToString()/*string created for the first and only time.*/);
        }
    }
}
