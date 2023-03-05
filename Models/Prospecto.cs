namespace Backend_ASP.NETcore.Models
{
    public class Prospecto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Servicio { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
