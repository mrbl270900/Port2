using DataLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSingleton<IDataService, DataService>();

var app = builder.Build();

app.MapControllers();

app.Run();
