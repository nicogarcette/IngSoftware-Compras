document.getElementById('registerProductForm').addEventListener('submit', function(event) {
    event.preventDefault();

    const formData = new FormData(event.target);
    const formObject = Object.fromEntries(formData.entries());
    const jsonData = JSON.stringify(formObject);

    console.log(jsonData); // Puedes verificar los datos JSON en la consola

    // Aquí enviarías los datos al backend
    fetch('YOUR_BACKEND_URL/register-product', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: jsonData
    })
    .then(response => response.json())
    .then(data => {
        console.log('Success:', data);
        showMessage('El producto ha sido registrado en la base de datos.');
        addProductToList(formObject);
    })
    .catch((error) => {
        console.error('Error:', error);
        showMessage('Error al registrar el producto. Por favor, inténtelo de nuevo.');
    });

    // Mostrar producto en pantalla localmente
    showMessage('El producto ha sido registrado localmente.');
    addProductToList(formObject);
});

function showMessage(message) {
    const messageDiv = document.getElementById('message');
    messageDiv.innerText = message;
}

function addProductToList(product) {
    const productList = document.getElementById('productList');
    const productItem = document.createElement('div');
    productItem.classList.add('product-item');
    productItem.innerHTML = `
        <p><strong>Código:</strong> ${product.productCode}</p>
        <p><strong>Nombre:</strong> ${product.productName}</p>
        <p><strong>Descripción:</strong> ${product.productDescription}</p>
        <p><strong>Stock:</strong> ${product.stock}</p>
        <p><strong>Precio:</strong> $${product.price}</p>
    `;
    productList.appendChild(productItem);
}
