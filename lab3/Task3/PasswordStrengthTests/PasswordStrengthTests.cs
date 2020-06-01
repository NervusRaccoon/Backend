using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PasswordStrengthTests
{
    [TestClass]
    public class GetPasswordTests
    {
        [TestMethod]
        public void MoreThanOneArgument_ShouldThrowException()
        {
            string[] twoArgs = { "aa", "" };
            try
            {
                PasswordStrength.Program.GetPassword(twoArgs);
            }
            catch (System.Exception e)
            {
                Equals(e.Message, PasswordStrength.Program.InvalidArgumentsCount);
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
        [TestMethod]
        public void WithNoArgument_ShouldThrowException()
        {
            string[] noArgs = { };
            try
            {
                PasswordStrength.Program.GetPassword(noArgs);
            }
            catch (System.Exception e)
            {
                Equals(e.Message, PasswordStrength.Program.InvalidArgumentsCount);
                return;
            }
            Assert.Fail("The expected exception was not thrown");
        }
    }
    [TestClass]
    public class CheckLetterAndDigit
    {
        [TestMethod]
        public void DigitWithNumber_ShouldReturnTrue()
        {
            char number = '1';
            bool res = PasswordStrength.Program.CheckDigit(number);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void Lowercase_ShouldReturnTrue()
        {
            char letter = 'a';
            bool res = PasswordStrength.Program.CheckLowercase(letter);
            Assert.AreEqual(true, res);
        }
        [TestMethod]
        public void Uppercase_ShouldReturnTrue()
        {
            char letter = 'A';
            bool res = PasswordStrength.Program.CheckUppercase(letter);
            Assert.AreEqual(true, res);
        }
    }
    [TestClass]
    public class CheckPasswordTests
    {
        [TestMethod]
        public void EmptyPassword_ShouldReturnFalse()
        {
            string emptyString = "";
            bool result = PasswordStrength.Program.CheckPassword(emptyString);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void ExtraSymbols_ShouldReturnFalse()
        {
            string wrongPassword = "ab#";
            bool result = PasswordStrength.Program.CheckPassword(wrongPassword);
            Assert.AreEqual(false, result);
        }
        [TestMethod]
        public void RightPassword_ShouldReturnTrue()
        {
            string rightPassword = "Daria2020";
            bool result = PasswordStrength.Program.CheckPassword(rightPassword);
            Assert.AreEqual(true, result);
        }
    }
    [TestClass]
    public class CheckCopiesTests
    {
        [TestMethod]
        public void HaveCopies_ShouldReturnNumberOfCopies()
        {
            string str = "aba";
            int resultNumber = PasswordStrength.Program.CheckCopies(str);
            int expectedNumber = 2;
            Assert.AreEqual(expectedNumber, resultNumber);
        }
        [TestMethod]
        public void NoCopies_ShouldReturnZero()
        {
            string str = "abc";
            int resultNumber = PasswordStrength.Program.CheckCopies(str);
            int expectedNumber = 0;
            Assert.AreEqual(expectedNumber, resultNumber);
        }
    }
    [TestClass]
    public class GetStrengthTests
    {
        [TestMethod]
        public void InitialStrength()
        {
            int length = 4;
            int resultStrength = PasswordStrength.Program.InitialStrength(length);
            int expectedStrength = 16;
            Assert.AreEqual(expectedStrength, resultStrength);
        }
        [TestMethod]
        public void StrengthWithUpperLetters()
        {
            int length = 4;
            int uppercase = 2;
            int resultStrength = PasswordStrength.Program.StrengthCaseLetters(length, uppercase);
            int expectedStrength = 4;
            Assert.AreEqual(expectedStrength, resultStrength);
        }
        [TestMethod]
        public void StrengthWithLowerLetters()
        {
            int length = 4;
            int lowercase = 2;
            int resultStrength = PasswordStrength.Program.StrengthCaseLetters(length, lowercase);
            int expectedStrength = 4;
            Assert.AreEqual(expectedStrength, resultStrength);
        }
        [TestMethod]
        public void StrengthWithDigits()
        {
            int digits = 4;
            int resultStrength = PasswordStrength.Program.InitialStrength(digits);
            int expectedStrength = 16;
            Assert.AreEqual(expectedStrength, resultStrength);
        }
        [TestMethod]
        public void StrengthWithNoDigits()
        {
            int length = 4;
            int digits = 0;
            int uppercase = 2;
            int lowercase = 2;
            int resultStrength = PasswordStrength.Program.StrengthWithOnlyDigitsOrLetters(length, lowercase,
                uppercase, digits);
            int expectedStrength = 4;
            Assert.AreEqual(expectedStrength, resultStrength);
        }
        [TestMethod]
        public void StrengthWithCopies()
        {
            string password = "hello";
            int resultStrength = PasswordStrength.Program.StrengthCopies(password);
            int expectedResult = 2;
            Assert.AreEqual(expectedResult, resultStrength);
        }
    }
    [TestClass]
    public class GetPasswordStrengthTests
    {
        [TestMethod]
        public void PasswordWithOnlyNumbers()
        {
            string password = "123";
            int expectedStrength = 21;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void PasswordWithOnlyLowercase()
        {
            string password = "abcd";
            int expectedStrength = 12;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void PasswordWithOnlyUppercase()
        {
            string password = "ABCD";
            int expectedStrength = 12;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void PasswordWithUppercase()
        {
            string password = "aBCd";
            int expectedStrength = 20;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void PasswordWithNumbersAndLowercase()
        {
            string password = "ab12";
            int expectedStrength = 28;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void PasswordWithNumbersAndUppercase()
        {
            string password = "AB12";
            int expectedStrength = 28;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void PasswordWithCopies()
        {
            string password = "abcd1a";
            int expectedStrength = 28;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
        [TestMethod]
        public void StrongPassword()
        {
            string password = "ab12NeO";
            int expectedStrength = 54;
            int strength = PasswordStrength.Program.GetPasswordStrength(password);
            Assert.AreEqual(expectedStrength, strength);
        }
    }
}
