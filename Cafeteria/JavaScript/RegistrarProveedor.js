/* script.js */
document.getElementById('providerForm').addEventListener('submit', function(event) {
    event.preventDefault();

    const formData = new FormData(event.target);
    const formObject = Object.fromEntries(formData.entries());
    const jsonData = JSON.stringify(formObject);

    console.log(jsonData); // Puedes verificar los datos JSON en la consola

    // Aquí enviarías los datos al backend
    fetch('YOUR_BACKEND_URL', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: jsonData
    })
    .then(response => response.json())
    .then(data => {
        console.log('Success:', data);
        // Aquí puedes manejar la respuesta del servidor
    })
    .catch((error) => {
        console.error('Error:', error);
        // Aquí puedes manejar los errores
    });
});
