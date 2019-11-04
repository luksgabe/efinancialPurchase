using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Persons.CrossCutting.WebApiServices;

namespace Persons.UI.Controllers
{
    public class UsuarioController : BaseController
    {
        public UsuarioController(IWebApiService webApiService, IConfiguration configuration) : base(webApiService, configuration)
        {
            _configuration = configuration;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}