﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VrtxIntranetPortal.TalentMgmtItmes {
    using System.Web.UI.WebControls.Expressions;
    using System.Web.UI.HtmlControls;
    using System.Collections;
    using System.Text;
    using System.Web.UI;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using Microsoft.SharePoint.WebPartPages;
    using System.Web.SessionState;
    using System.Configuration;
    using Microsoft.SharePoint;
    using System.Web;
    using System.Web.DynamicData;
    using System.Web.Caching;
    using System.Web.Profile;
    using System.ComponentModel.DataAnnotations;
    using System.Web.UI.WebControls;
    using System.Web.Security;
    using System;
    using Microsoft.SharePoint.Utilities;
    using System.Text.RegularExpressions;
    using System.Collections.Specialized;
    using System.Web.UI.WebControls.WebParts;
    using Microsoft.SharePoint.WebControls;
    using System.CodeDom.Compiler;
    
    
    public partial class TalentMgmtItmes {
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.HtmlControls.HtmlGenericControl usahtmlable;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.HtmlControls.HtmlGenericControl indiahtml;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected global::System.Web.UI.WebControls.HiddenField hdnViewStateValue;
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebPartCodeGenerator", "12.0.0.0")]
        public static implicit operator global::System.Web.UI.TemplateControl(TalentMgmtItmes target) 
        {
            return target == null ? null : target.TemplateControl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::Microsoft.SharePoint.WebControls.CssRegistration @__BuildControl__control2() {
            global::Microsoft.SharePoint.WebControls.CssRegistration @__ctrl;
            @__ctrl = new global::Microsoft.SharePoint.WebControls.CssRegistration();
            @__ctrl.Name = "/_layouts/15/VrtxIntranetStyles/CSS/intranet.css";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.HtmlControls.HtmlGenericControl @__BuildControlusahtmlable() {
            global::System.Web.UI.HtmlControls.HtmlGenericControl @__ctrl;
            @__ctrl = new global::System.Web.UI.HtmlControls.HtmlGenericControl("ul");
            this.usahtmlable = @__ctrl;
            @__ctrl.ID = "usahtmlable";
            ((System.Web.UI.IAttributeAccessor)(@__ctrl)).SetAttribute("style", "vertical-align: top");
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n                        "));
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBindingusahtmlable);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        public void @__DataBindingusahtmlable(object sender, System.EventArgs e) {
            System.Web.UI.HtmlControls.HtmlGenericControl dataBindingExpressionBuilderTarget;
            System.Web.UI.Control Container;
            dataBindingExpressionBuilderTarget = ((System.Web.UI.HtmlControls.HtmlGenericControl)(sender));
            Container = ((System.Web.UI.Control)(dataBindingExpressionBuilderTarget.BindingContainer));
            dataBindingExpressionBuilderTarget.InnerHtml = global::System.Convert.ToString(Eval("htmlable"), global::System.Globalization.CultureInfo.CurrentCulture);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.HtmlControls.HtmlGenericControl @__BuildControlindiahtml() {
            global::System.Web.UI.HtmlControls.HtmlGenericControl @__ctrl;
            @__ctrl = new global::System.Web.UI.HtmlControls.HtmlGenericControl("ul");
            this.indiahtml = @__ctrl;
            @__ctrl.ID = "indiahtml";
            @__ctrl.DataBinding += new System.EventHandler(this.@__DataBindingindiahtml);
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        public void @__DataBindingindiahtml(object sender, System.EventArgs e) {
            System.Web.UI.HtmlControls.HtmlGenericControl dataBindingExpressionBuilderTarget;
            System.Web.UI.Control Container;
            dataBindingExpressionBuilderTarget = ((System.Web.UI.HtmlControls.HtmlGenericControl)(sender));
            Container = ((System.Web.UI.Control)(dataBindingExpressionBuilderTarget.BindingContainer));
            dataBindingExpressionBuilderTarget.InnerHtml = global::System.Convert.ToString(Eval("htmlable"), global::System.Globalization.CultureInfo.CurrentCulture);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private global::System.Web.UI.WebControls.HiddenField @__BuildControlhdnViewStateValue() {
            global::System.Web.UI.WebControls.HiddenField @__ctrl;
            @__ctrl = new global::System.Web.UI.WebControls.HiddenField();
            this.hdnViewStateValue = @__ctrl;
            @__ctrl.ID = "hdnViewStateValue";
            return @__ctrl;
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void @__BuildControlTree(global::VrtxIntranetPortal.TalentMgmtItmes.TalentMgmtItmes @__ctrl) {
            global::Microsoft.SharePoint.WebControls.CssRegistration @__ctrl1;
            @__ctrl1 = this.@__BuildControl__control2();
            System.Web.UI.IParserAccessor @__parser = ((System.Web.UI.IParserAccessor)(@__ctrl));
            @__parser.AddParsedSubObject(@__ctrl1);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n<script type=\"text/javascript\" src=\"/_layouts/15/VrtxIntranetStyles/JS/jquery.c" +
                        "ookie.js\"></script>\r\n<script>\r\n\r\n    $(document).ready(function () {\r\n\r\n        " +
                        "var url = window.location.href;\r\n        //if (url.indexOf(\"ctype\") != -1)\r\n    " +
                        "    //    $(\".htmlable\").show();\r\n\r\n        if (url.indexOf(\"Category=\") != -1)\r" +
                        "\n            $(\".ExpandHrManual\").show();\r\n        if ((url.indexOf(\"ctype=india" +
                        "\") != -1) || (url.indexOf(\"ctype=usa\") != -1) || (url.indexOf(\"ctype=pg\") != -1)" +
                        ") {\r\n            $(\".htmlable\").show();\r\n            $(\"#ExpandHrManual\").hide()" +
                        ";\r\n            $(\".expandCertification\").hide();\r\n        }\r\n        if ((url.in" +
                        "dexOf(\"ctype=Latest\") != -1) || (url.indexOf(\"ctype=Certificate\") != -1) || (url" +
                        ".indexOf(\"ctype=user\") != -1)) {\r\n            $(\".expandCertification\").show();\r" +
                        "\n            $(\"#ExpandHrManual\").hide();\r\n            $(\".htmlable\").hide();\r\n " +
                        "       }\r\n        $(\".expandContent\").click(function () {\r\n            $(\".htmla" +
                        "ble\").toggle();\r\n            $(\"#ExpandHrManual\").hide();\r\n            $(\".expan" +
                        "dCertification\").hide();\r\n\r\n        });\r\n        $(\".expandContentCertification\"" +
                        ").click(function () {\r\n            $(\".expandCertification\").toggle();\r\n        " +
                        "    $(\"#ExpandHrManual\").hide();\r\n            $(\".htmlable\").hide();\r\n\r\n        " +
                        "});\r\n\r\n\r\n        //$(\".ExpandContentHrManual\").click(function () {\r\n        //  " +
                        "  $(\"#ExpandHrManual\").toggle();\r\n\r\n        //});\r\n        if (url.indexOf(\"ctyp" +
                        "e=india\") != -1) {\r\n            $(\'.liIndia\').addClass(\'list-active\');\r\n        " +
                        "}\r\n        if (url.indexOf(\"ctype=usa\") != -1) {\r\n            $(\'.liUsa\').addCla" +
                        "ss(\'list-active\');\r\n        }\r\n        if (url.indexOf(\"ctype=pg\") != -1) {\r\n   " +
                        "         $(\'.lipg\').addClass(\'list-active\');\r\n        }\r\n\r\n        if (url.index" +
                        "Of(\"ctype=Latest\") != -1) {\r\n            $(\'.liLatest\').addClass(\'list-active\');" +
                        "\r\n        }\r\n        if (url.indexOf(\"ctype=Certificate\") != -1) {\r\n            " +
                        "$(\'.liCertificate\').addClass(\'list-active\');\r\n        }\r\n        if (url.indexOf" +
                        "(\"ctype=user\") != -1) {\r\n            $(\'.liuser\').addClass(\'list-active\');\r\n    " +
                        "    }\r\n        //if (url.indexOf(\"id\") != -1) {\r\n        //    $(\'.ExpandHrManua" +
                        "l\').show();\r\n        //}\r\n       \r\n        $(\'.ExpandContentHrManual\').click(fun" +
                        "ction () {\r\n            $(\'#ExpandHrManual\').toggle();\r\n            $(\".expandCe" +
                        "rtification\").hide();\r\n            $(\".htmlable\").hide();\r\n            //if ($(\"" +
                        "#ExpandHrManual\").is(\":visible\")) {\r\n            //    $(\'#ExpandHrManual\').hide" +
                        "();               \r\n            //}\r\n            //else {\r\n            //    $(\'" +
                        "#ExpandHrManual\').show();\r\n            //}\r\n        });\r\n\r\n    });\r\n    function" +
                        " showhidHrManual()\r\n    {\r\n        if ($(\".ExpandHrManual\").is(\":visible\")) {\r\n " +
                        "           $(\'.ExpandHrManual\').hide();\r\n        }\r\n        else {\r\n            " +
                        "$(\'.ExpandHrManual\').show();\r\n        }\r\n\r\n       \r\n        \r\n    }\r\n\r\n\r\n\r\n    f" +
                        "unction Romvecookie() {\r\n        $.removeCookie(\"example\");\r\n    }\r\n</script>\r\n\r" +
                        "\n<div class=\"inner-right\">\r\n    <div class=\"right-menu-ctr\">\r\n        <div class" +
                        "=\"right-menu-header\">IN THIS PAGE</div>\r\n        <ul>\r\n            <li><a href=\"" +
                        "../SitePages/EmpDirectory.aspx\">Employee Directories</a>\r\n\r\n            </li>\r\n " +
                        "           <li class=\"expandContent\"><a  href=\"javascript:void(0)\">List of Holid" +
                        "ays</a>\r\n                <ul class=\"htmlable\" id=\"Expand\" style=\"display: none\">" +
                        "\r\n                    <li><a class=\"liIndia\" href=\"../SitePages/CurrentHolidays." +
                        "aspx?ctype=india\">India</a></li>\r\n                    <li><a class=\"liUsa\" href=" +
                        "\"../SitePages/CurrentHolidays.aspx?ctype=usa\">USA</a></li>\r\n                    " +
                        "<li><a class=\"lipg\" href=\"../SitePages/CurrentHolidays.aspx?ctype=pg\">P&G</a></l" +
                        "i>\r\n                </ul>\r\n            </li>\r\n            <li><a href=\"http://ca" +
                        "reers.vertexcs.com/jobs/\" target=\"_blank\" dir=\"rtl\">Current Openings</a></li>\r\n " +
                        "           <li class=\"expandContentCertification\"><a href=\"javascript:void(0)\">E" +
                        "mployee Certification</a>\r\n                <ul id=\"expandCertification\" class=\"e" +
                        "xpandCertification\" style=\"display: none\">\r\n                    <li><a class=\"li" +
                        "Latest\" href=\"../SitePages/EmployeeAchievment.aspx?ctype=Latest\">Latest</a></li>" +
                        "\r\n                    <li><a class=\"liCertificate\" href=\"../SitePages/EmployeeAc" +
                        "hievment.aspx?ctype=Certificate\">By Certificate</a></li>\r\n                    <l" +
                        "i><a class=\"liuser\" href=\"../SitePages/EmployeeAchievment.aspx?ctype=user\">By Us" +
                        "er</a></li>\r\n                </ul>\r\n\r\n            </li>\r\n            <li><a href" +
                        "=\"../SitePages/EIS.aspx\">Employee Information System</a></li>\r\n            \r\n   " +
                        "               <li class=\"ExpandContentHrManual\"><a href=\"javascript:void(0)\" >H" +
                        "R Manual</a>\r\n                <ul id=\"ExpandHrManual\" class=\"ExpandHrManual\" sty" +
                        "le=\"display: none\">\r\n                    <li class=\"\"><a onclick=\"Romvecookie()\"" +
                        " href=\"../SitePages/HRPolicy.aspx?Category=Overview&&Country=USA\">Employee Manua" +
                        "l - USA</a>\r\n                        "));
            global::System.Web.UI.HtmlControls.HtmlGenericControl @__ctrl2;
            @__ctrl2 = this.@__BuildControlusahtmlable();
            @__parser.AddParsedSubObject(@__ctrl2);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n                    </li>\r\n\r\n\r\n\r\n\r\n                    <li><a onclick=\"Romvecoo" +
                        "kie()\" href=\"../SitePages/HRPolicy.aspx?Category=Overview&&Country=India\">Employ" +
                        "ee Manual - India</a>\r\n                        "));
            global::System.Web.UI.HtmlControls.HtmlGenericControl @__ctrl3;
            @__ctrl3 = this.@__BuildControlindiahtml();
            @__parser.AddParsedSubObject(@__ctrl3);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl(@"


                    </li>
                </ul>



            </li>
            <li><a href=""../SitePages/HRNewsletter.aspx"">HR Newsletter</a></li>
            <li><a href=""../SitePages/TrainingDevelopment.aspx"">Training & Development</a></li>
            <li><a href=""../SitePages/OrganizationChart.aspx"">Organization Chart</a></li>
            <li><a href=""../SitePages/downloads.aspx"">Downloads</a></li>
            <li><a href=""../SitePages/EmpOrentation.aspx"">Employee Orientation</a></li>
        </ul>
        <p>
            <a href=""../SitePages/Archives.aspx?ctype=TalentMgmnt"">
                <img src=""/_layouts/15/VrtxIntranetStyles/Images/archieves.jpg"" width=""244"" height=""38"" /></a>
        </p>

        <p>
            <a href=""/Lists/AskAnExpert/NewForm.aspx?Source=http%3A%2F%2Finhy2012v4%3A5555%2FLists%2FAskAnExpert%2FAllItems%2Easpx%3FInitialTabId%3DRibbon%252EList%26VisibilityContext%3DWSSTabPersistence%23InplviewHashd7fb7cd0-e0d5-4677-99b7-6fc7af3787dd%3D&RootFolder=%2FLists%2FAskAnExpert"">
                <img src=""/_layouts/15/VrtxIntranetStyles/Images/ask-an-expert.jpg"" width=""240"" height=""127"" /></a>
        </p>


    </div>
   
    "));
            global::System.Web.UI.WebControls.HiddenField @__ctrl4;
            @__ctrl4 = this.@__BuildControlhdnViewStateValue();
            @__parser.AddParsedSubObject(@__ctrl4);
            @__parser.AddParsedSubObject(new System.Web.UI.LiteralControl("\r\n    \r\n</div>\r\n"));
        }
        
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        private void InitializeControl() {
            this.@__BuildControlTree(this);
            this.Load += new global::System.EventHandler(this.Page_Load);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected virtual object Eval(string expression) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression);
        }
        
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Never)]
        [GeneratedCodeAttribute("Microsoft.VisualStudio.SharePoint.ProjectExtensions.CodeGenerators.SharePointWebP" +
            "artCodeGenerator", "12.0.0.0")]
        protected virtual string Eval(string expression, string format) {
            return global::System.Web.UI.DataBinder.Eval(this.Page.GetDataItem(), expression, format);
        }
    }
}
