# 📝Public Note Board📝

---

### 📘 Overview

**Public Note Board** is a simple and dynamic "digital bulletin board" built using the ASP.NET Core MVC framework. It provides a clean, dark-mode interface where all users share the same board. Any visitor can publicly post a note, edit existing notes, or delete notes, with all changes visible to everyone.

---

### 💻 Tech Stack

This project is built with a modern .NET and web stack:

* **🧠 Backend:** ASP.NET Core MVC (.NET 9 / .NET 6+)
* **🧰 Language:** C#
* **🗃️ Database:** Entity Framework Core with SQLite
* **🎨 Frontend:** HTML5, CSS3, Bootstrap 5
* **⚙️ Tooling:** `dotnet-ef` for database migrations

---

### 🚀 Steps To Run

#### ✅ Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/en-us/download) (Version 6.0 or newer)
* [EF Core Global Tool](https://learn.microsoft.com/en-us/ef/core/cli/dotnet#installing-the-tools)
    ```sh
    dotnet tool install --global dotnet-ef
    ```
* A code editor like Visual Studio or VS Code

#### ▶️ Running the Project

1.  **Clone the Repository**
    ```sh
    git clone https://github.com/niyamk/PublicNotes.git
    cd PublicNotes
    ```

2.  **Restore Dependencies**
    ```sh
    dotnet restore
    ```

3.  **Create the Database**
    This is a crucial step to set up your local `app.db` file.
    ```sh
    dotnet ef database update
    ```

4.  **Run the Project**
    ```sh
    dotnet run
    ```

5.  **Open Your Browser**
    Navigate to the local URL shown in your terminal (usually `http://localhost:5xxx` or `https://localhost:7xxx`).

# 📸 Screenshots 📸
<img width="1907" height="1079" alt="image" src="https://github.com/user-attachments/assets/6bceaa2e-0a4e-4ea4-a3a0-f6a302b3ba3b" />

