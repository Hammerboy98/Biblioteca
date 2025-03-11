using Microsoft.AspNetCore.Mvc;
using Biblioteca.Services;
using Biblioteca.ViewModels;

namespace Biblioteca.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        // Correzione: Il nome del parametro nel costruttore deve corrispondere al campo privato
        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var booksList = await _bookService.GetAllBooksAsync();

            return View(booksList);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel addBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Error while saving entity to database";
                return RedirectToAction("Index");
            }

            // Correzione: passare l'oggetto addBookViewModel al metodo del servizio
            var result = await _bookService.AddBookAsync(addBookViewModel);

            if (!result)
            {
                TempData["Error"] = "Error while saving entity to database";
            }

            return RedirectToAction("Index");
        }

        [Route("book/details/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookService.GetAllBooksAsync();

            if (book == null)
            {
                TempData["Error"] = "Error while finding entity on database";
                return RedirectToAction("Index");
            }

            // Correzione: Mappatura dei dettagli corretti
            var bookDetailsViewModel = new BookDetailsViewModel()
            {
                Id = book.Id,
                Titolo = book.Titolo,  // Usa Titolo al posto di Name
                Autore = book.Autore, // Usa Descrizione al posto di Description
                Genere = book.Genere, // Usa Prezzo al posto di Price
                CoperturaUrl = book.CoperturaUrl // Usa Genere al posto di Category
            };

            return View(bookDetailsViewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var result = await _bookService.DeleteBookByIdAsync(id);

            if (!result)
            {
                TempData["Error"] = "Error while deleting entity from database";
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _bookService.GetAllBooksAsync();

            if (book == null)
            {
                return RedirectToAction("Index");
            }

            // Correzione: Creazione dell'EditBookViewModel usando le proprietà giuste
            var editBookViewModel = new EditBookViewModel()
            {
                Id = book.Id,
                Titolo = book.Titolo,  // Usa Titolo al posto di Name
                Autore = book.Autore, // Usa Descrizione al posto di Description
                Genere = book.Genere, // Usa Prezzo al posto di Price
                CoperturaUrl = book.CoperturaUrl // Usa Genere al posto di Category
            };

            return View(editBookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBookViewModel editBookViewModel)
        {
            var result = await _bookService.UpdateBookAsync(editBookViewModel);

            if (!result)
            {
                TempData["Error"] = "Error while updating entity on database";
            }

            return RedirectToAction("Index");
        }
    }
}
