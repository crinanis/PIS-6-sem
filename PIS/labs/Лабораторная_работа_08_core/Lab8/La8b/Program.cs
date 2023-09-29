using Lab8.Interfaces;
using Lab8.Models;
using Lab8.Models.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); //регистрируем в контейнере DI
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer(); //Регистрирует компоненты для генерации документации API и обнаружения маршрутов.

builder.Services.AddSwaggerGen(options => //добавляем службу swagger
{
    options.SwaggerDoc("v1", new OpenApiInfo 
    {
        Version = "v1",
        Title = "LeraX",
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename)); //включение комментариев из XML-файла документации в сгенерированную спецификацию Swagger.
});

builder.Services.AddScoped<IDbContext, TDDbContext>(); //рег интерфейс с реализацией
builder.Services.AddScoped<ITD, TD>();                                                      //AddTransient, AddSingleton

builder.Services.AddDbContext<TDDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build(); //запуск конвеера обработки запросов

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers(); // middleware для маршрутизации запросов к контроллерам

app.Run(); //начало обработки запроса
