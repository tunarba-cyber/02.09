using ProniaModular.Modules.Products;
using ProniaModular.Modules.Products.Endpoints;
using Microsoft.Extensions.DependencyInjection;
using ProniaModular.Modules.Users.Application.Presentation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

builder.Services.AddProductsModule(connectionString);
builder.Services.AddUsersModule(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapControllers();

app.UseHttpsRedirection();

// Map Endpoints
app.MapProductEndpoints();
app.MapCategoryEndpoints();
app.MapSizeEndpoints();

app.Run();