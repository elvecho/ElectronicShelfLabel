// Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Configurations.ElectronicShelfLabelConfig
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pluggable.Integration.ElectronicShelfLabel.Models;
using Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Context;
using Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Models;

namespace Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Configurations
{
    public class ElectronicShelfLabelConfig : Pluggable.Integration.ElectronicShelfLabel.SES.Configurations.ElectronicShelfLabelConfig
	{
		private readonly ILogger<Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Configurations.ElectronicShelfLabelConfig> _logger;

		private readonly DbContextOptions<ElectronicShelfLabelContext> _options;

		private readonly IConfiguration _configuration;

		public override string GetDomainGetPackageInfoUri(List<ElectronicShelfLabelData> package)
		{
			return string.Format(BaseGetPackageInfoUri, GetDomain(package));
		}

		public override string GetDomainPostPackageUri(List<ElectronicShelfLabelData> package)
		{
			return string.Format(BasePostPackageUri, GetDomain(package));
		}

		public virtual string GetDomain(List<ElectronicShelfLabelData> package)
		{
			ElectronicShelfLabelContext ctx = new ElectronicShelfLabelContext(_options, _configuration);
			try
			{
				DBElectronicShelfLabelData record = package.First() as DBElectronicShelfLabelData;
				return (from w in (IQueryable<StoreConfiguration>)ctx.StoreConfiguration
						where w.CODNEG == record.StoreId.ToString()
						select w into s
						select s.SES_URL).FirstOrDefault();
			}
			finally
			{
				((IDisposable)ctx)?.Dispose();
			}
		}

		public ElectronicShelfLabelConfig(ILogger<Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Configurations.ElectronicShelfLabelConfig> logger, IConfiguration configuration, DbContextOptions<ElectronicShelfLabelContext> options)
			: base(logger, configuration)
		{
			_logger = logger;
			_configuration = configuration;
			_options = options;
		}
	}
}