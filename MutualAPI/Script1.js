function llenarTablaClientes() {
    fetch('http://localhost:5259/api/Cliente')
        .then(response => response.json())
        .then(data => {
            var tablaClientes = document.getElementById("tablaClientes");
            data.forEach(cliente => {
                var fila = document.createElement("tr");
                fila.innerHTML = `
                    <td>${cliente.id}</td>
                    <td>${cliente.nombre}</td>
                    <td>${cliente.codPostal}</td>
                `;
                tablaClientes.appendChild(fila);
                console.log(cliente)
            });
        })
        .catch(error => {
            console.error('Error al obtener datos:', error);
        });
}

document.addEventListener("DOMContentLoaded", llenarTablaClientes);
