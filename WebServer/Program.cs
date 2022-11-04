using DataLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// jeg har lavet en kommentar i program.cs
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IDataService, DataService>();

var app = builder.Build();

app.MapControllers();

app.Run();
