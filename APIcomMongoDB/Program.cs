using APIcomMongoDB.Config;
using APIcomMongoDB.Services;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Singleton config and AppSettings params.
builder.Services.Configure<ProjAPIcomMongoSettings>(builder.Configuration.GetSection("ProjAPIcomMongoSettings"));
builder.Services.AddSingleton<IProjAPIcomMongoSettings>(s => s.GetRequiredService<IOptions<ProjAPIcomMongoSettings>>().Value);
builder.Services.AddSingleton<CustomerService>();

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
