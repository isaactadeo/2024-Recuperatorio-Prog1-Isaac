using System.Diagnostics.CodeAnalysis;

namespace MutualEntities
{
    public class Cliente
    {
        public int Id { get; set; } 
        public int Dni { get; set; } 
        public string Nombre { get; set; }  
        public string Direccion { get; set; }  
        public int CodPostal { get; set; }  
        public DateTime FechaNacimiento { get; set; }   
        public DateTime FechaEliminacion { get; set; }   
        public string Contraseña { get; set; } //6 digitos
    }
}

//Cuando se da de alta un cliente, esta contraseña debe ser auto generada de manera aleatoria.
