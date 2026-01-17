:root {
    --neon-blue: #00f2ff;
    --neon-purple: #bc13fe;
    --dark-res: #080808;
    --card-bg: #111111;
}

* { margin: 0; padding: 0; box-sizing: border-box; }

body {
    background: var(--dark-res);
    color: white;
    font-family: 'Inter', sans-serif;
    overflow-x: hidden;
}

/* Efeito de linhas de TV antiga */
.scanline {
    width: 100%; height: 100px; z-index: 10;
    background: linear-gradient(0deg, rgba(0,0,0,0) 0%, rgba(255,255,255,0.02) 50%, rgba(0,0,0,0) 100%);
    opacity: 0.1; position: fixed; bottom: 100%;
    animation: scanline 8s linear infinite; pointer-events: none;
}

@keyframes scanline { 0% { bottom: 100%; } 100% { bottom: -100px; } }

.cyber-bg {
    position: fixed; top: 0; width: 100%; height: 100%;
    background-image: 
        linear-gradient(rgba(18, 18, 18, 0.9) 1px, transparent 1px),
        linear-gradient(90deg, rgba(18, 18, 18, 0.9) 1px, transparent 1px);
    background-size: 30px 30px; z-index: -1;
}

.container { max-width: 1200px; margin: 0 auto; padding: 20px; }

/* Navbar */
.navbar {
    display: flex; justify-content: space-between; align-items: center;
    padding: 30px 0; border-bottom: 1px solid #222;
}

.brand { font-family: 'Syncopate', sans-serif; font-size: 1.2rem; letter-spacing: 5px; }
.brand span { color: var(--neon-blue); text-shadow: 0 0 10px var(--neon-blue); }

.nav-status { font-size: 0.7rem; font-weight: 900; letter-spacing: 2px; color: #444; }
.pulse { display: inline-block; width: 6px; height: 6px; background: #0f0; border-radius: 50%; margin-right: 10px; box-shadow: 0 0 10px #0f0; }

/* Hero */
.hero { text-align: center; padding: 80px 0; }
.hero h1 { font-family: 'Syncopate', sans-serif; font-size: 5vw; letter-spacing: -2px; margin-bottom: 10px; position: relative; }

.glitch {
    color: white;
    text-shadow: 2px 0 var(--neon-purple), -2px 0 var(--neon-blue);
}

.hero p { color: #666; font-size: 0.8rem; letter-spacing: 5px; font-weight: 700; }

/* Grid de Cards Cyberpunk */
.grid {
    display: grid;
    grid-template-columns: repeat(4, 1fr);
    gap: 20px;
}

.cyber-card {
    background: var(--card-bg);
    border: 1px solid #222;
    padding: 30px;
    position: relative;
    transition: 0.3s;
    overflow: hidden;
}

.featured {
    grid-column: span 2;
    grid-row: span 2;
    border-color: var(--neon-blue);
    background: linear-gradient(135deg, #111 0%, #050505 100%);
}

.cyber-card:hover {
    border-color: var(--neon-blue);
    transform: translateY(-5px);
    box-shadow: 0 0 30px rgba(0, 242, 255, 0.1);
}

.card-tag {
    position: absolute; top: 0; right: 0;
    background: #222; color: #888;
    padding: 5px 12px; font-size: 0.6rem; font-weight: 900;
}

.featured .card-tag { background: var(--neon-blue); color: black; }

.icon-bg {
    position: absolute; bottom: -20px; right: -20px;
    font-size: 8rem; opacity: 0.03; color: white;
}

.card-body h2 { font-family: 'Syncopate', sans-serif; font-size: 1.8rem; margin-bottom: 15px; }
.card-body h3 { font-size: 1.2rem; margin-bottom: 10px; color: var(--neon-blue); }
.card-body p { color: #888; font-size: 0.9rem; line-height: 1.6; margin-bottom: 25px; }

/* Buttons */
.cyber-btn {
    display: inline-block; width: 100%; padding: 20px;
    background: var(--neon-blue); color: black;
    text-decoration: none; font-weight: 900; text-align: center;
    clip-path: polygon(10% 0, 100% 0, 90% 100%, 0% 100%);
    transition: 0.3s;
}

.cyber-btn:hover {
    background: white;
    box-shadow: 0 0 20px white;
}

.mini-btn {
    display: inline-block; padding: 10px 20px;
    border: 1px solid #333; color: white;
    text-decoration: none; font-size: 0.7rem; font-weight: 900;
    transition: 0.3s;
}

.mini-btn:hover { background: white; color: black; }

footer {
    margin-top: 100px; padding: 40px;
    text-align: center; font-size: 0.6rem;
    color: #333; letter-spacing: 3px; border-top: 1px solid #222;
}

@media (max-width: 900px) {
    .grid { grid-template-columns: 1fr; }
    .featured { grid-column: span 1; }
    .hero h1 { font-size: 10vw; }
}
