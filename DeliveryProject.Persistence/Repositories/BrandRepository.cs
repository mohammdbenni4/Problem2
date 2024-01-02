using DeliveryProject.Domain.Interfaces;
using DeliveryProject.Persistence.Core.Abstractions.Data;
using Elkood.Domain.Repository;
using Microsoft.Extensions.Options;

namespace DeliveryProject.Persistence.Repositories
{
    public class BrandRepository : ElRepository<Guid, IAppDbContext>, IBrandRepository
    {
        public BrandRepository(IAppDbContext context, IOptions<ElRepositoryOptions> options) : base(context, options)
        {
        }
    }
}
