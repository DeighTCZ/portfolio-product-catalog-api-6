# product-catalog-db

## Popis

Tento projekt slouží pro správu databázové struktury. Obsahuje skripty pro schémata a tabulky. Dále obsahuje postdeploy skript pro naplnění tabulek výchozími daty.

## Spuštění

Tento projekt je nutno vypublikovat do vybraného databázového stroje, čož provede založení db a naplnění daty.

## Výchozí data

Výchozí data byla vygenerována z <https://www.mockaroo.com/>

### postdeploy.1 Naplnění produktů [^1] [^2]

``` curl
curl "https://api.mockaroo.com/api/48711c50?count=1000&key=26416e60" > "portfolio-catalog-init-data.sql"
```

[^1] Curl script je vázaný na můj účet nepůjde ho pustit komukoliv.
[^2] Vygenerovaný script byl pročištěn tak, aby nezpůsoboval porušení unikátnosti slupce product_name
