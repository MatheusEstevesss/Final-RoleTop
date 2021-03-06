#pragma checksum "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\Administrador\Dashboard.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d25de7c6a974b7605db158af49ad8b6a4b134c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Administrador_Dashboard), @"mvc.1.0.view", @"/Views/Administrador/Dashboard.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Administrador/Dashboard.cshtml", typeof(AspNetCore.Views_Administrador_Dashboard))]
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
#line 1 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\_ViewImports.cshtml"
using RoleTopMvc;

#line default
#line hidden
#line 2 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\_ViewImports.cshtml"
using RoleTopMvc.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d25de7c6a974b7605db158af49ad8b6a4b134c1", @"/Views/Administrador/Dashboard.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"36a1b6a35e855e3bf7e86af114d09287816f6194", @"/Views/_ViewImports.cshtml")]
    public class Views_Administrador_Dashboard : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<RoleTopMvc.ViewModels.DashboardViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(49, 284, true);
            WriteLiteral(@"    <main>
        
        <h2>Dashboard</h2>
        <section id=""status-pedidos"">
            <h3>Status dos pedidos</h3>
            <div id=""painel"">
                <div class=""box-status-pedidos aprovados"">
                    <h4>Aprovados</h4>
                    <p>");
            EndContext();
            BeginContext(334, 22, false);
#line 10 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\Administrador\Dashboard.cshtml"
                  Write(Model.EventosAprovados);

#line default
#line hidden
            EndContext();
            BeginContext(356, 153, true);
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"box-status-pedidos pendentes\">\r\n                    <h4>Pendentes</h4>\r\n                    <p>");
            EndContext();
            BeginContext(510, 22, false);
#line 14 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\Administrador\Dashboard.cshtml"
                  Write(Model.EventosPendentes);

#line default
#line hidden
            EndContext();
            BeginContext(532, 155, true);
            WriteLiteral("</p>\r\n                </div>\r\n                <div class=\"box-status-pedidos reprovados\">\r\n                    <h4>Reprovados</h4>\r\n                    <p>");
            EndContext();
            BeginContext(688, 23, false);
#line 18 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\Administrador\Dashboard.cshtml"
                  Write(Model.EventosReprovados);

#line default
#line hidden
            EndContext();
            BeginContext(711, 701, true);
            WriteLiteral(@"</p>
                </div>
            </div>
        </section>

        <section id=""lista-pedidos"">
            <h3>Lista de pedidos</h3>
            <table>
                <thead>
                    <tr>
                        <th rowspan=""2"">Nome</th>
                        <th rowspan=""2"">Tipo Evento</th>
                        <th rowspan=""2"">Evento</th>
                        <th rowspan=""2"">Email</th>
                        <th colspan=""2"" rowspan=""2"">Aprovar</th>
                    </tr>
                </thead>
                <tfoot>
                    <tr>
                        <td colspan=""6"">
                            <p>Eventos atualizados em ");
            EndContext();
            BeginContext(1413, 12, false);
#line 38 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\Administrador\Dashboard.cshtml"
                                                 Write(DateTime.Now);

#line default
#line hidden
            EndContext();
            BeginContext(1425, 115, true);
            WriteLiteral("</p>\r\n                        </td>\r\n                    </tr>\r\n                </tfoot>\r\n                <tbody>\r\n");
            EndContext();
#line 43 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\Administrador\Dashboard.cshtml"
                     foreach(var evento in Model.Eventos )
                    {

#line default
#line hidden
            BeginContext(1623, 62, true);
            WriteLiteral("                        <tr>\r\n                            <td>");
            EndContext();
            BeginContext(1686, 19, false);
#line 46 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\Administrador\Dashboard.cshtml"
                           Write(evento.Cliente.Nome);

#line default
#line hidden
            EndContext();
            BeginContext(1705, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1745, 24, false);
#line 47 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\Administrador\Dashboard.cshtml"
                           Write(evento.Cliente.Documento);

#line default
#line hidden
            EndContext();
            BeginContext(1769, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1809, 23, false);
#line 48 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\Administrador\Dashboard.cshtml"
                           Write(evento.Cliente.Telefone);

#line default
#line hidden
            EndContext();
            BeginContext(1832, 39, true);
            WriteLiteral("</td>\r\n                            <td>");
            EndContext();
            BeginContext(1872, 20, false);
#line 49 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\Administrador\Dashboard.cshtml"
                           Write(evento.Cliente.Email);

#line default
#line hidden
            EndContext();
            BeginContext(1892, 41, true);
            WriteLiteral("</td>\r\n                            <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 1933, "\'", 1995, 1);
#line 50 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\Administrador\Dashboard.cshtml"
WriteAttributeValue("", 1940, Url.Action("Aprovar", "Evento", new {id = @evento.Id}), 1940, 55, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1996, 74, true);
            WriteLiteral("><i class=\"fas fa-check\"></i></a></td>\r\n                            <td><a");
            EndContext();
            BeginWriteAttribute("href", " href=\'", 2070, "\'", 2133, 1);
#line 51 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\Administrador\Dashboard.cshtml"
WriteAttributeValue("", 2077, Url.Action("Reprovar", "Evento", new {id = @evento.Id}), 2077, 56, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2134, 71, true);
            WriteLiteral("><i class=\"fas fa-times\"></i></a></td>\r\n                        </tr>\r\n");
            EndContext();
#line 53 "C:\Users\mathe\OneDrive\Documentos\Sprint4\RoleTopMvc\Views\Administrador\Dashboard.cshtml"
                    }

#line default
#line hidden
            BeginContext(2228, 81, true);
            WriteLiteral("                </tbody>\r\n            </table>\r\n        </section>\r\n\r\n    </main>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<RoleTopMvc.ViewModels.DashboardViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
