# DRB - Route Scheduling API (.NET 8 / EF Core)

A **RESTful API** for managing drivers, routes, and schedules.  
Built with **ASP.NET Core 8**, **Entity Framework Core**, and a relational database (**SQL Server**).  

---

## Features
- **Driver Management**
  - Create, read, update, delete drivers
  - Track availability status
- **Route Management**
  - Manage start & end locations with dates
- **Schedule Management**
  - Assign drivers to routes
  - Prevent double-booking (unique Driver + Date)
  - CRUD operations with validation
- **Driver History**
  - Fetch a driver's schedule history
  - Apply Pagination For schedule history Of Specific Driver (using Specification Design pattern)
---

## Tech Stack
- **.NET 8 / ASP.NET Core Web API**
- **Entity Framework Core** (Code-First Migrations)
- **SQL Server Engine**
- **Swagger UI & postman** for API documentation

---
📖 API Endpoints
Drivers

GET /api/drivers → Get all drivers

POST /api/drivers → Create new driver

PUT /api/drivers/{id} → Update driver

DELETE /api/drivers/{id} → Delete driver

Routes

GET /api/routes → Get all routes

POST /api/routes → Create new route

Schedules

GET /api/schedules → Get all schedules

POST /api/schedules/assign → Assign driver to a route (check availability)

GET /api/drivers/{driverId}/history → Get driver schedule history

GET /api/drivers/{driverId}/history/paged?page=1&pageSize=10 → Get history with pagination

GET /api/drivers/{driverId}/history/{type} → Filter history (past / upcoming) With Pagination 

Notes

Business rule: A driver cannot be assigned to multiple schedules on the same date.

Validation is enforced in both the API layer and the Database (Unique Index).

Ready for extension: e.g., driver history, advanced scheduling, reporting.

License

MIT License © 2025 Ahmed Refaat;
