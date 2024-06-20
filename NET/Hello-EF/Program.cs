using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<PetService>();

string? connectionString = builder.Configuration.GetConnectionString("Docker");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseSqlServer(connectionString)
    );

var app = builder.Build();

// Test the api with a "hello world"
// https://localhost:xxxx
app.MapGet("/", () => "Hello World!");

//CRUD - Create, Read, Update, Delete
// HTTP - POST, GET, PUT, DETELE

// GET All the pets!
// https://localhost:xxxx/pets
app.MapGet("/pets", (PetService pets) =>
{
    return PetService.Pets;
});

// GET a specific pet?
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

// Database test
// https://localhost:xxxx/db
app.MapGet("/db", async (PetService pets) =>
{
    await pets.TestDbAsync();
});

// GET does not include a body!!
// DELETE does not include a body!!!
// POST and PUT will have a body, and we can place an object (in serialized form!) in the body

// POST a new pet (includes the new pet object?)
// https://localhost:xxxx/pets
app.MapPost("/pets", (PetService pets, [FromBody] Pet newPet) =>
{
    PetService.Pets.Add(newPet);
    return PetService.Pets;
});

// PUT an update on a pet
// https://locahost:xxxx/pets/{id}
app.MapPut("/pets/{id}", async (int id, Pet updatePet, PetService pets) =>
{
    if (PetService.Pets.Exists(x => x.ID == id))
    {
        int i = PetService.Pets.FindIndex(x => x.ID == id);

        PetService.Pets[i] = updatePet;
        return Results.Ok(PetService.Pets.Find(x => x.ID == updatePet.ID));
    }
    return Results.NotFound();
});

// DELETE a pet by id
// https://localhost:xxxx/pets/{id}
app.MapDelete("/pets/{id}", (int id, PetService pets) =>
{
    if (PetService.Pets.Exists(x => x.ID == id))
    {
        Pet toDelete = PetService.Pets.Find(x => x.ID == id);

        return (PetService.Pets.Remove(toDelete)) ? Results.NoContent() : Results.NotFound();
    }
    return Results.NotFound();
});

// DELETE a pet by body
// https://localhost:xxxx/pets/
app.MapDelete("/pets/b", ([FromBody] Pet toDelete, [FromServices] PetService pets) =>
{
    return (PetService.Pets.Remove(toDelete)) ? Results.NoContent() : Results.NotFound();
});

// DELETE ALL PETS!!!
// https://localhost:xxxx/pets
app.MapDelete("/pets", (PetService pets) => 
{
    PetService.Pets.Clear();
    return Results.Ok();
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