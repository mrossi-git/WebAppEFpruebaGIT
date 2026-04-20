namespace WebAppEF.Models
{
    public class Libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int Copias { get; set; }
        public int GeneroId { get; set; }
        public int UbicacionId { get; set; }
        public int EditorialId { get; set; }
        public int AutorId { get; set; }

        public Genero? genero { get; set; }
        public Ubicacion? ubicacion { get; set; }
        public Editorial? editorial { get; set; }
        public Autor? autor { get; set; }
    }
}
