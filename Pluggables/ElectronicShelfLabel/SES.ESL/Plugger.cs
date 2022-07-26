// Pluggable.Integration.SES.ESL.Plugger

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Plugga.Core.Interfaces;
using Pluggable.Integration.ElectronicShelfLabel.Configurations;
using Pluggable.Integration.ElectronicShelfLabel.Interfaces;

namespace Pluggable.Integration.SES.ESL
{
	public class Plugger : IPluggable
	{
		public void Configure(IApplicationBuilder applicationBuilder, IWebHostEnvironment hostingEnvironment, IConfiguration configuration, ILogger logger)
		{
		}

		public void ConfigureServices(IServiceCollection services, IConfiguration configuration, ILogger logger)
		{
			services.AddSingleton(typeof(IElectronicShelfLabelConfig), typeof(ElectronicShelfLabelConfig));
		}
	}
}

