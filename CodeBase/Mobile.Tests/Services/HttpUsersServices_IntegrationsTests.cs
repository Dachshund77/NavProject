using Backend;
using Commons.Domain;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Mobile.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Mobile.Tests.Services
{
    public class HttpUsersServices_IntegrationsTests
    {
        private readonly HttpUsersService httpUsersService;
        private readonly ITestOutputHelper output;
        private readonly TestServer server;
        private readonly HttpClient client;

        public HttpUsersServices_IntegrationsTests(ITestOutputHelper output)
        {
            this.httpUsersService = new HttpUsersService();
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
        public async void GetUser_DoesNotThrowException()
        {
            //Arrange
            User mockUSer = User.GetMockUsers().First();

            //Act
            var exception = await Record.ExceptionAsync(() =>
            httpUsersService.GetUser(mockUSer.UserName, client));

            //Assert
            output.WriteLine("Result: " + exception);
            Assert.Null(exception);
        }
    }
}
