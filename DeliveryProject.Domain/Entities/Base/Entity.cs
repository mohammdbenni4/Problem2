using Elkood.Domain.Primitives.Entity.Base;

namespace DeliveryProject.Domain.Entities.Base;

public class Entity : BaseEntity<Guid>	
{
	public Entity()
	{
		Id = Guid.NewGuid();
	}
}

