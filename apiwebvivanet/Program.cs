//using apiwebvivanet.basedatos;
using apiwebvivanet.Utils;
using AplicationLayer;
using InterfaceAdapter_Darta;
using InterfaceAdapter_Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// dependencias
builder.Services.AddDbContext<ContabilidadDatabaseContext>(sqlServerBuilder => {
	sqlServerBuilder.UseSqlServer(builder.Configuration.GetConnectionString("Connection1"));
});

builder.Services.AddScoped<IRepository, Repository>();
builder.Services.AddScoped<GetRangoRemuneracionUseCase>();
builder.Services.AddScoped<GetImpuestoUnicoUseCase>();
builder.Services.AddScoped<GetDteEmitidosUseCase>();
//builder.Services.AddScoped<General>();



/***********************************/

builder.Services.AddCors(options =>
{
	options.AddPolicy("NewPolicyCors", app =>
	{
		app.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
	});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("NewPolicyCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
