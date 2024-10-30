using ViMusic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ViMusic.Infrastructure.Persistence;

public class ApplicationDbContextInitialiser
{
    private readonly ILogger<ApplicationDbContextInitialiser> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitialiser(ILogger<ApplicationDbContextInitialiser> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsNpgsql())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        // Default data
        // Seed, if necessary
        Genre genre = null;
        if (!_context.Genres.Any())
        {
            var genreEntity = _context.Genres.Add(new Genre
            {
                Name = "Pop",
                Description = "Pop music",
            });

            await _context.SaveChangesAsync();

            genre = genreEntity.Entity;
        }
        else
        {
            genre = _context.Genres.First();
        }

        Artist artist = null;
        if (!_context.Artists.Any())
        {
           var artistEntry = _context.Artists.Add(new Artist
           {
               Name = "Pop",
               ImageUrl = "https://pyxis.nymag.com/v1/imgs/3a3/b1f/2141226b8ab1ae07afe4b541ee0d2b0825-11-yic-pop-essay.rhorizontal.w700.jpg"
           });

           await _context.SaveChangesAsync();

           artist = artistEntry.Entity;
        }
        else
        {
           artist = _context.Artists.First();
        }

        if (!_context.Songs.Any())
        {
           _context.Songs.Add(new Song
           {
               Title = "Todo List",
               CoverImageUrl = "https://img.nrj.fr/HAvFqtCk0d2WfgA6JTvmis_eYPY=/0x450/smart/http%3A%2F%2Fmedia.nrj.fr%2F436x327%2F2012%2F06%2Fla-pop-music_7505.jpg",
               Genre = genre,
               Artist = artist
           });

           await _context.SaveChangesAsync();
        }
    }
}
