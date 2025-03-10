using Biblioteca.Models;

namespace Biblioteca.ViewModels
{
    public class Book
    {
        public int Id { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string Genere { get; set; }
        public bool Disponibile { get; set; }
        public string CoperturaUrl { get; set; }
    }
}

// ViewModels/ProductsListViewModel.cs
namespace Biblioteca.ViewModels
{
    public class ProductsListViewModel
    {
        // Lista di libri (Book)
        public List<Book>? Products { get; set; }
    }
}
