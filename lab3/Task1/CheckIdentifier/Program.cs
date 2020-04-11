using System;

namespace CheckIdentifier
{
    public class Program
    {
        public static bool CheckDigit(char ch)
        {
            return ch >= '0' && ch <= '9';
        }

        public static bool CheckLetter(char ch)
        {
            return (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');
        }
        public static string GetIdentifier(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments");
            }
            return args[0];
        }
        public static bool CheckIdentifierForErrors(string identifier)
        {
            if (identifier == "")
            {
                Console.WriteLine("Identifier must not be an empty string");
                return false;
            }

            if (CheckDigit(identifier[0]))
            {
                Console.WriteLine("Identifier cannot start with a digit");
                return false;
            }
            if (!CheckLetter(identifier[0]))
            {
                Console.WriteLine("Identifier can start only with a letter");
                return false;
            }
            else
            {
                for (int i = 1; i < identifier.Length; i++)
                {
                    if (!CheckLetter(identifier[i]) && !CheckDigit(identifier[i]))
                    {
                        Console.WriteLine("Identifier must contain only letters or numbers");
                        return false;
                    }
                }
                return true;
            }

        }
        public static void Main(string[] args)
        {
            string identifier = GetIdentifier(args);
            if (CheckIdentifierForErrors(identifier))
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }

        }
    }
}