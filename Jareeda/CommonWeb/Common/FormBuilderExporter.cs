using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BusinessLogicLayer.Entities;
using System.Linq.Expressions;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using BusinessLogicLayer.Entities.FormBuilder;
namespace CommonWeb.Common
{
    public enum BuilderExportType
    {
        Excel,
        DataTable
    }
    public class FormBuilderExporter
    {
        public static DataTable ExportToDataTable(FormDocument document)
        {
            if (document == null)
                return null;
            DataTable result = new DataTable();
            foreach (FormField q in document.FormFields)
            {
                
                if (q.FormFieldTypeId == 6)
                {
                    List<FormFieldValue> FormFieldvalues = new BusinessLogicLayer.Components.FormBuilder.FormFieldValueLogic().GetAllByFormFieldId(q.FormFieldId);
                    foreach (FormFieldValue v in FormFieldvalues)
                    {
                        DataColumn col = new DataColumn(v.FieldValue);
                        col.ExtendedProperties.Add("TypeID", q.FormFieldTypeId);
                        col.Caption = String.Format("{0},{1}", q.FormFieldId, v.FormFieldValueId);
                        result.Columns.Add(col);
                    }
                }
                else
                {
                    DataColumn col = new DataColumn(q.Title);
                    col.ExtendedProperties.Add("TypeID", q.FormFieldTypeId);
                    col.Caption = q.FormFieldId.ToString();
                    result.Columns.Add(col);
                }


            }
            DataColumn colIsAnonymous = new DataColumn("IsAnonymous_System");
            colIsAnonymous.Caption = "IsAnonymous_System";
            DataColumn colFirstName = new DataColumn("UserDisplayName_System");
            colFirstName.Caption = "UserDisplayName_System";
            DataColumn colUserName = new DataColumn("UserName_System");
            colUserName.Caption = "UserName_System";
            result.Columns.Add(colIsAnonymous);
            //result.Columns.Add(colFirstName);
            result.Columns.Add(colUserName);
            List<FormSubmissionAnswer> answers = new BusinessLogicLayer.Components.FormBuilder.FormSubmissionAnswerLogic().ViewSubmissionAnswers(document.FormDocumentID);
            var submissions = (from x in answers select x.FormSubmissionId).Distinct();
            foreach (int submission in submissions)
            {
                DataRow row = result.NewRow();
                var userSubmission = (from x in answers where x.FormSubmissionId == submission select x).FirstOrDefault();
                foreach (DataColumn col in result.Columns)
                {
                    switch (col.Caption)
                    {
                        case "IsAnonymous_System":
                            row[col.ColumnName] = userSubmission.FormSubmission.IsAnonymous;
                            break;
                        case "UserName_System":
                            row[col.ColumnName] = userSubmission.FormSubmission.User.Username;
                            break;
                        //case "UserDisplayName_System":
                        //    row[col.ColumnName] = userSubmission.UserDisplayName;
                        //    break;
                        default:
                            if (col.Caption.Contains(","))
                            {
                                string[] splitResults = col.Caption.Split(',');

                                var answerResult = from x in answers where x.FormSubmissionId == submission && x.FormFieldId == Convert.ToInt32(splitResults[0]) && x.FormFieldValueId == Convert.ToInt32(splitResults[1]) select x;
                                string resultText = "";
                                int count = 1;
                                foreach (FormSubmissionAnswer a in answerResult)
                                {
                                    if (count > 1)
                                        resultText += ",";
                                    resultText += a.Answer;
                                }
                                row[col.ColumnName.ToString()] = resultText;
                            }
                            else
                            {
                                var answerResult = from x in answers where x.FormSubmissionId == submission && x.FormFieldId == Convert.ToInt32(col.Caption) select x;
                                string resultText = "";
                                int count = 1;
                                foreach (FormSubmissionAnswer a in answerResult)
                                {
                                    if (count > 1)
                                        resultText += ",";
                                    resultText += a.Answer;
                                }
                                row[col.ColumnName.ToString()] = resultText;
                            }
                            break;
                    }
                    
                }
                result.Rows.Add(row);
            }

            foreach (FormField q in document.FormFields)
            {

                if (q.FormFieldTypeId == 6)
                {
                    List<FormFieldValue> FormFieldvalues = new BusinessLogicLayer.Components.FormBuilder.FormFieldValueLogic().GetAllByFormFieldId(q.FormFieldId);
                    foreach (FormFieldValue v in FormFieldvalues)
                    {
                        string cap = v.FieldValue;
                        result.Columns[cap].Caption = v.FieldValue;
                        //DataColumn col = new DataColumn(v.FieldValue);
                        //col.ExtendedProperties.Add("TypeID", q.FormFieldTypeId);
                        //col.Caption = String.Format("{0},{1}", q.FormFieldId, v.FormFieldValueId);
                        //result.Columns.Add(col);
                    }
                }
                else
                {
                    string cap = q.Title;
                    result.Columns[cap].Caption = q.Title;
                    //DataColumn col = new DataColumn(q.Title);
                    //col.ExtendedProperties.Add("TypeID", q.FormFieldTypeId);
                    //col.Caption = 
                    //result.Columns.Add(col);
                }


            }
            return result;
        }

        public static void ExportToExcel(System.Web.UI.Page page,FormDocument document,string fileName)
        {
            DataTable dt = ExportToDataTable(document);
            page.Response.Clear();
            page.Response.AddHeader("content-disposition", String.Format("attachment;filename={0}", fileName));
            page.Response.ContentType = "application/vnd.ms-excel";

            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);
            DataGrid dataExportExcel = new DataGrid();
            dataExportExcel.DataSource = dt;
            dataExportExcel.DataBind();
            dataExportExcel.RenderControl(htmlWrite);
            StringBuilder sbResponseString = new StringBuilder();
            sbResponseString.Append(String.Format("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:excel\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><meta http-equiv=\"Content-Type\" content=\"text/html;charset=unicode-1200\"><!--[if gte mso 9]><xml><x:ExcelWorkbook><x:ExcelWorksheets><x:ExcelWorksheet><x:Name>FormBuilder</x:Name><x:WorksheetOptions><x:Panes></x:Panes></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head> <body>"));
            sbResponseString.Append(stringWriter + "</body></html>");
            page.Response.Write(sbResponseString.ToString());
            page.Response.End();
        }
    }
}