using DotNetCore.Objects;
using EFinancialPurchase.AspNet.Common.CommandResult;
using EFinancialPurchase.AspNet.Common.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persons.Application.Application;
using Persons.Application.Interface;
using Persons.Application.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Persons.Ui.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private readonly IAccountApplication _accountApp;

        public AccountController(IAccountApplication accountApp)
        {
            _accountApp = accountApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            try
            {
                AppResult<LoginViewModel> result = await _accountApp.Login(login);
                if (result.ValidationResult.IsValid)
                    return Ok(result);
                else
                    return Unauthorized(result.ValidationResult.Errors.FirstOrDefault().ErrorMessage);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}