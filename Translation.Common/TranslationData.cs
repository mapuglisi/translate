using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Translation.Common
{
    /// <summary>
    /// A simple class containing the necessary parameters to perform a translation
    /// </summary>
    public class TranslationData
    {
        /// <summary>
        /// The language the original text is is
        /// </summary>
        [Required]
        public Language? sourceLanguage { get; set; }

        /// <summary>
        /// The desired language for the translation
        /// </summary>
        [Required]
        public Language targetLanguage { get; set; }

        /// <summary>
        /// The original text
        /// </summary>
        [Required]
        public string OriginalText { get; set; }

        /// <summary>
        /// The translated text
        /// </summary>
        public string TranslatedText { get; set; }

        /// <summary>
        /// The translated text as sentences
        /// </summary>
        public IEnumerable<string> TranslatedSentences { get; set; }
    }
}
