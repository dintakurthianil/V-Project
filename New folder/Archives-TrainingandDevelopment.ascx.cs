using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace VrtxIntranetArchives.Archives_TrainingandDevelopment
{
    [ToolboxItemAttribute(false)]
    public partial class Archives_TrainingandDevelopment : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Archives_TrainingandDevelopment()
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
                    GetCalenderEvents(Year);
                }
                else
                {
                    string yeare = DateTime.Now.Year.ToString();
                    GetCalenderEvents(yeare);
                }

            }
        }

        private void GetCalenderEvents(string year)
        {


            using (SPSite osite = new SPSite(SPContext.Current.Web.Url))
            {
                using (SPWeb oweb = osite.OpenWeb())
                {
                    SPQuery qry = new SPQuery();
                    SPList olist = oweb.Lists.TryGetList("Training & Development Calendar");
                    string currentYear = DateTime.Now.Year.ToString();
                    if (year != "allyears")
                    {

                        qry.Query = "<Where><Eq><FieldRef Name='FiscalYear' /><Value Type='Text'>" + year + "</Value></Eq></Where>";


                    }
                    else
                    {

                        qry.Query = "<Where><Neq><FieldRef Name='FiscalYear' /><Value Type='Text'>" + currentYear + "</Value></Neq></Where>";
                    }
                    SPListItemCollection collListItems = olist.GetItems(qry);
                    if (collListItems.Count > 0)
                    {
                        DataTable dt = new DataTable();
                        dt.Columns.Add("Title", typeof(string));
                        dt.Columns.Add("TargetAudience", typeof(string));
                        dt.Columns.Add("PlannedDate", typeof(string));
                        dt.Columns.Add("TotalDuration", typeof(string));
                        dt.Columns.Add("Modeoftraining", typeof(string));
                        dt.Columns.Add("ActualDateofTraining", typeof(string));
                        dt.Columns.Add("NameoftheTrainer", typeof(string));
                        dt.Columns.Add("EndDate", typeof(string));
                        dt.Columns.Add("EventDate", typeof(string));
                        dt.Columns.Add("Comments", typeof(string));



                        foreach (SPListItem item in collListItems)
                        {


                            string[] delimit = new string[] { ";#" };

                            DataRow dr = dt.NewRow();
                            string[] stringarray = item["TargetAudience"].ToString().Split((delimit), StringSplitOptions.RemoveEmptyEntries);
                            StringBuilder sb = new StringBuilder();
                            for (int i = 0; i < stringarray.Length; i++)
                            {

                                if (i % 2 != 0)
                                {
                                    sb.Append(stringarray[i].ToString()+" ");
                                }
                            }
                            dr["Title"] = item["Title"] != null ? item["Title"].ToString() : string.Empty;
                            dr["TargetAudience"] = sb.ToString();// fieldUserValues.ToString();//item["TargetAudience"] != null ? item["TargetAudience"].ToString() : string.Empty;
                            dr["PlannedDate"] = item["PlannedDate"] != null ? item["PlannedDate"].ToString() : string.Empty;
                            dr["TotalDuration"] = item["TotalDuration"] != null ? item["TotalDuration"].ToString() : string.Empty;
                            dr["Modeoftraining"] = item["Modeoftraining"] != null ? item["Modeoftraining"].ToString() : string.Empty;
                            dr["ActualDateofTraining"] = item["ActualDateofTraining"] != null ? item["ActualDateofTraining"].ToString() : string.Empty;
                            dr["NameoftheTrainer"] = item["NameoftheTrainer"] != null ? item["NameoftheTrainer"].ToString() : string.Empty;
                            dr["EndDate"] = item["EndDate"] != null ? item["EndDate"].ToString() : string.Empty;
                            dr["EventDate"] = item["EventDate"] != null ? item["EventDate"].ToString() : string.Empty;
                            dr["Comments"] = item["Comments"] != null ? item["Comments"].ToString() : string.Empty;
                            dt.Rows.Add(dr);
                        }
                        gvTraining.DataSource = dt;
                        gvTraining.DataBind();
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
