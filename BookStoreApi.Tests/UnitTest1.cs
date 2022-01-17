using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http.Results;
using BookStoreApi.Controllers;
using BookStoreApi.Models;
namespace BookStoreApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testBooks = GetTestBooks();
            var controller = new BooksController(testBooks);

            var result = controller.GetAllBooks() as List<Book>;
            Assert.AreEqual(testBooks.Count, result.Count);
        }
    }
}
