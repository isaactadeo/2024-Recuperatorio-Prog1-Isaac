
document.addEventListener("DOMContentLoaded", function (event) {
    console.info("Pruebas")
});

document.getElementById('FormularioUser').addEventListener('submit', function (event) {
    event.preventDefault();

    const datos = {
        Nombre: document.getElementById('Nombre').value,
        Direccion: document.getElementById('Direccion').value,
        CodPostal: document.getElementById('CodPostal').value,
        Dni: document.getElementById('Dni').value,
        FechaNacimiento: document.getElementById('FechaNacimiento').value,
    };

    fetch('http://localhost:5259/api/Cliente', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(datos)
    })
        .then(response => response.json())
        .then(data => {

            console.log('Respuesta de la API:', data);
            alert('Registro exitoso');
        })
        .catch(error => {

            console.error('Error al enviar los datos:', error);
            alert('Hubo un error al procesar el registro');
        });
});