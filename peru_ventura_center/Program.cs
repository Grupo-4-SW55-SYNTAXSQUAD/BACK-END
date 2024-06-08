using LearningCenterPlatform.Profiles.Application.Internal.CommandServices;
using LearningCenterPlatform.Profiles.Application.Internal.QueryServices;
using LearningCenterPlatform.Profiles.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.profiles.Domain.Services;
using peru_ventura_center.profiles.Infrastructure.Persistence.ACL;
using peru_ventura_center.profiles.Infrastructure.Persistence.ACL.Services;
using peru_ventura_center.publishing.Application.Internal.CommandServices;
using peru_ventura_center.publishing.Application.Internal.OutboundServices.ACL;
using peru_ventura_center.publishing.Application.Internal.QueryServices;
using peru_ventura_center.publishing.Domain.Repositories;
using peru_ventura_center.publishing.Domain.Services;
using peru_ventura_center.publishing.Infraestructure.Persistence.EFC.Repositories;
using peru_ventura_center.Shared.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;
using peru_ventura_center.Shared.Interfaces.ASP.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=>options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels

builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Peru.Ventura.API",
                Version = "v1",
                Description = "Peru Ventura Center API",
                TermsOfService = new Uri("https://peru-ventura.com/tos"),
                Contact = new OpenApiContact
                {
                    Name = "Peru Ventura",
                    Email = "venturaperu@ventura.com"
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                Array.Empty<string>()
            }
        });
    });
// Configure Lowercase URLs
builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Dependency Injection

// Shared Bounded Context Injection Configuration
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Publishing Bounded Context Injection Configuration
builder.Services.AddScoped<IPromotionRepository, PromotionRepository>();
builder.Services.AddScoped<IPromotionCommandService, PromotionCommandService>();
builder.Services.AddScoped<IPromotionQueryService, PromotionQueryService>();
builder.Services.AddScoped<ICommunityRepository, CommunityRepository>();
builder.Services.AddScoped<ICommunityQueryService, CommunityQueryService>();
builder.Services.AddScoped<ICommunityCommandServcice, CommunityCommandService>();
builder.Services.AddScoped<ITallerRepository, TallerRepository>();
builder.Services.AddScoped<ITallerQueryService, TallerQueryService>();
builder.Services.AddScoped<ExternalProfileService>();
// Profiles Bounded Context Injection Configuration
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
builder.Services.AddScoped<IProfileContextFacade, ProfilesContextFacade>();

var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
