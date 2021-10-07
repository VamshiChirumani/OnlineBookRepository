using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using OnlineBookStore.Controllers;
using OnlineBookStore.Models;
using OnlineBookStore.Repositories;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace OnlineBookStoreTest
{
    [TestClass]
    public class BooksControllerTest
    {
        List<Book> books;
        List<Book> empty =new List<Book> { };
        [TestInitialize]
        public void SetUp()
        {
            books = new List<Book>
            {
                new Book
                {
                    BookId=1,
                    BookName="Book1",
                    Author="Author1",
                    Cost=10,
                    Rating=4

                },
                new Book
                {
                    BookId=2,
                    BookName="Book2",
                    Author="Author2",
                    Cost=20,
                    Rating=3

                },
                new Book
                {
                    BookId=3,
                    BookName="Book3",
                    Author="Author3",
                    Cost=30,
                    Rating=2

                },
                new Book
                {
                    BookId=4,
                    BookName="Book4",
                    Author="Author4",
                    Cost=40,
                    Rating=2

                }
            };

        }
        [TestMethod]
        public void GetBooks_RetrunsOk()
        {
            var mock = new Mock<IBookRepository>();
            mock.Setup(x => x.GetAllBooks()).Returns(books);
            BooksController controller = new BooksController(mock.Object);
            var res = controller.GetBooks();
            var result = res as OkObjectResult;
            Assert.IsNotNull(res);
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public void GetBooks_RetrunsBadRequest()
        {
            var mock = new Mock<IBookRepository>();
            mock.Setup(x => x.GetAllBooks()).Returns(empty);
            BooksController controller = new BooksController(mock.Object);
            var res = controller.GetBooks();
            var result = res as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public void GetBookById_ReturnsOk()
        {
            int id = 1;
            var mock = new Mock<IBookRepository>();
            mock.Setup(x => x.GetBookByID(id)).Returns(books.Where(x=>x.BookId==id).FirstOrDefault());
            BooksController controller = new BooksController(mock.Object);
            var res = controller.GetBookById(id);
            var result = res as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public void GetBookById_ReturnsBadRequest()
        {
            int id = 25;
            var mock = new Mock<IBookRepository>();
            mock.Setup(x => x.GetBookByID(id)).Returns(books.Where(x => x.BookId == id).FirstOrDefault());
            BooksController controller = new BooksController(mock.Object);
            var res = controller.GetBookById(id);
            var result = res as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public void PostBook_ReturnsOk()
        {
            Book book = new Book
            {
                BookName = "Book6",
                Author = "Author 6",
                Rating = 3,
                Cost = 25
            };
            var mock = new Mock<IBookRepository>();
            BooksController controller = new BooksController(mock.Object);
            var res = controller.PostBook(book);
            var result = res as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public void PostBook_ReturnsBadRequest()
        {
            Book book = new Book
            {
                BookName = "",
                Author = "Author 6",
                Rating = 3,
                Cost = 25
            };
            var mock = new Mock<IBookRepository>();
            BooksController controller = new BooksController(mock.Object);
            var res = controller.PostBook(book);
            var result = res as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }
        [TestMethod]
        public void UpdateBook_ReturnsOk()
        {
            Book book = new Book
            {
                BookName = "Book6",
                Author = "Author 6",
                Rating = 3,
                Cost = 25
            };
            var mock = new Mock<IBookRepository>();
            BooksController controller = new BooksController(mock.Object);
            var res = controller.UpdateBook(book);
            var result = res as ObjectResult;
            Assert.AreEqual(200, result.StatusCode);
        }
        [TestMethod]
        public void UpdateBook_ReturnsbadRequest()
        {
            Book book = new Book
            {
                BookName = "Book6",
                Author = "Author 6",
                Rating = 8,
                Cost = 25
            };
            var mock = new Mock<IBookRepository>();
            BooksController controller = new BooksController(mock.Object);
            var res = controller.UpdateBook(book);
            var result = res as ObjectResult;
            Assert.AreEqual(400, result.StatusCode);
        }

    }
}
