# The Unlimitted

## Overview
This project is an ASP.NET Core application with Entity Framework Core for database management. This document provides instructions on how to update the database and apply migrations using NuGet.

## Prerequisites
- [.NET Core SDK](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) or any other IDE
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)

## Setup

### Step 1: Clone the Repository
Clone this repository to your local machine using the following command:
```bash
git clone <repository_url>
```

## Migrations
### Update Database and Apply Migrations
Using Package Manager Console in Visual Studio
- Open Visual Studio and load the project.
- Open the Package Manager Console (Tools -> NuGet Package Manager -> Package Manager Console).
- Ensure the Default Project is set to the correct project containing the DbContext.
- Run the following command to update the database:
```bash
Update-Database
```
- Run the following command to update add new migration
```bash
Add-Migration <MigrationName>
```
