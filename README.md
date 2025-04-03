# Clinic and Staff Management API

This is a sample **ASP.NET Core Web API** for managing **Clinics** and **Staffs** with **CRUD operations** using **Entity Framework Core** and **SQL Server** as the database.  

---

## 🚀 Features  

- **CRUD Operations** for Clinics and Staffs  
- Entity Framework Core for ORM  
- SQL Server as the Database  
- RESTful API Endpoints  
- Basic Error Handling and Validation  

---

## 🖥️ Technologies Used  

- **ASP.NET Core 8**  
- **Entity Framework Core**  
- **SQL Server**  
- **Swagger** (for API documentation)  
- **Xunit** (for Unit Testing)  

---

## ⚡ Getting Started  

Follow these steps to set up the project locally:  

### 1️⃣ **Clone the Repository**  
```bash
git clone https://github.com/your-username/clinic-staff-api.git
cd clinic-staff-api
```

# Setup the Database
> Make sure SQL Server is installed and running.

> Update the connection string in appsettings.json:

"ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ClinicDB;Trusted_Connection=True;"
}

# Run Migrations in infrastructure project
 Go to Pacakage manager console and run these command
 1. First run  add-migration "some_comment"
 2. update-database

