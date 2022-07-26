// Pluggable.Integration.ElectronicShelfLabel.SES.Services.ElectronicShelfLabelCommunicator
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Pluggable.Integration.ElectronicShelfLabel.Configurations;
using Pluggable.Integration.ElectronicShelfLabel.Enum;
using Pluggable.Integration.ElectronicShelfLabel.Interfaces;
using Pluggable.Integration.ElectronicShelfLabel.Models;
using Pluggable.Integration.ElectronicShelfLabel.SES.Configurations;
using Pluggable.Integration.ElectronicShelfLabel.SES.Models;
using Pluggable.Integration.ElectronicShelfLabel.SES.Services;

namespace Pluggable.Integration.ElectronicShelfLabel.SES.Services
{
	public class ElectronicShelfLabelCommunicator : ICommunicator
	{
		public class InMemoryFile
		{
			public string FileName { get; set; }

			public byte[] Content { get; set; }
		}

		private readonly ILogger<ElectronicShelfLabelCommunicator> _logger;

		private readonly IConfiguration _configuration;

		private readonly HttpClient _httpClient;

		private readonly IElectronicShelfLabelConfig _electronicShelfLabelConfig;

		public ElectronicShelfLabelCommunicator(ILogger<ElectronicShelfLabelCommunicator> logger, IConfiguration configuration, IEnumerable<IElectronicShelfLabelConfig> electronicShelfLabelConfig = null)
		{
			_logger = logger;
			_configuration = configuration;
			_electronicShelfLabelConfig = electronicShelfLabelConfig.Where((IElectronicShelfLabelConfig c) => c.GetType().FullName == Pluggable.Integration.ElectronicShelfLabel.Configurations.ElectronicShelfLabelConfig.Key).FirstOrDefault();
			if (_electronicShelfLabelConfig == null)
			{
				throw new Exception("ElectronicShelfLabelHostedService creation failed because the configuration is not valid.");
			}
			if (_electronicShelfLabelConfig.GetType().FullName != _electronicShelfLabelConfig.Configuration)
			{
				_logger.LogInformation("ElectronicShelfLabelHostedService replace base configuration with " + _electronicShelfLabelConfig.Configuration);
				_electronicShelfLabelConfig = electronicShelfLabelConfig.Where((IElectronicShelfLabelConfig c) => c.GetType().FullName == _electronicShelfLabelConfig.Configuration).FirstOrDefault();
			}
			_httpClient = new HttpClient();
			_httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", (_electronicShelfLabelConfig as Pluggable.Integration.ElectronicShelfLabel.SES.Configurations.ElectronicShelfLabelConfig).OcpApimSubscriptionKey);
		}

		public async Task<DataState> Send(List<ElectronicShelfLabelData> data)
		{
			string funcName = "Send";
			DataState rc = DataState.ToResend;
			string csv = string.Empty;
			string responseContent = string.Empty;
			string postCSVUri = string.Empty;
			_ = string.Empty;
			try
			{
				_logger.LogDebug($"{funcName}: There are {data.Count} records to send");
				postCSVUri = (_electronicShelfLabelConfig as Pluggable.Integration.ElectronicShelfLabel.SES.Configurations.ElectronicShelfLabelConfig).GetDomainPostPackageUri(data);
				_logger.LogDebug(funcName + ": DomainPostPackageUri is " + postCSVUri);
				string getCSVInfoUri = (_electronicShelfLabelConfig as Pluggable.Integration.ElectronicShelfLabel.SES.Configurations.ElectronicShelfLabelConfig).GetDomainGetPackageInfoUri(data);
				_logger.LogDebug(funcName + ": GetDomainGetPackageInfoUri is " + getCSVInfoUri);
				csv = CreateCSV(data, addHeader: true);
				byte[] content = Encoding.UTF8.GetBytes(csv.ToString());
				if ((_electronicShelfLabelConfig as Pluggable.Integration.ElectronicShelfLabel.SES.Configurations.ElectronicShelfLabelConfig).CSVCompressionRequired)
				{
					content = GetZipArchive(new List<InMemoryFile>
				{
					new InMemoryFile
					{
						Content = content,
						FileName = "basko_item.csv"
					}
				});
				}
				using (MemoryStream memoryStream = new MemoryStream(content))
				{
					using StreamContent streamContent = new StreamContent(memoryStream);
					_logger.LogDebug(funcName + ": Send items to " + postCSVUri);
					using HttpResponseMessage httpResponseMessage2 = await _httpClient.PostAsync(postCSVUri, streamContent);
					_logger.LogDebug(string.Format("{0}: The response content status code is {1} and it is {2}valid", funcName, httpResponseMessage2.StatusCode, httpResponseMessage2.IsSuccessStatusCode ? "" : "in"));
					httpResponseMessage2.EnsureSuccessStatusCode();
					responseContent = await httpResponseMessage2.Content.ReadAsStringAsync();
					_logger.LogDebug(funcName + ": The response content is" + Environment.NewLine + responseContent);
				}
				PostCSVResponse postCSVResponse = JsonSerializer.Deserialize<PostCSVResponse>(responseContent);
				GetCSVInfoResponse getCSVInfoResponse = null;
				_logger.LogDebug($"{funcName}: Check the result using {getCSVInfoUri + postCSVResponse.correlationId}. Number of retries: {(_electronicShelfLabelConfig as Pluggable.Integration.ElectronicShelfLabel.SES.Configurations.ElectronicShelfLabelConfig).GetPackageInfoNumberOfRetries}, Sleeping time (in mills): {(_electronicShelfLabelConfig as Pluggable.Integration.ElectronicShelfLabel.SES.Configurations.ElectronicShelfLabelConfig).GetPackageInfoNumberOfRetriesMillisecondsSleepingTime}");
				for (int i = 0; i < (_electronicShelfLabelConfig as Pluggable.Integration.ElectronicShelfLabel.SES.Configurations.ElectronicShelfLabelConfig).GetPackageInfoNumberOfRetries; i++)
				{
					await Task.Delay((_electronicShelfLabelConfig as Pluggable.Integration.ElectronicShelfLabel.SES.Configurations.ElectronicShelfLabelConfig).GetPackageInfoNumberOfRetriesMillisecondsSleepingTime);
					using (HttpResponseMessage httpResponseMessage = await _httpClient.GetAsync(getCSVInfoUri + postCSVResponse.correlationId))
					{
						_logger.LogDebug(string.Format("{0}: The response content status code is {1} and it is {2}valid", funcName, httpResponseMessage.StatusCode, httpResponseMessage.IsSuccessStatusCode ? "" : "in"));
						httpResponseMessage.EnsureSuccessStatusCode();
						responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
						_logger.LogDebug(funcName + ": The response content is" + Environment.NewLine + responseContent);
					}
					getCSVInfoResponse = JsonSerializer.Deserialize<GetCSVInfoResponse>(responseContent);
					if (getCSVInfoResponse == null || getCSVInfoResponse?.records == null)
					{
						_logger.LogWarning(funcName + ": The result is not still available at " + getCSVInfoUri + postCSVResponse.correlationId + "!");
					}
				}
				if (getCSVInfoResponse == null || getCSVInfoResponse?.records == null || getCSVInfoResponse.records.invalid > 0)
				{
					throw new Exception($"{funcName}: Not all records have been successfully processed (Records: {data.Count}, Sent: {getCSVInfoResponse.records.count}, Valid: {getCSVInfoResponse.records.valid}, Invalid: {getCSVInfoResponse.records.invalid}, Ignored: {getCSVInfoResponse.records.ignored})");
				}
				_logger.LogInformation(funcName + ": Data have been sent." + Environment.NewLine + responseContent);
				rc = DataState.Sent;
				return rc;
			}
			catch (Exception ex2)
			{
				Exception ex = ex2;
				_logger.LogError(ex, $"{funcName} exception occurs sending records to URI {postCSVUri}{Environment.NewLine}Records{Environment.NewLine}{data}{Environment.NewLine}CSV Length{Environment.NewLine}{csv.Length}{Environment.NewLine}Response{Environment.NewLine}{responseContent}");
				return rc;
			}
		}

		private string CreateCSV(List<ElectronicShelfLabelData> data, bool addHeader)
		{
			string text = "CreateCSV";
			StringBuilder stringBuilder = new StringBuilder();
			try
			{
				_logger.LogDebug(text + " called");
				if (addHeader)
				{
					PropertyInfo[] properties = data.First().GetType().GetProperties();
					foreach (PropertyInfo propertyInfo in properties)
					{
						ColumnAttribute customAttribute = propertyInfo.GetCustomAttribute<ColumnAttribute>(inherit: false);
						stringBuilder.Append(((stringBuilder.Length == 0) ? string.Empty : ";") + ((customAttribute == null || string.IsNullOrEmpty(customAttribute.Name)) ? propertyInfo.Name : customAttribute.Name));
					}
					stringBuilder.Append(Environment.NewLine);
				}
				foreach (ElectronicShelfLabelData datum in data)
				{
					bool flag = true;
					PropertyInfo[] properties2 = datum.GetType().GetProperties();
					foreach (PropertyInfo propertyInfo2 in properties2)
					{
						stringBuilder.Append((flag ? string.Empty : ";") + propertyInfo2.GetValue(datum));
						flag = false;
					}
					stringBuilder.Append(Environment.NewLine);
				}
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, text + ": " + ex.Message);
				stringBuilder.Clear();
			}
			finally
			{
				_logger.LogDebug($"{text}: returns with CSV content length{Environment.NewLine}{stringBuilder.Length}");
			}
			return stringBuilder.ToString();
		}

		public static byte[] GetZipArchive(List<InMemoryFile> files)
		{
			using MemoryStream memoryStream = new MemoryStream();
			using (ZipArchive zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, leaveOpen: true))
			{
				foreach (InMemoryFile file in files)
				{
					ZipArchiveEntry zipArchiveEntry = zipArchive.CreateEntry(file.FileName, CompressionLevel.Optimal);
					using Stream stream = zipArchiveEntry.Open();
					stream.Write(file.Content, 0, file.Content.Length);
				}
			}
			return memoryStream.ToArray();
		}
	}
}

