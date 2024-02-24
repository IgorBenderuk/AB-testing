AB Testing API
This API is designed for AB testing purposes, allowing you to manage button colors and purchase profits for statistical analysis.

Technologies Used
ASP.NET Core
Entity Framework Core
AutoMapper
Microsoft SQL Server

Getting Started
To get started with the API, follow these steps:

Clone this repository to your local machine.
Set up your database connection string in the appsettings.json file.
Run the Entity Framework Core migrations to create the database:
	"dotnet ef database update" 
	or if you use Nuget Package console "Update-Database"
and run the application

Endpoints
ButtonColor
GET /api/ButtonColor: Adds a new button color record or retrieves an existing one.
GET /api/ButtonColor/Get_Statistic: Retrieves statistics for button color records.
PurchaseProfit
GET /api/PurchaseProfit: Adds a new purchase profit record or retrieves an existing one.
GET /api/PurchaseProfit/Get_Statistic: Retrieves statistics for purchase profit records.
