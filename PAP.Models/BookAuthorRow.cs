namespace PAP.Models
{
    /// <summary>
    /// Fila plana para mostrar la tabla BookAuthors (Entity Framework no genera
    /// una clase para tablas puente que solo tienen las dos llaves foraneas).
    /// </summary>
    public class BookAuthorRow
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public int AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
