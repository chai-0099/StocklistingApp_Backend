
using Microsoft.EntityFrameworkCore;
using Stocklisting.Middleware;
using Stocklisting.Model;
using Stocklisting.Repsository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Add the services of the db context
builder.Services.AddDbContext<ApplicationDBContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//Add the services of the repository

builder.Services.AddScoped<ISharesRepo, SharesRepo>();

builder.Services.AddControllers();

//add the services of the middleware
builder.Services.AddScoped<ExceptionMiddleware>();


//add the cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//add the cors
app.UseCors("CorsPolicy");
//add the middleware of the exception
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
