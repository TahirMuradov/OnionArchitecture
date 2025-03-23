
using FluentValidation.AspNetCore;
using OnionArch.Application.Validators.ProductValidators;
using OnionArch.Infrastructure.Filters;
using OnionArch.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options=>options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;//default filter is removed
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddPersistenceServices(); // This is the extension method that registers the services
builder.Services.AddCors(options =>options.AddDefaultPolicy(
    policy => policy
  .WithOrigins(builder.Configuration["Domain:Front"])
    .AllowAnyMethod()
    .AllowAnyHeader()
    )

);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
