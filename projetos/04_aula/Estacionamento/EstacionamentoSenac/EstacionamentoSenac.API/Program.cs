using EstacionamentoSenac.API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=EstacionamentoSenacDB;Trusted_Connection=True;";

builder.Services.AddDbContext<AppDbContext>(opt => opt .UseSqlServer(connectionString));

builder.Services.AddControllers();

builder.Services.AddOpenApi();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
