@page
@model SupermarketCatalog.Pages.DealsModel
@{
    var lang = Model.Lang;
    var dir = Model.Dir;
}
<!doctype html>
<html lang="@lang" dir="@dir">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Deals</title>
    <link rel="stylesheet" href="/css/site.css" />
</head>
<body class="list-page">
    <header class="topbar premium-topbar">
        <div class="container topbar-inner">
            <div class="brand-wrap">
                <div class="brand-mark">M</div>
                <div>
                    <div class="brand-name">MarketHub</div>
                    <small>Latest offers</small>
                </div>
            </div>

            <nav class="main-nav">
                <a href="/">Home</a>
                <a class="active" href="/Deals">Deals</a>
                <a href="/Stores">Stores</a>
                <a href="/About">About</a>
            </nav>

            <div class="header-tools">
                <a class="ghost-btn" href="/">Home</a>
                <div class="language-switch">
                    <a href="/Deals?lang=ku">KUR</a>
                    <a href="/Deals?lang=ar">AR</a>
                    <a href="/Deals?lang=en">EN</a>
                </div>
            </div>
        </div>
    </header>

    <main class="container page-main">
        <section class="list-header">
            <div>
                <div class="eyebrow">Fresh discounts</div>
                <h1>All current deals</h1>
            </div>
            <a class="primary-btn" href="/">Back home</a>
        </section>

        <form class="filter-bar" method="get" action="/Deals">
            <input type="text" name="q" value="@Model.SearchTerm" placeholder="Search by product, store, or keyword" />
            <select name="category">
                <option value="">All categories</option>
                <option value="Groceries" selected="@(Model.Category == "Groceries")">Groceries</option>
                <option value="Home" selected="@(Model.Category == "Home")">Home</option>
                <option value="Electronics" selected="@(Model.Category == "Electronics")">Electronics</option>
                <option value="Fashion" selected="@(Model.Category == "Fashion")">Fashion</option>
                <option value="Bakery" selected="@(Model.Category == "Bakery")">Bakery</option>
                <option value="Drinks" selected="@(Model.Category == "Drinks")">Drinks</option>
            </select>
            <button type="submit">Filter</button>
        </form>

        <div class="deal-grid large-grid">
            @if (!Model.Deals.Any())
            {
                <div class="empty-state wide">No deals match your search.</div>
            }
            else
            {
                @foreach (var deal in Model.Deals)
                {
                    <article class="deal-card">
                        <a href="/Deal/@deal.Id?lang=@lang" class="deal-image-wrap">
                            <img src="@deal.ImageUrl" alt="@Model.Title(deal)" />
                            <span class="deal-badge">-@deal.Discount%</span>
                        </a>

                        <div class="deal-body">
                            <div class="deal-card-top">
                                <span class="store-tag">@deal.Store?.GetName(lang)</span>
                                <span class="live-tag">@deal.Category</span>
                            </div>

                            <h3>@Model.Title(deal)</h3>

                            <div class="price-row">
                                <strong>@deal.Price.ToString("N0") IQD</strong>
                                <del>@deal.OldPrice.ToString("N0") IQD</del>
                            </div>

                            <div class="deal-footer">
                                <span>Ends @deal.ExpiresAt.ToString("dd MMM yyyy")</span>
                                <a href="/Deal/@deal.Id?lang=@lang" class="small-btn">View</a>
                            </div>
                        </div>
                    </article>
                }
            }
        </div>
    </main>
</body>
</html>
