using API;
using API.Context;
using API.EndPoints;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MyDbContext>(Options =>
    Options.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));

builder.Services.AddSignalR();


var app = builder.Build();

app.MapHub<OrdersHub>("/ordersHub");
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseProductosEndPoints();

app.UseOrdenesEndPoints();

app.Run();

