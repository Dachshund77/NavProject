using Commons.Domain;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Backend;
using System.Net.Http;
using Xunit.Abstractions;
using System.Linq;

namespace Mobile.Tests.Services
{
    public class HttpAuthService_IntegrationTests
    {
        private readonly HttpAuthService httpAuthService;
        private readonly ITestOutputHelper output;
        private readonly TestServer server;
        private readonly HttpClient client;

        public HttpAuthService_IntegrationTests(ITestOutputHelper output)
        {
            this.httpAuthService = new HttpAuthService();
            this.output = output;
            this.server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>()
                 .UseConfiguration(new ConfigurationBuilder()
                 //.AddJsonFile("appsettings_server1.json")
                 .Build())
                 );
            this.client = server.CreateClient();
        }


        [Fact]
        public async void LogIn_DoesNotThrowException()
        {
            //Arrange
            User mockUser = User.GetMockUsers().First();
            string result = null;

            //Act
            var exception = await Record.ExceptionAsync(async () =>
            result = await httpAuthService.LogIn(mockUser, client));

            //Assert
            output.WriteLine("Result: " + result);
            output.WriteLine("Exception: " + exception);
            Assert.Null(exception);
        }

        [Fact]
        public async void LogOut_DoesNotThrowException()
        {
            //Arrange
            User mockUser = User.GetMockUsers().First();
            bool? result = null;

            //Act
            var exception = await Record.ExceptionAsync(async () =>
            result = await httpAuthService.LogOut(mockUser, client));

            //Assert
            output.WriteLine("Result: " + result);
            output.WriteLine("Exception: " + exception);
            Assert.Null(exception);
        }

        [Fact]
        public async void Register_DoesNotThrowException()
        {
            //Arrange
            User mockUser = User.GetMockUsers().First();
            bool? result = null;

            //Act
            var exception = await Record.ExceptionAsync( async () =>
            result = await httpAuthService.Register(mockUser, client));

            //Assert
            output.WriteLine("Result: " + result);
            output.WriteLine("Exception: " + exception);
            Assert.Null(exception);
        }

    }
}
