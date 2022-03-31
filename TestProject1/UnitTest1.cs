using Xunit;
using BookStoreApi.Controllers;
using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Options;

namespace TestProject1
{
    public class UnitTest1
    {

        private BookStoreDatabaseSettings bookStoreDatabaseSettings = new BookStoreDatabaseSettings() {
            ConnectionString = "mongodb://localhost:27017",
            DatabaseName = "BookStore",
            BooksCollectionName = "Books"

        };
        private readonly Mock<BooksService> _repo;
        private readonly BooksController controller;

        public UnitTest1()
        {
            var options = new Mock<IOptions<BookStoreDatabaseSettings>>();
            options.Setup(o => o.Value).Returns(bookStoreDatabaseSettings);
             _repo = new Mock<BooksService>(options.Object);
            controller = new BooksController(_repo.Object);
        }
        [Fact]
        public async Task Test1Async()
        {
            //Arrange
            string id = "61e5051db5b01fb1d250e3b0";


            //Act

            var actionResult = await controller.Get(id);
            //Assert

            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]

        public async void Test2()
        {
            //Arrange
            string id = "61dd4e610b898dff5f96e104";

            //Act
            var actionResult = await controller.Get(id);

            //Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

    }
}

