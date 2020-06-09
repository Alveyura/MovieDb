using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Models
{
    public class MovieEditViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Title required!")]
        [MaxLength(30, ErrorMessage = "Maximum 30 characters!")]
        public string Title { get; set; }

        [MaxLength(250, ErrorMessage = "Maximum 250 characters!")]
        public string Description { get; set; }

        [MaxLength(30, ErrorMessage = "Maximum 30 characters!")]
        public string Genre { get; set; }

        [Range(typeof(DateTime), "1/1/1900", "1/1/2070")]
        public DateTime ReleaseDate { get; set; }
    }
}
