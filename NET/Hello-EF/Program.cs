using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<PetService>();

string? connectionString = builder.Configuration.GetConnectionString("Docker");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString)
    );

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// Get All the pets!
// https://localhost:xxxx/pets
app.MapGet("/pets", (PetService pets) =>
{
    return PetService.Pets;
});

// Get a specific pet?
// https://localhost:xxxx/pets/{id}
app.MapGet("/pets/{id}", (PetService pets, int id) =>
{
    //Linq to find the entry we want!
    var found = 
        from i in PetService.Pets
        where i.ID == id
        select i;
    return found;
});

app.MapGet("/db", async (PetService pets) =>
{
    await pets.TestDbAsync();
});

app.Run();

class PetService
{
    // Fields
    private readonly DataContext _context;

    static Pet Sil = new Pet{ID = 1, Name= "Sil", Cuteness = 5, PetSpecies = new Species{
            ID = 1, SpeciesName = "Cat"},
        PetOwners = new List<Owner>()};
    static Pet Claude = new Pet{ID = 2, Name= "Claude", Cuteness = 9, PetSpecies = new Species{
            ID = 2, SpeciesName = "Hedgehog"},
        PetOwners = new List<Owner>()};

    public static List<Pet> Pets { get; set; } = new List<Pet>{Sil, Claude};

    // Constructor
    public PetService(DataContext? context)
    {
        this._context = context;
    }

    public async Task TestDbAsync()
    {
        // knowing the state of an object is important to managing your DB!
        var newPet = new Pet{ Name = "Sil", Cuteness = 6}; // Detached - EF/DB don't know about this obect!
        _context.Pets.Add(newPet); // Still not sent to the database, but it's added to our local DbSet
        await _context.SaveChangesAsync(); // newPet is "Added" - Db now knows about this entry!

        newPet.Cuteness = 7; // Modified - the C# object is updated, but the database does't know it yet.

        await _context.SaveChangesAsync(); 

       // _context.Pets.Remove(newPet); 
        await _context.SaveChangesAsync(); // Deleted from the database, but still around in the C# application
        newPet.Name = "Sil'"; // Detached once again!  
    }
}

class Pet
{
    public int ID { get; set; }
    public string? Name { get; set; } = "";
    public int? Cuteness { get; set; }
    public Species? PetSpecies { get; set; } // 1 - 1 relationship
    public List<Owner> PetOwners { get; set; } = new();// many to many relationship
}

class Species
{
    public int ID { get; set;}
    public string? SpeciesName { get; set; }
}

class Owner
{
    public int ID { get; set;}
    public string? Name { get; set; }
    public List<Pet> OwnedPet { get; set; } = new();// 1 to many if only one of the two classes "has" the other
}

class DataContext : DbContext
{
    // Fields
    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<Species> Species => Set<Species>();
    public DbSet<Owner> Owners => Set<Owner>();

    // Constructors
    public DataContext(DbContextOptions<DataContext> options) : base(options) {}
}