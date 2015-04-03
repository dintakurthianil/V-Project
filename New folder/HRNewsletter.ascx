<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HRNewsletter.ascx.cs" Inherits="TalentManagement.HRNewsletter.HRNewsletter" %>

<SharePoint:CssRegistration runat="server" Name="/_layouts/15/VrtxIntranetStyles/CSS/intranet.css" />

<div style="margin-top:19px;">
    <asp:GridView ID="grdDocument" runat="server" AutoGenerateColumns="false" Style="width: 100%" GridLines="None">
        <AlternatingRowStyle CssClass="grid-sub2" BorderWidth="0" />
        <RowStyle CssClass="grid-sub1" BorderWidth="0" />
        <HeaderStyle CssClass="grid-header" />
        <Columns>
            <asp:TemplateField HeaderText="S.NO" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblIndiaSerialNo" Text='<%#Container.DataItemIndex + 1%>' Width="50px" runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Month" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="Label1" Text='<%#Eval("Month")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DownLoad Link" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <a href='<%#Eval("URl")%>' style="vertical-align: top"><%#"Click Here to download" +" "+ Eval("Month") + " " + "News letter"%></a>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div style="padding-left: 30%; padding-top: 10%;">
        <h2>
            <asp:Label Text="" ID="lblError" Visible="false" runat="server" /></h2>
    </div>
</div>
