using Microsoft.EntityFrameworkCore;
using ScheduleManagement.Api.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiVersioning()
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
})
.AddOpenApi();

builder.Services.AddControllers();

// Dependency Injection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))
); 


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi().WithDocumentPerVersion();
    app.UseSwaggerUI(options =>
    {
        foreach (var description in app.DescribeApiVersions().Reverse())
        {
            options.SwaggerEndpoint(
                $"/openapi/{description.GroupName}.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection(); // Middleware

app.MapControllers();

app.Run();


// Software architecture 
// Naming conventions
// camel case
// method: pascal case