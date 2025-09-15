using System.Text.Json.Serialization;
using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure and Core services
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add Controllers to the service collection
builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddAutoMapper(cfg => { },
typeof(ApplicationUserMappingProfile).Assembly);

// FluentValidations
builder.Services.AddFluentValidationAutoValidation();

// Add API explorer services
builder.Services.AddEndpointsApiExplorer();

// Add swagger generation services to create swagger specification
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opt => opt.AddDefaultPolicy(policyBuilder => 
        policyBuilder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
    ));

// Build the web application
var app = builder.Build();

// Exception Handling Middleware
app.UseExceptionHandlingMiddleware();

// Routing
app.UseRouting();
app.UseSwagger(); // Adds endpoint that can serve the swagger.json
app.UseSwaggerUI(); // Adds swagger user interface (interactive page to explore and test API endpoints)

app.UseCors(opt => opt.AllowAnyOrigin());

// Auth
app.UseAuthentication();
app.UseAuthorization();

// Controller routes
app.MapControllers();

app.Run();