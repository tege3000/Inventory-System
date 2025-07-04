# 📦 Inventory Management System

A full-stack ASP.NET Core MVC web application for real-time inventory tracking. Built with Entity Framework Core and SQL Server. Deployed using Azure App Services and Azure SQL Database.

---

## 🚀 Features

- 🗃️ CRUD for Products, Categories, and Suppliers  
- 🔐 Optional role-based user authentication  
- 📊 Real-time stock tracking and search  

---

## 🧰 Tech Stack

- ASP.NET Core MVC (.NET 6/7)  
- Entity Framework Core (Code-First)  
- SQL Server  
- Azure App Service & Azure SQL  
- GitHub for version control  

---

## 📁 Project Structure

```
InventorySystem/
├── Controllers/
├── Models/
├── Views/
├── Data/
├── wwwroot/
├── appsettings.json
├── Program.cs
├── InventorySystem.csproj
├── README.md
```

---

## 🧱 Entity Models

### Product.cs
```csharp
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
```

### Category.cs
```csharp
public class Category {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}
```

### Supplier.cs
```csharp
public class Supplier {
    public int Id { get; set; }
    public string Name { get; set; }
    public string ContactInfo { get; set; }
    public ICollection<Product> Products { get; set; }
}
```

---

## 🛠️ Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/tege3000/InventorySystem.git
cd InventorySystem
```

### 2. Configure the Database
In `appsettings.json`:
```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=InventoryDb;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true"
}
```

### 3. Apply Migrations
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 4. Run the App
```bash
dotnet run
```

Visit: `http://localhost:5173/`

---

## 📋 TODO: For Next Sprint

-- 🔐 Role-based Authentication with ASP.NET Identity
-- 🔍 Search & Filter Products
-- 📈 Low-stock Alerts
-- ☁️ Azure deployment with App Service and Azure SQL

---
## 👨‍💻 Author

**Tito Egeonu**  
[GitHub](https://github.com/tege3000)  
[LinkedIn](https://linkedin.com/in/tito-egeonu)

---
