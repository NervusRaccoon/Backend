using System;
using System.Collections.Generic;

namespace PasswordStrength
{
    public static class Program
    {
        public static int CountUppercaseLetter(string password)
        {
            int uppercase = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 'A' && password[i] <= 'Z')
                {
                    uppercase += 1;
                }
            }
            return uppercase;
        }

        public static int CountLowercaseLetter(string password)
        {
            int lowercase = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= 'a' && password[i] <= 'z')
                {
                    lowercase += 1;
                }
            }
            return lowercase;
        }

        public static int CountDigit(string password)
        {
            int numbers = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= '0' && password[i] <= '9')
                {
                    numbers += 1;
                }
            }
            return numbers;
        }
        public static int CountDuplicates(string password)
        {
            int duplicates = 0;

            Dictionary<char, int> charDictionary = new Dictionary<char, int>();

            foreach (char ch in password)
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
            foreach (var item in charDictionary)
            {
                if (item.Value > 1)
                {
                    duplicates += item.Value;
                }
            }
            return duplicates;
        }
        public static int CountStrength(string password)
        {
            int strength = 0;
            int len = password.Length;
            strength += len * 4;
            strength += (4 * CountDigit(password));
            if (CountUppercaseLetter(password) > 0)
            {
                strength += (len - CountUppercaseLetter(password)) * 2;
            }
            if (CountLowercaseLetter(password) > 0)
            {
                strength += (len - CountLowercaseLetter(password)) * 2;
            }
            if ((len == CountUppercaseLetter(password) + CountLowercaseLetter(password)) || (CountUppercaseLetter(password) + CountLowercaseLetter(password) == 0))
            {
                strength -= len;
            }
            strength -= CountDuplicates(password);
            return strength;
        }
        public static int Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect number of arguments");
                return 1;
            }

            int strength;
            string password = args[0];
            strength = CountStrength(password);
            Console.WriteLine(strength);
            return 0;
        }
    }
}