using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.FormBuilder;
using BusinessLogicLayer.Entities.FormBuilder;
namespace BusinessLogicLayer.Components.FormBuilder
{
	/// <summary>
	/// This is a Business Logic Component Class  for FormDocument table
	/// This class RAPs the FormDocumentDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class FormDocumentLogic : BusinessLogic
	{
		public FormDocumentLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<FormDocument> GetAll()
         {
             FormDocumentDAC _formDocumentComponent = new FormDocumentDAC();
             IDataReader reader =  _formDocumentComponent.GetAllFormDocument().CreateDataReader();
             List<FormDocument> _formDocumentList = new List<FormDocument>();
             while(reader.Read())
             {
             if(_formDocumentList == null)
                 _formDocumentList = new List<FormDocument>();
                 FormDocument _formDocument = new FormDocument();
                 if(reader["FormDocumentID"] != DBNull.Value)
                     _formDocument.FormDocumentID = Convert.ToInt32(reader["FormDocumentID"]);
                 if(reader["FormDocumentStatusID"] != DBNull.Value)
                     _formDocument.FormDocumentStatusID = Convert.ToInt32(reader["FormDocumentStatusID"]);
                 if(reader["Title"] != DBNull.Value)
                     _formDocument.Title = Convert.ToString(reader["Title"]);
                 if(reader["Description"] != DBNull.Value)
                     _formDocument.Description = Convert.ToString(reader["Description"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _formDocument.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["EndDate"] != DBNull.Value)
                     _formDocument.EndDate = Convert.ToDateTime(reader["EndDate"]);
                 if(reader["ConfirmationText"] != DBNull.Value)
                     _formDocument.ConfirmationText = Convert.ToString(reader["ConfirmationText"]);
                 if(reader["CreatorID"] != DBNull.Value)
                     _formDocument.CreatorID = Convert.ToInt32(reader["CreatorID"]);
                 if(reader["CreationDate"] != DBNull.Value)
                     _formDocument.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                 if(reader["SendEmail"] != DBNull.Value)
                     _formDocument.SendEmail = Convert.ToBoolean(reader["SendEmail"]);
                 if(reader["SendSMS"] != DBNull.Value)
                     _formDocument.SendSMS = Convert.ToBoolean(reader["SendSMS"]);
                 if(reader["AllowModify"] != DBNull.Value)
                     _formDocument.AllowModify = Convert.ToBoolean(reader["AllowModify"]);
             _formDocument.NewRecord = false;
             _formDocumentList.Add(_formDocument);
             }             reader.Close();
             return _formDocumentList;
         }

        #region Insert And Update
		public bool Insert(FormDocument formdocument)
		{
			int autonumber = 0;
			FormDocumentDAC formdocumentComponent = new FormDocumentDAC();
			bool endedSuccessfuly = formdocumentComponent.InsertNewFormDocument( ref autonumber,  formdocument.FormDocumentStatusID,  formdocument.Title,  formdocument.Description,  formdocument.StartDate,  formdocument.EndDate,  formdocument.ConfirmationText,  formdocument.CreatorID,  formdocument.CreationDate,  formdocument.SendEmail,  formdocument.SendSMS,  formdocument.AllowModify);
			if(endedSuccessfuly)
			{
				formdocument.FormDocumentID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int FormDocumentID,  int FormDocumentStatusID,  string Title,  string Description,  DateTime StartDate,  DateTime EndDate,  string ConfirmationText,  int CreatorID,  DateTime CreationDate,  bool SendEmail,  bool SendSMS,  bool AllowModify)
		{
			FormDocumentDAC formdocumentComponent = new FormDocumentDAC();
			return formdocumentComponent.InsertNewFormDocument( ref FormDocumentID,  FormDocumentStatusID,  Title,  Description,  StartDate,  EndDate,  ConfirmationText,  CreatorID,  CreationDate,  SendEmail,  SendSMS,  AllowModify);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int FormDocumentStatusID,  string Title,  string Description,  DateTime StartDate,  DateTime EndDate,  string ConfirmationText,  int CreatorID,  DateTime CreationDate,  bool SendEmail,  bool SendSMS,  bool AllowModify)
		{
			FormDocumentDAC formdocumentComponent = new FormDocumentDAC();
            int FormDocumentID = 0;

			return formdocumentComponent.InsertNewFormDocument( ref FormDocumentID,  FormDocumentStatusID,  Title,  Description,  StartDate,  EndDate,  ConfirmationText,  CreatorID,  CreationDate,  SendEmail,  SendSMS,  AllowModify);
		}
		public bool Update(FormDocument formdocument ,int old_formDocumentID)
		{
			FormDocumentDAC formdocumentComponent = new FormDocumentDAC();
			return formdocumentComponent.UpdateFormDocument( formdocument.FormDocumentStatusID,  formdocument.Title,  formdocument.Description,  formdocument.StartDate,  formdocument.EndDate,  formdocument.ConfirmationText,  formdocument.CreatorID,  formdocument.CreationDate,  formdocument.SendEmail,  formdocument.SendSMS,  formdocument.AllowModify,  old_formDocumentID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int FormDocumentStatusID,  string Title,  string Description,  DateTime StartDate,  DateTime EndDate,  string ConfirmationText,  int CreatorID,  DateTime CreationDate,  bool SendEmail,  bool SendSMS,  bool AllowModify,  int Original_FormDocumentID)
		{
			FormDocumentDAC formdocumentComponent = new FormDocumentDAC();
			return formdocumentComponent.UpdateFormDocument( FormDocumentStatusID,  Title,  Description,  StartDate,  EndDate,  ConfirmationText,  CreatorID,  CreationDate,  SendEmail,  SendSMS,  AllowModify,  Original_FormDocumentID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_FormDocumentID)
		{
			FormDocumentDAC formdocumentComponent = new FormDocumentDAC();
			formdocumentComponent.DeleteFormDocument(Original_FormDocumentID);
		}

        #endregion
         public FormDocument GetByID(int _formDocumentID)
         {
             FormDocumentDAC _formDocumentComponent = new FormDocumentDAC();
             IDataReader reader = _formDocumentComponent.GetByIDFormDocument(_formDocumentID);
             FormDocument _formDocument = null;
             while(reader.Read())
             {
                 _formDocument = new FormDocument();
                 if(reader["FormDocumentID"] != DBNull.Value)
                     _formDocument.FormDocumentID = Convert.ToInt32(reader["FormDocumentID"]);
                 if(reader["FormDocumentStatusID"] != DBNull.Value)
                     _formDocument.FormDocumentStatusID = Convert.ToInt32(reader["FormDocumentStatusID"]);
                 if(reader["Title"] != DBNull.Value)
                     _formDocument.Title = Convert.ToString(reader["Title"]);
                 if(reader["Description"] != DBNull.Value)
                     _formDocument.Description = Convert.ToString(reader["Description"]);
                 if(reader["StartDate"] != DBNull.Value)
                     _formDocument.StartDate = Convert.ToDateTime(reader["StartDate"]);
                 if(reader["EndDate"] != DBNull.Value)
                     _formDocument.EndDate = Convert.ToDateTime(reader["EndDate"]);
                 if(reader["ConfirmationText"] != DBNull.Value)
                     _formDocument.ConfirmationText = Convert.ToString(reader["ConfirmationText"]);
                 if(reader["CreatorID"] != DBNull.Value)
                     _formDocument.CreatorID = Convert.ToInt32(reader["CreatorID"]);
                 if(reader["CreationDate"] != DBNull.Value)
                     _formDocument.CreationDate = Convert.ToDateTime(reader["CreationDate"]);
                 if(reader["SendEmail"] != DBNull.Value)
                     _formDocument.SendEmail = Convert.ToBoolean(reader["SendEmail"]);
                 if(reader["SendSMS"] != DBNull.Value)
                     _formDocument.SendSMS = Convert.ToBoolean(reader["SendSMS"]);
                 if(reader["AllowModify"] != DBNull.Value)
                     _formDocument.AllowModify = Convert.ToBoolean(reader["AllowModify"]);
             _formDocument.NewRecord = false;             }             reader.Close();
             return _formDocument;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			FormDocumentDAC formdocumentcomponent = new FormDocumentDAC();
			return formdocumentcomponent.UpdateDataset(dataset);
		}



	}
}
