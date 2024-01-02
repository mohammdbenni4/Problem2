using DeliveryProject.Domain.Entities.Brands;
using DeliveryProject.Domain.Interfaces;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryProject.Application.Brands.Commands.AddBrand
{
    public class AddBrandHandler : IRequestHandler<AddBrandCommand.Request,
        OperationResponse<AddBrandCommand.Response>>
    {
        private readonly IBrandRepository _brandRepository;
        public AddBrandHandler(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public async Task<OperationResponse<AddBrandCommand.Response>> HandleAsync(AddBrandCommand.Request request, CancellationToken cancellationToken = default)
        {
           var brand = new Brand();
            brand.Name = request.Name; 
            brand.Id = Guid.NewGuid();

            var ret = new AddBrandCommand.Response();
            ret.Id = brand.Id;
            ret.Name = brand.Name;

            await _brandRepository.AddAsync(brand);
            await _brandRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return ret;


        }
    }
}
