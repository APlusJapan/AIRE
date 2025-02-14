dotnet ef dbcontext scaffold "Host=localhost;Username=postgres;Password=root;Database=AIRE_DB" Npgsql.EntityFrameworkCore.PostgreSQL --output-dir Models --project AIRE_DB --no-onconfiguring
rmdir /S /Q AIRE_DB\bin
rmdir /S /Q AIRE_DB\obj
rmdir /S /Q AIRE_App\Models
move AIRE_DB\Models AIRE_App\Models
pause