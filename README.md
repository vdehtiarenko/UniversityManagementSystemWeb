
# **UniversityManagementSystemWeb**

A web application for university management that allows you to manage courses, groups, and students, organizing the educational process.

# Table of Contents

- [Description](#description)
- [Technologies](#technologies)
- [Project Setup](#project-setup)
- [User Interface](#user-interface)

# Description

UniversityManagementSystemWeb is a web application based on ASP.NET Core MVC using Clean architecture, designed for effective university management. Users can manage courses, groups, and students by performing CRUD operations and organizing the educational process. The program allows you to easily manage course and group structures, as well as control student information. The web application facilitates university administration and stores all data in a structured form.

# Technologies

- C# / .NET 9
- ASP.NET Core MVC
- Clean Architecture
- SQL Server
- Entity Framework Core

# Project Setup

1. **Cloning a repository**  
Clone the repository and open the project in **Visual Studio**:
```bash
git clone <your-repository-url>
```

2. **Creating the database**
Create a new database in your SQL Server with the desired name for your project.

3. **Configuring the database connection**  
Open the `appsettings.json` file and locate the `ConnectionStrings` section. Replace the `DefaultConnection` value with the connection string to your own database.

4. **Applying migrations**
Open the Package Manager Console and run:
```bash
Update-Database
```

# User Interface

![UI Screenshot 1](https://github.com/user-attachments/assets/a885176a-7a44-4dcf-8d45-a1dead0f5f0f)

![UI Screenshot 2](https://github.com/user-attachments/assets/20f7f225-8595-4630-ae1e-01be4d006136)

<img width="452" height="261" alt="Image" src="https://github.com/user-attachments/assets/5866c339-1402-4645-82c8-82fc393ae455" /> <img width="451" height="209" alt="Image" src="https://github.com/user-attachments/assets/00c94909-bfaa-4b1d-af48-a618086be0db" />

![UI Screenshot 3](https://github.com/user-attachments/assets/871bddc0-fc32-4f11-9c66-a71965c5e380)
