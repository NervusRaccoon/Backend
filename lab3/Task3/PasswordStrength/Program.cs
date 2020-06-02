using System;
using System.Collections.Generic;

namespace PasswordStrength
{
    public class Program
    {
        public const string InvalidArgumentsCount = "Incorrect number of arguments";
        public static string GetPassword(string[] args)
        {
            if (args.Length != 1)
            {
                throw new Exception(InvalidArgumentsCount);
            }
            return args[0];
        }
        public static bool CheckLowercase(char ch)
        {
            return ch >= 'a' && ch <= 'z';
        }
        public static bool CheckUppercase(char ch)
        {
            return ch >= 'A' && ch <= 'Z';
        }
        public static bool CheckDigit(char ch)
        {
            return ch >= '0' && ch <= '9';
        }
        public static bool CheckPassword(string password)
        {
            if (password == "")
            {
                Console.WriteLine("Identifier must not be an empty string");
                return false;
            }
            for (int i = 0; i < password.Length; i++)
            {
                if (!CheckLowercase(password[i]) && !CheckUppercase(password[i]) && !CheckDigit(password[i]))
                {
                    Console.WriteLine("Identifier must not contain extra characters");
                    return false;
                }
            }
            return true;
        }
        public static int CheckCopies(string str)
        {
            int copies = 0;
            Dictionary<char, int> charDictionary = new Dictionary<char, int>();
            foreach (char ch in str)
            {
                if (charDictionary.ContainsKey(ch))
                {
                    charDictionary[ch]++;
                }
                else
                {
                    charDictionary.Add(ch, 1);
                }
            }
            foreach (var i in storage)
            {
                if (i.Value > 1)
                {
                    charDictionary += i.Value;
                }
            }
            return copies;
        }
        public static int InitialStrength(int length)
        {
            return 4 * length;
        }
        public static int StrengthCaseLetters(int length, int numberOfCase)
        {
            return numberOfCase != 0 ? (length - numberOfCase) * 2 : 0;
        }
        public static int StrengthDigits(int digits)
        {
            return digits != 0 ? (4 * digits) : 0;
        }
        public static int StrengthWithOnlyDigitsOrLetters(int length, int lowercase, int uppercase, int digits)
        {
            if ((lowercase == 0 && uppercase == 0) || digits == 0)
            {
                return length;
            }
            return 0;
        }
        public static int StrengthCopies(string password)
        {
            int copies = CheckCopies(password);
            return copies;
        }
        public static int CalculateStrength(string password, int digits, int lowercase, int uppercase)
        {
            int strength = 0;
            int length = password.Length;

            strength += InitialStrength(length);
            strength += StrengthDigits(digits);
            strength += StrengthCaseLetters(length, uppercase);
            strength += StrengthCaseLetters(length, lowercase);
            strength -= StrengthWithOnlyDigitsOrLetters(length, lowercase, uppercase, digits);
            strength -= StrengthCopies(password);

            return strength;
        }
        public static int GetPasswordStrength(string password)
        {
            int digits = 0;
            int lowercase = 0;
            int uppercase = 0;

            for (int i = 0; i < password.Length; i++)
            {
                if (CheckDigit(password[i]))
                {
                    digits++;
                }
                if (CheckLowercase(password[i]))
                {
                    lowercase++;
                }
                if (CheckUppercase(password[i]))
                {
                    uppercase++;
                }
            }
            int strength = CalculateStrength(password, digits, lowercase, uppercase);
            return strength;
        }
        public static void Main(string[] args)
        {
            try
            {
                string password = GetPassword(args);
                if (CheckPassword(password))
                {
                    int passwordStrength = GetPasswordStrength(password);
                    Console.WriteLine(passwordStrength);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"{e.GetType().Name}: " + InvalidArgumentsCount);
            }
        }
    }
}
