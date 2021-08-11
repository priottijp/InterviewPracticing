namespace InterviewPracticing.Utilities
{
    public class BoxingUnboxing
    {
        public void BoxAndUnbox()
        {
            int a = 1;
            object Box = a; //Implicit Boxing
            int UnboxedInteger = (int)Box; // Implicit Unboxing
        }
    }
}
