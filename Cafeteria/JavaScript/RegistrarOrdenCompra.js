
    let total = 0;
    let selectedProvider = null;
    let selectedProduct = null;
    let productos = [];
    let productosSeleccionados = [];
    let productosRequest = [];

    const cargarProveedores =()=>{

        fetch('https://localhost:7241/api/Proveedor')
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

    const boton = document.getElementById('verProductos');
    const proveedorSelect = document.getElementById('proveedor');
    const activarBoton = () => {

        console.log(proveedorSelect.value)
        boton.disabled = !proveedorSelect.value;
    };

    boton.addEventListener("click", ()=>{
        const proveedorId = parseInt(proveedorSelect.value);

        if (proveedorId) {
      
            const productosFiltrados = productos.filter(producto => producto.idProveedor === proveedorId);
            const productoSelect = document.getElementById('producto');

            console.log(productosFiltrados);

            productoSelect.innerHTML = '<option value="">Seleccione un producto</option>';
    
            productosFiltrados.forEach(producto => {
                const option = document.createElement('option');
                option.value = producto.id;  
                option.textContent = producto.descripcion; 
                productoSelect.appendChild(option);
            });
        }
    })
    
    const mostrarCampoCantidad = () => {
        const productoSelect = document.getElementById('producto');
        const cantidadContainer = document.getElementById('cantidadContainer');
        const btn = document.getElementById('btnAgregarProducto');

        cantidadContainer.style.display = productoSelect.value ? 'block' : 'none';
        btn.style.display = productoSelect.value ? 'block' : 'none';
    };
    
    const cargarProducto = async()=>{
        productos = await  fetchProducts();
    }

    async function fetchProducts() {
        const response = await fetch('https://localhost:7241/api/Producto');
        const products = await response.json();
        return products;
    }

    async function fetchProducts() {
        const response = await fetch('https://localhost:7241/api/Producto');
        const products = await response.json();
        return products;
    }

    const agregarProducto = () => {
        const productoSelect = document.getElementById('producto');
        const cantidadInput = document.getElementById('cantidad');
        const productoId = parseInt(productoSelect.value);
        const cantidad = parseInt(cantidadInput.value);
    
        if (productoId && cantidad > 0) {
            const producto = productos.find(prod => prod.id === productoId);

            const productoSeleccionado = {
                id: producto.id,
                nombre: producto.descripcion,
                cantidad: cantidad,
                precio: producto.precioVenta 
            };

            const productoRequest = {
                idProducto: producto.id,
                cantidad: cantidad,
            };

            productosRequest.push(productoRequest);
    
            productosSeleccionados.push(productoSeleccionado);
            actualizarTabla();
        } else {
            alert("Seleccione un producto y una cantidad válida.");
        }
    };

    const actualizarTabla = () => {
        const tbody = document.getElementById('productosTableBody');
        tbody.innerHTML = '';
    
        productosSeleccionados.forEach((producto, index) => {
            const row = document.createElement('tr');
    
            row.innerHTML = `
                <th scope="row">${index + 1}</th>
                <td>${producto.nombre}</td>
                <td>${producto.cantidad}</td>
                <td>${producto.precio * producto.cantidad}</td>
            `;
    
            tbody.appendChild(row);
        });
    };
    

    cargarProveedores();
    cargarProducto();


document.getElementById('generarOrdenDeCompra').addEventListener('click', async (event) => {
    event.preventDefault();

    const order = {
        descripcion: document.getElementById('descripcion').value,
        fecha: document.getElementById('fecha').value,
        idProveedor: proveedorSelect.value,
        productos: productosRequest
    };

    console.log(order)

    const response = await fetch('https://localhost:7241/api/OrdenCompra', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(order)
    });

    if (response.ok) {
        Swal.fire({
            position: "top-end",
            icon: "success",
            title: "Orden de compra generada!",
            showConfirmButton: false,
            timer: 1500
        });
        
        document.getElementById('purchaseOrderForm').reset();
        productosSeleccionados = [];
        productosRequest = [];
        const tbody = document.getElementById('productosTableBody');
        tbody.innerHTML = '';
        
    } else {
        Swal.fire({
            position: "top-end",
            icon: "error",
            title: "error al generar orden!",
            showConfirmButton: false,
            timer: 1500
        });
    }
});
