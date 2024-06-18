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
    sampleProducts.forEach(product => {
        const card = document.createElement('div');
        card.className = 'card';

        card.innerHTML = `
            <img src="${product.imageUrl}" alt="${product.name}">
            <h2>${product.name}</h2>
            <p>Precio: $${product.price.toFixed(2)}</p>
            <p>Stock actual: ${product.stockCurrent}</p>
            <p>Stock mínimo: ${product.stockMin}</p>
        `;
        productsList.appendChild(card);
    });

    // Fetch para obtener productos desde el backend
    fetch('YOUR_BACKEND_URL/products')
        .then(response => response.json())
        .then(products => {
            products.forEach(product => {
                const card = document.createElement('div');
                card.className = 'card';

                card.innerHTML = `
                    <img src="${product.imageUrl}" alt="${product.name}">
                    <h2>${product.name}</h2>
                    <p>Precio: $${product.price.toFixed(2)}</p>
                    <p>Stock actual: ${product.stockCurrent}</p>
                    <p>Stock mínimo: ${product.stockMin}</p>
                `;
                productsList.appendChild(card);
            });
        })
        .catch(error => console.error('Error fetching products:', error));
});
