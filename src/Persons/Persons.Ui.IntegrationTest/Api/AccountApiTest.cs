using Xunit;
using Persons.Ui.WebApi;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using System.Net.Http;
using System.Threading.Tasks;
using Persons.Application.ViewModels;
using Persons.Ui.WebApi.Controllers;
using Persons.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Persons.CrossCutting.IoC;
using Persons.Application.Application;
using Persons.Domain.Services;
using Persons.Infra.Data.Repositories;
using Persons.Infra.Data.Context;
using Persons.Infra.Data.UoW;
using AutoMapper;
using Persons.Application.AutoMapper;
using Persons.CrossCutting.Security.Hash;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Persons.Ui.IntegrationTest.Api
{
    public class AccountApiTest
    {
        private readonly HttpClient _client;
        private readonly IAccountApplication _accountApp;


        public AccountApiTest()
        {

            var mappingConfig = AutoMapperConfig.RegisterMappings();
            IMapper mapper = mappingConfig.CreateMapper();
            var db = new DbContextOptions<ApplicationDbContext>();
            var context = new ApplicationDbContext(db);

            var uoW= new UnitOfWork(context);
            var accountService = new AccountService(uoW);
            var accountApp = new AccountApplication(accountService, mapper, new Hash());
            _accountApp = accountApp;
        }

        [Fact]
        public async Task LoginTestAsync()
        {           
            //Arrange
            var controller = new AccountController(_accountApp);
            var model = new LoginViewModel
            { 
               Login = "luksgabe",
               Password = "dasdasdaddaas",
               Remember = true
            };

            //Act
            var response = await controller.Login(model);

            //Assert
            Assert.IsType<OkObjectResult>(response);
        }
    }
}
