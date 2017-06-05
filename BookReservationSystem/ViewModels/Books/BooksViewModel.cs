using BookReservationSystem.ViewModels.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookReservationSystem.ViewModels.Books
{
    public class BooksViewModel
    {
        public IEnumerable<BookListItemViewModel> Books { get; set; }

        public int BooksAvailable { get; set; }
    }
}