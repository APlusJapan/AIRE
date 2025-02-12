dotnet ef dbcontext scaffold "Host=localhost;Username=postgres;Password=root;Database=AIRE_DB" Npgsql.EntityFrameworkCore.PostgreSQL --project EFCore --output-dir Models
rmdir /S /Q AIRE_App\Models
move EFCore\Models AIRE_App\Models
pause