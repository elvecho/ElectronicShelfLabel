// Pluggable.Integration.ElectronicShelfLabel.Pages.Pages_ElectronicShelfLabel__Layout
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.Razor.TagHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace Pluggable.Integration.ElectronicShelfLabel.Pages
{
	[RazorSourceChecksum("SHA1", "88a62211b1d67677e4277ea8222787c90cf5b189", "/Pages/ElectronicShelfLabel/_Layout.cshtml")]
	[RazorSourceChecksum("SHA1", "113bdfe2cf137124d8ad19cabad55fbbc02482d6", "/Pages/ElectronicShelfLabel/_ViewImports.cshtml")]

	public class Pages_ElectronicShelfLabel__Layout : RazorPage<object>
	{
		private static readonly TagHelperAttribute __tagHelperAttribute_0 = new TagHelperAttribute("class", new HtmlString("navbar-brand"), HtmlAttributeValueStyle.DoubleQuotes);

		private static readonly TagHelperAttribute __tagHelperAttribute_1 = new TagHelperAttribute("asp-area", "", HtmlAttributeValueStyle.DoubleQuotes);

		private static readonly TagHelperAttribute __tagHelperAttribute_2 = new TagHelperAttribute("asp-page", "/Index", HtmlAttributeValueStyle.DoubleQuotes);

		private static readonly TagHelperAttribute __tagHelperAttribute_3 = new TagHelperAttribute("class", new HtmlString("nav-link text-dark"), HtmlAttributeValueStyle.DoubleQuotes);

		private static readonly TagHelperAttribute __tagHelperAttribute_4 = new TagHelperAttribute("asp-page", "Dashboard", HtmlAttributeValueStyle.DoubleQuotes);

		private static readonly TagHelperAttribute __tagHelperAttribute_5 = new TagHelperAttribute("asp-page", "/Privacy", HtmlAttributeValueStyle.DoubleQuotes);

		private static readonly TagHelperAttribute __tagHelperAttribute_6 = new TagHelperAttribute("src", "./js/site.js", HtmlAttributeValueStyle.DoubleQuotes);

		private TagHelperExecutionContext __tagHelperExecutionContext;

		private TagHelperRunner __tagHelperRunner = new TagHelperRunner();

		private string __tagHelperStringValueBuffer;

		private TagHelperScopeManager __backed__tagHelperScopeManager = null;

		private HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;

		private BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;

		private AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;

		private ScriptTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper;

		private TagHelperScopeManager __tagHelperScopeManager
		{
			get
			{
				if (__backed__tagHelperScopeManager == null)
				{
					__backed__tagHelperScopeManager = new TagHelperScopeManager(base.StartTagHelperWritingScope, base.EndTagHelperWritingScope);
				}
				return __backed__tagHelperScopeManager;
			}
		}

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
			WriteLiteral("<!DOCTYPE html>\r\n<html lang=\"en\">\r\n");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", TagMode.StartTagAndEndTag, "88a62211b1d67677e4277ea8222787c90cf5b1895831", async delegate
			{
				WriteLiteral("\r\n    <base href=\"/ElectronicShelfLabel/\">\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>");
				Write(base.ViewData["Title"]);
				WriteLiteral(" -- Pluggable.Integration.ElectronicShelfLabel</title>\r\n    <link rel=\"stylesheet\" href=\"./lib/bootstrap/dist/css/bootstrap.min.css\" />\r\n    <link rel=\"stylesheet\" href=\"./css/site.css\" />\r\n");
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<HeadTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n");
			__tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", TagMode.StartTagAndEndTag, "88a62211b1d67677e4277ea8222787c90cf5b1897451", async delegate
			{
				WriteLiteral("\r\n    <header>\r\n        <nav class=\"navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3\">\r\n            <div class=\"container\">\r\n                ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "88a62211b1d67677e4277ea8222787c90cf5b1897906", async delegate
				{
					WriteLiteral("Pluggable.Integration.SES.ESL");
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_2.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n                <button class=\"navbar-toggler\" type=\"button\" data-toggle=\"collapse\" data-target=\".navbar-collapse\" aria-controls=\"navbarSupportedContent\"\r\n                        aria-expanded=\"false\" aria-label=\"Toggle navigation\">\r\n                    <span class=\"navbar-toggler-icon\"></span>\r\n                </button>\r\n                <div class=\"navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse\">\r\n                    <ul class=\"navbar-nav flex-grow-1\">\r\n                        <li class=\"nav-item\">\r\n                            ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "88a62211b1d67677e4277ea8222787c90cf5b18910011", async delegate
				{
					WriteLiteral("Dashboard");
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				__tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_4.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n                        </li>\r\n                    </ul>\r\n                </div>\r\n            </div>\r\n        </nav>\r\n    </header>\r\n    <div class=\"container\">\r\n        <main role=\"main\" class=\"pb-3\">\r\n            ");
				Write(RenderBody());
				WriteLiteral("\r\n        </main>\r\n    </div>\r\n\r\n    <footer class=\"border-top footer text-muted\">\r\n        <div class=\"container\">\r\n            &copy; 2020 - Pluggable.Integration.SES.ESL - ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", TagMode.StartTagAndEndTag, "88a62211b1d67677e4277ea8222787c90cf5b18912227", async delegate
				{
					WriteLiteral("Privacy");
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<AnchorTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_1.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
				__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Page = (string)__tagHelperAttribute_5.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n        </div>\r\n    </footer>\r\n\r\n    <script src=\"./lib/jquery/dist/jquery.min.js\"></script>\r\n    <script src=\"./lib/bootstrap/dist/js/bootstrap.bundle.min.js\"></script>\r\n    ");
				__tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", TagMode.StartTagAndEndTag, "88a62211b1d67677e4277ea8222787c90cf5b18913843", async delegate
				{
				});
				__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper = CreateTagHelper<ScriptTagHelper>();
				__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper);
				__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.Src = (string)__tagHelperAttribute_6.Value;
				__tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
				__Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion = true;
				__tagHelperExecutionContext.AddTagHelperAttribute("asp-append-version", __Microsoft_AspNetCore_Mvc_TagHelpers_ScriptTagHelper.AppendVersion, HtmlAttributeValueStyle.DoubleQuotes);
				await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
				if (!__tagHelperExecutionContext.Output.IsContentModified)
				{
					await __tagHelperExecutionContext.SetOutputContentAsync();
				}
				Write(__tagHelperExecutionContext.Output);
				__tagHelperExecutionContext = __tagHelperScopeManager.End();
				WriteLiteral("\r\n\r\n    ");
				Write(RenderSection("Scripts", required: false));
				WriteLiteral("\r\n");
			});
			__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<BodyTagHelper>();
			__tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
			await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
			if (!__tagHelperExecutionContext.Output.IsContentModified)
			{
				await __tagHelperExecutionContext.SetOutputContentAsync();
			}
			Write(__tagHelperExecutionContext.Output);
			__tagHelperExecutionContext = __tagHelperScopeManager.End();
			WriteLiteral("\r\n</html>\r\n");
		}
	}
}

