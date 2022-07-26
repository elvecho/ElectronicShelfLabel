// Pluggable.Integration.ElectronicShelfLabel.Interfaces.IDataManager
using System.Collections.Generic;
using System.Threading.Tasks;
using Pluggable.Integration.ElectronicShelfLabel.Enum;
using Pluggable.Integration.ElectronicShelfLabel.Models;

namespace Pluggable.Integration.ElectronicShelfLabel.Interfaces
{
	public interface IDataManager
	{
		Task<bool> HasPendingPackages();

		Task<List<ElectronicShelfLabelData>> AllPackages();

		IAsyncEnumerable<List<ElectronicShelfLabelData>> NextPendingPackage();

		Task<bool> SetPackage(List<ElectronicShelfLabelData> package, DataState state);
	}
}

