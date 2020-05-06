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
    public class HttpTransactionsService_IntegrationTests
    {
        private readonly HttpTransactionsService httpTransactionsService;
        private readonly ITestOutputHelper output;
        private readonly TestServer server;
        private readonly HttpClient client;

        public HttpTransactionsService_IntegrationTests(ITestOutputHelper output)
        {
            this.httpTransactionsService = new HttpTransactionsService();
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
        public async void GetTransaction_DoesNotThrowException()
        {
            //Arrange
            Transaction mockTransaction = Transaction.GetMockTransactions().First();

            //Act
            var exception = await Record.ExceptionAsync(() =>
            httpTransactionsService.GetTransaction(mockTransaction.ID, client));

            //Assert
            output.WriteLine("Result: " + exception);
            Assert.Null(exception);
        }

        [Fact]
        public async void GetTransactionsOfBasket_DoesNotThrowException()
        {
            //Arrange
            Basket mockBasket = Basket.GetMockBaskets().First();

            //Act
            var exception = await Record.ExceptionAsync(() =>
            httpTransactionsService.GetTransactionsOfBasket(mockBasket.ID, client));

            //Assert
            output.WriteLine("Result: " + exception);
            Assert.Null(exception);
        }

        [Fact]
        public async void GetTransactionsOfUser_DoesNotThrowException()
        {
            //Arrange
            User mockUser = User.GetMockUsers().First();

            //Act
            var exception = await Record.ExceptionAsync(() =>
            httpTransactionsService.GetTransactionsOfUser(mockUser.UserName, client));

            //Assert
            output.WriteLine("Result: " + exception);
            Assert.Null(exception);
        }
    }
}
