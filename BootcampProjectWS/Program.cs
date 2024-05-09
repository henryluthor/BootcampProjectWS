using BootcampProjectWS.DBModels;
using BootcampProjectWS.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

//new line
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//new block
builder.Services.AddCors( options => 
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        policy =>
        {
            policy.WithOrigins("https://localhost:7251/api/Client");
        });
} );

builder.Services.AddDbContext<BootcampprojectContext>(options =>
    //options.UseSqlServer("Server=LAPTOP-R601H3RA\\SQLEXPRESS;Database=bootcampproject;Trusted_Connection=true;TrustServerCertificate=true;Persist Security Info=true"));
    options.UseSqlServer((new ConfigurationBuilder()).AddJsonFile("appsettings.json").Build().GetSection("DB").GetValue<string>("connection")));

builder.Services.AddScoped<SessionUserFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//new line
//app.UseCors(MyAllowSpecificOrigins);
//new block
app.UseCors(policy =>
    policy.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
);

app.UseAuthorization();

app.MapControllers();

app.Run();
