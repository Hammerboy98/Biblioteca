namespace Biblioteca.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string Genere { get; set; }
        public bool Disponibile { get; set; }
        public string CoperturaUrl { get; set; }
    }
}
