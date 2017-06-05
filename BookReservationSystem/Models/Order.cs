using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookReservationSystem.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public bool Completed { get; set; }

        public DateTime TimeOfOrder { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}