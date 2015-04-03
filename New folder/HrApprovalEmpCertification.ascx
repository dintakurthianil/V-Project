<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HrApprovalEmpCertification.ascx.cs" Inherits="VrtxIntranetHrApproval.HrApprovalEmpCertification.HrApprovalEmpCertification" %>
<SharePoint:CssRegistration runat="server" Name="/_layouts/15/VrtxIntranetStyles/CSS/intranet.css" />

<script>

    $(document).ready(function () {
        $('[id$=chkCertificationHeader]').click(function () {
            $("[id$='chkEmpCertificationsSelect']").attr('checked', this.checked);
        });
    });


</script>
<div>
    <table>
        <tr>
            <td>
                <asp:Label Text="Employee Certifications" runat="server" />
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" />
            </td>
        </tr>
    </table>

</div>


<table>
    <asp:GridView ID="GvCertifications" runat="server" BorderStyle="0" Width="100%" GridLines="None" AutoGenerateColumns="false">
        <AlternatingRowStyle CssClass="grid-sub2" BorderWidth="0" />
        <RowStyle CssClass="grid-sub1" BorderWidth="0" />
        <HeaderStyle CssClass="grid-header" />
        <Columns>

            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox ID="chkCertificationHeader" runat="server" />
                </HeaderTemplate>
                <ItemTemplate >
                    <asp:CheckBox ID="chkEmpCertificationsSelect" runat="server"  />
                </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField HeaderText="User Name">
                <ItemTemplate>
                    <asp:Label ID="lblUserName" Text='<%#Eval("UserName")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Technology" >
                <ItemTemplate>
                    <asp:Label ID="lblTechnology" Text='<%#Eval("Technology")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Name of Certification">
                <ItemTemplate>
                    <asp:Label ID="lblNameofCertifi" Text='<%#Eval("Certificate")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Certification ID">
                <ItemTemplate>
                    <asp:Label ID="lblCertificationID" Text='<%#Eval("CertificationID")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Certified Date">
                <ItemTemplate>
                    <asp:Label ID="lblCertifiedDate" Text='<%#Eval("CertifiedDate")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Until Date">
                <ItemTemplate>
                    <asp:Label ID="lblUntilDate" Text='<%#Eval("UntilDate")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>

    </asp:GridView>

    <asp:Label Text="" ID="lblValue" runat="server" />
</table>
