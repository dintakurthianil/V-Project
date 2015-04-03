using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using System.Data;
using System.IO;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Web;
using Microsoft.SharePoint.Utilities;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Text;
using System.Security.Cryptography;
using System.Linq;


namespace vrtxIntranetSol.EmpHistoryForm
{
    [ToolboxItemAttribute(false)]
    public partial class EmpHistoryForm : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public EmpHistoryForm()
        {
        }
        string FIRSTNAME = "First_x0020_Name";
        string LASTNAME = "Last_x0020_Name";
        string FORTE = "Forte_x0028_Skill_x0020_set_x002";
        string BESTBOOK = "Best_x0020_Book";


        int CurrUserID;
        int CurrUserTempID;
        int CurrAddUserID;
        int CurrAddUserTempID;

        string TempEmpBasicInfo = "TempEmpBasicInfo";
        string TempEmpAdditionalInfo = "TempEmpAdditionalInfo";
        string TempEmpCertifications = "TempEmpCerifications";

        string EmpBasicInfo = "EmpBasicInfo";
        string EmpAdditionalInfo = "EmpAdditionalDetails";
        string EmpCertifications = "EmpCertifications";
        SPQuery qryValues;
        SPListItemCollection listCollFinal;
        string strQueryVal = "";
        DataTable dtValues = new DataTable();
        DataTable dtTempItems = new DataTable();


        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();


        }

        string logedInUser = string.Empty;
        string UserName = HttpContext.Current.Request.QueryString["UserName"];
        CheckBox[] strtech;

        // int lenght1;
        int fileLength;
        String fileName = "";
        //string strDocLibURL = "";
        // string strFilenName;
        //  bool replaceExistingFiles = false;
        bool IsValid = true;

        protected void Page_Load(object sender, EventArgs e)
        {

            hdnAssignUtil.Value = "0";
            if (Page.Request.QueryString["UserName"] != null)
            {
                //ImgUserPic.Visible = true;
                btnSave.Text = "Update";
            }
            else
            {

            }
            string UserName = string.Empty;
            UserName = HttpContext.Current.Request.QueryString["UserName"];
            BindProfileTags();

            if (!Page.IsPostBack)
            {

                // FuploadUserPic.Attributes.Add("onchange", "return CheckFile(this);");               
                txtFirstName.Attributes.Add("onkeyup", "return checkFirstName()");
                txtLastName.Attributes.Add("onkeyup", "return checkLastName()");
                txtEmpID.Attributes.Add("onkeyup", "return checkEmpID()");
                txtResPhNo.Attributes.Add("onKeyPress", "return numbersonly(event)");
                txtMobNo.Attributes.Add("onKeyPress", "return numbersonly(event)");
                txtICQNo.Attributes.Add("onKeyPress", "return numbersonly(event)");
                txtExtNo.Attributes.Add("onKeyPress", "return numbersonly(event)");
                btnSave.Attributes.Add("onclick", "return validateEmpForm()");
                btnSubmit.Attributes.Add("onclick", "return validateCertification()");
                btnUpdate.Attributes.Add("onclick", "return validateCertification()");
                logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
                logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);
                BindDesignation();
                BindDepartment();
                BindTechnology();
                BindCountry();
                BindGender();
                //BindProfileTags();
                BindNameOfCertificate();
                // BindGvCertificates(logedInUser);

                if (HttpContext.Current.Request.QueryString["UserName"] != null)
                {
                    if (logedInUser != UserName)
                    {
                        GetEmpBasicInfo(UserName);
                        getEmpAdditionalInfo(UserName);
                        BindGvCertificates(UserName);



                    }
                    else
                    {
                        GetEmpBasicInfo(UserName);
                        getEmpAdditionalInfo(UserName);
                        BindGvCertificates(UserName);

                    }
                }
                else
                {
                    bool ISUserEntry = CheckUserEntry();
                    if (ISUserEntry)
                    {
                        logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
                        logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);
                        GetEmpBasicInfo(logedInUser);
                        getEmpAdditionalInfo(logedInUser);
                        BindGvCertificates(logedInUser);

                    }
                }
            }
        }
        private bool CheckUserEntry()
        {

            logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
            logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);
            bool EmpValid = true;

            SPSecurity.RunWithElevatedPrivileges(delegate
            {

                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {

                    using (SPWeb web = site.OpenWeb())
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList listBasicInfo = web.Lists.TryGetList(TempEmpBasicInfo);
                        if (listBasicInfo != null)
                        {
                            SPQuery qry = new SPQuery();
                            string stringQuery = "";
                            stringQuery = string.Format(@"<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>{0}</Value></Eq></Where>", logedInUser);
                            qry.Query = stringQuery;
                            SPListItemCollection listcoll = listBasicInfo.GetItems(qry);

                            if (listcoll.Count == 0)
                            {
                                EmpValid = false;

                            }
                            else
                            {

                            }


                        }

                    }

                }

            });
            return EmpValid;
        }

        //private bool CheckUserEntry()
        //{
        //    logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
        //    logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);
        //    bool EmpValid = true;

        //    SPSecurity.RunWithElevatedPrivileges(delegate
        //    {

        //        using (SPSite site = new SPSite(SPContext.Current.Web.Url))
        //        {

        //            using (SPWeb web = site.OpenWeb())
        //            {
        //                web.AllowUnsafeUpdates = true;
        //                SPList listBasicInfo = web.Lists.TryGetList("EmpBasicInfo"); 
        //                if (listBasicInfo != null)
        //                {
        //                    SPQuery qry = new SPQuery();
        //                    string stringQuery = "";
        //                    stringQuery = string.Format(@"<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>{0}</Value></Eq></Where>", logedInUser);
        //                    qry.Query = stringQuery;
        //                    SPListItemCollection listcoll = listBasicInfo.GetItems(qry);

        //                    if (listcoll.Count == 0)
        //                    {
        //                        EmpValid = false;

        //                    }
        //                    else
        //                    {

        //                    }


        //                }

        //            }

        //        }

        //    });
        //    return EmpValid;
        //}
        private void GetEmpBasicInfo(string UserName)
        {
            logedInUser = UserName;
            //SPContext.Current.Web.CurrentUser.LoginName;
            //logedInUser = //logedInUser.Substring(logedInUser.IndexOf("\\") + 1);

            SPSecurity.RunWithElevatedPrivileges(delegate
            {

                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {

                    using (SPWeb web = site.OpenWeb())
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList listBasicInfo = web.Lists.TryGetList("EmpBasicInfo");
                        SPList listDept = web.Lists.TryGetList("Department");
                        SPList listDesignation = web.Lists.TryGetList("Designation");
                        SPList listCountry = web.Lists.TryGetList("Country");
                        SPList listGender = web.Lists.TryGetList("Gender");
                        SPList listTempBasicInfo = web.Lists.TryGetList(TempEmpBasicInfo);

                        if (listTempBasicInfo != null)
                        {
                            SPQuery qry = new SPQuery();
                            string stringQuery = "";
                            stringQuery = string.Format(@"<Where><And><Eq><FieldRef Name='Title' /><Value Type='Text'>{0}</Value></Eq><Eq><FieldRef Name='IsApprove' /><Value Type='Text'>{1}</Value></Eq></And></Where>", logedInUser, "NO");
                            qry.Query = stringQuery;
                            SPListItemCollection listcoll = listTempBasicInfo.GetItems(qry);
                            if (listcoll.Count == 0)
                            {
                                if (listBasicInfo != null)
                                {

                                    SPQuery qryBasicInfo = new SPQuery();
                                    string strBasicInfo = "";
                                    strBasicInfo = string.Format(@"<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>{0}</Value></Eq></Where>", logedInUser);
                                    qryBasicInfo.Query = strBasicInfo;
                                    SPListItemCollection listcollBasic = listBasicInfo.GetItems(qryBasicInfo);

                                    foreach (SPListItem item in listcollBasic)
                                    {

                                        txtFirstName.Text = item[FIRSTNAME].ToString();
                                        txtLastName.Text = item[LASTNAME].ToString();
                                        if (item["ResidencePhoneNumber"] != null)
                                        {
                                            txtResPhNo.Text = item["ResidencePhoneNumber"].ToString();
                                        }
                                        txtMobNo.Text = item["MobileNumber"].ToString();
                                        txtICQNo.Text = item["ICQNumber"].ToString();
                                        txtEmpID.Text = item["EmpID"].ToString();
                                        if (item["ExtensionNumber"] != null)
                                        {
                                            txtExtNo.Text = item["ExtensionNumber"].ToString();
                                        }
                                        txtHiddenBasicInfo.Text = item["ID"].ToString();

                                        if (item["Department"] != null)
                                        {
                                            SPFieldLookupValue lookupDept = new SPFieldLookupValue(item["Department"].ToString());
                                            SelectByText(drpDept, lookupDept.ToString());
                                        }
                                        if (item["Designation"] != null)
                                        {
                                            SPFieldLookupValue LookupDesig = new SPFieldLookupValue(item["Designation"].ToString());
                                            SelectByText(drpDesignation, LookupDesig.ToString());
                                        }

                                        if (item["Country"] != null)
                                        {
                                            SPFieldLookupValue lookupCountry = new SPFieldLookupValue(item["Country"].ToString());
                                            SelectByText(drpCountry, lookupCountry.ToString());
                                        }
                                        if (item["Gender"] != null)
                                        {
                                            SPFieldLookupValue lookupGender = new SPFieldLookupValue(item["Gender"].ToString());
                                            SelectByText(drpGender, lookupGender.ToString());
                                        }

                                        SPFieldLookupValue fieldValues = new SPFieldLookupValue(item["ProfileTag"].ToString());
                                        //string[] delimiterTags = { ';#',' ' };
                                        string[] stringSeparators = new string[] { ";#" };
                                        string[] TagNumber = item["ProfileTag"].ToString().Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                                        foreach (Control ctrl in PnlProfileTags.Controls)
                                        {
                                            if (ctrl.GetType() == typeof(CheckBox))
                                            {
                                                CheckBox cb = ctrl as CheckBox;
                                                foreach (string Txt in TagNumber)
                                                {
                                                    if (Txt == cb.Text)
                                                    {
                                                        cb.Checked = true;
                                                    }
                                                }
                                            }

                                        }

                                        char[] delimiterCertifiedDate = { ' ' };
                                        string[] wordsCertifiedDate = item["DOB"].ToString().Split(delimiterCertifiedDate);
                                        string CertifiedDate = wordsCertifiedDate[0].ToString();
                                        txtOnePageReportStartDate.Text = CertifiedDate;


                                        if (item.Attachments.Count > 0)
                                        {
                                            var strhdn = true;
                                            hdnPic.Value = strhdn.ToString();

                                            foreach (String attachmentname in item.Attachments)
                                            {
                                                String attachmentAbsoluteURL = item.Attachments.UrlPrefix + attachmentname;
                                                ImgUserPic.ImageUrl = attachmentAbsoluteURL;
                                                ImgUserPic.Visible = true;
                                            }
                                        }
                                        else
                                        {
                                            ImgUserPic.ImageUrl = "/_layouts/15/VrtxIntranetStyles/Images/NoImage.jpg";
                                        }

                                    }

                                }
                                else
                                {

                                }

                            }
                            else
                            {
                                if (listTempBasicInfo != null)
                                {
                                    SPQuery strQury = new SPQuery();
                                    string StrQuery = "";
                                    StrQuery = string.Format(@"<Where><Eq><FieldRef Name='Title'/><Value Type='Text'>{0}</Value></Eq></Where>", logedInUser);
                                    strQury.Query = StrQuery;
                                    SPListItemCollection lstcoll = listTempBasicInfo.GetItems(strQury);
                                    foreach (SPListItem item in lstcoll)
                                    {
                                        txtFirstName.Text = item[FIRSTNAME].ToString();
                                        txtLastName.Text = item[LASTNAME].ToString();
                                        if (item["ResidencePhoneNumber"] != null)
                                        {
                                            txtResPhNo.Text = item["ResidencePhoneNumber"].ToString();
                                        }
                                        txtMobNo.Text = item["MobileNumber"].ToString();
                                        txtICQNo.Text = item["ICQNumber"].ToString();
                                        txtEmpID.Text = item["EmpID"].ToString();
                                        if (item["ExtensionNumber"] != null)
                                        {
                                            txtExtNo.Text = item["ExtensionNumber"].ToString();
                                        }
                                        txtHiddenBasicTemp.Text = item["ID"].ToString();
                                        if (item["Department"] != null)
                                        {
                                            SPFieldLookupValue lookupDept = new SPFieldLookupValue(item["Department"].ToString());
                                            SelectByText(drpDept, lookupDept.ToString());
                                        }
                                        if (item["Designation"] != null)
                                        {
                                            SPFieldLookupValue LookupDesig = new SPFieldLookupValue(item["Designation"].ToString());
                                            SelectByText(drpDesignation, LookupDesig.ToString());
                                        }
                                        if (item["Country"] != null)
                                        {
                                            SPFieldLookupValue lookupCountry = new SPFieldLookupValue(item["Country"].ToString());
                                            SelectByText(drpCountry, lookupCountry.ToString());
                                        }
                                        if (item["Gender"] != null)
                                        {

                                            SPFieldLookupValue lookupGender = new SPFieldLookupValue(item["Gender"].ToString());
                                            SelectByText(drpGender, lookupGender.ToString());
                                        }


                                        SPFieldLookupValue fieldValues = new SPFieldLookupValue(item["ProfileTag"].ToString());
                                        //string[] delimiterTags = { ';#',' ' };
                                        string[] stringSeparators = new string[] { ";#" };
                                        string[] TagNumber = item["ProfileTag"].ToString().Split(stringSeparators, StringSplitOptions.RemoveEmptyEntries);
                                        foreach (Control ctrl in PnlProfileTags.Controls)
                                        {
                                            if (ctrl.GetType() == typeof(CheckBox))
                                            {
                                                CheckBox cb = ctrl as CheckBox;
                                                foreach (string Txt in TagNumber)
                                                {
                                                    if (Txt == cb.Text)
                                                    {
                                                        cb.Checked = true;
                                                    }
                                                }
                                            }

                                        }

                                        char[] delimiterCertifiedDate = { ' ' };
                                        string[] wordsCertifiedDate = item["DOB"].ToString().Split(delimiterCertifiedDate);
                                        string CertifiedDate = wordsCertifiedDate[0].ToString();
                                        txtOnePageReportStartDate.Text = CertifiedDate;


                                        if (item.Attachments.Count > 0)
                                        {
                                            var strhdn = true;
                                            hdnPic.Value = strhdn.ToString();

                                            foreach (String attachmentname in item.Attachments)
                                            {
                                                String attachmentAbsoluteURL = item.Attachments.UrlPrefix + attachmentname;
                                                ImgUserPic.ImageUrl = attachmentAbsoluteURL;
                                                ImgUserPic.Visible = true;
                                            }
                                        }
                                        else
                                        {
                                            ImgUserPic.ImageUrl = "/_layouts/15/VrtxIntranetStyles/Images/NoImage.jpg";

                                        }

                                    }

                                }
                            }

                        }
                        else
                        {

                        }

                    }
                }
            });

        }
        private void getEmpAdditionalInfo(string UserName)
        {
            logedInUser = UserName;
            //logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
            //logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {

                    using (SPWeb web = site.OpenWeb())
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.Lists.TryGetList("EmpAdditionalDetails");
                        SPList listTEmpAdditional = web.Lists.TryGetList(TempEmpAdditionalInfo);
                        if (listTEmpAdditional != null)
                        {
                            SPQuery qryTemp = new SPQuery();
                            string str = "";
                            str = string.Format(@"<Where><And><Eq><FieldRef Name='UserName' /><Value Type='Text'>{0}</Value></Eq><Eq><FieldRef Name='IsApprove' /><Value Type='Text'>NO</Value></Eq></And></Where>", logedInUser);
                            qryTemp.Query = str;
                            SPListItemCollection listCollTemp = listTEmpAdditional.GetItems(qryTemp);
                            if (listCollTemp.Count == 0)
                            {
                                if (list != null)
                                {
                                    SPQuery qry = new SPQuery();
                                    string stringQuery = "";

                                    stringQuery = string.Format(@"<Where><Eq><FieldRef Name='UserName' /><Value Type='Text'>{0}</Value></Eq></Where>", logedInUser);
                                    qry.Query = stringQuery;
                                    SPListItemCollection listcoll = list.GetItems(qry);

                                    foreach (SPListItem item in listcoll)
                                    {

                                        txthiddenAdditionalInfo.Text = item["ID"].ToString();
                                        //var aString = item["Overview"].ToString();

                                        SPFieldMultiLineText commentsField = item.Fields.GetField("Overview") as SPFieldMultiLineText;
                                        string comments = commentsField.GetFieldValueAsText(item["Overview"]);
                                        string commentsAsHtml = commentsField.GetFieldValueAsHtml(item["Overview"]);
                                        txtOverView.Text = comments.ToString();
                                        txtForte.Text = item[FORTE].ToString();

                                        SPFieldMultiLineText SpouseField = item.Fields.GetField("AboutSpouse") as SPFieldMultiLineText;
                                        string Spouse = SpouseField.GetFieldValueAsText(item["AboutSpouse"]);
                                        txtMySpouse.Text = Spouse.ToString();

                                        SPFieldMultiLineText HobbiesField = item.Fields.GetField("MyHobbies") as SPFieldMultiLineText;
                                        string Hobbies = HobbiesField.GetFieldValueAsText(item["MyHobbies"]);
                                        txtMyHobbies.Text = Hobbies.ToString();

                                        SPFieldMultiLineText BookField = item.Fields.GetField(BESTBOOK) as SPFieldMultiLineText;
                                        string Book = BookField.GetFieldValueAsText(item[BESTBOOK]);
                                        txtBestBooks.Text = Book.ToString();

                                        SPFieldMultiLineText InspiredField = item.Fields.GetField("Inspiredme") as SPFieldMultiLineText;
                                        string Inspired = InspiredField.GetFieldValueAsText(item["Inspiredme"]);
                                        txtInspiredMe.Text = Inspired.ToString();

                                        SPFieldMultiLineText JobField = item.Fields.GetField("loveaboutjobs") as SPFieldMultiLineText;
                                        string job = JobField.GetFieldValueAsText(item["loveaboutjobs"]);
                                        txtAboutJob.Text = job.ToString();

                                        SPFieldMultiLineText TickField = item.Fields.GetField("Makesmetick") as SPFieldMultiLineText;
                                        string Tick = TickField.GetFieldValueAsText(item["Makesmetick"]);
                                        txtMakesMeTick.Text = Tick.ToString();

                                        SPFieldMultiLineText LazyField = item.Fields.GetField("LazyAfternoon") as SPFieldMultiLineText;
                                        string Lazy = LazyField.GetFieldValueAsText(item["LazyAfternoon"]);
                                        txtLazyNon.Text = Lazy.ToString();

                                        SPFieldMultiLineText FoodField = item.Fields.GetField("FavoriteFoods") as SPFieldMultiLineText;
                                        string Food = FoodField.GetFieldValueAsText(item["FavoriteFoods"]);
                                        txtFavFods.Text = Food.ToString();

                                        SPFieldMultiLineText proudField = item.Fields.GetField("MostProudof") as SPFieldMultiLineText;
                                        string Proud = proudField.GetFieldValueAsText(item["MostProudof"]);
                                        txtProudOf.Text = Proud.ToString();

                                        SPFieldMultiLineText RestField = item.Fields.GetField("BestRestaurant") as SPFieldMultiLineText;
                                        string Rest = RestField.GetFieldValueAsText(item["BestRestaurant"]);
                                        txtBestReat.Text = Rest.ToString();

                                        SPFieldMultiLineText thingField = item.Fields.GetField("InterestingThing") as SPFieldMultiLineText;
                                        string Thing = thingField.GetFieldValueAsText(item["BestRestaurant"]);
                                        txtInterstingThings.Text = Thing.ToString();

                                        SPFieldMultiLineText worldField = item.Fields.GetField("ChangeAnythingAboutWorld") as SPFieldMultiLineText;
                                        string world = worldField.GetFieldValueAsText(item["ChangeAnythingAboutWorld"]);
                                        txtICudChgWorld.Text = world.ToString();

                                        SPFieldMultiLineText sportField = item.Fields.GetField("FollowSports") as SPFieldMultiLineText;
                                        string sport = sportField.GetFieldValueAsText(item["FollowSports"]);
                                        txtSptTmIFoll.Text = sport.ToString();

                                        SPFieldMultiLineText MusicField = item.Fields.GetField("FavoriteMusic") as SPFieldMultiLineText;
                                        string Music = MusicField.GetFieldValueAsText(item["FavoriteMusic"]);
                                        txtmusIListen.Text = Music.ToString();

                                        SPFieldMultiLineText TVField = item.Fields.GetField("FavoriteTV") as SPFieldMultiLineText;
                                        string TV = TVField.GetFieldValueAsText(item["FavoriteTV"]);
                                        txtFavTV.Text = TV.ToString();

                                    }
                                }
                                else
                                {



                                }

                            }
                            else
                            {
                                if (listTEmpAdditional != null)
                                {
                                    SPQuery qry = new SPQuery();
                                    string stringQuery = "";

                                    stringQuery = string.Format(@"<Where><Eq><FieldRef Name='UserName' /><Value Type='Text'>{0}</Value></Eq></Where>", logedInUser);
                                    qry.Query = stringQuery;
                                    SPListItemCollection listcoll = listTEmpAdditional.GetItems(qry);

                                    foreach (SPListItem item in listcoll)
                                    {

                                        txthiddenAdditionalInfoTemp.Text = item["ID"].ToString();
                                        //var aString = item["Overview"].ToString();

                                        SPFieldMultiLineText commentsField = item.Fields.GetField("Overview") as SPFieldMultiLineText;
                                        string comments = commentsField.GetFieldValueAsText(item["Overview"]);
                                        string commentsAsHtml = commentsField.GetFieldValueAsHtml(item["Overview"]);
                                        txtOverView.Text = comments.ToString();

                                        txtForte.Text = item[FORTE].ToString();

                                        SPFieldMultiLineText SpouseField = item.Fields.GetField("AboutSpouse") as SPFieldMultiLineText;
                                        string Spouse = SpouseField.GetFieldValueAsText(item["AboutSpouse"]);
                                        txtMySpouse.Text = Spouse.ToString();

                                        SPFieldMultiLineText HobbiesField = item.Fields.GetField("MyHobbies") as SPFieldMultiLineText;
                                        string Hobbies = HobbiesField.GetFieldValueAsText(item["MyHobbies"]);
                                        txtMyHobbies.Text = Hobbies.ToString();

                                        SPFieldMultiLineText BookField = item.Fields.GetField(BESTBOOK) as SPFieldMultiLineText;
                                        string Book = BookField.GetFieldValueAsText(item[BESTBOOK]);
                                        txtBestBooks.Text = Book.ToString();

                                        SPFieldMultiLineText InspiredField = item.Fields.GetField("Inspiredme") as SPFieldMultiLineText;
                                        string Inspired = InspiredField.GetFieldValueAsText(item["Inspiredme"]);
                                        txtInspiredMe.Text = Inspired.ToString();

                                        SPFieldMultiLineText JobField = item.Fields.GetField("loveaboutjobs") as SPFieldMultiLineText;
                                        string job = JobField.GetFieldValueAsText(item["loveaboutjobs"]);
                                        txtAboutJob.Text = job.ToString();

                                        SPFieldMultiLineText TickField = item.Fields.GetField("Makesmetick") as SPFieldMultiLineText;
                                        string Tick = TickField.GetFieldValueAsText(item["Makesmetick"]);
                                        txtMakesMeTick.Text = Tick.ToString();

                                        SPFieldMultiLineText LazyField = item.Fields.GetField("LazyAfternoon") as SPFieldMultiLineText;
                                        string Lazy = LazyField.GetFieldValueAsText(item["LazyAfternoon"]);
                                        txtLazyNon.Text = Lazy.ToString();

                                        SPFieldMultiLineText FoodField = item.Fields.GetField("FavoriteFoods") as SPFieldMultiLineText;
                                        string Food = FoodField.GetFieldValueAsText(item["FavoriteFoods"]);
                                        txtFavFods.Text = Food.ToString();

                                        SPFieldMultiLineText proudField = item.Fields.GetField("MostProudof") as SPFieldMultiLineText;
                                        string Proud = proudField.GetFieldValueAsText(item["MostProudof"]);
                                        txtProudOf.Text = Proud.ToString();

                                        SPFieldMultiLineText RestField = item.Fields.GetField("BestRestaurant") as SPFieldMultiLineText;
                                        string Rest = RestField.GetFieldValueAsText(item["BestRestaurant"]);
                                        txtBestReat.Text = Rest.ToString();

                                        SPFieldMultiLineText thingField = item.Fields.GetField("InterestingThing") as SPFieldMultiLineText;
                                        string Thing = thingField.GetFieldValueAsText(item["BestRestaurant"]);
                                        txtInterstingThings.Text = Thing.ToString();

                                        SPFieldMultiLineText worldField = item.Fields.GetField("ChangeAnythingAboutWorld") as SPFieldMultiLineText;
                                        string world = worldField.GetFieldValueAsText(item["ChangeAnythingAboutWorld"]);
                                        txtICudChgWorld.Text = world.ToString();

                                        SPFieldMultiLineText sportField = item.Fields.GetField("FollowSports") as SPFieldMultiLineText;
                                        string sport = sportField.GetFieldValueAsText(item["FollowSports"]);
                                        txtSptTmIFoll.Text = sport.ToString();

                                        SPFieldMultiLineText MusicField = item.Fields.GetField("FavoriteMusic") as SPFieldMultiLineText;
                                        string Music = MusicField.GetFieldValueAsText(item["FavoriteMusic"]);
                                        txtmusIListen.Text = Music.ToString();

                                        SPFieldMultiLineText TVField = item.Fields.GetField("FavoriteTV") as SPFieldMultiLineText;
                                        string TV = TVField.GetFieldValueAsText(item["FavoriteTV"]);
                                        txtFavTV.Text = TV.ToString();

                                    }
                                }

                            }

                        }

                    }
                }
            });
        }
        private void UpdateBasicInfo(string UserName)
        {
            //logedInUser = UserName;
            logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
            logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);

            SPSecurity.RunWithElevatedPrivileges(delegate
            {

                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {

                    using (SPWeb web = site.OpenWeb())
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList listBasicInfo = web.Lists.TryGetList("EmpBasicInfo");
                        SPList listDept = web.Lists.TryGetList("Department");
                        SPList listDesignation = web.Lists.TryGetList("Designation");
                        SPList listCountry = web.Lists.TryGetList("Country");
                        SPList listTags = web.Lists.TryGetList("ProfileTags");
                        SPList listGender = web.Lists.TryGetList("Gender");
                        SPList listTempBasicInfo = web.Lists.TryGetList(TempEmpBasicInfo);


                        int DeptID = Convert.ToInt32(drpDept.SelectedValue);
                        SPListItem itmDept = web.Lists[listDept.Title].GetItemById(DeptID);

                        int DesignationID = Convert.ToInt32(drpDesignation.SelectedValue);
                        SPListItem itmDesignation = web.Lists[listDesignation.Title].GetItemById(DesignationID);

                        int CountryID = Convert.ToInt32(drpCountry.SelectedValue);
                        SPListItem itmCountry = web.Lists[listCountry.Title].GetItemById(CountryID);

                        int GenderID = Convert.ToInt32(drpGender.SelectedValue);
                        SPListItem itmGender = web.Lists[listGender.Title].GetItemById(GenderID);

                        List<string> fileNames = new List<string>();

                        if (listTempBasicInfo != null)
                        {
                            SPQuery Qry = new SPQuery();
                            string strQuery;
                            strQuery = string.Format(@"<Where><And><Eq><FieldRef Name='Title' /><Value Type='Text'>{0}</Value></Eq><Eq><FieldRef Name='IsApprove' /><Value Type='Text'>NO</Value></Eq></And></Where>", logedInUser);
                            Qry.Query = strQuery;
                            SPListItemCollection listColl = listTempBasicInfo.GetItems(Qry);
                            if (listColl.Count == 0)
                            {
                                if (listBasicInfo != null)
                                {
                                    if (txtHiddenBasicInfo.Text != null || txtHiddenBasicInfo.Text != "")
                                    {
                                        CurrUserID = Convert.ToInt32(txtHiddenBasicInfo.Text);
                                        SPListItem item = listBasicInfo.Items.GetItemById(CurrUserID);
                                        SPListItem itemTemp = listTempBasicInfo.Items.Add();
                                        itemTemp[FIRSTNAME] = txtFirstName.Text;
                                        itemTemp[LASTNAME] = txtLastName.Text;
                                        itemTemp["ResidencePhoneNumber"] = txtResPhNo.Text;
                                        itemTemp["MobileNumber"] = txtMobNo.Text;
                                        itemTemp["ICQNumber"] = txtICQNo.Text;
                                        itemTemp["ExtensionNumber"] = txtExtNo.Text;
                                        itemTemp["Department"] = new SPFieldLookupValue(itmDept.ID, itmDept.Title);
                                        itemTemp["Designation"] = new SPFieldLookupValue(itmDesignation.ID, itmDesignation.Title);
                                        itemTemp["DOB"] = Convert.ToDateTime(txtOnePageReportStartDate.Text);
                                        itemTemp["Country"] = new SPFieldLookupValue(itmCountry.ID, itmCountry.Title);
                                        itemTemp["Gender"] = new SPFieldLookupValue(itmGender.ID, itmGender.Title);
                                        itemTemp["EmpID"] = txtEmpID.Text;

                                        SPFieldLookupValueCollection fieldValues = new SPFieldLookupValueCollection();
                                        foreach (Control ctrl in PnlProfileTags.Controls)
                                        {
                                            CheckBox cb = ctrl as CheckBox;
                                            if (cb != null)
                                            {
                                                if (cb.Checked)
                                                {
                                                    int TageID = Convert.ToInt32(cb.ID.Substring(4));
                                                    SPListItem TagItm = listTags.GetItemById(TageID);

                                                    fieldValues.Add(new SPFieldLookupValue(TagItm.ID, TagItm.Title));
                                                }
                                            }
                                        }
                                        itemTemp["ProfileTag"] = fieldValues;
                                        if (FuploadUserPic.HasFiles != false)
                                        {
                                            if (FuploadUserPic.PostedFile != null)
                                            {
                                                HttpPostedFile myFile = FuploadUserPic.PostedFile;
                                                fileLength = myFile.ContentLength;
                                                byte[] contents = new byte[fileLength];
                                                myFile.InputStream.Read(contents, 0, fileLength);
                                                fileName = System.IO.Path.GetFileName(FuploadUserPic.PostedFile.FileName);

                                                foreach (string fileName1 in item.Attachments)
                                                {
                                                    fileNames.Add(fileName1);
                                                }

                                                foreach (string fileName1 in fileNames)
                                                {
                                                    itemTemp.Attachments.Delete(fileName1);
                                                }

                                                itemTemp.Attachments.Add(FuploadUserPic.FileName, contents);
                                            }
                                        }
                                        else
                                        {

                                        }
                                        itemTemp.Update();


                                    }
                                }
                            }
                            else
                            {
                                if (TempEmpBasicInfo != null)
                                {
                                    if (txtHiddenBasicTemp.Text != null || txtHiddenBasicInfo.Text != " ")
                                    {
                                        CurrUserTempID = Convert.ToInt32(txtHiddenBasicTemp.Text);
                                        SPListItem item = listTempBasicInfo.Items.GetItemById(CurrUserTempID);
                                        item[FIRSTNAME] = txtFirstName.Text;
                                        item[LASTNAME] = txtLastName.Text;
                                        item["ResidencePhoneNumber"] = txtResPhNo.Text;
                                        item["MobileNumber"] = txtMobNo.Text;
                                        item["ICQNumber"] = txtICQNo.Text;
                                        item["ExtensionNumber"] = txtExtNo.Text;
                                        item["Department"] = new SPFieldLookupValue(itmDept.ID, itmDept.Title);
                                        item["Designation"] = new SPFieldLookupValue(itmDesignation.ID, itmDesignation.Title);
                                        item["DOB"] = Convert.ToDateTime(txtOnePageReportStartDate.Text);
                                        item["Country"] = new SPFieldLookupValue(itmCountry.ID, itmCountry.Title);
                                        item["Gender"] = new SPFieldLookupValue(itmGender.ID, itmGender.Title);
                                        item["EmpID"] = txtEmpID.Text;
                                        item["IsApprove"] = "NO";

                                        SPFieldLookupValueCollection fieldValues = new SPFieldLookupValueCollection();
                                        foreach (Control ctrl in PnlProfileTags.Controls)
                                        {
                                            CheckBox cb = ctrl as CheckBox;
                                            if (cb != null)
                                            {
                                                if (cb.Checked)
                                                {
                                                    int TageID = Convert.ToInt32(cb.ID.Substring(4));
                                                    SPListItem TagItm = listTags.GetItemById(TageID);

                                                    fieldValues.Add(new SPFieldLookupValue(TagItm.ID, TagItm.Title));
                                                }
                                            }
                                        }
                                        item["ProfileTag"] = fieldValues;
                                        if (FuploadUserPic.HasFiles != false)
                                        {
                                            if (FuploadUserPic.PostedFile != null)
                                            {
                                                HttpPostedFile myFile = FuploadUserPic.PostedFile;
                                                fileLength = myFile.ContentLength;
                                                byte[] contents = new byte[fileLength];
                                                myFile.InputStream.Read(contents, 0, fileLength);
                                                fileName = System.IO.Path.GetFileName(FuploadUserPic.PostedFile.FileName);

                                                foreach (string fileName1 in item.Attachments)
                                                {
                                                    fileNames.Add(fileName1);
                                                }

                                                foreach (string fileName1 in fileNames)
                                                {
                                                    item.Attachments.Delete(fileName1);
                                                }

                                                item.Attachments.Add(FuploadUserPic.FileName, contents);
                                            }
                                        }
                                        else
                                        {

                                        }
                                        item.Update();
                                    }
                                }

                            }
                        }
                    }
                }
            });
        }
        private void UpdateAdditionalInfo(string UserName)
        {
            logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
            logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                // int hiddenItmID = Convert.ToInt32(txthiddenAdditionalInfo.Text);
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {

                    using (SPWeb web = site.OpenWeb())
                    {
                        web.AllowUnsafeUpdates = true;
                        SPList listAdditionalInfo = web.Lists.TryGetList("EmpAdditionalDetails");
                        SPList listTempAdditional = web.Lists.TryGetList(TempEmpAdditionalInfo);
                        if (listTempAdditional != null)
                        {
                            SPQuery qry = new SPQuery();
                            string strQry = "";
                            strQry = string.Format(@"<Where><And><Eq><FieldRef Name='UserName' /><Value Type='Text'>{0}</Value></Eq><Eq><FieldRef Name='IsApprove' /><Value Type='Text'>NO</Value></Eq></And></Where>", logedInUser);
                            qry.Query = strQry;
                            SPListItemCollection listColl = listTempAdditional.GetItems(qry);
                            if (listColl.Count == 0)
                            {
                                if (listAdditionalInfo != null)
                                {
                                    if (txthiddenAdditionalInfo.Text != null || txthiddenAdditionalInfoTemp.Text != "")
                                    {
                                        CurrAddUserID = Convert.ToInt32(txthiddenAdditionalInfo.Text);

                                        SPListItem item = listAdditionalInfo.Items.GetItemById(CurrAddUserID);
                                        item["Overview"] = txtOverView.Text;
                                        item[FORTE] = txtForte.Text;
                                        item["AboutSpouse"] = txtMySpouse.Text;
                                        item["MyHobbies"] = txtMyHobbies.Text;
                                        item[BESTBOOK] = txtBestBooks.Text;
                                        item["Inspiredme"] = txtInspiredMe.Text;
                                        item["loveaboutjobs"] = txtAboutJob.Text;
                                        item["Makesmetick"] = txtMakesMeTick.Text;
                                        item["LazyAfternoon"] = txtLazyNon.Text;
                                        item["FavoriteFoods"] = txtFavFods.Text;
                                        item["MostProudof"] = txtProudOf.Text;
                                        item["BestRestaurant"] = txtBestReat.Text;
                                        item["InterestingThing"] = txtInterstingThings.Text;
                                        item["ChangeAnythingAboutWorld"] = txtICudChgWorld.Text;
                                        item["FollowSports"] = txtSptTmIFoll.Text;
                                        item["FavoriteMusic"] = txtmusIListen.Text;
                                        item["FavoriteTV"] = txtFavTV.Text;
                                        item.Update();
                                    }
                                }
                            }
                            else
                            {
                                if (listTempAdditional != null)
                                {
                                    if (txthiddenAdditionalInfo.Text != null || txthiddenAdditionalInfoTemp.Text != "")
                                    {
                                        CurrAddUserTempID = Convert.ToInt32(txthiddenAdditionalInfoTemp.Text);

                                        SPListItem Parentitem = listTempAdditional.Items.GetItemById(CurrAddUserTempID);
                                        Parentitem["Overview"] = txtOverView.Text;
                                        Parentitem[FORTE] = txtForte.Text;
                                        Parentitem["AboutSpouse"] = txtMySpouse.Text;
                                        Parentitem["MyHobbies"] = txtMyHobbies.Text;
                                        Parentitem[BESTBOOK] = txtBestBooks.Text;
                                        Parentitem["Inspiredme"] = txtInspiredMe.Text;
                                        Parentitem["loveaboutjobs"] = txtAboutJob.Text;
                                        Parentitem["Makesmetick"] = txtMakesMeTick.Text;
                                        Parentitem["LazyAfternoon"] = txtLazyNon.Text;
                                        Parentitem["FavoriteFoods"] = txtFavFods.Text;
                                        Parentitem["MostProudof"] = txtProudOf.Text;
                                        Parentitem["BestRestaurant"] = txtBestReat.Text;
                                        Parentitem["InterestingThing"] = txtInterstingThings.Text;
                                        Parentitem["ChangeAnythingAboutWorld"] = txtICudChgWorld.Text;
                                        Parentitem["FollowSports"] = txtSptTmIFoll.Text;
                                        Parentitem["FavoriteMusic"] = txtmusIListen.Text;
                                        Parentitem["FavoriteTV"] = txtFavTV.Text;
                                        Parentitem["IsApprove"] = "NO";
                                        Parentitem.Update();
                                    }
                                }
                            }

                        }

                    }
                }
            });

        }
        private void GetCertification(string UserName)
        {

            logedInUser = UserName;

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {

                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList list = web.Lists.TryGetList("EmpCertifications");
                        if (list != null)
                        {
                            SPQuery qry = new SPQuery();
                            string stringQuery = "";

                            stringQuery = string.Format(@"<Where><Eq><FieldRef Name='UserName' /><Value Type='Text'>{0}</Value></Eq></Where>", logedInUser);

                            qry.Query = stringQuery;

                            SPListItemCollection listcoll = list.GetItems(qry);
                            DataTable dtCerificate = new DataTable();

                            dtCerificate = listcoll.GetDataTable();
                        }
                    }
                }
            });

        }
        private void BindGvCertificates(string UserName)
        {

            logedInUser = UserName;
            // logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {
                    using (SPWeb web = site.OpenWeb())
                    {
                        SPList list = web.Lists.TryGetList("EmpCertifications");
                        SPList lstCertifications = web.Lists.TryGetList(TempEmpCertifications);
                        SPQuery qryCertifications = new SPQuery();
                        string strQuery = "";
                        string Year = DateTime.Now.Year.ToString();
                        strQuery = string.Format(@"<Where><And><Eq><FieldRef Name='UserName' /><Value Type='Text'>{0}</Value></Eq><Eq><FieldRef Name='FiscalYear' /><Value Type='Text'>{1}</Value></Eq></And></Where>", logedInUser, Year);
                        qryCertifications.Query = strQuery;
                        SPListItemCollection lstColl = list.GetItems(qryCertifications);

                        SPQuery qryTemp = new SPQuery();
                        string strQueryTemp = "";
                        strQueryTemp = string.Format(@"<Where><And><Eq><FieldRef Name='IsApprove' /><Value Type='Text'>{0}</Value></Eq><Eq><FieldRef Name='UserName' /><Value Type='Text'>{1}</Value></Eq></And></Where>", "NO", logedInUser);
                        qryTemp.Query = strQueryTemp;
                        SPListItemCollection lstCollTemp = lstCertifications.GetItems(qryTemp);
                        if (lstCollTemp.Count > 0)
                        {
                            List<SPListItem> GenricTempCollection = lstCollTemp.OfType<SPListItem>().ToList();


                            List<string> strlist = new List<string>();
                            foreach (SPListItem item in lstCollTemp)
                            {
                                strlist.Add(item["EditID"] != null ? item["EditID"].ToString() : string.Empty);
                                string strVal = string.Join(",", strlist.ToArray());
                            }
                            List<string> result = new List<string>();
                            result = (from m in strlist select m).Distinct().ToList();

                            Array.ForEach(result.ToArray(),
                            delegate(string x)
                            {
                                if (x != string.Empty)
                                {
                                    if (GenricTempCollection.Exists(y => (y["EditID"] != null) && y["EditID"].ToString() == x))
                                    {
                                        qryValues = new SPQuery();
                                        string strQueryVal = "";
                                        strQueryVal = string.Format(@"<Where><And><Eq><FieldRef Name='UserName' /><Value Type='Text'>{0}</Value></Eq><Neq><FieldRef Name='ID' /><Value Type='Counter'>{1}</Value></Neq></And></Where>", logedInUser, x);
                                        qryValues.Query = strQueryVal;
                                    }
                                    listCollFinal = list.GetItems(qryValues);
                                }
                                else
                                {
                                    listCollFinal = list.GetItems(qryCertifications);
                                }

                            }

                        );
                        }
                        else
                        {
                            lstColl = list.GetItems(qryCertifications);
                            GvCertificates.DataSource = lstColl.GetDataTable();
                            GvCertificates.DataBind();
                        }

                        if (listCollFinal != null && listCollFinal.Count > 0)
                        {
                            dtValues = listCollFinal.GetDataTable();
                        }


                        if (lstCollTemp.Count > 0)
                        {
                            dtTempItems = lstCollTemp.GetDataTable();
                        }
                        if (dtTempItems.Rows.Count > 0 && dtValues.Rows.Count > 0)
                        {
                            dtTempItems.Merge(dtValues);
                            GvCertificates.DataSource = dtTempItems;
                            GvCertificates.DataBind();
                        }
                        else if (dtValues.Rows.Count > 0)
                        {
                            GvCertificates.DataSource = dtValues;
                            GvCertificates.DataBind();
                        }
                        else if (dtTempItems.Rows.Count > 0)
                        {
                            GvCertificates.DataSource = dtTempItems;
                            GvCertificates.DataBind();
                        }
                    }
                }
            });
        }

        private void BindDesignation()
        {
            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {
                if (site != null)
                {
                    SPWeb web = site.OpenWeb();
                    web.AllowUnsafeUpdates = true;
                    SPList list = web.Lists.TryGetList("Designation");
                    if (list != null)
                    {
                        DataTable dt = list.Items.GetDataTable();
                        if (dt.Columns.Count >= 0)
                        {
                            drpDesignation.DataSource = dt;
                            drpDesignation.DataValueField = dt.Columns["ID"].ToString();
                            drpDesignation.DataTextField = dt.Columns["Title"].ToString();
                            // drpDept.DataValueField = dt.Columns["Designation/Domain"].ToString();
                            drpDesignation.DataBind();
                            drpDesignation.Items.Insert(0, "Select");
                        }
                    }

                }
            }
        }

        private void BindDepartment()
        {
            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {
                if (site != null)
                {
                    SPWeb web = site.OpenWeb();
                    web.AllowUnsafeUpdates = false;
                    SPList list = web.Lists.TryGetList("Department");
                    if (list != null)
                    {
                        DataTable dt = list.Items.GetDataTable();
                        drpDept.DataSource = dt;
                        drpDept.DataTextField = dt.Columns["Title"].ToString();
                        drpDept.DataValueField = dt.Columns["ID"].ToString();
                        drpDept.DataBind();
                        drpDept.Items.Insert(0, "Select");
                    }

                }
            }

        }
        private void BindProfileTags()
        {
            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {
                if (site != null)
                {
                    SPWeb web = site.OpenWeb();
                    web.AllowUnsafeUpdates = true;
                    SPList list = web.Lists.TryGetList("ProfileTags");
                    if (list != null)
                    {
                        SPListItemCollection listcoll = list.Items;

                        strtech = new CheckBox[listcoll.Count];
                        int i = 0;

                        foreach (SPListItem item in listcoll)
                        {

                            CheckBox objchkProfileTag = new CheckBox();
                            PnlProfileTags.Controls.Add(new LiteralControl("<div style=\"width:33%;float:left\">"));
                            objchkProfileTag.Text = item["Title"].ToString();
                            objchkProfileTag.ID = "tech" + item["ID"].ToString();
                            strtech[i] = objchkProfileTag;
                            PnlProfileTags.Controls.Add(objchkProfileTag);
                            PnlProfileTags.Controls.Add(new LiteralControl("</div>"));
                            i++;
                        }

                    }
                }
            }
            //ProfileTags = new string[] { };
        }
        private void BindTechnology()
        {
            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {
                if (site != null)
                {
                    SPWeb web = site.OpenWeb();
                    web.AllowUnsafeUpdates = true;
                    SPList list = web.Lists.TryGetList("Technologies");
                    if (list != null)
                    {
                        DataTable dt = list.Items.GetDataTable();
                        drpTechnology.DataSource = dt;
                        drpTechnology.DataTextField = dt.Columns["Title"].ToString();
                        drpTechnology.DataValueField = dt.Columns["ID"].ToString();
                        //drpTechnology.DataValueField = dt.Columns["Technology"].ToString();
                        drpTechnology.DataBind();
                        drpTechnology.Items.Insert(0, "Select");
                    }

                }
            }

        }
        private void BindNameOfCertificate()
        {
            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {
                if (site != null)
                {
                    SPWeb web = site.OpenWeb();
                    web.AllowUnsafeUpdates = true;
                    SPList list = web.Lists.TryGetList("Certifications");
                    if (list != null)
                    {
                        DataTable dt = list.Items.GetDataTable();
                        drpNameOfCertification.DataSource = dt;
                        drpNameOfCertification.DataValueField = dt.Columns["ID"].ToString();
                        drpNameOfCertification.DataTextField = dt.Columns["Title"].ToString();
                        //drpDept.DataTextField = dt.Columns["Name of Certificate"].ToString();
                        drpNameOfCertification.DataBind();
                        drpNameOfCertification.Items.Insert(0, "Select");
                    }
                }
            }
        }
        private void BindGender()
        {
            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {
                if (site != null)
                {
                    SPWeb web = site.OpenWeb();
                    web.AllowUnsafeUpdates = true;
                    SPList list = web.Lists.TryGetList("Gender");
                    if (list != null)
                    {
                        DataTable dt = list.Items.GetDataTable();
                        drpGender.DataSource = dt;
                        drpGender.DataValueField = dt.Columns["ID"].ToString();
                        drpGender.DataTextField = dt.Columns["Title"].ToString();
                        drpGender.DataBind();
                        drpGender.Items.Insert(0, "Select");
                    }
                }
            }
        }
        private void BindCountry()
        {
            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {
                if (site != null)
                {
                    SPWeb web = site.OpenWeb();
                    web.AllowUnsafeUpdates = true;
                    SPList list = web.Lists.TryGetList("Country");
                    if (list != null)
                    {
                        DataTable dt = list.Items.GetDataTable();
                        drpCountry.DataSource = dt;
                        drpCountry.DataValueField = dt.Columns["ID"].ToString();
                        drpCountry.DataTextField = dt.Columns["Title"].ToString();
                        //drpDept.DataTextField = dt.Columns["Name of Certificate"].ToString();
                        drpCountry.DataBind();
                        drpCountry.Items.Insert(0, "Select");
                    }
                }
            }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                CheckDuplications();
                // BindGvCertificates(UserName);
            }
            catch (Exception ex)
            { }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                //logedInUser = UserName;
                logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
                logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);
                bool bFlag = UpdateEmpInfo();

                if (bFlag)
                {
                    //txtEditItemUtilization.Text = string.Empty;
                    //hdnAssignUtil.Value = "0";
                    string confirmScript = "alert('updated certificates Saved successfully');window.location = window.location.toString();";
                    ScriptManager.RegisterClientScriptBlock(btnUpdate, btnUpdate.GetType(), "exists5", confirmScript, true);
                    BindGvCertificates(logedInUser);
                }


            }
            catch (Exception ex)
            { }


        }
        private void DeleteEmpInfo()
        {

            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {
                    if (site != null)
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true;
                        SPList listchl = web.Lists.TryGetList("EmpCertifications");
                        SPList listTemp = web.Lists.TryGetList(TempEmpCertifications);
                        int ItmiD = Convert.ToInt32(txtCertificateDelete.Text);
                        if (listTemp != null)
                        {
                            SPQuery qry = new SPQuery();
                            string strQry = "";
                            strQry = string.Format(@"<Where><And><Eq><FieldRef Name='ID' /><Value Type='Counter'>{0}</Value></Eq><Eq><FieldRef Name='IsApprove' /><Value Type='Text'>NO</Value></Eq></And></Where>", ItmiD.ToString());
                            qry.Query = strQry;
                            SPListItemCollection listColl = listTemp.GetItems(qry);
                            if (listColl.Count == 0)
                            {
                                //int itmID = Convert.ToInt32(txtCertificateId.Text);

                                SPListItem item = listchl.Items.GetItemById(ItmiD);
                                item.Delete();
                                //item.Update();
                                listchl.Update();
                            }
                            else
                            {
                                SPListItem item = listTemp.Items.GetItemById(ItmiD);
                                item.Delete();
                                //item.Update();
                                listchl.Update();
                            }
                        }

                    }
                }
            });


        }

        private bool UpdateEmpInfo()
        {
            bool uFlag = false;
            int itmID;
            try
            {
                logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
                logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);

                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                    {
                        if (site != null)
                        {
                            SPWeb web = site.OpenWeb();
                            web.AllowUnsafeUpdates = true;
                            SPList listm = web.Lists.TryGetList("Certifications");
                            SPList listchl = web.Lists.TryGetList("EmpCertifications");
                            SPList listcertification = web.Lists.TryGetList(TempEmpCertifications);


                            if (txtCerificateEdit1.Text != string.Empty)
                                itmID = Convert.ToInt32(txtCerificateEdit1.Text);

                            else
                                itmID = Convert.ToInt32(hdnEditId.Value);


                            int crtId = Convert.ToInt32(drpNameOfCertification.SelectedValue);
                            var cerficationItm = web.Lists[listm.Title].GetItemById(crtId);

                            if (listcertification != null)
                            {

                                SPQuery qry = new SPQuery();
                                string strQry = "";
                                strQry = string.Format(@"<Where><And><Eq><FieldRef Name='ID' /><Value Type='Counter'>{0}</Value></Eq><Eq><FieldRef Name='IsApprove' /><Value Type='Text'>{1}</Value></Eq></And></Where>", itmID.ToString(), "NO");
                                qry.Query = strQry;
                                SPListItemCollection listColl = listcertification.GetItems(qry);
                                if (listColl.Count == 0)
                                {
                                    if (listchl != null)
                                    {
                                        //SPListItem item = listcertification.Items.GetItemById(itmID);
                                        SPListItem itemTemp = listcertification.Items.Add();
                                        itemTemp["UserName"] = logedInUser;
                                        itemTemp["Technology"] = drpTechnology.SelectedValue;
                                        itemTemp["Certificate"] = drpNameOfCertification.SelectedValue;

                                        if (txtCertificationID.Text != "")
                                        {
                                            itemTemp["CertificationID"] = txtCertificationID.Text;
                                        }
                                        if (txtCertifiedDate.Text != "")
                                        {
                                            itemTemp["Certificate"] = new SPFieldLookupValue(cerficationItm.ID, cerficationItm.Title);
                                            itemTemp["CertifiedDate"] = Convert.ToDateTime(txtCertifiedDate.Text);

                                        }
                                        if (txtUntilDate.Text != "")
                                        {
                                            itemTemp["UntilDate"] = Convert.ToDateTime(txtUntilDate.Text);

                                        }
                                        itemTemp["IsApprove"] = "NO";
                                        itemTemp["EditID"] = itmID.ToString();
                                        SPList listFY = web.Lists.TryGetList("FiscalYear");
                                        string StrFY = DateTime.Now.Year.ToString();

                                        SPQuery qryFIS = new SPQuery();
                                        string stringQuery = "";
                                        // stringQuery = string.Format(@"<Where><And><Eq><FieldRef Name='Technology' /><Value Type='Lookup'>{0}</Value></Eq><And><Eq><FieldRef Name='Certificate' /><Value Type='Lookup'>{1}</Value></Eq><And><Eq><FieldRef Name='UserName' /><Value Type='Lookup'>{2}</Value></Eq></And></And></And></Where>", drpTechnology.SelectedValue, drpNameOfCertification.SelectedValue,logedInUser);
                                        stringQuery = string.Format(@"<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>{0}</Value></Eq></Where>", StrFY);
                                        qryFIS.Query = stringQuery;
                                        SPListItemCollection collection = listFY.GetItems(qryFIS);

                                        //int ItmFYID =Convert.ToInt32(StrFY);
                                        //SPListItem itmFY = web.Lists[listFY.Title].GetItemById(ItmFYID);

                                        foreach (SPListItem items in collection)
                                        {
                                            SPListItem lookupFY = listFY.GetItemById(items.ID);
                                            itemTemp["FiscalYear"] = new SPFieldLookupValue(lookupFY.ID, lookupFY.Title);
                                        }
                                        //  item["FiscalYear"] = DateTime.Now.Yea
                                        List<string> fileNames = new List<string>();
                                        if (FulCerificates.HasFiles != false)
                                        {
                                            if (FulCerificates.PostedFile != null)
                                            {
                                                HttpPostedFile myFile = FulCerificates.PostedFile;
                                                fileLength = myFile.ContentLength;
                                                byte[] contents = new byte[fileLength];
                                                myFile.InputStream.Read(contents, 0, fileLength);
                                                fileName = System.IO.Path.GetFileName(FulCerificates.PostedFile.FileName);


                                                //    //FileStream stream = new FileStream(FulCerificates.PostedFile.FileName, FileMode.Open);
                                                //    //byte[] byteArray = new byte[stream.Length];
                                                //    //stream.Read(byteArray, 0, Convert.ToInt32(stream.Length));
                                                //    //stream.Close();
                                                foreach (string fileName1 in itemTemp.Attachments)
                                                {
                                                    fileNames.Add(fileName1);
                                                }

                                                foreach (string fileName1 in fileNames)
                                                {
                                                    itemTemp.Attachments.Delete(fileName1);
                                                }

                                                itemTemp.Attachments.Add(FulCerificates.FileName, contents);
                                            }
                                        }
                                        itemTemp.Update();
                                        uFlag = true;
                                    }

                                }
                                else
                                {
                                    if (listcertification != null)
                                    {
                                        //SPListItem item = listchl.Items.Add();

                                        SPListItem item = listcertification.Items.GetItemById(itmID);
                                        List<string> fileNames = new List<string>();

                                        item["UserName"] = logedInUser;
                                        item["Technology"] = drpTechnology.SelectedValue;
                                        item["Certificate"] = drpNameOfCertification.SelectedValue;
                                        if (txtCertificationID.Text != "")
                                        {
                                            item["CertificationID"] = txtCertificationID.Text;
                                        }
                                        if (txtCertifiedDate.Text != "")
                                        {
                                            item["Certificate"] = new SPFieldLookupValue(cerficationItm.ID, cerficationItm.Title);
                                            item["CertifiedDate"] = Convert.ToDateTime(txtCertifiedDate.Text);

                                        }
                                        if (txtUntilDate.Text != "")
                                        {
                                            item["UntilDate"] = Convert.ToDateTime(txtUntilDate.Text);

                                        }
                                        item["IsApprove"] = "NO";



                                        if (FulCerificates.HasFiles != false)
                                        {
                                            if (FulCerificates.PostedFile != null)
                                            {
                                                HttpPostedFile myFile = FulCerificates.PostedFile;
                                                fileLength = myFile.ContentLength;
                                                byte[] contents = new byte[fileLength];
                                                myFile.InputStream.Read(contents, 0, fileLength);
                                                fileName = System.IO.Path.GetFileName(FulCerificates.PostedFile.FileName);


                                                //    //FileStream stream = new FileStream(FulCerificates.PostedFile.FileName, FileMode.Open);
                                                //    //byte[] byteArray = new byte[stream.Length];
                                                //    //stream.Read(byteArray, 0, Convert.ToInt32(stream.Length));
                                                //    //stream.Close();
                                                foreach (string fileName1 in item.Attachments)
                                                {
                                                    fileNames.Add(fileName1);
                                                }

                                                foreach (string fileName1 in fileNames)
                                                {
                                                    item.Attachments.Delete(fileName1);
                                                }

                                                item.Attachments.Add(FulCerificates.FileName, contents);
                                            }
                                        }
                                        item.Update();
                                        uFlag = true;
                                    }
                                }
                            }


                        }
                    }
                });
            }
            catch (Exception ex)
            {
                uFlag = false;
            }
            finally
            {
                hdnTechnology.Value = string.Empty;
                hdnNameOfCertification.Value = string.Empty;
                hdnCertificationID.Value = string.Empty;
                hdnStartDate.Value = string.Empty;
                hdnEndDate.Value = string.Empty;
                hdnAttachment.Value = string.Empty;

            }
            return uFlag;

        }

        public void CheckDuplications()
        {
            logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
            logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);
            bool bFlag = false;
            int itemCount;
            using (SPSite site = new SPSite(SPContext.Current.Web.Url))
            {
                if (site != null)
                {
                    SPWeb web = site.OpenWeb();
                    web.AllowUnsafeUpdates = true;
                    SPList list = web.Lists.TryGetList("EmpCertifications");
                    if (list != null)
                    {
                        string strTechnology = drpTechnology.SelectedItem.Text;
                        string strCertificate = drpNameOfCertification.SelectedItem.Text;
                        SPQuery qry = new SPQuery();
                        string stringQuery = "";
                        // stringQuery = string.Format(@"<Where><And><Eq><FieldRef Name='Technology' /><Value Type='Lookup'>{0}</Value></Eq><And><Eq><FieldRef Name='Certificate' /><Value Type='Lookup'>{1}</Value></Eq><And><Eq><FieldRef Name='UserName' /><Value Type='Lookup'>{2}</Value></Eq></And></And></And></Where>", drpTechnology.SelectedValue, drpNameOfCertification.SelectedValue,logedInUser);
                        stringQuery = string.Format(@"<Where><And><Eq><FieldRef Name='Technology'/><Value Type='Lookup'>{0}</Value></Eq><And><Eq><FieldRef Name='Certificate'/><Value Type='Lookup'>{1}</Value></Eq><Eq><FieldRef Name='UserName'/><Value Type='Text'>{2}</Value></Eq></And></And></Where>", strTechnology, strCertificate, logedInUser);
                        qry.Query = stringQuery;
                        SPListItemCollection collection = list.GetItems(qry);
                        itemCount = collection.Count;
                        if (itemCount == 0)
                        {
                            bFlag = InsertCertificates();

                            if (bFlag == true)
                            {
                                string confirmScript = "alert('Saved successfully');window.location = window.location.toString();";
                                ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "exists5", confirmScript, true);
                                BindGvCertificates(UserName);
                            }

                            //string confirmScript2 = "alert('unable add certificates');window.location = window.location.toString();";
                            //ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "exists5", confirmScript2, true);
                            ////Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Javascript", "<script>alert('unable add certificates')</script>", false);

                        }
                        else
                        {
                            string ConfirmDuplication = "alert('Duplicate entry');window.location = window.location.toString();";
                            ScriptManager.RegisterClientScriptBlock(btnSubmit, btnSubmit.GetType(), "exist6", ConfirmDuplication, true);
                            BindGvCertificates(UserName);
                            // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Javascript", "<script>alert('Duplicate entry')</script>", false);
                        }
                    }
                }
            }


        }

        private void InsertEmpBasicInfo()
        {
            logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
            logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);

            SPSecurity.RunWithElevatedPrivileges(delegate
            {

                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {
                    if (site != null)
                    {
                        using (SPWeb web = site.OpenWeb())
                        {
                            web.AllowUnsafeUpdates = true;
                            SPList listchl = web.Lists.TryGetList(TempEmpBasicInfo);
                            SPList listDesigM = web.Lists.TryGetList("Designation");
                            SPList listDeptM = web.Lists.TryGetList("Department");
                            SPList listCountry = web.Lists.TryGetList("Country");
                            SPList listTags = web.Lists.TryGetList("ProfileTags");
                            SPList listGender = web.Lists.TryGetList("Gender");

                            if (listchl != null)
                            {
                                int itemCount;
                                SPQuery qry = new SPQuery();
                                string stringQuery = "";

                                stringQuery = string.Format(@"<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>{0}</Value></Eq></Where>", logedInUser);
                                qry.Query = stringQuery;
                                SPListItemCollection collection = listchl.GetItems(qry);
                                itemCount = collection.Count;
                                if (itemCount == 0)
                                {
                                    // bool IsValid = false;
                                    SPListItem item = listchl.Items.Add();
                                    item["Title"] = logedInUser;
                                    item[FIRSTNAME] = txtFirstName.Text;
                                    item[LASTNAME] = txtLastName.Text;
                                    item["ResidencePhoneNumber"] = txtResPhNo.Text;
                                    item["MobileNumber"] = txtMobNo.Text;
                                    item["ICQNumber"] = txtICQNo.Text;
                                    item["ExtensionNumber"] = txtExtNo.Text;
                                    item["EmpID"] = txtEmpID.Text;
                                    item["IsApprove"] = "NO";
                                    if (drpGender.SelectedValue != null && drpGender.SelectedIndex != 0)
                                    {
                                        int GenderId = Convert.ToInt32(drpGender.SelectedValue);
                                        var GenderItm = web.Lists[listGender.Title].GetItemById(GenderId);
                                        item["Gender"] = new SPFieldLookupValue(GenderItm.ID, GenderItm.Title);
                                    }

                                    if (drpDesignation.SelectedValue != null && drpDesignation.SelectedIndex != 0)
                                    {
                                        int DesigId = Convert.ToInt32(drpDesignation.SelectedValue);
                                        var DesignItm = web.Lists[listDesigM.Title].GetItemById(DesigId);
                                        item["Designation"] = new SPFieldLookupValue(DesignItm.ID, DesignItm.Title);
                                    }

                                    item["VertexEmailID"] = SPContext.Current.Web.CurrentUser;

                                    //if (ChkProfileTag.SelectedValue != null)
                                    //{  
                                    //    //foreach (SPListItem itmTags in chkprofileTags.Items)
                                    //    //{

                                    //    //    int Tagid = Convert.ToInt32(chkprofileTags.SelectedValue);
                                    //    //    var itm = web.Lists[listTags.Title].GetItemById(Tagid);
                                    //    //    item["ProfileTags"] = new SPFieldMultiChoiceValue(itm.Title);
                                    //    //}
                                    //}

                                    //SPFile file = myLibrary.Files.Add(fileName, contents, replaceExistingFiles);
                                    //file.Update();

                                    if (FuploadUserPic.HasFiles != false)
                                    {

                                        SPFile fileDetails = null;
                                        if (FuploadUserPic.PostedFile != null)
                                        {
                                            HttpPostedFile myFile = FuploadUserPic.PostedFile;
                                            fileLength = myFile.ContentLength;
                                            byte[] contents = new byte[fileLength];
                                            myFile.InputStream.Read(contents, 0, fileLength);
                                            fileName = System.IO.Path.GetFileName(FuploadUserPic.PostedFile.FileName);
                                            string fileExt = Path.GetExtension(myFile.FileName).ToLower();
                                            string fileName1 = Path.GetFileName(myFile.FileName);


                                            if (fileName1 != string.Empty)
                                            {
                                                if (fileExt == ".jpg" || fileExt == ".png")
                                                {
                                                    item.Attachments.Add(FuploadUserPic.FileName, contents);
                                                    IsValid = true;
                                                }
                                                else
                                                {
                                                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Javascript", "<script>alert('Please upload Picture of type .jpg and .png')</script>", false);
                                                    IsValid = false;
                                                }
                                            }

                                        }
                                    }
                                    if (drpDept.SelectedValue != null && drpDept.SelectedIndex != 0)
                                    {
                                        int DeptId = Convert.ToInt32(drpDept.SelectedValue);
                                        var DeptItm = web.Lists[listDeptM.Title].GetItemById(DeptId);

                                        item["Department"] = new SPFieldLookupValue(DeptItm.ID, DeptItm.Title);
                                    }
                                    SPFieldLookupValueCollection fieldValues = new SPFieldLookupValueCollection();
                                    foreach (Control ctrl in PnlProfileTags.Controls)
                                    {
                                        CheckBox cb = ctrl as CheckBox;
                                        if (cb != null)
                                        {
                                            if (cb.Checked)
                                            {
                                                int TageID = Convert.ToInt32(cb.ID.Substring(4));
                                                var TagItm = web.Lists[listTags.Title].GetItemById(TageID);

                                                fieldValues.Add(new SPFieldLookupValue(TagItm.ID, TagItm.Title));
                                            }
                                        }

                                    }
                                    item["ProfileTag"] = fieldValues;

                                    if (txtOnePageReportStartDate.Text != string.Empty)
                                    {
                                        item["DOB"] = Convert.ToDateTime(txtOnePageReportStartDate.Text);
                                    }
                                    if (drpCountry.SelectedValue != null && drpCountry.SelectedIndex != 0)
                                    {
                                        int CountryID = Convert.ToInt32(drpCountry.SelectedValue);
                                        var countryItem = web.Lists[listCountry.Title].GetItemById(CountryID);
                                        item["Country"] = new SPFieldLookupValue(countryItem.ID, countryItem.Title);
                                    }

                                    if (IsValid)
                                    {
                                        item.Update();
                                    }
                                    // item.Update();
                                }
                                else
                                {
                                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Javascript", "<script>alert('Employee Details already exist')</script>", false);
                                }
                            }


                        }

                    }
                }
            });
        }
        private void InsertEmpAdditionalInfo()
        {
            SPSecurity.RunWithElevatedPrivileges(delegate
            {
                using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                {
                    if (site != null)
                    {
                        SPWeb web = site.OpenWeb();
                        web.AllowUnsafeUpdates = true;
                        SPList list = web.Lists.TryGetList(TempEmpAdditionalInfo);
                        if (list != null)
                        {
                            int itemCount;
                            SPQuery qry = new SPQuery();
                            string stringQuery = "";

                            stringQuery = string.Format(@"<Where><Eq><FieldRef Name='UserName' /><Value Type='Text'>{0}</Value></Eq></Where>", logedInUser);

                            qry.Query = stringQuery;
                            SPListItemCollection collection = list.GetItems(qry);
                            itemCount = collection.Count;
                            if (itemCount == 0)
                            {
                                SPListItem item = list.Items.Add();
                                item["UserName"] = logedInUser;
                                item["IsApprove"] = "NO";
                                item["Overview"] = txtOverView.Text;
                                item[FORTE] = txtForte.Text;
                                item["AboutSpouse"] = txtMySpouse.Text;
                                item["MyHobbies"] = txtMyHobbies.Text;
                                item[BESTBOOK] = txtBestBooks.Text;
                                item["Inspiredme"] = txtInspiredMe.Text;
                                item["loveaboutjobs"] = txtAboutJob.Text;
                                item["Makesmetick"] = txtMakesMeTick.Text;
                                item["LazyAfternoon"] = txtLazyNon.Text;
                                item["FavoriteFoods"] = txtFavFods.Text;
                                item["BestRestaurant"] = txtBestReat.Text;
                                item["MostProudof"] = txtProudOf.Text;
                                item["InterestingThing"] = txtInterstingThings.Text;
                                item["ChangeAnythingAboutWorld"] = txtICudChgWorld.Text;
                                item["FollowSports"] = txtSptTmIFoll.Text;
                                item["FavoriteMusic"] = txtmusIListen.Text;
                                item["FavoriteTV"] = txtFavTV.Text;
                                if (IsValid)
                                {
                                    item.Update();
                                }
                            }
                            else
                            {
                                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Javascript", "<script>alert('Employee Details already exist')</script>", false);
                            }
                            web.AllowUnsafeUpdates = false;
                        }

                    }
                }
            });

        }
        private bool InsertCertificates()
        {
            bool fstatus = false;
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate
                {
                    using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                    {
                        if (site != null)
                        {
                            SPWeb web = site.OpenWeb();
                            web.AllowUnsafeUpdates = true;
                            SPList listm = web.Lists.TryGetList("Certifications");
                            SPList listchl = web.Lists.TryGetList(TempEmpCertifications);

                            if (listchl != null)
                            {
                                SPListItem item = listchl.Items.Add();
                                item["UserName"] = logedInUser;
                                item["IsApprove"] = "NO";
                                if (drpTechnology.SelectedValue != null && drpTechnology.SelectedIndex != 0)
                                {
                                    item["Technology"] = drpTechnology.SelectedValue;
                                }
                                if (drpNameOfCertification.SelectedValue != null && drpNameOfCertification.SelectedIndex != 0)
                                {
                                    int crtId = Convert.ToInt32(drpNameOfCertification.SelectedValue);
                                    var cerficationItm = web.Lists[listm.Title].GetItemById(crtId);
                                    item["Certificate"] = new SPFieldLookupValue(cerficationItm.ID, cerficationItm.Title);
                                }

                                if (txtCertificationID.Text != "")
                                {
                                    item["CertificationID"] = txtCertificationID.Text;
                                }

                                if (txtCertifiedDate.Text != "")
                                {
                                    item["CertifiedDate"] = Convert.ToDateTime(txtCertifiedDate.Text);
                                }
                                if (txtUntilDate.Text != "")
                                {
                                    item["UntilDate"] = Convert.ToDateTime(txtUntilDate.Text);
                                }
                                SPList listFY = web.Lists.TryGetList("FiscalYear");
                                string StrFY = DateTime.Now.Year.ToString();

                                SPQuery qry = new SPQuery();
                                string stringQuery = "";
                                // stringQuery = string.Format(@"<Where><And><Eq><FieldRef Name='Technology' /><Value Type='Lookup'>{0}</Value></Eq><And><Eq><FieldRef Name='Certificate' /><Value Type='Lookup'>{1}</Value></Eq><And><Eq><FieldRef Name='UserName' /><Value Type='Lookup'>{2}</Value></Eq></And></And></And></Where>", drpTechnology.SelectedValue, drpNameOfCertification.SelectedValue,logedInUser);
                                stringQuery = string.Format(@"<Where><Eq><FieldRef Name='Title' /><Value Type='Text'>{0}</Value></Eq></Where>", StrFY);
                                qry.Query = stringQuery;
                                SPListItemCollection collection = listFY.GetItems(qry);

                                //int ItmFYID =Convert.ToInt32(StrFY);
                                //SPListItem itmFY = web.Lists[listFY.Title].GetItemById(ItmFYID);

                                foreach (SPListItem items in collection)
                                {
                                    SPListItem lookupFY = listFY.GetItemById(items.ID);
                                    item["FiscalYear"] = new SPFieldLookupValue(lookupFY.ID, lookupFY.Title);
                                }
                                //  item["FiscalYear"] = DateTime.Now.Year;
                                if (FulCerificates.HasFile)
                                {

                                    //FileStream stream = new FileStream(FulCerificates.PostedFile.FileName, FileMode.Open);
                                    //byte[] byteArray = new byte[stream.Length];
                                    //stream.Read(byteArray, 0, Convert.ToInt32(stream.Length));
                                    //stream.Close();
                                    if (FulCerificates.PostedFile != null)
                                    {
                                        HttpPostedFile myFile = FulCerificates.PostedFile;
                                        fileLength = myFile.ContentLength;
                                        byte[] contents = new byte[fileLength];
                                        myFile.InputStream.Read(contents, 0, fileLength);
                                        fileName = System.IO.Path.GetFileName(FulCerificates.PostedFile.FileName);
                                        item.Attachments.Add(FulCerificates.FileName, contents);
                                    }
                                }


                                item.Update();
                                fstatus = true;
                            }
                            // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Javascript", "<script>alert('Certificates added Successfully')</script>", false);

                        }

                    }
                });
            }
            catch (Exception ex)
            {
                fstatus = false;
            }
            finally
            {
                hdnTechnology.Value = string.Empty;
                hdnNameOfCertification.Value = string.Empty;
                hdnCertificationID.Value = string.Empty;
                hdnStartDate.Value = string.Empty;
                hdnEndDate.Value = string.Empty;
                hdnAttachment.Value = string.Empty;

            }
            return fstatus;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
                logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);
                //if (HttpContext.Current.Request.QueryString["UserName"] != null)
                //{
                if (Page.Request.QueryString["UserName"] != null)
                {
                    UpdateBasicInfo(logedInUser);
                    UpdateAdditionalInfo(logedInUser);
                    string confirmScript = "alert('Employee Details updated Successfully');window.location = window.location.toString();";
                    ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "exists54", confirmScript, true);
                    // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Javascript", "<script>alert('Employee Details updated Successfully')</script>", false);

                }
                else
                {
                    bool ISUserEntry = CheckUserEntry();
                    if (!ISUserEntry)
                    {

                        InsertEmpBasicInfo();
                        if (IsValid != false)
                        {
                            InsertEmpAdditionalInfo();
                        }
                        string confirmScript = "alert('Employee Details added Successfully');window.location = window.location.toString();";
                        ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "exists54", confirmScript, true);
                        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Javascript", "<script>alert('Employee Details added Successfully')</script>", false);
                        clear();
                    }
                    else
                    {
                        UpdateBasicInfo(logedInUser);
                        UpdateAdditionalInfo(logedInUser);
                        string confirmScript = "alert('Employee Details updated Successfully');window.location = window.location.toString();";
                        ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "exists54", confirmScript, true);
                        //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Javascript", "<script>alert('Employee Details updated Successfully')</script>", false);

                    }

                }
                //}
                //else
                //{
                //    UpdateBasicInfo(logedInUser);
                //    UpdateAdditionalInfo(logedInUser);
                //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "Javascript", "<script>alert('Employee Details updated Successfully')</script>", false);


                //}
            }
            catch (Exception ex)
            { }
        }
        #region SelectByText Method
        /// <summary>
        /// Set the Selected Item of grid and populate the value into  Dropdown list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="text"></param>
        public void SelectByText(DropDownList list, string Text)
        {
            string[] strVal = Text.Split(';');
            ListItem listItemToFind = list.Items.FindByValue(strVal[0]);
            if (listItemToFind != null)
            {
                if (list.Items.Contains(listItemToFind))
                {
                    list.SelectedValue = listItemToFind.Value;
                }
            }
            else
                list.SelectedIndex = 0;
        }
        #endregion

        protected void btnhiddenCertifiDelete_Click(object sender, EventArgs e)
        {
            try
            {
                logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
                logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);
                DeleteEmpInfo();
                string confirmScript = "window.location = window.location.toString();";
                ScriptManager.RegisterClientScriptBlock(btnhiddenCertifiDelete, btnhiddenCertifiDelete.GetType(), "exists55", confirmScript, true);

            }
            catch (Exception ex)
            { }
            finally
            {
                BindGvCertificates(logedInUser);
                hdnAssignUtil.Value = "0";
            }
        }

        protected void btnhiddenCertificateEdit_Click1(object sender, EventArgs e)
        {
            try
            {
                logedInUser = SPContext.Current.Web.CurrentUser.LoginName;
                logedInUser = logedInUser.Substring(logedInUser.IndexOf("\\") + 1);
                hdnAssignUtil.Value = "0";
                int ItmiD = Convert.ToInt32(txtCerificateEdit.Text);
                hdnEditId.Value = txtCerificateEdit.Text.Trim();

                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(SPContext.Current.Web.Url))
                    {
                        if (site != null)
                        {
                            SPWeb web = site.OpenWeb();
                            web.AllowUnsafeUpdates = true;
                            SPList EmpCertificationslist = web.Lists.TryGetList("EmpCertifications");
                            SPList listTemp = web.Lists.TryGetList(TempEmpCertifications);
                            if (listTemp != null)
                            {
                                SPQuery qry = new SPQuery();
                                string stringQuery = "";
                                stringQuery = string.Format(@"<Where><Eq><FieldRef Name='ID' /><Value Type='Number'>{0}</Value></Eq></Where>", ItmiD.ToString());
                                qry.Query = stringQuery;
                                SPListItemCollection items = EmpCertificationslist.GetItems(qry);
                                List<SPListItem> itemsGenericColl = items.OfType<SPListItem>().ToList();
                                if (itemsGenericColl.Exists(x => x["ID"].ToString() == ItmiD.ToString()))
                                {

                                    SPListItem item = items.GetItemById(ItmiD);
                                    char[] delimiterChars = { ';', '#' };
                                    string[] words = items[0][5].ToString().Split(delimiterChars);
                                    char[] delimiterChars1 = { ';', '#' };
                                    string[] words1 = items[0][4].ToString().Split(delimiterChars);
                                    SelectByText(drpTechnology, words1[0].ToString());

                                    //modi Start 12-2-2015
                                    SPList ListCertifications = web.Lists["Certifications"];
                                    SPQuery qryCertifications = new SPQuery();
                                    string Stringqry = "";
                                    Stringqry = string.Format(@"<Where><Eq><FieldRef Name='Technology' /><Value Type='Lookup'>{0}</Value></Eq></Where>", words1[2]);
                                    drpNameOfCertification.DataSource = Stringqry;
                                    qryCertifications.Query = Stringqry;
                                    SPListItemCollection listitemcoll = ListCertifications.GetItems(qryCertifications);
                                    drpNameOfCertification.DataSource = listitemcoll.GetDataTable();
                                    drpNameOfCertification.DataTextField = "Title";
                                    drpNameOfCertification.DataValueField = "ID";
                                    drpNameOfCertification.DataBind();
                                    drpNameOfCertification.Items.Insert(0, "Select");
                                    //mod End 12-2-2015

                                    SelectByText(drpNameOfCertification, words[0].ToString());
                                    if (drpNameOfCertification.SelectedIndex != 0)
                                        hdnNameOfCertification.Value = drpNameOfCertification.SelectedItem.Value;
                                    else
                                        hdnNameOfCertification.Value = string.Empty;

                                    char[] delimiterCertifiedDate = { ' ' };
                                    if (items[0][8] != null)
                                    {
                                        string certificationID = items[0][8].ToString();
                                        if (certificationID != "")
                                        {
                                            txtCertificationID.Text = certificationID;
                                            hdnCertificationID.Value = txtCertificationID.Text;
                                        }
                                    }
                                    else
                                    {
                                        txtCertificationID.Text = string.Empty;
                                        hdnCertificationID.Value = string.Empty;
                                    }
                                    if (items[0][6] != null)
                                    {
                                        string[] wordsCertifiedDate = items[0][6].ToString().Split(delimiterCertifiedDate);
                                        string CertifiedDate = wordsCertifiedDate[0].ToString();
                                        if (CertifiedDate != "")
                                        {
                                            txtCertifiedDate.Text = CertifiedDate;
                                            hdnStartDate.Value = txtCertifiedDate.Text;
                                        }
                                    }
                                    else
                                    {
                                        txtCertifiedDate.Text = string.Empty;
                                        hdnStartDate.Value = string.Empty;
                                    }
                                    if (items[0][7] != null)
                                    {
                                        string[] wordsUntillDate = items[0][7].ToString().Split(delimiterCertifiedDate);
                                        string UntillDate = wordsUntillDate[0].ToString();
                                        if (UntillDate != "")
                                        {
                                            txtUntilDate.Text = UntillDate;
                                            hdnEndDate.Value = txtUntilDate.Text;
                                        }
                                    }
                                    else
                                    {
                                        txtUntilDate.Text = string.Empty;
                                        hdnEndDate.Value = string.Empty;
                                    }

                                    txtCertificateId.Text = txtCerificateEdit.Text;

                                    //if (items[0].Attachments[0] != null && items[0].Attachments[0] != string.Empty)

                                    if ((bool)items[0][23])
                                    {
                                        lblImageName.Text = items[0].Attachments[0].ToString();
                                        hdnAttachment.Value = lblImageName.Text;
                                    }
                                    else
                                    {
                                        lblImageName.Text = string.Empty;
                                        hdnAttachment.Value = string.Empty;
                                    }

                                }
                                else
                                {
                                    //templist Edit
                                    if (listTemp != null)
                                    {

                                        SPQuery qryTemp = new SPQuery();
                                        string strTempQuery = "";
                                        strTempQuery = string.Format(@"<Where><Eq><FieldRef Name='ID' /><Value Type='Number'>{0}</Value></Eq></Where>", ItmiD.ToString());
                                        qryTemp.Query = strTempQuery;
                                        SPListItemCollection itmColl = listTemp.GetItems(qryTemp);
                                        SPListItem item = itmColl.GetItemById(ItmiD);
                                        char[] delimiterChars = { ';', '#' };
                                        string[] words = itmColl[0][5].ToString().Split(delimiterChars);
                                        char[] delimiterChars1 = { ';', '#' };
                                        string[] words1 = itmColl[0][4].ToString().Split(delimiterChars);
                                        SelectByText(drpTechnology, words1[0].ToString());

                                        //modi Start 12-2-2015
                                        SPList ListCertifications = web.Lists["Certifications"];
                                        SPQuery qryCertifications = new SPQuery();
                                        string Stringqry = "";
                                        Stringqry = string.Format(@"<Where><Eq><FieldRef Name='Technology' /><Value Type='Lookup'>{0}</Value></Eq></Where>", words1[2]);
                                        drpNameOfCertification.DataSource = Stringqry;
                                        qryCertifications.Query = Stringqry;
                                        SPListItemCollection listitemcoll = ListCertifications.GetItems(qryCertifications);
                                        drpNameOfCertification.DataSource = listitemcoll.GetDataTable();
                                        drpNameOfCertification.DataTextField = "Title";
                                        drpNameOfCertification.DataValueField = "ID";
                                        drpNameOfCertification.DataBind();
                                        drpNameOfCertification.Items.Insert(0, "Select");
                                        //mod End 12-2-2015

                                        SelectByText(drpNameOfCertification, words[0].ToString());
                                        if (drpNameOfCertification.SelectedIndex != 0)
                                            hdnNameOfCertification.Value = drpNameOfCertification.SelectedItem.Value;
                                        else
                                            hdnNameOfCertification.Value = string.Empty;

                                        char[] delimiterCertifiedDate = { ' ' };
                                        if (itmColl[0][8] != null)
                                        {
                                            string certificationID = itmColl[0][8].ToString();
                                            if (certificationID != "")
                                            {
                                                txtCertificationID.Text = certificationID;
                                                hdnCertificationID.Value = txtCertificationID.Text;
                                            }
                                        }
                                        else
                                        {
                                            txtCertificationID.Text = string.Empty;
                                            hdnCertificationID.Value = string.Empty;
                                        }
                                        if (itmColl[0][6] != null)
                                        {
                                            string[] wordsCertifiedDate = itmColl[0][6].ToString().Split(delimiterCertifiedDate);
                                            string CertifiedDate = wordsCertifiedDate[0].ToString();
                                            if (CertifiedDate != "")
                                            {
                                                txtCertifiedDate.Text = CertifiedDate;
                                                hdnStartDate.Value = txtCertifiedDate.Text;
                                            }
                                        }
                                        else
                                        {
                                            txtCertifiedDate.Text = string.Empty;
                                            hdnStartDate.Value = string.Empty;
                                        }
                                        if (itmColl[0][7] != null)
                                        {
                                            string[] wordsUntillDate = itmColl[0][7].ToString().Split(delimiterCertifiedDate);
                                            string UntillDate = wordsUntillDate[0].ToString();
                                            if (UntillDate != "")
                                            {
                                                txtUntilDate.Text = UntillDate;
                                                hdnEndDate.Value = txtUntilDate.Text;
                                            }
                                        }
                                        else
                                        {
                                            txtUntilDate.Text = string.Empty;
                                            hdnEndDate.Value = string.Empty;
                                        }

                                        txtCertificateId.Text = txtCerificateEdit.Text;

                                        //if (items[0].Attachments[0] != null && items[0].Attachments[0] != string.Empty)

                                        if ((bool)itmColl[0][25])
                                        {
                                            lblImageName.Text = itmColl[0].Attachments[0].ToString();
                                            hdnAttachment.Value = lblImageName.Text;
                                        }
                                        else
                                        {
                                            lblImageName.Text = string.Empty;
                                            hdnAttachment.Value = string.Empty;
                                        }

                                    }
                                }


                            }

                            btnUpdate.Visible = true;

                        }
                    }

                });

            }
            catch (Exception ex)
            { }
        }

        protected void btnClearDetails_Click(object sender, EventArgs e)
        {
            txtEmpID.Text = string.Empty;
            drpGender.SelectedIndex = 0;
            txtOverView.Text = string.Empty;
            txtForte.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtMobNo.Text = string.Empty;
            txtResPhNo.Text = string.Empty;
            txtICQNo.Text = string.Empty;
            txtAboutJob.Text = string.Empty;
            txtBestBooks.Text = string.Empty;
            txtBestReat.Text = string.Empty;
            txtExtNo.Text = string.Empty;
            txtFavFods.Text = string.Empty;
            txtFavTV.Text = string.Empty;
            txtICudChgWorld.Text = string.Empty;
            txtInspiredMe.Text = string.Empty;
            txtInterstingThings.Text = string.Empty;
            txtLazyNon.Text = string.Empty;
            txtMakesMeTick.Text = string.Empty;
            txtmusIListen.Text = string.Empty;
            txtMyHobbies.Text = string.Empty;
            txtMySpouse.Text = string.Empty;
            txtOnePageReportStartDate.Text = string.Empty;
            txtProudOf.Text = string.Empty;
            txtSptTmIFoll.Text = string.Empty;
            txtResPhNo.Text = string.Empty;
            drpCountry.SelectedIndex = 0;
            drpDept.SelectedIndex = 0;
            drpCountry.SelectedIndex = 0;
            drpDesignation.SelectedIndex = 0;
            ClearProfileTags();
        }
        public void ClearProfileTags()
        {
            foreach (Control ctrl in PnlProfileTags.Controls)
            {
                if (ctrl.GetType() == typeof(CheckBox))
                {
                    CheckBox cb = ctrl as CheckBox;
                    cb.Checked = false;
                }

            }
        }

        protected void clear()
        {
            txtEmpID.Text = string.Empty;
            drpGender.SelectedIndex = 0;
            txtOverView.Text = string.Empty;
            txtForte.Text = string.Empty;
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtMobNo.Text = string.Empty;
            txtResPhNo.Text = string.Empty;
            txtICQNo.Text = string.Empty;
            txtAboutJob.Text = string.Empty;
            txtBestBooks.Text = string.Empty;
            txtBestReat.Text = string.Empty;
            txtExtNo.Text = string.Empty;
            txtFavFods.Text = string.Empty;
            txtFavTV.Text = string.Empty;
            txtICudChgWorld.Text = string.Empty;
            txtInspiredMe.Text = string.Empty;
            txtInterstingThings.Text = string.Empty;
            txtLazyNon.Text = string.Empty;
            txtMakesMeTick.Text = string.Empty;
            txtmusIListen.Text = string.Empty;
            txtMyHobbies.Text = string.Empty;
            txtMySpouse.Text = string.Empty;
            txtOnePageReportStartDate.Text = string.Empty;
            txtProudOf.Text = string.Empty;
            txtSptTmIFoll.Text = string.Empty;
            txtResPhNo.Text = string.Empty;
            drpCountry.SelectedIndex = 0;
            drpDept.SelectedIndex = 0;
            drpCountry.SelectedIndex = 0;
            drpDesignation.SelectedIndex = 0;
            ClearProfileTags();

        }

        protected void drpTechnology_SelectedIndexChanged1(object sender, EventArgs e)
        {

            btnUpdate.Visible = true;
            drpNameOfCertification.Items.Clear();
            hdnAssignUtil.Value = "1";
            try
            {
                SPSecurity.RunWithElevatedPrivileges(delegate()
                {
                    using (SPSite site = new SPSite(SPContext.Current.Site.Url))
                    {
                        using (SPWeb web = site.OpenWeb())
                        {
                            if (drpTechnology.SelectedIndex != 0)
                            {

                                int drpTechId = Convert.ToInt32(drpTechnology.SelectedItem.Value);
                                string drpTechText = drpTechnology.SelectedItem.Text;
                                hdnTechnology.Value = drpTechId.ToString();
                                SPList list = web.Lists["Certifications"];
                                SPQuery qry = new SPQuery();
                                string quervalue = drpTechnology.SelectedItem.Text;
                                string quey = string.Format(@"<Where><Eq><FieldRef Name='Technology' /><Value Type='Lookup'>{0}</Value></Eq></Where>", drpTechText);
                                qry.Query = quey;
                                SPListItemCollection items = list.GetItems(qry);
                                //SPListItem item = ocol.GetItemById(drpTechId);
                                drpNameOfCertification.DataSource = items.GetDataTable();
                                drpNameOfCertification.DataTextField = "Title";
                                drpNameOfCertification.DataValueField = "ID";
                                drpNameOfCertification.DataBind();
                                drpNameOfCertification.Items.Insert(0, new ListItem("Select", "0"));
                                if (drpNameOfCertification.SelectedIndex != 0)
                                    hdnNameOfCertification.Value = drpNameOfCertification.SelectedItem.Value;
                                else
                                    hdnNameOfCertification.Value = string.Empty;
                                if (txtCertificationID.Text != string.Empty)
                                    hdnCertificationID.Value = txtCertificationID.Text;
                                else
                                    hdnCertificationID.Value = string.Empty;
                                if (txtCertifiedDate.Text != string.Empty)
                                    hdnStartDate.Value = txtCertifiedDate.Text;
                                else
                                    hdnStartDate.Value = string.Empty;
                                if (txtUntilDate.Text != string.Empty)
                                    hdnEndDate.Value = txtUntilDate.Text;
                                else
                                    hdnEndDate.Value = string.Empty;
                                if (hdnAttachment.Value != "")
                                    lblImageName.Text = hdnAttachment.Value;
                                else
                                    lblImageName.Text = string.Empty;


                            }

                            else
                            {
                                hdnAssignUtil.Value = "0";
                                hdnEndDate.Value = string.Empty;
                                hdnStartDate.Value = string.Empty;
                                hdnCertificationID.Value = string.Empty;
                                hdnNameOfCertification.Value = string.Empty;
                                hdnAttachment.Value = string.Empty;
                            }
                        }
                    }
                });
            }
            catch (Exception ex)
            {

            }

        }
    }
}

