// Pluggable.Integration.ElectronicShelfLabel.Interfaces.IElectronicShelfLabelConfig
using System;

namespace Pluggable.Integration.ElectronicShelfLabel.Interfaces
{
	public interface IElectronicShelfLabelConfig
	{
		string DataManager { get; set; }

		string Communicator { get; set; }

		string Configuration { get; set; }

		TimeSpan CheckInterval { get; set; }
	}
}
