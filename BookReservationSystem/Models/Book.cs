using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookReservationSystem.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        public string Identifier { get; set; }

        public DateTime ProductionDate { get; set; }

        public BookDefinition Definition { get; set; }

        public ApplicationUser Lender { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}