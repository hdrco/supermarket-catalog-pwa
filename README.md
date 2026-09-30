# Supermarket Catalog PWA

پڕۆژەیەکی ASP.NET Core 8 Razor Pages بۆ پیشاندانی تخفیفەکانی سوپرمارکەتەکان.

## تایبەتمەندی
- کوردی، عەرەبی و ئینگلیزی
- RTL/LTR، Dark Mode
- PWA: manifest، service worker و دامەزراندن لە مۆبایل
- لیستی تخفیف و پنلی بەڕێوەبردن
- زیادکردنی تخفیف لە `/Admin/New`
- SQLite و seed data بۆ تاقیکردنەوە

## اجرا
```bash
dotnet restore
dotnet run
```
پاشان `/` و `/Admin` بکەرەوە. بۆ production پێویستە authentication، upload storage و payment gateway بە environment secrets زیاد بکرێن.