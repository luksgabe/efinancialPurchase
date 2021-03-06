﻿using EFinancialPurchase.AspNet.Common.CommandResult;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Persons.Application.ViewModels;
using Persons.CrossCutting.WebApiServices;
using System;
using System.Threading.Tasks;
using EFinancialPurchase.AspNet.Common.Utils;

namespace Persons.Ui.Controllers
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

        public async Task<IActionResult> Login()
        {
            //await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
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
                var command = await _webApi.PostAsync<AppResult<LoginViewModel>>(_urlRedirect, login);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message.SpliteHttpCode().Trim());
                return View(login);
            }
        }

        public async Task<IActionResult> SignOut()
        {
            return RedirectToAction("Login");
        }
    }
}