<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="archivesLeftNavigation.ascx.cs" Inherits="VrtxIntranetArchives.archivesLeftNavigation.archivesLeftNavigation" %>
<SharePoint:CssRegistration runat="server" Name="/_layouts/15/VrtxIntranetStyles/CSS/intranet.css" />

<script src="../_layouts/15/VrtxIntranetStyles/JS/jquery-1.8.1.js"></script>


<div class="inner-right" style="margin-top:18px;">
    <div class="right-menu-ctr">
        <div class="right-menu-header">IN THIS PAGE</div>

<%--        <ul>
            <li runat="server"  style="vertical-align: top">List of Archives
            <ul id="htmlTitle" runat="server"></ul>
                </li>
        </ul>
        --%>
            
        <div id="htmlTitle" runat="server"></div>
            
         

        

        <p>
            <a href="../SitePages/Archives.aspx">
                <img src="/_layouts/15/VrtxIntranetStyles/Images/archieves.jpg" width="244" height="38" /></a>
        </p>

        <p>
            <a href="javascript:void(0)">
                <img src="/_layouts/15/VrtxIntranetStyles/Images/ask-an-expert.jpg" width="240" height="127" /></a>
        </p>


    </div>



</div>

<script>



    
    
    
    
    
    
    $(document).ready(function () {

        //modi 24-12-2015 start 
      
        var sPageURL = window.location.search.substring(1);
        var sURLVariables = sPageURL.split('&&Title=', 2);
        var TitleValue = sURLVariables[1];
        switch (TitleValue) {
            case "Holidays": $(".Holidays").show();
                break;
            case "Message": $(".MessageBoard").show();
                break;
            case "Client": $(".ClientTestmonials").show();
                break;
            case "Corporate": $(".CorporateOverview").show();
                break;
            case "News": $(".NewsandEvents").show();
                break;
            case "Employee": $(".EmployeeCertification").show();
                break;
            case "Training": $(".TrainingandDevelopment").show();
                break;
            case "Company": $(".CompanyNewsletter").show();
                break;

         }

        //if (sPageURL.indexOf("Title=" != -1)) {
        //    $(".ExpandHrManual").show();
        //}
        
            //EnD
        $("#Holidays").click(function () {
           
            $(".Holidays").toggle();
            $(".MessageBoard").hide();
            $(".ClientTestmonials").hide();
            $(".CorporateOverview").hide();
            $(".NewsandEvents").hide();
            $(".EmployeeCertification").hide();
            $(".CompanyNewsletter").hide();
            $(".TrainingandDevelopment").hide();

        });

        $("#MessageBoard").click(function () {
            $(".Holidays").hide();            
            $(".ClientTestmonials").hide();
            $(".CorporateOverview").hide();
            $(".NewsandEvents").hide();
            $(".EmployeeCertification").hide();
            $(".CompanyNewsletter").hide();
            $(".TrainingandDevelopment").hide();
            $(".MessageBoard").toggle();

        });

        $("#ClientTestmonials").click(function () {
            $(".Holidays").hide();            
            $(".CorporateOverview").hide();
            $(".NewsandEvents").hide();
            $(".EmployeeCertification").hide();
            $(".CompanyNewsletter").hide();
            $(".TrainingandDevelopment").hide();
            $(".MessageBoard").hide();
            $(".ClientTestmonials").toggle();

        });

        $("#CorporateOverview").click(function () {
            $(".Holidays").hide();            
            $(".NewsandEvents").hide();
            $(".EmployeeCertification").hide();
            $(".CompanyNewsletter").hide();
            $(".TrainingandDevelopment").hide();
            $(".MessageBoard").hide();
            $(".ClientTestmonials").hide();
            $(".CorporateOverview").toggle();

        });


        $("#NewsandEvents").click(function () {
            $(".Holidays").hide();           
            $(".EmployeeCertification").hide();
            $(".CompanyNewsletter").hide();
            $(".TrainingandDevelopment").hide();
            $(".MessageBoard").hide();
            $(".ClientTestmonials").hide();
            $(".CorporateOverview").hide();
            $(".NewsandEvents").toggle();

        });


        $("#EmployeeCertification").click(function () {
            $(".Holidays").hide();           
            $(".CompanyNewsletter").hide();
            $(".TrainingandDevelopment").hide();
            $(".MessageBoard").hide();
            $(".ClientTestmonials").hide();
            $(".CorporateOverview").hide();
            $(".NewsandEvents").hide();
            $(".EmployeeCertification").toggle();

        });


        $("#CompanyNewsletter").click(function () {
            $(".Holidays").hide();
            $(".TrainingandDevelopment").hide();
            $(".MessageBoard").hide();
            $(".ClientTestmonials").hide();
            $(".CorporateOverview").hide();
            $(".NewsandEvents").hide();
            $(".EmployeeCertification").hide();
            $(".CompanyNewsletter").toggle();

        });

        $("#TrainingandDevelopment").click(function () {
            $(".Holidays").hide();
           
            $(".MessageBoard").hide();
            $(".ClientTestmonials").hide();
            $(".CorporateOverview").hide();
            $(".NewsandEvents").hide();
            $(".EmployeeCertification").hide();
            $(".CompanyNewsletter").hide();
            $(".TrainingandDevelopment").toggle();

        });

    });


</script>