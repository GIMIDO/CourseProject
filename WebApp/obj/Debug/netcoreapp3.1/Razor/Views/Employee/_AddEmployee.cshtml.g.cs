#pragma checksum "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\Employee\_AddEmployee.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a7d292e3388333fb8f49c5fad1c3d51fe6527924"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Employee__AddEmployee), @"mvc.1.0.view", @"/Views/Employee/_AddEmployee.cshtml")]
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
#line 1 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\_ViewImports.cshtml"
using WebApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\_ViewImports.cshtml"
using WebApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a7d292e3388333fb8f49c5fad1c3d51fe6527924", @"/Views/Employee/_AddEmployee.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_Employee__AddEmployee : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApp.Models.EmployeeIndexViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<h3>\r\n    Добавление записи\r\n</h3>\r\n<hr />\r\n");
#nullable restore
#line 6 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\Employee\_AddEmployee.cshtml"
 using (Html.BeginForm("AddEmployee", "Employee", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        ");
#nullable restore
#line 9 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\Employee\_AddEmployee.cshtml"
   Write(Html.LabelFor(m => m.FIO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
#nullable restore
#line 11 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\Employee\_AddEmployee.cshtml"
       Write(Html.TextBoxFor(m => m.FIO));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div>\r\n        ");
#nullable restore
#line 15 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\Employee\_AddEmployee.cshtml"
   Write(Html.LabelFor(m => m.Position));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
#nullable restore
#line 17 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\Employee\_AddEmployee.cshtml"
       Write(Html.TextBoxFor(m => m.Position));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div>\r\n        ");
#nullable restore
#line 21 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\Employee\_AddEmployee.cshtml"
   Write(Html.LabelFor(m => m.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <div class=\"col-md-10\">\r\n            ");
#nullable restore
#line 23 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\Employee\_AddEmployee.cshtml"
       Write(Html.TextBoxFor(m => m.Number));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n    </div>\r\n    <div>\r\n        <div>\r\n            <input type=\"submit\" class=\"btn btn-default\" value=\"Добавить\" />\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 31 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\Employee\_AddEmployee.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.Models.EmployeeIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
