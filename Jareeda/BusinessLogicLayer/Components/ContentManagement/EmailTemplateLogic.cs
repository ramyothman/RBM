using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
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
                 if(reader["EmailTemplateId"] != DBNull.Value)
                     _emailTemplate.EmailTemplateId = Convert.ToInt32(reader["EmailTemplateId"]);
                 if(reader["SiteId"] != DBNull.Value)
                     _emailTemplate.SiteId = Convert.ToInt32(reader["SiteId"]);
                 if(reader["Title"] != DBNull.Value)
                     _emailTemplate.Title = Convert.ToString(reader["Title"]);
                 if(reader["TemplateContent"] != DBNull.Value)
                     _emailTemplate.TemplateContent = Convert.ToString(reader["TemplateContent"]);
             _emailTemplate.NewRecord = false;
             _emailTemplateList.Add(_emailTemplate);
             }             reader.Close();
             return _emailTemplateList;
         }

        #region Insert And Update
		public bool Insert(EmailTemplate emailtemplate)
		{
			int autonumber = 0;
			EmailTemplateDAC emailtemplateComponent = new EmailTemplateDAC();
			bool endedSuccessfuly = emailtemplateComponent.InsertNewEmailTemplate( ref autonumber,  emailtemplate.SiteId,  emailtemplate.Title,  emailtemplate.TemplateContent);
			if(endedSuccessfuly)
			{
				emailtemplate.EmailTemplateId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int EmailTemplateId,  int SiteId,  string Title,  string TemplateContent)
		{
			EmailTemplateDAC emailtemplateComponent = new EmailTemplateDAC();
			return emailtemplateComponent.InsertNewEmailTemplate( ref EmailTemplateId,  SiteId,  Title,  TemplateContent);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SiteId,  string Title,  string TemplateContent)
		{
			EmailTemplateDAC emailtemplateComponent = new EmailTemplateDAC();
            int EmailTemplateId = 0;

			return emailtemplateComponent.InsertNewEmailTemplate( ref EmailTemplateId,  SiteId,  Title,  TemplateContent);
		}
		public bool Update(EmailTemplate emailtemplate ,int old_emailTemplateId)
		{
			EmailTemplateDAC emailtemplateComponent = new EmailTemplateDAC();
			return emailtemplateComponent.UpdateEmailTemplate( emailtemplate.SiteId,  emailtemplate.Title,  emailtemplate.TemplateContent,  old_emailTemplateId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SiteId,  string Title,  string TemplateContent,  int Original_EmailTemplateId)
		{
			EmailTemplateDAC emailtemplateComponent = new EmailTemplateDAC();
			return emailtemplateComponent.UpdateEmailTemplate( SiteId,  Title,  TemplateContent,  Original_EmailTemplateId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_EmailTemplateId)
		{
			EmailTemplateDAC emailtemplateComponent = new EmailTemplateDAC();
			emailtemplateComponent.DeleteEmailTemplate(Original_EmailTemplateId);
		}

        #endregion
         public EmailTemplate GetByID(int _emailTemplateId)
         {
             EmailTemplateDAC _emailTemplateComponent = new EmailTemplateDAC();
             IDataReader reader = _emailTemplateComponent.GetByIDEmailTemplate(_emailTemplateId);
             EmailTemplate _emailTemplate = null;
             while(reader.Read())
             {
                 _emailTemplate = new EmailTemplate();
                 if(reader["EmailTemplateId"] != DBNull.Value)
                     _emailTemplate.EmailTemplateId = Convert.ToInt32(reader["EmailTemplateId"]);
                 if(reader["SiteId"] != DBNull.Value)
                     _emailTemplate.SiteId = Convert.ToInt32(reader["SiteId"]);
                 if(reader["Title"] != DBNull.Value)
                     _emailTemplate.Title = Convert.ToString(reader["Title"]);
                 if(reader["TemplateContent"] != DBNull.Value)
                     _emailTemplate.TemplateContent = Convert.ToString(reader["TemplateContent"]);
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
