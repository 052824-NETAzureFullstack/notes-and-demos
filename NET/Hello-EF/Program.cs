using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("Docker");

builder.Services.AddDbContext<PetContext>(options =>
    options.UseSqlServer(connectionString)
    );

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// app.MapGet("/pets", async (PetContext) =>
// {
//     // knowing the state of an object is important to managing your DB!
//     var newPet = new Pet{ Name = "Sil", Cuteness = 6}; // Detached - EF/DB don't know about this obect!
//     PetContext.Pets.Add(newPet); // Still not sent to the database, but it's added to our local DbSet
//     await PetContext.SaveChangesAsync(); // newPet is "Added" - Db now knows about this entry!

//     newPet.Cuteness = 7; // Modified - the C# object is updated, but the database does't know it yet.

//     await PetContext.SaveChangesAsync(); 

//     PetContext.Pets.Remove(newPet); 
//     await PetContext.SaveChangesAsync() // Deleted from the database, but still around in the C# application
//     newPet.Name = "Sil'"; // Detached once again!
//     return Task.FromResult(newPet);
// });

app.Run();


class Pet
{
    public int ID { get; set; }
    public string Name { get; set; } = "";
    public int? Cuteness { get; set; }
    public Species PetSpecies { get; set; } // 1 - 1 relationship
    public List<Owner> PetOwners { get; set; } // many to many relationship
}

class Species
{
    public int ID { get; set;}
    public string SpeciesName { get; set; }
}

class Owner
{
    public int ID { get; set;}

    [MaxLength(100)]
    public string Name { get; set; }
    public List<Pet> OwnedPet { get; set; } // 1 to many if only one of the two classes "has" the other
}

class PetContext : DbContext
{
    // Fields
    public DbSet<Pet> Pets => Set<Pet>();
    public DbSet<Species> Species => Set<Species>();
    public DbSet<Owner> Owners => Set<Owner>();

    // Constructors
    public PetContext(DbContextOptions<PetContext> options) : base(options) {}
}