using ExtendsApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ExtendsApi.CommunicationLayer
{
    public abstract class ResponseController : ControllerBase
    {
        protected IActionResult ReturnApiErrors<TModel>(Response<TModel> responseObject)
        {
            if (responseObject.Errors.ToList().Any(x => x.Type.Equals(ErrorType.BusinessLogicError)))
            {
                return Conflict(responseObject.Errors.Select(x => x.Message).ToList());
            }
            else if (responseObject.Errors.ToList().Any(x => x.Type.Equals(ErrorType.Exception)))
            {
                return StatusCode(503, responseObject.Errors.Select(x => x.Message).ToList());
            }
            else if (responseObject.Errors.ToList().Any(x => x.Type.Equals(ErrorType.NotFound)))
            {
                return NotFound(responseObject.Errors.Select(x => x.Message).ToList());
            }
            else if (responseObject.Errors.ToList().Any(x => x.Type.Equals(ErrorType.ValidationError)))
            {
                return BadRequest(responseObject.Errors.Select(x => x.Message).ToList());
            }
            else
            {
                return StatusCode(500, responseObject.Errors);
            }
        }
    }
}
