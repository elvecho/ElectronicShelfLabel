// Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Models.DBElectronicShelfLabelData
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Pluggable.Integration.ElectronicShelfLabel.Enum;
using Pluggable.Integration.ElectronicShelfLabel.Models;

namespace Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Models
{

	[Table("ElTrasmissionQueue", Schema = "PARAM")]
	public class DBElectronicShelfLabelData : ElectronicShelfLabelData
	{
		[Key]
		public long QueueId { get; set; }

		public long? RefToTPTrx { get; set; }

		public byte SalesChannel { get; set; }

		public short StoreId { get; set; }

		[Required]
		[StringLength(13)]
		public string ItemId { get; set; }

		[Required]
		[StringLength(20)]
		public string ReordBarcode { get; set; }

		[Required]
		[StringLength(13)]
		public string ReordCode { get; set; }

		[Required]
		[StringLength(40)]
		public string Description { get; set; }

		[Required]
		[StringLength(5)]
		public string UnitOfMeasure { get; set; }

		[Required]
		[StringLength(13)]
		public string UMPrice { get; set; }

		[Required]
		[StringLength(13)]
		public string PackageContents { get; set; }

		[Required]
		[StringLength(13)]
		public string SellingPrice { get; set; }

		[Required]
		[StringLength(13)]
		public string PackingItemNo { get; set; }

		[Required]
		[StringLength(20)]
		public string MasterEan { get; set; }

		[StringLength(20)]
		public string PromoCmpCode { get; set; }

		[StringLength(20)]
		public string PromoAvtId { get; set; }

		[StringLength(40)]
		public string PromoType { get; set; }

		[StringLength(150)]
		public string PromoAdditionaInfo { get; set; }

		[StringLength(150)]
		public string PromoAdditionaInfo2 { get; set; }

		[StringLength(13)]
		public string PromoPrice { get; set; }

		[StringLength(13)]
		public string PromoUMPrice { get; set; }

		[StringLength(20)]
		public string PromoCluster { get; set; }

		[StringLength(13)]
		public string PromoEPurse { get; set; }

		[StringLength(10)]
		public string PromoStartDate { get; set; }

		[StringLength(10)]
		public string PromoEndDate { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime? QueueDateTime { get; set; }

		[Column(TypeName = "tinyint")]
		public DataState ElabState { get; set; }

		[Column(TypeName = "datetime")]
		public DateTime LastUpdate { get; set; }
	}
}

