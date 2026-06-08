using Microsoft.EntityFrameworkCore;
using Csharp.Data;

var builder = WebApplication.CreateBuilder(args);


var connectionString = "Server=localhost;Port=3306;Database=GestionStudent;Uid=root;Pwd=;AllowPublicKeyRetrieval=true;SslMode=None;";
var serverVersion = new MySqlServerVersion(new Version(9, 1, 0));

builder.Services.AddDbContext<dbConnexion>(options =>
    options.UseMySql(connectionString, serverVersion));

builder.Services.AddControllers();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.MapGet("/", () => "api fonctionnel");

app.Run();