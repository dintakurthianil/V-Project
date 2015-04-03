using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace VrtxIntranetHrApproval
{
    public class CommnonMethod
    {
        SPList list = null;
        SPListItemCollection itemCollection = null;
        SPListItem itemadd = null;
        string URL = SPContext.Current.Web.Url;
        Constants ct = new Constants();
        public String  GetGridviewColumnData(GridViewRow row, string columnName)
        {
            Label lblCol = row.FindControl(columnName) as Label;
            
            if (lblCol != null)
            {
                ct.colValue = lblCol.Text;
                return ct.colValue;
            }
            else
            {
                ct.colValue = string.Empty;
                return ct.colValue;
            }
        }

        public SPListItemCollection GetHRApproveListitemCollection(SPList lst)
        {
            //list = GetList(lst);
            if (lst != null)
            {
                SPQuery qry = new SPQuery();
                string stringQuery = string.Format(@"<Where><Eq><FieldRef Name='IsApprove' /><Value Type='Text'>NO</Value></Eq></Where>");
                qry.Query = stringQuery;
                itemCollection = lst.GetItems(qry);
            }

            return itemCollection;
        }

        public SPListItemCollection GetListCollection(SPList lst, string queery)
        {
            //list = GetList(lst);
            if (lst != null)
            {
                SPQuery qry = new SPQuery();
                string stringQuery = queery;
                qry.Query = stringQuery;
                itemCollection = lst.GetItems(qry);
            }

            return itemCollection;
        }

        public List<string> Getusercollection(SPList lst, string query)
        {
            itemCollection = GetListCollection(lst, query);
            List<string> strlist = new List<string>();
            foreach (SPListItem item in itemCollection)
            {
                strlist.Add(item["UserName"] != null ? item["UserName"].ToString() : string.Empty);
                string strVal = string.Join(",", strlist.ToArray());
            }
            List<string> result = (from m in strlist select m).Distinct().ToList();//it  is used to remove duplicates
            return result;
        }

        public SPList GetList(SPList lst)
        {
            using (SPSite site = new SPSite(URL))
            {
                using (SPWeb web = site.OpenWeb())
                {
                    if (lst != null)
                    {
                        return list;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
        }

       

       

        public SPListItem InsertItem(SPList lst)
        {
            
            itemadd = lst.Items.Add();
            if (lst != null)
            {
                return itemadd;
            }
            else
            {
                return null;
            }

        }

    }
}
