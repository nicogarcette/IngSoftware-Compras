

async function modifyOrder() {
    const order = {
        descripcion: document.getElementById('ordenDescription').value,
        fecha: document.getElementById('Date').value
    };

    const orderId = document.getElementById("idOrden").value;

    try {
        const response = await fetch(`https://localhost:7241/api/OrdenCompra/${orderId}`, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(order)
        });
        
        if (!response.ok) {
            throw new Error('Error al modificar la orden de compra.');
        }

        Swal.fire({
            position: "top-end",
            icon: "success",
            title: "Orden modificada!",
            showConfirmButton: false,
            timer: 1500
        });

        cargarOrden();
        document.getElementById("modifyForm").reset();
        
    } catch (error) {
        Swal.fire({
            position: "top-end",
            icon: "error",
            title: "Error al modificar!",
            showConfirmButton: false,
            timer: 1500
        });
    }
}

function cargarOrden() {
    fetch('https://localhost:7241/api/OrdenCompra')
        .then(response => response.json())
        .then(data => {
            const select = document.getElementById('idOrden');

            select.innerHTML = '';
            const initialOption = document.createElement('option');
            initialOption.value = '';
            initialOption.textContent = 'Orden de Compra';
            initialOption.disabled = true;
            initialOption.selected = true;
            select.appendChild(initialOption);
            data.forEach(producto => {
                const option = document.createElement('option');
                option.value = producto.id;
                option.textContent = producto.descripcion;
                select.appendChild(option);
            });
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

cargarOrden();

document.getElementById("btnModiOrden").addEventListener("click", () => modifyOrder());