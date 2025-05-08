using DatabasesComplusory.Application.Commands.UserCommandHandlers;
using DatabasesComplusory.Application.Events;
using DatabasesComplusory.Application.Events.UserEventHandlers;
using DatabasesComplusory.Application.Handlers.UserHandlers;
using DatabasesComplusory.Application.Interfaces;
using DatabasesComplusory.Application.Service;
using DatabasesComplusory.Domain.Interfaces;
using DatabasesComplusory.Infrastructure.Context;
using DatabasesComplusory.Infrastructure.EventBus;
using DatabasesComplusory.Infrastructure.Repository;
using DatabasesComplusory.Infrastructure.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EfCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));


builder.Services.AddSingleton<MongoDbContext>(sp =>
{
    var config = sp.GetRequiredService<IConfiguration>();
    var connStr = config.GetConnectionString("MongoDb");
    var databaseName = config["MongoDbDatabaseName"];

    if (string.IsNullOrWhiteSpace(connStr))
        throw new InvalidOperationException(
            "Missing MongoDb connection string. " +
            "Please set ConnectionStrings:MongoDb in appsettings.json.");
    if (string.IsNullOrWhiteSpace(databaseName))
        throw new InvalidOperationException(
            "Missing MongoDbDatabaseName. " +
            "Please set MongoDbDatabaseName in appsettings.json.");

    return new MongoDbContext(connStr, databaseName);
});

builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
    ConnectionMultiplexer.Connect(
        builder.Configuration.GetConnectionString("Redis")!));

builder.Services.AddMemoryCache();
builder.Services.AddScoped<CacheService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserReadRepository, UserReadRepository>();
builder.Services.AddScoped<IListingRepository, ListingRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddSingleton<IEventBus, InMemoryEventBus>();

builder.Services.AddScoped<CreateUserCommandHandler>();
builder.Services.AddScoped<GetUserCommandHandler>();

builder.Services.AddScoped<UserCreatedEventHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var bus = app.Services.GetRequiredService<IEventBus>();
// synchronously register the handler
bus.Subscribe<UserCreatedEvent>(evt =>
{
    using var scope = app.Services.CreateScope();
    var handler = scope.ServiceProvider.GetRequiredService<UserCreatedEventHandler>();
    handler.Handle(evt);
})
.GetAwaiter()
.GetResult();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();