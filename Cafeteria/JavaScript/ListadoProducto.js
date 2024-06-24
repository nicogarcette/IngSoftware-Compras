/* script.js */
document.addEventListener('DOMContentLoaded', () => {
    const sampleProducts = [
        {
            name: 'Producto 1',
            price: 19.99,
            stockCurrent: 50,
            stockMin: 10,
            imageUrl: 'img/productos/granos.jpg'
        },
        {
            name: 'Producto 2',
            price: 29.99,
            stockCurrent: 30,
            stockMin: 5,
            imageUrl: 'img/productos/granos.jpg'
        },
        {
            name: 'Producto 3',
            price: 39.99,
            stockCurrent: 20,
            stockMin: 2,
            imageUrl: 'img/productos/granos.jpg'
        },
        {
            name: 'Producto 4',
            price: 39.99,
            stockCurrent: 60,
            stockMin: 5,
            imageUrl: 'img/productos/granos.jpg'
        }
    ];

    const productsList = document.getElementById('productsList');

    // Agregar productos de muestra
        // sampleProducts.forEach(product => {
        //     const card = document.createElement('div');
        //     card.className = 'card';

        //     card.innerHTML = `
        //         <img src="${product.imageUrl}" alt="${product.name}">
        //         <h2>${product.name}</h2>
        //         <p>Precio: $${product.price.toFixed(2)}</p>
        //         <p>Stock actual: ${product.stockCurrent}</p>
        //         <p>Stock mínimo: ${product.stockMin}</p>
        //     `;
        //     productsList.appendChild(card);
        // });

    // Fetch para obtener productos desde el backend
    fetch('https://localhost:7241/api/Producto')
        .then(response => response.json())
        .then(products => {

            // {
            //     "id": 3,
            //     "descripcion": "cafe",
            //     "precioVenta": 10,
            //     "stockActual": 2,
            //     "stockMinimo": 3,
            //     "numeroLote": 1,
            //     "fechaVencimiento": "2024-09-09T21:05:14.495"
            //   }
            products.forEach(product => {
                const card = document.createElement('div');
                card.className = 'card CardCafe';

                card.innerHTML = `
                    <img class="imgCard" src="img/productos/granos.jpg" alt="${product.name}">
                    <h2>${product.descripcion}</h2>
                    <div>
                        <p>Precio: $${product.precioVenta.toFixed(2)}</p>
                        <p>Stock actual: ${product.stockActual} </p>
                        <p>Stock mínimo: ${product.stockMinimo}</p>
                        <p>Vencimiento: ${formatFecha(product.fechaVencimiento)}</p>
                    </div>
                `;
                productsList.appendChild(card);
            });
        })
        .catch(error => console.error('Error fetching products:', error));
});


function formatFecha(fechaISO) {
    const options = { year: 'numeric', month: 'long', day: 'numeric' };
    const fecha = new Date(fechaISO);
    return fecha.toLocaleDateString('es-ES', options);
}