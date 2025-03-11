using System.ComponentModel.DataAnnotations;

namespace Biblioteca.ViewModels
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(20)]
        public required string Titolo { get; set; }

        [Required]
        [StringLength(2000, MinimumLength = 10)]
        public required string Autore { get; set; }

        [Required]
        [Range(1, 5000)]
        public String Genere { get; set; }

        [Required]
        public required bool Disponibile { get; set; }

        [Required]
        public string CoperturaUrl { get; set; }
    }
}
