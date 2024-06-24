
document.getElementById('deleteProductForm').addEventListener('submit', function(event) {
    event.preventDefault();
  
    const productId = document.getElementById('idProducto').value;

    deleteProducto(productId);
});

const deleteProducto = async (productId) =>{

    await fetch(`https://localhost:7241/api/Producto/${productId}`, {
        method: 'DELETE'
    })
    .then(response => response.json())
    .then(data => {

        Swal.fire({
            position: "top-end",
            icon: "success",
            title: "Producto eliminado!",
            showConfirmButton: false,
            timer: 1500
        });
        cargarProducto();
    })
    .catch((error) => {
        Swal.fire({
            position: "top-end",
            icon: "success",
            title: "Producto eliminado!",
            showConfirmButton: false,
            timer: 1500
        });
        cargarProducto();
    });
}

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
