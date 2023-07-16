using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using Repository.AddressRepository;
using Repository.ClientRepository;
using Repository.Interfaces.IAddressRepository;
using Repository.Interfaces.IClientRepository;
using Repository.Interfaces.IProfileRepository;
using Repository.ProfileRepository;
using server.Models;
using Services.AddressService;
using Services.ClientService;
using Services.Interfaces.IAddressService;
using Services.Interfaces.IClientService;
using Services.Interfaces.IProfileService;
using Services.ProfileService;

var builder = WebApplication.CreateBuilder(args);

// Add Cors
var provider = builder.Services.BuildServiceProvider();
var settings = provider.GetRequiredService<IConfiguration>();
builder.Services.AddCors(op => {
    var clientURL = settings.GetValue<string>("ConnectionStrings:ClientConnection");

    op.AddDefaultPolicy(builder => {
        builder.WithOrigins(clientURL!).AllowAnyMethod().AllowAnyHeader().AllowCredentials();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ClientContext>(op => op.UseSqlServer("ConnectionStrings:DBConnection"));

builder.Services.AddScoped<IClientRepository , ClientRepository>();
builder.Services.AddScoped<IClientService , ClientService>();
builder.Services.AddScoped<IProfileRepository , ProfileRepository>();
builder.Services.AddScoped<IProfileService , ProfileService>();
builder.Services.AddScoped<IAddressRepository , AddressRepository>();
builder.Services.AddScoped<IAddressService , AddressService>();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
