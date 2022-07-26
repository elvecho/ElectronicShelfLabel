// Pluggable.Integration.ElectronicShelfLabel.Pages.Pages_ElectronicShelfLabel__ViewImports
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;

namespace Pluggable.Integration.ElectronicShelfLabel.Pages
{
	[RazorSourceChecksum("SHA1", "113bdfe2cf137124d8ad19cabad55fbbc02482d6", "/Pages/ElectronicShelfLabel/_ViewImports.cshtml")]
	public class Pages_ElectronicShelfLabel__ViewImports : RazorPage<object>
	{
		[RazorInject]
		public IModelExpressionProvider ModelExpressionProvider { get; private set; }

		[RazorInject]
		public IUrlHelper Url { get; private set; }

		[RazorInject]
		public IViewComponentHelper Component { get; private set; }

		[RazorInject]
		public IJsonHelper Json { get; private set; }

		[RazorInject]
		public IHtmlHelper<dynamic> Html { get; private set; }

		public override async Task ExecuteAsync()
		{
		}
	}
}
