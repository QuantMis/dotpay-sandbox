using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using MerchatService.API.Infrastructure.Database;
using dotenv.net;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// read from dotenv
DotEnv.Load(options: new DotEnvOptions(ignoreExceptions: false));
var envVars = DotEnv.Read();
var DB_NAME = envVars["DB_NAME"];
var DB_USER = envVars["DB_USER"];
var DB_PASS = envVars["DB_PASS"];
var DB_PORT = envVars["DB_PORT"];

string connectionString = $"Host=localhost;Port={DB_PORT};Database={DB_NAME};Username={DB_USER};Password={DB_PASS}";

builder.Services.AddDbContext<MerchantDbContext>(options => options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();

app.Run();

