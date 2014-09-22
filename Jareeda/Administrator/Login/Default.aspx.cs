using CommonWeb.Security;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Linq.Expressions;

namespace Administrator.Login
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            //if (!String.IsNullOrEmpty(returnUrl))
            //{
            //    RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            //}
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (SecurityManager.doLogin(this, txtusername.Text, txtpassword.Text))
                {
                    CreateAndLoginUser(txtusername.Text, SecurityManager.getUser(this).Email);
                }
                    
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }

        private void CreateAndLoginUser(string username, string email)
        {
            Session["dummy"] = "dummy";
            if (!IsValid)
            {
                return;
            }
            var manager = new UserManager();
            var user = new ApplicationUser() { UserName = username, Email = email, Id = Guid.NewGuid().ToString() };
            var userM = (from y in manager.Users where y.UserName == username select y).FirstOrDefault();
            if(userM == null)
            {
                IdentityResult result = manager.Create(user);
                if (result.Succeeded)
                {
                    IdentityHelper.SignIn(manager, user, isPersistent: false);
                    IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                    return;
                }
                AddErrors(result);
            }
            else
            {
                IdentityHelper.SignIn(manager, userM, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
                return;
            }
            
            
            
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}