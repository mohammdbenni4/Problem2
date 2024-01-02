using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DeliveryProject.Api.Util;
using DeliveryProject.Persistence.Test.Queries.GetAll;
using Elkood.API.Controller;
using Elkood.API.Swagger;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DeliveryProject.Api.Controllers;

public class TestController : ElApiController
{
    //[HttpGet, ElRoute(ElApiGroupNames.All), ElApiGroup(ElApiGroupNames.All)]
    //[ProducesResponseType(typeof(GetAllTestQuery.Response), StatusCodes.Status200OK)]
    //public async Task<IActionResult> GetAll(
    //    [FromQuery] GetAllTestQuery.Request request,
    //    [FromServices] IRequestHandler<GetAllTestQuery.Request,
    //        OperationResponse<GetAllTestQuery.Response>> handler)
    //    => await handler.HandleAsync(request).ToJsonResultAsync();

    [HttpGet, ElRoute(ElApiGroupNames.All), ElApiGroup(ElApiGroupNames.All)]
    public async Task<IActionResult> GetToday()
    {
        return Ok("adadasda");
    }
    
}

