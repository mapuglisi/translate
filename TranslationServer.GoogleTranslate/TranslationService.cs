using GoogleTranslateFreeApi;
using System.Threading.Tasks;
using Translation.Common;

namespace TranslationServer.GoogleTranslate
{
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

        public static async Task<TranslationData> GetTranslatedTextAsync(TranslationData translation)
        {
            TranslationResult result = await TranslateTextAsync(translation.OriginalText, translation.sourceLanguage.ToString(), translation.targetLanguage.ToString());

            translation.TranslatedText = result.MergedTranslation;

            return translation;
        }


        public static async Task<TranslationData> GetTranslatedSentencesAsync(TranslationData translation)
        {
            TranslationResult result = await TranslateTextAsync(translation.OriginalText, translation.sourceLanguage.ToString(), translation.targetLanguage.ToString());

            translation.TranslatedSentences = result.FragmentedTranslation;

            return translation;
        }
    }
}
