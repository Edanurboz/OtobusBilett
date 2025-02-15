using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer
    (options =>
    {
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Token:Issuer"],
            ValidAudience = builder.Configuration["Token:Audience"],
            IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            ClockSkew=TimeSpan.Zero
        };
    });
builder.Services.AddScoped<BiletOtomasyonu>();

builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<ISeatService, SeatManager>();
builder.Services.AddScoped<ISeatRepository, SeatRepository>();

builder.Services.AddScoped<ITicketService, TicketManager>();
builder.Services.AddScoped<ITicketRepository, TicketRepository>();

builder.Services.AddScoped<ITripService, TripManager>();
builder.Services.AddScoped<ITripRepository, TripRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();    

app.UseAuthorization();

app.MapControllers();

app.Run();
