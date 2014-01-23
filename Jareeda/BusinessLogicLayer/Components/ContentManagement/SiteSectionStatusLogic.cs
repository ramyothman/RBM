using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for SiteSectionStatus table
	/// This class RAPs the SiteSectionStatusDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SiteSectionStatusLogic : BusinessLogic
	{
		public SiteSectionStatusLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SiteSectionStatus> GetAll()
         {
             SiteSectionStatusDAC _siteSectionStatusComponent = new SiteSectionStatusDAC();
             IDataReader reader =  _siteSectionStatusComponent.GetAllSiteSectionStatus().CreateDataReader();
             List<SiteSectionStatus> _siteSectionStatusList = new List<SiteSectionStatus>();
             while(reader.Read())
             {
             if(_siteSectionStatusList == null)
                 _siteSectionStatusList = new List<SiteSectionStatus>();
                 SiteSectionStatus _siteSectionStatus = new SiteSectionStatus();
                 if(reader["SiteSectionStatusId"] != DBNull.Value)
                     _siteSectionStatus.SiteSectionStatusId = Convert.ToInt32(reader["SiteSectionStatusId"]);
                 if(reader["Name"] != DBNull.Value)
                     _siteSectionStatus.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _siteSectionStatus.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _siteSectionStatus.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _siteSectionStatus.NewRecord = false;
             _siteSectionStatusList.Add(_siteSectionStatus);
             }             reader.Close();
             return _siteSectionStatusList;
         }

        #region Insert And Update
		public bool Insert(SiteSectionStatus sitesectionstatus)
		{
			int autonumber = 0;
			SiteSectionStatusDAC sitesectionstatusComponent = new SiteSectionStatusDAC();
			bool endedSuccessfuly = sitesectionstatusComponent.InsertNewSiteSectionStatus( ref autonumber,  sitesectionstatus.Name,  sitesectionstatus.RowGuid,  sitesectionstatus.ModifiedDate);
			if(endedSuccessfuly)
			{
				sitesectionstatus.SiteSectionStatusId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int SiteSectionStatusId,  string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			SiteSectionStatusDAC sitesectionstatusComponent = new SiteSectionStatusDAC();
			return sitesectionstatusComponent.InsertNewSiteSectionStatus( ref SiteSectionStatusId,  Name,  RowGuid,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			SiteSectionStatusDAC sitesectionstatusComponent = new SiteSectionStatusDAC();
            int SiteSectionStatusId = 0;

			return sitesectionstatusComponent.InsertNewSiteSectionStatus( ref SiteSectionStatusId,  Name,  RowGuid,  ModifiedDate);
		}
		public bool Update(SiteSectionStatus sitesectionstatus ,int old_siteSectionStatusId)
		{
			SiteSectionStatusDAC sitesectionstatusComponent = new SiteSectionStatusDAC();
			return sitesectionstatusComponent.UpdateSiteSectionStatus( sitesectionstatus.Name,  sitesectionstatus.RowGuid,  sitesectionstatus.ModifiedDate,  old_siteSectionStatusId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  Guid RowGuid,  DateTime ModifiedDate,  int Original_SiteSectionStatusId)
		{
			SiteSectionStatusDAC sitesectionstatusComponent = new SiteSectionStatusDAC();
			return sitesectionstatusComponent.UpdateSiteSectionStatus( Name,  RowGuid,  ModifiedDate,  Original_SiteSectionStatusId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SiteSectionStatusId)
		{
			SiteSectionStatusDAC sitesectionstatusComponent = new SiteSectionStatusDAC();
			sitesectionstatusComponent.DeleteSiteSectionStatus(Original_SiteSectionStatusId);
		}

        #endregion
         public SiteSectionStatus GetByID(int _siteSectionStatusId)
         {
             SiteSectionStatusDAC _siteSectionStatusComponent = new SiteSectionStatusDAC();
             IDataReader reader = _siteSectionStatusComponent.GetByIDSiteSectionStatus(_siteSectionStatusId);
             SiteSectionStatus _siteSectionStatus = null;
             while(reader.Read())
             {
                 _siteSectionStatus = new SiteSectionStatus();
                 if(reader["SiteSectionStatusId"] != DBNull.Value)
                     _siteSectionStatus.SiteSectionStatusId = Convert.ToInt32(reader["SiteSectionStatusId"]);
                 if(reader["Name"] != DBNull.Value)
                     _siteSectionStatus.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _siteSectionStatus.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _siteSectionStatus.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _siteSectionStatus.NewRecord = false;             }             reader.Close();
             return _siteSectionStatus;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SiteSectionStatusDAC sitesectionstatuscomponent = new SiteSectionStatusDAC();
			return sitesectionstatuscomponent.UpdateDataset(dataset);
		}



	}
}
