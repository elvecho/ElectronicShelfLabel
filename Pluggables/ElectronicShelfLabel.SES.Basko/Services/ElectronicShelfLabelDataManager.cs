

// Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Services.ElectronicShelfLabelDataManager
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pluggable.Integration.ElectronicShelfLabel.Enum;
using Pluggable.Integration.ElectronicShelfLabel.Interfaces;
using Pluggable.Integration.ElectronicShelfLabel.Models;
using Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Context;
using Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Models;
using Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Services;

namespace Pluggable.Integration.ElectronicShelfLabel.SES.Basko.Services
{

	public class ElectronicShelfLabelDataManager : IDataManager
	{
		private readonly ILogger<ElectronicShelfLabelDataManager> _logger;

		private readonly IConfiguration _configuration;

		private readonly DbContextOptions<ElectronicShelfLabelContext> _options;

		private readonly Expression<Func<DBElectronicShelfLabelData, bool>> all = (DBElectronicShelfLabelData data) => true;

		private readonly Expression<Func<DBElectronicShelfLabelData, bool>> pendingPackages = (DBElectronicShelfLabelData data) => data.QueueDateTime <= DateTime.Now && ((int)data.ElabState == 0 || (int)data.ElabState == 1);

		public ElectronicShelfLabelDataManager(ILogger<ElectronicShelfLabelDataManager> logger, IConfiguration configuration, DbContextOptions<ElectronicShelfLabelContext> options)
		{
			_logger = logger;
			_configuration = configuration;
			_options = options;
		}

		public async Task<bool> HasPendingPackages()
		{
			ElectronicShelfLabelContext ctx = new ElectronicShelfLabelContext(_options, _configuration);
			try
			{
				return await EntityFrameworkQueryableExtensions.CountAsync<DBElectronicShelfLabelData>(((IQueryable<DBElectronicShelfLabelData>)ctx.DBElectronicShelfLabelData).Where(pendingPackages), default(CancellationToken)) > 0;
			}
			finally
			{
				((IDisposable)ctx)?.Dispose();
			}
		}

		public async Task<List<ElectronicShelfLabelData>> AllPackages()
		{
			ElectronicShelfLabelContext ctx = new ElectronicShelfLabelContext(_options, _configuration);
			try
			{
				return await EntityFrameworkQueryableExtensions.ToListAsync<ElectronicShelfLabelData>((IQueryable<ElectronicShelfLabelData>)((IQueryable<DBElectronicShelfLabelData>)ctx.DBElectronicShelfLabelData).Where(all), default(CancellationToken));
			}
			finally
			{
				((IDisposable)ctx)?.Dispose();
			}
		}

		public async Task<List<ElectronicShelfLabelData>> AllPendingPackages()
		{
			ElectronicShelfLabelContext ctx = new ElectronicShelfLabelContext(_options, _configuration);
			try
			{
				return await EntityFrameworkQueryableExtensions.ToListAsync<ElectronicShelfLabelData>((IQueryable<ElectronicShelfLabelData>)((IQueryable<DBElectronicShelfLabelData>)ctx.DBElectronicShelfLabelData).Where(pendingPackages), default(CancellationToken));
			}
			finally
			{
				((IDisposable)ctx)?.Dispose();
			}
		}

		public async IAsyncEnumerable<List<ElectronicShelfLabelData>> NextPendingPackage()
		{
			ElectronicShelfLabelContext ctx = new ElectronicShelfLabelContext(_options, _configuration);
			try
			{
				List<DBElectronicShelfLabelData> packages = await EntityFrameworkQueryableExtensions.ToListAsync<DBElectronicShelfLabelData>(((IQueryable<DBElectronicShelfLabelData>)ctx.DBElectronicShelfLabelData).Where((DBElectronicShelfLabelData data) => data.QueueDateTime <= DateTime.Now && ((int)data.ElabState == 0 || (int)data.ElabState == 1)), default(CancellationToken));
				IEnumerable<short> stores = packages.Select((DBElectronicShelfLabelData s) => s.StoreId).Distinct();
				foreach (short store in stores)
				{
					yield return ((IEnumerable<ElectronicShelfLabelData>)packages.Where((DBElectronicShelfLabelData w) => w.StoreId == store)).ToList();
				}
			}
			finally
			{
				((IDisposable)ctx)?.Dispose();
			}
		}

		public async Task<bool> SetPackage(List<ElectronicShelfLabelData> package, DataState state)
		{
			string funcName = "SetPackage";
			bool rc = false;
			try
			{
				ElectronicShelfLabelContext ctx = new ElectronicShelfLabelContext(_options, _configuration);
				try
				{
					foreach (ElectronicShelfLabelData item in package)
					{
						DBElectronicShelfLabelData record = ctx.DBElectronicShelfLabelData.Find(new object[1] { (item as DBElectronicShelfLabelData).QueueId });
						record.ElabState = state;
						ctx.DBElectronicShelfLabelData.Update(record);
					}
					rc = await ((DbContext)ctx).SaveChangesAsync(default(CancellationToken)) > 0;
				}
				finally
				{
					((IDisposable)ctx)?.Dispose();
				}
				return rc;
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				_logger.LogError(ex, funcName + " has failed");
				return rc;
			}
		}
	}
}

