* { box-sizing: border-box; }
html { scroll-behavior: smooth; }
body {
  margin: 0;
  font-family: "Segoe UI", Tahoma, Geneva, Verdana, sans-serif;
  background: #f4f7fb;
  color: #0f172a;
}

a { text-decoration: none; color: inherit; }
img { max-width: 100%; display: block; }
input, select, button { font: inherit; }

:root {
  --bg: #f4f7fb;
  --surface: #ffffff;
  --surface-soft: #eef4ff;
  --surface-dark: #101827;
  --text: #0f172a;
  --muted: #64748b;
  --line: #e2e8f0;
  --primary: #0f766e;
  --primary-strong: #0b5e57;
  --secondary: #f97316;
  --accent: #2563eb;
  --success: #15a46a;
  --warning: #f59e0b;
  --shadow: 0 22px 55px rgba(15, 23, 42, 0.09);
  --radius: 24px;
}

body.dark {
  --bg: #071421;
  --surface: rgba(15, 23, 42, 0.96);
  --surface-soft: rgba(15, 23, 42, 0.82);
  --text: #f8fafc;
  --muted: #cbd5e1;
  --line: rgba(148, 163, 184, 0.14);
  --primary: #2dd4bf;
  --primary-strong: #99f6e4;
  --secondary: #fb923c;
  --accent: #60a5fa;
  --success: #34d399;
  --shadow: 0 24px 55px rgba(2, 6, 23, 0.45);
  background: var(--bg);
  color: var(--text);
}

.container {
  width: min(1180px, calc(100% - 32px));
  margin-inline: auto;
}

.topbar {
  position: sticky;
  top: 0;
  z-index: 100;
  background: rgba(255,255,255,0.82);
  backdrop-filter: blur(18px);
  border-bottom: 1px solid rgba(148,163,184,0.15);
}

body.dark .topbar {
  background: rgba(15, 23, 42, 0.82);
}

.topbar-inner {
  min-height: 80px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 20px;
}

.brand-wrap {
  display: flex;
  align-items: center;
  gap: 12px;
}

.brand-mark {
  width: 44px;
  height: 44px;
  border-radius: 14px;
  background: linear-gradient(135deg, var(--primary), var(--accent));
  display: grid;
  place-items: center;
  color: white;
  font-size: 1.2rem;
  font-weight: 800;
  box-shadow: var(--shadow);
}

.brand-name {
  font-weight: 800;
  letter-spacing: -0.04em;
}

.brand-wrap small {
  color: var(--muted);
  display: block;
}

.main-nav {
  display: flex;
  align-items: center;
  gap: 8px;
}

.main-nav a {
  padding: 10px 14px;
  border-radius: 10px;
  color: var(--muted);
  font-weight: 700;
  transition: 0.2s ease;
}

.main-nav a.active,
.main-nav a:hover {
  background: rgba(15,118,110,0.08);
  color: var(--primary-strong);
}

.header-tools {
  display: flex;
  align-items: center;
  gap: 12px;
}

.ghost-btn,
.primary-btn,
.secondary-btn,
.small-btn,
.filter-bar button {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  border-radius: 14px;
  font-weight: 700;
  transition: transform 0.2s ease;
}

.ghost-btn {
  background: rgba(15,118,110,0.08);
  color: var(--primary-strong);
  padding: 10px 16px;
}

.primary-btn {
  background: linear-gradient(135deg, var(--secondary), #f59e0b);
  color: white;
  padding: 14px 22px;
  box-shadow: 0 18px 30px rgba(249,115,22,0.24);
}

.secondary-btn {
  background: rgba(255,255,255,0.06);
  border: 1px solid rgba(255,255,255,0.2);
  color: white;
  padding: 14px 22px;
}

.small-btn {
  background: var(--primary);
  color: white;
  padding: 10px 14px;
  border-radius: 10px;
  font-size: 0.8rem;
}

.ghost-btn:hover,
.primary-btn:hover,
.secondary-btn:hover,
.small-btn:hover,
.filter-bar button:hover {
  transform: translateY(-1px);
}

.language-switch {
  display: flex;
  align-items: center;
  gap: 6px;
  background: rgba(15, 118, 110, 0.05);
  padding: 5px;
  border-radius: 999px;
}

.language-switch a {
  color: var(--muted);
  padding: 8px 10px;
  border-radius: 999px;
  font-size: 0.72rem;
  font-weight: 700;
}

.language-switch a:hover {
  background: rgba(15,118,110,0.08);
  color: var(--primary-strong);
}

.hero-section {
  padding-top: 30px;
  padding-bottom: 28px;
  display: grid;
  grid-template-columns: 1.3fr 0.9fr;
  gap: 24px;
  align-items: stretch;
}

.hero-copy {
  background: linear-gradient(135deg, #0f172a 0%, #0b5e57 48%, #0d9488 100%);
  border-radius: 30px;
  padding: 36px 30px;
  color: white;
  box-shadow: var(--shadow);
}

.eyebrow {
  display: inline-block;
  background: rgba(255,255,255,0.08);
  border: 1px solid rgba(255,255,255,0.18);
  border-radius: 999px;
  padding: 8px 14px;
  font-size: 0.76rem;
  letter-spacing: 0.08em;
  text-transform: uppercase;
  margin-bottom: 16px;
}

.hero-copy h1 {
  margin: 0 0 18px;
  font-size: clamp(2.2rem, 4vw, 3.8rem);
  line-height: 1.04;
  letter-spacing: -0.06em;
}

.hero-copy p {
  margin: 0;
  color: rgba(255,255,255,0.78);
  max-width: 620px;
  line-height: 1.7;
}

.search-box {
  display: flex;
  align-items: center;
  gap: 10px;
  background: rgba(255,255,255,0.08);
  padding: 10px 12px 10px 10px;
  border-radius: 18px;
  border: 1px solid rgba(255,255,255,0.15);
  margin-top: 22px;
}

.search-box input {
  flex: 1;
  background: transparent;
  border: none;
  font-size: 0.98rem;
  color: white;
  outline: none;
}

.search-box input::placeholder {
  color: rgba(255,255,255,0.7);
}

.search-box button,
.filter-bar button {
  border: none;
  background: linear-gradient(135deg, var(--secondary), #f59e0b);
  color: white;
  padding: 12px 18px;
  border-radius: 12px;
  cursor: pointer;
}

.hero-actions {
  display: flex;
  align-items: center;
  gap: 14px;
  flex-wrap: wrap;
  margin-top: 28px;
}

.mini-stats {
  margin-top: 26px;
  display: grid;
  grid-template-columns: repeat(3, minmax(0,1fr));
  gap: 16px;
}

.mini-stats div {
  padding: 16px 12px;
  border-radius: 18px;
  background: rgba(255,255,255,0.08);
  border: 1px solid rgba(255,255,255,0.12);
}

.mini-stats strong,
.mini-stats span {
  display: block;
}

.mini-stats strong {
  font-size: 1.25rem;
  margin-bottom: 4px;
}

.mini-stats span {
  color: rgba(255,255,255,0.75);
  font-size: 0.8rem;
}

.hero-visual {
  display: flex;
  flex-direction: column;
  gap: 18px;
}

.spotlight-card {
  background: var(--surface);
  border: 1px solid var(--line);
  border-radius: 28px;
  box-shadow: var(--shadow);
  padding: 22px;
}

.spotlight-card.large {
  background: linear-gradient(135deg, #fff7ed, #fef3c7 55%, #fff7ed);
  min-height: 260px;
}

.spotlight-card.small {
  background: linear-gradient(135deg, #ecfeff, #dbeafe 60%, #eff6ff);
  min-height: 150px;
}

.tiny-tag {
  display: inline-block;
  background: rgba(15,118,110,0.09);
  color: var(--primary-strong);
  border-radius: 999px;
  padding: 8px 10px;
  font-size: 0.75rem;
  font-weight: 700;
}

.spotlight-card h3,
.spotlight-card h4 {
  margin: 18px 0 8px;
}

.spotlight-card p {
  margin: 0;
  color: var(--muted);
  line-height: 1.7;
}

.category-section,
.deals-section,
.stores-section {
  margin-top: 28px;
}

.section-heading {
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 12px;
  margin-bottom: 20px;
}

.section-heading h2 {
  margin: 0;
  font-size: clamp(1.5rem, 2vw, 2.3rem);
  letter-spacing: -0.04em;
}

.section-heading a {
  color: var(--primary-strong);
  font-weight: 700;
}

.category-grid {
  display: grid;
  grid-template-columns: repeat(6, minmax(0, 1fr));
  gap: 16px;
}

.category-card {
  background: var(--surface);
  border: 1px solid var(--line);
  border-radius: 20px;
  padding: 18px 14px;
  display: grid;
  place-items: center;
  gap: 10px;
  min-height: 120px;
  box-shadow: 0 12px 24px rgba(15,23,42,0.04);
}

.category-card span {
  font-size: 2rem;
}

.category-card strong {
  font-size: 0.92rem;
}

.deal-grid {
  display: grid;
  grid-template-columns: repeat(4, minmax(0, 1fr));
  gap: 22px;
}

.large-grid {
  grid-template-columns: repeat(3, minmax(0, 1fr));
}

.deal-card {
  background: var(--surface);
  border: 1px solid var(--line);
  border-radius: var(--radius);
  overflow: hidden;
  box-shadow: 0 18px 30px rgba(15,23,42,0.05);
  transition: transform 0.2s ease, box-shadow 0.2s ease;
}

.deal-card:hover {
  transform: translateY(-4px);
  box-shadow: 0 28px 45px rgba(15,23,42,0.08);
}

.deal-image-wrap {
  position: relative;
  display: block;
  overflow: hidden;
}

.deal-image-wrap img {
  width: 100%;
  height: 240px;
  object-fit: cover;
}

.deal-badge {
  position: absolute;
  top: 16px;
  right: 16px;
  background: linear-gradient(135deg, var(--secondary), #f59e0b);
  color: white;
  border-radius: 12px;
  padding: 8px 10px;
  font-weight: 800;
  box-shadow: 0 15px 25px rgba(249,115,22,0.25);
}

.deal-body {
  padding: 18px;
}

.deal-card-top {
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 10px;
  margin-bottom: 12px;
}

.store-tag,
.live-tag {
  display: inline-flex;
  align-items: center;
  justify-content: center;
  border-radius: 999px;
  font-size: 0.7rem;
  font-weight: 800;
  padding: 7px 10px;
}

.store-tag {
  background: rgba(15,118,110,0.08);
  color: var(--primary-strong);
}

.live-tag {
  background: rgba(21,164,106,0.11);
  color: var(--success);
}

.deal-body h3 {
  margin: 0;
  font-size: 1.2rem;
  line-height: 1.4;
}

.price-row {
  display: flex;
  align-items: center;
  gap: 12px;
  margin-top: 16px;
}

.price-row strong {
  font-size: 1.4rem;
  color: var(--primary-strong);
}

.price-row del {
  color: var(--muted);
}

.deal-footer {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 12px;
  margin-top: 18px;
  color: var(--muted);
  font-size: 0.8rem;
}

.store-grid {
  display: grid;
  grid-template-columns: repeat(3, minmax(0, 1fr));
  gap: 22px;
}

.large-store-grid {
  grid-template-columns: repeat(3, minmax(0, 1fr));
}

.store-card {
  background: var(--surface);
  border: 1px solid var(--line);
  border-radius: 24px;
  padding: 24px 22px 18px;
  box-shadow: 0 18px 32px rgba(15,23,42,0.04);
  position: relative;
  display: block;
}

.store-badge {
  position: absolute;
  top: 16px;
  right: 16px;
  background: rgba(37,99,235,0.09);
  color: var(--accent);
  padding: 8px 10px;
  border-radius: 999px;
  font-size: 0.7rem;
  font-weight: 800;
}

.store-logo {
  width: 58px;
  height: 58px;
  border-radius: 18px;
  background: linear-gradient(135deg, var(--primary), var(--accent));
  display: grid;
  place-items: center;
  color: white;
  font-size: 1.4rem;
  font-weight: 800;
  margin-bottom: 16px;
}

.store-card h3 {
  margin: 0 0 10px;
  font-size: 1.3rem;
}

.store-card p {
  margin: 0;
  color: var(--muted);
  line-height: 1.7;
}

.store-meta {
  display: flex;
  justify-content: space-between;
  gap: 10px;
  margin-top: 18px;
  color: var(--muted);
  font-size: 0.8rem;
}

.feature-strip {
  margin-top: 34px;
  display: grid;
  grid-template-columns: repeat(3, minmax(0,1fr));
  gap: 18px;
  padding-bottom: 50px;
}

.feature-item {
  background: var(--surface);
  border: 1px solid var(--line);
  border-radius: 20px;
  padding: 20px;
  display: flex;
  align-items: center;
  gap: 14px;
}

.feature-icon {
  width: 54px;
  height: 54px;
  border-radius: 16px;
  background: rgba(15,118,110,0.08);
  display: grid;
  place-items: center;
  font-size: 1.4rem;
}

.feature-item strong,
.feature-item span {
  display: block;
}

.feature-item span {
  color: var(--muted);
  font-size: 0.82rem;
}

.site-footer {
  background: rgba(255,255,255,0.7);
  border-top: 1px solid var(--line);
  padding: 26px 0 40px;
}

body.dark .site-footer {
  background: rgba(15, 23, 42, 0.8);
}

.footer-inner {
  display: flex;
  justify-content: space-between;
  align-items: center;
  gap: 20px;
}

.footer-inner p {
  margin: 6px 0 0;
  color: var(--muted);
}

.footer-links {
  display: flex;
  align-items: center;
  gap: 16px;
  color: var(--muted);
}

.page-main {
  padding-top: 30px;
  padding-bottom: 60px;
}

.list-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  gap: 16px;
  margin-bottom: 24px;
}

.list-header h1 {
  margin: 0;
  font-size: clamp(2rem, 3vw, 3rem);
  letter-spacing: -0.05em;
}

.filter-bar {
  display: grid;
  grid-template-columns: 1.5fr 0.7fr auto;
  gap: 12px;
  background: var(--surface);
  border: 1px solid var(--line);
  border-radius: 18px;
  padding: 14px;
  margin-bottom: 26px;
  box-shadow: 0 14px 26px rgba(15,23,42,0.04);
}

.filter-bar input,
.filter-bar select {
  background: rgba(148,163,184,0.04);
  border: 1px solid var(--line);
  border-radius: 12px;
  padding: 13px 14px;
  color: var(--text);
  outline: none;
}

.empty-state {
  background: var(--surface);
  border: 1px dashed var(--line);
  border-radius: 18px;
  color: var(--muted);
  padding: 28px;
  text-align: center;
  grid-column: 1 / -1;
}

.wide {
  grid-column: 1 / -1;
}

@media (max-width: 980px) {
  .hero-section {
    grid-template-columns: 1fr;
  }

  .category-grid {
    grid-template-columns: repeat(3, minmax(0, 1fr));
  }

  .deal-grid,
  .store-grid,
  .feature-strip {
    grid-template-columns: repeat(2, minmax(0,1fr));
  }
}

@media (max-width: 720px) {
  .main-nav { display: none; }
  .deal-grid,
  .store-grid,
  .feature-strip,
  .category-grid,
  .mini-stats,
  .filter-bar {
    grid-template-columns: 1fr;
  }

  .filter-bar {
    display: grid;
  }

  .topbar-inner,
  .list-header,
  .footer-inner {
    flex-direction: column;
    align-items: flex-start;
  }

  .search-box {
    flex-direction: column;
    align-items: stretch;
  }

  .search-box button {
    width: 100%;
  }
}

@media (max-width: 540px) {
  .hero-copy { padding: 24px 18px; }
  .deal-image-wrap img { height: 220px; }
  .language-switch { display: none; }
  .section-heading { align-items: flex-start; flex-direction: column; }
}
