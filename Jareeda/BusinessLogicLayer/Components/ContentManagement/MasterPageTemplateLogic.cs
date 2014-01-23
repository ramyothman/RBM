using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for MasterPageTemplate table
	/// This class RAPs the MasterPageTemplateDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class MasterPageTemplateLogic : BusinessLogic
	{
		public MasterPageTemplateLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<MasterPageTemplate> GetAll()
         {
             MasterPageTemplateDAC _masterPageTemplateComponent = new MasterPageTemplateDAC();
             IDataReader reader =  _masterPageTemplateComponent.GetAllMasterPageTemplate().CreateDataReader();
             List<MasterPageTemplate> _masterPageTemplateList = new List<MasterPageTemplate>();
             while(reader.Read())
             {
             if(_masterPageTemplateList == null)
                 _masterPageTemplateList = new List<MasterPageTemplate>();
                 MasterPageTemplate _masterPageTemplate = new MasterPageTemplate();
                 if(reader["MasterPageTemplateId"] != DBNull.Value)
                     _masterPageTemplate.MasterPageTemplateId = Convert.ToInt32(reader["MasterPageTemplateId"]);
                 if(reader["Name"] != DBNull.Value)
                     _masterPageTemplate.Name = Convert.ToString(reader["Name"]);
                 if(reader["Path"] != DBNull.Value)
                     _masterPageTemplate.Path = Convert.ToString(reader["Path"]);
                 if(reader["ClassName"] != DBNull.Value)
                     _masterPageTemplate.ClassName = Convert.ToString(reader["ClassName"]);
                 if(reader["MasterPageContent"] != DBNull.Value)
                     _masterPageTemplate.MasterPageContent = Convert.ToString(reader["MasterPageContent"]);
             _masterPageTemplate.NewRecord = false;
             _masterPageTemplateList.Add(_masterPageTemplate);
             }             reader.Close();
             return _masterPageTemplateList;
         }

        #region Insert And Update
		public bool Insert(MasterPageTemplate masterpagetemplate)
		{
			int autonumber = 0;
			MasterPageTemplateDAC masterpagetemplateComponent = new MasterPageTemplateDAC();
			bool endedSuccessfuly = masterpagetemplateComponent.InsertNewMasterPageTemplate( ref autonumber,  masterpagetemplate.Name,  masterpagetemplate.Path,  masterpagetemplate.ClassName,  masterpagetemplate.MasterPageContent);
			if(endedSuccessfuly)
			{
				masterpagetemplate.MasterPageTemplateId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int MasterPageTemplateId,  string Name,  string Path,  string ClassName,  string MasterPageContent)
		{
			MasterPageTemplateDAC masterpagetemplateComponent = new MasterPageTemplateDAC();
			return masterpagetemplateComponent.InsertNewMasterPageTemplate( ref MasterPageTemplateId,  Name,  Path,  ClassName,  MasterPageContent);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  string Path,  string ClassName,  string MasterPageContent)
		{
			MasterPageTemplateDAC masterpagetemplateComponent = new MasterPageTemplateDAC();
            int MasterPageTemplateId = 0;

			return masterpagetemplateComponent.InsertNewMasterPageTemplate( ref MasterPageTemplateId,  Name,  Path,  ClassName,  MasterPageContent);
		}
		public bool Update(MasterPageTemplate masterpagetemplate ,int old_masterPageTemplateId)
		{
			MasterPageTemplateDAC masterpagetemplateComponent = new MasterPageTemplateDAC();
			return masterpagetemplateComponent.UpdateMasterPageTemplate( masterpagetemplate.Name,  masterpagetemplate.Path,  masterpagetemplate.ClassName,  masterpagetemplate.MasterPageContent,  old_masterPageTemplateId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  string Path,  string ClassName,  string MasterPageContent,  int Original_MasterPageTemplateId)
		{
			MasterPageTemplateDAC masterpagetemplateComponent = new MasterPageTemplateDAC();
			return masterpagetemplateComponent.UpdateMasterPageTemplate( Name,  Path,  ClassName,  MasterPageContent,  Original_MasterPageTemplateId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_MasterPageTemplateId)
		{
			MasterPageTemplateDAC masterpagetemplateComponent = new MasterPageTemplateDAC();
			masterpagetemplateComponent.DeleteMasterPageTemplate(Original_MasterPageTemplateId);
		}

        #endregion
         public MasterPageTemplate GetByID(int _masterPageTemplateId)
         {
             MasterPageTemplateDAC _masterPageTemplateComponent = new MasterPageTemplateDAC();
             IDataReader reader = _masterPageTemplateComponent.GetByIDMasterPageTemplate(_masterPageTemplateId);
             MasterPageTemplate _masterPageTemplate = null;
             while(reader.Read())
             {
                 _masterPageTemplate = new MasterPageTemplate();
                 if(reader["MasterPageTemplateId"] != DBNull.Value)
                     _masterPageTemplate.MasterPageTemplateId = Convert.ToInt32(reader["MasterPageTemplateId"]);
                 if(reader["Name"] != DBNull.Value)
                     _masterPageTemplate.Name = Convert.ToString(reader["Name"]);
                 if(reader["Path"] != DBNull.Value)
                     _masterPageTemplate.Path = Convert.ToString(reader["Path"]);
                 if(reader["ClassName"] != DBNull.Value)
                     _masterPageTemplate.ClassName = Convert.ToString(reader["ClassName"]);
                 if(reader["MasterPageContent"] != DBNull.Value)
                     _masterPageTemplate.MasterPageContent = Convert.ToString(reader["MasterPageContent"]);
             _masterPageTemplate.NewRecord = false;             }             reader.Close();
             return _masterPageTemplate;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			MasterPageTemplateDAC masterpagetemplatecomponent = new MasterPageTemplateDAC();
			return masterpagetemplatecomponent.UpdateDataset(dataset);
		}



	}
}
