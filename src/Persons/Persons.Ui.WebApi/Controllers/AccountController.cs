using EFinancialPurchase.AspNet.Common.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persons.Application.Application;
using Persons.Application.Interface;
using Persons.Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace Persons.Ui.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : BaseController
    {
        //private readonly IAccountApplication _accountApp;

        public AccountController()
        {
            //_accountApp = accountApp;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel login)
        {
            try
            {
                //string token = await _accountApp.Login(login);
                string token = "fjasnfasndasdsadd";
                var account = new AccountDTO { Login = login.Username, Password = login.Password, Token = token };
                return Ok(account);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}