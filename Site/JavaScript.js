const translations = {
    pt: {
        status: "CENTRO DE DOWNLOADS",
        hero_desc: "Alta performance, otimização e ferramentas de elite em um só lugar.",
        zclaw_desc: "O auge da performance em execução. Estável, rápido e seguro.",
        btn_download: "BAIXAR AGORA",
        sapphire_desc: "Sistema Windows ultra otimizado para jogos e latência zero.",
        simple_desc: "Minimalista e funcional. Perfeito para testes rápidos.",
        clicker_desc: "Frequência extrema de 0ms a 1ms. O mais rápido do mercado.",
        spotify_desc: "Gerenciador de músicas e ferramentas diretas para Spotify Desktop."
    },
    en: {
        status: "DOWNLOAD CENTER",
        hero_desc: "High performance, optimization, and elite tools in one place.",
        zclaw_desc: "The pinnacle of execution performance. Stable, fast, and secure.",
        btn_download: "DOWNLOAD NOW",
        sapphire_desc: "Ultra-optimized Windows system for gaming and zero latency.",
        simple_desc: "Minimalist and functional. Perfect for quick tests.",
        clicker_desc: "Extreme frequency from 0ms to 1ms. The fastest in the market.",
        spotify_desc: "Music manager and direct tools for Spotify Desktop."
    }
};

function changeLang(lang) {
    // Alterna classes dos botões
    document.querySelectorAll('.lang-btn').forEach(btn => {
        btn.classList.toggle('active', btn.innerText.toLowerCase() === lang);
    });

    // Animação de fade
    document.querySelector('.container').style.opacity = '0';
    
    setTimeout(() => {
        document.querySelectorAll('[data-i18n]').forEach(el => {
            const key = el.getAttribute('data-i18n');
            if (translations[lang][key]) {
                el.innerText = translations[lang][key];
            }
        });
        document.querySelector('.container').style.opacity = '1';
    }, 250);
}

// Suporte para transição suave no CSS
document.querySelector('.container').style.transition = 'opacity 0.3s ease';