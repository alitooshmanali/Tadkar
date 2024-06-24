using Autofac;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tadkar.Application;
using Tadkar.Application.Behaviors;
using Tadkar.DataAccessLayer;
using Tadkar.DataAccessLayer.Context;
using Tadkar.RestApi.Controllers.V1.Personnels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddHttpContextAccessor();
builder.Services.AddLogging();
builder.Services.AddApiVersioning();
builder.Services.AddAutoMapper(typeof(PersonnelsController).Assembly);
builder.Services.AddHttpCacheHeaders();
builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true)
    .ConfigureApiBehaviorOptions(options =>
    {
        options.InvalidModelStateResponseFactory = context =>
        {
            var validationProblemDetails = new ValidationProblemDetails(context.ModelState)
            {
                Type = "",
                Title = "",
                Status = StatusCodes.Status422UnprocessableEntity,
                Detail = "",
                Instance = context.HttpContext.Request.Path
            };

            validationProblemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

            return new UnprocessableEntityObjectResult(validationProblemDetails);
        };
    });

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Tadkar REST API", Version = "v1" });
});

builder.Services.AddMediatR(builder =>
{
    var applicationAssemblies = typeof(IUnitOfWork).Assembly;

    builder.RegisterServicesFromAssemblies(applicationAssemblies);
    builder.AddBehavior(typeof(TransactionBehavior<,>));
    builder.AddBehavior(typeof(LoggingBehavior<,>));
});

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlServer(connectionString);
});


// Register All Service With Autofac library
builder.Host.ConfigureContainer<ContainerBuilder>(container =>
{
    var dataAccessLayerAssemblies = typeof(UnitOfWork).Assembly;

    container.RegisterAssemblyTypes(dataAccessLayerAssemblies)
    .Where(t => t.Name.EndsWith("Repository"))
    .AsImplementedInterfaces().InstancePerLifetimeScope();

    container.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
});
    




var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
