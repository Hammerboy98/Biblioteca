namespace Biblioteca.Models
{
    public class Prestito
    {
        public int Id { get; set; }
        public int LibroId { get; set; }
        public Book Libro { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataScadenza { get; set; }
        public bool Restituito { get; set; }
    }
}



