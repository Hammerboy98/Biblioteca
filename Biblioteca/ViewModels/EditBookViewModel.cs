namespace Biblioteca.ViewModels
{
    public class EditBookViewModel
    {
        public required int Id { get; set; }

        public required string Titolo { get; set; }

        public required string Autore { get; set; }

        public required string CoperturaUrl { get; set; }

        public required string Genere { get; set; }

        public bool Disponibile { get; set; }
    }
}
