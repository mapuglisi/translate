using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Translation.Common;
using TranslationServer.GoogleTranslate;

namespace Test.TranslationServer.GoogleTranslate
{
    /// <summary>
    /// A test class that contains tests for the <see cref="TranslationService"/>
    /// </summary>
    [TestClass]
    public class TranslationServiceTests
    {
        /// <summary>
        /// Test the <see cref="TranslationService.GetTranslatedTextAsync(TranslationData)"/>
        /// </summary>
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


        /// <summary>
        /// Test the <see cref="TranslationService.GetTranslatedTextAsync(TranslationData)"/> with auto detect function
        /// </summary>
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


        /// <summary>
        /// Test the <see cref="TranslationService.GetTranslatedSentencesAsync(TranslationData)"/>
        /// </summary>
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


        /// <summary>
        /// Test the <see cref="TranslationService.GetTranslatedSentencesAsync(TranslationData)"/> with auto detect function
        /// </summary>
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
