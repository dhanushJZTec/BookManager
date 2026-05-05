# 📚 Book Manager Console App

A C# console application to manage a list of books with support for **asynchronous JSON storage**, built using collections, LINQ, and proper exception handling.

---

## 🚀 Features

- ➕ Add Book  
- ❌ Remove Book  
- 🔍 Search Book (case-insensitive)  
- 🔃 Sort Books by Title  
- 📖 Display All Books  
- 💾 Persist data using JSON  
- ⚡ Asynchronous file operations (`async/await`)  
- ⚠️ Exception handling with try-catch  

---

## 🛠️ Technologies Used

- C#  
- .NET Console Application  
- `List<Book>` (Collections)  
- LINQ (`Where`, `OrderBy`, `FirstOrDefault`)  
- `System.Text.Json`  
- Asynchronous File I/O  

---

## 📂 Project Structure
Book_Manager_App/
│── Program.cs
│── Book.cs
│── Book_Manager_App.csproj
│── books.json
│── README.md

---


---

## ▶️ How to Run

1. Open the project in Visual Studio  
2. Ensure `.NET SDK` is installed  
3. Press `Ctrl + F5` to run  
4. Use the menu to manage books  

---

## 📄 JSON Storage

Books are stored in: books.json

### Initial File Content:
```json
[]

---

Example After Adding Books:
[
  {
    "Id": 1,
    "Title": "Madras",
    "Author": "Pa. Ranjith"
  }
]

---

⚙️ Async Implementation

This project uses:

File.ReadAllTextAsync() → Load data
File.WriteAllTextAsync() → Save data
async Task Main() → Entry point

🧠 Concepts Demonstrated

Object-Oriented Programming (OOP)
Collections (List<T>)
LINQ Queries
Async/Await Programming
File Handling
JSON Serialization/Deserialization
Exception Handling

⚠️ Error Handling

Invalid input handled using try-catch
Null input handled safely (?.Trim() ?? "")
Prevents duplicate Book IDs

📌 Future Improvements
✏️ Update Book Feature
🔐 Input validation (empty fields)
📊 Sort by Author / ID
💾 Database integration (SQL Server)
🌐 Convert to Web API (ASP.NET)


👨‍💻 Author

Dhanush

⭐ Notes

This project is a beginner-to-intermediate level implementation demonstrating clean coding practices and async file handling in C#.


---
