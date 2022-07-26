// Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Models.StoreConfiguration
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Models
{

	[Table("NEGOZI", Schema = "PARAM")]
	public class StoreConfiguration
	{
		[Key]
		[StringLength(3)]
		public string CODNEG { get; set; }

		[StringLength(150)]
		public string DESNEG { get; set; }

		[StringLength(150)]
		public string INDIRIZZO { get; set; }

		[StringLength(150)]
		public string LOCALITA { get; set; }

		[StringLength(255)]
		public string PATH_INGRESSO { get; set; }

		[StringLength(255)]
		public string PATH_USCITA { get; set; }

		[StringLength(15)]
		public string FTP_IP { get; set; }

		[StringLength(50)]
		public string FTP_USER { get; set; }

		[StringLength(50)]
		public string FTP_PASSWORD { get; set; }

		public bool? FLAG_ATTIVO { get; set; }

		public int? NODE_NUMBER { get; set; }

		public int? NODE_TPISHOP { get; set; }

		[StringLength(50)]
		public string DES_SOC { get; set; }

		public int? COD_CANALE { get; set; }

		public bool? FLAG_FISCALE { get; set; }

		public bool? FLAG_TO_MERSY { get; set; }

		[StringLength(50)]
		public string BATCH_TO_MERSY { get; set; }

		[StringLength(100)]
		public string PROVINCIA { get; set; }

		[StringLength(10)]
		public string CAP { get; set; }

		public bool? FLAG_TPISHOP { get; set; }

		public bool? IsNegBasko { get; set; }

		[StringLength(255)]
		public string CODA_MQ { get; set; }

		public bool? IsMersyNewVersion { get; set; }

		public bool? FlagEL { get; set; }

		public string SES_URL { get; set; }
	}
}

