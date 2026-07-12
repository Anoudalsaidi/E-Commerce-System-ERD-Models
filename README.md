# 🛒 E-Commerce System – ERD & Models

**.NET | C# | Entity Framework Core | SQL Server | Database Design**

A database modeling project for an **E-Commerce System** that demonstrates the design and implementation of entities, relationships, and Entity Framework Core models following relational database principles.

---

## 📌 Overview

This project focuses on designing the core database structure of an E-Commerce System using **Entity Framework Core** and **SQL Server**.

It includes the entity models, relationships, validation attributes, and database configuration required to build a scalable e-commerce application.

---

## 🚀 Features

* 🛍️ Product Management
* 📂 Category Management
* 👤 Customer Management
* 📦 Order Management
* 📝 Product Reviews
* 🔗 Entity Relationships
* ✔️ Data Annotations & Validation
* 💾 SQL Server Integration
* ⚡ Entity Framework Core

---

## 📂 Project Structure

```text
E-Commerce-System
│
├── Models
├── Data
├── Migrations
├── DbContext
└── Program.cs
```

---

## 🗄️ Database Design

### Entity Relationship Diagram (ERD)



```markdown
![ERD Diagram](https://github.com/Anoudalsaidi/E-Commerce-System-ERD-Models/pull/2/changes/f728bc8cd0c87462b6de7467d7903ac9b21e1b40)
```

---

## 📊 Database Entities

| Entity      | Description                         |
| ----------- | ----------------------------------- |
| User        | Stores customer information         |
| Category    | Organizes products into categories  |
| Product     | Stores product details              |
| Order       | Represents customer orders          |
| OrderDetail | Stores ordered products             |
| Review      | Stores customer reviews and ratings |

---

## 🔗 Relationships

* One Category → Many Products
* One User → Many Orders
* One Order → Many Order Details
* One Product → Many Order Details
* One User → Many Reviews
* One Product → Many Reviews

---

## 🎯 Highlights

* ✅ Relational Database Design
* ✅ Entity Framework Core Models
* ✅ Primary & Foreign Keys
* ✅ One-to-Many Relationships
* ✅ Data Validation
* ✅ Clean Model Structure

---

## 🛠️ Technologies

* C#
* .NET
* Entity Framework Core
* SQL Server
* LINQ

---

## ⚙️ Getting Started

```bash
git clone https://github.com/Anoudalsaidi/E-Commerce-System-ERD-Models.git

cd E-Commerce-System-ERD-Models

dotnet restore

dotnet ef database update
```

---

## 📚 What I Learned

* Designing relational databases
* Implementing Entity Framework Core models
* Creating entity relationships
* Using Data Annotations for validation
* Working with SQL Server
* Building scalable database structures

---

## 🚀 Future Improvements

* ASP.NET Core Web API
* JWT Authentication
* Repository Pattern
* Clean Architecture
* Unit Testing
* Swagger Documentation

---

## 👩‍💻 Author

**Anoud Alsaidi**

Backend Developer | .NET | Entity Framework Core | SQL Server
