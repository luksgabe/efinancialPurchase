using Microsoft.AspNetCore.Mvc;
using Persons.Domain.Interfaces;

namespace Persons.Ui.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }

    }
}