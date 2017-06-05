using BookReservationSystem.Models;
using BookReservationSystem.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReservationSystem.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        public BookController()
        {

        }

        [HttpGet]
        public ActionResult Index()
        {

            var viewModel = new BooksViewModel();

            using (var dbContext = ApplicationDbContext.Create())
            {
                var bookDefinitions = dbContext.BookDefinitions.ToList();

                viewModel.BooksAvailable = bookDefinitions.Count;

                var books = new List<BookListItemViewModel>();

                foreach (var book in bookDefinitions)
                {
                    books.Add(new BookListItemViewModel()
                    {
                        Id = book.Id,
                        Title = book.Title,
                        Author = book.Author,
                        Category = (BookCategoryEnum)book.Category.Id,
                        PagesNo = book.NoOfPages
                    });
                }

                viewModel.Books = books;
            }    

            return View(viewModel);
        }

        [HttpGet]
        [ActionName("Add")]
        public ActionResult GetAddBookView()
        {
            var viewModel = new AddBookViewModel()
            {
                Categories = new List<SelectListItem>()
                {
                    new SelectListItem() { Text = BookCategoryEnum.Comedy.ToString(), Value = ((int)BookCategoryEnum.Comedy).ToString() },
                    new SelectListItem() { Text = BookCategoryEnum.Criminal.ToString(), Value = ((int)BookCategoryEnum.Criminal).ToString() },
                    new SelectListItem() { Text = BookCategoryEnum.SciFi.ToString(), Value = ((int)BookCategoryEnum.SciFi).ToString() }
                }
            };

            return View("Create", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Add")]
        public ActionResult AddBookDefinition(AddBookViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                using(var dbContext = ApplicationDbContext.Create())
                {
                    dbContext.BookDefinitions.Add(new BookDefinition()
                    {
                        Id = Guid.NewGuid(),
                        Title = viewModel.Title,
                        Author = viewModel.Author,
                        Description = viewModel.Description,
                        CategoryId = viewModel.SelectedCategory,
                        NoOfPages = viewModel.PagetNo
                    });

                    dbContext.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else return View("Create", viewModel);
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteBook(Guid id)
        {
            using (var dbContext = ApplicationDbContext.Create())
            {
                var bookDef = dbContext.BookDefinitions.FirstOrDefault(t => t.Id == id);

                if (bookDef == null) return HttpNotFound("Book does not exist");

                dbContext.BookDefinitions.Remove(bookDef);

                dbContext.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}