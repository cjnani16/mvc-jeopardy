using AutoMapper;
using MVCJeopardy.Core.Domain;
using MVCJeopardy.UI.Models;

namespace MVCJeopardy.UI.Helpers
{

public static class AutoMapperBootstrapper
	{
		public static void Initialize()
		{
			Mapper.Initialize(cfg =>
			{
				cfg.AddProfile<WebAutoMapperProfile>();
			});
		}
	}

	public class WebAutoMapperProfile : Profile
	{
		protected override void Configure()
		{
			
		}
	}
}
