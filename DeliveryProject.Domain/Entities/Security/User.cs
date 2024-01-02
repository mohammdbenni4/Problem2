using Elkood.Identity.Entities;

namespace DeliveryProject.Domain.Entities;

public class User : ElIdentityUserAggregate
{
	protected User()
	{
		Id = Guid.NewGuid();
		UserName = Guid.NewGuid().ToString();
	}
    public DateOnly? BirthDate { get; protected set; }
}

