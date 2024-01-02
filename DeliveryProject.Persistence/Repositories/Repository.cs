using DeliveryProject.Domain.Interfaces;
using DeliveryProject.Persistence.Core.Abstractions.Data;
using Elkood.Domain.Repository;
using Microsoft.Extensions.Options;

namespace DeliveryProject.Persistence.Repositories
{
    public class Repository : ElRepository<Guid, IAppDbContext>, IRepository
    {
        public Repository(IAppDbContext context, IOptions<ElRepositoryOptions> options) : base(context, options)
        {
        }
    }
}
