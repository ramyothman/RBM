using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using System.Linq.Expressions;
using CommonWeb.Common;
using System.Threading;
using CommonWeb.Security;

namespace Administrator.Controls.Common
{
    public partial class BootstrapMenu : System.Web.UI.UserControl
    {
        List<BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem> menuList = new List<BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem>();
        List<BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem> menuListLeft = new List<BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Thread.CurrentThread.CurrentUICulture.Name.Contains("ar"))
                {
                    menuList = BusinessLogicLayer.Common.MenuEntityItemLogic.GetAllParentItemsForItemId(88);
                }
                else
                {
                    menuList = BusinessLogicLayer.Common.MenuEntityItemLogic.GetAllParentItemsForItemId(Convert.ToInt32(BusinessLogicLayer.Common.AdminMenu));
                }
                
                MainMenuRepeater.DataSource = menuList;
                MainMenuRepeater.DataBind();

                if (SecurityManager.isLogged(this.Page))
                {
                    UserNameSpan.InnerText = SecurityManager.getUser(this.Page).UserName;
                    AccountLogout.Visible = true;
                    //AccountLogin.Visible = true;
                }
                //MainMenuRepeaterLeft.DataSource = menuListLeft;
                //MainMenuRepeaterLeft.DataBind();
            }
        }


        #region Helper Methods
        public int ChildCounter = 1;
        public int CountChilds = 0;
        public List<BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem> GetChildList(int id)
        {
            List<BusinessLogicLayer.Entities.ContentManagement.MenuEntityItem> details = BusinessLogicLayer.Common.MenuEntityItemLogic.GetAllByParent(id);
            return details;
        }
        public string GetClass(int id)
        {
            var item = (from x in menuList where x.MenuEntityItemId == id select x).FirstOrDefault();
            string result = "";
            if (item != null)
            {

                if (!string.IsNullOrEmpty(item.PagePath) && item.PagePath != "#")
                {
                    result = item.PagePath;
                    if (Tools.getWebsiteUrl(this.Page).Contains(item.PagePath))
                        result = "current";
                }
                if (item.ChildItems.Count > 0)
                {
                    result += " main-drop";
                }


            }
            return result;
        }
        public string GetText(int id)
        {
            var item = (from x in menuList where x.MenuEntityItemId == id select x).FirstOrDefault();
            string result = "";
            if (item != null)
            {
                result = item.Name;
            }
            return result;
        }
        public string GetLink(int id)
        {
            //return "#";
            var item = (from x in menuList where x.MenuEntityItemId == id select x).FirstOrDefault();
            string result = "";
            if (item != null)
            {
                if (!string.IsNullOrEmpty(item.PagePath) && item.PagePath != "#")
                {
                    string pagePath = item.PagePath;
                    if (item.PagePath.Contains("Section="))
                    {
                        string[] sp = pagePath.Split('=');
                        int secId = 0;
                        Int32.TryParse(sp[sp.Length - 1], out secId);
                        if (secId != 0)
                        {
                            BusinessLogicLayer.Entities.ContentManagement.SiteSection section = BusinessLogicLayer.Common.SiteSectionLogic.GetByID(secId);
                            if (section != null)
                            {
                                if (!string.IsNullOrEmpty(section.Alias))
                                    pagePath = pagePath.Replace("Section=" + secId, section.Alias);
                            }
                        }
                    }
                    result = pagePath;
                }
            }
            return result;
        }

        public string GetLink(int id, int childId)
        {
            //return "#";
            var item = (from x in menuList where x.MenuEntityItemId == id select x).FirstOrDefault();
            string result = "";
            if (item != null)
            {
                var child = (from x in item.ChildItems where x.MenuEntityItemId == childId select x).FirstOrDefault();
                if (child != null)
                {
                    if (!string.IsNullOrEmpty(child.PagePath) && child.PagePath != "#")
                    {
                        string pagePath = child.PagePath;
                        if (item.PagePath.Contains("Section="))
                        {
                            string[] sp = pagePath.Split('=');
                            int secId = 0;
                            Int32.TryParse(sp[sp.Length - 1], out secId);
                            if (secId != 0)
                            {
                                BusinessLogicLayer.Entities.ContentManagement.SiteSection section = BusinessLogicLayer.Common.SiteSectionLogic.GetByID(secId);
                                if (section != null)
                                {
                                    if (!string.IsNullOrEmpty(section.Alias))
                                        pagePath = pagePath.Replace("Section=" + secId, section.Alias);
                                }
                            }
                        }
                        result = pagePath;
                    }
                }
            }

            return result;
        }

        public int GetChildCount(int id)
        {
            var item = (from x in menuList where x.MenuEntityItemId == id select x).FirstOrDefault();
            int result = 0;
            if (item != null)
            {
                result = item.ChildItems.Count;
            }
            CountChilds = result;
            return result;
        }


        public string GetClassLeft(int id)
        {
            var item = (from x in menuListLeft where x.MenuEntityItemId == id select x).FirstOrDefault();
            string result = "";
            if (item != null)
            {
                if (!string.IsNullOrEmpty(item.PagePath) && item.PagePath != "#")
                {
                    result = item.PagePath;
                    if (Tools.getWebsiteUrl(this.Page).Contains(item.PagePath))
                        result = "current";
                }

            }
            return result;
        }
        public string GetTextLeft(int id)
        {
            var item = (from x in menuListLeft where x.MenuEntityItemId == id select x).FirstOrDefault();
            string result = "";
            if (item != null)
            {
                result = item.Name;
            }
            return result;
        }
        public string GetLinkLeft(int id)
        {
            return "#";
            var item = (from x in menuListLeft where x.MenuEntityItemId == id select x).FirstOrDefault();
            string result = "";
            if (item != null)
            {
                if (!string.IsNullOrEmpty(item.PagePath) && item.PagePath != "#")
                    result = item.PagePath;
            }
            return result;
        }
        #endregion
    }
}