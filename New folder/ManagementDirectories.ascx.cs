using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Data;
using System.Web.UI.WebControls.WebParts;
using System.Text;

namespace VrtxIntranetPortal.ManagementDirectories
{
    [ToolboxItemAttribute(false)]
    public partial class ManagementDirectories : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public ManagementDirectories()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GetMangeDirectories();
        }

        private void GetMangeDirectories()
        {
            using (SPSite osite = new SPSite(SPContext.Current.Web.Url))
            {
                using (SPWeb oweb = osite.OpenWeb())
                {
                    SPQuery qry = new SPQuery();
                    SPList olist = oweb.Lists.TryGetList("Management Directories");                    
                    SPListItemCollection collListItems = olist.GetItems();
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Title", typeof(string));
                    dt.Columns.Add("Designation", typeof(string));
                    dt.Columns.Add("PhoneNumber", typeof(string));
                    dt.Columns.Add("ICQNo", typeof(string));
                    dt.Columns.Add("VertexMailID", typeof(string));
                    if (collListItems.Count > 0)
                    {
                        foreach (SPListItem item in collListItems)
                        {
                            DataRow dr = dt.NewRow();
                            dr["Title"] = item["Title"] != null ? item["Title"].ToString() : string.Empty;
                            dr["Designation"] = item["Designation"] != null ? item["Designation"].ToString() : string.Empty;
                            dr["PhoneNumber"] = item["PhoneNumber"] != null ? item["PhoneNumber"].ToString() : string.Empty;
                            dr["ICQNo"] = item["ICQNo"] != null ? item["ICQNo"].ToString() : string.Empty;
                            StringBuilder st=new StringBuilder();
                            st.AppendFormat("<a href=mailto:"+item["VertexMailID"].ToString()+" style=cursor:hand>"+item["VertexMailID"].ToString()+"</a>");
                            dr["VertexMailID"] = item["VertexMailID"] != null ? st.ToString() : string.Empty;
                            dt.Rows.Add(dr);
                        }
                        gvmangementDirectroies.DataSource = dt;
                        gvmangementDirectroies.DataBind();
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
