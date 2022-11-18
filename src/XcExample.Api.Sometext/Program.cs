using Microsoft.OpenApi.Models;
using XcExample.Api.Sometext.Handlers;
using XcExample.Api.Sometext.System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    var apiInfo = new OpenApiInfo { Title = "XcExample.Api.Sometext", Version = "v1" };
    c.SwaggerDoc("v1", apiInfo);
    var filePath = Path.Combine(System.AppContext.BaseDirectory, $"{apiInfo.Title}.xml");
    c.IncludeXmlComments(filePath);
});

// register injection classes
builder.Services.AddScoped<IWords, WordDictionary>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(StaticFileConfiguration.GetNex());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
