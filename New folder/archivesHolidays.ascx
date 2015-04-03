<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>

<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="archivesHolidays.ascx.cs" Inherits="VrtxIntranetArchives.archivesHolidays.archivesHolidays" %>
<SharePoint:CssRegistration runat="server" Name="/_layouts/15/VrtxIntranetStyles/CSS/intranet.css" />




<%--<asp:Label Text="USA - Archives" runat="server" />
<asp:Label Text="text" runat="server" />
<asp:Label Text="text" runat="server" />
<asp:GridView ID="gvHolidays" runat="server" AutoGenerateColumns="false" Width ="100%" BorderStyle="0"  GridLines="None">
    <AlternatingRowStyle CssClass="grid-sub2" BorderWidth="0" />
    <RowStyle CssClass="grid-sub1" BorderWidth="0"  />
    <HeaderStyle CssClass="grid-header" />

    <Columns>
        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left"  > 
            <ItemTemplate>
               <asp:Label ID="lblSerialNo" Text='<%#Container.DataItemIndex + 1%>'  runat="server"></asp:Label>
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

<asp:Label  ID="lblUSA" runat="server" />

<br />
<asp:Panel  ID="pnlComment" runat="server" ></asp:Panel>
<div ID="lblPGResult" runat="server"></div>

<asp:Label Text="India - Archives" runat="server" />

<asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="false" Width ="100%" BorderStyle="0"  GridLines="None">
    <AlternatingRowStyle CssClass="grid-sub2" BorderWidth="0" />
    <RowStyle CssClass="grid-sub1" BorderWidth="0"  />
    <HeaderStyle CssClass="grid-header" />

    <Columns>
        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left"  > 
            <ItemTemplate>
               <asp:Label ID="lblSerialNo" Text='<%#Container.DataItemIndex + 1%>'  runat="server"></asp:Label>
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

<br />
<asp:Label  ID="lblInd" runat="server" />

<br />
<asp:Label Text="P&G - Archives" runat="server" />

<br />
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" Width ="100%" BorderStyle="0"  GridLines="None">
    <AlternatingRowStyle CssClass="grid-sub2" BorderWidth="0" />
    <RowStyle CssClass="grid-sub1" BorderWidth="0"  />
    <HeaderStyle CssClass="grid-header" />
    <Columns>
        <asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left"  > 
            <ItemTemplate>
               <asp:Label ID="lblSerialNo" Text='<%#Container.DataItemIndex + 1%>'  runat="server"></asp:Label>
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

<asp:Label Text="" ID="lblP&G" runat="server" />--%>
