using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordStrengthTests
{
    [TestClass]
    public class CheckErrorsInPassword
    {
        [TestMethod]
        public void ManyArgsuments()
        {
            string[] arguments = new string[] { "password1", "password2" };
            int res = PasswordStrength.Program.Main(arguments);

            Assert.AreEqual(1, res);
        }

        [TestMethod]
        public void ZeroArguments()
        {
            string[] arguments = new string[] { };
            int res = PasswordStrength.Program.Main(arguments);

            Assert.AreEqual(1, res);
        }
    }

    [TestClass]
    public class CheckCountDigit
    {
        [TestMethod]
        public void NoDigit()
        {
            string password = "password";
            int digits = 0;

            int result = PasswordStrength.Program.CountDigit(password);

            Assert.AreEqual(digits, result);
        }

        [TestMethod]
        public void ManyDigits()
        {
            string password = "password111";
            int digits = 3;

            int result = PasswordStrength.Program.CountDigit(password);

            Assert.AreEqual(digits, result);
        }
    }

    [TestClass]
    public class CheckCountUppercaseLetter
    {
        [TestMethod]
        public void NoUppercaseLetter()
        {
            string password = "nouppercase";
            int up = 0;
            int result = PasswordStrength.Program.CountUppercaseLetter(password);

            Assert.AreEqual(up, result);
        }

        [TestMethod]
        public void ManyUppercaseLetter()
        {
            string password = "MANY";
            int up = 4;
            int result = PasswordStrength.Program.CountUppercaseLetter(password);

            Assert.AreEqual(up, result);
        }
    }

    [TestClass]
    public class CheckCountLowercaseLetter
    {
        [TestMethod]
        public void NoLowercaseLetter()
        {
            string password = "NOLOWERCASE";
            int low = 0;
            int result = PasswordStrength.Program.CountLowercaseLetter(password);

            Assert.AreEqual(low, result);
        }

        [TestMethod]
        public void ManyLowercaseLetter()
        {
            string password = "manylowercase";
            int low = 13;
            int result = PasswordStrength.Program.CountLowercaseLetter(password);

            Assert.AreEqual(low, result);
        }
    }

    [TestClass]
    public class CheckDuplicatesTest
    {
        [TestMethod]
        public void StringWithDuplicates()
        {
            string str = "aaaa";
            int result = PasswordStrength.Program.CountDuplicates(str);
            int expected = 4;
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void NoDuplicates()
        {
            string str = "NoDuplicates";
            int result = PasswordStrength.Program.CountDuplicates(str);
            int expected = 0;
            Assert.AreEqual(expected, result);
        }
    }

    [TestClass]
    public class CheckCountStrength
    {
        [TestMethod]
        public void EmptyPassword()
        {
            string password = "";
            int expected = 0;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithUppercaseLetter()
        {
            string password = "ABCD";
            int expected = 12;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithLowercaseLetter()
        {
            string password = "abcde";
            int expected = 15;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithLowercaseAndUppercaseLetter()
        {
            string password = "abcDE";
            int expected = 25;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithDigit()
        {
            string password = "123";
            int expected = 21;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithLowercaseLetterAndDigit()
        {
            string password = "abc123";
            int expected = 42;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithUppercaseLetterAndDigit()
        {
            string password = "ABC1";
            int expected = 22;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithUppercaseAndLowercaseLetterAndDigit()
        {
            string password = "Abc12";
            int expected = 42;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithDuplicatesNoDigitNoUppercaseLetter()
        {
            string password = "aaa";
            int expected = 6;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithDuplicatesNoDigitNoLowercaseLetter()
        {
            string password = "BBB";
            int expected = 6;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithDuplicatesWithDigitNoUppercaseLetter()
        {
            string password = "aa11";
            int expected = 24;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithDuplicatesWithDigitNoLowercaseLetter()
        {
            string password = "BB22";
            int expected = 24;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithDuplicatesAndDigitNoLetter()
        {
            string password = "111";
            int expected = 18;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithDuplicatesAndUppercaseAndLowercaseLetterNoDigit()
        {
            string password = "AaAa";
            int expected = 16;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void PassWithDuplicatesAndDigitAndUppercaseAndLowercaseLetter()
        {
            string password = "AAaa123";
            int expected = 56;
            int result = PasswordStrength.Program.CountStrength(password);

            Assert.AreEqual(expected, result);
        }
    }
}