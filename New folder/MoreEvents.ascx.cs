using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Data;
using System.IO;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Administration;
using System.Web;

namespace VrtxIntranetPortal.MoreEvents
{
    [ToolboxItemAttribute(false)]
    public partial class MoreEvents : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public MoreEvents()
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
                    GetMoreEvents(Year);
                }
                else
                {
                    string yeare = DateTime.Now.Year.ToString();
                    GetMoreEvents(yeare);
                }

            }
        }



        private void GetMoreEvents(string year)
        {

            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    SPQuery qry = new SPQuery();
                    SPList list = web.Lists.TryGetList("WhatsNew");
                    string currenyear = DateTime.Now.Year.ToString();
                    if (year != "allyears")
                    {
                        qry.Query = "<Where><Eq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>" + year + "</Value></Eq></Where>";


                    }
                    else
                    {
                        qry.Query = "<Where><Neq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>" + currenyear + "</Value></Neq></Where>";
                    }

                    SPListItemCollection itemCollection = list.GetItems(qry); ;
                    DataTable dt = new DataTable();
                    dt.Columns.Add("Title");
                    dt.Columns.Add("Description");
                    dt.Columns.Add("ImagePath");
                    dt.Columns.Add("pageURL");


                    if (itemCollection.Count > 0)
                    {
                        foreach (SPListItem item in itemCollection)
                        {
                            DataRow row = dt.NewRow();
                            row["Title"] = item["Title"].ToString();

                            StringBuilder st = new StringBuilder();
                            StringBuilder sbmore = new StringBuilder();

                            SPFieldMultiLineText multilineField = item.Fields.GetField("EventDescription") as SPFieldMultiLineText;
                            string htmltext = multilineField.GetFieldValueAsHtml(item["EventDescription"], item);
                            string normaltext = multilineField.GetFieldValueAsText(item["EventDescription"]);
                            sbmore.Append(normaltext);

                            string text = sbmore.ToString();

                            renderHtml.InnerHtml = sbmore.ToString();

                            renderHtml.InnerText = sbmore.ToString();

                            text = renderHtml.InnerText;
                            
                            if (item["EventDescription"].ToString().Length > 400)
                            {
                                st.Append(item["EventDescription"].ToString().Substring(0, 400) +"...." + "<a id='trigger' onmouseover ='mouseoveritem(&quot; " + text + " &quot;)'>More</a>");

                            }
                            else
                            {
                                st.Append(item["EventDescription"].ToString());
                            }

                            row["Description"] = st.ToString();


                            string attachmentInfo = String.Empty;
                            if (item.Attachments.Count > 0)
                            {
                                foreach (string filename in item.Attachments)
                                {
                                    attachmentInfo += item.Attachments.UrlPrefix + filename;

                                }
                            }
                            else {
                                attachmentInfo = "/_layouts/15/VrtxIntranetStyles/Images/events.jpg";
                            }
                            if (item["PictureLibUrl"] != null)
                            {

                                SPFieldUrlValue typedValue = new SPFieldUrlValue(item["PictureLibUrl"].ToString());

                                if (typedValue.Url != string.Empty)
                                {
                                    row["pageURL"] = typedValue.Url;
                                }
                               
                            }
                            else
                            {
                                //row["pageURL"] =string.Empty; 
                            }

                            row["ImagePath"] = attachmentInfo;
                           
                            dt.Rows.Add(row);
                        }

                        gridImage.DataSource = dt;
                        gridImage.DataBind();

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

