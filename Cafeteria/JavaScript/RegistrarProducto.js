document.getElementById('addProducto').addEventListener('click', function(event) {
    event.preventDefault();

    let product = {
        descripcion : document.getElementById('productName').value,
        stockActual : document.getElementById('stockActual').value,
        stockMinimo : document.getElementById('stockMinimo').value,
        precioVenta : document.getElementById('precioVenta').value,
        numeroLote : document.getElementById('lote').value,
        fechaVencimiento : document.getElementById('fecha').value,
        idProveedor : document.getElementById('proveedor').value
    }

    fetch('https://localhost:7241/api/Producto', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(product)
    })
    .then(response => response.json())
    .then(data => {

        Swal.fire({
            position: "top-end",
            icon: "success",
            title: "Producto agregado!",
            showConfirmButton: false,
            timer: 1500
        });

        setTimeout(() => {
            document.getElementById("registerProductForm").reset();
        }, 1500);

    })
    .catch((error) => {
        console.error('Error:', error);
        showMessage('Error al registrar el producto. Por favor, inténtelo de nuevo.');
    });



});



function showMessage(message) {
    const messageDiv = document.getElementById('message');
    messageDiv.innerText = message;
}

const cargarProveedores =()=>{
    fetch(' https://localhost:7241/api/Proveedor')
    .then(response => response.json())
    .then(data => {
        const select = document.getElementById('proveedor');
            data.forEach(proveedor => {
                const option = document.createElement('option');
                option.value = proveedor.id;  
                option.textContent = proveedor.nombre; 
                select.appendChild(option);
            });
    })
    .catch((error) => {
        console.error('Error:', error);
    });
}

cargarProveedores();




