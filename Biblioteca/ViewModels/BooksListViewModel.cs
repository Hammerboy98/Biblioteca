using Biblioteca.Models;

namespace Biblioteca.ViewModels
{
    public class BooksListViewModel
    {
        public List<Book>? Books { get; set; }
        public int Id { get; internal set; }
        public string Titolo { get; internal set; }
        public string Autore { get; internal set; }
        public string Genere { get; internal set; }
        public string CoperturaUrl { get; internal set; }

        public bool Disponibile { get; internal set; }
    }
}
