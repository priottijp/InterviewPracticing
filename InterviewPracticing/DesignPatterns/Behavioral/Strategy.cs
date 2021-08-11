using System;
using System.Collections.Generic;

namespace InterviewPracticing.DesignPatterns.Behavioral
{
    //Source: https://www.dofactory.com/net/strategy-design-pattern

    public class Strategy : DesignPattern
    {
        public override void TryPattern()
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
    }
    /// <summary>
    /// The 'Strategy' abstract class
    /// </summary>
    public abstract class SortStrategy
    {
        public abstract void Sort(List<string> list);
    }
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    public class QuickSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Sort();  // Default is Quicksort
            Console.WriteLine("QuickSorted list ");
        }
    }
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    public class ReverseSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            list.Reverse();
            Console.WriteLine("ReverseSort list ");
        }
    }
    /// <summary>
    /// A 'ConcreteStrategy' class
    /// </summary>
    public class MergeSort : SortStrategy
    {
        public override void Sort(List<string> list)
        {
            Console.WriteLine("notimplemented - MergeSorted list ");
        }
    }
    /// <summary>
    /// The 'Context' class
    /// </summary>
    public class SortedList
    {
        private List<string> list = new List<string>();
        public SortedList()
        {
            list.Add("Samual");
            list.Add("Jimmy");
            list.Add("Sandra");
            list.Add("Vivek");
            list.Add("Anna");
        }
        private SortStrategy sortstrategy;

        public void SetSortStrategy(SortStrategy sortstrategy)
        {
            this.sortstrategy = sortstrategy;
        }

        public void Add(string name)
        {
            list.Add(name);
        }

        public void Sort()
        {
            sortstrategy.Sort(list);

            // Iterate over list and display results
            foreach (string name in list)
                Console.WriteLine(" " + name);

            Console.WriteLine();
        }
    }
}
