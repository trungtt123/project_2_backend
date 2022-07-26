using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WareHouse.Service.Interfaces;
using WareHouse.Service.Implementations;
using WareHouse.Repository.Interfaces;
using WareHouse.Repository.Implementations;
using System.Text;
using WareHouse;

// InitDatabase
//InitDatabase.ResetDb();




var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateActor = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});

builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IMailService, MailService>();

builder.Services.AddSingleton<IProductTypeRepository, ProductTypeRepository>();
builder.Services.AddSingleton<IProductTypeService, ProductTypeService>();

builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IProductService, ProductService>();

builder.Services.AddSingleton<IProductBatchRepository, ProductBatchRepository>();
builder.Services.AddSingleton<IProductBatchService, ProductBatchService>();

builder.Services.AddSingleton<IInputInfoRepository, InputInfoRepository>();
builder.Services.AddSingleton<IInputInfoService, InputInfoService>();

builder.Services.AddSingleton<IOutputInfoRepository, OutputInfoRepository>();
builder.Services.AddSingleton<IOutputInfoService, OutputInfoService>();
//builder.Services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest).AddApplicationPart(typeof(UserController).Assembly);
builder.Services.AddHttpClient();



var app = builder.Build();

app.UseSwagger();

app.UseAuthorization();

app.UseAuthentication();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.MapControllers();

app.UseSwaggerUI();

app.Run();

