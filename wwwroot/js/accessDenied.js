
    document.addEventListener('DOMContentLoaded', function() {
    const progressBar = document.getElementById('progressBar');
    const countdown = document.getElementById('countdown');
    let progress = 0;
    let timeLeft = 5;

    const interval = setInterval(() => {
    progress += 2;
    timeLeft = Math.ceil(5 - (progress / 20));

    progressBar.style.width = progress + '%';
    countdown.textContent = timeLeft;

    if (progress >= 100) {
    clearInterval(interval);
    window.location.href = '/User/Login';
}
}, 100);
});
