using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortOrReverse
{
    class Program
    {
        // Delegate declaration
        delegate int[] ArrayOperation(int[] array);

        static void Main(string[] args)
        {
            // user defined
            Console.Write("Enter the number of elements in the array: ");
            if (!int.TryParse(Console.ReadLine(), out int numElements) || numElements <= 0)
            {
                Console.WriteLine("Invalid number of elements. Exiting...");
                return;
            }

            // Initialize the array with user-defined size
            int[] array = new int[numElements];

            // Collect array elements from the user
            Console.WriteLine("Enter the elements of the array:");
            for (int i = 0; i < numElements; i++)
            {
                Console.Write($"Element {i + 1}: ");
                if (!int.TryParse(Console.ReadLine(), out array[i]))
                {
                    Console.WriteLine("Invalid input. Exiting...");
                    return;
                }
            }

            // choice
            Console.WriteLine("Choose an operation:");
            Console.WriteLine("1. Sort");
            Console.WriteLine("2. Reverse");
            Console.Write("Enter your choice (1 or 2): ");
            string choice = Console.ReadLine();

            // Delegate variable
            ArrayOperation operationDelegate = null;

            // Assign delegate based on user choice
            if (choice == "1")
            {
                operationDelegate = SortArray;
            }
            else if (choice == "2")
            {
                operationDelegate = ReverseArray;
            }
            else
            {
                Console.WriteLine("Invalid choice. Exiting...");
                return;
            }

            // Perform the operation using the delegate
            int[] result = operationDelegate(array);

            // Display the result
            Console.WriteLine("Original Array: [{0}]", string.Join(", ", array));
            if (choice == "1")
            {
                Console.WriteLine("Sorted Array: [{0}]", string.Join(", ", result));
            }
            else if (choice == "2")
            {
                Console.WriteLine("Reversed Array: [{0}]", string.Join(", ", result));
            }

            // Pause the program to view the result
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Method to sort an array
        static int[] SortArray(int[] array)
        {
            int[] sortedArray = (int[])array.Clone();
            Array.Sort(sortedArray);
            return sortedArray;
        }

        // Method to reverse an array
        static int[] ReverseArray(int[] array)
        {
            int[] reversedArray = (int[])array.Clone();
            Array.Reverse(reversedArray);
            return reversedArray;
        }
    }
}