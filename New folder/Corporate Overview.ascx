<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Corporate Overview.ascx.cs" Inherits="Company.Corporate_Overview.Corporate_Overview" %>





<asp:GridView ID="gvCorporateOverview" runat="server" AutoGenerateColumns="false" Width ="100%" BorderStyle="0"  GridLines="None">
    <AlternatingRowStyle CssClass="grid-sub2" BorderWidth="0" />
    <RowStyle CssClass="grid-sub1" BorderWidth="0"  />
    <HeaderStyle CssClass="" />

    <Columns>
        
        <asp:TemplateField HeaderText="" HeaderStyle-HorizontalAlign="Left">
            <ItemTemplate>
                <table style="padding:10px 10px 10px 10px;">

                    <tr>
                        <td style="    font-size: large;    padding:  0px 15px 0px;    color:#133d8c;">
                       <asp:Label ID="lblTittle" Text='<%#Eval("Title")%>'  runat="server"></asp:Label>
                            </td>
                    </tr>
                    <tr>
                        <td style="   padding: 0px 15px 0px; line-height:20px">
                        <asp:Label ID="lblDesciption" Text='<%#Eval("Description")%>'  runat="server"></asp:Label>
                        <td>
                       
                    </tr>
                    
                </table>
            </ItemTemplate>
        </asp:TemplateField>
       
    </Columns>
</asp:GridView>

<div style="padding-left: 30%;padding-top: 10%;">
    <h2><asp:Label Text="" ID="lblerrormessage" Visible="false" runat="server" /></h2>

</div>