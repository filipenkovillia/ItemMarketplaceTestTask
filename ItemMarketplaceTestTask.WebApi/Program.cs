using ItemMarketplaceTestTask.Infrastructure.Repositories;
using ItemMarketplaceTestTask.Infrastructure.Repositories.Interfaces;
using ItemMarketplaceTestTask.Service;
using ItemMarketplaceTestTask.Service.Interfaces;
using MarketplaceTestTask.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddScoped<IAuctionRepository, AuctionRepository>();
builder.Services.AddTransient<IAuctionService, AuctionService>();

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
