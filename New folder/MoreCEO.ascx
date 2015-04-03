<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MoreCEO.ascx.cs" Inherits="VrtxIntranetPortal.MoreCEO.MoreCEO" %>

<SharePoint:CssRegistration runat="server" Name="/_layouts/15/VrtxIntranetStyles/CSS/intranet.css" />
<asp:GridView ID="gvMoreCEO" runat="server" AutoGenerateColumns="false" Width="100%" BorderStyle="0" GridLines="None">
    <AlternatingRowStyle CssClass="" BorderWidth="0" />
    <RowStyle CssClass="" BorderWidth="0" />
    <HeaderStyle CssClass="" />

    <Columns>
        <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <div style="background-color: #f7f6f6; overflow: hidden; padding: 10px; margin-bottom: 10px;">
                    <div style="border-right: #fff solid 1px; width: 100px; height: 100px; margin-right: 10px; float: left;">
                        <asp:Image ID="imgImage" Height="100" Width="100" runat="server" ImageUrl='<%# Eval("Attachments")%>' />
                    </div>
                    <div style="width: 85%; float: left; padding: 0; margin: 0;">
                        <h2 style="color: #133d8c;">
                            <asp:Label ID="lblTittle" Text='<%#Eval("Title")%>' runat="server"></asp:Label></h2>
                        <div style="line-height:20px">
                            <asp:Label ID="lblDesciption" Text='<%#Eval("Message")%>' runat="server"  ></asp:Label>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

<div style="padding-left: 30%;padding-top: 10%;">
    <h2><asp:Label Text="" ID="lblError" Visible="false" runat="server" /></h2>
</div>