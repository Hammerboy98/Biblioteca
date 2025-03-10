using Biblioteca.ViewModels;
using Biblioteca.Models;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Services
{
    public class BookService
    {
        private readonly BibliotecaContext _context;

        public BookService(BibliotecaContext context)
        {
            _context = context;
        }

        public async Task<ProductsListViewModel> GetAllBooksAsync()
        {
            try
            {
                var booksList = new ProductsListViewModel();

                // Ottieni i libri dal contesto
                var libri = await _context.Libri.ToListAsync();

                // Mappa i libri dal modello alla ViewModel
                booksList.Products = libri.Select(l => new Book
                {
                    Id = l.Id,
                    Titolo = l.Titolo,
                    Autore = l.Autore,
                    Genere = l.Genere,
                    Disponibile = l.Disponibile,
                    CoperturaUrl = l.CoperturaUrl
                }).ToList();

                return booksList;
            }
            catch
            {
                return new ProductsListViewModel() { Products = new List<Book>() };
            }
        }
    }
}
