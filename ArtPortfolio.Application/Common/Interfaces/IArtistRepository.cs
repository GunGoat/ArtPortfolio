using ArtPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Application.Common.Interfaces;

public interface IArtistRepository : IRepository<Artist> {
	void Update(Artist entity);
}
