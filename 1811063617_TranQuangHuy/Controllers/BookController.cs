using _1811063617_TranQuangHuy.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _1811063617_TranQuangHuy.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public string HelloTeacher(string university)
        {
            return "Hello Nguyen Dinh Anh - University " + university;
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("Html5 & CSS3 The complete Manual - Author Name Book 1");
            books.Add("Html5 & CSS Respomeive web Design cookbook - Author Name Book 2 ");
            books.Add("Professional ASP.net MVC5 - Author Book 2 ");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1,"Html5 & CSS3 The complete Manual "," Author Name Book 1", "/img/Course_Images_HTML_CSS.png"));
            books.Add(new Book(2,"Html5 & CSS Respomeive web Design cookbook "," Author Name Book 2 ", "/img/html-and-css-crash-course-2-638.jpg"));
            books.Add(new Book(3,"Professional ASP.net MVC5 "," Author Book 2 ", "/img/htmlcss.jpg"));
            return View(books);
        }

        [HttpPost,ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id,string Title,string Author,string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Html5 & CSS3 The complete Manual ", " Author Name Book 1", "/img/Course_Images_HTML_CSS.png"));
            books.Add(new Book(2, "Html5 & CSS Respomeive web Design cookbook ", " Author Name Book 2 ", "/img/html-and-css-crash-course-2-638.jpg"));
            books.Add(new Book(3, "Professional ASP.net MVC5 ", " Author Book 2 ", "/img/htmlcss.jpg"));            
            foreach (Book b in books)
            {
                if (b.Id==id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_cover = ImageCover;
                    break;
                }
            }
            
            return View("ListBookModel",books);

        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost,ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult Contact([Bind(Include ="Id ,Title,Author,ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Html5 & CSS3 The complete Manual ", " Author Name Book 1", "/img/Course_Images_HTML_CSS.png"));
            books.Add(new Book(2, "Html5 & CSS Respomeive web Design cookbook ", " Author Name Book 2 ", "/img/html-and-css-crash-course-2-638.jpg"));
            books.Add(new Book(3, "Professional ASP.net MVC5 ", " Author Book 2 ", "/img/htmlcss.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {

                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }
    }
}