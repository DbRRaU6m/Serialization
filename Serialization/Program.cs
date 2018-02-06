using System;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            var iNode1 = new Node("1");
            var iNode2 = new Node("2");
            var iNode3 = new Node("3");
            var iNode4 = new Node("4");

            iNode1.Children.Add(iNode2);
            iNode1.Children.Add(iNode3);
            iNode3.Children.Add(iNode4);

            var iSerialized = Serializer.Serialize(iNode1);
            var iDeserialized = Serializer.Deserialize<Node>(iSerialized);

            // debug info

            var Lines = iDeserialized.Dump();
            foreach (var iLine in Lines)
            {
                Console.WriteLine(iLine);
            }
            Console.WriteLine("Press any key to continue."); // oh no, not that one
            Console.ReadKey();
        }
    }
}
