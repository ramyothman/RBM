using ManatiqFrontEnd.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //LayoutManager manager = new LayoutManager();
            //_Masters.Master master = this.Master as _Masters.Master;
            //if (master != null)
            //{
            //    manager.Holders = master.ContentPlaceHolderMain;
            //    manager.LoadControls(this, 71);
            //}
            //if (!IsPostBack)
            {
                PageManager manager = new PageManager();
                _Masters.Master master = this.Master as _Masters.Master;
                if (master != null)
                {
                    manager.Holders = master.ContentPlaceHolderMain;
                    int SectionID = 0;

                    string code = Request["Section"];
                    if (string.IsNullOrEmpty(code))
                    {
                        if (Page.RouteData.Values["sectionName"] != null)
                        {
                            code = Page.RouteData.Values["sectionName"].ToString();
                            if (!string.IsNullOrEmpty(code))
                            {
                                code.Replace("-", " ");
                                BusinessLogicLayer.Entities.ContentManagement.SiteSection section = BusinessLogicLayer.Common.SiteSectionLogic.GetByAlias(code);
                                if(section != null)
                                    SectionID = section.SiteSectionId;
                            }
                        }
                    }
                    else
                    {
                        Int32.TryParse(code, out SectionID);
                    }
                    manager.LoadControls(this, SectionID, 1);
                }

                //string str = BusinessLogicLayer.Common.ContentDomain;
            }

        }
    }
}