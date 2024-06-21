using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Infrastructure.Repository;

public class ArtworkRepository : Repository<Artwork>, IArtworkRepository {
	private readonly ApplicationDbContext _db;

	public ArtworkRepository(ApplicationDbContext db) : base(db) {
		_db = db;
	}

	public void Update(Artwork entity) {
		_db.Artworks.Update(entity);
	}
}
