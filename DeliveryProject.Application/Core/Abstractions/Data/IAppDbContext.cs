using Elkood.Application.Core.Abstractions.Data;

namespace DeliveryProject.Persistence.Core.Abstractions.Data;

public interface IAppDbContext : IDbContext<Guid>
{
}

