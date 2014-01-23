using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.FormBuilder;
using BusinessLogicLayer.Entities.FormBuilder;
namespace BusinessLogicLayer.Components.FormBuilder
{
	/// <summary>
	/// This is a Business Logic Component Class  for FormDocumentStatus table
	/// This class RAPs the FormDocumentStatusDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class FormDocumentStatusLogic : BusinessLogic
	{
		public FormDocumentStatusLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<FormDocumentStatus> GetAll()
         {
             FormDocumentStatusDAC _formDocumentStatusComponent = new FormDocumentStatusDAC();
             IDataReader reader =  _formDocumentStatusComponent.GetAllFormDocumentStatus().CreateDataReader();
             List<FormDocumentStatus> _formDocumentStatusList = new List<FormDocumentStatus>();
             while(reader.Read())
             {
             if(_formDocumentStatusList == null)
                 _formDocumentStatusList = new List<FormDocumentStatus>();
                 FormDocumentStatus _formDocumentStatus = new FormDocumentStatus();
                 if(reader["FormDocumentStatusID"] != DBNull.Value)
                     _formDocumentStatus.FormDocumentStatusID = Convert.ToInt32(reader["FormDocumentStatusID"]);
                 if(reader["StatusName"] != DBNull.Value)
                     _formDocumentStatus.StatusName = Convert.ToString(reader["StatusName"]);
             _formDocumentStatus.NewRecord = false;
             _formDocumentStatusList.Add(_formDocumentStatus);
             }             reader.Close();
             return _formDocumentStatusList;
         }

        #region Insert And Update
		public bool Insert(FormDocumentStatus formdocumentstatus)
		{
			FormDocumentStatusDAC formdocumentstatusComponent = new FormDocumentStatusDAC();
			return formdocumentstatusComponent.InsertNewFormDocumentStatus( formdocumentstatus.FormDocumentStatusID,  formdocumentstatus.StatusName);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int FormDocumentStatusID,  string StatusName)
		{
			FormDocumentStatusDAC formdocumentstatusComponent = new FormDocumentStatusDAC();
			return formdocumentstatusComponent.InsertNewFormDocumentStatus( FormDocumentStatusID,  StatusName);
		}
		public bool Update(FormDocumentStatus formdocumentstatus ,int old_formDocumentStatusID)
		{
			FormDocumentStatusDAC formdocumentstatusComponent = new FormDocumentStatusDAC();
			return formdocumentstatusComponent.UpdateFormDocumentStatus( formdocumentstatus.FormDocumentStatusID,  formdocumentstatus.StatusName,  old_formDocumentStatusID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int FormDocumentStatusID,  string StatusName,  int Original_FormDocumentStatusID)
		{
			FormDocumentStatusDAC formdocumentstatusComponent = new FormDocumentStatusDAC();
			return formdocumentstatusComponent.UpdateFormDocumentStatus( FormDocumentStatusID,  StatusName,  Original_FormDocumentStatusID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_FormDocumentStatusID)
		{
			FormDocumentStatusDAC formdocumentstatusComponent = new FormDocumentStatusDAC();
			formdocumentstatusComponent.DeleteFormDocumentStatus(Original_FormDocumentStatusID);
		}

        #endregion
         public FormDocumentStatus GetByID(int _formDocumentStatusID)
         {
             FormDocumentStatusDAC _formDocumentStatusComponent = new FormDocumentStatusDAC();
             IDataReader reader = _formDocumentStatusComponent.GetByIDFormDocumentStatus(_formDocumentStatusID);
             FormDocumentStatus _formDocumentStatus = null;
             while(reader.Read())
             {
                 _formDocumentStatus = new FormDocumentStatus();
                 if(reader["FormDocumentStatusID"] != DBNull.Value)
                     _formDocumentStatus.FormDocumentStatusID = Convert.ToInt32(reader["FormDocumentStatusID"]);
                 if(reader["StatusName"] != DBNull.Value)
                     _formDocumentStatus.StatusName = Convert.ToString(reader["StatusName"]);
             _formDocumentStatus.NewRecord = false;             }             reader.Close();
             return _formDocumentStatus;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			FormDocumentStatusDAC formdocumentstatuscomponent = new FormDocumentStatusDAC();
			return formdocumentstatuscomponent.UpdateDataset(dataset);
		}



	}
}
