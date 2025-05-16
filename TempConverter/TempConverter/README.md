# 🌡️ Temperature Converter - ASP.NET Core MVC

## 📖 Table of Contents

- [🌡️ Temperature Converter - ASP.NET Core MVC](#️-temperature-converter---aspnet-core-mvc)
  - [📖 Table of Contents](#-table-of-contents)
  - [✨ Features](#-features)
  - [🏗️ How It Works](#️-how-it-works)
    - [🖼️ The Photo Frame System (Layouts)](#️-the-photo-frame-system-layouts)
    - [🏷️ Smart Stickers (Tag Helpers)](#️-smart-stickers-tag-helpers)
  - [🚀 Getting Started](#-getting-started)
    - [Prerequisites](#prerequisites)
    - [Installation](#installation)
  - [📂 Project Structure](#-project-structure)
  - [🎨 Theme System](#-theme-system)

---

## ✨ Features

**A rad, intuitive temperature converter that:**

- 🔄 Converts between Celsius and Fahrenheit
- 🌓 Auto-saves your preferred light/dark theme
- 📱 Works perfectly on phones and computers
- ❓ Includes a friendly Questionnare with Answers

---

## 🏗️ How It Works

### 🖼️ The Photo Frame System (Layouts)

Imagine your website is like a photo album:

- `_Layout.cshtml` is your **fancy frame** (same header/theme for all pages)
- Individual pages (like the converter) are **photos** that slide into this frame
- `_ViewStart.cshtml` automatically puts every "photo" in this frame

### 🏷️ Smart Stickers (Tag Helpers)

Instead of writing complex code, we use magical stickers (sounds elementary but trust me):

```html
<a asp-action="Index">Home</a> <!-- Automatically becomes <a href="/">Home</a> -->
<input asp-for="Temperature"> <!-- Knows it should be a number input -->
```

---

## 🚀 Getting Started

### Prerequisites

- 🖥️ **Computer** (Windows/Mac/Linux)
- 🌐 **Git** (to download repository)

### Installation

1. **Get the tools** (one-time setup):
   - Download [.NET 8+ SDK](https://dotnet.microsoft.com/download)
   - Install [Visual Studio Code](https://code.visualstudio.com/)

2. **Run the app**:

```bash
git clone https://github.com/IrvingFSanchez/.Net-Programming
cd TempConverter
dotnet run
```

3. **Open your browser** to:

```markdown
http://localhost:5166
```

---

## 📂 Project Structure

```markdown
temp-converter/
├── 📁 Controller/            # Figuratively Speaking--Your Control Panel
│   └── HomeController.cs     # Styles
├── 📁 Models/               # Figuratively Speaking--The Sensors & Data Processor
│   └── Temperature.cs       # "Recipe" for temp conversion
├── 📁 Views/               # Figuratively Speaking--Your Display Screen
│   ├── Home/               # Main screens
│   │   ├── Index.cshtml    # Converter UI
│   │   └── Questions.cshtml # Questionnare (Assignment Questions)
│   └── Shared/              # Reusable parts
│       └── _Layout.cshtml   # Master "frame"
└── 📁 wwwroot/             # Assets
    ├── css/                # Styles
    └── js/                 # Interactive bits (Didn't really use)
```

---

## 🎨 Theme System

This app remembers your light/dark preference like a smart lightbulb:

1. Click the 🌓 button to toggle
2. Your choice saves automatically
3. Returns to your preference next visit
4. Honestly I just wanted to add Dark Mode bc my eyes were burning

---

<p align="center">
  <img width="200" src="https://media2.giphy.com/media/v1.Y2lkPTc5MGI3NjExYzI5NHo4MWx2b2Vib2Nydm9nYzZoeTE3ZndrdDNrZWkybTBmNnJ2OCZlcD12MV9pbnRlcm5hbF9naWZfYnlfaWQmY3Q9cw/dA5g2PU3lUidXce5jQ/giphy.gif" alt="Temperature GIF">
  <br>
</p>
