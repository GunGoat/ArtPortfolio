namespace ArtPortfolio.Domain.Entities;

public class Artist
{
    public int Id { get; set; }  // Primary Key
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Biography { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string ProfilePictureUrl { get; set; }
    public DateTime DateOfBirth { get; set; }

    // Navigation property
    public ICollection<Artwork> Artworks { get; set; }
}
