using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Translation.Common;
using TranslationServer.GoogleTranslate;

namespace TranslationServer.Controllers
{

    /// <summary>
    /// The translation controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TranslationController : Controller
    {
        
        /// <summary>
        /// Obtains the translation of the sent text as sentences
        /// </summary>
        /// <param name="translationData">An object encapsulating the data needed to perform a translation</param>
        /// <returns>A <see cref="TranslationData"/> containing the translated text as sentences</returns>
        /// <response code="200">Returns the <see cref="TranslationData"/></response>
        [HttpPost]
        [Route("TranslateSentences")]
        [ProducesResponseType(typeof(TranslationData), StatusCodes.Status200OK)]
        public IActionResult TranslateSentences(TranslationData translationData)
        {
            var translation = TranslationService.GetTranslatedSentencesAsync(translationData).Result;

            //  TODO: Add language verification
            //  Return 400 when source language doesn't match the provided text language?
            
            return Ok(translation);
        }

        /// <summary>
        /// Obtains the translation of the sent text
        /// </summary>
        /// <param name="translationData">An object encapsulating the data needed to perform a translation</param>
        /// <returns>A <see cref="TranslationData"/> containing the translated text</returns>
        /// <response code="200">Returns the <see cref="TranslationData"/></response>
        [HttpPost]
        [Route("TranslateText")]
        [ProducesResponseType(typeof(TranslationData), StatusCodes.Status200OK)]
        public IActionResult TranslateText(TranslationData translationData)
        {
            var translation = TranslationService.GetTranslatedTextAsync(translationData).Result;

            //  TODO: Add language verification
            //  Return 400 when source language doesn't match the provided text language?

            return Ok(translation);
        }
    }
}
