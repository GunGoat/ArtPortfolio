using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Infrastructure.Repository;

public class ArtistRepository : Repository<Artist>, IArtistRepository {
	private readonly ApplicationDbContext _db;

	public ArtistRepository(ApplicationDbContext db) : base(db) {
		_db = db;
	}

	public void Update(Artist entity) {
		_db.Artists.Update(entity);
	}
}
