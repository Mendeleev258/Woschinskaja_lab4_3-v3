// var 3

using System.CodeDom.Compiler;
using System.Runtime.ExceptionServices;

class Program
{
    const int n = 5;

    static int[] fill_arr_from_matrix(int[,] matrix, int row, int size)
    {
        int[] result = new int[size];
        for (int i = 0; i < size; ++i)
            result[i] = matrix[row, i];
        return result;
    }

    static bool is_fibonacci_num(int prelast, int last, int current)
    {
        return prelast + last == current;
    }

    static int[] find_fibonacci_nums(ref int[,] matrix, int size, int row, out int res_arr_size)
    {
        int[] result = new int[size];
        int[] arr = fill_arr_from_matrix(matrix, row, size);
        res_arr_size = 0;

        for (int i = 0; i < size - 2; ++i)
        {
            if (is_fibonacci_num(arr[i], arr[i + 1], arr[i + 2]))
            {
                result[res_arr_size] = arr[i + 2];
                res_arr_size++;
            }
        }
        return result;
    }

    static void fill_matrix(int[,] matrix, int size, int a, int b)
    {
        Random rand = new Random();
        for (int i = 0; i < size; ++i)
            for (int j = 0; j < size; ++j)
                matrix[i, j] = rand.Next(a, b);
    }

    static void print_matrix(int[,] matrix, int size)
    {
        for (int i = 0; i < size; ++i)
        {
            for (int j = 0; j < size; ++j)
                Console.Write($"{matrix[i, j],4} ");
            Console.WriteLine();
        }
    }

    static void Main()
    {
        //int[,] matrix = new int[n, n];
        //fill_matrix(matrix, n, -100, 100);
        int[,] matrix = {
            { 1, 2, 3, 4, 5 },
            { 1, 2, 10, 0, 5 },
            { 100, 5, 105, -55, 50 },
            { 52, 52, 104, -4, 100 },
            { -1, -1, -2, -3, -5} };
        print_matrix(matrix, n);
        int[] arr_fib = new int[n];

        for (int i = 0; i < n; ++i)
        {
            int arr_fib_size;
            arr_fib = find_fibonacci_nums(ref matrix, n, i, out arr_fib_size);

            Console.Write("Fibonacci nums in {0} row: ", i);
            for (int j = 0; j < arr_fib_size; ++j)
                Console.Write(arr_fib[j] + " ");
            Console.WriteLine();
        }
    }
}