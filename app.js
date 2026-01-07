// Dados de exemplo — substitua/expanda conforme necessário.
// Cada jogo tem: id, title, platform, genres (array), description, updated, codes (array of {title, text})
const GAMES = [
  {
    id: "elden-ring",
    title: "Elden Ring",
    platform: "PC/PS/Xbox",
    genres: ["RPG", "Ação"],
    description: "Códigos e trainers para Elden Ring (exemplos).",
    updated: "2026-01-05",
    codes: [
      { title: "God Mode (exemplo)", text: "// Ativar invencibilidade\nplayer.invincible = true;" },
      { title: "MAX Runes", text: "// Adicionar runas\nplayer.runes += 999999;" }
    ]
  },
  {
    id: "fifa-26",
    title: "FIFA 26",
    platform: "PC/PS/Xbox",
    genres: ["Esportes"],
    description: "Códigos de mutators e ajustes para partidas locais.",
    updated: "2025-12-20",
    codes: [
      { title: "Desbloquear todos os kits", text: "unlockAllKits();" },
    ]
  },
  {
    id: "cs2",
    title: "Counter-Strike 2",
    platform: "PC",
    genres: ["FPS", "Multiplayer"],
    description: "Comandos e scripts úteis.",
    updated: "2026-01-03",
    codes: [
      { title: "Bunnyhop script", text: "bind mwheel_up +jump" },
      { title: "Radar always", text: "cl_radar_always_centered 1" }
    ]
  },
  {
    id: "stardew",
    title: "Stardew Valley",
    platform: "PC/Switch",
    genres: ["Indie", "Simulação"],
    description: "Códigos para modificar inventário e relações.",
    updated: "2025-11-11",
    codes: [
      { title: "Adicionar 9999 ouro", text: "player.money = 9999" }
    ]
  }
];

// ---------- RENDER ----------
const tabsEl = document.getElementById('tabs');
const gamesEl = document.getElementById('games');
const searchEl = document.getElementById('search');
const emptyEl = document.getElementById('empty');

let activeTab = 'Todos';

// Gera lista de abas a partir dos gêneros e plataformas
function buildTabs(){
  const set = new Set();
  set.add('Todos');
  GAMES.forEach(g => {
    g.genres.forEach(gg => set.add(gg));
    set.add(g.platform);
  });

  tabsEl.innerHTML = '';
  Array.from(set).forEach(name => {
    const btn = document.createElement('button');
    btn.className = 'tab' + (name === activeTab ? ' active' : '');
    btn.textContent = name;
    btn.onclick = () => {
      activeTab = name;
      document.querySelectorAll('.tab').forEach(t=>t.classList.remove('active'));
      btn.classList.add('active');
      render();
    };
    tabsEl.appendChild(btn);
  });
}

// Render dos cards filtrados
function render(){
  const q = searchEl.value.trim().toLowerCase();
  const filtered = GAMES.filter(g => {
    const inTab = activeTab === 'Todos' || g.genres.includes(activeTab) || g.platform === activeTab;
    const inQuery = !q || (
      g.title.toLowerCase().includes(q) ||
      g.description.toLowerCase().includes(q) ||
      g.genres.join(' ').toLowerCase().includes(q) ||
      g.platform.toLowerCase().includes(q) ||
      g.codes.some(c => c.title.toLowerCase().includes(q) || c.text.toLowerCase().includes(q))
    );
    return inTab && inQuery;
  });

  gamesEl.innerHTML = '';
  if(filtered.length === 0){
    emptyEl.hidden = false;
    return;
  } else {
    emptyEl.hidden = true;
  }

  const template = document.getElementById('game-card');
  const codeTemplate = document.getElementById('code-block');

  filtered.forEach(game => {
    const el = template.content.cloneNode(true);
    const article = el.querySelector('article.card');
    el.querySelector('.game-title').textContent = game.title;
    el.querySelector('.platform').textContent = game.platform;
    const ttime = el.querySelector('.updated');
    ttime.textContent = `Atualizado: ${game.updated}`;
    ttime.setAttribute('datetime', game.updated);
    el.querySelector('.game-desc').textContent = game.description;

    const tags = el.querySelector('.tags');
    game.genres.forEach(g => {
      const span = document.createElement('span');
      span.className = 'tag';
      span.textContent = g;
      tags.appendChild(span);
    });

    const btnShow = el.querySelector('.show-codes');
    const codesWrap = el.querySelector('.codes');

    // Popular códigos
    game.codes.forEach(c => {
      const cb = codeTemplate.content.cloneNode(true);
      cb.querySelector('.code-title').textContent = c.title;
      cb.querySelector('.code-content').textContent = c.text;
      cb.querySelector('.copy-code').addEventListener('click', () => {
        copyText(c.text);
      });
      codesWrap.appendChild(cb);
    });

    // copiar todos
    el.querySelector('.copy-all').addEventListener('click', () => {
      const all = game.codes.map(c => `== ${c.title} ==\n${c.text}`).join('\n\n');
      copyText(all);
    });

    btnShow.addEventListener('click', () => {
      const opened = !codesWrap.hidden;
      codesWrap.hidden = opened;
      btnShow.textContent = opened ? 'Mostrar Códigos' : 'Ocultar Códigos';
      // Smooth scroll into view when opened
      if(!opened) article.scrollIntoView({behavior:'smooth', block:'center'});
    });

    gamesEl.appendChild(el);
  });
}

// Copiar para clipboard com feedback simples
async function copyText(text){
  try{
    await navigator.clipboard.writeText(text);
    // feedback mínimo: usar alert ou criar um pequeno toast. Aqui usamos alert por compatibilidade.
    showToast('Copiado para a área de transferência ✅');
  }catch(e){
    showToast('Não foi possível copiar. Use Ctrl+C.');
  }
}

// Toast simples
let toastTimer;
function showToast(msg){
  let toast = document.getElementById('cg-toast');
  if(!toast){
    toast = document.createElement('div');
    toast.id = 'cg-toast';
    toast.style.position = 'fixed';
    toast.style.right = '20px';
    toast.style.bottom = '20px';
    toast.style.background = 'linear-gradient(90deg,var(--accent),var(--accent-2))';
    toast.style.color = '#fff';
    toast.style.padding = '10px 14px';
    toast.style.borderRadius = '10px';
    toast.style.boxShadow = '0 8px 24px rgba(0,0,0,0.4)';
    toast.style.zIndex = 9999;
    document.body.appendChild(toast);
  }
  toast.textContent = msg;
  toast.style.opacity = '1';
  clearTimeout(toastTimer);
  toastTimer = setTimeout(()=> { toast.style.opacity = '0'; }, 2400);
}

// Eventos
searchEl.addEventListener('input', () => render());

// Inicialização
buildTabs();
render();
