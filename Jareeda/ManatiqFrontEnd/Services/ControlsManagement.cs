using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Text.RegularExpressions;


namespace Portal
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class ControlsManagement : System.Web.Services.WebService
    {
        public ControlsManagement()
        {
            //Uncomment the following line if using designed components 
            //InitializeComponent(); 
        }
        [WebMethod]
        public string GetPollResultToPage(int pollID, string controlPath, Page page)
        {
            // Create instance of the page
            

            //Clean up code and return html from Loaded control
            return CleanHtml(ExecuteControl(page, LoadControl(controlPath, page, pollID))).Replace("VIEWSTATE", "");
        }
        [WebMethod]
        public string GetPollResult(int pollID, string controlPath)
        {
            // Create instance of the page
            Page page = new Page();

            //Clean up code and return html from Loaded control
            return CleanHtml(ExecuteControl(page, LoadControl(controlPath, page, pollID))).Replace("VIEWSTATE", "");
        }

        private UserControl LoadControl(string userControlPath, Page page, params object[] constructorParameters)
        {
            List<Type> constParamTypes = new List<Type>();
            foreach (object constParam in constructorParameters)
                constParamTypes.Add(constParam.GetType());

            UserControl userControl = page.LoadControl(userControlPath) as UserControl;

            // Find the relevant constructor
            System.Reflection.ConstructorInfo constructor = userControl.GetType().BaseType.GetConstructor(constParamTypes.ToArray());

            //And then call the relevant constructor
            if (constructor == null)
                throw new MemberAccessException("The requested constructor was not found on : " + userControl.GetType().BaseType.ToString());
            else
                constructor.Invoke(userControl, constructorParameters);

            // Finally return the fully initialized UC
            return userControl;
        }

        private string ExecuteControl(Page page, UserControl userControl)
        {
            //Form control is mandatory on page control to process User Controls
            HtmlForm form = new HtmlForm();

            //Disabled ViewState- If required
            page.EnableViewState = false;
            form.EnableViewState = false;
            userControl.EnableViewState = false;

            //Add user control to the form
            form.Controls.Add(userControl);

            //Add form to the page
            page.Controls.Add(form);

            //Write the control Html to text writer
            StringWriter textWriter = new StringWriter();

            //Execute page on server 
            HttpContext.Current.Server.Execute(page, textWriter, false);

            //Return the textWriter
            return textWriter.ToString();
        }

        /// <summary>
        /// Removes Form tags using Regular Expression
        /// </summary>
        private string CleanHtml(string html)
        {
            return Regex.Replace(html, @"<[/]?(form|[ovwxp]:\w+)[^>]*?>", "", RegexOptions.IgnoreCase);
        }
    }
}
