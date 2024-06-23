/* script.js */
document.addEventListener('DOMContentLoaded', () => {
   
    cargarProveedor(); 
});

const cargarProveedor =()=>{
    fetch('https://localhost:7241/api/Proveedor')
    .then(response => response.json())
    .then(data => {
        llenarTabla(data);;
    })
    .catch((error) => {
        console.error('Error:', error);
    });
}

function llenarTabla(datos) {
    const tablaBody = document.getElementById('tablaBody');
    tablaBody.innerHTML = '';
    datos.forEach((dato, index) => {
        const fila = document.createElement('tr');

        fila.innerHTML = `
            <th scope="row">${index + 1}</th>
            <td>${dato.nombre}</td>
            <td>${dato.apellido}</td>
            <td>${dato.cuil}</td>
            <td>${dato.direccion}</td>
            <td>${dato.telefono}</td>
            <td>${dato.nombreEmpresa}</td>
        `;

        tablaBody.appendChild(fila);
    });
}