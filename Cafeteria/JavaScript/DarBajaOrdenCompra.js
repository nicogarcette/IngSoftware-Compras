document.addEventListener('DOMContentLoaded', () => {
    const orders = [
        {
            id: 1,
            date: '2024-06-01',
            companyName: 'Empresa A',
            companyReason: 'Razón A',
            companyAddress: 'Dirección A',
            providerName: 'Proveedor A',
            providerAddress: 'Dirección Proveedor A',
            providerPhone: '123456789',
            products: [
                { name: 'Producto 1', price: 100, quantity: 2, subtotal: 200 },
                { name: 'Producto 2', price: 150, quantity: 1, subtotal: 150 },
                { name: 'Producto 3', price: 50, quantity: 3, subtotal: 150 }
            ],
            total: 500
        },
        {
            id: 2,
            date: '2024-06-02',
            companyName: 'Empresa B',
            companyReason: 'Razón B',
            companyAddress: 'Dirección B',
            providerName: 'Proveedor B',
            providerAddress: 'Dirección Proveedor B',
            providerPhone: '987654321',
            products: [
                { name: 'Producto 4', price: 200, quantity: 1, subtotal: 200 },
                { name: 'Producto 5', price: 100, quantity: 2, subtotal: 200 },
                { name: 'Producto 6', price: 75, quantity: 4, subtotal: 300 }
            ],
            total: 700
        }
    ];

    async function fetchOrder() {
        const orderId = document.getElementById('orderId').value;
        if (!orderId) {
            alert('Por favor, ingrese un ID de Orden de Compra.');
            return;
        }

        // Simulación de la búsqueda en la base de datos
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
            const response = await fetch(`YOUR_BACKEND_URL/orders/${orderId}`, {
                method: 'DELETE',
                headers: {
                    'Content-Type': 'application/json'
                }
            });
            if (!response.ok) {
                throw new Error('Error al eliminar la orden de compra.');
            }
            document.getElementById('orderDetails').innerHTML = '';
            alert('La Orden de compra ha sido eliminada de la base de datos.');
        } catch (error) {
            console.error('Error:', error);
            alert('Hubo un error al eliminar la orden de compra.');
        }
    }

    window.fetchOrder = fetchOrder;
    window.deleteOrder = deleteOrder;
});
