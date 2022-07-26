// Pluggable.Integration.ElectronicShelfLabel.SES.Models.GetCSVInfoResponse
using Pluggable.Integration.ElectronicShelfLabel.SES.Models;

namespace Pluggable.Integration.ElectronicShelfLabel.SES.Models
{
	public class GetCSVInfoResponse
	{
		public class File
		{
			public string name { get; set; }

			public string receivedDate { get; set; }
		}

		public class Records
		{
			public int valid { get; set; }

			public int duration { get; set; }

			public int ignored { get; set; }

			public int processingSpeedPerHour { get; set; }

			public string endDate { get; set; }

			public int count { get; set; }

			public int invalid { get; set; }

			public int labelsModificationCount { get; set; }

			public string startDate { get; set; }

			public string status { get; set; }
		}

		public string modificationDate { get; set; }

		public File file { get; set; }

		public Records records { get; set; }

		public string externalId { get; set; }

		public string correlationId { get; set; }

		public string eventType { get; set; }

		public string storeId { get; set; }

		public string creationDate { get; set; }

		public string status { get; set; }

		public int _score { get; set; }
	}
}

