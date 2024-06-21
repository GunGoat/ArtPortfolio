using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtPortfolio.Application.Common.Interfaces;

public interface IUnitOfWork {
	IArtistRepository Artist { get; }
	IArtworkRepository Artwork { get; }
}
