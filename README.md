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
## 🔐 Role-Based Access Control

The system supports **three user roles**, each with different levels of access:

| Role   | Access Description                                      |
|--------|----------------------------------------------------------|
| **Admin**  | Full access: Create, Read, Update, Delete, and manage users |
| **Staff**  | Can Create, Read, and Update records — but **cannot delete** |
| **Viewer** | Read-only access — cannot create, update, or delete |

> Access is enforced via `[Authorize(Roles = "...")]` attributes in controllers and views.

## ✅ Seeding Roles and Default Admin

The system automatically seeds **user roles** and a **default Admin account** at application startup.

### 🧾 Seeded Roles:
- `Admin`
- `Staff`
- `Viewer`

### 👤 Default Admin Account:
- **Email:** `admin@example.com`
- **Password:** `Admin@123`

> You can update this in `SeedData.cs` if needed.

---

## 🔒 Applying Role Restrictions

### 🧱 Controller-level Access:
Use the `[Authorize]` attribute to restrict access based on roles:

```csharp
[Authorize(Roles = "Admin")]
public class AdminOnlyController : Controller { }

[Authorize(Roles = "Admin,Staff")]
public class StaffAndAdminController : Controller { }

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


## 📋 TODO: For Next Sprint

## 🧩 Advanced Features for Enterprise-Grade Scalability

You can extend this project into a powerful, production-level system by adding:

### 🔒 Authentication & User Management
- Role-based access (Admin, Staff, Viewer) ✅ Done
- Session logging & audit trails  ✅ Done
- Two-Factor Authentication (2FA)

### 📊 Analytics & Dashboards
- Visual charts for stock levels, categories, suppliers
- Export to Excel or PDF
- Low-stock warnings

### 🧾 Transactions & Orders
- Purchase Orders, Sales Orders
- Inbound/Outbound stock movement history
- Invoice generation

### 🏢 Multi-Warehouse Support
- Assign products to different locations
- Stock transfer between warehouses

### 🧠 Smart Search & Filtering
- Filter by name, SKU, category, supplier, quantity range
- Search suggestions and fuzzy matching

### 📷 Barcode/QR Code Integration
- Scan or generate labels for products
- Integrate with barcode readers

### 🔌 REST API Support
- Secure API endpoints for external integrations
- JWT or OAuth authentication
- Connect to CRMs or e-commerce platforms

### ☁️ Cloud-Ready Architecture
- Store product images in Azure Blob Storage
- Use Azure App Insights for monitoring
- Implement caching with Redis or MemoryCache

### 🧱 Clean Architecture Principles
- Use layers: Domain, Application, Infrastructure, UI
- Implement CQRS with MediatR
- Modular, testable structure

---

## 📋 Future Roadmap

- [ ] Role-based access control  
- [ ] Audit logs & change history  
- [ ] Product image uploads  
- [ ] Stock threshold alerts  
- [ ] API-first refactor  
- [ ] Mobile app (MAUI or React Native)  
- [ ] SaaS multi-tenant mode  

---
## Other

- Develop UI to be more beautiful
- Check and handle exceptions properly. Creating proper Error/Eception Pages
- Create Unit Testing

---
## 👨‍💻 Author

**Tito Egeonu**  
[GitHub](https://github.com/tege3000)  
[LinkedIn](https://linkedin.com/in/tito-egeonu)

---
