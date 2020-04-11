using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckIdentifierTests
{
    [TestClass]
    public class CheckIdentifierTests
    {
        [TestMethod]
        public void EmptyIdentifier()
        {
            bool res = CheckIdentifier.Program.CheckIdentifierForErrors("");
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IdentifierStartWithDigit()
        {
            bool res = CheckIdentifier.Program.CheckIdentifierForErrors("1dent");
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void IdentifierWithIncorectSymbol()
        {
            bool res = CheckIdentifier.Program.CheckIdentifierForErrors("id^nt");
            Assert.IsFalse(res);
        }

        [TestMethod]
        public void Correct_identifier()
        {
            bool res = CheckIdentifier.Program.CheckIdentifierForErrors("ident123ident");
            Assert.IsTrue(res);
        }
    }
}