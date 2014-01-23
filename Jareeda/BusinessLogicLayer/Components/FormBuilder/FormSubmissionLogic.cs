using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.FormBuilder;
using BusinessLogicLayer.Entities.FormBuilder;
namespace BusinessLogicLayer.Components.FormBuilder
{
	/// <summary>
	/// This is a Business Logic Component Class  for FormSubmission table
	/// This class RAPs the FormSubmissionDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class FormSubmissionLogic : BusinessLogic
	{
		public FormSubmissionLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<FormSubmission> GetAll()
         {
             FormSubmissionDAC _formSubmissionComponent = new FormSubmissionDAC();
             IDataReader reader =  _formSubmissionComponent.GetAllFormSubmission().CreateDataReader();
             List<FormSubmission> _formSubmissionList = new List<FormSubmission>();
             while(reader.Read())
             {
             if(_formSubmissionList == null)
                 _formSubmissionList = new List<FormSubmission>();
                 FormSubmission _formSubmission = new FormSubmission();
                 if(reader["FormSubmissionId"] != DBNull.Value)
                     _formSubmission.FormSubmissionId = Convert.ToInt32(reader["FormSubmissionId"]);
                 if(reader["UserId"] != DBNull.Value)
                     _formSubmission.UserId = Convert.ToInt32(reader["UserId"]);
                 if(reader["IsAnonymous"] != DBNull.Value)
                     _formSubmission.IsAnonymous = Convert.ToBoolean(reader["IsAnonymous"]);
                 if(reader["SubmissionDate"] != DBNull.Value)
                     _formSubmission.SubmissionDate = Convert.ToDateTime(reader["SubmissionDate"]);
                 if(reader["IPAddress"] != DBNull.Value)
                     _formSubmission.IPAddress = Convert.ToString(reader["IPAddress"]);
                 if(reader["IsValid"] != DBNull.Value)
                     _formSubmission.IsValid = Convert.ToBoolean(reader["IsValid"]);
                 if(reader["EmailSent"] != DBNull.Value)
                     _formSubmission.EmailSent = Convert.ToBoolean(reader["EmailSent"]);
                 if(reader["SMSSent"] != DBNull.Value)
                     _formSubmission.SMSSent = Convert.ToBoolean(reader["SMSSent"]);
                 if(reader["FormDocumentID"] != DBNull.Value)
                     _formSubmission.FormDocumentID = Convert.ToInt32(reader["FormDocumentID"]);
             _formSubmission.NewRecord = false;
             _formSubmissionList.Add(_formSubmission);
             }             reader.Close();
             return _formSubmissionList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<FormSubmission> GetAllByFormDocumentId(int FormDocumentID)
        {
            FormSubmissionDAC _formSubmissionComponent = new FormSubmissionDAC();
            IDataReader reader = _formSubmissionComponent.GetAllFormSubmission("FormDocumentID = " + FormDocumentID).CreateDataReader();
            List<FormSubmission> _formSubmissionList = new List<FormSubmission>();
            while (reader.Read())
            {
                if (_formSubmissionList == null)
                    _formSubmissionList = new List<FormSubmission>();
                FormSubmission _formSubmission = new FormSubmission();
                if (reader["FormSubmissionId"] != DBNull.Value)
                    _formSubmission.FormSubmissionId = Convert.ToInt32(reader["FormSubmissionId"]);
                if (reader["UserId"] != DBNull.Value)
                    _formSubmission.UserId = Convert.ToInt32(reader["UserId"]);
                if (reader["IsAnonymous"] != DBNull.Value)
                    _formSubmission.IsAnonymous = Convert.ToBoolean(reader["IsAnonymous"]);
                if (reader["SubmissionDate"] != DBNull.Value)
                    _formSubmission.SubmissionDate = Convert.ToDateTime(reader["SubmissionDate"]);
                if (reader["IPAddress"] != DBNull.Value)
                    _formSubmission.IPAddress = Convert.ToString(reader["IPAddress"]);
                if (reader["IsValid"] != DBNull.Value)
                    _formSubmission.IsValid = Convert.ToBoolean(reader["IsValid"]);
                if (reader["EmailSent"] != DBNull.Value)
                    _formSubmission.EmailSent = Convert.ToBoolean(reader["EmailSent"]);
                if (reader["SMSSent"] != DBNull.Value)
                    _formSubmission.SMSSent = Convert.ToBoolean(reader["SMSSent"]);
                if (reader["FormDocumentID"] != DBNull.Value)
                    _formSubmission.FormDocumentID = Convert.ToInt32(reader["FormDocumentID"]);
                _formSubmission.NewRecord = false;
                _formSubmissionList.Add(_formSubmission);
            } reader.Close();
            return _formSubmissionList;
        }

        #region Insert And Update
		public bool Insert(FormSubmission formsubmission)
		{
			int autonumber = 0;
			FormSubmissionDAC formsubmissionComponent = new FormSubmissionDAC();
			bool endedSuccessfuly = formsubmissionComponent.InsertNewFormSubmission( ref autonumber,  formsubmission.UserId,  formsubmission.IsAnonymous,  formsubmission.SubmissionDate,  formsubmission.IPAddress,  formsubmission.IsValid,  formsubmission.EmailSent,  formsubmission.SMSSent,  formsubmission.FormDocumentID);
			if(endedSuccessfuly)
			{
				formsubmission.FormSubmissionId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int FormSubmissionId,  int UserId,  bool IsAnonymous,  DateTime SubmissionDate,  string IPAddress,  bool IsValid,  bool EmailSent,  bool SMSSent,  int FormDocumentID)
		{
			FormSubmissionDAC formsubmissionComponent = new FormSubmissionDAC();
			return formsubmissionComponent.InsertNewFormSubmission( ref FormSubmissionId,  UserId,  IsAnonymous,  SubmissionDate,  IPAddress,  IsValid,  EmailSent,  SMSSent,  FormDocumentID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int UserId,  bool IsAnonymous,  DateTime SubmissionDate,  string IPAddress,  bool IsValid,  bool EmailSent,  bool SMSSent,  int FormDocumentID)
		{
			FormSubmissionDAC formsubmissionComponent = new FormSubmissionDAC();
            int FormSubmissionId = 0;

			return formsubmissionComponent.InsertNewFormSubmission( ref FormSubmissionId,  UserId,  IsAnonymous,  SubmissionDate,  IPAddress,  IsValid,  EmailSent,  SMSSent,  FormDocumentID);
		}
		public bool Update(FormSubmission formsubmission ,int old_formSubmissionId)
		{
			FormSubmissionDAC formsubmissionComponent = new FormSubmissionDAC();
			return formsubmissionComponent.UpdateFormSubmission( formsubmission.UserId,  formsubmission.IsAnonymous,  formsubmission.SubmissionDate,  formsubmission.IPAddress,  formsubmission.IsValid,  formsubmission.EmailSent,  formsubmission.SMSSent,  formsubmission.FormDocumentID,  old_formSubmissionId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int UserId,  bool IsAnonymous,  DateTime SubmissionDate,  string IPAddress,  bool IsValid,  bool EmailSent,  bool SMSSent,  int FormDocumentID,  int Original_FormSubmissionId)
		{
			FormSubmissionDAC formsubmissionComponent = new FormSubmissionDAC();
			return formsubmissionComponent.UpdateFormSubmission( UserId,  IsAnonymous,  SubmissionDate,  IPAddress,  IsValid,  EmailSent,  SMSSent,  FormDocumentID,  Original_FormSubmissionId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_FormSubmissionId)
		{
			FormSubmissionDAC formsubmissionComponent = new FormSubmissionDAC();
			formsubmissionComponent.DeleteFormSubmission(Original_FormSubmissionId);
		}

        #endregion
         public FormSubmission GetByID(int _formSubmissionId)
         {
             FormSubmissionDAC _formSubmissionComponent = new FormSubmissionDAC();
             IDataReader reader = _formSubmissionComponent.GetByIDFormSubmission(_formSubmissionId);
             FormSubmission _formSubmission = null;
             while(reader.Read())
             {
                 _formSubmission = new FormSubmission();
                 if(reader["FormSubmissionId"] != DBNull.Value)
                     _formSubmission.FormSubmissionId = Convert.ToInt32(reader["FormSubmissionId"]);
                 if(reader["UserId"] != DBNull.Value)
                     _formSubmission.UserId = Convert.ToInt32(reader["UserId"]);
                 if(reader["IsAnonymous"] != DBNull.Value)
                     _formSubmission.IsAnonymous = Convert.ToBoolean(reader["IsAnonymous"]);
                 if(reader["SubmissionDate"] != DBNull.Value)
                     _formSubmission.SubmissionDate = Convert.ToDateTime(reader["SubmissionDate"]);
                 if(reader["IPAddress"] != DBNull.Value)
                     _formSubmission.IPAddress = Convert.ToString(reader["IPAddress"]);
                 if(reader["IsValid"] != DBNull.Value)
                     _formSubmission.IsValid = Convert.ToBoolean(reader["IsValid"]);
                 if(reader["EmailSent"] != DBNull.Value)
                     _formSubmission.EmailSent = Convert.ToBoolean(reader["EmailSent"]);
                 if(reader["SMSSent"] != DBNull.Value)
                     _formSubmission.SMSSent = Convert.ToBoolean(reader["SMSSent"]);
                 if(reader["FormDocumentID"] != DBNull.Value)
                     _formSubmission.FormDocumentID = Convert.ToInt32(reader["FormDocumentID"]);
             _formSubmission.NewRecord = false;             }             reader.Close();
             return _formSubmission;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			FormSubmissionDAC formsubmissioncomponent = new FormSubmissionDAC();
			return formsubmissioncomponent.UpdateDataset(dataset);
		}



	}
}
