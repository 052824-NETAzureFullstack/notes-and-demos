using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("Docker");

builder.Services.AddDbContext<PetContext>(options =>
    options.UseSqlServer(connectionString)
    );

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();


class Pet
{
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public int cuteness { get; set; }
}

class PetContext : DbContext
{
    // Fields
    public DbSet<Pet> Pets => Set<Pet>();

    // Constructors
    public PetContext(DbContextOptions<PetContext> options) : base(options) {}
}