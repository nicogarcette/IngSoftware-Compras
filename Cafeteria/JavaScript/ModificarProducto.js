async function  modifyProduct() {

    const productId = document.getElementById('idProducto').value;
    const productDescription = document.getElementById('productDescription').value;
    const productPrice = document.getElementById('productPrice').value;
    const annualStock = document.getElementById('annualStock').value;
    const minimumStock = document.getElementById('minimumStock').value;
    const batchNumber = document.getElementById('batchNumber').value;
    const expiryDate = document.getElementById('expiryDate').value;
    const supplierId = document.getElementById('idProveedor').value;

    const productData = {
        descripcion: productDescription,
        precioVenta: productPrice,
        stockActual: annualStock,
        stockMinimo: minimumStock,
        numeroLote: batchNumber,
        fechaVencimiento: expiryDate,
        idProveedor: supplierId
    };

    await fetch(`https://localhost:7241/api/Producto/${productId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(productData)
    })
    .then(response => {
        if (response.ok) {
            Swal.fire({
                position: "top-end",
                icon: "success",
                title: "Producto modificado!",
                showConfirmButton: false,
                timer: 1500
            });
            document.getElementById("modifyForm").reset();
            cargarProducto();
        } else {
        Swal.fire({
            position: "top-end",
            icon: "error",
            title: "error al modificar",
            showConfirmButton: false,
            timer: 1500
        });
    }})
    .catch(error => {
        console.error('Error:', error);
        alert('No se pudo modificar el producto. Por favor, intente nuevamente.');
    });
}

const cargarProveedor = () => {
    fetch('https://localhost:7241/api/Proveedor')
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            const select = document.getElementById('idProveedor');
          
            select.innerHTML = '';

            const initialOption = document.createElement('option');
            initialOption.value = '';
            initialOption.textContent = 'Proveedor';
            initialOption.disabled = true;
            initialOption.selected = true;
            select.appendChild(initialOption);

            data.forEach(proveedor => {
                const option = document.createElement('option');
                option.value = proveedor.id;
                option.textContent = proveedor.nombre;
                select.appendChild(option);
            });
        })
        .catch(error => {
            console.error('Error:', error);
        });
};

const cargarProducto =()=>{
    fetch('https://localhost:7241/api/Producto')
    .then(response => response.json())
    .then(data => {
        const select = document.getElementById('idProducto');

            select.innerHTML = '';
            const initialOption = document.createElement('option');
            initialOption.value = '';
            initialOption.textContent = 'Producto';
            initialOption.disabled = true;
            initialOption.selected = true;
            select.appendChild(initialOption);
            data.forEach(producto => {
                const option = document.createElement('option');
                option.value = producto.id;  
                option.textContent = producto.descripcion; 
                select.appendChild(option);
            });
    })
    .catch((error) => {
        console.error('Error:', error);
    });
}

cargarProducto();
cargarProveedor();

document.getElementById("btnAddProduct").addEventListener("click", () => modifyProduct());