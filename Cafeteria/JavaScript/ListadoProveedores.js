/* script.js */
document.addEventListener('DOMContentLoaded', () => {
    const providers = [
        {
            id: 1,
            name: 'Juan',
            lastname: 'Pérez',
            birthdate: '1980-01-01',
            dni: '12345678',
            address: 'Calle Falsa 123',
            phone: '1234567890',
            cuil: '20-12345678-9',
            companyName: 'Empresa A'
        },
        {
            id: 2,
            name: 'María',
            lastname: 'Gómez',
            birthdate: '1985-02-02',
            dni: '87654321',
            address: 'Avenida Siempreviva 742',
            phone: '0987654321',
            cuil: '27-87654321-6',
            companyName: 'Empresa B'
        },
        {
            id: 3,
            name: 'Carlos',
            lastname: 'Rodríguez',
            birthdate: '1990-03-03',
            dni: '11223344',
            address: 'Boulevard Central 456',
            phone: '1122334455',
            cuil: '23-11223344-8',
            companyName: 'Empresa C'
        }
    ];

    const providersList = document.getElementById('providersList');
    providers.forEach(provider => {
        const card = document.createElement('div');
        card.className = 'card';

        card.innerHTML = `
            <h2>${provider.name} (ID: ${provider.id})</h2>
            <button onclick="toggleDetails(${provider.id})">Detalles</button>
            <div id="details-${provider.id}" class="details">
                <p><strong>Nombre:</strong> ${provider.name}</p>
                <p><strong>Apellido:</strong> ${provider.lastname}</p>
                <p><strong>Fecha de nacimiento:</strong> ${provider.birthdate}</p>
                <p><strong>DNI:</strong> ${provider.dni}</p>
                <p><strong>Dirección:</strong> ${provider.address}</p>
                <p><strong>Teléfono:</strong> ${provider.phone}</p>
                <p><strong>CUIL:</strong> ${provider.cuil}</p>
                <p><strong>Nombre de la empresa:</strong> ${provider.companyName}</p>
            </div>
        `;
        providersList.appendChild(card);
    });
});

function toggleDetails(providerId) {
    const details = document.getElementById(`details-${providerId}`);
    if (details.style.display === 'none' || details.style.display === '') {
        details.style.display = 'block';
    } else {
        details.style.display = 'none';
    }
}
