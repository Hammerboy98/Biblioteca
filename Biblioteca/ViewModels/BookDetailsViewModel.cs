namespace Biblioteca.ViewModels
{
    public class BookDetailsViewModel
    {
        public int Id { get; set; }
        public string? Titolo { get; set; }

        public string? Autore { get; set; }

        public string Genere { get; set; }

        public string? CoperturaUrl { get; set; }
        public bool Disponibile { get; set; }
    }
}
