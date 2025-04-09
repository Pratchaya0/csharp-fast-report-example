using SimpleFastReport.API.Helpers;
using SimpleFastReport.API.Services;

namespace SimpleFastReport.API
{
	public static class ProjectSetup
	{

		public static IServiceCollection ConfigDependency(this IServiceCollection services, IConfiguration configuration)
		{

			services.AddScoped<IReportServices, ReportServices>();
			services.AddSingleton<FastReportHelper>();

			// TODO: ตัวอย่างการเขียน RestSharp หากไม่ใช้ให้ลบ Folder Examples ทิ้ง
			// วิธีการเขียน RestSharp
			// https://github.com/SiamsmileDev/DevKnowledgeBase/blob/develop/Example%20Code/CSharp/RestSharp%20Example.md

			// services.Configure<ServiceURL>(configuration.GetSection("ServiceURL"));
			// services.AddSingleton<ShortLinkClient>();
			// services.AddSingleton<SendSmsClient>();

			return services;
		}

	}
}
