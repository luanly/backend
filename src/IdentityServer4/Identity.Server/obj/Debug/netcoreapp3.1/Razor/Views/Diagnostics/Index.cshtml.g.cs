#pragma checksum "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a97f9b8ff8fcb1c64cba472c267d0aca3f66b5cf"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Diagnostics_Index), @"mvc.1.0.view", @"/Views/Diagnostics/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\_ViewImports.cshtml"
using Identity.Server;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\_ViewImports.cshtml"
using Identity.Server.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a97f9b8ff8fcb1c64cba472c267d0aca3f66b5cf", @"/Views/Diagnostics/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2b841a2b422600a2b4fa70debf6a289231bea5da", @"/Views/_ViewImports.cshtml")]
    public class Views_Diagnostics_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<DiagnosticsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Authentication cookie</h1>\r\n\r\n<h3>Claims</h3>\r\n<dl>\r\n");
#nullable restore
#line 7 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml"
     foreach (var claim in Model.AuthenticateResult.Principal.Claims)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<dt>");
#nullable restore
#line 9 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml"
       Write(claim.Type);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n\t\t<dd>");
#nullable restore
#line 10 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml"
       Write(claim.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 11 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>\r\n\r\n<h3>Properties</h3>\r\n<dl>\r\n");
#nullable restore
#line 16 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml"
     foreach (var prop in Model.AuthenticateResult.Properties.Items)
	{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t<dt>");
#nullable restore
#line 18 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml"
       Write(prop.Key);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dt>\r\n\t\t<dd>");
#nullable restore
#line 19 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml"
       Write(prop.Value);

#line default
#line hidden
#nullable disable
            WriteLiteral("</dd>\r\n");
#nullable restore
#line 20 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml"
	}

#line default
#line hidden
#nullable disable
            WriteLiteral("</dl>\r\n\r\n");
#nullable restore
#line 23 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml"
 if (Model.Clients.Any())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t<h3>Clients</h3>\r\n\t<ul>\r\n");
#nullable restore
#line 27 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml"
         foreach (var client in Model.Clients)
		{

#line default
#line hidden
#nullable disable
            WriteLiteral("\t\t\t<li>");
#nullable restore
#line 29 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml"
           Write(client);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 30 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml"
		}

#line default
#line hidden
#nullable disable
            WriteLiteral("\t</ul>\r\n");
#nullable restore
#line 32 "D:\final\backend_1\backend\src\IdentityServer4\Identity.Server\Views\Diagnostics\Index.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<DiagnosticsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591