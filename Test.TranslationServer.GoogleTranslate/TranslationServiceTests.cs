using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Translation.Common;
using TranslationServer.GoogleTranslate;

namespace Test.TranslationServer.GoogleTranslate
{
    [TestClass]
    public class TranslationServiceTests
    {
        [TestMethod]
        public void GetTranslatedTextAsync_Test()
        {
            //  Arrange
            var translationData = new TranslationData() { 
                OriginalText = "Hello Ruvan! How are you doing today?", 
                sourceLanguage = Language.English, 
                targetLanguage = Language.German };

            //  Act
            var result = TranslationService.GetTranslatedTextAsync(translationData).Result;

            Console.WriteLine(result);

            //  Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.TranslatedText));
        }


        [TestMethod]
        public void GetTranslatedTextAsync_AutoDetectFromLanguage_Test()
        {
            //  Arrange
            var translationData = new TranslationData()
            {
                OriginalText = "Hello Ruvan! How are you doing today?",
                sourceLanguage = null,
                targetLanguage = Language.German
            };

            //  Act
            var result = TranslationService.GetTranslatedTextAsync(translationData).Result;

            Console.WriteLine(result);

            //  Assert
            Assert.IsTrue(!string.IsNullOrWhiteSpace(result.TranslatedText));
        }


        [TestMethod]
        public void GetTranslatedSentencesAsync_Test()
        {
            //  Arrange
            var translationData = new TranslationData() { 
                OriginalText = "Hello Ruvan! How are you doing today?", 
                sourceLanguage = Language.English, 
                targetLanguage = Language.German };

            //  Act
            var result = TranslationService.GetTranslatedSentencesAsync(translationData).Result;

            Console.WriteLine(result);

            //  Assert
            Assert.IsTrue(result.TranslatedSentences.Any());
        }


        [TestMethod]
        public void GetTranslatedSentencesAsync_AutoDetectFromLanguage_Test()
        {
            //  Arrange
            var translationData = new TranslationData()
            {
                OriginalText = "Hello Ruvan! How are you doing today?",
                sourceLanguage = null,
                targetLanguage = Language.German
            };

            //  Act
            var result = TranslationService.GetTranslatedSentencesAsync(translationData).Result;

            Console.WriteLine(result);

            //  Assert
            Assert.IsTrue(result.TranslatedSentences.Any());
        }
    }
}
