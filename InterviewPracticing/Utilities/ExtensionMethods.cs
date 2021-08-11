using System.Collections.Generic;
using System.Linq;

namespace InterviewPracticing.Utilities
{
    public static class ExtensionMethods
    {
        public static List<string> GimmeAList(this string phrase) => phrase.Split(' ').ToList();
    }
}
