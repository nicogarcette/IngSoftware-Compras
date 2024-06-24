/* script.js */
function modifyProvider() {
    const providerId = document.getElementById('idProveedor').value;

    const providerData = {
        nombre: document.getElementById('providerName').value,
        apellido: document.getElementById('providerLastname').value,
        telefono: document.getElementById('providerPhone').value,
        direccion: document.getElementById('providerAddress').value,
        cuil: document.getElementById('providerCuil').value,
        nombreEmpresa: document.getElementById('providerCompanyName').value
    };

    fetch(`https://localhost:7241/api/Proveedor/${providerId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(providerData)
    })
    .then(response => {
       
        if (response.ok) {
            Swal.fire({
                position: "top-end",
                icon: "success",
                title: "Producto modificado!",
                showConfirmButton: false,
                timer: 1500
            });
            document.getElementById("modifyProviderForm").reset();
        } else {
            Swal.fire({
                position: "top-end",
                icon: "error",
                title: "error al modificar",
                showConfirmButton: false,
                timer: 1500
            });
        }
    })
    .catch(error => {
        console.error('Error:', error);
        alert('Error al modificar el proveedor. Por favor, inténtelo de nuevo.');
    });
}


const cargarProveedor = () => {
    fetch('https://localhost:7241/api/Proveedor')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            const select = document.getElementById('idProveedor');
          
            select.innerHTML = '';

            const initialOption = document.createElement('option');
            initialOption.value = '';
            initialOption.textContent = 'Proveedor';
            initialOption.disabled = true;
            initialOption.selected = true;
            select.appendChild(initialOption);

            data.forEach(proveedor => {
                const option = document.createElement('option');
                option.value = proveedor.id;
                option.textContent = proveedor.nombre;
                select.appendChild(option);
            });
        })
        .catch(error => {
            console.error('Error:', error);
        });
};

cargarProveedor();


document.getElementById("btnModificarProveedor").addEventListener("click", () => modifyProvider());