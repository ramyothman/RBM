using Administrator.Code;
using CommonWeb.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.Builder.FormBuilder
{
    public partial class View : AdminBasePage
    {
        public System.Data.DataTable MainData
        {
            set { Session["MainFormData"] = value; }
            get
            {
                if (Session["MainFormData"] == null)
                {
                    int id = Convert.ToInt32(Request["code"]);
                    BusinessLogicLayer.Entities.FormBuilder.FormDocument document = new BusinessLogicLayer.Components.FormBuilder.FormDocumentLogic().GetByID(id);
                    //grid.DataSource = Code.FormBuilderExporter.ExportToDataTable(document);
                    //grid.DataBind();
                    FormTitle.InnerText = document.Title;
                    System.Data.DataTable table = FormBuilderExporter.ExportToDataTable(document);
                    Session["MainFormData"] = table;
                }
                return Session["MainFormData"] as System.Data.DataTable;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                MainData = null;
            FormViewerGrid.DataSource = MainData;
            FormViewerGrid.DataBind();
            FormViewerGrid.FilterEnabled = true;
        }

        protected void btnDownloadList_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request["code"]);
            BusinessLogicLayer.Entities.FormBuilder.FormDocument document = new BusinessLogicLayer.Components.FormBuilder.FormDocumentLogic().GetByID(id);
            ASPxGridViewExporter1.WriteXlsToResponse(document.Title + "-" + DateTime.Today.Day + "-" + DateTime.Today.Month + "-" + DateTime.Today.Year + ".xls");
        }
    }
}