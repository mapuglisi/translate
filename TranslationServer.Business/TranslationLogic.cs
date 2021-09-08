using System;
using System.Threading.Tasks;
using Google.Cloud.Translate.V3;

namespace TranslationServer.Business
{
    public static class TranslationLogic
    {
        public static async Task<string> TranslateAsync(string text, string from, string to)
        {
            var translator = new TranslateTextRequest();

            var languageFrom = !string.IsNullOrWhiteSpace(from)
                                        ? .GetLanguageByName(from)
                                        : Language.Auto;
            var languageTo = GoogleTranslator.GetLanguageByName(to);

            var result = await translator.TranslateAsync(text, languageFrom, languageTo );

            return result.MergedTranslation;
        }
    }
}
