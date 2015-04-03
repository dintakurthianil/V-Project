<%@ Assembly Name="$SharePoint.Project.AssemblyFullName$" %>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Archives-TrainingandDevelopment.ascx.cs" Inherits="VrtxIntranetArchives.Archives_TrainingandDevelopment.Archives_TrainingandDevelopment" %>



<SharePoint:CssRegistration runat="server" Name="/_layouts/15/VrtxIntranetStyles/CSS/intranet.css" />
<div style="margin-top: 19px;">
    <asp:GridView ID="gvTraining" runat="server" AutoGenerateColumns="false" Width="100%" BorderStyle="0" GridLines="None">
        <AlternatingRowStyle CssClass="" BorderWidth="0" />
        <RowStyle CssClass="grid-sub1" BorderWidth="0" />
        <HeaderStyle CssClass="grid-header" />


        <Columns>
            <%--<asp:TemplateField HeaderText="S.No" HeaderStyle-HorizontalAlign="Left"  > 
            <ItemTemplate>
               <asp:Label ID="lblSerialNo" Text='<%#Container.DataItemIndex + 1%>'  runat="server"></asp:Label>
            </ItemTemplate>
        </asp:TemplateField>--%>
            <asp:TemplateField HeaderText="Name of Training" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblNameofTraining" Text='<%#Eval("Title")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Target Audience" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblTargetAudience" Text='<%#Eval("TargetAudience")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Planned Date" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblPlannedDate" Text='<%#Eval("PlannedDate")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Total Duration" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblTotalDuration" Text='<%#Eval("TotalDuration")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Mode of Training" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblModeofTraining" Text='<%#Eval("Modeoftraining")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actual Date of Training" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblActualDateofTraining" Text='<%#Eval("ActualDateofTraining")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Name of the Trainer" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblNameoftheTrainer" Text='<%#Eval("NameoftheTrainer")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Start Date" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblEventDate" Text='<%#Eval("EventDate")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="End Date" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblEndDate" Text='<%#Eval("EndDate")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Comments" HeaderStyle-HorizontalAlign="Left">
                <ItemTemplate>
                    <asp:Label ID="lblComments" Text='<%#Eval("Comments")%>' runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <div style="padding-left: 30%; padding-top: 10%;">
        <h2>
            <asp:Label Text="" ID="lblError" Visible="false" runat="server" /></h2>
    </div>
</div>
