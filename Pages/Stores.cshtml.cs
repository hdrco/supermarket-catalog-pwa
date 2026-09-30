@page
@model SupermarketCatalog.Pages.StoresModel
@{
    var lang = Model.Lang;
    var dir = Model.Dir;
}
<!doctype html>
<html lang="@lang" dir="@dir">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Stores</title>
    <link rel="stylesheet" href="/css/site.css" />
</head>
<body class="list-page">
    <header class="topbar premium-topbar">
        <div class="container topbar-inner">
            <div class="brand-wrap">
                <div class="brand-mark">M</div>
                <div>
                    <div class="brand-name">MarketHub</div>
                    <small>Trusted stores</small>
                </div>
            </div>

            <nav class="main-nav">
                <a href="/">Home</a>
                <a href="/Deals">Deals</a>
                <a class="active" href="/Stores">Stores</a>
                <a href="/About">About</a>
            </nav>

            <div class="header-tools">
                <a class="ghost-btn" href="/">Home</a>
            </div>
        </div>
    </header>

    <main class="container page-main">
        <section class="list-header">
            <div>
                <div class="eyebrow">Trusted brands</div>
                <h1>Stores in Iraq</h1>
            </div>
            <a class="primary-btn" href="/Deals">View deals</a>
        </section>

        <div class="store-grid large-store-grid">
            @foreach (var store in Model.Stores)
            {
                <a href="/Store/@store.Id?lang=@lang" class="store-card featured-store">
                    <div class="store-badge">@store.Rating?.ToString("0.0")/5</div>
                    <div class="store-logo">@((store.Name.Length > 0 ? store.Name[0].ToString().ToUpperInvariant() : "S"))</div>
                    <h3>@store.GetName(lang)</h3>
                    <p>@store.GetDescription(lang)</p>
                    <div class="store-meta">
                        <span>@store.Deals.Count deals</span>
                        <span>
                            @(store.IsVerified ? "Verified" : "New")
                        </span>
                    </div>
                </a>
            }
        </div>
    </main>
</body>
</html>
