using ExpendProject.BLL.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ExpendProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public static ActionResult<T> ToActionResult<T>(Result<T> result)
        {
            if (result.Succes)
                return new OkObjectResult(result.Value);
            return new BadRequestObjectResult(result.Error);
        }

        public static ActionResult<T> ToActionResult<T>(Result result)
        {
            if (result.Succes)
                return new OkResult();

            return new BadRequestObjectResult(result.Error);
        }


    }
}
