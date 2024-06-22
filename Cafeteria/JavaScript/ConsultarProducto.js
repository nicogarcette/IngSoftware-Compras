document.addEventListener('DOMContentLoaded', () => {
    const products = [
        {
            id: 1,
            description: 'Producto 1 Descripción',
            price: 100.0,
            annualStock: 50,
            minimumStock: 5,
            batchNumber: 'Lote1',
            expiryDate: '2024-12-31',
            supplierId: 101
        },
        {
            id: 2,
            description: 'Producto 2 Descripción',
            price: 200.0,
            annualStock: 30,
            minimumStock: 3,
            batchNumber: 'Lote2',
            expiryDate: '2024-11-30',
            supplierId: 102
        },
        {
            id: 3,
            description: 'Producto 3 Descripción',
            price: 150.0,
            annualStock: 20,
            minimumStock: 2,
            batchNumber: 'Lote3',
            expiryDate: '2024-10-31',
            supplierId: 103
        }
    ];

    window.consultProduct = function() {
        const productId = document.getElementById('productId').value;

        let url = `https://localhost:7241/api/Producto/${productId}`

        console.log(url);

        fetch(url)
        .then(response => response.json())
        .then(data => {
            console.log(data);
            displayProduct(data);
        })
        .catch((error) => {
            
            Swal.fire({
                position: "top-end",
                icon: "error",
                title: "Producto inexistente.",
                showConfirmButton: false,
                timer: 1500
            });
        });
        };

    function displayProduct(product) {
        document.getElementById('description').textContent = product.descripcion;
        document.getElementById('price').textContent = product.price;
        document.getElementById('annualStock').textContent = product.annualStock;
        document.getElementById('minimumStock').textContent = product.minimumStock;
        document.getElementById('batchNumber').textContent = product.batchNumber;
        document.getElementById('expiryDate').textContent = product.expiryDate;
        document.getElementById('supplierId').textContent = product.supplierId;
        document.getElementById('productInfo').style.display = 'block';
        document.getElementById('errorMessage').style.display = 'none';
    }

    function showError() {
        document.getElementById('productInfo').style.display = 'none';
        document.getElementById('errorMessage').style.display = 'block';
    }
});
