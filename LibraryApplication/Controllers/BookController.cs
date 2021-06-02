using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryApplication.Data.Model;
using LibraryApplication.Data.UnitOfWork;

namespace LibraryApplication.Controllers
{
    public class BookController : Controller
    {
        UnitOfWork _unitOfWork;

        public BookController()
        {
            _unitOfWork = new UnitOfWork();
        }

        public ActionResult Index()
        {
            var books = _unitOfWork.GetRepository<Book>().GetAll();
            return View(books);
        }

        public ActionResult AddBook()
        {
            ViewBag.Categories = _unitOfWork.GetRepository<Category>().GetAll();
            ViewBag.Writers = _unitOfWork.GetRepository<Writer>().GetAll();
            return View();
        }

        public JsonResult AddBookJson(string[] categories, string writer, string bookName, string bookQuantity, string orderNumber)
        {
            if (categories != null && !string.IsNullOrEmpty(writer) && !string.IsNullOrEmpty(bookName) && !string.IsNullOrEmpty(bookQuantity) && !string.IsNullOrEmpty(orderNumber))
            {



                List<Category> cats = new List<Category>();
                foreach (var categoryId in categories)
                {
                    var catId = Convert.ToInt32(categoryId);
                    var category = _unitOfWork.GetRepository<Category>().GetById(catId);
                    cats.Add(category);
                }

                Book book = new Book()
                {
                    BookName = bookName,
                    Categories = cats,
                    AddedDate = DateTime.Now,
                    InStock = Convert.ToInt32(bookQuantity),
                    OrderNumber = orderNumber,
                    WriterId = Convert.ToInt32(writer)
                };

                _unitOfWork.GetRepository<Book>().Add(book);
                var status = _unitOfWork.SaveChanges();
                if (status > 1) return Json('1');
                else return Json("0");
            }
            else
            {
                return Json("cannot be empty");
            }
        }

        [HttpPost]
        public JsonResult DeleteJson(int bookId)
        {
            _unitOfWork.GetRepository<Book>().Delete(bookId);
            var status = _unitOfWork.SaveChanges();
            return Json(status);
            //if (status <= 0) return Json("1");
            //else return Json(status);
        }

        public ActionResult Update(int bookId)
        {
            var book = _unitOfWork.GetRepository<Book>().GetById(bookId);
            ViewBag.Categories = _unitOfWork.GetRepository<Category>().GetAll();
            ViewBag.Writers = _unitOfWork.GetRepository<Writer>().GetAll();
            return View(book);
        }

        public JsonResult UpdateBookJson(int bookId, string[] categories, string writer, string bookName, string bookQuantity, string orderNumber)
        {
            if (categories != null && !string.IsNullOrEmpty(writer) && !string.IsNullOrEmpty(bookName) && !string.IsNullOrEmpty(bookQuantity) && !string.IsNullOrEmpty(orderNumber))
            {
                List<Category> cats = new List<Category>();
                foreach (var categoryId in categories)
                {
                    var catId = Convert.ToInt32(categoryId);
                    var category = _unitOfWork.GetRepository<Category>().GetById(catId);
                    cats.Add(category);
                }

                Book book = _unitOfWork.GetRepository<Book>().GetById(bookId);

                book.BookName = bookName;
                book.Categories.Clear();
                book.Categories = cats;
                book.InStock = Convert.ToInt32(bookQuantity);
                book.OrderNumber = orderNumber;
                book.WriterId = Convert.ToInt32(writer);

                _unitOfWork.GetRepository<Book>().Update(book);
                var status = _unitOfWork.SaveChanges();
                if (status > 1) return Json('1');
                else return Json("0");
            }
            else
            {
                return Json("cannot be empty");
            }
        }
    }
}