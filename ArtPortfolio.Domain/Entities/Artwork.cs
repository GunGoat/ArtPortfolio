using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Domain.Entities;

public class Artwork
{
    public int Id { get; set; }  // Primary Key
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public string Medium { get; set; }
    public string Dimensions { get; set; }
    public string ImageUrl { get; set; }

    // Foreign Key
    public int ArtistId { get; set; }

    // Navigation property
    public Artist Artist { get; set; }
}
