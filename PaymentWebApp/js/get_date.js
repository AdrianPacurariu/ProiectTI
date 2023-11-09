function updateDateTime() {
    const date = new Date();
    const currentDateTime = now.toLocaleString();
    document.querySelector('#date').textContent = currentDateTime;
}
setInterval(updateDateTime, 1000);