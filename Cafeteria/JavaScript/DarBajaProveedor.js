
function deleteProvider() {
    const providerId = document.getElementById('providerId').value;

    if (providerId) {
        fetch(`YOUR_BACKEND_URL/deleteProvider/${providerId}`, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(response => {
            if (response.ok) {
                alert('Proveedor dado de baja exitosamente');
                document.getElementById('deleteProviderForm').reset();
            } else {
                alert('Error al dar de baja al proveedor');
            }
        })
        .catch(error => {
            console.error('Error:', error);
            alert('Error al dar de baja al proveedor');
        });
    } else {
        alert('Por favor, ingrese un ID de proveedor');
    }
}
