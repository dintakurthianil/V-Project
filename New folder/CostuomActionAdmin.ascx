<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CostuomActionAdmin.ascx.cs" Inherits="SuiteBarBrandingDelegate.ControlTemplates.SuiteBarBrandingDelegate.CostuomActionAdmin" %>

<script type="text/javascript" src="/_layouts/15/VrtxIntranetStyles/JS/jquery-1.8.2.js"></script>
<script type="text/javascript" src="/_layouts/15/VrtxIntranetStyles/JS/jquery.SPServices-0.7.2.min.js"></script>


<script>
        function MYProfile() {
        var urlvalue = "../SitePages/EmpInfo.aspx";
        window.location = urlvalue;
    }
</script>
<script type="text/javascript">
    var loggedinUserGroup;
    debugger;
    $(document).ready(function () {
        Getrolesforuser();
        
    });

    function Getrolesforuser() {
        var strDescrition = "<%=administration.ClientID %>";
        $("#" + strDescrition).hide();
       
        loggedinUserGroup = "";
        $().SPServices({
            operation: "GetGroupCollectionFromUser",
            userLoginName: $().SPServices.SPGetCurrentUser(),
            async: false,
            completefunc: function (xData, Status) {
                $(xData.responseXML).find("Group").each(function () {
                    loggedinUserGroup = $(this).attr("Name");
                   
                    
                    
                    if (loggedinUserGroup == "HR") {
                        


                        $("#" + strDescrition).show();
                        
                    }
                    else
                    {
                        $("#" + strDescrition).hide();
                    }
                    if (loggedinUserGroup == "Marketing") {



                        $("#" + strDescrition).show();

                    }
                    else {
                        $("#" + strDescrition).hide();
                    }
                    //if (loggedinUserGroup == "Proprietários do Site") {
                    //    $("#ms-designer-ribbon").hide();
                    //}
                });
            }
        });
    }

</script> 




<a href="/SitePages/EmpInfo.aspx" id="myprofile" runat="server" style="cursor:pointer;"><img src="/_layouts/15/VrtxIntranetStyles/Images/my-profile.png" style=" vertical-align: middle" alt="Smiley face"></a>&nbsp;&nbsp;

<asp:LinkButton   href="/Lists/Admin%20Links/AllItems.aspx"    id="administration" runat="server" target="_blank" style="cursor:pointer; " >
<img src="/_layouts/15/VrtxIntranetStyles/Images/admin.png" style=" vertical-align: middle" alt="Smiley face" >
</asp:LinkButton>
<%--<a href="/Lists/Admin%20Links/AllItems.aspx" visible="false"  id="aadministration"  runat="server" target="_blank" style="cursor:pointer; "><img src="/_layouts/15/VrtxIntranetStyles/Images/admin.png" style=" vertical-align: middle"  alt="Smiley face" >
</a>&nbsp;--%>
