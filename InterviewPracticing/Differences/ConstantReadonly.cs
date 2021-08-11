using System;

namespace InterviewPracticing.Differences
{

    // Const is nothing but "constant", a variable of which the value is constant but at COMPILE TIME. 
    // And it's mandatory to assign a value to it. 
    // By default, a const is static and WE CANNOT CHANGE THE VALUE OF A CONST VARIABLE THROUGHOUT THE ENTIRE PROGRAM.
    // Readonly is the keyword whose value WE CAN CHANGE DURING RUNTIME or we can assign it at run time but only through the non-static constructor.
   
    public class ConstantReadonly
    {
        readonly int read = 10;
        const int cons = 10;
        public ConstantReadonly()
        {
            read = 100;
            //YOU CAN'T DO THIS cons = 100;
        }
        public void Check()
        {
            Console.WriteLine("Read only : {0}", read);
            Console.WriteLine("const : {0}", cons);
        }
    }
}
