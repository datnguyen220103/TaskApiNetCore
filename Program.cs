using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskListApi;

var builder = WebApplication.CreateBuilder(args);

#region config db
string dbConnection = "DbTest";

// Add services to the container.
string connectionString = builder.Configuration.GetConnectionString(dbConnection);
builder.Services.AddDbContext<AppDbContext>(options =>
{
    // Configure Entity Framework Core to use Microsoft SQL Server.
    options.UseSqlServer(connectionString);
});
#endregion

#region config swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Web API"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
        Name = "Authorization",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });

    //c.SchemaFilter<EnumSchemaFilter>();
});
#endregion

builder.Services.AddControllers();
var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();
