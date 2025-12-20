```
dotnet ef migrations add InitMigration --project traobang.be.infrastructure.data --startup-project traobang.be --output-dir Migrations
dotnet ef database update --project traobang.be.infrastructure.data --startup-project traobang.be --output-dir Migrations
```