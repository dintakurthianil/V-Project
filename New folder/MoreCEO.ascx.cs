using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace VrtxIntranetPortal.MoreCEO
{
    [ToolboxItemAttribute(false)]
    public partial class MoreCEO : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public MoreCEO()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                if (HttpContext.Current.Request.QueryString["year"] != null)
                {
                    string Year = HttpContext.Current.Request.QueryString["year"].ToString();
                    GetMoreCEO(Year);
                }
                else
                {
                    string yeare = DateTime.Now.Year.ToString();
                    GetMoreCEO(yeare);
                }

            }
        }
        private void GetMoreCEO(string year)
        {
            using (SPSite osite = new SPSite(SPContext.Current.Web.Url))
            {
                using (SPWeb oweb = osite.OpenWeb())
                {
                    SPQuery qry = new SPQuery();
                    SPList olist = oweb.Lists.TryGetList("CEOMessage");
                    if (year != "allyears")
                    {
                        qry.Query = "<Where><Eq><FieldRef Name='FiscalYear' /> <Value Type='Lookup'>" + year + "</Value></Eq></Where>";


                    }
                    else
                    {
                        string yearval = DateTime.Now.Year.ToString();
                        qry.Query = "<Where><Neq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>" + yearval + "</Value></Neq></Where>";
                    }
                    SPListItemCollection collListItems = olist.GetItems(qry);

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Attachments", typeof(string));
                    dt.Columns.Add("Title", typeof(string));
                    dt.Columns.Add("Message", typeof(string));
                    if (collListItems.Count > 0)
                    {
                        foreach (SPListItem item in collListItems)
                        {
                            DataRow dr = dt.NewRow();
                            string attachmentAbsoluteURL = string.Empty;
                            if (item.Attachments.Count > 0)
                            {
                                foreach (String attachmentname in item.Attachments)
                                {
                                    attachmentAbsoluteURL = item.Attachments.UrlPrefix + attachmentname;
                                    dr["Attachments"] = attachmentAbsoluteURL.ToString();
                                }
                            }
                            else
                            {
                                dr["Attachments"] = "/_layouts/15/VrtxIntranetStyles/Images/NoImage.jpg";
                            }
                            dr["Title"] = item["Title"] != null ? item["Title"].ToString() : string.Empty;
                            dr["Message"] = item["Message"] != null ? item["Message"].ToString() : string.Empty;
                            dt.Rows.Add(dr);
                        }
                        gvMoreCEO.DataSource = dt;
                        gvMoreCEO.DataBind();
                    }
                    else
                    {
                        lblError.Visible = true;
                        lblError.Text = "No Data Found";
                    }
                }
            }
        }
    }
}
