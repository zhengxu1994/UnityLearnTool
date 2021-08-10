using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DataStructure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            //Tree<string> tree = new Tree<string>();
            //Node<string> nodeA = tree.CreateRoot("A");
            //Node<string> nodeB = tree.AddChild(nodeA, "B");
            //Node<string> nodeC = tree.AddSibling(nodeB, "C");
            //Node<string> nodeD = tree.AddSibling(nodeC, "D");
            //Node<string> nodeE = tree.AddChild(nodeB, "E");
            //Node<string> nodeF = tree.AddChild(nodeC, "F");
            //Node<string> nodeG = tree.AddSibling(nodeF, "G");
            //Node<string> nodeH = tree.AddChild(nodeF, "H");

            //tree.TraverseByLevel();
            //Console.ReadLine();
          
            DataSort sort = new DataSort();
            Random r = new Random();
            var arr = new List<int>();
            for (int i = 0; i < 20000; i++)
            {
                arr.Add(i);
            }
            DateTime beforDT = System.DateTime.Now;
            sort.BuddingSort(arr);
            DateTime afterDT = System.DateTime.Now;
            TimeSpan ts = afterDT.Subtract(beforDT);
            Console.WriteLine("Stopwatch总共花费{0}ms.", ts.TotalMilliseconds);
            //for (int i = 0; i < arr.Count; i++)
            //    Console.WriteLine(arr[i]);
            Console.ReadLine();
        }
    }
}
