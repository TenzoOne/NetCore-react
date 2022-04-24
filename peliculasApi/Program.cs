using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using peliculasApi;
using peliculasApi.ApiBehavior;
using peliculasApi.Controllers;
using peliculasApi.Filtros;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Filters.Add(typeof(FiltroDeExcepcion));
    options.Filters.Add(typeof(ParsearBadRequest));
}).ConfigureApiBehaviorOptions(BehaviorBadRequest.Parsear);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddResponseCaching();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
   options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
});

builder.Services.AddCors(options =>
{
    var frontend = builder.Configuration.GetValue<string>("Frontend_url");
    options.AddDefaultPolicy(build =>
    {
        build.WithOrigins(frontend).AllowAnyMethod().AllowAnyHeader()
        .WithExposedHeaders(new string[] {"cantidadTotalRegistros"});
    });
});

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var logger = app.Services.GetService(typeof(ILogger<Program>)) as ILogger<Program>;

    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
app.UseAuthentication();
app.UseCors();
app.UseAuthorization();

app.MapControllers();

app.Run();
