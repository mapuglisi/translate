using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslationServer.Business;

namespace Tests.TranslationServer.Business
{
    [TestClass]
    public class TranslationLogicTests
    {
        [TestMethod]
        public void TranslateAsyncTest()
        {
            //  Arrange
            var text = "Hello world!";
            var from = "English";
            var to = "German";

            //  Act
            var result = TranslationLogic.TranslateAsync(text, from, to).Result;

            //  Assert
            Assert.IsTrue(string.IsNullOrWhiteSpace(result));
        }
    }
}
