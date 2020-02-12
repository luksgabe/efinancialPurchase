using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Persons.Application.Interface;

namespace Persons.Ui.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {

        private readonly IUserApplication _userApplication;

        public UserController(IUserApplication userApplication)
        {
            _userApplication = userApplication;
        }


        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await _userApplication.GetAll().ConfigureAwait(true);
                return Ok(list);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/User/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/User
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/User/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
