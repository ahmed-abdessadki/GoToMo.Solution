
using GoToMo.Dto.Infrastructure;

namespace GoToMo.Dto.Movies
{
	public class StreamingService:Entity
	{
		public required string Name { get; set; }

		public required string Url { get; set; }

		public StreamingService(string name, string url)
		{
			Name = name;
			Url = url;
		}
		
	}
}
