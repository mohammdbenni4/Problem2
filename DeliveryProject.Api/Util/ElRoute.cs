using Elkood.API.Swagger;
using Microsoft.AspNetCore.Mvc;

namespace DeliveryProject.Api.Util;

public class ElRoute : RouteAttribute
{
    public ElRoute(ElApiGroupNames name) : base($"api/{name}/[controller]/[action]")
    {
        
    }
}