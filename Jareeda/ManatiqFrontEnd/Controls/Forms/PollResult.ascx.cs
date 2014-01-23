using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace ManatiqFrontEnd.Controls.Forms
{
    public partial class PollResult : System.Web.UI.UserControl
    {
        public BusinessLogicLayer.Entities.FormBuilder.FormField DataSource { get; set; }
        public PollResult()
        {

        }
        public PollResult(int pollID)
        {
            DataSource = new BusinessLogicLayer.Components.FormBuilder.FormFieldLogic().GetByID(pollID);
            DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public new void DataBind()
        {
            PreRender += new EventHandler(Custom_Controls_VoteResult_PreRender);
        }
        void Custom_Controls_VoteResult_PreRender(object sender, EventArgs e)
        {
            RptrResult.DataSource = DataSource.FormFieldValues;
            RptrResult.DataBind();
            int votesCount = DataSource.TotalFieldAnswers;
            QuestionTitle.InnerText = DataSource.Title;
            LtrlVotesCounter.Text = votesCount.ToString();
            foreach (RepeaterItem item in RptrResult.Items)
            {
                ((HtmlImage)item.FindControl("percentImage")).Src = "~/Images/poll-result-graph.gif";
                if (DataSource.TotalFieldAnswers != 0)
                {
                    ((Literal)item.FindControl("LtrlPercent")).Text = ((float)(((float)DataSource.FormFieldValues[item.ItemIndex].TotalFieldAnswers / votesCount) * 100f)).ToString("f1");
                    ((HtmlImage)item.FindControl("percentImage")).Style["Width"] = ((int)(((float)DataSource.FormFieldValues[item.ItemIndex].TotalFieldAnswers / (float)votesCount) * 100) * 160f / 100f).ToString() + "px";
                }
                else
                {
                    ((Literal)item.FindControl("LtrlPercent")).Text = "0";
                    ((HtmlImage)item.FindControl("percentImage")).Style["Width"] = "0px";
                }
            }
        }
    }
}