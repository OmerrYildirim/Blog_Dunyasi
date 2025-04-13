
    let progress = 0;
    const interval = setInterval(() => {
    progress += 1;
    const progressBar = document.getElementById('progressBar');
    progressBar.style.width = progress + '%';
    progressBar.textContent = progress + '%';

    if (progress >= 100) {
    clearInterval(interval);
    setTimeout(() => {
    window.location.href = '/User/Login';
}, 500); // 500ms bekle
}
}, 30);
