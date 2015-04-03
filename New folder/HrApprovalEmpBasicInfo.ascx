<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HrApprovalEmpBasicInfo.ascx.cs" Inherits="VrtxIntranetHrApproval.HrApprovalEmpBasicInfo.HrApprovalEmpBasicInfo" %>
<SharePoint:CssRegistration runat="server" Name="/_layouts/15/VrtxIntranetStyles/CSS/intranet.css" />


<script>

    $(document).ready(function () {
        $('[id$=chkEmpBasicHeader]').click(function () {
            $("[id$='chkEmpBasicSelect']").attr('checked', this.checked);
        });
    });


</script>
<div>
    <table>
        <tr>
            <td>
                <asp:Label Text="Employee Basic Info" runat="server" />
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" />
            </td>
        </tr>
    </table>

</div>

<table>
    <asp:GridView ID="GvEmpBasicInfo" runat="server" BorderStyle="0" Width="100%" GridLines="None" AutoGenerateColumns="false">
       <AlternatingRowStyle CssClass="grid-sub2" BorderWidth="0" />
    <RowStyle CssClass="grid-sub1" BorderWidth="0"  />
    <HeaderStyle CssClass="grid-header" /> 
        <Columns>

            <asp:TemplateField>
                <HeaderTemplate>
                    <asp:CheckBox ID="chkEmpBasicHeader" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkEmpBasicSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User Name">
                <ItemTemplate>
                    <asp:Label ID="lblUserName" Text='<%#Eval("Title")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="First Name" >

                <ItemTemplate>
                    <asp:Label ID="lblFirstName" Text='<%#Eval("First_x0020_Name")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="LastName">
                <ItemTemplate>
                    <asp:Label ID="lblLastName" Text='<%#Eval("Last_x0020_Name")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Mobile Number">
                <ItemTemplate>
                    <asp:Label ID="lblMobileNumber"  Text='<%#Eval("MobileNumber")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Home Phone Number">
                <ItemTemplate>
                    <asp:Label ID="lblResidencePhoneNumber" Text='<%#Eval("ResidencePhoneNumber ")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="ICQ Number">
                <ItemTemplate>
                    <asp:Label ID="lblICQNumber"  Text='<%#Eval("ICQNumber")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Extension Number ">
                <ItemTemplate>
                    <asp:Label ID="lblExtensionNumber"  Text='<%#Eval("ExtensionNumber")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Designation">
                <ItemTemplate>
                    <asp:Label ID="lblDesignation"  Text='<%#Eval("Designation")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="DOB">
                <ItemTemplate>
                    <asp:Label ID="lblDOB"  Text='<%#Eval("DOB")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                    <asp:Label ID="lblDepartment"  Text='<%#Eval("Department")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Profile Tagging">
                <ItemTemplate>
                    <asp:Label ID="lblProfileTag"  Text='<%#Eval("ProfileTag")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
     <asp:Label Text="" ID="lblValue" runat="server" />
</table>