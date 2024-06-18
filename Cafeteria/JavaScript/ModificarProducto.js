function modifyProduct() {
    const productId = document.getElementById('productId').value;
    const productDescription = document.getElementById('productDescription').value;
    const productPrice = document.getElementById('productPrice').value;
    const annualStock = document.getElementById('annualStock').value;
    const minimumStock = document.getElementById('minimumStock').value;
    const batchNumber = document.getElementById('batchNumber').value;
    const expiryDate = document.getElementById('expiryDate').value;
    const supplierId = document.getElementById('supplierId').value;

    const productData = {
        id: productId,
        description: productDescription,
        price: productPrice,
        annualStock: annualStock,
        minimumStock: minimumStock,
        batchNumber: batchNumber,
        expiryDate: expiryDate,
        supplierId: supplierId
    };

    fetch('https://your-backend-api.com/modify', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(productData)
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            alert('Producto modificado con éxito');
            document.getElementById('modifyForm').reset();
        } else {
            alert('Error al modificar el producto');
        }
    })
    .catch(error => {
        console.error('Error:', error);
        alert('No se pudo modificar el producto. Por favor, intente nuevamente.');
    });
}
