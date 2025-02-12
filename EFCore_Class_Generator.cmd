dotnet ef dbcontext scaffold "Host=localhost;Username=postgres;Password=root;Database=AIRE_DB" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models --project EFCore --no-onconfiguring
rmdir /S /Q AIRE_App\Models
move EFCore\Models AIRE_App\Models
pause