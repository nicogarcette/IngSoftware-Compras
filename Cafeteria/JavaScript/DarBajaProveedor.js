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

document.addEventListener('DOMContentLoaded', cargarProveedor);

document.getElementById('deleteProviderForm').addEventListener('click', function(event) {
    event.preventDefault();

    const providerId = document.getElementById('idProveedor').value;

    deleteProveedor(providerId);
});

const deleteProveedor = async (providerId) => {
    try {
        const response = await fetch(`https://localhost:7241/api/Proveedor/${providerId}`, {
            method: 'DELETE'
        });

        if (!response.ok) {
            throw new Error('Network response was not ok');
        }

        const data = await response.json();

        if (data) {
            Swal.fire({
                position: "top-end",
                icon: "success",
                title: "Proveedor eliminado!",
                showConfirmButton: false,
                timer: 1500
            });
        cargarProveedor();
   
        } else {
            alert('El proveedor no existe.');
        }
    } catch (error) {

        Swal.fire({
            position: "top-end",
            icon: "success",
            title: "Proveedor eliminado!",
            showConfirmButton: false,
            timer: 1500
        });
        cargarProveedor();
    }
};



