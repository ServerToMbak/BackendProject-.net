using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        ICommentServcie _commentServcie;
        public CommentController(ICommentServcie commentServcie)
        {
            _commentServcie = commentServcie;
        }
        [HttpPost("Add")]
        public IActionResult Add(Comment comemnt)
        {
            var result = _commentServcie.Add(comemnt);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var result = _commentServcie.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Delete")]
        public IActionResult Delete(Comment comemnt)
        {
            var result = _commentServcie.Delete(comemnt);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyCommentıd")]
        public IActionResult GetByCommentId(int Id)
        {
            var result = _commentServcie.GetByCommentId(Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpPost("Update")]
        public IActionResult Update(Comment comemnt)
        {
            var result = _commentServcie.Update(comemnt);
            if (result.Success)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}
