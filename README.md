# Backend - HaveASeat Sagra

## Spis treści
- [Przeznaczenie i technologia](#przeznaczenie-i-technologia)
- [Setup i baza danych](#setup-i-baza-danych)
- [Mapa i biurka](#mapa-i-biurka)
- [Wzorzec projektowy](#wzorzec-projektowy)
- [Inne informacje](#inne-informacje)

## Przeznaczenie i technologia
Część backendowa aplikacji umożliwiającej rezerwację stanowisk pracy w biurze. Projekt zrealizowany w ASP.NET Core, C#, z pomocą poniższych paczek NuGet:
- Microsoft.AspNetCore.OpenApi (7.0.17)
- Microsoft.EntityFrameworkCore (7.0.0)
- Microsoft.EntityFrameworkCore.Tools (7.0.0)
- Microsoft.VisualStudio.Web.CodeGeneration.Design (8.0.3)
- Npgsql.EntityFrameworkCore.PostgreSQL (7.0.0)
- Swashbuckle.AspNetCore (6.5.0)
- BCrypt.Net-Next (4.0.3)  \
Wykorzystane środowisko programistyczne: JetBrains Rider
Baza danych: PostgreSQL, Docker

## Setup i baza danych
### Setup
Baza danych have-a-db oparta jest o technologię PostgreSQL i znajduje się w kontenerze Docker z pliku docker-compose.yaml. Do zarządzania kontenerami najlepiej pobrać Docker Desktop. Aby utworzyć i uruchomić kontener, należy otworzyć wiersz poleceń w folderze, w którym znajduje się plik i wykonać komendę:
```bash 
docker compose up
```
Komendy SQL można wykonać po wpisaniu:
```bash
docker exec -it HaveASeat psql -U postgres -d have-a-db
```
Więcej o PSQL: https://www.postgresguide.com/utilities/psql/ 

### Struktura bazy danych
Tabele w bazie danych generowane są na podstawie encji (Entities/). 

**Area** - wymiary mapy, czyli wysokość i szerokość (1 jednostka = bok biurka), jeden rekord

**Cell** - pojedyncza komórka mapy, ma zdefiniowane położenie (PositionX, PositionY) oraz kontur, czyli ścianę na mapie. Tabela połączona jest relacją n:1 z tabelą Room (pokojami).

**Desk** - pojedyncze biurko, określone jest położenie (PositionX, PositionY) oraz pozycja krzesła przy biurku (ChairPosition) opisane typem wyliczeniowym ChairPosition, w którym: \
0 - TOP - krzesło **nad** biurkiem \
1 - RIGHT - krzesło na **prawo** od biurka (biurko skierowane w lewo) \
2 - BOTTOM - krzesło **pod** biurkiem \
3 - LEFT - krzesło na **lewo** od biurka (biurko skierowane w prawo) \
Tabela połączona jest relacją n:1 z tabelą Room (pokojami).

**Room** - pokój, zawiera nazwę pokoju

**User** - użytkownik systemu identyfikowany mailem, posiada hasło oraz rolę opisaną typem wyliczeniowym Role, gdzie: 0 - ADMIN - Administrator systemu; 1 - EMPLOYEE - Pracownik, użytkownik systemu

**Reservation** - rezerwacja, dane biurko (DeskId) przypisane jest do użytkownika (UserId) na dany dzień (Date). Występują relacje n:1 z Desk i n:1 z User.

## Mapa i biurka
Kod zapisujący do bazy danych wszystkie pokoje i komórki mapy jest w pliku Seeders/MapSeeder.cs. W Program.cs wywoływana jest metoda SeepMap() statycznej klasy MapSeeder. Statyczna klasa Border reprezentuje kontur danej komórki, czyli ścianę na mapie. Do każdego z pól klasy przypisana jest wartość atrybutu css box-shadow, określająca po której stronie występuje kontur.

Przykład: \
```Border.Left = “-4px 0px 0px 0px black“``` — kontur komórki jest linią ciągłą po lewej stronie \
```Border.TopRight = “2px -2px 0px 2px black“``` — kontur komórki jest linią ciągłą po na górze i po prawej stronie komórki

Zapisywanie biurek odbywa się za sprawą metody SeedDesks() klasy statycznej DeskSeeder z pliku Seeders/DeskSeeder.cs w oparciu o encję Desk (Entities/Desk.cs) i jej relację 1:n z Room (Entities/Room.cs). Wywoływana jest w Program.cs. 

Wywołanie SeedDesk() i SeedMap() w Program.cs
```cs
app.SeedMap();
app.SeedDesks();
```

## Wzorzec projektowy
Projekt realizowany jest zgodnie ze [wzorcem projektowym Repozytorium (Repository)](https://learn.microsoft.com/pl-pl/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application). \
Każde repozytorium podzielone jest na interfejs i klasę po nim dziedziczącą. Implementacje repozytoriów znajdują się w folderze ***Repositories***, natomiast ich interfejsy w **Repositories/Interfaces**. W projekcie zastosowane jest podejście asynchroniczne, dlatego wykorzystywana jest klasa **Task**. 

Read more: [All you need to know about Task in C#](https://medium.com/@iamprovidence/all-you-need-to-know-about-task-in-c-2dce9e52c0f7)

## Inne informacje
Projekt powstał w ramach praktyk zawodowych uczniów SCI w Sagra Technology Sp. z o.o. Backend ukończony w lipcu 2024 roku.
