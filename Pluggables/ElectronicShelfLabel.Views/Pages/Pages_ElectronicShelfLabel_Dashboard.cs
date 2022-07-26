// Pluggable.Integration.ElectronicShelfLabel.Pages.Pages_ElectronicShelfLabel_Dashboard
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Internal;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.Hosting;
using Pluggable.Integration.ElectronicShelfLabel.Pages.ElectronicShelfLabel;

namespace Pluggable.Integration.ElectronicShelfLabel.Pages
{
    [RazorSourceChecksum("SHA1", "9b5546fd9f8d067eb10078a8040f2b3e4d95399f", "/Pages/ElectronicShelfLabel/Dashboard.cshtml")]
    [RazorSourceChecksum("SHA1", "113bdfe2cf137124d8ad19cabad55fbbc02482d6", "/Pages/ElectronicShelfLabel/_ViewImports.cshtml")]
    public class Pages_ElectronicShelfLabel_Dashboard : Page
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
        public IHtmlHelper<DashboardModel> Html { get; private set; }

        public ViewDataDictionary<DashboardModel> ViewData => (ViewDataDictionary<DashboardModel>)(base.PageContext?.ViewData);

        public DashboardModel Model => ViewData.Model;

        public override async Task ExecuteAsync()
        {
            ViewData["Title"] = "Dashboard";
            WriteLiteral("\r\n<h1>Dashboard</h1>\r\n\r\n<button class=\"btn btn-primary\" onclick=\"HasPendingPackages()\">HasPendingPackages</button>\r\n<button class=\"btn btn-primary\" onclick=\"NextPendingPackage()\">NextPendingPackage</button>\r\n<button class=\"btn btn-primary\" onclick=\"AllPackages()\">AllPackages</button>\r\n\r\n<div id=\"jResultContainer\">\r\n\r\n</div>\r\n");
        }
    }
}
