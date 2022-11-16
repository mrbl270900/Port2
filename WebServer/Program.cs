using DataLayer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddSingleton<IMovieDataService, MovieDataService>();

var app = builder.Build();

app.MapControllers();

app.Run();
