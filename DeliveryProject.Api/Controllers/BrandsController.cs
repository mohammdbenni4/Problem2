using DeliveryProject.Application.Brands.Commands.AddBrand;
using Elkood.API.Controller;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ElApiController
    {
        [HttpPost]
        public async Task<IActionResult> Add(
            [FromServices] IRequestHandler<AddBrandCommand.Request,
        OperationResponse<AddBrandCommand.Response>> handler,
            [FromBody] AddBrandCommand.Request request) 
            => await handler.HandleAsync(request).ToJsonResultAsync();

    }
}
