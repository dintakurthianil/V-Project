using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Data;
using System.Web.UI.WebControls.WebParts;

namespace VrtxIntranetPortal.SmartTool
{
    [ToolboxItemAttribute(false)]
    public partial class SmartTool : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public SmartTool()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           // txtNmae.Text = "helo";
            GetSmartTools();
        }

        private void GetSmartTools()
        {
            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {

                using (SPWeb web = site.OpenWeb())
                {
                    SPList list = web.Lists.TryGetList("Smart Tools");
                    if (list != null)
                    {

                        SPQuery query = new SPQuery();
                        string stringQuery = string.Format(@"<Where><Eq><FieldRef Name='Country' /><Value Type='LookUp'>{0}</Value></Eq></Where>", "India");
                        query.Query = stringQuery;
                        SPListItemCollection queryResults = list.GetItems(query);
                        DataTable dt = new DataTable();

                        dt.Columns.Add("URL", typeof(string));
                        dt.Columns.Add("ToolName", typeof(string));
                        dt.Columns.Add("Country", typeof(string));
                        dt.Columns.Add("Notes", typeof(string));

                        if (queryResults != null && queryResults.Count > 0)
                        {
                            foreach (SPListItem item in queryResults)
                            {

                                DataRow dr = dt.NewRow();
                               
                                if (item["URL"] != null)
                                {
                                    SPFieldUrlValue urlFiled = new SPFieldUrlValue(item["URL"].ToString());

                                    string urldes = urlFiled.Description;
                                    string urlNmae = urlFiled.Url;
                                   // string ursl = "<a href =" + urlNmae + " target='_blank'>" + item["Tool_x0020_Name"] + "</a>";
                                    dr["URL"] = item["URL"] = urlNmae;
                                }
                                else {
                                    dr["URL"] = string.Empty;
                                }

                                
                                dr["ToolName"] = item["Tool_x0020_Name"] != null ? item["Tool_x0020_Name"].ToString() : string.Empty;

                                dr["Country"] = new SPFieldLookupValue(item["Country"] as String).LookupValue;
                                dr["Notes"] = item["Notes"] != null ? item["Notes"].ToString() : string.Empty;
                                dt.Rows.Add(dr);
                            }
                        }
                        else
                        {

                        }

                        gvIndiaSmartTool.DataSource = dt;
                        gvIndiaSmartTool.DataBind();


                        SPQuery query1 = new SPQuery();
                        string stringQuery1 = string.Format(@"<Where><Eq><FieldRef Name='Country' /><Value Type='LookUp'>{0}</Value></Eq></Where>", "USA");
                        query1.Query = stringQuery1;
                        SPListItemCollection queryResults1 = list.GetItems(query1);
                        DataTable dt1 = new DataTable();

                        dt1.Columns.Add("URL", typeof(string));
                        dt1.Columns.Add("ToolName", typeof(string));
                        dt1.Columns.Add("Country", typeof(string));
                        dt1.Columns.Add("Notes", typeof(string));
                        if (queryResults1 != null && queryResults1.Count > 0)
                        {
                            foreach (SPListItem item in queryResults1)
                            {

                                DataRow dr = dt1.NewRow();
                                if (item["URL"] != null)
                                {
                                    SPFieldUrlValue urlFiled = new SPFieldUrlValue(item["URL"].ToString());

                                    string urldes = urlFiled.Description;
                                    string urlNmae = urlFiled.Url;
                                   // string ursl = "<a href=" + urlNmae + " target='_blank'>" + item["Tool_x0020_Name"] + "</a>";
                                    dr["URL"] = item["URL"] = urlNmae;
                                }
                                else
                                {
                                    dr["URL"] = string.Empty;
                                }
                               
                                dr["ToolName"] = item["Tool_x0020_Name"] != null ? item["Tool_x0020_Name"].ToString() : string.Empty;
                                dr["Country"] = new SPFieldLookupValue(item["Country"] as String).LookupValue;
                                dr["Notes"] = item["Notes"] != null ? item["Notes"].ToString() : string.Empty;
                                dt1.Rows.Add(dr);
                            }
                        }
                        else
                        {

                        }

                        gvUSASmartTool.DataSource = dt1;
                        gvUSASmartTool.DataBind();
                    }
                }
            }

        }
    }
}
