using LearningCenterPlatform.Profiles.Application.Internal.CommandServices;
using LearningCenterPlatform.Profiles.Application.Internal.QueryServices;
using LearningCenterPlatform.Profiles.Infraestructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using peru_ventura_center.Feedback.Application.Internal.CommandServices;
using peru_ventura_center.Feedback.Application.Internal.QueryServices;
using peru_ventura_center.Feedback.Domain.Repositories;
using peru_ventura_center.Feedback.Domain.Services;
using peru_ventura_center.Feedback.Infraestructure.Persistence.EFC.Repositories;
using peru_ventura_center.Feedback.Infrastructure.Persistence.ACL;
using peru_ventura_center.Feedback.Infrastructure.Persistence.ACL.Services;
using peru_ventura_center.payments.Application.Internal.CommandServices;
using peru_ventura_center.payments.Application.Internal.QueryServices;
using peru_ventura_center.Payments.Application.Internal.CommandServices;
using peru_ventura_center.Payments.Application.Internal.QueryServices;
using peru_ventura_center.Payments.Domain.Repositories;
using peru_ventura_center.Payments.Domain.Services;
using peru_ventura_center.Payments.Infrastructure.Persistence.ACL.Services;
using peru_ventura_center.Payments.Infrastructure.Persistence.ACL;
using peru_ventura_center.Payments.Infrastructure.Persistence.EFC.Repositories;
using peru_ventura_center.profiles.Application.Internal.OutboundServices.ACL;
using peru_ventura_center.profiles.Domain.Repositories;
using peru_ventura_center.profiles.Domain.Services;
using peru_ventura_center.publishing.Application.Internal.CommandServices;
using peru_ventura_center.publishing.Application.Internal.QueryServices;
using peru_ventura_center.publishing.Domain.Repositories;
using peru_ventura_center.publishing.Domain.Services;
using peru_ventura_center.publishing.Infraestructure.Persistence.EFC.Repositories;
using peru_ventura_center.publishing.Infrastructure.Persistence.ACL.Services;
using peru_ventura_center.Publishing.Application.Internal.QueryServices;
using peru_ventura_center.Publishing.Domain.Repositories;
using peru_ventura_center.Publishing.Domain.Services;
using peru_ventura_center.Publishing.Infraestructure.Persistence.EFC.Repositories;
using peru_ventura_center.Publishing.Infrastructure.Persistence.ACL;
using peru_ventura_center.Shared.Domain.Repositories;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Configuration;
using peru_ventura_center.Shared.Infraestructure.Persistence.EFC.Repositories;
using peru_ventura_center.Shared.Interfaces.ASP.Configuration;
using peru_ventura_center.profiles.Infrastructure.Persistence.EFC.Repositories;
using peru_ventura_center.profiles.Application.Internal.CommandServices;
using peru_ventura_center.profiles.Application.Internal.QueryServices;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options => options.Conventions.Add(new KebabCaseRouteNamingConvention()));

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});
// Add Database Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Levels
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
        {
            if (builder.Environment.IsDevelopment())
            {
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            }
            else if (builder.Environment.IsProduction())
            {
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();
            }
        }
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

// Profiles Bounded Context Injection Configuration
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<IOwnerReposirory, OwnerRepository>();
builder.Services.AddScoped<IOwnerCommandService, OwnerCommandService>();
builder.Services.AddScoped<IOwnerQueryService, OwnerQueryService>();
builder.Services.AddScoped<ITouristRepository, TouristRepository>();
builder.Services.AddScoped<ITouristCommandService, TouristCommandService>();
builder.Services.AddScoped<ITouristQueryService, TouristQueryService>();
builder.Services.AddScoped<IPublishingContextFacade, PublishingContextFacade>();

builder.Services.AddScoped<IActivityRepository, ActivityRepository>();
builder.Services.AddScoped<IActivityCommandServices, ActivityCommandServices>();
builder.Services.AddScoped<IActivityQueryServices, ActivityQueryServices>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IReviewCommandServices, ReviewCommandServices>();
builder.Services.AddScoped<IReviewQueryServices, ReviewQueryServices>();

// Register ExternalFeedbackService dependencies
builder.Services.AddScoped<IFeedBackContextFacade, FeedbackContextFacade>();
builder.Services.AddScoped<ExternalPublishingService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryQueryService, CategoryQueryServices>();

builder.Services.AddScoped<ExternalFeedbackService>();
builder.Services.AddScoped<IPaymentContextFacade, PaymentContextFacade>();
builder.Services.AddScoped<ExternalPaymentService>();
builder.Services.AddScoped<ExternalPublishingService>();

builder.Services.AddScoped<IDestinationTripRepository, DestinationTripRepository>();
builder.Services.AddScoped<IDestinationTripQueryServices, DestinationTripQueryServices>();


builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IBookingCommandServices, BookingCommandService>();
builder.Services.AddScoped<IBookingQueryServices, BookingQueryServices>();
builder.Services.AddScoped<IBookingStateRepository, BookingStateRepository>();
builder.Services.AddScoped<IBookingStateCommandService, BookingStateCommandService>();
builder.Services.AddScoped<IBookingStateQueryService, BookingStateQueryService>();

builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IPaymentCommandServices, PaymentCommandServices>();
builder.Services.AddScoped<IPaymentQueryServices, PaymentQueryServices>();
builder.Services.AddScoped<IPaymentStateRepository, PaymentStateRepository>();
builder.Services.AddScoped<IPaymentStateQueryServices, PaymentStateQueryServices>();
builder.Services.AddScoped<IPaymentTypeRepository, PaymentTypeRepository>();
builder.Services.AddScoped<IPaymentTypeQueryServices, PaymentTypeQueryServices>();

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
// Use CORS
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();