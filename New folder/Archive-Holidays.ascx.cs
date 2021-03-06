﻿using Microsoft.SharePoint;
using Microsoft.SharePoint.Mobile.Controls;
using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI.WebControls.WebParts;

namespace VrtxIntranetArchives.Archive_Holidays
{
    [ToolboxItemAttribute(false)]
    public partial class Archive_Holidays : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public Archive_Holidays()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string queryResult = Page.Request.QueryString["year"];
            if (!Page.IsPostBack)
            {
                string QurCountry = string.Empty;
                if (HttpContext.Current.Request.QueryString["year"] != null)
                {
                    QurCountry = HttpContext.Current.Request.QueryString["year"];
                    GetHolidays(QurCountry, true, "usa");
                    GetHolidays(QurCountry, true, "india");
                    GetHolidays(QurCountry, true, "P&G");
                    GetHolidays(QurCountry, true, "");
                }
            }
        }
        private void GetHolidays(string year, bool isCtype, string Country)
        {
            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {

                using (SPWeb web = site.OpenWeb())
                {
                    SPList list = web.Lists.TryGetList("Holidays");
                    if (list != null)
                    {
                        SPQuery qry = new SPQuery();
                        string stringQuery = "";
                        string currentYear = DateTime.Now.Year.ToString();
                        if (Country == "usa")
                        {
                            lblUSAHeader.Visible = true;
                            if (year!="allyears")
                            {
                                stringQuery = string.Format(@"<Where><And><Eq><FieldRef Name='Country' /><Value Type='Choice'>USA</Value></Eq><And><Eq><FieldRef Name='IsPGHoliday' /><Value Type='Boolean'>0</Value></Eq><Eq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>{0}</Value></Eq></And></And></Where>", year);

                            }
                            else
                            {
                                //Querry Changed by anil on date of 3/2/2015 Due to tester told me to get data excluding present data
                                stringQuery = string.Format(@"<Where><And><Eq><FieldRef Name='Country' /><Value Type='Choice'>USA</Value></Eq><Neq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>"+currentYear+"</Value></Neq></And></Where>");
                            }
                            qry.Query = stringQuery;
                            //qry.ViewFields = @"<FieldRef Name='HolidayDate' /><FieldRef Name='Title' /><FieldRef Name='Comment' />";
                            SPListItemCollection listcoll = list.GetItems(qry);
                            DataTable dtHoliday = new DataTable();
                            //dtHoliday.Columns.Add("SNo");
                            dtHoliday.Columns.Add("Month");
                            dtHoliday.Columns.Add("Day");
                            dtHoliday.Columns.Add("HolidayDate");
                            dtHoliday.Columns.Add("HolidayName");
                            dtHoliday.Columns.Add("MonthNum", typeof(int));
                            if (listcoll.Count > 0)
                            {
                                foreach (SPListItem item in listcoll)
                                {
                                    DataRow row = dtHoliday.NewRow();
                                    string title = item["Title"].ToString();
                                    if (title.Contains("*"))
                                    {
                                        // lblComment.Visible = true;
                                        if (item["Comment"] != null)
                                        {
                                            Label lblTextComment = new Label();
                                            lblTextComment.Text = "*" + item["Comment"].ToString();
                                            pnlComment.Controls.Add(lblTextComment);
                                        }
                                        //lblComment.Text = item["Comment"].ToString();
                                    }
                                    string HDate = item["HolidayDate"].ToString();
                                    DateTime dt = DateTime.Parse(HDate);
                                    string HdateName = String.Format("{0:MMMM d, yyyy}", dt);
                                    string HolidayMonth = String.Format("{0:MMMM}", dt);
                                    int MonthNumber = Convert.ToInt32(dt.Month.ToString());
                                    string HolidayDay = String.Format("{0:dddd}", dt);
                                    // count += 1;
                                    //row["SNo"] = count.ToString();
                                    row["Month"] = HolidayMonth.ToString();
                                    row["Day"] = HolidayDay.ToString();
                                    row["HolidayDate"] = HdateName.ToString();
                                    row["HolidayName"] = title.ToString();
                                    row["MonthNum"] = MonthNumber;
                                    dtHoliday.Rows.Add(row);

                                }
                            }
                            else
                            {
                                //lblUSA.Visible = true;
                                //lblUSA.Text = "No Archives";
                            }

                            if (dtHoliday.Rows.Count > 0)
                            {
                                DataView dv = dtHoliday.DefaultView;
                                dv.Sort = "MonthNum";
                                gvHolidays.DataSource = dv;
                                gvHolidays.DataBind();
                            }
                            else
                            {
                                StringBuilder sb = new StringBuilder();

                                sb.Append("<table style='Width:100%;' cellSpacing=0px cellPadding=0px> <tr Class=grid-sub1><td Class=grid-header>S.No</td><td  Class=grid-header>Month</td><td  Class=grid-header>Day</td><td Class=grid-header>Date</td><td Class=grid-header>Holidays</td></tr><tr  Class=grid-sub1><td colspan=5><b>Holidays are not available</b></td></tr></table>");
                                lblPGResult.InnerHtml = sb.ToString();
                            }



                        }
                        else if (Country == "india"  )
                        {
                            lblinidaHeader.Visible = true;
                            if (year !="allyears")
                            {
                                stringQuery = string.Format(@"<Where><And><Eq><FieldRef Name='Country' /><Value Type='Choice'>India</Value></Eq><Eq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>{0}</Value></Eq></And></Where>", year);
                            }
                            else
                            {

                                stringQuery = string.Format(@"<Where><And><Eq><FieldRef Name='Country' /><Value Type='Choice'>India</Value></Eq><Neq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>" + currentYear + "</Value></Neq></And></Where>");
                            }


                            qry.Query = stringQuery;
                            //qry.ViewFields = @"<FieldRef Name='HolidayDate' /><FieldRef Name='Title' /><FieldRef Name='Comment' />";
                            SPListItemCollection listcoll = list.GetItems(qry);
                            DataTable dtHoliday = new DataTable();
                            //dtHoliday.Columns.Add("SNo");
                            dtHoliday.Columns.Add("Month");
                            dtHoliday.Columns.Add("Day");
                            dtHoliday.Columns.Add("HolidayDate");
                            dtHoliday.Columns.Add("HolidayName");
                            dtHoliday.Columns.Add("MonthNum", typeof(int));

                            if (listcoll.Count > 0)
                            {
                                foreach (SPListItem item in listcoll)
                                {
                                    DataRow row = dtHoliday.NewRow();
                                    string title = item["Title"].ToString();
                                    if (title.Contains("*"))
                                    {
                                        // lblComment.Visible = true;
                                        if (item["Comment"] != null)
                                        {
                                            Label lblTextComment = new Label();
                                            lblTextComment.Text = "*" + item["Comment"].ToString();
                                            pnlComment.Controls.Add(lblTextComment);
                                        }
                                        //lblComment.Text = item["Comment"].ToString();
                                    }
                                    string HDate = item["HolidayDate"].ToString();
                                    DateTime dt = DateTime.Parse(HDate);
                                    string HdateName = String.Format("{0:MMMM d, yyyy}", dt);
                                    string HolidayMonth = String.Format("{0:MMMM}", dt);
                                    int MonthNumber = Convert.ToInt32(dt.Month.ToString());
                                    string HolidayDay = String.Format("{0:dddd}", dt);
                                    // count += 1;
                                    //row["SNo"] = count.ToString();
                                    row["Month"] = HolidayMonth.ToString();
                                    row["Day"] = HolidayDay.ToString();
                                    row["HolidayDate"] = HdateName.ToString();
                                    row["HolidayName"] = title.ToString();
                                    row["MonthNum"] = MonthNumber;
                                    dtHoliday.Rows.Add(row);

                                }
                            }
                            else
                            {
                                //lblInd.Visible = true;
                                //lblInd.Text = "No Archives";
                            }

                            if (dtHoliday.Rows.Count > 0)
                            {
                                DataView dv = dtHoliday.DefaultView;
                                dv.Sort = "MonthNum";
                                GridView2.DataSource = dv;
                                GridView2.DataBind();
                            }
                            else
                            {
                                StringBuilder sb = new StringBuilder();

                                sb.Append("<table style='Width:100%;' cellSpacing=0px cellPadding=0px><tr Class=grid-sub1><td Class=grid-header>S.No</td><td  Class=grid-header>Month</td><td  Class=grid-header>Day</td><td Class=grid-header>Date</td><td Class=grid-header>Holidays</td></tr><tr  Class=grid-sub1><td colspan=5><b>Holidays are not available</b></td></tr></table>");
                                lblindresult.InnerHtml = sb.ToString();
                            }



                        }
                        else if (Country == "P&G")
                        {
                            lblpgHeader.Visible = true;
                            // stringQuery = string.Format(@"<Query><Where><And><Eq><FieldRef Name='Country' /><Value Type='Choice'>{0}</Value></Eq><And><Eq><FieldRef Name='IsPGHoliday' /><Value Type='Boolean'>{1}</Value></Eq><Eq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>{2}</Value></Eq></And></And></Where></Query>","USA",true, year);
                            if (year != "allyears")
                            {
                                stringQuery = string.Format(@"<Where><And><Eq><FieldRef Name='Country' /><Value Type='Choice'>USA</Value></Eq><And><Eq><FieldRef Name='IsPGHoliday' /><Value Type='Boolean'>1</Value></Eq><Eq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>{0}</Value></Eq></And></And></Where>", year);
                            }
                            else
                            {
                                stringQuery = string.Format(@"<Where><And><Eq><FieldRef Name='Country' /><Value Type='Choice'>USA</Value></Eq><And><Eq><FieldRef Name='IsPGHoliday' /><Value Type='Boolean'>1</Value></Eq><Neq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>"+currentYear+"</Value></Neq></And></And></Where>");
                            }
                            qry.Query = stringQuery;
                            //qry.ViewFields = @"<FieldRef Name='HolidayDate' /><FieldRef Name='Title' /><FieldRef Name='Comment' />";
                            SPListItemCollection listcoll = list.GetItems(qry);
                            DataTable dtHoliday = new DataTable();
                            //dtHoliday.Columns.Add("SNo");
                            dtHoliday.Columns.Add("Month");
                            dtHoliday.Columns.Add("Day");
                            dtHoliday.Columns.Add("HolidayDate");
                            dtHoliday.Columns.Add("HolidayName");
                            dtHoliday.Columns.Add("MonthNum", typeof(int));

                            if (listcoll.Count > 0)
                            {
                                foreach (SPListItem item in listcoll)
                                {
                                    DataRow row = dtHoliday.NewRow();
                                    string title = item["Title"].ToString();
                                    if (title.Contains("*"))
                                    {
                                        // lblComment.Visible = true;
                                        if (item["Comment"] != null)
                                        {
                                            Label lblTextComment = new Label();
                                            lblTextComment.Text = "*" + item["Comment"].ToString();
                                            pnlComment.Controls.Add(lblTextComment);
                                        }
                                        //lblComment.Text = item["Comment"].ToString();
                                    }
                                    string HDate = item["HolidayDate"].ToString();
                                    DateTime dt = DateTime.Parse(HDate);
                                    string HdateName = String.Format("{0:MMMM d, yyyy}", dt);
                                    string HolidayMonth = String.Format("{0:MMMM}", dt);
                                    int MonthNumber = Convert.ToInt32(dt.Month.ToString());
                                    string HolidayDay = String.Format("{0:dddd}", dt);
                                    // count += 1;
                                    //row["SNo"] = count.ToString();
                                    row["Month"] = HolidayMonth.ToString();
                                    row["Day"] = HolidayDay.ToString();
                                    row["HolidayDate"] = HdateName.ToString();
                                    row["HolidayName"] = title.ToString();
                                    row["MonthNum"] = MonthNumber;
                                    dtHoliday.Rows.Add(row);

                                }
                            }
                            else
                            {
                                //lblpg.Visible = true;
                                //lblpg.Text = "No Archives";
                            }

                            if (dtHoliday.Rows.Count > 0)
                            {
                                DataView dv = dtHoliday.DefaultView;
                                dv.Sort = "MonthNum";
                                GridView1.DataSource = dv;
                                GridView1.DataBind();
                            }
                            else
                            {
                                StringBuilder sb = new StringBuilder();

                                sb.Append("<table style='Width:100%' cellSpacing=0px cellPadding=0px ><tr Class=grid-sub1><td Class=grid-header>S.No</td><td  Class=grid-header>Month</td><td  Class=grid-header>Day</td><td Class=grid-header>Date</td><td Class=grid-header>Holidays</td></tr><tr  Class=grid-sub1><td colspan=5><b>Holidays are not available</b></td></tr></table>");
                                lblusaResult.InnerHtml = sb.ToString();
                            }



                        }
                        else if (year == "allyears")
                        {
                            GetHolidays("allyears", true, "usa");
                            GetHolidays("allyears", true, "india");
                            GetHolidays("allyears", true, "P&G");



                        }
                    }
                }
            }
        }
    }
}
