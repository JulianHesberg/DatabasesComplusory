using DatabasesComplusory.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EFCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));


var connectionString = builder.Configuration.GetConnectionString("MongoDb");
var mongDbName = builder.Configuration["MongoDbDatabaseName"];
builder.Services.AddSingleton( new MongoDbContext(connectionString!, mongDbName!));
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

app.Run();