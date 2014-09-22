using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.General
{
    public partial class Weather : BaseControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                List<Code.WeatherDetails> details = Code.Weather.GetWeather("");
                WeatherRepeater.DataSource = details;
                WeatherRepeater.DataBind();
                WeatherTabsRepeater.DataSource = details;
                WeatherTabsRepeater.DataBind();
                LoadJavaScript();
            }

            if (IsPostBack && !this.Page.IsCallback)
            {
                LoadJavaScript();
            }

            if (!IsFirst)
                MainBlockContainer.Attributes.Add("class", "aside-block mrg-top ");
            else
                MainBlockContainer.Attributes.Add("class", "aside-block ");
        }

        void LoadJavaScript()
        {

            string js = @" $(function () { 
                $('#" + this.weather2.ClientID + @"').tabs();   
             

 });";

            this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "WeatherBlock" + this.ID, js, true);
        }
        int indexCounter = 0;
        public int IndexCounter
        {
            get
            {
                if (indexCounter == 3) indexCounter = 0;
                return indexCounter++;
            }
        }

        public string IsVisibleFirst
        {
            get { return indexCounter == 1? " visible" : ""; }
        }

        public string IsActiveFirst
        {
            get { return indexCounter == 1 ? " active" : ""; }
        }
    }
}