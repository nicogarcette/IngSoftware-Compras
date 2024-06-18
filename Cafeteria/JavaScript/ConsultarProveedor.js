/* script.js */
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
            // Asignar datos a los elementos correspondientes
            document.getElementById('name').innerText = data.name;
            document.getElementById('lastname').innerText = data.lastname;
            document.getElementById('phone').innerText = data.phone;
            document.getElementById('address').innerText = data.address;
            document.getElementById('cuil').innerText = data.cuil;
            document.getElementById('companyName').innerText = data.companyName;
            document.getElementById('providerInfo').style.display = 'block';
        })
        .catch(error => {
            console.error('Error:', error);
            alert('Error al consultar el proveedor. Por favor, inténtelo de nuevo.');
        });
}
