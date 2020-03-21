using System;

namespace print_args
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("No parameters were specified!");
                Environment.Exit(1);
            }
            else
            {
                Console.WriteLine("Number of arguments: {0}", args.Length);
                Console.Write("Arguments: {0}", String.Join(" ", args));
            }
        }
    }
}