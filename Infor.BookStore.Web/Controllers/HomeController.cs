using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Infor.BookStore.Business.Services;
using Infor.BookStore.Connectors.Format;
using Infor.BookStore.Data;
using Infor.BookStore.Data.Models;
using Infor.BookStore.Data.Repositories;

namespace Infor.BookStore.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookService bookService;
        private readonly IUnitOfWork uow;

        public HomeController()
        {
            // Later on, we can use DI tools like Autofac to do the initialisation
            var dbContext = new BSContext();
            bookService = new BookService(new BookRepository(dbContext));
            uow = new UnitOfWork(dbContext);
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Select a file to import";
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult ImportA(HttpPostedFileBase file)
        {
            return Import(file, BookFormatFactory.Abraham);
        }

        [HttpPost]
        public ActionResult ImportB(HttpPostedFileBase file)
        {
            return Import(file, BookFormatFactory.Barack);
        }

        private ActionResult Import(HttpPostedFileBase file, BookFormat format)
        {
            string message;

            if (file.ContentLength <= 0)
            {
                message = "Invalid file";
            }

            IList<Book> books = new List<Book>();

            try
            {
                books = bookService.Import(file.InputStream, BookFormatFactory.Abraham);
            }
            catch (Exception ex)
            {
                //TODO: Wrap business exception with more meaningful error
                ViewBag.Message = "Error while importing: " + ex.Message;
            }

            foreach (var book in books)
            {
                bookService.Create(-1, book);
            }

            message = "Import Succesful";

            uow.Commit();

            ViewBag.Message = message;

            return View("Index");
        }
    }
}