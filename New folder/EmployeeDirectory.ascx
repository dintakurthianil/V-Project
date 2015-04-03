<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeDirectory.ascx.cs" Inherits="EmpDirectory.EmployeeDirectory.EmployeeDirectory" %>
<link href="../_layouts/15/VrtxIntranetStyles/CSS/jquery.dataTables.css" rel="stylesheet" />

<script src="../_layouts/15/VrtxIntranetStyles/JS/jquery.dataTables.js" ></script>
<script src="../_layouts/15/EmpDirectory/Empdirectory.js" ></script>

<script>

    function printDiv(printcontent) {

        var printContents = document.getElementById(printcontent).innerHTML;
        var originalContents = document.body.innerHTML;

        document.body.innerHTML = printContents;
        document.getElementById('tblEmp_filter').style.display="None";
        window.print();

        document.body.innerHTML = originalContents;
        location.reload();
    }

   
    function myFunction(printcontent) {
        
        var contents = document.getElementById(printcontent).innerHTML;
        var frame1 = document.createElement('iframe');
        frame1.name = "frame1";
        frame1.style.position = "absolute";
        frame1.style.top = "-1000000px";
        document.body.appendChild(frame1);
        var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
        frameDoc.document.open();
        frameDoc.document.write('<html><head><title>DIV Contents</title>');
        frameDoc.document.write('</head><body>');
        frameDoc.document.write(contents);
        frameDoc.document.write('</body></html>');
        frameDoc.document.close();
        setTimeout(function () {
            window.frames["frame1"].focus();
            window.frames["frame1"].print();
            
            document.body.removeChild(frame1);
        }, 500);
        return false;
        
        //var printContents = document.getElementById(printcontent).innerHTML;
        //var originalContents = document.body.innerHTML;

        //document.body.innerHTML = printContents;
        //document.getElementById('tblEmp_filter').style.display = "None";
       
        //window.print();
        //window.location = "../SitePages/EmpDirectory.aspx";
}

    
    function printReport() {
        var content = "";
        var disp_setting = "toolbar=no,location=no,directories=yes,menubar=no,";
        disp_setting += "scrollbars=yes,width=900, height=600, left=100, top=25";

        soErrorLog = document.getElementById("printcontent").innerHTML;
        content += "<table 'width=100%'>";
        content += "<tr><td style='color:#000000;font-family:tahoma,sans-serif;font-size:10pt;font-weight:bold'>SO Error LOG</td></tr><tr><td>" + soErrorLog + "</td></tr></table>";
        var docprint = window.open("", "", disp_setting);
        docprint.document.open();
        docprint.document.write('<html><head><title>Print</title>');
        docprint.document.write('</head> <body onLoad="self.print()">');
        docprint.document.write(content);
        docprint.document.write('</body></html>');
        docprint.document.close();
        docprint.focus();
    }

    
   

</script>

<%--<asp:Button ID="asdkljf" Text="asdjlkf" runat="server" />--%>
<%--<input type="button" value="Print" onclick="printCert()" />
<asp:Label Text=" adsfadsfh"  runat="server" ID="asdasdklf" />
<asp:Button ID="btnasdhj" runat="server" />--%>

<table style="width:100%" >
    <tr>
        <td>
            <a style="padding-left:98%" onclick="printDiv('printcontent')" ><asp:Image  ImageUrl="/_layouts/15/VrtxIntranetStyles/Images/printer-icon.png" runat="server" /></a>
            <%--<input type="button"  onclick="printDiv('printcontent')"  value="Print" onclick="printDiv('printcontent')" />--%>
        </td>
    </tr>
    <tr >
        <td id="tblEmpDetails" ></td>
    </tr>
</table>