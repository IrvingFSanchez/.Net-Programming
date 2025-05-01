# 🚀 .Net Programming Projects Repository

Welcome to my **.Net Programming** repository! This repository contains all the projects and assignments I've completed as part of my **.Net Programming** course at **Lewis University, Romeoville, IL**. Each project demonstrates my growing skills in C# and .NET development.

---

## 🛠️ Projects

### Updated "Projects" List

```markdown
## 🛠️ Projects

1. **Shape Calculator**  
2. **Polynomial Calculator**  
3. **Storefront**  
4. **ADHD-Friendly Task Planner**  
5. **Investment Tracker**  
6. **Library Management System**  
7. **PokeDudeManager**  
8. **PokeDudesApp (EF Core)** 🐾⚡  <-- NEW ADDITION
```

---

### 1. **Shape Calculator**

- **Description**: A C# console application that calculates the volume of a cube and a sphere based on user input. It also displays a formatted banner and handles invalid input gracefully.
- **Features**:
  - 🎨 Custom banner with centered text.
  - 🔢 Input validation for numeric values.
  - 📐 Volume calculations for cubes and spheres.
  - 📊 Total volume calculation and display.
- **Technologies Used**: C#, .NET, Console Application.
- **How to Run**:
  1. Clone the repository.
  2. Navigate to the `ShapeCalculator` folder.
  3. Run the program using `dotnet run`. (Ensure you have .NET installed on your hardware).

---

### 2. **Polynomial Calculator**

- **Description**: A C# console application that calculates the values of polynomial functions (up to degree 3) over a specified domain. It allows users to input coefficients, domain ranges, and displays the polynomial's values in a tabulated format.
- **Features**:
  - 🎨 Custom banner with centered text.
  - ✔️ Input validation for degree, coefficients, and domain values.
  - 📊 Tabulated output of polynomial values over the domain.
  - 🔄 Ability to compute multiple polynomials in one session.
  - 🪄 Automatic swapping of `minX` and `maxX` if `minX > maxX`.
- **Technologies Used**: C#, .NET, Console Application.
- **How to Run**:
  1. Clone the repository.
  2. Navigate to the `PolynomialCalculator` folder.
  3. Run the program using `dotnet run`. (Ensure you have .NET installed on your hardware).

---

### 3. **Storefront**

- **Description**: A C# console application that simulates a storefront where users can purchase items from an inventory loaded from a text file. The program allows users to add items to their cart, specify quantities, and calculates the total cost at checkout.
- **Features**:
  - 🎨 Custom banner with centered text.
  - 📚 Automatically reads inventory from a text file (`Storefront.txt`).
  - 🛒 Allows users to add items to their cart and update quantities.
  - ✅ Input validation for item names and quantities.
  - 🧾 Displays a sorted list of purchased items and the total cost.
- **Technologies Used**: C#, .NET, Console Application, File I/O.
- **How to Run**:
  1. Clone the repository.
  2. Navigate to the `Storefront/Storefront` folder.
  3. Ensure the `Storefront.txt` file is in the same folder as the program but also put it in the bin/debug/netx.x folder just in case.
  4. Run the program using `dotnet run`. (Ensure you have .NET installed on your hardware).

---

### 4. **ADHD-Friendly Task Planner** (Windows Forms) Updated

- **Description**: A **Windows Forms** application designed to help individuals with ADHD (or anyone seeking better organization) manage tasks, set priorities, track deadlines, and attach images to tasks. It builds upon the original console version with a **graphical interface**, an **MVC** architecture, and **JSON** persistence.
- **Features**:
  - 🖥️ **Windows Forms** UI with text fields, combo boxes, buttons, and a picture box for image attachments.
  - 📝 Add, edit, delete tasks and mark them as completed.
  - 🎨 Priority levels: High, Medium, Low.
  - 🖼️ **Attach images** to each task, displayed in a picture box.
  - 📅 Display due dates, show time remaining, and track completion percentage.
  - 💾 **Save** and **Load** tasks in **JSON** format for persistence.
  - 🗂️ **Data Grid View** to display and edit tasks in a table layout.
  - ✅ MVC structure with `ADHDEvent` (model), `ADHDController` (controller), and `MainForm` (view).
- **Technologies Used**: C#, .NET (Windows Forms), JSON Serialization.
- **How to Run**:
  1. Clone the repository.
  2. Navigate to the `ADHDPlanner` folder.
  3. Build and run the Windows Forms project:
     - Either open the solution in Visual Studio and press **F5**,
     - Or in VS Code / command line: `dotnet build` then `dotnet run`.
  4. Once launched, you can add tasks, browse images, save tasks to JSON, and load them back in subsequent sessions.

---

### 5. **Investment Tracker** 💰

- **Description**: A C# console application that helps users manage their investments, including checking accounts and certificates of deposit (CDs). It features deposits, withdrawals, auto-adjustments, and account summaries, emphasizing **encapsulation**, **inheritance**, and **polymorphism**.
- **Features**:
  - 🎨 Custom banner with centered text and ASCII art using Figgle.
  - 💳 Create and manage **checking accounts** with overdraft fees.
  - 📈 Create and manage **CD accounts** with interest accrual.
  - 💵 Deposit and withdraw funds from checking accounts.
  - 🔄 Auto-adjust accounts: Apply overdraft fees or add interest.
  - 📊 View account summaries with formatted details.
  - ✅ Input validation for all user inputs.
- **Technologies Used**: C#, .NET, Console Application, Object-Oriented Programming (OOP).
- **How to Run**:
  1. Clone the repository.
  2. Navigate to the `InvestmentTracker` folder.
  3. Run the program using `dotnet run`. (Ensure you have .NET installed on your hardware). May need to run `dotnet build` first.

---

### 6. **Library Management System** 📚

- **Description**: A C# console application that models a library system. It allows users to manage books and periodicals, check out and return holdings, and view statistics about the library's collection. The program emphasizes **inheritance**, **polymorphism**, and **encapsulation**.
- **Features**:
  - 🎨 Custom banner with colored ASCII art using Figgle.
  - 📚 Add books and periodicals to the library.
  - 🔄 Check out and return holdings.
  - 📊 View statistics about available and checked-out holdings.
  - 💾 Save and load library data to/from a JSON file.
  - ✅ Input validation for all user inputs.
- **Technologies Used**: C#, .NET, Console Application, JSON Serialization, Object-Oriented Programming (OOP).
- **How to Run**:
  1. Clone the repository.
  2. Navigate to the `LibraryManagementSystem` folder.
  3. Run the program using `dotnet run`. (Ensure you have .NET installed on your hardware). May need to run `dotnet build` first.

---

### 7. **PokeDudeManager** 🧂

- **Description**: A C# console application that lets you manage a team of Pokémon-inspired creatures called "PokeDudes" using a SQL Server backend and full CRUD functionality.
- **Features**:
  - 🎮 Discover, explore, re-describe, release, and reset PokeDudes.
  - 🎨 Colorful welcome banner rendered using `Figgle` ASCII art.
  - 🧠 Uses ADO.NET for connecting to a SQL Server database.
  - 📂 Persists data locally in a database called `PokeServer`.
- **Technologies Used**: C#, .NET, SQL Server, ADO.NET, Figgle, Console Application
- **How to Run**:
  1. Clone the repository.
  2. Navigate to the `PokeDudeManager` folder.
  3. Install dependencies using `dotnet restore`.
  4. Install Figgle with `dotnet add package Figgle`.
  5. Run `create_database.sql` in VS Code (SQL Server extension) to create the database and table.
  6. Launch with `dotnet run`.

---

### 8. **PokeDudesApp (EF Core)** 🐾⚡

- **Description**: A .NET console application demonstrating **Entity Framework Core** for database management. Models Pokémon trainers ("PokeDudes") and their Pokémon ("PokePals") with SQL Server LocalDB. Features migrations, async queries, and CRUD operations.
- **Features**:
  - 🗄️ **Database Modeling**: Two related tables (`PokeDude` and `PokePal`) with 1-to-many relationships.
  - 🧩 **Entity Framework Core**: Migrations, DbContext, and LINQ-to-SQL translation.
  - 🌱 **Database Seeding**: Auto-populates initial data if tables are empty.
  - 🔍 **8 Async Queries**:
    - Retrieve all rows, filtered subsets, joins, sorting, aggregation (count/average), and custom queries.
  - 📸 **Screenshot Support**: Proof of database population for GitHub.
  - ⚡ **Async/Await**: Non-blocking database operations for scalability.
- **Technologies Used**: C#, .NET, EF Core, SQL Server LocalDB, LINQ.

- **Key Lessons**:
  - EF Core migrations for schema management.
  - Async database operations with `ToListAsync()`, `FirstOrDefaultAsync()`, etc.
  - LINQ query composition (filtering, sorting, joins, aggregation).

---

## 🧑‍💻 About Me

Hi! I'm **Irving F. Sanchez**, a student at **Lewis University** in Romeoville, Illinois pursuing my passion for software development and computer engineering. This repository is a reflection of my journey in learning **.NET programming** and building practical applications.

- **Professional Website**: [irving.cyberkineticengineering.com](https://irving.cyberkineticengineering.com/)
- **GitHub**: [/IrvingFSanchez](https://github.com/IrvingFSanchez)
- **Email**: <IrvingFSanchez@proton.me>

---

## 📜 License

This repository is licensed under the **MIT License**. Feel free to use, modify, and distribute the code as you see fit. For more details, see the [LICENSE](LICENSE) file.

---

## 🙏 Acknowledgments

- **Lewis University**: Under the guidance requirements for the B.S. Computer Science curriculum.
- **Professor [Dr. Ray Klump]**: For guiding us through the .NET Programming course.
- **You**: For visiting this repository! If you find it useful, please give it a ⭐!

---

## 🚧 Future Plans

- More projects will be added as I progress through the course.
- Improve existing projects with additional features and optimizations.
- Explore advanced .NET concepts like ASP.NET, Entity Framework, and more.

---

## 📊 Repository Stats

![GitHub Repo Size](https://img.shields.io/github/repo-size/IrvingFSanchez/.Net-Programming?style=for-the-badge)
![GitHub Last Commit](https://img.shields.io/github/last-commit/IrvingFSanchez/.Net-Programming?style=for-the-badge)
![GitHub Stars](https://img.shields.io/github/stars/IrvingFSanchez/.Net-Programming?style=for-the-badge)
![GitHub Forks](https://img.shields.io/github/forks/IrvingFSanchez/.Net-Programming?style=for-the-badge)

---

## 🌟 Why This Repository?

This repository is more than just a collection of projects—it's a testament to my growth as a developer. Each project reflects my dedication to learning, problem-solving, and creating practical tools. Whether you're a fellow student, a developer, or just curious, I hope you find something inspiring here! My goal is to develop software everybody can understand.

---

Thank you for visiting my repository! Let's build something gnarly together! 🚀
