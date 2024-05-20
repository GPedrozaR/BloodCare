var builder = WebApplication.CreateBuilder(args);

builder.ConfigureServices();
builder.ConfigureDataBase();
builder.ConfigureDependecyInjection();

var app = builder.Build();

app.ConfigureSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
