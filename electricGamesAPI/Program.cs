using electricgamesApi.Models;
using electricgamesApi.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<ElectricGamesDBsettings>(
    builder.Configuration.GetSection("ElectricGamesDBsettings")
);
builder.Services.AddSingleton<GamesService>();
builder.Services.AddCors(
    options =>{
        options.AddPolicy("AllowAnyOrigin",
            policies =>policies
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
        );
    }
);

builder.Services.AddControllers();
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
