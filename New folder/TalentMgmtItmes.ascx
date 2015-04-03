<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TalentMgmtItmes.ascx.cs" Inherits="VrtxIntranetPortal.TalentMgmtItmes.TalentMgmtItmes" %>
<SharePoint:CssRegistration runat="server" Name="/_layouts/15/VrtxIntranetStyles/CSS/intranet.css" />
<script type="text/javascript" src="/_layouts/15/VrtxIntranetStyles/JS/jquery.cookie.js"></script>
<script>

    $(document).ready(function () {

        var url = window.location.href;
        //if (url.indexOf("ctype") != -1)
        //    $(".htmlable").show();

        if (url.indexOf("Category=") != -1)
            $(".ExpandHrManual").show();
        if ((url.indexOf("ctype=india") != -1) || (url.indexOf("ctype=usa") != -1) || (url.indexOf("ctype=pg") != -1)) {
            $(".htmlable").show();
            $("#ExpandHrManual").hide();
            $(".expandCertification").hide();
        }
        if ((url.indexOf("ctype=Latest") != -1) || (url.indexOf("ctype=Certificate") != -1) || (url.indexOf("ctype=user") != -1)) {
            $(".expandCertification").show();
            $("#ExpandHrManual").hide();
            $(".htmlable").hide();
        }
        $(".expandContent").click(function () {
            $(".htmlable").toggle();
            $("#ExpandHrManual").hide();
            $(".expandCertification").hide();

        });
        $(".expandContentCertification").click(function () {
            $(".expandCertification").toggle();
            $("#ExpandHrManual").hide();
            $(".htmlable").hide();

        });


        //$(".ExpandContentHrManual").click(function () {
        //    $("#ExpandHrManual").toggle();

        //});
        if (url.indexOf("ctype=india") != -1) {
            $('.liIndia').addClass('list-active');
        }
        if (url.indexOf("ctype=usa") != -1) {
            $('.liUsa').addClass('list-active');
        }
        if (url.indexOf("ctype=pg") != -1) {
            $('.lipg').addClass('list-active');
        }

        if (url.indexOf("ctype=Latest") != -1) {
            $('.liLatest').addClass('list-active');
        }
        if (url.indexOf("ctype=Certificate") != -1) {
            $('.liCertificate').addClass('list-active');
        }
        if (url.indexOf("ctype=user") != -1) {
            $('.liuser').addClass('list-active');
        }
        //if (url.indexOf("id") != -1) {
        //    $('.ExpandHrManual').show();
        //}
       
        $('.ExpandContentHrManual').click(function () {
            $('#ExpandHrManual').toggle();
            $(".expandCertification").hide();
            $(".htmlable").hide();
            //if ($("#ExpandHrManual").is(":visible")) {
            //    $('#ExpandHrManual').hide();               
            //}
            //else {
            //    $('#ExpandHrManual').show();
            //}
        });

    });
    function showhidHrManual()
    {
        if ($(".ExpandHrManual").is(":visible")) {
            $('.ExpandHrManual').hide();
        }
        else {
            $('.ExpandHrManual').show();
        }

       <%-- var hiddenHR = $("#<%=hdnViewStateValue.ClientID%>").val(); 
        if (hiddenHR == "") {
            $("#<%=hdnViewStateValue.ClientID%>").val("1");
            window.location.href = "../SitePages/HRManual.aspx";
            $('.ExpandHrManual').hide();
        }
        else {
            $('.ExpandHrManual').show();
            $("#<%=hdnViewStateValue.ClientID%>").val("");
        }--%>
        
    }



    function Romvecookie() {
        $.removeCookie("example");
    }
</script>

<div class="inner-right">
    <div class="right-menu-ctr">
        <div class="right-menu-header">IN THIS PAGE</div>
        <ul>
            <li><a href="../SitePages/EmpDirectory.aspx">Employee Directories</a>

            </li>
            <li class="expandContent"><a  href="javascript:void(0)">List of Holidays</a>
                <ul class="htmlable" id="Expand" style="display: none">
                    <li><a class="liIndia" href="../SitePages/CurrentHolidays.aspx?ctype=india">India</a></li>
                    <li><a class="liUsa" href="../SitePages/CurrentHolidays.aspx?ctype=usa">USA</a></li>
                    <li><a class="lipg" href="../SitePages/CurrentHolidays.aspx?ctype=pg">P&G</a></li>
                </ul>
            </li>
            <li><a href="http://careers.vertexcs.com/jobs/" target="_blank" dir="rtl">Current Openings</a></li>
            <li class="expandContentCertification"><a href="javascript:void(0)">Employee Certification</a>
                <ul id="expandCertification" class="expandCertification" style="display: none">
                    <li><a class="liLatest" href="../SitePages/EmployeeAchievment.aspx?ctype=Latest">Latest</a></li>
                    <li><a class="liCertificate" href="../SitePages/EmployeeAchievment.aspx?ctype=Certificate">By Certificate</a></li>
                    <li><a class="liuser" href="../SitePages/EmployeeAchievment.aspx?ctype=user">By User</a></li>
                </ul>

            </li>
            <li><a href="../SitePages/EIS.aspx">Employee Information System</a></li>
            <%--id=1 is added by 18-2-2015 for collaps operation
            <li class="ExpandContentHrManual"><a href="../SitePages/HRManual.aspx?id=1">HR Manual</a>--%>
                  <li class="ExpandContentHrManual"><a href="javascript:void(0)" >HR Manual</a>
                <ul id="ExpandHrManual" class="ExpandHrManual" style="display: none">
                    <li class=""><a onclick="Romvecookie()" href="../SitePages/HRPolicy.aspx?Category=Overview&&Country=USA">Employee Manual - USA</a>
                        <ul runat="server" id="usahtmlable" innerhtml='<%#Eval("htmlable")%>' style="vertical-align: top">
                        </ul>
                    </li>




                    <li><a onclick="Romvecookie()" href="../SitePages/HRPolicy.aspx?Category=Overview&&Country=India">Employee Manual - India</a>
                        <ul runat="server" id="indiahtml" innerhtml='<%#Eval("htmlable")%>'></ul>


                    </li>
                </ul>



            </li>
            <li><a href="../SitePages/HRNewsletter.aspx">HR Newsletter</a></li>
            <li><a href="../SitePages/TrainingDevelopment.aspx">Training & Development</a></li>
            <li><a href="../SitePages/OrganizationChart.aspx">Organization Chart</a></li>
            <li><a href="../SitePages/downloads.aspx">Downloads</a></li>
            <li><a href="../SitePages/EmpOrentation.aspx">Employee Orientation</a></li>
        </ul>
        <p>
            <a href="../SitePages/Archives.aspx?ctype=TalentMgmnt">
                <img src="/_layouts/15/VrtxIntranetStyles/Images/archieves.jpg" width="244" height="38" /></a>
        </p>

        <p>
            <a href="/Lists/AskAnExpert/NewForm.aspx?Source=http%3A%2F%2Finhy2012v4%3A5555%2FLists%2FAskAnExpert%2FAllItems%2Easpx%3FInitialTabId%3DRibbon%252EList%26VisibilityContext%3DWSSTabPersistence%23InplviewHashd7fb7cd0-e0d5-4677-99b7-6fc7af3787dd%3D&RootFolder=%2FLists%2FAskAnExpert">
                <img src="/_layouts/15/VrtxIntranetStyles/Images/ask-an-expert.jpg" width="240" height="127" /></a>
        </p>


    </div>
   <%--modi--%>
    <asp:HiddenField  runat="server" ID="hdnViewStateValue"/>
    <%--End--%>
</div>
