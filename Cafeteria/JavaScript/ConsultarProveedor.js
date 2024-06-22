function consultProvider() {
    const providerId = document.getElementById('providerId').value;

    fetch(`YOUR_BACKEND_URL/provider/${providerId}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            if (data) {
                document.getElementById('name').innerText = data.name;
                document.getElementById('lastname').innerText = data.lastname;
                document.getElementById('phone').innerText = data.phone;
                document.getElementById('address').innerText = data.address;
                document.getElementById('cuil').innerText = data.cuil;
                document.getElementById('companyName').innerText = data.companyName;
                document.getElementById('providerInfo').style.display = 'block';
            } else {
                alert('El proveedor no existe.');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('Error al consultar el proveedor. Por favor, inténtelo de nuevo.');
        });
}

// Simulación de datos
document.addEventListener('DOMContentLoaded', () => {
    const providers = [
        {
            id: 1,
            name: 'Juan',
            lastname: 'Pérez',
            phone: '123456789',
            address: 'Calle Falsa 123',
            cuil: '20-12345678-9',
            companyName: 'Empresa A'
        },
        {
            id: 2,
            name: 'María',
            lastname: 'González',
            phone: '987654321',
            address: 'Av. Siempreviva 742',
            cuil: '27-87654321-0',
            companyName: 'Empresa B'
        },
        {
            id: 3,
            name: 'Carlos',
            lastname: 'Rodríguez',
            phone: '456789123',
            address: 'Calle Luna 456',
            cuil: '23-45678912-3',
            companyName: 'Empresa C'
        }
    ];

    window.consultProvider = function() {
        const providerId = parseInt(document.getElementById('providerId').value);

        const provider = providers.find(p => p.id === providerId);

        if (provider) {
            document.getElementById('name').innerText = provider.name;
            document.getElementById('lastname').innerText = provider.lastname;
            document.getElementById('phone').innerText = provider.phone;
            document.getElementById('address').innerText = provider.address;
            document.getElementById('cuil').innerText = provider.cuil;
            document.getElementById('companyName').innerText = provider.companyName;
            document.getElementById('providerInfo').style.display = 'block';
        } else {
            alert('El proveedor no existe.');
        }
    };
});
