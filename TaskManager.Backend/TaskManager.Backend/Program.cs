using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using TaskManager.Backend.Configurations;
using TaskManager.Backend.Data;
using TaskManager.Backend.Repositories.TareaRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnection"));
});

builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowAll",
		b => b.AllowAnyMethod()
		.AllowAnyHeader()
		.AllowAnyOrigin());
});

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddControllers().AddJsonOptions(options =>
{
	options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddScoped<ITareaRepository, TareaRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.UseMiddleware<GlobalErrorHandlingMiddleware>();

app.MapControllers();

app.Run();
