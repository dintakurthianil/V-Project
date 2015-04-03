<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Holidays.ascx.cs" Inherits="VrtxIntranetPortal.Holidays.Holidays" %>

<script>
    function printDiv(printcontent) {
        var contents = document.getElementById(printcontent).innerHTML;
        var frame1 = document.createElement('iframe');
        frame1.name = "frame1";
        frame1.style.position = "absolute";
        frame1.style.top = "-1000000px";
        document.body.appendChild(frame1);
        var frameDoc = frame1.contentWindow ? frame1.contentWindow : frame1.contentDocument.document ? frame1.contentDocument.document : frame1.contentDocument;
        frameDoc.document.open();
        frameDoc.document.write('<html><head><title></title>');
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
        //window.print();
        //document.body.innerHTML = originalContents;
    }
</script>

<style>
    

</style>

<SharePoint:CssRegistration runat="server" Name="/_layouts/15/VrtxIntranetStyles/CSS/intranet.css" />
<a style="padding-left:98%"  onclick="printDiv('printcontent')" ><asp:Image  ImageUrl="/_layouts/15/VrtxIntranetStyles/Images/printer-icon.png" runat="server" /></a>
<%--<input type="button" id="btnPrint" value="Print" onclick="printDiv('printcontent')" />--%>
<%--<asp:Label ID="akjsdfh" runat="server" ></asp:Label>--%>
<div id="printcontent">
<asp:GridView ID="gvHolidays" runat="server" AutoGenerateColumns="false" Width ="100%" BorderStyle="0"   GridLines="None">
    <AlternatingRowStyle CssClass="grid-sub2" BorderWidth="0" />
    <RowStyle CssClass="grid-sub1" BorderWidth="0"  />
    <HeaderStyle CssClass="grid-header" />

    <Columns>
        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left"  > 
            <ItemTemplate>
               <asp:Label ID="lblSerialNo" Text='<%#Container.DataItemIndex + 1%>' Style="padding: 10px;"  runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Month" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
               <asp:Label ID="lblMonth" Text='<%#Eval("Month")%>'  runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Day" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
               <asp:Label ID="lblDay" Text='<%#Eval("Day")%>'  runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Date" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
               <asp:Label ID="lblDateAndDay" Text='<%#Eval("HolidayDate")%>' runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Holidays" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
               <asp:Label ID="lblHolidays" Text='<%#Eval("HolidayName")%>' runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

    </div>
<br />
<asp:Panel  ID="pnlComment" runat="server" ></asp:Panel>
<div ID="lblPGResult" runat="server"></div>



