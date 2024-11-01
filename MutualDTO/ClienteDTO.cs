using System.ComponentModel.DataAnnotations;

namespace MutualDTO
{
    public class ClienteDTO
    {
        [Required]
        public int Dni { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public int CodPostal { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        public string Contraseña { get; set; }
        public int Id { get; set; }
    }
}
