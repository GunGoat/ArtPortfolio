using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Infrastructure.Repository;

public class UnitOfWork : IUnitOfWork {
	readonly ApplicationDbContext _db;
	public IArtistRepository Artist { get; private set; }
	public IArtworkRepository Artwork { get; private set; }

	public UnitOfWork(ApplicationDbContext db) {
		_db = db;
		Artist = new ArtistRepository(_db);
		Artwork = new ArtworkRepository(_db);
	}
}
