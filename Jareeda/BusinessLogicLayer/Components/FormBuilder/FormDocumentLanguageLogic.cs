using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.FormBuilder;
using BusinessLogicLayer.Entities.FormBuilder;
namespace BusinessLogicLayer.Components.FormBuilder
{
	/// <summary>
	/// This is a Business Logic Component Class  for FormDocumentLanguage table
	/// This class RAPs the FormDocumentLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class FormDocumentLanguageLogic : BusinessLogic
	{
		public FormDocumentLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<FormDocumentLanguage> GetAll()
         {
             FormDocumentLanguageDAC _formDocumentLanguageComponent = new FormDocumentLanguageDAC();
             IDataReader reader =  _formDocumentLanguageComponent.GetAllFormDocumentLanguage().CreateDataReader();
             List<FormDocumentLanguage> _formDocumentLanguageList = new List<FormDocumentLanguage>();
             while(reader.Read())
             {
             if(_formDocumentLanguageList == null)
                 _formDocumentLanguageList = new List<FormDocumentLanguage>();
                 FormDocumentLanguage _formDocumentLanguage = new FormDocumentLanguage();
                 if(reader["FormDocumentLanguageId"] != DBNull.Value)
                     _formDocumentLanguage.FormDocumentLanguageId = Convert.ToInt32(reader["FormDocumentLanguageId"]);
                 if(reader["DocumentId"] != DBNull.Value)
                     _formDocumentLanguage.DocumentId = Convert.ToInt32(reader["DocumentId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _formDocumentLanguage.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["Title"] != DBNull.Value)
                     _formDocumentLanguage.Title = Convert.ToString(reader["Title"]);
                 if(reader["Description"] != DBNull.Value)
                     _formDocumentLanguage.Description = Convert.ToString(reader["Description"]);
                 if(reader["ConfirmationText"] != DBNull.Value)
                     _formDocumentLanguage.ConfirmationText = Convert.ToString(reader["ConfirmationText"]);
             _formDocumentLanguage.NewRecord = false;
             _formDocumentLanguageList.Add(_formDocumentLanguage);
             }             reader.Close();
             return _formDocumentLanguageList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<FormDocumentLanguage> GetAllByDocumentId(int DocumentId, int LanguageId)
        {
            FormDocumentLanguageDAC _formDocumentLanguageComponent = new FormDocumentLanguageDAC();
            IDataReader reader = _formDocumentLanguageComponent.GetAllFormDocumentLanguage(String.Format("DocumentId = {0} AND LanguageId = {1}", DocumentId, LanguageId)).CreateDataReader();
            List<FormDocumentLanguage> _formDocumentLanguageList = new List<FormDocumentLanguage>();
            while (reader.Read())
            {
                if (_formDocumentLanguageList == null)
                    _formDocumentLanguageList = new List<FormDocumentLanguage>();
                FormDocumentLanguage _formDocumentLanguage = new FormDocumentLanguage();
                if (reader["FormDocumentLanguageId"] != DBNull.Value)
                    _formDocumentLanguage.FormDocumentLanguageId = Convert.ToInt32(reader["FormDocumentLanguageId"]);
                if (reader["DocumentId"] != DBNull.Value)
                    _formDocumentLanguage.DocumentId = Convert.ToInt32(reader["DocumentId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _formDocumentLanguage.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["Title"] != DBNull.Value)
                    _formDocumentLanguage.Title = Convert.ToString(reader["Title"]);
                if (reader["Description"] != DBNull.Value)
                    _formDocumentLanguage.Description = Convert.ToString(reader["Description"]);
                if (reader["ConfirmationText"] != DBNull.Value)
                    _formDocumentLanguage.ConfirmationText = Convert.ToString(reader["ConfirmationText"]);
                _formDocumentLanguage.NewRecord = false;
                _formDocumentLanguageList.Add(_formDocumentLanguage);
            } reader.Close();
            return _formDocumentLanguageList;
        }


        #region Insert And Update
		public bool Insert(FormDocumentLanguage formdocumentlanguage)
		{
			int autonumber = 0;
			FormDocumentLanguageDAC formdocumentlanguageComponent = new FormDocumentLanguageDAC();
			bool endedSuccessfuly = formdocumentlanguageComponent.InsertNewFormDocumentLanguage( ref autonumber,  formdocumentlanguage.DocumentId,  formdocumentlanguage.LanguageId,  formdocumentlanguage.Title,  formdocumentlanguage.Description,  formdocumentlanguage.ConfirmationText);
			if(endedSuccessfuly)
			{
				formdocumentlanguage.FormDocumentLanguageId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int FormDocumentLanguageId,  int DocumentId,  int LanguageId,  string Title,  string Description,  string ConfirmationText)
		{
			FormDocumentLanguageDAC formdocumentlanguageComponent = new FormDocumentLanguageDAC();
			return formdocumentlanguageComponent.InsertNewFormDocumentLanguage( ref FormDocumentLanguageId,  DocumentId,  LanguageId,  Title,  Description,  ConfirmationText);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int DocumentId,  int LanguageId,  string Title,  string Description,  string ConfirmationText)
		{
			FormDocumentLanguageDAC formdocumentlanguageComponent = new FormDocumentLanguageDAC();
            int FormDocumentLanguageId = 0;

			return formdocumentlanguageComponent.InsertNewFormDocumentLanguage( ref FormDocumentLanguageId,  DocumentId,  LanguageId,  Title,  Description,  ConfirmationText);
		}
		public bool Update(FormDocumentLanguage formdocumentlanguage ,int old_formDocumentLanguageId)
		{
			FormDocumentLanguageDAC formdocumentlanguageComponent = new FormDocumentLanguageDAC();
			return formdocumentlanguageComponent.UpdateFormDocumentLanguage( formdocumentlanguage.DocumentId,  formdocumentlanguage.LanguageId,  formdocumentlanguage.Title,  formdocumentlanguage.Description,  formdocumentlanguage.ConfirmationText,  old_formDocumentLanguageId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int DocumentId,  int LanguageId,  string Title,  string Description,  string ConfirmationText,  int Original_FormDocumentLanguageId)
		{
			FormDocumentLanguageDAC formdocumentlanguageComponent = new FormDocumentLanguageDAC();
			return formdocumentlanguageComponent.UpdateFormDocumentLanguage( DocumentId,  LanguageId,  Title,  Description,  ConfirmationText,  Original_FormDocumentLanguageId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_FormDocumentLanguageId)
		{
			FormDocumentLanguageDAC formdocumentlanguageComponent = new FormDocumentLanguageDAC();
			formdocumentlanguageComponent.DeleteFormDocumentLanguage(Original_FormDocumentLanguageId);
		}

        #endregion
         public FormDocumentLanguage GetByID(int _formDocumentLanguageId)
         {
             FormDocumentLanguageDAC _formDocumentLanguageComponent = new FormDocumentLanguageDAC();
             IDataReader reader = _formDocumentLanguageComponent.GetByIDFormDocumentLanguage(_formDocumentLanguageId);
             FormDocumentLanguage _formDocumentLanguage = null;
             while(reader.Read())
             {
                 _formDocumentLanguage = new FormDocumentLanguage();
                 if(reader["FormDocumentLanguageId"] != DBNull.Value)
                     _formDocumentLanguage.FormDocumentLanguageId = Convert.ToInt32(reader["FormDocumentLanguageId"]);
                 if(reader["DocumentId"] != DBNull.Value)
                     _formDocumentLanguage.DocumentId = Convert.ToInt32(reader["DocumentId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _formDocumentLanguage.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["Title"] != DBNull.Value)
                     _formDocumentLanguage.Title = Convert.ToString(reader["Title"]);
                 if(reader["Description"] != DBNull.Value)
                     _formDocumentLanguage.Description = Convert.ToString(reader["Description"]);
                 if(reader["ConfirmationText"] != DBNull.Value)
                     _formDocumentLanguage.ConfirmationText = Convert.ToString(reader["ConfirmationText"]);
             _formDocumentLanguage.NewRecord = false;             }             reader.Close();
             return _formDocumentLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			FormDocumentLanguageDAC formdocumentlanguagecomponent = new FormDocumentLanguageDAC();
			return formdocumentlanguagecomponent.UpdateDataset(dataset);
		}



	}
}
