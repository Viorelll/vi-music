using ViMusic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ViMusic.Application.Common.Models;

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
        // Default data, (seed, if necessary)

        //CREATE USERS
        var user = await CreateUsers();

        //CREATE GENRES
        var genre = await CreateGenres();

        //CREATE ARTISTS
        await CreateArtists();

        //CREATE PLAYLISTS
        var playlists = await CreatePlaylists();

        //CREATE SONGS
        var songs = await CreateSongs();

        //CREATE PLAYLISTS-SONGS
        await CreatePlaylistSongs(playlists, songs);
    }

    private async Task CreatePlaylistSongs(List<Playlist> playlists, List<Song> songs)
    {
        if (!_context.PlaylistSongs.Any())
        {
            var playlist = playlists.FirstOrDefault(playlist => playlist.Name == "ViPlaylist");
            var playlist2 = playlists.FirstOrDefault(playlist => playlist.Name == "Global Top 50");
          

            foreach (var song in songs)
            {
                _context.PlaylistSongs.Add(new PlaylistSong
                {
                    Playlist = playlist,
                    Song = song
                });
            }

            foreach (var song in songs.Where(song => song.Artist.Name == "Ed Sheeran"))
            {
                _context.PlaylistSongs.Add(new PlaylistSong
                {
                    Playlist = playlist2,
                    Song = song
                });
            }

            await _context.SaveChangesAsync();
        }
    }

    private async Task<List<Song>> CreateSongs()
    {
        var artists = _context.Artists.ToList();
        var artist1 = artists.FirstOrDefault(artist => artist.Name == "Ed Sheeran");
        var artist2 = artists.FirstOrDefault(artist => artist.Name == "INNA");
        var artist3 = artists.FirstOrDefault(artist => artist.Name == "Carla's Dreams");
        var artist4 = artists.FirstOrDefault(artist => artist.Name == "Dan Balan");
        var artist5 = artists.FirstOrDefault(artist => artist.Name == "Irina Rimes");
        var artist6 = artists.FirstOrDefault(artist => artist.Name == "Martin Garrix");
        var artist7 = artists.FirstOrDefault(artist => artist.Name == "Miley Cyrus");
        var artist8 = artists.FirstOrDefault(artist => artist.Name == "R3HAB & VINAI");
        var artist9 = artists.FirstOrDefault(artist => artist.Name == "Selena Gomez");
        var artist10 = artists.FirstOrDefault(artist => artist.Name == "Shawn Mendes, Camilia Cabello");
        var artist11 = artists.FirstOrDefault(artist => artist.Name == "Tones and I");

        var songs = new List<Song>
            {
                new Song
                {
                    Title = "Imperfect",
                    CoverImageUrl ="../../assets/songimages/Carla's Dreams - Imperfect  Official Video.jpg",
                    LocationUrl = "../../assets/songs/Carla's Dreams - Imperfect  Official Video.mp3",
                    Artist = artist3 
                },
                new Song
                {
                    Title = "Chica Bomb",
                    CoverImageUrl ="../../assets/songimages/Dan Balan - Chica Bomb.jpg",
                    LocationUrl = "../../assets/songs/Dan Balan - Chica Bomb Official Video HD Hype Williams.mp3",
                    Artist = artist4
                },
                new Song
                {
                    Title = "Perfect",
                    CoverImageUrl ="../../assets/songimages/Ed Sheeran - Perfect.jpg",
                    LocationUrl = "../../assets/songs/Ed Sheeran - Perfect (Official Music Video).mp3",
                    Artist = artist1
                },
                new Song
                {
                    Title = "Shape of You",
                    CoverImageUrl ="../../assets/songimages/Ed Sheeran - Shape of You.jpg",
                    LocationUrl = "../../assets/songs/Ed Sheeran - Shape of You (Official Music Video).mp3",
                    Artist = artist1
                },
                new Song
                {
                    Title = "Hot",
                    CoverImageUrl ="../../assets/songimages/Inna - Hot.jpg",
                    LocationUrl = "../../assets/songs/Inna - Hot (Official Video HD).mp3",
                    Artist = artist2
                },
                new Song
                {
                    Title = "Up",
                    CoverImageUrl ="../../assets/songimages/Inna - Up.jpg",
                    LocationUrl = "../../assets/songs/Inna - Up.mp3",
                    Artist = artist2
                },
                new Song
                {
                    Title = "N-avem timp",
                    CoverImageUrl ="../../assets/songimages/Irina Rimes - N-avem timp.jpg",
                    LocationUrl = "../../assets/songs/Irina Rimes - N-avem timp  Official Video.mp3",
                    Artist = artist5
                },
                new Song
                {
                    Title = "Forbidden Voices",
                    CoverImageUrl ="../../assets/songimages/Martin Garrix - Forbidden Voices.jpg",
                    LocationUrl = "../../assets/songs/Martin Garrix - Forbidden Voices (Official Music Video).mp3",
                    Artist = artist6
                },
                new Song
                {
                    Title = "Flowers",
                    CoverImageUrl ="../../assets/songimages/Miley Cyrus - Flowers.jpg",
                    LocationUrl = "../../assets/songs/Miley Cyrus - Flowers (Official Video).mp3",
                    Artist = artist7
                },
                new Song
                {
                    Title = "How We Party",
                    CoverImageUrl ="../../assets/songimages/R3HAB & VINAI - How We Party.jpg",
                    LocationUrl = "../../assets/songs/R3HAB & VINAI - How We Party (Official Music Video).mp3",
                    Artist = artist8
                },
                new Song
                {
                    Title = "Calm",
                    CoverImageUrl ="../../assets/songimages/Rema-Selena-Gomez-Calm-Down-2022-billboard-1548.webp",
                    LocationUrl = "../../assets/songs/Rema, Selena Gomez - Calm Down (Official Music Video).mp3",
                    Artist = artist9
                },
                new Song
                {
                    Title = "Señorita",
                    CoverImageUrl ="../../assets/songimages/Shawn Mendes, Camila Cabello - Señorita.jpg",
                    LocationUrl = "../../assets/songs/Shawn Mendes, Camila Cabello - Señorita.mp3",
                    Artist = artist10
                },
                new Song
                {
                    Title = "DANCE MONKEY",
                    CoverImageUrl ="../../assets/songimages/TONES AND I - DANCE MONKEY.jpg",
                    LocationUrl = "../../assets/songs/TONES AND I - DANCE MONKEY (OFFICIAL VIDEO).mp3",
                    Artist = artist11
                }
            };

        if (!_context.Songs.Any())
        {
            _context.Songs.AddRange(songs);

            await _context.SaveChangesAsync();
        }

        return songs;
    }

    private async Task<List<Playlist>> CreatePlaylists()
    {
        var playlists = new List<Playlist>
            {
                new Playlist
                {
                    Name = "Global Top 50",
                    CoverImageUrl = "../../assets/playlistimages/cover1.jpg",
                    User = Users.SystemUser,
                },
                new Playlist
                {
                    Name = "I get back to the dream",
                    CoverImageUrl = "../../assets/playlistimages/cover2.jpg",
                    User = Users.SystemUser,
                },
                new Playlist
                {
                    Name = "WHO YOU ARE!",
                    CoverImageUrl = "../../assets/playlistimages/cover3.jpg",
                    User = Users.SystemUser,
                },
                new Playlist
                {
                    Name = "ViPlaylist",
                    CoverImageUrl = "../../assets/playlistimages/cover4.jpg",
                    User = Users.SystemUser,
                }
            };
        
        if (!_context.Playlists.Any())
        {
            _context.Playlists.AddRange(playlists);

            await _context.SaveChangesAsync();
        }

        return playlists;
    }

    private async Task<User> CreateUsers()
    {
        User user = null;
        if (!_context.Users.Any())
        {
            var userEntity = _context.Users.Add(Users.SystemUser);

            await _context.SaveChangesAsync();

            user = userEntity.Entity;
        }
        else
        {
            user = _context.Users.First();
        }

        return user;
    }

    private async Task<Genre> CreateGenres()
    {
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

        return genre;
    }

    private async Task CreateArtists()
    {
        var artists = new List<Artist> {
            new Artist
            {
                Name = "Ed Sheeran",
                ImageUrl = "https://i.iheart.com/v3/surl/aHR0cDovL2ltYWdlLmloZWFydC5jb20vaW1hZ2VzL3JvdmkvMTA4MC8wMDA1LzgzOS9NSTAwMDU4MzkwNjcuanBn?ops=fit%28720%2C720%29&sn=eGtleWJhc2UyMDIxMTExMDq9rG-Vld6sQd9Q-ofOr6HcTrxy93WdqAgLghFWm4wFdA%3D%3D&surrogate=1cOXl179JY-syhxYSCX6Q1a_Mcu6UO8d-F4oJzpZf1hcUbJr4aImzdcOGEf7jx8Dyc-TVn0NCe4274Vj8_8pmrWntbcuAB0Upw-ZmFv1o3y1-KgHYz8LBCmgkExfmyLdymml_R9eJScNTb22YeRUCulglAw18rZ6iEqT1ZQxxQs7hhVu2yZT6uq9nDFNVFsoZ2Yaput_ptV3PPFTzatGY_37zkU4BA%3D%3D"
            },
            new Artist
            {
                Name = "INNA",
                ImageUrl = "https://i.iheart.com/v3/surl/aHR0cDovL2ltYWdlLmloZWFydC5jb20vaW1hZ2VzL3JvdmkvMTA4MC8wMDA1LzgzOS9NSTAwMDU4MzkwNjcuanBn?ops=fit%28720%2C720%29&sn=eGtleWJhc2UyMDIxMTExMDq9rG-Vld6sQd9Q-ofOr6HcTrxy93WdqAgLghFWm4wFdA%3D%3D&surrogate=1cOXl179JY-syhxYSCX6Q1a_Mcu6UO8d-F4oJzpZf1hcUbJr4aImzdcOGEf7jx8Dyc-TVn0NCe4274Vj8_8pmrWntbcuAB0Upw-ZmFv1o3y1-KgHYz8LBCmgkExfmyLdymml_R9eJScNTb22YeRUCulglAw18rZ6iEqT1ZQxxQs7hhVu2yZT6uq9nDFNVFsoZ2Yaput_ptV3PPFTzatGY_37zkU4BA%3D%3D"
            },
            new Artist
            {
                Name = "Carla's Dreams",
                ImageUrl = ""
            },
            new Artist
            {
                Name = "Dan Balan",
                ImageUrl = ""
            },
            new Artist
            {
                Name = "Irina Rimes",
                ImageUrl = ""
            },
            new Artist
            {
                Name = "Martin Garrix",
                ImageUrl = ""
            },
            new Artist
            {
                Name = "Miley Cyrus",
                ImageUrl = ""
            },
            new Artist
            {
                Name = "R3HAB & VINAI",
                ImageUrl = ""
            },
            new Artist
            {
                Name = "Selena Gomez",
                ImageUrl = ""
            },
            new Artist
            {
                Name = "Shawn Mendes, Camilia Cabello",
                ImageUrl = ""
            },
            new Artist
            {
                Name = "Tones and I",
                ImageUrl = ""
            }
        };

        if (!_context.Artists.Any())
        {
            _context.Artists.AddRange(artists);

            await _context.SaveChangesAsync();
        }
    }
}
