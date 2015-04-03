using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;
using System.Globalization;
using System.IO;
using System.Collections;
using Microsoft.SharePoint.Portal;
using Microsoft.SharePoint.Portal.WebControls;

namespace SuiteBarBrandingDelegate.ControlTemplates.SuiteBarBrandingDelegate
{
    public partial class CostuomActionAdmin : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //checkuser();
            //CheckIfUserIsAGroupMember("HR");
        }


        //protected override void Render(HtmlTextWriter writer)
        //{
        //    writer.RenderBeginTag(HtmlTextWriterTag.Style);
        //    writer.Write(".ms-promotedActionButton {display: inline-block;}");
        //    writer.RenderEndTag();
        //    writer.AddAttribute(HtmlTextWriterAttribute.Class, "ms-promotedActionButton");
        //    writer.RenderBeginTag(HtmlTextWriterTag.A);
        //    AddPromotedSuiteLink(writer, "http://uscl2012v3:1234/SitePages/Adminpage.aspx", "#", "Administration", "Fb_Lsp");
        //    writer.RenderEndTag();
        //    base.Render(writer);

        //}
        //protected static void AddPromotedSuiteLink(HtmlTextWriter writer, string url, string iconurl, string name, string linkId)
        //{
        //    writer.AddAttribute(HtmlTextWriterAttribute.Class, "ms-promotedActionButton");

        //    writer.AddAttribute(HtmlTextWriterAttribute.Title, name);
        //    writer.AddAttribute(HtmlTextWriterAttribute.Onclick, url);

        //    writer.RenderBeginTag(HtmlTextWriterTag.Span);
        //    writer.AddAttribute(HtmlTextWriterAttribute.Class, "s4-clust ms-promotedActionButton-icon");

        //    writer.RenderBeginTag(HtmlTextWriterTag.Img);
        //    writer.AddAttribute(HtmlTextWriterAttribute.Src, iconurl);
        //    writer.RenderEndTag();

        //    writer.RenderEndTag();

        //    writer.RenderBeginTag(HtmlTextWriterTag.Span);
        //    writer.AddAttribute(HtmlTextWriterAttribute.Class, "ms-promotedActionButton-text");

        //    writer.AddAttribute(HtmlTextWriterAttribute.Id, linkId);

        //    writer.Write(name);
        //    writer.RenderEndTag();
        //}

        //private void checkusegroup()
        //{
        //    using (SPSite site = new SPSite(SPContext.Current.Web.Url))
        //    {
        //        using (SPWeb objWeb = site.OpenWeb())
        //        {
        //            SPList oList = objWeb.Lists["Kaizen Category"];

        //            SPListItemCollection results = oList.GetItems();

        //            foreach (SPListItem item in results)
        //            {

        //                string group = item["Category"].ToString();

        //                SPGroup groupName = SPContext.Current.Web.Groups[group];////.Split('#')[1] 

        //                SPUser user = objWeb.EnsureUser(objWeb.CurrentUser.ToString());

        //                if (groupName.ContainsCurrentUser)
        //                {
        //                    //divDrop.Visible = true;

        //                }
        //            }
        //        }
        //    }

        //}

        #region May be use later
        //public bool CheckIfUserIsAGroupMember(string groupName)
        //{
        //    using (SPSite site = new SPSite(SPContext.Current.Site.ID))
        //    {
        //        using (SPWeb web = site.OpenWeb(SPContext.Current.Web.ID))
        //        {
        //            return web.SiteGroups[groupName].ContainsCurrentUser;
        //        }
        //    }
        //} 
        #endregion
        private void checkuser()
        {
            using (SPSite ostite = SPContext.Current.Site)
            {
                using (SPWeb rootWeb = ostite.OpenWeb())
                {
                    //foreach (SPGroup group in rootWeb.SiteGroups)
                    //{
                        SPGroup Groupname;
                        bool IsHe;
                        SPUser currentuser = SPContext.Current.Web.CurrentUser;
                        //Checking Logged in user belong to HR
                        Groupname = rootWeb.Groups["HR"];
                        IsHe = isUserInGroup(Groupname, currentuser.LoginName);
                        if (IsHe == true)
                        {
                            administration.Visible = true;
                        }


                        //Checking Logged in user belong to Marketing
                        Groupname = rootWeb.Groups["Marketing"];
                        IsHe = isUserInGroup(Groupname, currentuser.LoginName);
                        if (IsHe == true)
                        {
                            administration.Visible = true;
                        }


                    //}
                }
            }

        }

        private Boolean isUserInGroup(SPGroup oGroupName, String sUserLoginName)
        {
            Boolean bUserIsInGroup = false;
            try
            {
                SPUser x = oGroupName.Users[sUserLoginName];
                bUserIsInGroup = true;
            }
            catch (SPException)
            {
                bUserIsInGroup = false;
            }
            return bUserIsInGroup;

        }

       

    }
}





