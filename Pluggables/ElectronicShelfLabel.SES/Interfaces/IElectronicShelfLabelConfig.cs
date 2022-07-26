// Pluggable.Integration.ElectronicShelfLabel.SES.Interfaces.IElectronicShelfLabelConfig
using System.Collections.Generic;
using Pluggable.Integration.ElectronicShelfLabel.Interfaces;
using Pluggable.Integration.ElectronicShelfLabel.Models;

namespace Pluggable.Integration.ElectronicShelfLabel.SES.Interfaces
{
	public interface IElectronicShelfLabelConfig : Pluggable.Integration.ElectronicShelfLabel.Interfaces.IElectronicShelfLabelConfig
	{
		string OcpApimSubscriptionKey { get; set; }

		string BasePostPackageUri { get; set; }

		string BaseGetPackageInfoUri { get; set; }

		bool CSVHeaderRequired { get; set; }

		bool CSVCompressionRequired { get; set; }

		int GetPackageInfoNumberOfRetries { get; set; }

		int GetPackageInfoNumberOfRetriesMillisecondsSleepingTime { get; set; }

		string GetDomainPostPackageUri(List<ElectronicShelfLabelData> package);

		string GetDomainGetPackageInfoUri(List<ElectronicShelfLabelData> package);
	}
}

