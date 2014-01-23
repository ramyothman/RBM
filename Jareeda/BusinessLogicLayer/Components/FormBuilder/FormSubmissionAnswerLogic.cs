using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.FormBuilder;
using BusinessLogicLayer.Entities.FormBuilder;
namespace BusinessLogicLayer.Components.FormBuilder
{
	/// <summary>
	/// This is a Business Logic Component Class  for FormSubmissionAnswer table
	/// This class RAPs the FormSubmissionAnswerDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class FormSubmissionAnswerLogic : BusinessLogic
	{
		public FormSubmissionAnswerLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<FormSubmissionAnswer> GetAll()
         {
             FormSubmissionAnswerDAC _formSubmissionAnswerComponent = new FormSubmissionAnswerDAC();
             IDataReader reader =  _formSubmissionAnswerComponent.GetAllFormSubmissionAnswer().CreateDataReader();
             List<FormSubmissionAnswer> _formSubmissionAnswerList = new List<FormSubmissionAnswer>();
             while(reader.Read())
             {
             if(_formSubmissionAnswerList == null)
                 _formSubmissionAnswerList = new List<FormSubmissionAnswer>();
                 FormSubmissionAnswer _formSubmissionAnswer = new FormSubmissionAnswer();
                 if(reader["FormSubmissionAnswerId"] != DBNull.Value)
                     _formSubmissionAnswer.FormSubmissionAnswerId = Convert.ToInt32(reader["FormSubmissionAnswerId"]);
                 if(reader["FormSubmissionId"] != DBNull.Value)
                     _formSubmissionAnswer.FormSubmissionId = Convert.ToInt32(reader["FormSubmissionId"]);
                 if(reader["FormFieldId"] != DBNull.Value)
                     _formSubmissionAnswer.FormFieldId = Convert.ToInt32(reader["FormFieldId"]);
                 if(reader["Answer"] != DBNull.Value)
                     _formSubmissionAnswer.Answer = Convert.ToString(reader["Answer"]);
                 if(reader["FormFieldColumnId"] != DBNull.Value)
                     _formSubmissionAnswer.FormFieldColumnId = Convert.ToInt32(reader["FormFieldColumnId"]);
                 if(reader["FormFieldValueId"] != DBNull.Value)
                     _formSubmissionAnswer.FormFieldValueId = Convert.ToInt32(reader["FormFieldValueId"]);
                 if(reader["Grade"] != DBNull.Value)
                     _formSubmissionAnswer.Grade = Convert.ToInt32(reader["Grade"]);
             _formSubmissionAnswer.NewRecord = false;
             _formSubmissionAnswerList.Add(_formSubmissionAnswer);
             }             reader.Close();
             return _formSubmissionAnswerList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<FormSubmissionAnswer> GetAllByFormSubmissionId(int FormSubmissionId)
        {
            FormSubmissionAnswerDAC _formSubmissionAnswerComponent = new FormSubmissionAnswerDAC();
            IDataReader reader = _formSubmissionAnswerComponent.GetAllFormSubmissionAnswer("FormSubmissionId = " + FormSubmissionId).CreateDataReader();
            List<FormSubmissionAnswer> _formSubmissionAnswerList = new List<FormSubmissionAnswer>();
            while (reader.Read())
            {
                if (_formSubmissionAnswerList == null)
                    _formSubmissionAnswerList = new List<FormSubmissionAnswer>();
                FormSubmissionAnswer _formSubmissionAnswer = new FormSubmissionAnswer();
                if (reader["FormSubmissionAnswerId"] != DBNull.Value)
                    _formSubmissionAnswer.FormSubmissionAnswerId = Convert.ToInt32(reader["FormSubmissionAnswerId"]);
                if (reader["FormSubmissionId"] != DBNull.Value)
                    _formSubmissionAnswer.FormSubmissionId = Convert.ToInt32(reader["FormSubmissionId"]);
                if (reader["FormFieldId"] != DBNull.Value)
                    _formSubmissionAnswer.FormFieldId = Convert.ToInt32(reader["FormFieldId"]);
                if (reader["Answer"] != DBNull.Value)
                    _formSubmissionAnswer.Answer = Convert.ToString(reader["Answer"]);
                if (reader["FormFieldColumnId"] != DBNull.Value)
                    _formSubmissionAnswer.FormFieldColumnId = Convert.ToInt32(reader["FormFieldColumnId"]);
                if (reader["FormFieldValueId"] != DBNull.Value)
                    _formSubmissionAnswer.FormFieldValueId = Convert.ToInt32(reader["FormFieldValueId"]);
                if (reader["Grade"] != DBNull.Value)
                    _formSubmissionAnswer.Grade = Convert.ToInt32(reader["Grade"]);
                _formSubmissionAnswer.NewRecord = false;
                _formSubmissionAnswerList.Add(_formSubmissionAnswer);
            } reader.Close();
            return _formSubmissionAnswerList;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<FormSubmissionAnswer> ViewSubmissionAnswers(int FormDocumentID)
        {
            FormSubmissionAnswerDAC _formSubmissionAnswerComponent = new FormSubmissionAnswerDAC();
            IDataReader reader = _formSubmissionAnswerComponent.ViewSubmissionAnswers("FormDocumentID = " + FormDocumentID).CreateDataReader();
            List<FormSubmissionAnswer> _formSubmissionAnswerList = new List<FormSubmissionAnswer>();
            while (reader.Read())
            {
                if (_formSubmissionAnswerList == null)
                    _formSubmissionAnswerList = new List<FormSubmissionAnswer>();
                FormSubmissionAnswer _formSubmissionAnswer = new FormSubmissionAnswer();
                #region FormSubmissionAnswer Fields
                if (reader["FormSubmissionAnswerId"] != DBNull.Value)
                    _formSubmissionAnswer.FormSubmissionAnswerId = Convert.ToInt32(reader["FormSubmissionAnswerId"]);
                if (reader["FormSubmissionId"] != DBNull.Value)
                    _formSubmissionAnswer.FormSubmissionId = Convert.ToInt32(reader["FormSubmissionId"]);
                if (reader["FormFieldId"] != DBNull.Value)
                    _formSubmissionAnswer.FormFieldId = Convert.ToInt32(reader["FormFieldId"]);
                if (reader["Answer"] != DBNull.Value)
                    _formSubmissionAnswer.Answer = Convert.ToString(reader["Answer"]);
                if (reader["FormFieldColumnId"] != DBNull.Value)
                    _formSubmissionAnswer.FormFieldColumnId = Convert.ToInt32(reader["FormFieldColumnId"]);
                if (reader["FormFieldValueId"] != DBNull.Value)
                    _formSubmissionAnswer.FormFieldValueId = Convert.ToInt32(reader["FormFieldValueId"]);
                if (reader["Grade"] != DBNull.Value)
                    _formSubmissionAnswer.Grade = Convert.ToInt32(reader["Grade"]);
                #endregion

                #region FormSubmission Fields
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

                BusinessLogicLayer.Entities.Persons.Credential _credential = new Entities.Persons.Credential();
                if (reader["UserId"] != DBNull.Value)
                    _credential.BusinessEntityId = Convert.ToInt32(reader["UserId"]);
                if (reader["Username"] != DBNull.Value)
                    _credential.Username = Convert.ToString(reader["Username"]);
                _formSubmission.User = _credential;
                _formSubmissionAnswer.FormSubmission = _formSubmission;
                #endregion

                _formSubmissionAnswer.NewRecord = false;
                _formSubmissionAnswerList.Add(_formSubmissionAnswer);
            } reader.Close();
            return _formSubmissionAnswerList;
        }


        #region Insert And Update
		public bool Insert(FormSubmissionAnswer formsubmissionanswer)
		{
			int autonumber = 0;
			FormSubmissionAnswerDAC formsubmissionanswerComponent = new FormSubmissionAnswerDAC();
			bool endedSuccessfuly = formsubmissionanswerComponent.InsertNewFormSubmissionAnswer( ref autonumber,  formsubmissionanswer.FormSubmissionId,  formsubmissionanswer.FormFieldId,  formsubmissionanswer.Answer,  formsubmissionanswer.FormFieldColumnId,  formsubmissionanswer.FormFieldValueId,  formsubmissionanswer.Grade);
			if(endedSuccessfuly)
			{
				formsubmissionanswer.FormSubmissionAnswerId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int FormSubmissionAnswerId,  int FormSubmissionId,  int FormFieldId,  string Answer,  int FormFieldColumnId,  int FormFieldValueId,  int Grade)
		{
			FormSubmissionAnswerDAC formsubmissionanswerComponent = new FormSubmissionAnswerDAC();
			return formsubmissionanswerComponent.InsertNewFormSubmissionAnswer( ref FormSubmissionAnswerId,  FormSubmissionId,  FormFieldId,  Answer,  FormFieldColumnId,  FormFieldValueId,  Grade);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int FormSubmissionId,  int FormFieldId,  string Answer,  int FormFieldColumnId,  int FormFieldValueId,  int Grade)
		{
			FormSubmissionAnswerDAC formsubmissionanswerComponent = new FormSubmissionAnswerDAC();
            int FormSubmissionAnswerId = 0;

			return formsubmissionanswerComponent.InsertNewFormSubmissionAnswer( ref FormSubmissionAnswerId,  FormSubmissionId,  FormFieldId,  Answer,  FormFieldColumnId,  FormFieldValueId,  Grade);
		}
		public bool Update(FormSubmissionAnswer formsubmissionanswer ,int old_formSubmissionAnswerId)
		{
			FormSubmissionAnswerDAC formsubmissionanswerComponent = new FormSubmissionAnswerDAC();
			return formsubmissionanswerComponent.UpdateFormSubmissionAnswer( formsubmissionanswer.FormSubmissionId,  formsubmissionanswer.FormFieldId,  formsubmissionanswer.Answer,  formsubmissionanswer.FormFieldColumnId,  formsubmissionanswer.FormFieldValueId,  formsubmissionanswer.Grade,  old_formSubmissionAnswerId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int FormSubmissionId,  int FormFieldId,  string Answer,  int FormFieldColumnId,  int FormFieldValueId,  int Grade,  int Original_FormSubmissionAnswerId)
		{
			FormSubmissionAnswerDAC formsubmissionanswerComponent = new FormSubmissionAnswerDAC();
			return formsubmissionanswerComponent.UpdateFormSubmissionAnswer( FormSubmissionId,  FormFieldId,  Answer,  FormFieldColumnId,  FormFieldValueId,  Grade,  Original_FormSubmissionAnswerId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_FormSubmissionAnswerId)
		{
			FormSubmissionAnswerDAC formsubmissionanswerComponent = new FormSubmissionAnswerDAC();
			formsubmissionanswerComponent.DeleteFormSubmissionAnswer(Original_FormSubmissionAnswerId);
		}

        #endregion
         public FormSubmissionAnswer GetByID(int _formSubmissionAnswerId)
         {
             FormSubmissionAnswerDAC _formSubmissionAnswerComponent = new FormSubmissionAnswerDAC();
             IDataReader reader = _formSubmissionAnswerComponent.GetByIDFormSubmissionAnswer(_formSubmissionAnswerId);
             FormSubmissionAnswer _formSubmissionAnswer = null;
             while(reader.Read())
             {
                 _formSubmissionAnswer = new FormSubmissionAnswer();
                 if(reader["FormSubmissionAnswerId"] != DBNull.Value)
                     _formSubmissionAnswer.FormSubmissionAnswerId = Convert.ToInt32(reader["FormSubmissionAnswerId"]);
                 if(reader["FormSubmissionId"] != DBNull.Value)
                     _formSubmissionAnswer.FormSubmissionId = Convert.ToInt32(reader["FormSubmissionId"]);
                 if(reader["FormFieldId"] != DBNull.Value)
                     _formSubmissionAnswer.FormFieldId = Convert.ToInt32(reader["FormFieldId"]);
                 if(reader["Answer"] != DBNull.Value)
                     _formSubmissionAnswer.Answer = Convert.ToString(reader["Answer"]);
                 if(reader["FormFieldColumnId"] != DBNull.Value)
                     _formSubmissionAnswer.FormFieldColumnId = Convert.ToInt32(reader["FormFieldColumnId"]);
                 if(reader["FormFieldValueId"] != DBNull.Value)
                     _formSubmissionAnswer.FormFieldValueId = Convert.ToInt32(reader["FormFieldValueId"]);
                 if(reader["Grade"] != DBNull.Value)
                     _formSubmissionAnswer.Grade = Convert.ToInt32(reader["Grade"]);
             _formSubmissionAnswer.NewRecord = false;             }             reader.Close();
             return _formSubmissionAnswer;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			FormSubmissionAnswerDAC formsubmissionanswercomponent = new FormSubmissionAnswerDAC();
			return formsubmissionanswercomponent.UpdateDataset(dataset);
		}



	}
}
