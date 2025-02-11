
Created API Project named ProductApi. 

Used below command to create the project
dotnet new webapi -n ProductApi
cd ProductApi
git init
git add .
git commit -m "Initial commit"
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools


Then defined Product model inside Contract folder
Created ProductDbContext under Data folder which shows DbSet that will be created in database.
Followed by ProductController under Controller folder which contain endpoints relted to CRUD.
Followed by ProductService under Domain folder which contain business logic.
Followed by ProductRepository under Repository folder which contain database transaction code.

For Product and ProductRepository , there are respective interface files under Contract and Repository.Contract.

Startup.cs file is created which injects the services needed in running the project.

appsetting.json file which contain all configuration related to projects - here connectionString

then we have ProductApi.csproj which contain all packages installed and .net version.

At last we can do data migration using following commands
dotnet ef migrations add InitialCreate
dotnet ef database update
