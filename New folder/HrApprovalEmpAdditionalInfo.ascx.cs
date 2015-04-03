using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Linq;
using System.Collections.Generic;
using System.Web.UI.WebControls;


namespace VrtxIntranetHrApproval.HrApprovalEmpAdditionalInfo
{
    [ToolboxItemAttribute(false)]
    public partial class HrApprovalEmpAdditionalInfo : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public HrApprovalEmpAdditionalInfo()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }
        CommnonMethod cm = new CommnonMethod();
        Constants ct = new Constants();
        SPListItemCollection listcoll = null;
        SPListItemCollection tempEmpAdditionalcoll = null;
        SPListItemCollection empAdditionalcoll = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetTempEmpAdditional();
            }

        }
        public void GetTempEmpAdditional()
        {

            listcoll = cm.GetHRApproveListitemCollection(ct.lstTempEmpAdditionalInfo);

            GvEmpAdditionalInfo.DataSource = listcoll.GetDataTable();
            GvEmpAdditionalInfo.DataBind();

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            
            tempEmpAdditionalcoll = cm.GetListCollection(ct.lstTempEmpAdditionalInfo, Constants.tempQuerry);
            empAdditionalcoll = cm.GetListCollection(ct.lstEmpAdditionalDetails, "<Where><Eq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>" + ct.Currentyear + "</Value></Eq></Where>");
            List<SPListItem> lstTempAdditionalcoll = tempEmpAdditionalcoll.OfType<SPListItem>().ToList();
            List<SPListItem> lstEmpAdditionalcoll = empAdditionalcoll.OfType<SPListItem>().ToList();

            SPList lstFisicalyear = SPContext.Current.Web.Lists.TryGetList("FiscalYear");
            SPQuery qry = new SPQuery();
            string stringQuery = "";
            stringQuery = string.Format(@"<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>{0}</Value></Eq></Where>", ct.Currentyear);
            qry.Query = stringQuery;
            SPListItemCollection collection = lstFisicalyear.GetItems(qry);

            foreach (GridViewRow gvrow in GvEmpAdditionalInfo.Rows)
            {
                if (gvrow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkEmpAdditionalSelect");
                    if (chk != null & chk.Checked)
                    {
                        if (cm.GetGridviewColumnData(gvrow, "lblUserName") != null)
                        {
                            //lblValue.Text = Constants.emptyvalue;
                            lblValue.Text += ct.colValue + Constants.commaValue;
                            ct.chkselectedUserNmae = cm.GetGridviewColumnData(gvrow, "lblUserName");
                            if (tempEmpAdditionalcoll != null && empAdditionalcoll != null)
                            {
                                foreach (SPListItem empAdditionalitem in empAdditionalcoll)
                                {
                                    if (lstEmpAdditionalcoll.Exists(x => x["UserName"].ToString() == ct.chkselectedUserNmae))
                                    {

                                        foreach (SPListItem tempEMpAdditionalItem in tempEmpAdditionalcoll)
                                        {
                                            if (ct.chkselectedUserNmae == tempEMpAdditionalItem["UserName"].ToString())
                                            {
                                                ct.UserName = tempEMpAdditionalItem["UserName"].ToString();
                                                ct.AboutSpouse = tempEMpAdditionalItem["AboutSpouse"].ToString();
                                                ct.BestBook = tempEMpAdditionalItem["Best_x0020_Book"].ToString();
                                                ct.BestRestaurant = tempEMpAdditionalItem["BestRestaurant"].ToString();
                                                ct.ChangeAnythingAboutWorld = tempEMpAdditionalItem["ChangeAnythingAboutWorld"].ToString();
                                                ct.FavoriteFoods = tempEMpAdditionalItem["FavoriteFoods"].ToString();
                                                ct.FavoriteMusic = tempEMpAdditionalItem["FavoriteMusic"].ToString();
                                                ct.FavoriteTV = tempEMpAdditionalItem["FavoriteTV"].ToString();
                                                ct.FollowSports = tempEMpAdditionalItem["FollowSports"].ToString();
                                                ct.FortSkillset = tempEMpAdditionalItem["Forte_x0028_Skill_x0020_set_x002"].ToString();
                                                ct.Inspiredme = tempEMpAdditionalItem["Inspiredme"].ToString();
                                                ct.InterestingThing = tempEMpAdditionalItem["InterestingThing"].ToString();
                                                ct.LazyAfternoon = tempEMpAdditionalItem["LazyAfternoon"].ToString();
                                                ct.loveaboutjobs = tempEMpAdditionalItem["loveaboutjobs"].ToString();
                                                ct.Makesmetick = tempEMpAdditionalItem["Makesmetick"].ToString();
                                                ct.MostProudof = tempEMpAdditionalItem["MostProudof"].ToString();
                                                ct.MyHobbies = tempEMpAdditionalItem["MyHobbies"].ToString();
                                                ct.Overview = tempEMpAdditionalItem["Overview"].ToString();
                                                tempEMpAdditionalItem["IsApprove"] = Constants.IsApprove;
                                                tempEMpAdditionalItem.Update();
                                            }
                                        }
                                        if (ct.chkselectedUserNmae == empAdditionalitem["UserName"].ToString())
                                        {
                                            empAdditionalitem["AboutSpouse"] = ct.AboutSpouse.ToString();
                                            empAdditionalitem["Best_x0020_Book"] = ct.BestBook.ToString();
                                            empAdditionalitem["BestRestaurant"] = ct.BestRestaurant.ToString();
                                            empAdditionalitem["ChangeAnythingAboutWorld"] = ct.ChangeAnythingAboutWorld.ToString();
                                            empAdditionalitem["FavoriteFoods"] = ct.FavoriteFoods.ToString();
                                            empAdditionalitem["FavoriteMusic"] = ct.FavoriteMusic.ToString();
                                            empAdditionalitem["FavoriteTV"] = ct.FavoriteTV.ToString();
                                            empAdditionalitem["FollowSports"] = ct.FollowSports.ToString();
                                            if (!string.IsNullOrEmpty(ct.FortSkillset))
                                            {
                                                empAdditionalitem["Forte_x0028_Skill_x0020_set_x002"] = ct.FortSkillset.ToString();
                                            }
                                            empAdditionalitem["Inspiredme"] = ct.Inspiredme.ToString();
                                            empAdditionalitem["InterestingThing"] = ct.InterestingThing.ToString();
                                            empAdditionalitem["LazyAfternoon"] = ct.LazyAfternoon.ToString();
                                            empAdditionalitem["loveaboutjobs"] = ct.loveaboutjobs.ToString();
                                            empAdditionalitem["Makesmetick"] = ct.Makesmetick.ToString();
                                            empAdditionalitem["MostProudof"] = ct.MostProudof.ToString();
                                            empAdditionalitem["MyHobbies"] = ct.MyHobbies.ToString();
                                            if (!string.IsNullOrEmpty(ct.Overview))
                                            {
                                                empAdditionalitem["Overview"] = ct.Overview.ToString();
                                            }
                                            foreach (SPListItem items in collection)
                                            {
                                                SPListItem lookupFY = lstFisicalyear.GetItemById(items.ID);
                                                empAdditionalitem["FiscalYear"] = new SPFieldLookupValue(lookupFY.ID, lookupFY.Title);
                                            }
                                            empAdditionalitem.Update();
                                        }
                                    }
                                    else
                                    {
                                        foreach (SPListItem tempEMpAdditionalItem in tempEmpAdditionalcoll)
                                        {
                                            if (ct.chkselectedUserNmae == tempEMpAdditionalItem["UserName"].ToString())
                                            {
                                                ct.UserName = tempEMpAdditionalItem["UserName"].ToString();
                                                ct.AboutSpouse = tempEMpAdditionalItem["AboutSpouse"].ToString();
                                                ct.BestBook = tempEMpAdditionalItem["Best_x0020_Book"].ToString();
                                                ct.BestRestaurant = tempEMpAdditionalItem["BestRestaurant"].ToString();
                                                ct.ChangeAnythingAboutWorld = tempEMpAdditionalItem["ChangeAnythingAboutWorld"].ToString();
                                                ct.FavoriteFoods = tempEMpAdditionalItem["FavoriteFoods"].ToString();
                                                ct.FavoriteMusic = tempEMpAdditionalItem["FavoriteMusic"].ToString();
                                                ct.FavoriteTV = tempEMpAdditionalItem["FavoriteTV"].ToString();
                                                ct.FollowSports = tempEMpAdditionalItem["FollowSports"].ToString();
                                                ct.FortSkillset = tempEMpAdditionalItem["Forte_x0028_Skill_x0020_set_x002"].ToString();
                                                ct.Inspiredme = tempEMpAdditionalItem["Inspiredme"].ToString();
                                                ct.InterestingThing = tempEMpAdditionalItem["InterestingThing"].ToString();
                                                ct.LazyAfternoon = tempEMpAdditionalItem["LazyAfternoon"].ToString();
                                                ct.loveaboutjobs = tempEMpAdditionalItem["loveaboutjobs"].ToString();
                                                ct.Makesmetick = tempEMpAdditionalItem["Makesmetick"].ToString();
                                                ct.MostProudof = tempEMpAdditionalItem["MostProudof"].ToString();
                                                ct.MyHobbies = tempEMpAdditionalItem["MyHobbies"].ToString();
                                                ct.Overview = tempEMpAdditionalItem["Overview"].ToString();
                                                tempEMpAdditionalItem["IsApprove"] = Constants.IsApprove;
                                                tempEMpAdditionalItem.Update();
                                            }
                                        }
                                        using (SPSite oSPsite = new SPSite(SPContext.Current.Web.Url))
                                        {
                                            using (SPWeb oSPWeb = oSPsite.OpenWeb())
                                            {
                                                oSPWeb.AllowUnsafeUpdates = true;
                                                SPList list = oSPWeb.Lists["EmpAdditionalDetails"];
                                                SPListItem itemadd = list.Items.Add();
                                                itemadd["UserName"] = ct.chkselectedUserNmae.ToString();
                                                itemadd["AboutSpouse"] = ct.AboutSpouse.ToString();
                                                itemadd["Best_x0020_Book"] = ct.BestBook.ToString();
                                                itemadd["BestRestaurant"] = ct.BestRestaurant.ToString();
                                                itemadd["ChangeAnythingAboutWorld"] = ct.ChangeAnythingAboutWorld.ToString();
                                                itemadd["FavoriteFoods"] = ct.FavoriteFoods.ToString();
                                                itemadd["FavoriteMusic"] = ct.FavoriteMusic.ToString();
                                                itemadd["FavoriteTV"] = ct.FavoriteTV.ToString();
                                                itemadd["FollowSports"] = ct.FollowSports.ToString();
                                                itemadd["Forte_x0028_Skill_x0020_set_x002"] = ct.FortSkillset.ToString();
                                                itemadd["Inspiredme"] = ct.Inspiredme.ToString();
                                                itemadd["InterestingThing"] = ct.InterestingThing.ToString();
                                                itemadd["LazyAfternoon"] = ct.LazyAfternoon.ToString();
                                                itemadd["loveaboutjobs"] = ct.loveaboutjobs.ToString();
                                                itemadd["Makesmetick"] = ct.Makesmetick.ToString();
                                                itemadd["MostProudof"] = ct.MostProudof.ToString();
                                                itemadd["MyHobbies"] = ct.MyHobbies.ToString();
                                                itemadd["Overview"] = ct.Overview.ToString();
                                                foreach (SPListItem items in collection)
                                                {
                                                    SPListItem lookupFY = lstFisicalyear.GetItemById(items.ID);
                                                    itemadd["FiscalYear"] = new SPFieldLookupValue(lookupFY.ID, lookupFY.Title);
                                                }
                                                itemadd.Update();
                                                oSPWeb.AllowUnsafeUpdates = true;
                                                break;
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                }
            }
            GetTempEmpAdditional();
            //if (lblValue.Text.EndsWith(Constants.commaValue))
            //{
            //    lblValue.Text = lblValue.Text.Remove(lblValue.Text.Length - 1) + Constants.ApprovedSuccessfully;
            //}
        }
    }
}
