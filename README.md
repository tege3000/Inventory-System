
## 🧾 Inventory Management System App

A full-stack ASP.NET Core MVC web application for managing product inventory in real-time. Built with ASP.NET Core, Entity Framework Core, and SQL Server

---

## 📦 Features

- 🔐 Role-based Authentication with ASP.NET Identity (optional)
- 🗃️ CRUD operations for Products, Categories, and Suppliers
- 🔍 Search & Filter Products
- 📈 Low-stock Alerts (optional)
- ☁️ Deployed to Azure with Azure SQL Database
- 🧱 Built using ASP.NET Core MVC and Entity Framework Core

---

## 🛠️ Technologies Used

- ASP.NET Core MVC (.NET 6/7)
- C#, HTML5, CSS3, Bootstrap
- Entity Framework Core
- SQL Server
- Azure App Service & Azure SQL
- GitHub (Version Control)

---

## 📁 Project Structure
InventorySystem/
├── Controllers/
├── Models/
├── Views/
├── Data/
├── wwwroot/
├── appsettings.json
├── Program.cs
├── InventorySystem.csproj
├── README.md ← This file

## 🗃️ Entity Models

### Product
public class Product {
    public int Id { get; set; }
    public string Name { get; set; }
    public string SKU { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    public int SupplierId { get; set; }
    public Supplier Supplier { get; set; }
}
### Category
public class Category {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}
### Supplier
public class Supplier {
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    public ICollection<Product> Products { get; set; }
}

🛠️ Getting Started
1. Clone the Repository
git clone https://github.com/tege3000/InventorySystem.git
cd InventorySystem

2. Configure the Database
Update the connection string in appsettings.json:

json
"ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=InventoryDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true",
    "ApplicationDbContext": "Server=(localdb)\\mssqllocaldb;Database=ApplicationDbContext-d7c8b7f8-207d-47a9-95bf-0e666a399e5f;Trusted_Connection=True;MultipleActiveResultSets=true"
}

3. Apply Migrations
dotnet ef migrations add InitialCreate
dotnet ef database update
4. Run the Application
dotnet run
Visit http://localhost:5173 in your browser.

🔐 Authentication
To enable login & roles:

Add Identity to your project:
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
Configure Identity in Program.cs



👨‍💻 Author
Tito Egeonu
LinkedIn : https://www.linkedin.com/in/tito-egeonu/
GitHub : https://github.com/tege3000
