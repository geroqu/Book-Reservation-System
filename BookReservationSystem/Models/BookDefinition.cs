using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookReservationSystem.Models
{
    public class BookDefinition
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int NoOfPages { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public virtual BookCategory Category { get; set; }
    }
}