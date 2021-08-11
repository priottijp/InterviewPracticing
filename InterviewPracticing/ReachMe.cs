namespace InterviewPracticing
{
    public class ReachMe
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public ReachMe()
        {
            this._name = "Unnamed";
        }
        public ReachMe(string name)
        {
            this._name = name;
        }
    }
}
