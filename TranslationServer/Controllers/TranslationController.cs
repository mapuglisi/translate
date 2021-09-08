using Microsoft.AspNetCore.Mvc;
using Translation.Common;
using TranslationServer.GoogleTranslate;

namespace TranslationServer.Controllers
{

    [ApiController]
    [Route("api/[controller]")] //    /api/Translation 
    public class TranslationController : Controller
    {
      
        [HttpPost]
        [Route("TranslateSentences")]
        public IActionResult TranslateSentences(TranslationData translationData)
        {
            var translation = TranslationService.GetTranslatedSentencesAsync(translationData).Result;
            
            return Ok(translation);
        }

        [HttpPost]
        [Route("TranslateText")]
        public IActionResult TranslateText(TranslationData translationData)
        {
            var translation = TranslationService.GetTranslatedTextAsync(translationData).Result;

            return Ok(translation);
        }
    }
}
