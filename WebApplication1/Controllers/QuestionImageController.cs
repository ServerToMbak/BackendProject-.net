using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionImageController : ControllerBase
    {
        IQuestionImageSevice _questionImageSevice;
        public QuestionImageController(IQuestionImageSevice questionImageSevice)
        {
                _questionImageSevice = questionImageSevice;
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] IFormFile file, [FromForm] QuestionImage questionImage)
        {
            var result = _questionImageSevice.Add(file, questionImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(QuestionImage questionImage)
        {
            var carDeleteImage = _questionImageSevice.GetByImageId(questionImage.Id).Data;
            var result = _questionImageSevice.Delete(carDeleteImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] IFormFile file, [FromForm] QuestionImage questionImage)
        {
            var result = _questionImageSevice.Update(file, questionImage);
            if (result.Success)
            {
                return Ok();
            }
            return BadRequest();
    
        }
    }
}
