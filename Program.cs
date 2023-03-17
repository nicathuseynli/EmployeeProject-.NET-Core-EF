using Employee_HW_EF;
using Employee_HW_EF.Context;
using Employee_HW_EF.Repository.Implementation;
using Employee_HW_EF.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
                                                                                                
builder.Services.AddDbContext<EmployeeDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("defaultServer")));
builder.Services.addRepositoryLayer();

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
