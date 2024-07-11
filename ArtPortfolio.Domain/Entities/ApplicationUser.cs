using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Domain.Entities;

public class ApplicationUser : IdentityUser {
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }

    // Foreign Key
    [ForeignKey("Artist")]
    [Display(Name = "Artist")]
    public int? ArtistId { get; set; }
}
