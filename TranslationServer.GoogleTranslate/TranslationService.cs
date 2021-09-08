using GoogleTranslateFreeApi;
using System.Threading.Tasks;
using Translation.Common;

namespace TranslationServer.GoogleTranslate
{
    /// <summary>
    /// The translation service
    /// </summary>
    public static class TranslationService
    {
        private static async Task<TranslationResult> TranslateTextAsync(string text, string languageFrom, string languageTo)
        {
            var translator = new GoogleTranslator();
            var from = !string.IsNullOrEmpty(languageFrom)
                            ? GoogleTranslator.GetLanguageByName(languageFrom)
                            : GoogleTranslateFreeApi.Language.Auto;
            var to = GoogleTranslator.GetLanguageByName(languageTo);

            var result = await translator.TranslateLiteAsync(text, from, to);
            return result;
        }

        /// <summary>
        /// Translates a given text to the desired language
        /// </summary>
        /// <param name="translation">The translation data</param>
        /// <returns>A <see cref="TranslationData"/> containing the translation in the <see cref="TranslationData.TranslatedText"/></returns>
        public static async Task<TranslationData> GetTranslatedTextAsync(TranslationData translation)
        {
            TranslationResult result = await TranslateTextAsync(translation.OriginalText, translation.sourceLanguage.ToString(), translation.targetLanguage.ToString());

            translation.TranslatedText = result.MergedTranslation;

            return translation;
        }

        /// <summary>
        /// Translates a given text to the desired language as sentences
        /// </summary>
        /// <param name="translation">The translation data</param>
        /// <returns>A <see cref="TranslationData"/> containing the translation in the <see cref="TranslationData.TranslatedSentences"/></returns>
        public static async Task<TranslationData> GetTranslatedSentencesAsync(TranslationData translation)
        {
            TranslationResult result = await TranslateTextAsync(translation.OriginalText, translation.sourceLanguage.ToString(), translation.targetLanguage.ToString());

            translation.TranslatedSentences = result.FragmentedTranslation;

            return translation;
        }
    }
}
