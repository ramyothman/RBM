using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd._Masters
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        public string GetDate(DateTime d)
        {
            DateTime dt = BusinessLogicLayer.Common.ArticleLogic.GetLast(BusinessLogicLayer.Common.ManatiqID);
            TimeSpan ts = DateTime.Now.Subtract(dt);
            string x = "";
            if (ts.Hours == 0)
            {
                x = CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GregToHijriCompleteWithDay(d)) + " - " + CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GetGreggCompleteByDate(d));
                x += " آخر تحديث منذ " + ts.Minutes + " دقيقة ";
            }
            else
            {
                x = CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GregToHijriCompleteWithDay(d)) + " - " + CommonWeb.Common.BasePage.TranslateNumerals(CommonWeb.Common.BasePage.GetGreggCompleteByDate(d));
                x += " آخر تحديث منذ " + ts.Hours + " ساعة و " + ts.Minutes + " دقيقة ";
            }
            
            return  x;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Search/7-" + txtSearchText.Value);
        }
    }
}