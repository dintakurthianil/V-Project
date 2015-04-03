using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Linq;
using System.Web;
using System.IO;

namespace VrtxIntranetHrApproval.HrApprovalEmpCertification
{
    [ToolboxItemAttribute(false)]
    public partial class HrApprovalEmpCertification : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public HrApprovalEmpCertification()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }
        CommnonMethod cm = new CommnonMethod();
        Constants ct = new Constants();
        SPListItemCollection empCertificationCol = null;
        SPListItemCollection fisicalyearcoll;
        SPListItemCollection listcoll = null;
        SPListItemCollection tempEmpCerificationcoll = null;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetTempEmpCertifications();
            }
        }

        public void GetTempEmpCertifications()
        {
            listcoll = cm.GetHRApproveListitemCollection(ct.lstTempEmpCerifications);
            GvCertifications.DataSource = listcoll.GetDataTable();
            GvCertifications.DataBind();
        }



        protected void btnApprove_Click(object sender, EventArgs e)
        {
            
            empCertificationCol = cm.GetListCollection(ct.lstEmpCertifications, "<Where><Eq><FieldRef Name='FiscalYear' /><Value Type='Lookup'>" + ct.Currentyear + "</Value></Eq></Where>");
            fisicalyearcoll = cm.GetListCollection(ct.lstFiscalYear, "<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>" + ct.Currentyear + "</Value></Eq></Where>");
            List<SPListItem> lstempCertificationCol = empCertificationCol.OfType<SPListItem>().ToList();
            foreach (GridViewRow gvrow in GvCertifications.Rows)
            {
                if (gvrow.RowType == DataControlRowType.DataRow)
                {
                    CheckBox box = (CheckBox)gvrow.FindControl("chkEmpCertificationsSelect");
                    if (((box != null) & box.Checked) && (cm.GetGridviewColumnData(gvrow, "lblUserName") != null))
                    {
                        //lblValue.Text = "";
                        lblValue.Text = lblValue.Text + cm.GetGridviewColumnData(gvrow, "lblUserName") + ",";
                        ct.chkselectedUserNmae = cm.GetGridviewColumnData(gvrow, "lblUserName");
                        ct.chkCertificationID = cm.GetGridviewColumnData(gvrow, "lblCertificationID");
                        ct.chkTechnology = cm.GetGridviewColumnData(gvrow, "lblTechnology");
                        tempEmpCerificationcoll = cm.GetListCollection(ct.lstTempEmpCerifications, "<Where><And><Eq><FieldRef Name='UserName' /><Value Type='Text'>" + ct.chkselectedUserNmae + "</Value></Eq><Eq><FieldRef Name='IsApprove' /><Value Type='Text'>NO</Value></Eq></And></Where>");
                        List<SPListItem> lsttempEmpCerificationcoll = tempEmpCerificationcoll.OfType<SPListItem>().ToList<SPListItem>();
                        if (tempEmpCerificationcoll != null)
                        {
                            if (empCertificationCol != null && empCertificationCol.Count>0)
                            {
                                foreach (SPListItem empCertificationitem in empCertificationCol)
                                {
                                    if (lstempCertificationCol.Exists(x => x["UserName"].ToString() == ct.chkselectedUserNmae))
                                    {
                                        if (lstempCertificationCol.Exists(x => x["CertificationID"].ToString() == ct.chkCertificationID))
                                        {
                                            foreach (SPListItem tempEmpCerificationitem in tempEmpCerificationcoll)
                                            {
                                                if ((ct.chkselectedUserNmae == tempEmpCerificationitem["UserName"].ToString()) && ct.chkCertificationID == tempEmpCerificationitem["CertificationID"].ToString())
                                                {
                                                    ct.UserName = tempEmpCerificationitem["UserName"].ToString();
                                                    ct.Certificate = tempEmpCerificationitem["Certificate"].ToString();
                                                    ct.Technology = tempEmpCerificationitem["Technology"].ToString();
                                                    if (tempEmpCerificationitem["CertificationID"] != null)
                                                    {
                                                        ct.CertificationID = tempEmpCerificationitem["CertificationID"].ToString();
                                                    }
                                                    if (tempEmpCerificationitem["CertifiedDate"] != null)
                                                    {
                                                        ct.CertifiedDate = tempEmpCerificationitem["CertifiedDate"].ToString();
                                                    }
                                                    if (tempEmpCerificationitem["UntilDate"] != null)
                                                    {
                                                        ct.UntilDate = tempEmpCerificationitem["UntilDate"].ToString();
                                                    }
                                                    foreach (String attachmentname in tempEmpCerificationitem.Attachments)
                                                    {
                                                        ct.TemAttachmentName = attachmentname;
                                                        String attachmentAbsoluteURLs = tempEmpCerificationitem.Attachments.UrlPrefix + attachmentname; // gets the containing directory URL
                                                        // To get the SPSile reference to the attachment just use this code
                                                        SPFile attachmentFile = ct.oweb.GetFile(attachmentAbsoluteURLs);
                                                        // To read the file content simply use this code
                                                        ct.stream= attachmentFile.OpenBinaryStream();
                                                        StreamReader reader = new StreamReader(ct.stream);
                                                        String fileContent = reader.ReadToEnd();
                                                        ct.Attachment = attachmentAbsoluteURLs.ToString();
                                                    }
                                                    tempEmpCerificationitem["IsApprove"] = Constants.IsApprove;
                                                    tempEmpCerificationitem.Update();
                                                }
                                            }
                                            if ((ct.chkselectedUserNmae == empCertificationitem["UserName"].ToString()) && ct.chkCertificationID == empCertificationitem["CertificationID"].ToString())
                                            {
                                                empCertificationitem["Certificate"] = ct.Certificate.ToString();
                                                empCertificationitem["Technology"] = ct.Technology.ToString();
                                                if (!string.IsNullOrEmpty(ct.CertificationID))
                                                {
                                                    empCertificationitem["CertificationID"] = ct.CertificationID.ToString();
                                                }
                                                if (!string.IsNullOrEmpty(ct.CertifiedDate))
                                                {
                                                    empCertificationitem["CertifiedDate"] = Convert.ToDateTime(ct.CertifiedDate);
                                                }
                                                if (!string.IsNullOrEmpty(ct.UntilDate))
                                                {
                                                    empCertificationitem["UntilDate"] = Convert.ToDateTime(ct.UntilDate);
                                                }
                                                if (empCertificationitem.Attachments.Count > 0)
                                                {
                                                    if (ct.Attachment != null)
                                                    {
                                                        ct.DocumentName = ct.Attachment.ToString();
                                                        byte[] contents = GetFileStream();
                                                        if ((ct.DocumentName != null) && (contents.Length > 0))
                                                        {
                                                            SPAttachmentCollection fileAttach = empCertificationitem.Attachments;
                                                            if (ct.TemAttachmentName == System.IO.Path.GetFileName(ct.DocumentName))
                                                            {
                                                                empCertificationitem.Attachments.Delete(System.IO.Path.GetFileName(ct.DocumentName));
                                                                fileAttach.Add(ct.DocumentName, contents);
                                                            }
                                                            else
                                                            {
                                                                fileAttach.Add(ct.DocumentName, contents);
                                                            }
                                                        }
                                                    }
                                                }
                                                foreach (SPListItem items in fisicalyearcoll)
                                                {
                                                    SPListItem lookupFY = ct.lstFiscalYear.GetItemById(items.ID);
                                                    empCertificationitem["FiscalYear"] = new SPFieldLookupValue(lookupFY.ID, lookupFY.Title);
                                                }
                                                empCertificationitem.Update();
                                            }
                                        }// if user is anil but he is uploading new certificate
                                        else
                                        {
                                            foreach (SPListItem tempEmpCerificationitem in tempEmpCerificationcoll)
                                            {
                                                if ((ct.chkselectedUserNmae == tempEmpCerificationitem["UserName"].ToString()) && ct.chkCertificationID == tempEmpCerificationitem["CertificationID"].ToString())
                                                {
                                                    ct.UserName = tempEmpCerificationitem["UserName"].ToString();
                                                    ct.Certificate = tempEmpCerificationitem["Certificate"].ToString();
                                                    ct.Technology = tempEmpCerificationitem["Technology"].ToString();
                                                    if (tempEmpCerificationitem["CertificationID"] != null)
                                                    {
                                                        ct.CertificationID = tempEmpCerificationitem["CertificationID"].ToString();
                                                    }
                                                    if (tempEmpCerificationitem["CertifiedDate"] != null)
                                                    {
                                                        ct.CertifiedDate = tempEmpCerificationitem["CertifiedDate"].ToString();
                                                    }
                                                    if (tempEmpCerificationitem["UntilDate"] != null)
                                                    {
                                                        ct.UntilDate = tempEmpCerificationitem["UntilDate"].ToString();
                                                    }
                                                    foreach (String attachmentname in tempEmpCerificationitem.Attachments)
                                                    {
                                                        String attachmentAbsoluteURLs = tempEmpCerificationitem.Attachments.UrlPrefix + attachmentname; // gets the containing directory URL
                                                        // To get the SPSile reference to the attachment just use this code
                                                        SPFile attachmentFile = ct.oweb.GetFile(attachmentAbsoluteURLs);
                                                        // To read the file content simply use this code
                                                        ct.stream = attachmentFile.OpenBinaryStream();
                                                        StreamReader reader = new StreamReader(ct.stream);
                                                        String fileContent = reader.ReadToEnd();
                                                        ct.Attachment = attachmentAbsoluteURLs.ToString();
                                                    }
                                                    tempEmpCerificationitem["IsApprove"] = Constants.IsApprove;
                                                    tempEmpCerificationitem.Update();
                                                }
                                            }
                                            insertItem();
                                            break;
                                        }
                                    }//if user Dosenot exit int Temp list so it will insert
                                    else
                                    {
                                        readTempData();
                                        insertItem();
                                        break;
                                    }

                                }

                            }//it is for the very fist time intial request
                            else
                            {
                                readTempData();
                                insertItem();
                                break;
                            }
                        }
                    }
                }
            }
            GetTempEmpCertifications();
            //if (lblValue.Text.EndsWith(","))
            //{
            //    lblValue.Text = lblValue.Text.Remove(lblValue.Text.Length - 1) + " ApprovedSuccessfully";
            //}
        }



        

        private void insertItem()
        {
            fisicalyearcoll = cm.GetListCollection(ct.lstFiscalYear, "<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>" + ct.Currentyear + "</Value></Eq></Where>");
            SPListItem EmpCertificationitem = cm.InsertItem(ct.lstEmpCertifications);
            ct.oweb.AllowUnsafeUpdates = true;
            EmpCertificationitem["UserName"] = ct.chkselectedUserNmae;
            EmpCertificationitem["Certificate"] = ct.Certificate.ToString();
            EmpCertificationitem["Technology"] = ct.Technology.ToString();
            if(!string.IsNullOrEmpty(ct.CertificationID) ) 
            {
                EmpCertificationitem["CertificationID"] = ct.CertificationID.ToString();
            }
            if (!string.IsNullOrEmpty(ct.CertifiedDate) )
            {
                EmpCertificationitem["CertifiedDate"] = Convert.ToDateTime(ct.CertifiedDate);
            }
            if (!string.IsNullOrEmpty(ct.UntilDate) )
            {
                EmpCertificationitem["UntilDate"] = Convert.ToDateTime(ct.UntilDate);
            }
            if (!string.IsNullOrEmpty(ct.Attachment) )
            {
                ct.DocumentName = ct.Attachment.ToString();
                byte[] contents = GetFileStream();
                if (!string.IsNullOrEmpty((ct.DocumentName )) && (contents.Length > 0))
                {
                    SPAttachmentCollection fileAttach = EmpCertificationitem.Attachments;
                    fileAttach.Add(ct.DocumentName, contents);
                }
            }
            foreach (SPListItem items in fisicalyearcoll)
            {
                SPListItem lookupFY = ct.lstFiscalYear.GetItemById(items.ID);
                EmpCertificationitem["FiscalYear"] = new SPFieldLookupValue(lookupFY.ID, lookupFY.Title);
            }

            EmpCertificationitem.Update();
            ct.oweb.AllowUnsafeUpdates = false;
        }

        public byte[] GetFileStream()
        {
            Stream fStream = ct.stream;
            byte[] contents = new byte[fStream.Length];
            fStream.Read(contents, 0, (int)fStream.Length);
            fStream.Close();
            return contents;
        }
        private void readTempData()
        {
            tempEmpCerificationcoll = cm.GetListCollection(ct.lstTempEmpCerifications, "<Where><And><Eq><FieldRef Name='UserName' /><Value Type='Text'>" + ct.chkselectedUserNmae + "</Value></Eq><Eq><FieldRef Name='IsApprove' /><Value Type='Text'>NO</Value></Eq></And></Where>");
            foreach (SPListItem tempEmpCerificationitem in tempEmpCerificationcoll)
            {
                if (ct.chkselectedUserNmae == tempEmpCerificationitem["UserName"].ToString())
                {
                    ct.UserName = tempEmpCerificationitem["UserName"].ToString();
                    ct.Certificate = tempEmpCerificationitem["Certificate"].ToString();
                    ct.Technology = tempEmpCerificationitem["Technology"].ToString();
                    if (tempEmpCerificationitem["CertificationID"] != null)
                    {
                        ct.CertificationID = tempEmpCerificationitem["CertificationID"].ToString();
                    }
                    if (tempEmpCerificationitem["CertifiedDate"] != null)
                    {
                        ct.CertifiedDate = tempEmpCerificationitem["CertifiedDate"].ToString();
                    }
                    if (tempEmpCerificationitem["UntilDate"] != null)
                    {
                        ct.UntilDate = tempEmpCerificationitem["UntilDate"].ToString();
                    }
                    foreach (String attachmentname in tempEmpCerificationitem.Attachments)
                    {
                        String attachmentAbsoluteURLs = tempEmpCerificationitem.Attachments.UrlPrefix + attachmentname; // gets the containing directory URL
                        // To get the SPSile reference to the attachment just use this code
                        SPFile attachmentFile = ct.oweb.GetFile(attachmentAbsoluteURLs);
                        // To read the file content simply use this code
                        ct.stream = attachmentFile.OpenBinaryStream();
                        StreamReader reader = new StreamReader(ct.stream);
                        String fileContent = reader.ReadToEnd();
                        ct.Attachment = attachmentAbsoluteURLs.ToString();
                    }
                    tempEmpCerificationitem["IsApprove"] = Constants.IsApprove;
                    tempEmpCerificationitem.Update();
                }
            }
        }
    }
}
