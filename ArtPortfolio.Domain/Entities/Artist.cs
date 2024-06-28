using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArtPortfolio.Domain.Entities;

public class Artist {
	[Key]
	public int Id { get; set; }  // Primary Key

	[Required]
	[MaxLength(50)]
	public string FirstName { get; set; }

	[Required]
	[MaxLength(50)]
	public string LastName { get; set; }

	[MaxLength(1000)]
	public string Biography { get; set; }

	[Required]
	[EmailAddress]
	public string Email { get; set; }

	[Url]
	public string Website { get; set; }

    [NotMapped]
    public IFormFile? ProfilePicture { get; set; }

    [MaxLength(255)]
    public string ProfilePictureUrl { get; set; }

	[Required]
	public DateTime DateOfBirth { get; set; }

	// Navigation property
	[ValidateNever]
	public ICollection<Artwork> Artworks { get; set; }
}
