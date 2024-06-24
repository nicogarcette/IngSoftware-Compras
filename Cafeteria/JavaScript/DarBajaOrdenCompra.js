async function fetchOrder() {
    
    const orderId = document.getElementById('orderId').value;
    if (!orderId) {
        alert('Por favor, ingrese un ID de Orden de Compra.');
        return;
    }

    const order = orders.find(o => o.id == orderId);

    if (order) {
        displayOrderDetails(order);
    } else {
        alert('No se encontró la orden de compra.');
    }
}

function displayOrderDetails(order) {
    const orderDetailsDiv = document.getElementById('orderDetails');
    orderDetailsDiv.innerHTML = `
        <h2>ID Orden de Compra: ${order.id}</h2>
        <p><strong>Nombre de la Empresa:</strong> ${order.companyName}</p>
        <p><strong>Razón:</strong> ${order.companyReason}</p>
        <p><strong>Domicilio Empresa:</strong> ${order.companyAddress}</p>
        <p><strong>Nombre Proveedor:</strong> ${order.providerName}</p>
        <p><strong>Domicilio Proveedor:</strong> ${order.providerAddress}</p>
        <p><strong>Teléfono Proveedor:</strong> ${order.providerPhone}</p>
        <h3>Productos:</h3>
        <ul>
            ${order.products.map(product => `
                <li>${product.name} - ${product.price} x ${product.quantity} = ${product.subtotal}</li>
            `).join('')}
        </ul>
        <p><strong>Total:</strong> ${order.total}</p>
        <button class="delete-button" type="button" onclick="deleteOrder(${order.id})">Eliminar</button>
    `;
    orderDetailsDiv.style.display = 'block';
}


async function deleteOrder(orderId) {
    try {
        const response = await fetch(`https://localhost:7241/api/OrdenCompra/${orderId}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        if (!response.ok) {
            throw new Error('Error al eliminar la orden de compra.');
        }

        Swal.fire({
            position: "top-end",
            icon: "success",
            title: "Orden de Compra eliminada!",
            showConfirmButton: false,
            timer: 1500
        });
        cargarOrden();

    } catch (error) {
        console.error('Error:', error);
        alert('Hubo un error al eliminar la orden de compra.');
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


document.getElementById("deleteOrden").addEventListener("click",()=>{

    event.preventDefault();

    const ordenId = document.getElementById('idOrden').value;
    deleteOrder(ordenId);
})