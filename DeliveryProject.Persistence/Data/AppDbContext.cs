using System.Reflection;
using DeliveryProject.Persistence.Core.Abstractions.Data;
using DeliveryProject.Domain.Entities;
using Elkood.Application.Core.Abstractions.Common;
using Elkood.Application.Dispatchers.DomainEventDispatcher;
using Elkood.Identity.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using DeliveryProject.Domain.Entities.Brands;

namespace DeliveryProject.Persistence.Data;

public class AppDbContext : ElIdentityDbContext<User> ,IAppDbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options,
		IDateTime dateTime,
		IDomainEventDispatcher domainEventDispatcher)
		: base(options, dateTime, domainEventDispatcher) 
	{
	}
    
    public DbSet<Brand> Brands { get; set; }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		//builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
}

