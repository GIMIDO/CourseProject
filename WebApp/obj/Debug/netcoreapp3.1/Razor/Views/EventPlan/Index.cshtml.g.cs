#pragma checksum "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "33e5a694aca886df8181065e78d647da6faf32dc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_EventPlan_Index), @"mvc.1.0.view", @"/Views/EventPlan/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"33e5a694aca886df8181065e78d647da6faf32dc", @"/Views/EventPlan/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fc48f17eb9bac3476d8060730298bf398eb2fa5e", @"/Views/_ViewImports.cshtml")]
    public class Views_EventPlan_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebApp.Models.EventPlanIndexViewModel>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("border-color:black;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
  
    ViewBag.Title = "Таблица запланированных мероприятий";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<script>
    function changeAddVisibility() {
        document.getElementById('DeleteEventPlan').style.display = ""none"";
        document.getElementById('UpdateEventPlan').style.display = ""none"";
        document.getElementById('AddEventPlan').style.display = ""block"";
    }
</script>
<script>
    function changeDeleteVisibility() {
        document.getElementById('DeleteEventPlan').style.display = ""block"";
        document.getElementById('UpdateEventPlan').style.display = ""none"";
        document.getElementById('AddEventPlan').style.display = ""none"";
    }
</script>
<script>
    function changeUpdateVisibility() {
        document.getElementById('DeleteEventPlan').style.display = ""none"";
        document.getElementById('UpdateEventPlan').style.display = ""block"";
        document.getElementById('AddEventPlan').style.display = ""none"";
    }
</script>

<H1>");
#nullable restore
#line 27 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
Write(ViewBag.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral(":</H1>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33e5a694aca886df8181065e78d647da6faf32dc6158", async() => {
                WriteLiteral("\r\n    <div>\r\n        <label class=\"control-label\">Название события:&nbsp;</label>\r\n        <select name=\"eventName\" class=\"form-control\">\r\n");
#nullable restore
#line 32 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
             foreach (var elem in Model.FilterEventsNames)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33e5a694aca886df8181065e78d647da6faf32dc6848", async() => {
#nullable restore
#line 34 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
                   Write(elem);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 35 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </select>\r\n    </div>\r\n    <div>\r\n        <label class=\"control-label\">ФИО работника:&nbsp;</label>\r\n        <select name=\"emplFIO\" class=\"form-control\">\r\n");
#nullable restore
#line 41 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
             foreach (var elem in Model.FilterEmplFIOs)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33e5a694aca886df8181065e78d647da6faf32dc8673", async() => {
#nullable restore
#line 43 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
                   Write(elem);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 44 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("        </select>\r\n    </div>\r\n    <br />\r\n    <div>\r\n        <input type=\"submit\" style=\"border-color:black;\" value=\"Фильтр\" class=\"btn btn-default\" />\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<br />
<table border=""1"">
    <thead>
        <tr>
            <td>
                Id
            </td>
            <td>
                Название организации
            </td>
            <td>
                Название события
            </td>
            <td>
                Начало события
            </td>
            <td>
                Конец события
            </td>
            <td>
                Планируемый объем
            </td>
            <td>
                Планируемая стоимость
            </td>
            <td>
                Экономический эффект
            </td>
            <td>
                ФИО работника
            </td>
        </tr>
    </thead>
");
#nullable restore
#line 85 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
     foreach (var elem in Model.EventPlanViewModels)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 89 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
           Write(elem.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 92 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
           Write(elem.OrganizationName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 95 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
           Write(elem.EventName);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 98 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
           Write(elem.StartDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 101 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
           Write(elem.EndDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 104 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
           Write(elem.PlanVolume);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 107 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
           Write(elem.PlanCost);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 110 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
           Write(elem.EconomicEffect);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 113 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
           Write(elem.EmployeeFIO);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 116 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n<br />\r\n");
#nullable restore
#line 119 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
 if (Model.PageViewModel.HasPreviousPage)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33e5a694aca886df8181065e78d647da6faf32dc15419", async() => {
                WriteLiteral("\r\n        <i class=\"glyphicon glyphicon-chevron-left\"></i>\r\n        Назад\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 122 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
            WriteLiteral(Model.PageViewModel.PageNumber - 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 127 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 128 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
 if (Model.PageViewModel.HasNextPage)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "33e5a694aca886df8181065e78d647da6faf32dc18217", async() => {
                WriteLiteral("\r\n        Вперед\r\n        <i class=\"glyphicon glyphicon-chevron-right\"></i>\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-page", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 131 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
            WriteLiteral(Model.PageViewModel.PageNumber + 1);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-page", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["page"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 136 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n");
#nullable restore
#line 138 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
 if (User.IsInRole("Admin") || User.IsInRole("Employee"))
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div>
        <input type=""submit"" style=""border-color:black;"" value=""Добавить запись"" onclick=""changeAddVisibility()"" />
        <input type=""submit"" style=""border-color:black;"" value=""Удалить запись"" onclick=""changeDeleteVisibility()"" />
        <input type=""submit"" style=""border-color:black;"" value=""Изменить запись"" onclick=""changeUpdateVisibility()"" />
    </div>
    <hr />
");
#nullable restore
#line 146 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
Write(ViewData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div>\r\n        <div id=\"AddEventPlan\" style=\"display:none;\">\r\n");
#nullable restore
#line 149 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
              await Html.RenderPartialAsync("_AddEventPlan");

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div id=\"DeleteEventPlan\" style=\"display:none;\">\r\n");
#nullable restore
#line 152 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
              await Html.RenderPartialAsync("_DeleteEventPlan");

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n        <div id=\"UpdateEventPlan\" style=\"display:none;\">\r\n");
#nullable restore
#line 155 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
              await Html.RenderPartialAsync("_UpdateEventPlan");

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n");
#nullable restore
#line 158 "C:\Users\GIMIDO\Downloads\WebApp\WebApp\WebApp\Views\EventPlan\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebApp.Models.EventPlanIndexViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591