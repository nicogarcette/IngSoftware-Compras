
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
            <p><label>Nombre de la Empresa:</label> <input type="text" id="companyName" value="${order.companyName}"></p>
            <p><label>Razón:</label> <input type="text" id="companyReason" value="${order.companyReason}"></p>
            <p><label>Domicilio Empresa:</label> <input type="text" id="companyAddress" value="${order.companyAddress}"></p>
            <p><label>Nombre Proveedor:</label> <input type="text" id="providerName" value="${order.providerName}"></p>
            <p><label>Domicilio Proveedor:</label> <input type="text" id="providerAddress" value="${order.providerAddress}"></p>
            <p><label>Teléfono Proveedor:</label> <input type="text" id="providerPhone" value="${order.providerPhone}"></p>
            <h3>Productos:</h3>
            <div id="products">
                ${order.products.map((product, index) => `
                    <div class="product-item">
                        <p><label>Nombre Producto:</label> <input type="text" id="productName-${index}" value="${product.name}"></p>
                        <p><label>Precio:</label> <input type="number" id="productPrice-${index}" value="${product.price}"></p>
                        <p><label>Cantidad:</label> <input type="number" id="productQuantity-${index}" value="${product.quantity}"></p>
                        <p><label>Subtotal:</label> <span id="productSubtotal-${index}">${product.subtotal}</span></p>
                    </div>
                `).join('')}
            </div>
            <p><label>Total:</label> <span id="orderTotal">${order.total}</span></p>
            <button type="button" onclick="modifyOrder(${order.id})">Modificar</button>
        `;
        orderDetailsDiv.style.display = 'block';
    }

    async function modifyOrder(orderId) {
        const order = {
            companyName: document.getElementById('companyName').value,
            companyReason: document.getElementById('companyReason').value,
            companyAddress: document.getElementById('companyAddress').value,
            providerName: document.getElementById('providerName').value,
            providerAddress: document.getElementById('providerAddress').value,
            providerPhone: document.getElementById('providerPhone').value,
            products: Array.from(document.querySelectorAll('.product-item')).map((productItem, index) => ({
                name: document.getElementById(`productName-${index}`).value,
                price: parseFloat(document.getElementById(`productPrice-${index}`).value),
                quantity: parseInt(document.getElementById(`productQuantity-${index}`).value),
                subtotal: parseFloat(document.getElementById(`productPrice-${index}`).value) * parseInt(document.getElementById(`productQuantity-${index}`).value)
            })),
            total: Array.from(document.querySelectorAll('.product-item')).reduce((acc, productItem, index) => {
                return acc + parseFloat(document.getElementById(`productPrice-${index}`).value) * parseInt(document.getElementById(`productQuantity-${index}`).value);
            }, 0)
        };

        try {
            const response = await fetch(`YOUR_BACKEND_URL/orders/${orderId}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(order)
            });
            if (!response.ok) {
                throw new Error('Error al modificar la orden de compra.');
            }
            const updatedOrder = await response.json();
            displayOrderDetails(updatedOrder);
            alert('Orden de compra modificada exitosamente.');
        } catch (error) {
            console.error('Error:', error);
            alert('Hubo un error al modificar la orden de compra.');
        }
    }

    window.fetchOrder = fetchOrder;
    window.modifyOrder = modifyOrder;
});
