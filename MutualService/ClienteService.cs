using MutualEntities;
using MutualDTO;
using MutualData;
using System.Net;
namespace MutualService
{
    public class ClienteService
    {
        public bool AgregarCliente(ClienteDTO clienteDto)
        {
            clienteDto.Contraseña = GenerarContraseñaNumerica();
            ClienteFiles.EscribirClientesAJson(ConvertirACliente(clienteDto));
            return true;
        }

        public List<ClienteDTO> ObtenerClientes()
        {
            var lista = ClienteFiles.LeerClientesDesdeJson().Select(ConvertirAClienteDto).ToList();
            return lista;
        }
        public ClienteDTO ObtenerClientePorDni(int dni)
        {
            var cliente = ClienteFiles.LeerClientesDesdeJson().FirstOrDefault(x => x.Dni == dni);
            if (cliente == null)
            {
                return null;
            }
            return ConvertirAClienteDto(cliente);
        }

        public bool EditarCliente(int dni, ClienteDTO clienteDto)
        {
            var cliente = ClienteFiles.LeerClientesDesdeJson().FirstOrDefault(x => x.Dni == dni);
            if (cliente == null) { return false; }
            var nuevo = ConvertirACliente(clienteDto);
            nuevo.Id = dni;
            ClienteFiles.EscribirClientesAJson(nuevo);
            return true;
        }
        public bool EliminarCliente(int id)
        {
            var cliente = ClienteFiles.LeerClientesDesdeJson().FirstOrDefault(x => x.Id == id);
            if (cliente == null) { return false; }
            cliente.FechaEliminacion = DateTime.Now;
            ClienteFiles.EscribirClientesAJson(cliente);
            return true;
        }

        private Cliente ConvertirACliente(ClienteDTO clienteDto)
        {
            Cliente cliente = new Cliente();
            cliente.Dni = clienteDto.Dni;
            cliente.Id = clienteDto.Id;
            cliente.Nombre = clienteDto.Nombre;
            cliente.Direccion = clienteDto.Direccion;
            cliente.CodPostal = clienteDto.CodPostal;
            cliente.FechaNacimiento = clienteDto.FechaNacimiento;
            cliente.Contraseña = clienteDto.Contraseña;
            return cliente;
        }
        
        private ClienteDTO ConvertirAClienteDto(Cliente cliente)
        {
            ClienteDTO clienteDto = new ClienteDTO();
            clienteDto.Dni = cliente.Dni;
            clienteDto.Id = cliente.Id; 
            clienteDto.Nombre = cliente.Nombre;
            clienteDto.Direccion = cliente.Direccion;
            clienteDto.CodPostal = cliente.CodPostal;
            clienteDto.FechaNacimiento = cliente.FechaNacimiento;
            clienteDto.Contraseña = cliente.Contraseña;          
            return clienteDto;
          
        }

        private string GenerarContraseñaNumerica()
        {
            Random random = new Random();
            return random.Next(100000, 999999).ToString();
        }
    }
}
