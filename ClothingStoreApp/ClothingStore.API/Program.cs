using ClothingStore.API.APIExtentions;
using ClothingStore.Application.DependencyInjection;
using ClothingStore.Persistence.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Console.WriteLine($"Environment: {builder.Environment.EnvironmentName}");
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        b => b.WithOrigins("http://localhost:5173") // frontend URL
              .AllowAnyHeader()
              .AllowAnyMethod());
});
var app = builder.Build();
app.UseCors("AllowFrontend");

//using (var scope = app.Services.CreateScope())
//{
//    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    try
//    {
//        await context.Database.MigrateAsync();
//        await ApplicationDbContextSeed.SeedAsync(context);
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Database seeding failed: {ex.Message}");
//        throw; // optional: rethrow or ignore
//    }
//}
await app.SeedDatabaseAsync();
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
