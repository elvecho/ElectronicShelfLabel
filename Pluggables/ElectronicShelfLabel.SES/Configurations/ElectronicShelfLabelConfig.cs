// Pluggable.Integration.ElectronicShelfLabel.SES.Configurations.ElectronicShelfLabelConfig
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pluggable.Integration.ElectronicShelfLabel.Configurations;
using Pluggable.Integration.ElectronicShelfLabel.Interfaces;
using Pluggable.Integration.ElectronicShelfLabel.Models;
using Pluggable.Integration.ElectronicShelfLabel.SES.Configurations;
using Pluggable.Integration.ElectronicShelfLabel.SES.Interfaces;

namespace Pluggable.Integration.ElectronicShelfLabel.SES.Configurations
{
	public class ElectronicShelfLabelConfig : Pluggable.Integration.ElectronicShelfLabel.Configurations.ElectronicShelfLabelConfig, Pluggable.Integration.ElectronicShelfLabel.SES.Interfaces.IElectronicShelfLabelConfig, Pluggable.Integration.ElectronicShelfLabel.Interfaces.IElectronicShelfLabelConfig
	{
		public virtual string OcpApimSubscriptionKey { get; set; }

		public virtual string BasePostPackageUri { get; set; }

		public virtual string BaseGetPackageInfoUri { get; set; }

		public bool CSVHeaderRequired { get; set; } = false;


		public bool CSVCompressionRequired { get; set; } = false;


		public int GetPackageInfoNumberOfRetries { get; set; } = 6;


		public int GetPackageInfoNumberOfRetriesMillisecondsSleepingTime { get; set; } = 10000;


		public virtual string GetDomainGetPackageInfoUri(List<ElectronicShelfLabelData> package)
		{
			return BaseGetPackageInfoUri;
		}

		public virtual string GetDomainPostPackageUri(List<ElectronicShelfLabelData> package)
		{
			return BasePostPackageUri;
		}

		public ElectronicShelfLabelConfig(ILogger<Pluggable.Integration.ElectronicShelfLabel.SES.Configurations.ElectronicShelfLabelConfig> logger, IConfiguration configuration)
			: base(logger, configuration)
		{
		}
	}
}

