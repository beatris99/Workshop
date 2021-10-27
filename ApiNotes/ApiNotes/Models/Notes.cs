using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiNotes.Models
{
    public class Notes
    {
        public Guid Id { get; set; }
        public Guid OwnerId { get; set; } //pt a vedea cine are acces la baza de date
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
    }
}
