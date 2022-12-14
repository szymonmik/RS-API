using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using RS_API;
using RS_API.Middleware;
using RS_API.Models;
using RS_API.Models.Validators;
using RS_API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Authentication configuration scope
var authenticationSettings = new AuthenticationSettings();
builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
builder.Services.AddSingleton<AuthenticationSettings>(authenticationSettings);
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = "Bearer";
    option.DefaultScheme = "Bearer";
    option.DefaultChallengeScheme = "Bearer";
}).AddJwtBearer(cfg =>
{
    cfg.RequireHttpsMetadata = false;
    cfg.SaveToken = true;
    cfg.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = authenticationSettings.JwtIssuer,
        ValidAudience = authenticationSettings.JwtIssuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
    };
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
// Database context registration
builder.Services.AddDbContext<StoreDbContext>();
//builder.Services.AddScoped<StoreSeeder>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
// Services registration
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddScoped<IRecordService, RecordService>();
builder.Services.AddScoped<IOrderService, OrderService>();
// Password hasher registration
// Register form validator registration
builder.Services.AddScoped<IValidator<CreateRecordDto>, CreateRecordDtoValidator>();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
