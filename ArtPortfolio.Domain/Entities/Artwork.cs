using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Http;

namespace ArtPortfolio.Domain.Entities;

public class Artwork {
	[Key]
	public int Id { get; set; }  // Primary Key

	[Required]
	[MaxLength(100)]
	public string Title { get; set; }

	[MaxLength(1000)]
	public string Description { get; set; }

	[Required]
	public DateTime CreationDate { get; set; }

	[MaxLength(100)]
	public string Medium { get; set; }

	[MaxLength(100)]
	public string Dimensions { get; set; }

    [NotMapped]
    public IFormFile? Image { get; set; }

    [MaxLength(255)]
    public string ImageUrl { get; set; } // Relative path to the image file

    // Foreign Key
    [ForeignKey("Artist")]
    [Display(Name = "Artist")]
    public int ArtistId { get; set; }

    // Navigation property
    [ValidateNever]
    public Artist Artist { get; set; }
}