using System.Linq.Expressions;
using DeliveryProject.Domain.Entities;
using Elkood.Application.Core.Abstractions.Request;
using Elkood.Application.OperationResponses;

namespace DeliveryProject.Persistence.Test.Queries.GetAll;

public class GetAllTestQuery
{
	public class Request : IRequest<OperationResponse<Response>>
	{
		public int Id { get; set; }
	}
	public class Response
	{
		public List<Test1> tests { get; set; }

		public class Test1
		{
			public int Id { get; set; }
			public string Name { get; set; }
		}

		public static Expression<Func<TestModel, Test1>> Selector()
			=> a => new()
			{
				Id = a.id
			};
	}
}

