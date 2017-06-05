using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookReservationSystem.ViewModels.Books
{
    public class AddBookViewModel
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        public int SelectedCategory { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; }

        public int PagetNo { get; set; }
    }
}