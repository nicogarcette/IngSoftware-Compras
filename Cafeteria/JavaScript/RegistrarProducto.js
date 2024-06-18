function registerProduct() {
    const productCode = document.getElementById('productCode').value;
    const productName = document.getElementById('productName').value;
    const productDescription = document.getElementById('productDescription').value;
    const productStock = document.getElementById('productStock').value;
    const productPrice = document.getElementById('productPrice').value;

    const productData = {
        code: productCode,
        name: productName,
        description: productDescription,
        stock: productStock,
        price: productPrice
    };

    fetch('https://your-backend-api.com/register', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(productData)
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            alert('Producto registrado con éxito');
            document.getElementById('registerForm').reset();
        } else {
            alert('Error al registrar el producto');
        }
    })
    .catch(error => {
        console.error('Error:', error);
        alert('No se pudo registrar el producto. Por favor, intente nuevamente.');
    });
}
