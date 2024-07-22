using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Prueba_Double_V.Application.DTOs;
using Prueba_Double_V.Application.Interfaces;
using Prueba_Double_V.Application.Services;
using Prueba_Double_V.DBContext;
using Prueba_Double_V.Domain.Interfaces;
using Prueba_Double_V.Domain.Repocitory;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(
        options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

builder.Services.AddCors(c =>
{
    c.AddPolicy("AllowAll", options => options.AllowAnyOrigin()
                                            .AllowAnyHeader()
                                            .AllowAnyMethod());
});

var my_secret_key = builder.Configuration.GetSection("settings").GetSection("secretkey").ToString();
var keyBites = Encoding.UTF8.GetBytes(my_secret_key);

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.RequireHttpsMetadata = false;
    config.SaveToken = true;
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyBites),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});



builder.Services.AddScoped<IPersonaService, PersonaService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddScoped<IPersonaDomainService, PersonaDomainService>();
builder.Services.AddScoped<IUsuarioDomainService, UsuarioDomainService>();


var mappingConf = new MapperConfiguration((options) =>
{
    options.AddProfile<MappingProfile>();
});

var mapper = mappingConf.CreateMapper();
builder.Services.AddSingleton<IMapper>(mapper);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();
app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
