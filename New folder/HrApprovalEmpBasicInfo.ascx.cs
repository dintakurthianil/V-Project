using Microsoft.SharePoint;
using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace VrtxIntranetHrApproval.HrApprovalEmpBasicInfo
{
    [ToolboxItemAttribute(false)]
    public partial class HrApprovalEmpBasicInfo : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public HrApprovalEmpBasicInfo()
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
        SPListItemCollection tempEmpBasicInfocoll = null;
        SPListItemCollection empBasicInfocoll = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetTempEmpBasicInfo();
            }
        }
        public void GetTempEmpBasicInfo()
        {

            listcoll = cm.GetHRApproveListitemCollection(ct.lstTempEmpBasicInfo);

            GvEmpBasicInfo.DataSource = listcoll.GetDataTable();
            GvEmpBasicInfo.DataBind();

        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            
            tempEmpBasicInfocoll = cm.GetListCollection(ct.lstTempEmpBasicInfo, "<Where><Eq><FieldRef Name='IsApprove' /><Value Type='Text'>NO</Value></Eq></Where>");
            empBasicInfocoll = cm.GetListCollection(ct.lstEmpBasicInfo, "<Where><Eq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>" + ct.Currentyear + "</Value></Eq></Where>");
            List<SPListItem> lsttempEmpBasicInfocoll = tempEmpBasicInfocoll.OfType<SPListItem>().ToList();
            List<SPListItem> lstempBasicInfocoll = empBasicInfocoll.OfType<SPListItem>().ToList();

            SPList lstFisicalyear = SPContext.Current.Web.Lists.TryGetList("FiscalYear");
            SPQuery qry = new SPQuery();
            string stringQuery = "";
            stringQuery = string.Format(@"<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>{0}</Value></Eq></Where>", ct.Currentyear);
            qry.Query = stringQuery;
            SPListItemCollection collection = lstFisicalyear.GetItems(qry);

            foreach (GridViewRow gvrow in GvEmpBasicInfo.Rows)
            {
                if (gvrow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox chk = (CheckBox)gvrow.FindControl("chkEmpBasicSelect");
                    if (chk != null & chk.Checked)
                    {
                        if (cm.GetGridviewColumnData(gvrow, "lblUserName") != null)
                        {
                            //lblValue.Text = Constants.emptyvalue;
                            lblValue.Text += ct.colValue + Constants.commaValue;
                            ct.chkselectedUserNmae = cm.GetGridviewColumnData(gvrow, "lblUserName");
                            if (tempEmpBasicInfocoll != null && empBasicInfocoll != null)
                            {
                                foreach (SPListItem empBasicinfoitem in empBasicInfocoll)
                                {
                                    if (lstempBasicInfocoll.Exists(x => x["Title"].ToString() == ct.chkselectedUserNmae))
                                    {

                                        foreach (SPListItem tempEMpBasicinfoItem in tempEmpBasicInfocoll)
                                        {
                                            if (ct.chkselectedUserNmae == tempEMpBasicinfoItem["Title"].ToString())
                                            {
                                                ct.Designation = tempEMpBasicinfoItem["Designation"].ToString();
                                                ct.Department = tempEMpBasicinfoItem["Department"].ToString();
                                                ct.DOB = tempEMpBasicinfoItem["DOB"].ToString();
                                                ct.EmpID = tempEMpBasicinfoItem["EmpID"].ToString();
                                                ct.ExtensionNumber = tempEMpBasicinfoItem["ExtensionNumber"].ToString();
                                                ct.FirstName = tempEMpBasicinfoItem["First_x0020_Name"].ToString();
                                                ct.Gender = tempEMpBasicinfoItem["Gender"].ToString();
                                                ct.ICQNumber = tempEMpBasicinfoItem["ICQNumber"].ToString();
                                                ct.LastName = tempEMpBasicinfoItem["Last_x0020_Name"].ToString();
                                                ct.MobileNumber = tempEMpBasicinfoItem["MobileNumber"].ToString();
                                                ct.ProfileTag = tempEMpBasicinfoItem["ProfileTag"].ToString();
                                                ct.ResidencePhoneNumber = tempEMpBasicinfoItem["ResidencePhoneNumber"].ToString();
                                                ct.VertexEmailID = tempEMpBasicinfoItem["VertexEmailID"].ToString();
                                                tempEMpBasicinfoItem["IsApprove"] = Constants.IsApprove;
                                                tempEMpBasicinfoItem.Update();
                                            }
                                        }
                                        if (ct.chkselectedUserNmae == empBasicinfoitem["Title"].ToString())
                                        {
                                            empBasicinfoitem["Designation"] = new SPFieldLookupValue(ct.Designation.ToString());
                                            empBasicinfoitem["Department"] = new SPFieldLookupValue(ct.Department.ToString());
                                            empBasicinfoitem["DOB"] = ct.DOB.ToString();
                                            empBasicinfoitem["EmpID"] = ct.EmpID.ToString();
                                            if (ct.ExtensionNumber != null)
                                                empBasicinfoitem["ExtensionNumber"] = ct.ExtensionNumber.ToString();
                                            empBasicinfoitem["First_x0020_Name"] = ct.FirstName.ToString();
                                            empBasicinfoitem["Gender"] = new SPFieldLookupValue(ct.Gender.ToString());
                                            if (ct.ICQNumber != null)
                                                empBasicinfoitem["ICQNumber"] = ct.ICQNumber.ToString();
                                            empBasicinfoitem["Last_x0020_Name"] = ct.LastName.ToString();
                                            if (ct.MobileNumber != null)
                                                empBasicinfoitem["MobileNumber"] = ct.MobileNumber.ToString();
                                            empBasicinfoitem["ProfileTag"] = new SPFieldLookupValue(ct.ProfileTag.ToString());
                                            if (ct.ResidencePhoneNumber != null)
                                                empBasicinfoitem["ResidencePhoneNumber"] = ct.ResidencePhoneNumber.ToString();
                                            empBasicinfoitem["VertexEmailID"] = ct.VertexEmailID.ToString();
                                            foreach (SPListItem items in collection)
                                            {
                                                SPListItem lookupFY = lstFisicalyear.GetItemById(items.ID);
                                                empBasicinfoitem["FiscalYear"] = new SPFieldLookupValue(lookupFY.ID, lookupFY.Title);
                                            }
                                            empBasicinfoitem.Update();
                                        }
                                    }
                                    else
                                    {
                                        foreach (SPListItem tempEMpBasicinfoItem in tempEmpBasicInfocoll)
                                        {
                                            if (ct.chkselectedUserNmae == tempEMpBasicinfoItem["Title"].ToString())
                                            {
                                                ct.Designation = tempEMpBasicinfoItem["Designation"].ToString();
                                                ct.Department = tempEMpBasicinfoItem["Department"].ToString();
                                                ct.DOB = tempEMpBasicinfoItem["DOB"].ToString();
                                                ct.EmpID = tempEMpBasicinfoItem["EmpID"].ToString();
                                                ct.ExtensionNumber = tempEMpBasicinfoItem["ExtensionNumber"].ToString();
                                                ct.FirstName = tempEMpBasicinfoItem["First_x0020_Name"].ToString();
                                                ct.Gender = tempEMpBasicinfoItem["Gender"].ToString();
                                                ct.ICQNumber = tempEMpBasicinfoItem["ICQNumber"].ToString();
                                                ct.LastName = tempEMpBasicinfoItem["Last_x0020_Name"].ToString();
                                                ct.MobileNumber = tempEMpBasicinfoItem["MobileNumber"].ToString();
                                                ct.ProfileTag = tempEMpBasicinfoItem["ProfileTag"].ToString();
                                                ct.ResidencePhoneNumber = tempEMpBasicinfoItem["ResidencePhoneNumber"].ToString();
                                                ct.VertexEmailID = tempEMpBasicinfoItem["VertexEmailID"].ToString();
                                                tempEMpBasicinfoItem["IsApprove"] = Constants.IsApprove;
                                                tempEMpBasicinfoItem.Update();
                                            }
                                        }
                                        using (SPSite oSPsite = new SPSite(SPContext.Current.Web.Url))
                                        {
                                            using (SPWeb oSPWeb = oSPsite.OpenWeb())
                                            {
                                                oSPWeb.AllowUnsafeUpdates = true;
                                                SPList list = oSPWeb.Lists["EmpBasicInfo"];
                                                SPListItem itemadd = list.Items.Add();
                                                itemadd["Title"] = ct.chkselectedUserNmae;
                                                itemadd["Designation"] = ct.Designation.ToString();
                                                itemadd["Department"] = ct.Department.ToString();
                                                itemadd["DOB"] = Convert.ToDateTime(ct.DOB);
                                                itemadd["EmpID"] = ct.EmpID.ToString();
                                                itemadd["ExtensionNumber"] = ct.ExtensionNumber.ToString();
                                                itemadd["First_x0020_Name"] = ct.FirstName.ToString();
                                                itemadd["Gender"] = ct.Gender.ToString();
                                                itemadd["ICQNumber"] = ct.ICQNumber.ToString();
                                                itemadd["Last_x0020_Name"] = ct.LastName.ToString();
                                                itemadd["MobileNumber"] = ct.MobileNumber.ToString();
                                                itemadd["ProfileTag"] = ct.ProfileTag.ToString();
                                                itemadd["ResidencePhoneNumber"] = ct.ResidencePhoneNumber.ToString();
                                                itemadd["VertexEmailID"] = ct.VertexEmailID.ToString();
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
            GetTempEmpBasicInfo();
            //if (lblValue.Text.EndsWith(Constants.commaValue))
            //{
            //    lblValue.Text = lblValue.Text.Remove(lblValue.Text.Length - 1) + Constants.ApprovedSuccessfully;
            //}
        }
    }
}
