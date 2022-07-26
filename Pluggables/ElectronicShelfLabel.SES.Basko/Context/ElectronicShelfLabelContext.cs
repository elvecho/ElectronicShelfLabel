// Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Context.ElectronicShelfLabelContext
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Plugga.Core.Attributes;
using Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Context;
using Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Models;

namespace Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Context
{

	[PluggableServiceDbContextSqlServerOptions(ConnectionString = "ElectronicShelfLabel", ContextLifetime = ServiceLifetime.Transient, OptionsLifetime = ServiceLifetime.Transient)]
	public class ElectronicShelfLabelContext : DbContext
	{
		public virtual DbSet<DBElectronicShelfLabelData> DBElectronicShelfLabelData { get; set; }

		public virtual DbSet<StoreConfiguration> StoreConfiguration { get; set; }

		public ElectronicShelfLabelContext(DbContextOptions<ElectronicShelfLabelContext> options, IConfiguration configuration)
			: base((DbContextOptions)(object)options)
		{
			((DbContext)this).ChangeTracker.AutoDetectChangesEnabled = false;
			RelationalDatabaseFacadeExtensions.SetCommandTimeout(((DbContext)this).Database, (int?)int.MaxValue);
		}
	}
}

