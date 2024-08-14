using ArtPortfolio.Application.Common.Interfaces;
using ArtPortfolio.Domain.Entities;
using ArtPortfolio.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Infrastructure.Repository;


public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository {
	private readonly ApplicationDbContext _db;

	public ApplicationUserRepository(ApplicationDbContext db) : base(db) {
		_db = db;
	}

	public void Update(ApplicationUser entity) {
		_db.ApplicationUsers.Update(entity);
	}
}