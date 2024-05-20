var builder = WebApplication.CreateBuilder(args);

builder
    .ConfigureServices()
    .ConfigureDataBase();

var app = builder.Build();

app.ConfigureSwagger();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
