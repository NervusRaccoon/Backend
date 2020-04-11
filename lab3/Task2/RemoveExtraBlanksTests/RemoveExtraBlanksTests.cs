using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveExtraBlanksTests
{
    [TestClass]
    public class RemoveExtraBlanksTests
    {
        [TestMethod]
        public void EmptyString()
        {
            string str = "";
            string expectedStr = "";
            string res = RemoveExtraBlanks.Program.ChangeString(str);
            Assert.AreEqual(expectedStr, res);
        }

        [TestMethod]
        public void RemoveDuplicateWithSpaces()
        {
            string str = "               string                   with      spaces     ";
            string expectedStr = "string with spaces";
            string res = RemoveExtraBlanks.Program.ChangeString(str);
            Assert.AreEqual(expectedStr, res);
        }

        [TestMethod]
        public void RemoveDuplicateWithTabs()
        {
            string str = "\t\tstring \t\twith \t\ttabs\t\t";
            string expectedStr = "string with tabs";
            string res = RemoveExtraBlanks.Program.ChangeString(str);
            Assert.AreEqual(expectedStr, res);
        }
    }
}