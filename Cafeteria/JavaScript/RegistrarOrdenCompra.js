/* script.js */
document.addEventListener('DOMContentLoaded', () => {
    let total = 0;
    let selectedProvider = null;
    let selectedProduct = null;

    async function fetchProviders() {
        const response = await fetch('YOUR_BACKEND_URL/providers');
        const providers = await response.json();
        return providers;
    }

    async function fetchProducts() {
        const response = await fetch('YOUR_BACKEND_URL/products');
        const products = await response.json();
        return products;
    }

    async function selectProvider() {
        const providers = await fetchProviders();
        selectedProvider = providers[Math.floor(Math.random() * providers.length)];
        document.getElementById('selectedProvider').innerText = `Proveedor seleccionado: ${selectedProvider.name}`;
    }

    async function selectProduct() {
        const products = await fetchProducts();
        selectedProduct = products[Math.floor(Math.random() * products.length)];
        document.getElementById('selectedProduct').innerText = `Producto seleccionado: ${selectedProduct.name}`;
        document.getElementById('unitPrice').value = selectedProduct.price.toFixed(2);
        updateSubtotal();
    }

    function updateSubtotal() {
        const quantity = document.getElementById('quantity').value;
        const unitPrice = document.getElementById('unitPrice').value;
        const subtotal = quantity * unitPrice;
        document.getElementById('subtotal').value = subtotal.toFixed(2);
    }

    document.getElementById('quantity').addEventListener('input', updateSubtotal);

    document.getElementById('purchaseOrderForm').addEventListener('submit', async (event) => {
        event.preventDefault();
        total += parseFloat(document.getElementById('subtotal').value);
        document.getElementById('total').value = total.toFixed(2);

        const order = {
            companyName: document.getElementById('companyName').value,
            companyAddress: document.getElementById('companyAddress').value,
            companyPhone: document.getElementById('companyPhone').value,
            providerId: selectedProvider.id,
            products: [
                {
                    productId: selectedProduct.id,
                    quantity: document.getElementById('quantity').value,
                    unitPrice: selectedProduct.price,
                    subtotal: parseFloat(document.getElementById('subtotal').value)
                }
            ],
            total: total
        };

        const response = await fetch('YOUR_BACKEND_URL/orders', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(order)
        });

        if (response.ok) {
            alert('Orden de compra registrada.');
            // Limpiar el formulario después de enviar los datos
            document.getElementById('purchaseOrderForm').reset();
            document.getElementById('selectedProvider').innerText = '';
            document.getElementById('selectedProduct').innerText = '';
            total = 0;
            document.getElementById('total').value = '';
        } else {
            alert('Hubo un error al registrar la orden de compra.');
        }
    });

    window.selectProvider = selectProvider;
    window.selectProduct = selectProduct;
    window.addProduct = () => {
        total += parseFloat(document.getElementById('subtotal').value);
        document.getElementById('total').value = total.toFixed(2);
        alert('Producto añadido a la orden.');
        // Aquí se pueden agregar más productos a la orden
    };
});
