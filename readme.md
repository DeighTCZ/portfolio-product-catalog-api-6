# Produktový katalog

## Popis

Tato sollution slouží jako api pro přístup k produktům.

## product-catalog-db

Tento projekt slouží pro správu databázové struktury. Obsahuje skripty pro schémata a tabulky. Dále obsahuje postdeploy skript pro naplnění tabulek výchozími daty.

### Spuštění db

Tento projekt je nutno vypublikovat do vybraného databázového stroje, čož provede založení db a naplnění daty.

### Výchozí data

Výchozí data byla vygenerována z <https://www.mockaroo.com/>

#### postdeploy.1 Naplnění produktů [^1] [^2]

``` curl
curl "https://api.mockaroo.com/api/48711c50?count=1000&key=26416e60" > "portfolio-catalog-init-data.sql"
```

[^1] Curl script je vázaný na můj účet nepůjde ho pustit komukoliv.
[^2] Vygenerovaný script byl pročištěn tak, aby nezpůsoboval porušení unikátnosti slupce product_name

## product-catalog-api

Tento projekt je spustitelná aplikace ve formě api pro přístup k produktům.

### Spuštění api

Projekt lze spustit v IDE nebo jako vypublikovanou verzi pod IIS. Popřípadě při drobné úprave jako aplikaci, nebo službu běžící pod Kestrel serverem.

## product-catalog-data-access

Tento projekt slouží jako přístupová vrstva k datům. Obsahuje interfacy pro využití v repository paternu.
Projekt obsahuje 2 implementace. Entity framework pro přístup k datům v živých prostředí. Mock pro testovací účely.

### Entity Framework

Jedná se o vygenerovaný kontext z databázového projektu product-catalog-db.

### Mock

Jednoduchá implementace privátního listu v dané implementaci.

## product-catalog-data-model

Tento projekt slouží jako datový model pro využití v api.

## Postup spuštění aplikace

Nejprve je nutno provést publikaci DB popsané v kapitole *Spuštění db*.

## Testy

Sollution obsahuje momentálně 2 testovací projekty oba v sollution folder *Tests*.

### Spuštění testů

Testy lze spustit v IDE nebo následujícím příkazem v terminálu.

``` shell
dotnet test
```
