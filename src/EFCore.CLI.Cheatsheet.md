1. dotnet ef => If missing, needs to be installed with `dotnet tool install --global dotnet-ef` for the latest version;
	- If failing because of private NuGet sources, make sure you call `dotnet tool install --global dotnet-ef --ignore-failed-sources` to ignore them

2. dotnet ef dbcontext list => Will list the DBContext classes that you've set-up within the project.
	- Needs to be called from the project which contains the class implementing DbContext

3. dotnet ef dbcontext info -s [start-up project path] => Will give you the info about the dbcontext class.
	- Start-up project needs to reference the `Microsoft.EntityFrameworkCore.Design` NuGet package to work (required by the CLI)

4. dotnet ef migrations add [name of the migration] -s [start-up project path] => Updates the Entity schema from your changed C# DbContext (can be reverted with `ef migrations remove`)

5. dotnet ef database update -s [start-up project path] -v => Updates the database from the Entity schema (-v for verbosity)