using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrtxIntranetHrApproval
{
    class CommnonMethods
    {
        SPListItemCollection itemCollection;
        public SPListItemCollection GetListitemCollection(string lst)
        {

            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {

                using (SPWeb web = site.OpenWeb())
                {
                    SPList list = web.Lists.TryGetList(lst);
                    if (list != null)
                    {
                        SPQuery qry = new SPQuery();
                        string stringQuery = string.Format(@"<Where><Eq><FieldRef Name='IsApprove' /><Value Type='Text'>Yes</Value></Eq></Where>");
                        qry.Query = stringQuery;
                        itemCollection = list.GetItems(qry);
                    }
                }
            }
            return itemCollection;
        }
    }
}
