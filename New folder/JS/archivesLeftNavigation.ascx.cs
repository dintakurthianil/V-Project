using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using Microsoft.SharePoint;
using System.Web;

namespace VrtxIntranetArchives.archivesLeftNavigation
{
    [ToolboxItemAttribute(false)]
    public partial class archivesLeftNavigation : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public archivesLeftNavigation()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["cType"] != null)
            {
                string Tabname = HttpContext.Current.Request.QueryString["cType"].ToString();
                getvalues(Tabname);
            }
        }

        private void getvalues(string Tabname)
        {
            using (SPSite site = new SPSite(SPContext.Current.Site.Url))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    
                    SPList archiveList = web.Lists["Archives"];
                    StringBuilder sb = new StringBuilder();
                    SPQuery titlequery = new SPQuery();
                    string quey = string.Format(@"<Where><Eq><FieldRef Name='TabName' /><Value Type='Text'>{0}</Value></Eq></Where>", Tabname);
                    titlequery.Query = quey;
                    SPListItemCollection usacollListItems = archiveList.GetItems(titlequery);
                    sb.Append("<ul>");
                    foreach (SPListItem item in usacollListItems)
                    {
                        string pageUrl = string.Empty;
                        string title = string.Empty;
                        string Titlvalue = string.Empty;
                        Titlvalue = item["Title"].ToString();
                        if (item["PageName"]!= null)
                        {
                             
                            title = item["PageName"].ToString();
                        }
                        else
                        {
                            title = "Archivies";
                        }
                        pageUrl = "/SitePages/" + title + ".aspx";
                        var noSpaceString = Titlvalue.Replace(" ", "");
                        sb.AppendFormat("<li ><a href='javascript:void(0)' id='" + noSpaceString + "'>{0}</a>", Titlvalue);
                        SPList fiscalyearList = web.Lists["FiscalYear"];
                        SPQuery fiscalyearQuery = new SPQuery();
                        string fiscalyearQuerry = string.Format(@"<Where><Neq><FieldRef Name='Title' /><Value Type='Text'>" + DateTime.Now.Year + "</Value></Neq></Where><OrderBy><FieldRef Name='Title' Ascending='False' /></OrderBy>");
                        fiscalyearQuery.Query = fiscalyearQuerry;
                        SPListItemCollection subcategorycolllistitems = fiscalyearList.GetItems(fiscalyearQuery);

                        sb.Append("<ul class=" + noSpaceString + " style=display:none>");
                        int counter = 0;
                        foreach (SPListItem items in subcategorycolllistitems)
                        {
                            if (counter <= 3)
                            {

                                string yearvalue = items["Title"].ToString();
                                sb.AppendFormat("<li><a href=" + pageUrl + "?cType="+Tabname+"&&year={0}&&Title={1}>{0}</a></li>", yearvalue, Titlvalue);
                                //Modi                                
                                 //End
                                counter++;
                            }
                        }
                        sb.AppendFormat("<li style=''><a href=" + pageUrl + "?cType=" + Tabname + "&&year={0}&&Title={1}>All Years</a></li>", "allyears", Titlvalue);
                        sb.Append("</ul>");
                        sb.Append("</li>");
                    }
                    sb.Append("</ul>");
                    htmlTitle.InnerHtml = sb.ToString();

                }
            }
        }
    }
}
