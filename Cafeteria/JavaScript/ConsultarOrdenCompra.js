/* script.js */
document.addEventListener('DOMContentLoaded', () => {
    async function fetchOrder(orderId) {
        try {
            const response = await fetch(`YOUR_BACKEND_URL/orders/${orderId}`);
            if (!response.ok) {
                throw new Error('Error al consultar la orden de compra.');
            }
            const order = await response.json();
            return order;
        } catch (error) {
            console.error('Error:', error);
            alert('Hubo un error al consultar la orden de compra.');
        }
    }

    function displayOrderDetails(order) {
        const orderDetailsDiv = document.getElementById('orderDetails');
        orderDetailsDiv.innerHTML = ''; // Limpiar contenido anterior

        const detailsHTML = `
            <h2>Detalles de la Orden de Compra</h2>
            <p><strong>ID:</strong> ${order.id}</p>
            <p><strong>Nombre de la Empresa:</strong> ${order.companyName}</p>
            <p><strong>Razón, Domicilio Empresa:</strong> ${order.companyAddress}</p>
            <p><strong>Teléfono Empresa:</strong> ${order.companyPhone}</p>
            <p><strong>ID del Proveedor:</strong> ${order.providerId}</p>
            <h3>Productos:</h3>
            <ul>
                ${order.products.map(product => `
                    <li>
                        <strong>Producto:</strong> ${product.name}<br>
                        <strong>Cantidad:</strong> ${product.quantity}<br>
                        <strong>Precio Unitario:</strong> $${product.unitPrice.toFixed(2)}<br>
                        <strong>Subtotal:</strong> $${product.subtotal.toFixed(2)}
                    </li>
                `).join('')}
            </ul>
            <p><strong>Total:</strong> $${order.total.toFixed(2)}</p>
        `;

        orderDetailsDiv.innerHTML = detailsHTML;
    }

    async function consultOrder() {
        const orderId = document.getElementById('orderId').value;
        const order = await fetchOrder(orderId);
        if (order) {
            displayOrderDetails(order);
        }
    }

    window.consultOrder = consultOrder;
});
