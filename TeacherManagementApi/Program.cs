using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using TeacherManagement.Business.Abstract;
using TeacherManagement.Business.Concrete;
using TeacherManagement.DataAccess.Abstract;
using TeacherManagement.DataAccess.Concreate;
using TeacherManagement.DataAccess.Context;
using TeacherManagement.Entity.Entites;
using TeacherManagementApi.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Service Extensions ve AutoMapper Eklemeleri
builder.Services.AddServiceExtensions();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// DbContext Ekleme
builder.Services.AddDbContext<TeacherManagementContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Identity Ekleme
builder.Services.AddIdentity<AppUser, AppRole>()
    .AddEntityFrameworkStores<TeacherManagementContext>()
    .AddDefaultTokenProviders();
// JWT Authentication Ayarlarý
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ClockSkew = TimeSpan.Zero
    };
});

// Controller Servisleri
builder.Services.AddControllers().AddJsonOptions(x =>
   x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware Sýralamasý
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication(); // JWT Authentication Middleware
app.UseAuthorization();  // Authorization Middleware

app.MapControllers();

app.Run();

