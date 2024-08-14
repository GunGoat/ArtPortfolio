using ArtPortfolio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Application.Common.Interfaces;

public interface IApplicationUserRepository : IRepository<ApplicationUser> {
	void Update(ApplicationUser entity);
}