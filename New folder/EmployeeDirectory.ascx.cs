using System;
using System.ComponentModel;
using System.Web.UI.WebControls.WebParts;

namespace EmpDirectory.EmployeeDirectory
{
    [ToolboxItemAttribute(false)]
    public partial class EmployeeDirectory : WebPart
    {
        // Uncomment the following SecurityPermission attribute only when doing Performance Profiling on a farm solution
        // using the Instrumentation method, and then remove the SecurityPermission attribute when the code is ready
        // for production. Because the SecurityPermission attribute bypasses the security check for callers of
        // your constructor, it's not recommended for production purposes.
        // [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Assert, UnmanagedCode = true)]
        public EmployeeDirectory()
        {
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            InitializeControl();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        //protected void printContent_Click(object sender, EventArgs e)
        //{

        //    Context.Response.AddHeader("Content-Disposition", "attachment; filename=ResourceTimesheet.pdf");
        //    Context.Response.AddHeader("Content-Length", printcontent.Length.ToString());
        //    Context.Response.ContentType = "application/pdf";
        //    Context.Response.BinaryWrite(printcontent);
        //    Context.Response.Flush();
        //    Context.Response.End();

        //}
    }
}
