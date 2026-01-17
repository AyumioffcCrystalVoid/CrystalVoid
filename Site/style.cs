:root {
    --primary: #00f2ff;
    --secondary: #7000ff;
    --bg-black: #020203;
    --card-bg: rgba(10, 10, 15, 0.6);
    --border: rgba(255, 255, 255, 0.08);
    --text-main: #ffffff;
    --text-dim: #94a3b8;
}

* { margin: 0; padding: 0; box-sizing: border-box; font-family: 'Outfit', sans-serif; }

body {
    background-color: var(--bg-black);
    color: var(--text-main);
    min-height: 100vh;
    overflow-x: hidden;
}

/* Background Effects */
.void-bg {
    position: fixed; top: 0; left: 0; width: 100%; height: 100%;
    background: 
        radial-gradient(circle at 20% 30%, rgba(112, 0, 255, 0.15) 0%, transparent 50%),
        radial-gradient(circle at 80% 70%, rgba(0, 242, 255, 0.1) 0%, transparent 50%);
    z-index: -2;
}

.noise-overlay {
    position: fixed; top: 0; left: 0; width: 100%; height: 100%;
    background: url('https://grainy-gradients.vercel.app/noise.svg');
    opacity: 0.03; pointer-events: none; z-index: -1;
}

.container { max-width: 1100px; margin: 0 auto; padding: 2rem 1.5rem; }

/* Top Bar & Interface */
.top-bar { display: flex; justify-content: space-between; align-items: center; padding: 1.5rem 0; margin-bottom: 2rem; }

.status-indicator {
    display: flex; align-items: center; gap: 10px;
    background: rgba(255,255,255,0.03); padding: 8px 16px;
    border-radius: 50px; border: 1px solid var(--border);
    font-size: 0.7rem; font-weight: 800; letter-spacing: 1px;
}

.pulse-dot { width: 8px; height: 8px; background: var(--primary); border-radius: 50%; box-shadow: 0 0 10px var(--primary); animation: pulse 2s infinite; }

.lang-btn { background: none; border: 1px solid var(--border); color: #555; padding: 6px 12px; border-radius: 8px; cursor: pointer; transition: 0.3s; font-weight: bold; }
.lang-btn.active { color: white; border-color: var(--primary); background: rgba(0, 242, 255, 0.1); }

/* Header */
header { text-align: center; margin-bottom: 4rem; }
.main-logo { font-family: 'Space Grotesk', sans-serif; font-size: 5rem; letter-spacing: -3px; }
.glow-text { background: linear-gradient(135deg, var(--primary), var(--secondary)); -webkit-background-clip: text; -webkit-text-fill-color: transparent; filter: drop-shadow(0 0 20px rgba(0, 242, 255, 0.3)); }
.hero-subtitle { color: var(--text-dim); font-size: 1.2rem; margin-top: 10px; max-width: 600px; margin-inline: auto; }

/* Bento Grid */
.bento-grid {
    display: grid;
    grid-template-columns: repeat(3, 1fr);
    grid-auto-rows: minmax(280px, auto);
    gap: 1.5rem;
}

.card {
    background: var(--card-bg);
    border: 1px solid var(--border);
    border-radius: 28px;
    padding: 2.5rem;
    backdrop-filter: blur(10px);
    transition: all 0.4s cubic-bezier(0.23, 1, 0.32, 1);
    display: flex; flex-direction: column; position: relative;
    overflow: hidden;
}

.card:hover { transform: translateY(-8px); border-color: rgba(255,255,255,0.2); background: rgba(20, 20, 25, 0.8); box-shadow: 0 20px 40px rgba(0,0,0,0.4); }

/* Especial Card (zclaw) */
.featured-card {
    grid-column: span 2;
    background: linear-gradient(145deg, rgba(112, 0, 255, 0.1), rgba(0, 242, 255, 0.05));
    border: 1px solid rgba(112, 0, 255, 0.3);
}

.badge-official {
    position: absolute; top: 20px; right: 20px;
    background: white; color: black; padding: 5px 12px;
    border-radius: 50px; font-size: 0.6rem; font-weight: 900;
}

.icon-wrap {
    width: 55px; height: 55px; background: rgba(255,255,255,0.03);
    border-radius: 16px; display: flex; align-items: center; justify-content: center;
    font-size: 1.8rem; margin-bottom: 1.5rem; color: var(--primary);
}

.featured-icon { background: var(--primary); color: black; font-size: 2rem; box-shadow: 0 0 20px var(--primary); }

.card h2, .card h3 { font-size: 1.8rem; font-weight: 800; margin-bottom: 0.8rem; }
.card p { color: var(--text-dim); line-height: 1.6; margin-bottom: 2rem; font-size: 0.95rem; }

/* Buttons */
.btn-main {
    background: white; color: black; padding: 16px 30px;
    border-radius: 14px; text-decoration: none; font-weight: 900;
    display: flex; align-items: center; justify-content: center; gap: 10px;
    transition: 0.3s; margin-top: auto;
}
.btn-main:hover { background: var(--primary); transform: scale(1.05); }

.btn-glass {
    background: rgba(255,255,255,0.05); border: 1px solid var(--border);
    color: white; padding: 14px; border-radius: 14px; text-decoration: none;
    text-align: center; font-weight: 700; transition: 0.3s; margin-top: auto;
    display: flex; align-items: center; justify-content: center; gap: 8px;
}
.btn-glass:hover { background: white; color: black; }

/* Cores Adicionais */
.accent-text { color: var(--primary); }
.blue i { color: #3ddc84; }
.purple i { color: #7000ff; }
.green-hover:hover { background: #3ddc84 !important; color: black !important; }
.yellow-hover:hover { background: #ffb800 !important; color: black !important; }

footer { margin-top: 6rem; text-align: center; color: #444; border-top: 1px solid var(--border); padding: 3rem; }
.creator { color: var(--text-dim); font-weight: bold; }

@keyframes pulse { 0% { opacity: 1; } 50% { opacity: 0.3; } 100% { opacity: 1; } }

@media (max-width: 900px) {
    .bento-grid { grid-template-columns: 1fr; }
    .featured-card { grid-column: span 1; }
    .main-logo { font-size: 3.5rem; }
}