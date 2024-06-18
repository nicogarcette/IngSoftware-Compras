function consultProduct() {
    const productId = document.getElementById('productId').value;
    
    // Simulación de una solicitud al backend
    fetch(`https://your-backend-api.com/products/${productId}`)
        .then(response => response.json())
        .then(data => {
            document.getElementById('description').textContent = data.description;
            document.getElementById('price').textContent = data.price;
            document.getElementById('annualStock').textContent = data.annualStock;
            document.getElementById('minimumStock').textContent = data.minimumStock;
            document.getElementById('batchNumber').textContent = data.batchNumber;
            document.getElementById('expiryDate').textContent = data.expiryDate;
            document.getElementById('supplierId').textContent = data.supplierId;
        })
        .catch(error => {
            console.error('Error:', error);
            alert('No se pudo consultar el producto. Por favor, intente nuevamente.');
        });
}
