using DeliveryProject.Persistence.Core.Abstractions.Data;
using DeliveryProject.Domain.Entities;
using DeliveryProject.Persistence.Data;
using Elkood.Application.Security.JWT.DependencyInjection;
using Elkood.DependencyInjection;
using Elkood.Domain.Repository;
using Elkood.Identity.DependencyInjection;
using Elkood.Identity.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DeliveryProject.Persistence;

public static class DependencyInjection
{
	public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
	{
		services.AddElDbContext<IAppDbContext, AppDbContext>
		(o =>
		{
			o.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
			if (environment.IsDevelopment())
			{
				o.EnableSensitiveDataLogging();
			}
		});


  //      services.AddElIdentity<User, ElIdentityRole, AppDbContext>(options =>
		//{
		//	options.Password.RequiredLength = 4;
		//	options.Password.RequiredUniqueChars = 0;
		//	options.Password.RequireDigit = false;
		//	options.Password.RequireNonAlphanumeric = false;
		//	options.Password.RequireUppercase = false;
		//	options.Password.RequireLowercase = false;
		//}).AddJwtBearerAuthentication(configuration);

        return services;
	}
}

