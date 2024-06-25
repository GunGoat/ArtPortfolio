using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

	[Url]
	public string ImageUrl { get; set; }

	// Foreign Key
	[ForeignKey("Artist")]
	public int ArtistId { get; set; }

	// Navigation property
	public Artist Artist { get; set; }
}