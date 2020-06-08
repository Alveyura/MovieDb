using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieWeb.Models
{
    public class MovieCreateViewModel
    {
        [DisplayName("Titel")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Titel verplicht!")]
        [MaxLength(30, ErrorMessage = "Maximum 30 karakters!")]
        public string Title { get; set; }
        [DisplayName("Omschrijving")]
        [MaxLength(250, ErrorMessage = "Maximum 250 karakters!")]
        public string Description { get; set; }
        [DisplayName("Genre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Genre verplicht!")]
        [MaxLength(30, ErrorMessage = "Maximum 30 karakters!")]
        public string Genre { get; set; }
        [DisplayName("Release Datum")]
        [DataType(DataType.DateTime)]
        public DateTime ReleaseDate { get; set; }
    }
}
