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
    public class HttpBasketsService_IntegrationTests
    {
        private readonly HttpBasketsService httpBasketsService;
        private readonly ITestOutputHelper output;
        private readonly TestServer server;
        private readonly HttpClient client;

        public HttpBasketsService_IntegrationTests(ITestOutputHelper output)
        {
            this.httpBasketsService = new HttpBasketsService();
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
        public async void ChangeProductCount_DoesNotThrowException()
        {
            //Arrange
            Basket mockBasket = Basket.GetMockBaskets().First();

            //Act
            var exception = await Record.ExceptionAsync(() =>
            httpBasketsService.ChangeProductCount(mockBasket,1,1,1, client));

            //Assert
            output.WriteLine("Result: " + exception);
            Assert.Null(exception);
        }

        [Fact]
        public async void DeleteBasket_DoesNotThrowException()
        {
            //Arrange          

            //Act
            var exception = await Record.ExceptionAsync(() =>
            httpBasketsService.DeleteBasket(1, client));

            //Assert
            output.WriteLine("Result: " + exception);
            Assert.Null(exception);
        }

        [Fact]
        public async void GetBasket_DoesNotThrowException()
        {
            //Arrange
            Basket mockBasket = Basket.GetMockBaskets().First();

            //Act
            var exception = await Record.ExceptionAsync(() =>
            httpBasketsService.GetBasket(mockBasket.ID, client));

            //Assert
            output.WriteLine("Result: " + exception);
            Assert.Null(exception);
        }

        [Fact]
        public async void GetBasketsOfUser_DoesNotThrowException()
        {
            //Arrange
            User mockUser = User.GetMockUsers().First();

            //Act
            var exception = await Record.ExceptionAsync(() =>
            httpBasketsService.GetBasketsOfUser(mockUser.UserName, client));

            //Assert
            output.WriteLine("Result: " + exception);
            Assert.Null(exception);
        }

        [Fact]
        public async void PostBasket_DoesNotThrowException()
        {
            //Arrange
            Basket mockBasket = Basket.GetMockBaskets().First();
            User mockUser = User.GetMockUsers().First();

            //Act
            var exception = await Record.ExceptionAsync(() =>
            httpBasketsService.PostBasket(mockBasket, mockUser.UserName, client));

            //Assert
            output.WriteLine("Result: " + exception);
            Assert.Null(exception);
        }

        [Fact]
        public async void PutBasket_DoesNotThrowException()
        {
            //Arrange
            Basket mockBasket = Basket.GetMockBaskets().First();
            User mockUser = User.GetMockUsers().First();

            //Act
            var exception = await Record.ExceptionAsync(() =>
            httpBasketsService.PutBasket(mockBasket, mockBasket.ID, client));

            //Assert
            output.WriteLine("Result: " + exception);
            Assert.Null(exception);
        }

        [Fact]
        public async void RemoveProductFromBasket_DoesNotThrowException()
        {
            //Arrange
            Basket mockBasket = Basket.GetMockBaskets().First();
            User mockUser = User.GetMockUsers().First();
            Product mockProduct = Product.GetMockProducts().First();

            //Act
            var exception = await Record.ExceptionAsync(() =>
            httpBasketsService.RemoveProductFromBasket(mockBasket, mockBasket.ID, mockProduct.Barcode, client));

            //Assert
            output.WriteLine("Result: " + exception);
            Assert.Null(exception);
        }
    }
}
