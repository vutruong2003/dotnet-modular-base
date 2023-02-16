using MediatR;
using Shared.Core;
using Shared.Infrastructures;
using Shared.Modules;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSharedInfrastructure(builder.Configuration)
    .AddSharedCore(builder.Configuration)
    .AddModules(builder.Configuration);

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

await app.InitSharedInfrastructure();
await app.InitSharedCore();
await app.InitModules();

await app.RunAsync();
