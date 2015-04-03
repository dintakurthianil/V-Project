<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ManagementDirectories.ascx.cs" Inherits="VrtxIntranetPortal.ManagementDirectories.ManagementDirectories" %>



<SharePoint:CssRegistration runat="server" Name="/_layouts/15/VrtxIntranetStyles/CSS/intranet.css" />
<asp:GridView ID="gvmangementDirectroies" runat="server" AutoGenerateColumns="false" Width="100%" BorderStyle="0" GridLines="None">
    <AlternatingRowStyle CssClass="grid-sub2" BorderWidth="0" />
    <RowStyle CssClass="grid-sub1" BorderWidth="0" />
    <HeaderStyle CssClass="grid-header" />

    <Columns>
         <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left"  > 
            <ItemTemplate>
               <asp:Label ID="lblSerialNo" Text='<%#Container.DataItemIndex + 1%>'  runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
               <asp:Label ID="lblTitle" Text='<%#Eval("Title")%>'  runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Designation" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
               <asp:Label ID="lblDesignation" Text='<%#Eval("Designation")%>'  runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Phone Number" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
               <asp:Label ID="lblPhoneNumber" Text='<%#Eval("PhoneNumber")%>'  runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="ICQ No" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
               <asp:Label ID="lblICQNo" Text='<%#Eval("ICQNo")%>'  runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Vertex Mail ID" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
              <asp:Label ID="lblEmail" Text='<%#Eval("VertexMailID")%>'  runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<div style="padding-left: 30%;padding-top: 10%;">
    <h2><asp:Label Text="" ID="lblError" Visible="false" runat="server" /></h2>
</div>