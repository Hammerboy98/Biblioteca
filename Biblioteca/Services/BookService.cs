using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Services
{
    public class BookService
    {
        private readonly BibliotecaContext _context;

        public BookService(BibliotecaContext context)
        {
            _context = context;
        }

        private async Task<bool> SaveAsync()
        {
            try
            {
                var rowsAffected = await _context.SaveChangesAsync();
                return rowsAffected > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<ViewModels.BooksListViewModel> GetAllBooksAsync()
        {
            try
            {
                var booksList = new ViewModels.BooksListViewModel();

                // Ottieni i libri dal contesto
                var books = await _context.Books.ToListAsync();

                // Mappa i libri dal modello alla ViewModel
                booksList.Books = books.Select(b => new Book
                {
                    Id = b.Id,
                    Titolo = b.Titolo,
                    Autore = b.Autore,
                    Genere = b.Genere,
                    Disponibile = b.Disponibile,
                    CoperturaUrl = b.CoperturaUrl
                }).ToList();

                return booksList;
            }
            catch
            {
                // Gestisci l'errore restituendo una lista vuota in caso di errore
                return new ViewModels.BooksListViewModel() { Books = new List<Book>() };
            }
        }

        public async Task<bool> AddBookAsync(AddBookViewModel addBookViewModel)
        {
            // Valida il ViewModel
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(addBookViewModel);
            bool isValid = Validator.TryValidateObject(addBookViewModel, validationContext, validationResults, true);

            if (!isValid)
            {
                // Se la validazione fallisce, puoi restituire false o gestire l'errore come preferisci
                return false;
            }

            try
            {
                var book = new Book()
                {
                    Titolo = addBookViewModel.Titolo,
                    Autore = addBookViewModel.Autore,
                    CoperturaUrl = addBookViewModel.CoperturaUrl,
                    Genere = addBookViewModel.Genere
                };

                _context.Books.Add(book);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<BookDetailsViewModel?> GetBookDetailsByIdAsync(Guid id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);

                if (book == null)
                {
                    return null;
                }

                // Mappa i dettagli del libro nel BookDetailsViewModel
                var bookDetails = new BookDetailsViewModel
                {
                    Id = book.Id,
                    Titolo = book.Titolo,
                    Autore = book.Autore,
                    CoperturaUrl = book.CoperturaUrl,
                    Genere = book.Genere
                };

                return bookDetails;
            }
            catch
            {
                return null;
            }
        }

        public async Task<bool> DeleteBookByIdAsync(int id)
        {
            try
            {
                var book = await _context.Books.FindAsync(id);

                if (book == null)
                {
                    return false;
                }

                _context.Books.Remove(book);
                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateBookAsync(EditBookViewModel editBookViewModel)
        {
            try
            {
                var book = await _context.Books.FindAsync(editBookViewModel.Id);

                if (book == null)
                {
                    return false;
                }

                // Aggiorna le proprietà del libro con i nuovi dati
                book.Titolo = editBookViewModel.Titolo;
                book.Autore = editBookViewModel.Autore;
                book.CoperturaUrl = editBookViewModel.CoperturaUrl;
                book.Genere = editBookViewModel.Genere;

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}