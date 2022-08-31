1. Create Database named InventoryManagement
Run below migration into Package Manager Console
-> dotnet ef database update --project InventoryManagement.Web --context ApplicationDbContext
-> dotnet ef database update --project InventoryManagement.Web --context InventoryDbContext
