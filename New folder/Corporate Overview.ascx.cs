using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Data;
using System.Web;

namespace Company.Corporate_Overview
{
    [ToolboxItemAttribute(false)]
    public partial class Corporate_Overview : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Corporate_Overview()
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
                    GetCorporateOverview(Year);
                }
                else
                {
                    string currentYear = DateTime.Now.Year.ToString();
                    int year = Convert.ToInt32(currentYear);
                    string yearvalue = Convert.ToString(year - 1);
                    string yeare = yearvalue;// DateTime.Now.Year.ToString();
                    GetCorporateOverview(yeare);
                }

            }

        }
        private void GetCorporateOverview(string year)
        {
            using (SPSite osite = new SPSite(SPContext.Current.Web.Url))
            {
                using (SPWeb oweb = osite.OpenWeb())
                {


                    SPList olist = oweb.Lists.TryGetList("CorporateOverview");
                    SPQuery querry = new SPQuery();
                    string query = string.Empty;
                    if (year != "allyears")
                    {
                        query = string.Format(@"<Where><Eq><FieldRef Name='FiscalYear'/><Value Type='Lookup'>{0}</Value></Eq></Where>", year);
                    }
                    else
                    {
                        string yearval = DateTime.Now.Year.ToString();
                        query = string.Format(@"<Where><Neq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>" + yearval + "</Value></Neq></Where>");
                    }
                    querry.Query = query;
                    SPListItemCollection collListItems = olist.GetItems(querry);

                    DataTable dt = new DataTable();

                    dt.Columns.Add("Title", typeof(string));
                    dt.Columns.Add("Description", typeof(string));
                    if (collListItems.Count > 0)
                    {
                        foreach (SPListItem item in collListItems)
                        {
                            DataRow dr = dt.NewRow();

                            dr["Title"] = item["Title"] != null ? item["Title"].ToString() : string.Empty;
                            dr["Description"] = item["Description"] != null ? item["Description"].ToString() : string.Empty;
                            dt.Rows.Add(dr);
                        }
                        gvCorporateOverview.DataSource = dt;
                        gvCorporateOverview.DataBind();
                    }

                    else
                    {
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = "No Data Found";
                    }
                }
            }
        }
    }
}
