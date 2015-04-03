using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace TalentManagement.HRNewsletter
{
    [ToolboxItemAttribute(false)]
    public partial class HRNewsletter : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public HRNewsletter()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Request.QueryString["year"] != null)
            {
                string Year = HttpContext.Current.Request.QueryString["year"].ToString();
                GetHRNewsletters(Year);
            }
            else
            {
                string yeare = DateTime.Now.Year.ToString();
                GetHRNewsletters(yeare);
            }

        }
        private void GetHRNewsletters(string year)
        {
            using (SPSite osite = new SPSite(SPContext.Current.Web.Url))
            {
                using (SPWeb oweb = osite.OpenWeb())
                {
                    string currentYears = year;// DateTime.Now.Year.ToString();
                    DataTable dtListItem = new DataTable();
                    dtListItem.Columns.Add("Title", typeof(string));
                    dtListItem.Columns.Add("URl", typeof(string));
                    dtListItem.Columns.Add("Month", typeof(string));
                    //dtListItem.Columns.Add("Month", typeof(string));
                    string stringQueryclienttestmonial = string.Empty;
                    SPList olist = oweb.Lists.TryGetList("HRNewsletter");
                    SPQuery qurryclienttestmonialcollection = new SPQuery();
                    if (currentYears != "allyears")
                    {
                        stringQueryclienttestmonial = string.Format(@"<Where><Eq><FieldRef Name='fiscalYear' /><Value Type='Lookup'>{0}</Value></Eq></Where>", currentYears);

                    }
                    else
                    {
                        string yearval = DateTime.Now.Year.ToString();
                        stringQueryclienttestmonial = string.Format(@"<Where><Neq><FieldRef Name='fiscalYear' /><Value Type='Lookup'>" + yearval + "</Value></Neq></Where>");
                    }
                    qurryclienttestmonialcollection.Query = stringQueryclienttestmonial;
                    SPListItemCollection col = olist.GetItems(qurryclienttestmonialcollection);
                    if (col.Count > 0)
                    {

                        foreach (SPListItem item in col)
                        {
                            DataRow row = dtListItem.NewRow();

                            row["URl"] = item["ows_FileRef"].ToString();
                            row["Title"] = item["ows_LinkFilename"].ToString();
                            row["Month"] = item["Month"].ToString();
                            dtListItem.Rows.Add(row);

                        }

                        grdDocument.DataSource = dtListItem;
                        grdDocument.DataBind();
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
