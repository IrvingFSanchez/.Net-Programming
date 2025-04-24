# 🧢 PokeDudeManager

**PokeDudeManager** is a C# console application that lets you discover, explore, update, and release your very own Pokémon-style companions — "PokeDudes" — with a fully functional SQL Server database.

---

## 📦 Features

- 🧠 Discover new PokeDudes (Create)
- 📜 Explore all existing PokeDudes (Read)
- ✏️ Re-describe or rename existing PokeDudes (Update)
- 🕊️ Release a single or all PokeDudes (Delete)
- 🎨 Console banner powered by `Figgle` ASCII Art
- 💾 Data stored in a local SQL Server Express or LocalDB database

---

## 🛠️ Requirements

- [.NET SDK 7.0+ or 9.0](https://dotnet.microsoft.com/en-us/download)
- [SQL Server Express or LocalDB](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server (mssql) Extension for VS Code](https://marketplace.visualstudio.com/items?itemName=ms-mssql.mssql)
- Windows OS (this version uses Windows Authentication and SQL Server)

---

## 🚀 Getting Started

### 1. 🧬 Clone the Repository

```bash
git clone https://github.com/IrvingFSanchez/.Net-Programming.git
cd PokeDudeManager
```

---

### 2. 📦 Install Dependencies

Install Figgle for the ASCII title screen:

```bash
dotnet add package Figgle
```

---

### 3. 🧱 Set Up the SQL Server Database

#### Option A: Using SQL Server Express (Recommended)

1. In VS Code, install the SQL Server extension
2. Go to the **SQL SERVER** tab and connect using:
   - Server: `localhost\SQLEXPRESS`
   - Authentication: **Windows Authentication**
   - Leave **Database** blank
   - ✅ Enable **Trust Server Certificate**

#### Option B: Using LocalDB (Optional)

If you prefer LocalDB, update your connection string in `Program.cs` to:

```csharp
string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=PokeServer;Integrated Security=True;TrustServerCertificate=True;";
```

---

### 4. 🧾 Run the SQL Script

Open `create_database.sql` and execute the script to create the database and table:

```sql
CREATE DATABASE PokeServer;
GO

USE PokeServer;
GO

CREATE TABLE PokeDudes (
    PokeDudeID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Type NVARCHAR(100) NOT NULL,
    Gender NVARCHAR(200),
    Location NVARCHAR(100),
    DiscoveryDate DATE
);
```

💡 In VS Code: Right-click the SQL file > **Run Query** or **Execute Query** or press `Ctrl+Shift+E`.

---

### 5. ⚙️ Build the Project

```bash
dotnet restore
dotnet build
```

---

### 6. 🧢 Run the App

```bash
dotnet run
```

You’ll see the ASCII welcome banner followed by:

```markdown
POKEDUDE NETWORK MANAGER
1. Discover a PokeDude
2. Explore PokeDudes
3. Re-describe a PokeDude
4. Release a PokeDude
5. Reset PokeServer
6. Exit
```

---

## 🔐 Connection String

Default for SQL Server Express in `Program.cs`:

```csharp
string connectionString = "Server=localhost\\SQLEXPRESS;Database=PokeServer;Integrated Security=True;TrustServerCertificate=True;";
```

Update the connection string if you:

- Use LocalDB
- Have a custom SQL Server instance name

---

## 🧼 Project Structure

```markdown
PokeDudeManager/
├── Program.cs               # Main program logic and menu
├── create_database.sql      # SQL script for database setup
├── Models/
│   └── PokeDude.cs          # Data model for PokeDudes
├── Data/
│   └── PokeDB.cs            # ADO.NET helper class for CRUD operations
├── PokeDudeManager.csproj   # Project file with dependencies
```

---

## 🧠 Notes

- ASCII art is rendered using the `Figgle` library: <https://github.com/drewnoakes/figgle>
- Requires Windows authentication for database access
- Designed for educational use, class project assignments, or just fun exploration of .NET and SQL Server

---

## 💡 Troubleshooting

- **SQL Server not found**: Make sure the instance `SQLEXPRESS` or `MSSQLLocalDB` is running. Use `Get-Service` or `SQL Server Management Studio` to confirm.
- **"Invalid object name 'PokeDudes'"**: Your database/table might not have been created correctly. Re-run `create_database.sql`.
- **System error 5 - Access Denied**: Run PowerShell as Administrator when starting/stopping SQL Server.

---

## 🌈 Future Ideas

- Add search/filter by type or location
- Add leveling system or evolution logic
- Export to CSV or JSON
- Build a GUI version using WinForms, WPF, or Blazor
- I kinda want to add an AI randomizer for characters but I may be getting a little ahead on this

---

## 🧢 Credits

Created by Irving F. Sanchez as part of the .NET Programming course at Lewis University.  
Inspired by Pokémon, terminal nostalgia, and a love for clean code with creative metaphors. 🎮

---

## 📄 License

MIT License

---
