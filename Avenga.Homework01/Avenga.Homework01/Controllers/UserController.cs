using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Avenga.Homework01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<string>> Get() 
        { 
            return Ok(StaticDb.Users);
        }

        [HttpGet("{id}")]
        public ActionResult<string> GetById(int id) 
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest,
                        "The id has negative value");
                }
                if (id > StaticDb.Users.Count())
                {
                    return StatusCode(StatusCodes.Status404NotFound,
                        $"There is no resource on index {id}");
                }

                return StatusCode(StatusCodes.Status200OK, StaticDb.Users[id]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    $"An error occurred. Contact the admin {e.Message}");
            }
        }
    }
}
