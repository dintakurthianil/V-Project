using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Text;

namespace VrtxIntranetPortal.TalentMgmtItmes
{
    [ToolboxItemAttribute(false)]
    public partial class TalentMgmtItmes : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public TalentMgmtItmes()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }
       
        


        protected void Page_Load(object sender, EventArgs e)
        {
            //modi 
            string viewHrManual="Value";
            ViewState["HrManual"] = viewHrManual;
            getvalues();
            //End
        }
        private void getvalues()
        {
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    
                    SPList employeemanualmasterlist = web.Lists["EmpManualMaster"];
                    StringBuilder sb = new StringBuilder();
                    SPQuery usaquery = new SPQuery();
                    string quey = string.Format(@"<Where><Eq><FieldRef Name='Country' /><Value Type='Lookup'>{0}</Value></Eq></Where>", "USA");
                    usaquery.Query = quey;
                    SPListItemCollection usacollListItems = employeemanualmasterlist.GetItems(usaquery);
                    sb.Append("<ul>");
                    foreach (SPListItem item in usacollListItems)
                    {


                        string Category = item["Title"].ToString();
                        sb.AppendFormat("<li><a onclick='Romvecookie()' href=\"/SitePages/HRPolicy.aspx?Category={0}&&Country={1}\">{0}</a>", Category, "usa");

                        SPList SubCategorylist = web.Lists["SubCategory"];
                        SPQuery usasubCategoryQuery = new SPQuery();
                        string subcategoryQuerry = string.Format(@"<Where><And><Eq><FieldRef Name='Country' /><Value Type='Lookup'>{0}</Value></Eq><Eq><FieldRef Name='Category' /><Value Type='Lookup'>{1}</Value></Eq></And></Where>","USA", Category);
                        usasubCategoryQuery.Query = subcategoryQuerry;
                        SPListItemCollection subcategorycolllistitems = SubCategorylist.GetItems(usasubCategoryQuery);
                        sb.Append("<ul>");
                        foreach (SPListItem items in subcategorycolllistitems)
                        {
                            string SubCategory = items["Title"].ToString();
                            sb.AppendFormat("<li style=''><a onclick='Romvecookie()' href=\"/SitePages/HRPolicy.aspx?Category={1}&&Country={2}&&SubCategory={0}\">{0}</a></li>", SubCategory, Category, "usa");
                        }
                        sb.Append("</ul>");
                        sb.Append("</li>");
                    }
                    sb.Append("</ul>");
                    //sb.Clear();
                    usahtmlable.InnerHtml = sb.ToString();


                    StringBuilder sb1 = new StringBuilder();
                    SPQuery indiaquery = new SPQuery();
                    string indiaquey = string.Format(@"<Where><Eq><FieldRef Name='Country' /><Value Type='Lookup'>{0}</Value></Eq></Where>", "India");
                    indiaquery.Query = indiaquey;
                    SPListItemCollection indiacollListItems = employeemanualmasterlist.GetItems(indiaquery);
                    sb1.Append("<ul>");
                    foreach (SPListItem item in indiacollListItems)
                    {

                        string Category = item["Title"].ToString();
                        sb1.AppendFormat("<li><a onclick='Romvecookie()' href=\"/SitePages/HRPolicy.aspx?Category={0}&&Country={1}\">{0}</a>", Category, "india");

                        SPList indSubCategorylist = web.Lists["SubCategory"];
                        SPQuery indiasubCategoryQuery = new SPQuery();
                        string indsubcategoryQuerry = string.Format(@"<Where><And><Eq><FieldRef Name='Country' /><Value Type='Lookup'>{0}</Value></Eq><Eq><FieldRef Name='Category' /><Value Type='Lookup'>{1}</Value></Eq></And></Where>", "India", Category);
                        indiasubCategoryQuery.Query = indsubcategoryQuerry;
                        SPListItemCollection indsubcategorycolllistitems = indSubCategorylist.GetItems(indiasubCategoryQuery);
                        sb1.Append("<ul>");
                        foreach (SPListItem items in indsubcategorycolllistitems)
                        {
                            string SubCategory = items["Title"].ToString();
                            sb1.AppendFormat("<li style=''><a onclick='Romvecookie()' href=\"/SitePages/HRPolicy.aspx?Category={1}&&Country={2}&&SubCategory={0}\">{0}</a></li>", SubCategory, Category, "India");
                        }
                        sb1.Append("</ul>");
                        sb1.Append("</li>");
                    }
                    sb1.Append("</ul>");
                    indiahtml.InnerHtml = sb1.ToString();
                    


                }
            }
        }
    }
}
