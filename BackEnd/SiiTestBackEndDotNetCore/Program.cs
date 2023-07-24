using SiiTestBackEndDotNetCore;
using SiiTestBLL;
using SiiTestBLL.Interfaces;
using SiiTestDAL;
using SiiTestDAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeesBll, EmployeesBll>();
builder.Services.AddScoped<IEmployeesDAL, EmployeesDAL>();
builder.WebHost.UseUrls(new[] { "https://localhost:7234/" });
builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
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
app.UseCors(options => options.AllowAnyOrigin());
app.UseHttpsRedirection();
app.MapControllers();

app.Run();
