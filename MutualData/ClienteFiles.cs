using Newtonsoft.Json;
using MutualEntities;

namespace MutualData
{
    public class ClienteFiles
    {
        private static string rutaCliente = Path.GetFullPath("Clientes.json");

        public static List<Cliente> LeerClientesDesdeJson()
        {
            if (File.Exists($"{rutaCliente}"))
            {
                var json = File.ReadAllText($"{rutaCliente}");
                return JsonConvert.DeserializeObject<List<Cliente>>(json);
            }
            else
            {
                return new List<Cliente>();
            }

        }

        public static void EscribirClientesAJson(Cliente cliente)
        {
            List<Cliente> clientes = LeerClientesDesdeJson();

            if (cliente.Id == 0)
            {
                cliente.Id = clientes.Count() + 1;
            }
            else
            {
                clientes.RemoveAll(x => x.Id == cliente.Id);

            }

            clientes.Add(cliente);

            var json = JsonConvert.SerializeObject(clientes, Formatting.Indented);
            File.WriteAllText($"{rutaCliente}", json);
        }
    }
}
