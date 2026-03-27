# Wypożyczalnia Sprzętu

## Opis projektu

Aplikacja konsolowa w języku C#, która obsługuje uczelnianą wypożyczalnię sprzętu.  
System pozwala na:

- dodanie nowego użytkownika do systemu.
- dodanie nowego sprzętu danego typu.
- wyświetlenie listy całego sprzętu z aktualnym statusem.
- wyświetlenie wyłącznie sprzętu dostępnego do wypożyczenia.
- wypożyczenie sprzętu użytkownikowi.
- zwrot sprzętu wraz z przeliczeniem ewentualnej kary za opóźnienie.
- oznaczenie sprzętu jako niedostępnego, np. z powodu uszkodzenia lub serwisu.
- wyświetlenie aktywnych wypożyczeń danego użytkownika.
- wyświetlenie listy przeterminowanych wypożyczeń.
- wygenerowanie krótkiego raportu podsumowującego stan wypożyczalni

Projekt wykorzystuje podejście obiektowe oraz prostą warstwę serwisową do obsługi logiki biznesowej.

## Struktura projektu

Projekt został podzielony na trzy główne części:

### 1. Models
Zawiera klasy domenowe opisujące dane w systemie:
- `User` (abstrakcyjny), `Student`, `Employee`
- `Equipment` (abstrakcyjny), `Laptop`, `Camera`, `Projector`
- `Rental`

### 2. Services
Zawiera logikę biznesową:
- `UserService` – zarządzanie użytkownikami
- `EquipmentService` – operacje na sprzęcie
- `RentalService` – obsługa wypożyczeń
- `PenaltyCalculator` – obliczanie kar
- `BorrowingPolicy` – zasady limitów wypożyczeń
- `ReportService` – generowanie raportów

### 3. Data
- `InMemoryStore` – przechowywanie danych w pamięci (lista użytkowników, sprzętu i wypożyczeń)

### 4. Program.cs
Zawiera scenariusz demonstracyjny działania aplikacji.

## Uzasadnienie decyzji projektowych

### Podział na warstwy

Zastosowałem podział na `Models`, `Services` i `Data`, aby:
- oddzielić dane od logiki operacji,
- uniknąć umieszczania całej logiki w `Program.cs`,
- ułatwić rozwój i czytelność projektu.

### Dziedziczenie w modelu użytkownika i sprzętu

Zamiast użycia enumów zastosowałem dziedziczenie:

- `User` → `Student`, `Employee`
- `Equipment` → `Laptop`, `Camera`, `Projector`

Dzięki temu łatwiej dodać nowe typy w przyszłości, a logika może zależeć od konkretnego typu użytkownika lub sprzętu.

### Rozdzielenie odpowiedzialności klas

Każda klasa ma jasno określoną odpowiedzialność:

- `RentalService` – obsługuje wypożyczenia i zwroty
- `EquipmentService` – zarządza sprzętem
- `PenaltyCalculator` – nalicza kary
- `BorrowingPolicy` – przechowuje reguły biznesowe odnośnie maksymalnej liczby wypożyczeń
- `ReportService` – odpowiada za tworzenie raportu

## Kohezja i coupling

### Kohezja

W projekcie kohezja objawia się w postaci:

- klasy wykonują jedno konkretne zadanie (np. `PenaltyCalculator` tylko liczy kary)
- modele zawierają tylko dane i proste operacje
- serwisy skupiają się na jednej dziedzinie (sprzęt, użytkownicy, wypożyczenia)

### Coupling

Powiązania między klasami zostały ograniczone poprzez:

- użycie `InMemoryStore` jako wspólnego źródła danych
- przekazywanie zależności przez konstruktor
- serwisy nie korzystają bezpośrednio z siebie nawzajem, tylko z danych z `InMemoryStore`

## Scenariusz działania

W `Program.cs` zaprezentowano przykładowe użycie systemu:

- Dodanie kilku egzemplarzy sprzętu różnych typów.
- Dodanie kilku użytkowników różnych typów.
- Poprawne wypożyczenie sprzętu.
- Próbę wykonania niepoprawnej operacji, np. wypożyczenia sprzętu niedostępnego albo
przekroczenia limitu.
- Zwrot sprzętu w terminie.
- Zwrot opóźniony skutkujący naliczeniem kary.
- Wyświetlenie raportu końcowego o stanie systemu.

## Podsumowanie

Projekt starałem się zrobić w sposób prosty i czytelny.  
Zależało mi głównie na tym, żeby:
- każda klasa miała swoją rolę
- logika była rozdzielona
- kod był łatwy do zrozumienia

Dzięki takiemu podejściu aplikację można łatwo rozbudować w przyszłości.