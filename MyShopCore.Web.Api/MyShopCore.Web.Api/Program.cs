using Microsoft.Extensions.Options;
using MyShopCore.Web.Api.Brokers.DateTimes;
using MyShopCore.Web.Api.Brokers.Loggings;
using MyShopCore.Web.Api.Brokers.Storages;
using MyShopCore.Web.Api.Services.Foundations.Products;
using MyShopCore.Web.Api.Services.Foundations.Stocks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("Localhost", builder =>
//    {
//        builder.WithOrigins("http://localhost:5173/")
//        .AllowAnyHeader()
//        .AllowAnyMethod();
//    });
//});

builder.Services.AddCors();



builder.Services.AddDbContext<StorageBroker>();

ServiceBroker(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options => options
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.UseAuthorization();

app.MapControllers();

app.Run();

static void ServiceBroker(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<IStorageBroker, StorageBroker>();
    builder.Services.AddTransient<ILoggingBroker, LoggingBroker>();
    builder.Services.AddTransient<IDateTimeBroker, DateTimeBroker>();
    builder.Services.AddTransient<IProductService, ProductService>();
    builder.Services.AddTransient<IStockService, StockService>();

}