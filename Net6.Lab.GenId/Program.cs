using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Net6.Lab.GenId.Data;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Net6LabGenIdContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Net6LabGenIdContext") ?? throw new InvalidOperationException("Connection string 'Net6LabGenIdContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
