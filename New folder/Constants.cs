using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VrtxIntranetHrApproval
{
    public class Constants
    {
        //Sharepoint Constants
        public SPWeb oweb = SPContext.Current.Web;
        public SPList lstTempEmpCerifications = SPContext.Current.Web.Lists["TempEmpCerifications"];
        public SPList lstTempEmpAdditionalInfo = SPContext.Current.Web.Lists["TempEmpAdditionalInfo"];
        public SPList lstTempEmpBasicInfo = SPContext.Current.Web.Lists["TempEmpBasicInfo"];
        public SPList lstEmpAdditionalDetails = SPContext.Current.Web.Lists["EmpAdditionalDetails"];
        public SPList lstEmpBasicInfo = SPContext.Current.Web.Lists["EmpBasicInfo"];
        public SPList lstEmpCertifications = SPContext.Current.Web.Lists["EmpCertifications"];
        public SPList lstFiscalYear = SPContext.Current.Web.Lists["FiscalYear"];
        public string loggedinuser = SPContext.Current.Web.CurrentUser.LoginName.ToString().Split('\\')[1];

        
        public string DocumentName = string.Empty;
        public string TemAttachmentName = string.Empty;
        public Stream stream;
        public string Currentyear = DateTime.Now.Year.ToString();
        public string chkselectedUserNmae = string.Empty;
        public string chkusername = string.Empty;
        public string chkCertificationID = string.Empty;
        public string chkTechnology = string.Empty;
        public string UserName = string.Empty;
        public string colValue = string.Empty;
        


        public const string emptyvalue = "";
        public const string commaValue = ",";
        public const string IsApprove = "YES";
        public const string ApprovedSuccessfully = " ApprovedSuccessfully";
        public const string NoItemsMessage = "Dont Have any UnApproved Items";
        public const string tempQuerry = "<Where><Eq><FieldRef Name='IsApprove' /><Value Type='Text'>NO</Value></Eq></Where>";

        //GridControl Ids
        public const string lblUserName = "lblUserName";
        public const string lblCertificationID = "lblCertificationID";
        public const string lblTechnology = "lblTechnology";
        //Checkboxids
        public const string chkEmpCertificationsSelect = "chkEmpCertificationsSelect";
        //FiscalYear list
        public string FiscalYear = string.Empty;

        //EmpAdditionalInfo list       
        public string AboutSpouse = string.Empty;
        public string BestBook = string.Empty;
        public string BestRestaurant = string.Empty;
        public string ChangeAnythingAboutWorld = string.Empty;
        public string FavoriteFoods = string.Empty;
        public string FavoriteMusic = string.Empty;
        public string FavoriteTV = string.Empty;
        public string FollowSports = string.Empty;
        public string FortSkillset = string.Empty;
        public string Inspiredme = string.Empty;
        public string InterestingThing = string.Empty;
        public string LazyAfternoon = string.Empty;
        public string loveaboutjobs = string.Empty;
        public string Makesmetick = string.Empty;
        public string MostProudof = string.Empty;
        public string MyHobbies = string.Empty;
        public string Overview = string.Empty;
        //EmpCertifiacations list
        public string Certificate = string.Empty;
        public string Technology = string.Empty;
        public string CertificationID = string.Empty;
        public string CertifiedDate = string.Empty;
        public string UntilDate = string.Empty;
        public string Attachment = string.Empty;
        
        //EmpBasic lsit
        public string Designation = string.Empty;
        public string Department = string.Empty;
        public string DOB = string.Empty;
        public string EmpID = string.Empty;
        public string ExtensionNumber = string.Empty;
        public string FirstName = string.Empty;
        public string Gender = string.Empty;
        public string ICQNumber = string.Empty;
        public string LastName = string.Empty;
        public string MobileNumber = string.Empty;
        public string ProfileTag = string.Empty;
        public string ResidencePhoneNumber = string.Empty;
        public string VertexEmailID = string.Empty;

    }

}
