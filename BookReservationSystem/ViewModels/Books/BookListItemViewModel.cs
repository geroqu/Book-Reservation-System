using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReservationSystem.ViewModels.Books
{
    public class BookListItemViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public BookCategoryEnum Category { get; set; }
        public int PagesNo { get; set; }
    }
}