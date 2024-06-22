/* script.js */
function modifyProvider() {
    const providerId = document.getElementById('providerId').value;
    const providerData = {
        name: document.getElementById('providerName').value,
        lastname: document.getElementById('providerLastname').value,
        phone: document.getElementById('providerPhone').value,
        address: document.getElementById('providerAddress').value,
        cuil: document.getElementById('providerCuil').value,
        companyName: document.getElementById('providerCompanyName').value
    };

    fetch(`YOUR_BACKEND_URL/provider/${providerId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(providerData)
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Network response was not ok');
        }
        return response.json();
    })
    .then(data => {
        alert('Proveedor modificado exitosamente');
    })
    .catch(error => {
        console.error('Error:', error);
        alert('Error al modificar el proveedor. Por favor, inténtelo de nuevo.');
    });
}
