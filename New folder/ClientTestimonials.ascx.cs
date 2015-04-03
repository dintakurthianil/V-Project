using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Data;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Company.ClientTestimonials
{
    [ToolboxItemAttribute(false)]
    public partial class ClientTestimonials : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public ClientTestimonials()
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
                    GetClientTestimonial(Year);
                }
                else {
                    string yeare = DateTime.Now.Year.ToString();
                    GetClientTestimonial(yeare);
                }

            }
        }

        //SPUserCollection users;
        SPFieldUserValueCollection userFieldValueCollection;
        string imagepath;
        string attachmentAbsoluteURL;
        private void GetClientTestimonial(string year)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Attachments", typeof(string));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Description", typeof(string));
            dt.Columns.Add("htmlable");
            using (SPSite osite = new SPSite(SPContext.Current.Web.Url))
            {
                using (SPWeb oweb = osite.OpenWeb())
                { 
                    string currentYears =string.Empty;

                    
                      currentYears=year;
                    
                     

                   //DateTime.Now.Year.ToString();
                    SPList listclienttestmonial = oweb.Lists.TryGetList("Client Testimonials");
                    SPQuery qurryclienttestmonialcollection = new SPQuery();
                    string stringQueryclienttestmonial=string.Empty;
                    if (currentYears != "allyears")
                    {
                        stringQueryclienttestmonial = string.Format(@"<Where><Eq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>{0}</Value></Eq></Where>", currentYears);

                    }
                    else {
                        string yearval = DateTime.Now.Year.ToString();
                        stringQueryclienttestmonial = string.Format(@"<Where><Neq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>" + yearval + "</Value></Neq></Where>");
                    }
                    qurryclienttestmonialcollection.Query = stringQueryclienttestmonial;
                    SPListItemCollection collListItems = listclienttestmonial.GetItems(qurryclienttestmonialcollection);
                    StringBuilder sb = new StringBuilder();
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
                            dr["Description"] = item["Description"] != null ? item["Description"].ToString() : string.Empty;

                            SPFieldUser userField = (SPFieldUser)item.Fields.GetField("Team");
                            userFieldValueCollection = (SPFieldUserValueCollection)userField.GetFieldValue(item["Team"].ToString());

                            foreach (SPFieldUserValue user in userFieldValueCollection)
                            {
                                string uservalue = user.User.ToString().Split('\\')[1];
                                SPList empbasicinfolist = oweb.Lists.TryGetList("EmpBasicInfo");
                                SPQuery q = new SPQuery();
                                string stringQuery = string.Format(@"<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>{0}</Value></Eq></Where>", uservalue);
                                q.Query = stringQuery;
                                SPListItemCollection employebasicinfocollListItems = empbasicinfolist.GetItems(q);
                                foreach (SPListItem items in employebasicinfocollListItems)
                                {
                                    if (items.Attachments.Count > 0)
                                    {
                                        foreach (String attachmentname in items.Attachments)
                                        {
                                            attachmentAbsoluteURL = items.Attachments.UrlPrefix + attachmentname;
                                            imagepath = attachmentAbsoluteURL.ToString();
                                        }
                                    }
                                    else
                                    {
                                        imagepath = "/_layouts/15/VrtxIntranetStyles/Images/NoImage.jpg";
                                    }
                                    string Name = items["Title"] != null ? items["Title"].ToString() : string.Empty;
                                    sb.Append("<div> ");
                                    sb.Append("<table style=\"float:left\">");
                                    sb.Append("<tr>");
                                    sb.AppendFormat("<td style=\"padding-left: 10px;  \">{0}</td>", "<a href=\"/SitePages/ODCServiceProfiles.aspx?username=" + Name + "\" Target='_blank'><img style=\"height:100px;width:100px \" src='" + imagepath + "'/></a></td>", Name);
                                    sb.Append("</tr>");
                                    sb.Append("<tr>");
                                    sb.AppendFormat("<td style=\"text-align: center;\"><a href=\"/SitePages/ODCServiceProfiles.aspx?username={0}\" Target='_blank'>{0}</a></td>", Name);
                                    sb.Append("</tr>");
                                    sb.Append("</table>");
                                }
                            }
                            dr["htmlable"] = sb.Append("</div>");
                            sb.Clear();
                            dt.Rows.Add(dr);
                        }
                    }
                    else
                    {
                        lblerrormessage.Visible = true;
                        lblerrormessage.Text = "No Data Found";
                    }
                }
                gvClientTestimonials.DataSource = dt;
                gvClientTestimonials.DataBind();
            }
        }
    }
}
