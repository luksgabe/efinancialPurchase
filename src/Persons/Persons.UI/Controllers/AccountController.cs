using EFinancialPurchase.AspNet.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Persons.Application.ViewModels;
using Persons.CrossCutting.WebApiServices;
using System;
using System.Threading.Tasks;

namespace Persons.UI.Controllers
{
    public class AccountController : BaseController
    {
        public AccountController(IWebApiService webApi, IConfiguration configuration) : base(webApi, configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registrar(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
                return View(register);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel login)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View(login);

                _urlRedirect = "api/Account/Login";
                var result = await _webApi.PostAsync<AccountDTO>(_urlRedirect, login);

                if (!string.IsNullOrEmpty(result.Token))
                    return RedirectToAction("Index", "Home");
                else
                    return View(login);
            }
            catch (Exception ex)
            {                     
                return View(login);
            }
        }
    }
}