# Intro to Minimal API

We will create an event API to build on the concept of minimal APIs, The API will help you learn about:

1. Project structure
2. Rest API
3. CRUD Functionality

We will use In-memory database for now meaning the data will not be permanently saved into the Database. On a start of the application it will clear any prevous data. We shall later connect to Microsoft SQL server

**Requirements**

1. Code Editor - Visual stiudio is preffered
2. Fundamental concepts on C# language
3. Readyness to learn🙂

## step 1: Create an Empty .NET Core project

## step 2: What is included in the project and running the scafolded project

You should have the following code in ***Program.cs*** file. Program.cs is the entry point of the application and we shall be referrencing to it severally.

![1753097002946](image/Readme/1753097002946.png)

- press the keys Ctr + F5 or the run without debugging button to run the application.
- You should have a browser launched with the ***hello world*** being displayed. This shows that the project configurations looks good.
- Let break down the scafolded project:

### **Properties/launchBrowser**

- This file tells VisualStudio or dotnet run how to launch the app during developement including:

* [ ] Ports
* [ ] Whether a browser should open
* [ ] Environment variables
* [ ] HTTPS or HTTP settings

**- Schema**

```json
 "$schema": "https://json.schemastore.org/launchsettings.json",
```

The above learn  defines the JSON Schema- helps editors like VS code with intellisense and validation

**- Profiles**

- Defines a way to run the application - we got two "http and https"

* [ ] ***commandName***: tells dotnet to launch the main project with dotnet run
* [ ] ***dotnetRunMessages***: shows the usual logs like ("now listening on http://")
* [ ] ***launchBrowser***: used to auto launch the browser
* [ ] ***applicationUrl***: Port where the application will be running
* [ ] ***environmentVariables***: Sets the environment viariables like "Development"

- To avoid having the browser launching everytime you run you project; head to the properties folder and open the *launchSettings.json* file. You should have seen a property called ***launchBrowser: "true"***, turn that to ***launchBrowser: "false"*** for both the profiles (http and https).

![1753097399085](image/Readme/1753097399085.png)

- The Dependencies folder will hold all the packages we will be installing from [Nuget Package Manager](https://www.nuget.org/)

**What is NuGet?**

- NuGet is the package manager for .NET. The NuGet client tools provide the ability to produce and consume packages. The NuGet Gallery is the central package repository used by all package authors and consumers.

### Conected Services Folder

- The folder provides tooling to connect your application to external services like:

* [ ] Web APIS - OpenAPI/Swagger for API calls
* [ ] gprc services - Add and consume gRPC endpoints
* [ ] Azure Services - Connect to older SOAP/WCF services
* [ ] Databases - connect to a database and generate models with EF

### Program.cs File

This is the entry point of the application. Lets break it down:

1. var builder = WebApplication.CreateBuilder(args);

- used to create ***WebapplicationBuilder* **instance
- it configures services, logging, evinronment and app settings

2. var app = builder.Build();

- This builds the application
- create ***WebapplicationBuilder* **instance making the app ready to define the endpoinnts and middlewares

3. app.MapGet("/", () => "Hello World!");

- This is where you  **define your first API endpoint** ., whenever you visit the endpoint, it returns "Hello World".
- **() => "Hello World!** - this is a lamda function that returns a string. Lamda is a concept in C#.

4. app.Run();

- This  **starts the web server** .

* It starts listening for HTTP requests on the specified port(s)
* It keeps the application running

## step 3: Create Models folder

- Add a folder at the root of the project and name it Models. The models folder will hold all the entities we will be using. An entity is similar to a table in relational databases.
- Inside the newly created Model Folder, add a class named Event. This will hold the properties of an event.

![1753171415175](image/Readme/1753171415175.png)

- All the fields are made to be public meaning they can be accessed from anywhere from the Application
- These properties are of different data types which simulates the real world object of an event.
- The string property has "?" because by default, all strings are nullable.

### Concept of Nullable Refference

- This is a concept which was introduced in C# 8.0. in older versions of C#, you could not be warned if ther was a potential null value. With the nullable referrence types, C# became more strict and smart by helping you to catch null issues at compile time.
- ***public string Description { get; set; }** - This means that you garantee that the Description will never be null. If you do not initialize any value the compler will warn you.*
- ***public string? Description { get; set;** }* - This means that Description can be null. This tells the compliler that it okay if the property is null and it won't warn you.

#### Turning Nullable ON and OFF

- This behavior is controlled by a setting in the .csproj

```xml
<Nullable>enable</Nullable>
```

![1753172173059](image/Readme/1753172173059.png)

[Read more about Nullable reference](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-reference-types?WT.mc_id=studentamb_244628)

### .csproj file

This is the important file, its like the heart of the project configuration. It is an XML file that defines:

* What files are part of the project
* What dependencies (NuGet packages) are needed
* What version of .NET to use
* Build settings, project properties, and more

## step 4: EF Core and DB Context

### **Docs/ Resources**

[Official docs](https://learn.microsoft.com/en-us/ef/core/?WT.mc_id=studentamb_244628 "visit")

[Readme Presentation](https://github.com/kenya-data-platform-user-group/EF-Core-Presentation "visit")

[Youtube Turorial by Nick Chapsas](https://www.youtube.com/watch?v=2t88FOeQ898 "visit")

### What is EF Core?

EF Core is a modern, open-source, and cross-platform **Object-Relational Mapper (ORM)** for .NET that eliminates the need to write complex SQL queries manually. It allows developers to work with databases using **C# classes and LINQ** instead of SQL.

EF Core acts as a bridge between **.NET applications** and **databases**, allowing developers to perform operations using object-oriented techniques.

#### Why EF Core?

**1. Quick Story/Example**

Imagine you're building a .NET application and need to interact with a database. How do you do it efficiently? You could write raw SQL queries, but that can be error-prone and hard to maintain. This is where an ORM (Object-Relational Mapper) like EF Core comes in handy.

**2. How Do We Interact with Databases in .NET?**

Before Entity Framework Core (EF Core), developers interacted with databases using **ADO.NET**, **Dapper**, or raw SQL queries. While these approaches provided control and performance, they often required writing a lot of boilerplate code for CRUD operations.

- Open a database connection.
- Write SQL queries manually.
- Handle result mappings to objects.
- Manage transactions and exceptions explicitly

This process is repetitive and error-prone. This is where **EF Core** comes in.

**4. Why Use EF Core?**

**a. Simplifies Data Access**

EF Core abstracts database interactions, allowing developers to use **C# objects** instead of SQL queries.

**b. Boosts Productivity**

- Eliminates the need to write repetitive SQL queries.
- Supports **automatic migrations** to handle database schema changes.
- Works seamlessly with **LINQ queries** for data retrieval.

**c. Supports Multiple Databases**

EF Core is database-agnostic and supports multiple database providers, including:

- **SQL Server**
- **PostgreSQL**
- **MySQL**
- **SQLite**
- **Azure Cosmos DB**

### Setting Up EF Core

**Installing EF Core**

To install EF Core in your .NET project, run the following command in your terminal:
In visual studio code

```bash
dotnet add package Microsoft.EntityFrameworkCore
```

In Visual Studio, click on Tools-Nuget Package Manager and search - **Microsoft.EntityFrameworkCore** and install

## What is Db Context?

DbContext is the main class in Entity Framwork Core that manages database connections and is used to query and save data.

Think of this like a bridge between your C# code and your Database.

What does it do?

* Maps your **C# classes (entities)** to **database tables**
* Allows you to  **query** ,  **insert** ,  **update** , and **delete** data
* Tracks changes to your data so it knows what to update in the database

## step 5: CRUD Operations FOR rest API

## step 6: MapGroup

👉 Next, we will learn about TypedResults APi to help us handle different responses of our system.
