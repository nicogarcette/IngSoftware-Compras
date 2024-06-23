/* script.js */
document.getElementById('providerForm').addEventListener('submit', function(event) {
    event.preventDefault();

    const formData = new FormData(event.target);
    const formObject = Object.fromEntries(formData.entries());
    const jsonData = JSON.stringify(formObject);

    fetch('https://localhost:7241/api/Proveedor', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: jsonData
    })
    .then(response => response.json())
    .then(data => {
        Swal.fire({
            position: "top-end",
            icon: "success",
            title: "Proveedor agregado!",
            showConfirmButton: false,
            timer: 1500
        });

        setTimeout(() => {
            document.getElementById("providerForm").reset();
        }, 1500);
    })
    .catch((error) => {
        console.error('Error:', error);
    });
});
