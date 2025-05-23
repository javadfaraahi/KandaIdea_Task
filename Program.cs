using DNTPersianUtils.Core.IranCities;
using KandaIdea_Task.Application.Mappings;
using KandaIdea_Task.Application.Services;
using KandaIdea_Task.Application.Validators;
using KandaIdea_Task.Domain.Interfaces;
using KandaIdea_Task.Extensions;
using KandaIdea_Task.Infrastructure.Data;
using KandaIdea_Task.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using KandaIdea_Task.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IProvinceService, ProvinceService>();
builder.Services.AddScoped<IExcelExportService, ExcelExportService>();
//DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("kanda")));
//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddControllers();
// Fluent Validator
builder.Services.AddValidatorsFromAssemblyContaining<UserDtoValidator>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
// Run DataSeeder
await app.UseDatabaseSeederAsync();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseMiddleware<RequestLoggingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
