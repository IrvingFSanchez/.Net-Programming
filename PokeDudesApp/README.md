# PokeDudesApp — Entity Framework Core Console App

PokeDudesApp is a C# console application built using Entity Framework Core. It simulates a Pokémon training world, where `PokeDudes` (trainers) have many `PokePals` (Pokémon). The project models real-world relationships, performs asynchronous data queries, and demonstrates foundational database operations in a .NET environment.

---

## 📚 Project Purpose

This project was developed as part of an advanced .NET programming course focusing on **Entity Framework Core** (EF Core). The goal was to demonstrate the following:

- Relational database modeling using C# classes
- Use of EF Core for migrations, database creation, and data access
- Data seeding for test environments
- Querying with asynchronous LINQ methods
- Real-world software practices like avoiding data reseeding and separating concerns

---

## 📦 Technologies Used

- **.NET 9.0**
- **C#**
- **Entity Framework Core 9.0.4**
- **SQL Server LocalDB**
- **LINQ**
- **Console App (no UI framework)**

---

## 🗂 Project Structure

```markdown
PokeDudesApp/
├── Data/
│   └── PokeDbContext.cs         # DbContext class
├── Models/
│   ├── PokeDude.cs              # Trainer model
│   └── PokePal.cs               # Pokémon model
├── Migrations/                  # Auto-generated EF migration files
├── Program.cs                   # App entry point with queries & seeding
├── PokeDudesApp.csproj
└── README.md
```

---

## 🧱 Database Design

### 📌 Tables

| Table       | Description                  |
|-------------|------------------------------|
| `PokeDudes` | Pokémon trainers             |
| `PokePals`  | Pokémon belonging to trainers|

### 🔁 Relationship

- **One-to-Many:** One `PokeDude` can own many `PokePals`.

---

## 🌱 Data Seeding

The database is seeded with well-known trainers (like Ash and Misty) and their Pokémon. Seeding only occurs **if no data exists** to avoid duplicating entries:

```csharp
if (!await context.PokeDudes.AnyAsync())
{
    // Seed Ash, Misty, and their PokePals
}
```

This reflects real-world practice where production data should not be overwritten by default.

---

## 🔍 Queries Demonstrated

Each query is written asynchronously using EF Core's `ToListAsync`, `FirstOrDefaultAsync`, etc.

| # | Query | Description |
|---|-------|-------------|
| 1 | Retrieve all data | Displays all `PokeDudes` and `PokePals` |
| 2 | Limited results | User inputs how many Pokémon to retrieve |
| 3 | First match | Gets the first Pokémon of a specified type |
| 4 | Sorting | Sorts Pokémon by Level (asc) and Name (desc) |
| 5 | Filtered subset | Shows high-level Water-type Pokémon |
| 6 | Joined data | Trainer-to-Pokémon mapping with sorting |
| 7 | Aggregation | Average level grouped by Pokémon type |
| 8 | Custom | Count of Pokémon per trainer + strongest level |

### 🧵 Example Async Query

```csharp
var avgLevelByType = await context.PokePals
    .GroupBy(p => p.Type)
    .Select(g => new { Type = g.Key, AvgLevel = g.Average(p => p.Level) })
    .ToListAsync();
```

### 💬 Why Use Async?

```csharp
// Using async methods like ToListAsync improves performance and avoids blocking the main thread,
// especially when interacting with a database, which can be slow or I/O-bound.
```

---

## 📸 Screenshots

Screenshots of the populated tables can be found in the [`/assets`](./assets) folder.

- `PokeDudes Table`
- `PokePals Table`

These verify successful seeding and data model relationships.

---

## 🧠 Educational Value

This project models how real applications interact with databases:

- Defining **data relationships** with C# classes
- Building and managing a database with **EF Core migrations**
- Implementing **data seeding logic**
- Writing **async LINQ queries** to extract insights
- Practicing **safe, scalable data access**

This structure and logic reflect enterprise best practices used in web, desktop, and cloud-based software.

---

### ✅ Prerequisites

You’ll need the following installed:

- [Visual Studio 2022 or later](https://visualstudio.microsoft.com/) with the **“.NET desktop development”** workload
- [.NET SDK 9.0](https://dotnet.microsoft.com/en-us/download/dotnet/9.0)
- **SQL Server LocalDB** (comes with Visual Studio)

## 🚀 How to Run

1. Clone the repo:

   ```markdown
   git clone https://github.com/your-username/PokeDudesApp.git
   cd PokeDudesApp
   ```

2. Restore dependencies:

   ```markdown
   dotnet restore
   ```

3. Create the database:

   ```markdown
   Add-Migration InitialCreate
   Update-Database
   ```

4. Run the app:

   ```markdown
   dotnet run
   ```

You’ll be prompted to enter how many Pokémon to display and see various query outputs in the console.

---

## 🛡 License

This project is for educational purposes and is not intended for production use. All Pokémon names and references are owned by Nintendo/Game Freak and are used here for academic demonstration only.

---

## 🙌 Credits

Created by [Irving F. Sanchez] for .NET Programming Coursework  
Instructor: [Dr. Klump]  
School/Program: [Lewis University]
