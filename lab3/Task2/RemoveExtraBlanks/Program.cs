using System;
using System.IO;

namespace RemoveExtraBlanks
{
    public class Program
    {
        public static string ChangeString(string inpStr)
        {
            string newStr = "";
            bool blank = false;
            for (int i = 0; i < inpStr.Length; i++)
            {
                if (inpStr[i] != ' ' && inpStr[i] != '\t')
                {
                    newStr += inpStr[i];
                    blank = true;
                }
                else if (blank)
                {
                    newStr += inpStr[i];
                    blank = false;
                }
            }
            if (newStr.EndsWith(' ') || newStr.EndsWith('\t'))
            {
                newStr = newStr.Remove(newStr.Length - 1);
            }

            return newStr;
        }

        public static bool CopyInFile(string inputFile, string outputFile)
        {
            if (!File.Exists(inputFile))
            {
                Console.WriteLine("File does not exist");
                return false;
            }

            StreamReader inpFile = new StreamReader(inputFile);
            StreamWriter outFile = new StreamWriter(outputFile);

            string str;
            while ((str = inpFile.ReadLine()) != null)
            {
                outFile.WriteLine(ChangeString(str));
            }

            inpFile.Close();
            outFile.Close();
            return true;
        }

        public static int Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Incorrect number of arguments");
                return 1;
            }

            string inputFile = args[0];
            string outputFile = args[1];
            CopyInFile(inputFile, outputFile);

            return 0;
        }
    }
}