using System;
using System.Linq;
using System.Text;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree binaryTree = new BinaryTree();

            int[] intArray = new int[15];

            for (var i = 0; i < 15; i++)
            {
                Random random = new Random();
                int rand = 0;
                rand = random.Next(1, 50);

                while (intArray.Contains(rand))
                {
                    rand = random.Next(1, 50);
                    if (!(intArray.Contains(rand)))
                    {
                        break;
                    }
                }

                binaryTree.Add(rand);
                intArray[i] = rand;
            }

            StringBuilder initialArraySB = new StringBuilder("Initial Insert: ");

            for (int i = 0; i < intArray.Length; i++)
            {
                initialArraySB.Append(intArray[i].ToString() + " ");
            }

            initialArraySB.Length--;

            Console.WriteLine(initialArraySB);

            int depth = binaryTree.GetMaxDepth();
            Console.WriteLine("Depth: " + depth);

            Console.WriteLine("PreOrder:");
            binaryTree.PrintPreOrder(binaryTree.Root);
            Console.WriteLine();

            Console.WriteLine("InOrder:");
            binaryTree.PrintInOrder(binaryTree.Root);
            Console.WriteLine();

            Console.WriteLine("PostOrder:");
            binaryTree.PrintPostOrder(binaryTree.Root);
            Console.WriteLine();

            Console.WriteLine("BFS:");
            binaryTree.PrintBFS(binaryTree.Root);
            Console.WriteLine();

            Console.WriteLine("DFS:");
            binaryTree.PrintDFS(binaryTree.Root);
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
