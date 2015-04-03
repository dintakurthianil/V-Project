<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SmartTool.ascx.cs" Inherits="VrtxIntranetPortal.SmartTool.SmartTool" %>



<SharePoint:CssRegistration runat="server" Name="/_layouts/15/VrtxIntranetStyles/CSS/intranet.css" />

<span style="font-weight: bold">Smart Tools - India</span>
<div id="Container" >
    <asp:GridView ID="gvIndiaSmartTool" runat="server" AutoGenerateColumns="false" Width="850px" BorderStyle="0" GridLines="None" CssClass="">
        <AlternatingRowStyle CssClass="grid-sub2" BorderWidth="0" />
        <RowStyle CssClass="grid-sub1" BorderWidth="0" />
        <HeaderStyle CssClass="grid-header" />

        <Columns>
            <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblIndiaSerialNo" Text='<%#Container.DataItemIndex + 1%>' Width="50px" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="URL" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:HyperLink ID="HyperLink1" runat="server" Width="200px"
                        NavigateUrl='<%# Eval("URL") %>'
                        Text='<%# Eval("ToolName") %>' Target="_blank"></asp:HyperLink>

                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tool Name" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblIndiaToolName" Width="200px" Text='<%#Eval("ToolName")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Country" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblIndiaCountry" Width="200px" Text='<%#Eval("Country")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Notes" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblIndiaNotes" Width="200px" Text='<%#Eval("Notes")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</div>
<br />
<br />
<br />
<span style="font-weight: bold">Smart Tools - USA</span>
<asp:GridView ID="gvUSASmartTool" runat="server" AutoGenerateColumns="false" Width="850px" BorderStyle="0" GridLines="None" CssClass="">
    <AlternatingRowStyle CssClass="grid-sub2" BorderWidth="0" />
    <RowStyle CssClass="grid-sub1" BorderWidth="0" />
    <HeaderStyle CssClass="grid-header" />

    <Columns>

        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left">

            <ItemTemplate>

                <asp:Label ID="lblUSASerialNo" Text='<%#Container.DataItemIndex + 1%>' Width="50px" runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="URL" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:HyperLink ID="HyperLink2" runat="server" Width="200px"
                    NavigateUrl='<%# Eval("URL") %>'
                    Text='<%# Eval("ToolName") %>' Target="_blank"></asp:HyperLink>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="ToolName" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Label ID="lblUSAToolName" Width="200px" Text='<%#Eval("ToolName")%>' runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Country" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Label ID="lblUSACountry" Width="200px" Text='<%#Eval("Country")%>' runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Notes" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <asp:Label ID="lblUSANotes" Width="200px" Text='<%#Eval("Notes")%>' runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
