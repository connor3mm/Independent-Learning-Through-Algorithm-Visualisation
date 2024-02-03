using API_University_Dissertation.Application.Strategies;
using API_University_Dissertation.Core.Repositories;
using API_University_Dissertation.Core.Services.Interfaces;
using API_University_Dissertation.Core.Services.Services;
using API_University_Dissertation.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("bearer", new OpenApiSecurityScheme
    {
        Description = "Authorization header using the Bearer scheme.",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "bearer",
                },
            },
            new string[] { }
        },
    });
});

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
        };
    });
builder.Services.AddIdentityApiEndpoints<IdentityUser>().AddEntityFrameworkStores<DataContext>();

//This allows request from the my frontend with origin 5173
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        corsPolicyBuilder =>
        {
            corsPolicyBuilder.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

builder.Services.AddTransient<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<ISortingStrategy, BubbleSort>();
builder.Services.AddScoped<ISortingStrategy, SelectionSort>();
builder.Services.AddScoped<ISortingStrategy, MergeSort>();
builder.Services.AddScoped<ISortingStrategy, InsertionSort>();
builder.Services.AddScoped<ISortingStrategy, QuickSort>();
builder.Services.AddScoped<ISortingAlgorithmService, SortingAlgorithmService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();

var app = builder.Build();
app.UseRouting();
app.UseCors("AllowFrontend");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapIdentityApi<IdentityUser>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();