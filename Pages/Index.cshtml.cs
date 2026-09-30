document.addEventListener('DOMContentLoaded', function () {
  const body = document.body;
  const btn = document.querySelector('.theme-btn');
  const saved = localStorage.getItem('market-theme');

  if (saved === 'dark') {
    body.classList.add('dark');
    if (btn) btn.textContent = '☾';
  } else {
    if (btn) btn.textContent = '☀';
  }

  if (btn) {
    btn.addEventListener('click', function () {
      const isDark = body.classList.toggle('dark');
      localStorage.setItem('market-theme', isDark ? 'dark' : 'light');
      btn.textContent = isDark ? '☾' : '☀';
    });
  }
});

if ('serviceWorker' in navigator) {
  window.addEventListener('load', function () {
    navigator.serviceWorker.register('/sw.js').catch(function () {
      // silent fail for dev mode
    });
  });
}
