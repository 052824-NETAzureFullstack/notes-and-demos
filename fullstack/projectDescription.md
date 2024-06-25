# Sheet Music Share

## Architecture
- Fullstack Angular SPA, ASP.NET API, MS SQL Server DB, Entity Framework Core ORM

## User Stories
- A user should be able to see a piece of music saved to the application. (Read/GET)
- A user should be able to add a new piece of music to the application. (Create/POST)
- A user should be able to update or modify a piece of music already in the application. (Update/PUT)
- A user should be able to delete a piece of music from the application. (Delete/DELETE)

## Objects
### SPA
- Song
    - ID - int
    - Title - string
    - Artist/Composer - List<string>
    - Resource URL - string
    - Rating - double
    - Genre - string
    - Tempo - int

### API 
- Song
    - ID - int
    - Title - String
    - Artist/Composer - List<artist>
    - Resource URL - String
    - TotalRating - int
    - RatingCount - int
    - AverageRating - double (calculated from Ratings)
    - Genre - Genre
    - Tempo - int

- Artist
    - ID - int
    - Name - String

- Genre
    - ID - int
    - Name - String