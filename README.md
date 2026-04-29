# 🎓 Course Registration API

A simple ASP.NET Core Web API that allows students to register for courses.
This project was built as a beginner-friendly backend system to demonstrate core concepts in C#, API development, and database integration using Entity Framework Core.

---

## 🚀 Features

* Create and manage students
* Create and manage courses
* Register students for courses
* Prevent duplicate registrations
* Update and delete records
* Persistent data storage using SQL Server

---

## 🏗️ Project Structure

* **Models** → Defines the data structure (Student, Course, StudentCourse)
* **Services** → Contains business logic
* **Controllers** → Handles API requests and responses
* **Data** → Contains `AppDbContext` for database connection

---

## 🧠 Key Concepts Learned

* RESTful API design (GET, POST, PUT, DELETE)
* Dependency Injection in ASP.NET Core
* Entity Framework Core (EF Core)
* LINQ for querying data
* Many-to-Many relationships (Student ↔ Course)
* Data validation and error handling
* Database migrations

---

## 🗄️ Database Design

The system uses three tables:

* *Students*
* *Courses*
* *StudentCourses* (Join table for many-to-many relationship)

The `StudentCourses` table uses a **composite key (StudentId + CourseId)** to prevent duplicate registrations.

---

## ⚙️ Technologies Used

* C#
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server (LocalDB)



---
