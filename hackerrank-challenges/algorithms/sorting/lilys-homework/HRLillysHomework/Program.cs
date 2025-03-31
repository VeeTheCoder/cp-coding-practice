using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;
using System.Net;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*var strContent = "";
            int arrSize = 0;
            var webRequest = WebRequest.Create(@"https://hr-testcases-us-east-1.s3.amazonaws.com/27262/input03.txt?AWSAccessKeyId=AKIAR6O7GJNX5DNFO3PV&Expires=1599510027&Signature=PUQACqhNpYrhKbQR0F1r3OzLg%2Fw%3D&response-content-type=text%2Fplain");
             using (var response = webRequest.GetResponse())
             using (var content = response.GetResponseStream())
             using (var reader = new StreamReader(content))
             {
                 arrSize = Int32.Parse(reader.ReadLine()); // skip one line
                 string line;
                 while ((line = reader.ReadLine()) != null)
                 {
                     strContent += line;
                 }
             }

            int[] arr = strContent.Split(' ').Select(Int32.Parse).ToArray();*/

            int sortSize = 100000;
            HashSet<int> randomNumbers = new HashSet<int>();
            Random rnd = new Random();
            for (int i = 0; i < sortSize; i++)
            {
                int num = 0;
                while (randomNumbers.Contains(num))
                {
                    num = rnd.Next(1, sortSize + 1);

                    if (!(randomNumbers.Contains(num)))
                    {
                        break;
                    }
                }

                randomNumbers.Add(num);
            }
            int[] arr = new int[randomNumbers.Count()];
            randomNumbers.CopyTo(arr);

            Stopwatch sw = new Stopwatch();
            sw.Start();
            Console.WriteLine(lilysHomework(arr));
            sw.Stop();

            if (sw.ElapsedMilliseconds < 2800)
            {
                Console.WriteLine("Pass" + " Time: " + sw.ElapsedMilliseconds);
            }
            else
            {
                Console.WriteLine("Fail" + " Time: " + sw.ElapsedMilliseconds);
            }

        }

        static int lilysHomework(int[] arr)
        {
            int forwardSwapCount = 0;
            int reverseSwapCount = 0;

            Task task1 = Task.Factory.StartNew(() => { forwardSwapCount = GetForwardSwapCount(arr); });
            Task task2 = Task.Factory.StartNew(() => { reverseSwapCount = GetReverseSwapCount(arr); });
            Task.WaitAll(task1, task2);

            return Math.Min(forwardSwapCount, reverseSwapCount);
        }

        static int GetForwardSwapCount(int[] arr)
        {
            int[] arrCopy = new int[arr.Length];
            int[] sortedArray = new int[arr.Length];
            Stack<int> previousIndexPosition = new Stack<int>();
            Dictionary<int, int> sortedIndexCompare = new Dictionary<int, int>();
            int swapCount = 0;

            Array.Copy(arr, arrCopy, arr.Length);
            Array.Copy(arr, sortedArray, arr.Length);
            Array.Sort(sortedArray);

            for (int i = 0; i < sortedArray.Length; i++)
            {
                sortedIndexCompare.Add(sortedArray[i], i);
            }

            for (int i = 0; i < arrCopy.Length; i++)
            {
                int sortedIndex = sortedIndexCompare[arrCopy[i]];
                if (i != sortedIndex)
                {
                    int tmp = arrCopy[sortedIndex];
                    arrCopy[sortedIndex] = arrCopy[i];
                    arrCopy[i] = tmp;

                    previousIndexPosition.Push(i);
                    if (i != arrCopy.Length)
                    {
                        i = sortedIndex - 1;
                    }
                    swapCount++;
                }
                else if (previousIndexPosition.Count() > 0)
                {
                    if (previousIndexPosition.First() != 0)
                    {
                        i = previousIndexPosition.First() - 1;
                    }
                    else
                    {
                        i = previousIndexPosition.First();
                    }
                    previousIndexPosition.Clear();
                }
            }

            return swapCount;
        }

        static int GetReverseSwapCount(int[] arr)
        {
            int[] arrCopy = new int[arr.Length];
            int[] reverseSortedArray = new int[arr.Length];
            Stack<int> previousIndexPosition = new Stack<int>();
            Dictionary<int, int> sortedIndexCompare = new Dictionary<int, int>();
            int swapCount = 0;

            Array.Copy(arr, arrCopy, arr.Length);
            Array.Copy(arr, reverseSortedArray, arr.Length);
            Array.Sort(reverseSortedArray);
            Array.Reverse(reverseSortedArray);

            for (int i = 0; i < reverseSortedArray.Length; i++)
            {
                sortedIndexCompare.Add(reverseSortedArray[i], i);
            }

            for (int i = 0; i < arrCopy.Length; i++)
            {
                int sortedIndex = sortedIndexCompare[arrCopy[i]];
                if (i != sortedIndex)
                {
                    int tmp = arrCopy[sortedIndex];
                    arrCopy[sortedIndex] = arrCopy[i];
                    arrCopy[i] = tmp;

                    previousIndexPosition.Push(i);
                    if (i != arrCopy.Length)
                    {
                        i = sortedIndex - 1;
                    }
                    swapCount++;
                }
                else if (previousIndexPosition.Count() > 0)
                {
                    if (previousIndexPosition.First() != 0)
                    {
                        i = previousIndexPosition.First() - 1;
                    }
                    else
                    {
                        i = previousIndexPosition.First();
                    }
                    previousIndexPosition.Clear();
                }
            }

            return swapCount;
        }
    }
}