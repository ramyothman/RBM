using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for EmailTemplate table
	/// This class RAPs the EmailTemplateDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class EmailTemplateLogic : BusinessLogic
	{
		public EmailTemplateLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<EmailTemplate> GetAll()
         {
             EmailTemplateDAC _emailTemplateComponent = new EmailTemplateDAC();
             IDataReader reader =  _emailTemplateComponent.GetAllEmailTemplate().CreateDataReader();
             List<EmailTemplate> _emailTemplateList = new List<EmailTemplate>();
             while(reader.Read())
             {
             if(_emailTemplateList == null)
                 _emailTemplateList = new List<EmailTemplate>();
                 EmailTemplate _emailTemplate = new EmailTemplate();
                 if(reader["EmailTemplateID"] != DBNull.Value)
                     _emailTemplate.EmailTemplateID = Convert.ToInt32(reader["EmailTemplateID"]);
                 if(reader["SystemEmailTypeID"] != DBNull.Value)
                     _emailTemplate.SystemEmailTypeID = Convert.ToInt32(reader["SystemEmailTypeID"]);
                 if(reader["ConferenceID"] != DBNull.Value)
                     _emailTemplate.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _emailTemplate.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["Name"] != DBNull.Value)
                     _emailTemplate.Name = Convert.ToString(reader["Name"]);
                 if(reader["Description"] != DBNull.Value)
                     _emailTemplate.Description = Convert.ToString(reader["Description"]);
                 if(reader["EmailContent"] != DBNull.Value)
                     _emailTemplate.EmailContent = Convert.ToString(reader["EmailContent"]);
             _emailTemplate.NewRecord = false;
             _emailTemplateList.Add(_emailTemplate);
             }             reader.Close();
             return _emailTemplateList;
         }

        public EmailTemplate GetTemplate(int TemplateTypeID,int ConferenceID,int LanguageID)
        {
            EmailTemplateDAC _emailTemplateComponent = new EmailTemplateDAC();
            IDataReader reader = _emailTemplateComponent.GetAllEmailTemplate(string.Format("SystemEmailTypeID = {0} and ConferenceID = {1} and LanguageID = {2}",TemplateTypeID,ConferenceID,LanguageID)).CreateDataReader();
            
            EmailTemplate _emailTemplate = null;
            while (reader.Read())
            {
                _emailTemplate = new EmailTemplate();
                if (reader["EmailTemplateID"] != DBNull.Value)
                    _emailTemplate.EmailTemplateID = Convert.ToInt32(reader["EmailTemplateID"]);
                if (reader["SystemEmailTypeID"] != DBNull.Value)
                    _emailTemplate.SystemEmailTypeID = Convert.ToInt32(reader["SystemEmailTypeID"]);
                if (reader["ConferenceID"] != DBNull.Value)
                    _emailTemplate.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _emailTemplate.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["Name"] != DBNull.Value)
                    _emailTemplate.Name = Convert.ToString(reader["Name"]);
                if (reader["Description"] != DBNull.Value)
                    _emailTemplate.Description = Convert.ToString(reader["Description"]);
                if (reader["EmailContent"] != DBNull.Value)
                    _emailTemplate.EmailContent = Convert.ToString(reader["EmailContent"]);
                _emailTemplate.NewRecord = false;
            } reader.Close();
            if(_emailTemplate == null && LanguageID != Convert.ToInt32(Common.DefaultLanguageId))
                return GetTemplate(TemplateTypeID, ConferenceID, Convert.ToInt32(Common.DefaultLanguageId));
            return _emailTemplate;
        }

        #region Insert And Update
		public bool Insert(EmailTemplate emailtemplate)
		{
			int autonumber = 0;
			EmailTemplateDAC emailtemplateComponent = new EmailTemplateDAC();
			bool endedSuccessfuly = emailtemplateComponent.InsertNewEmailTemplate( ref autonumber,  emailtemplate.SystemEmailTypeID,  emailtemplate.ConferenceID,  emailtemplate.LanguageID,  emailtemplate.Name,  emailtemplate.Description,  emailtemplate.EmailContent);
			if(endedSuccessfuly)
			{
				emailtemplate.EmailTemplateID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int EmailTemplateID,  int SystemEmailTypeID,  int ConferenceID,  int LanguageID,  string Name,  string Description,  string EmailContent)
		{
			EmailTemplateDAC emailtemplateComponent = new EmailTemplateDAC();
			return emailtemplateComponent.InsertNewEmailTemplate( ref EmailTemplateID,  SystemEmailTypeID,  ConferenceID,  LanguageID,  Name,  Description,  EmailContent);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SystemEmailTypeID,  int ConferenceID,  int LanguageID,  string Name,  string Description,  string EmailContent)
		{
			EmailTemplateDAC emailtemplateComponent = new EmailTemplateDAC();
            int EmailTemplateID = 0;

			return emailtemplateComponent.InsertNewEmailTemplate( ref EmailTemplateID,  SystemEmailTypeID,  ConferenceID,  LanguageID,  Name,  Description,  EmailContent);
		}
		public bool Update(EmailTemplate emailtemplate ,int old_emailTemplateID)
		{
			EmailTemplateDAC emailtemplateComponent = new EmailTemplateDAC();
			return emailtemplateComponent.UpdateEmailTemplate( emailtemplate.SystemEmailTypeID,  emailtemplate.ConferenceID,  emailtemplate.LanguageID,  emailtemplate.Name,  emailtemplate.Description,  emailtemplate.EmailContent,  old_emailTemplateID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SystemEmailTypeID,  int ConferenceID,  int LanguageID,  string Name,  string Description,  string EmailContent,  int Original_EmailTemplateID)
		{
			EmailTemplateDAC emailtemplateComponent = new EmailTemplateDAC();
			return emailtemplateComponent.UpdateEmailTemplate( SystemEmailTypeID,  ConferenceID,  LanguageID,  Name,  Description,  EmailContent,  Original_EmailTemplateID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_EmailTemplateID)
		{
			EmailTemplateDAC emailtemplateComponent = new EmailTemplateDAC();
			emailtemplateComponent.DeleteEmailTemplate(Original_EmailTemplateID);
		}

        #endregion
         public EmailTemplate GetByID(int _emailTemplateID)
         {
             EmailTemplateDAC _emailTemplateComponent = new EmailTemplateDAC();
             IDataReader reader = _emailTemplateComponent.GetByIDEmailTemplate(_emailTemplateID);
             EmailTemplate _emailTemplate = null;
             while(reader.Read())
             {
                 _emailTemplate = new EmailTemplate();
                 if(reader["EmailTemplateID"] != DBNull.Value)
                     _emailTemplate.EmailTemplateID = Convert.ToInt32(reader["EmailTemplateID"]);
                 if(reader["SystemEmailTypeID"] != DBNull.Value)
                     _emailTemplate.SystemEmailTypeID = Convert.ToInt32(reader["SystemEmailTypeID"]);
                 if(reader["ConferenceID"] != DBNull.Value)
                     _emailTemplate.ConferenceID = Convert.ToInt32(reader["ConferenceID"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _emailTemplate.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["Name"] != DBNull.Value)
                     _emailTemplate.Name = Convert.ToString(reader["Name"]);
                 if(reader["Description"] != DBNull.Value)
                     _emailTemplate.Description = Convert.ToString(reader["Description"]);
                 if(reader["EmailContent"] != DBNull.Value)
                     _emailTemplate.EmailContent = Convert.ToString(reader["EmailContent"]);
             _emailTemplate.NewRecord = false;             }             reader.Close();
             return _emailTemplate;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			EmailTemplateDAC emailtemplatecomponent = new EmailTemplateDAC();
			return emailtemplatecomponent.UpdateDataset(dataset);
		}



	}
}
