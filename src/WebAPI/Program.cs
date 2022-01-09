using Core.Services;
using Infrastructure.Data;
using Microsoft.OpenApi.Models;
using SharedKernal.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Persistance 
builder.Services.AddDbContext<AppDbContext>();

// Repository 
builder.Services.AddScoped(typeof(IReadRepository<>), typeof(EfRepository<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

// Add services to the container.
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DDS API", Version = "v1" });
    c.EnableAnnotations();
});

builder.Services.AddCors(o => o.AddPolicy("AllowAllOriginsPolicy", builder =>
{
    builder.AllowAnyOrigin()
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyHeader()
            .AllowAnyMethod();
}));

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
