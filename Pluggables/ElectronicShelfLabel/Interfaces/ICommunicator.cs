// Pluggable.Integration.ElectronicShelfLabel.Interfaces.ICommunicator
using System.Collections.Generic;
using System.Threading.Tasks;
using Pluggable.Integration.ElectronicShelfLabel.Enum;
using Pluggable.Integration.ElectronicShelfLabel.Models;

namespace Pluggable.Integration.ElectronicShelfLabel.Interfaces
{
    public interface ICommunicator
    {
        Task<DataState> Send(List<ElectronicShelfLabelData> data);
    }
}