<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HrApprovalEmpAdditionalInfo.ascx.cs" Inherits="VrtxIntranetHrApproval.HrApprovalEmpAdditionalInfo.HrApprovalEmpAdditionalInfo" %>

<SharePoint:CssRegistration runat="server" Name="/_layouts/15/VrtxIntranetStyles/CSS/intranet.css" />

<script>

    $(document).ready(function () {
        $('[id$=chkEmpAdditionalHeader]').click(function () {
            $("[id$='chkEmpAdditionalSelect']").attr('checked', this.checked);
        });
    });


</script>
<div>
    <table>
        <tr>
            <td>
                <asp:Label Text="Employee Additional Info" runat="server" />
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnApprove" runat="server" Text="Approve" OnClick="btnApprove_Click" />
            </td>
        </tr>
    </table>

</div>


<div>
<asp:GridView ID="GvEmpAdditionalInfo" runat="server" BorderStyle="0" Width="100%" GridLines="None" AutoGenerateColumns="false">
   <AlternatingRowStyle CssClass="grid-sub2" BorderWidth="0" />
    <RowStyle CssClass="grid-sub1" BorderWidth="0"  />
    <HeaderStyle CssClass="grid-header" /> 
        <Columns>

            <asp:TemplateField>
                 <HeaderTemplate>
                    <asp:CheckBox ID="chkEmpAdditionalHeader" runat="server" />
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="chkEmpAdditionalSelect" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="User Name">
                <ItemTemplate>
                    <asp:Label ID="lblUserName" Text='<%#Eval("UserName")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="About Spouse">
                <ItemTemplate>
                    <asp:Label ID="lblAboutSpouse" Text='<%#Eval("AboutSpouse")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Best Book">
                <ItemTemplate>
                    <asp:Label ID="lblBestBook"  Text='<%#Eval("Best_x0020_Book")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Best Restaurant">
                <ItemTemplate>
                    <asp:Label ID="lblBestRestaurant"  Text='<%#Eval("BestRestaurant")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Change Any thing About World">
                <ItemTemplate>
                    <asp:Label ID="lblChangeAnythingAboutWorld"  Text='<%#Eval("ChangeAnythingAboutWorld ")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Favorite Foods">
                <ItemTemplate>
                    <asp:Label ID="lblFavoriteFoods" Text='<%#Eval("FavoriteFoods")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Favorite Music">
                <ItemTemplate>
                    <asp:Label ID="lblFavoriteMusic"  Text='<%#Eval("FavoriteMusic")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Favorite TV">
                <ItemTemplate>
                    <asp:Label ID="lblFavoriteTV"  Text='<%#Eval("FavoriteTV")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="FollowSports">
                <ItemTemplate>
                    <asp:Label ID="lblFollowSports" Width="200px" Text='<%#Eval("FollowSports)%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>--%>

            <asp:TemplateField HeaderText="Forte Skill set">
                <ItemTemplate>
                    <asp:Label ID="lblForteSkillset" Text='<%#Eval("Forte_x0028_Skill_x0020_set_x002")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Inspired me">
                <ItemTemplate>
                    <asp:Label ID="lblInspiredme"  Text='<%#Eval("Inspiredme")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>


             <asp:TemplateField HeaderText="Interesting Thing">
                <ItemTemplate>
                    <asp:Label ID="lblInterestingThing"  Text='<%#Eval("InterestingThing")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Lazy After noon">
                <ItemTemplate>
                    <asp:Label ID="lblLazyAfternoon"  Text='<%#Eval("LazyAfternoon")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="love about jobs">
                <ItemTemplate>
                    <asp:Label ID="lblloveaboutjobs" Text='<%#Eval("loveaboutjobs")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Makes me tick">
                <ItemTemplate>
                    <asp:Label ID="lblMakesmetick"  Text='<%#Eval("Makesmetick")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Most Proud of">
                <ItemTemplate>
                    <asp:Label ID="lblMostProudof"  Text='<%#Eval("MostProudof")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="My Hobbies">
                <ItemTemplate>
                    <asp:Label ID="lblMyHobbies" Text='<%#Eval("MyHobbies")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Overview">
                <ItemTemplate>
                    <asp:Label ID="lblOverview"  Text='<%#Eval("Overview")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

             <asp:TemplateField HeaderText="Follow Sports">
                <ItemTemplate>
                    <asp:Label ID="lblFollowSports"  Text='<%#Eval("FollowSports")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
           
        </Columns>
    </asp:GridView>
    <asp:Label Text="" ID="lblValue" runat="server" />
    </div>