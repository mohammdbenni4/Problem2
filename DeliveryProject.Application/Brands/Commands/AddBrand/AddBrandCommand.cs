using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryProject.Application.Brands.Commands.AddBrand
{
    public class AddBrandCommand
    {
        public class Request : IRequest<OperationResponse<Response>>
        {
            public string Name { get; set; }
        }

        public class Response
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
        }
    }
}
