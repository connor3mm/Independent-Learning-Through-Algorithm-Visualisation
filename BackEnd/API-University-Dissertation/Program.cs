using API_University_Dissertation.Application.Mappers;
using API_University_Dissertation.Application.Services.Interfaces;
using API_University_Dissertation.Application.Services.Services;
using API_University_Dissertation.Application.Strategies;
using API_University_Dissertation.Core.Data.DataContexts;
using API_University_Dissertation.Core.Repositories;
using API_University_Dissertation.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        JsonConvert.DefaultSettings = () => new JsonSerializerSettings();
        
        // Add more options as required
    });
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

builder.Services.AddLogging(builder => { builder.AddConsole(); });

builder.Services.AddDbContext<DataContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

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
builder.Services.AddLogging();
builder.Services.AddTransient<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddTransient<IAspNetUserRepository, AspNetUserRepository>();
builder.Services.AddTransient<IQuizRepository, QuizRepository>();
builder.Services.AddScoped<IQuizService, QuizService>();
builder.Services.AddScoped<ISortingStrategy, BubbleSort>();
builder.Services.AddScoped<ISortingStrategy, SelectionSort>();
builder.Services.AddScoped<ISortingStrategy, InsertionSort>();
builder.Services.AddScoped<ISortingStrategy, QuickSort>();
builder.Services.AddScoped<ISortingStrategy, ShellSort>();
builder.Services.AddScoped<ISortingAlgorithmService, SortingAlgorithmService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddAutoMapper(typeof(UserProfileMapper));

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