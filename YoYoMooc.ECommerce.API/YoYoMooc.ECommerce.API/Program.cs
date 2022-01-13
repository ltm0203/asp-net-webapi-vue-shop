
using YoYoMooc.ECommerce.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
 builder.Services.AddControllers();

builder.Services.AddScoped<IProductRepository, MockProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();
app.Run();