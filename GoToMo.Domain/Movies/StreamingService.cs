
using GoToMo.Domain.Infrastructure;

namespace GoToMo.Domain.Movies
{
	public class StreamingService : Entity
	{
		public string Name { get; set; }

		public string Url { get; set; }

		public List<Production> Productions { get; set; } = new();

		public StreamingService(string name, string url)
		{
			Name = name;
			Url = url;
		}
		
	}
}
