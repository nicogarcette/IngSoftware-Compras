
document.addEventListener('DOMContentLoaded', () => {
    // const orders = [
    //     {
    //         id: 1,
    //         date: '2024-06-01',
    //         companyName: 'Empresa A',
    //         providerName: 'Proveedor A',
    //         products: [
    //             { name: 'Producto 1', price: 100, quantity: 2, subtotal: 200 },
    //             { name: 'Producto 2', price: 150, quantity: 1, subtotal: 150 },
    //             { name: 'Producto 3', price: 50, quantity: 3, subtotal: 150 }
    //         ],
    //         total: 500
    //     },
    //     {
    //         id: 2,
    //         date: '2024-06-02',
    //         companyName: 'Empresa B',
    //         providerName: 'Proveedor B',
    //         products: [
    //             { name: 'Producto 4', price: 200, quantity: 1, subtotal: 200 },
    //             { name: 'Producto 5', price: 100, quantity: 2, subtotal: 200 },
    //             { name: 'Producto 6', price: 75, quantity: 4, subtotal: 300 }
    //         ],
    //         total: 700
    //     }
    // ];

    

    function displayOrderList(orders) {
        console.log(orders)

        const orderListDiv = document.getElementById('orderList');
        orders.forEach(order => {
            const orderItem = document.createElement('div');
            orderItem.className = 'order-item';
            orderItem.innerHTML = `
                <h2>Orden de Compra: ${order.id}</h2>
                <button onclick="toggleDetails(${order.id})">Detalles</button>
                <div id="details-${order.id}" class="order-details" style="display: none;">
                    <p><strong>Descripcion:</strong> ${order.descripcion}</p>
                    <p><strong>Fecha Orden de Compra:</strong> ${order.fecha}</p>
                    <p><strong>Nombre de la Empresa:</strong> ${order.proveedor.nombreEmpresa}</p>
                    <p><strong>Nombre Proveedor:</strong> ${order.proveedor.nombre}</p>
                    <h3>Productos:</h3>
                    <ul>
                        ${order.productos.map(product => `
                            <li>
                                <strong>Producto:</strong> ${product.descripcion} <br>
                                <strong>Precio:</strong> $${product.precioVenta.toFixed(2)} <br>
                            </li>
                        `).join('')}
                    </ul>
                    <p><strong>Total:</strong> $${order.precioTotal.toFixed(2)}</p>
                </div>
            `;
            orderListDiv.appendChild(orderItem);
        });
    }
{/* <strong>Cantidad:</strong> ${product.quantity} <br></br>
<strong>Subtotal:</strong> $${product.subtotal.toFixed(2)} */}
    window.toggleDetails = function(orderId) {
        const detailsDiv = document.getElementById(`details-${orderId}`);
        if (detailsDiv.style.display === 'none') {
            detailsDiv.style.display = 'block';
        } else {
            detailsDiv.style.display = 'none';
        }
    };

    async function fetchOrders() {
        try {
            const response = await fetch('https://localhost:7241/api/OrdenCompra');
            if (!response.ok) {
                throw new Error('Error al obtener las órdenes de compra.');
            }
            const orders = await response.json();
            displayOrderList(orders);
        } catch (error) {
            console.error('Error:', error);
            displayOrderList(orders); 
        }
    }

    fetchOrders();
});
