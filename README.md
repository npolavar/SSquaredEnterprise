Please go to Code -> Download Zip and then extract the files.

I created ASP.NET Core Web App(Model View Controller) application. I used EntityFramework 6.0 for data access. 
So, code-first approach is used where the EF Core creates the database tables based on domain classes.

To run this application open the solution in Visual Studio 2022 and follow below steps
1. Go to Tools -> Nuget Package Manager -> Package Manager Console
2. Give the below commands 
	a) Add-Migration First
	b) Update-Database
3. Run the application
