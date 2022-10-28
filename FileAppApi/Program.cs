using FileAppApi.Configuration;
using FileAppRepository.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.Configure<LocalStorageOptions>(builder.Configuration.GetSection(LocalStorageOptions.LocalStorage));
builder.Services.Configure<AzureStorageOptions>(builder.Configuration.GetSection(AzureStorageOptions.AzureStorage));

builder.Services.AddFileAppRepositories();
builder.Services.AddFileAppServices();

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

app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
