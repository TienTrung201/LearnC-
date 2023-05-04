using LearnCRUD_API.EmployeeData;
using LearnCRUD_API.Model;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddSingleton<IEmployeeData, MockEmployeeDada>();
builder.Services.AddScoped<IEmployeeData, SqlEmployeeData>();
builder.Services.AddDbContext<EmployeeContext>(options =>
{
	var connectionString = builder.Configuration.GetConnectionString("CRUD_API");
	options.UseSqlServer(connectionString);
});
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
