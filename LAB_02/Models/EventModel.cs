using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LAB_02.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        [StringLength(30,MinimumLength =5,ErrorMessage ="Insert a string with lenght between 5 and 30")]
        public string Lokacija { get; set; }
    }
}