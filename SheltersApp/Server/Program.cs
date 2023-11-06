using MongoDB.Driver;
using SheltersApp.Shared.Storage;

var builder = WebApplication.CreateBuilder(args);

// Konfigurerer MongoDB
var mongoDbConnectionString = "mongodb+srv://gustavrosell:Gustav41541@dbdesign.q2bkeja.mongodb.net/";
var mongoClient = new MongoClient(mongoDbConnectionString);
var database = mongoClient.GetDatabase("shelterDB");

// Registrerer MongoDB-tjenester
builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddSingleton(database);

// Tilføjer Repository
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IShelterRepository, ShelterRepository>();

// Tilføjer Persistency som en singleton service
builder.Services.AddSingleton<Persistency>();

// Tilføjer controllers med views og Razor Pages til DI containeren
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Konfigurer HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // Standard HSTS værdien er 30 dage. Du kan ændre dette i produktions scenarier, se https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();