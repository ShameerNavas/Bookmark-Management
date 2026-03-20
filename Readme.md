📌 Bookmark Management System (.NET MVC)

🚀 Overview

The Bookmark Management System is a web application built using ASP.NET MVC that allows users to manage their bookmarks efficiently. Users can add, edit, delete, search, and view bookmarks with features like pagination and authentication.

---

✨ Features

- 🔐 User Authentication (Login/Logout)
- ➕ Add new bookmarks (Title & URL)
- 📋 View bookmarks list with pagination
- ✏️ Edit existing bookmarks
- ❌ Delete bookmarks
- 🔍 Search bookmarks by Title or URL
- ⏱️ Timestamp for each bookmark
- ⚠️ Restriction: Maximum 5 bookmarks per user

---

🛠️ Technologies Used

- ASP.NET MVC (C#)
- Entity Framework Core (ORM)
- SQL Server
- Razor Views (Frontend)

---

🗂️ Project Structure

```
BOOKMARK/
│
├── Controllers/        # Handles application logic
├── Models/             # Data models
├── Views/              # UI (Razor Pages)
├── DBContext/          # Database context (EF Core)
├── wwwroot/            # Static files (CSS, JS)
├── Migrations/         # EF Core migrations
│
├── Program.cs          # App configuration
├── appsettings.json    # DB connection settings
├── BOOKMARK.csproj     # Project file
└── Properties/         # Launch settings
```

---

⚙️ Setup Instructions

1️⃣ Clone the repository

git clone https://github.com/ShameerNavas/Bookmark-management.git
cd bookmark-management

2️⃣ Configure Database

- Open "appsettings.json"
- Update your SQL Server connection string:

"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER;Database=BookmarkDB;Trusted_Connection=True;TrustServerCertificate=True;"
}

---

3️⃣ Apply Migrations

dotnet ef database update

---

4️⃣ Run the Application

dotnet run

Then open:

https://localhost:bookmarkmanagement

---

📸 Screens (Optional)

- Add Bookmark Page
- View Bookmarks Page
- Edit Bookmark Page

(You can add screenshots here later)

---

🧠 Key Concepts Used

- MVC Architecture
- CRUD Operations
- Entity Framework Core (Code First)
- Authentication with Cookies
- Pagination using Skip & Take
- TempData for messages

---

📌 Future Improvements

- Password encryption
- Bookmark categories/tags
- Responsive UI enhancements
- API integration

---

👨‍💻 Author

Shameer Navas 

---

📄 License

This project is for learning purposes and not licensed for commercial use.