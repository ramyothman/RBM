using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for PageStatus table
	/// This class RAPs the PageStatusDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PageStatusLogic : BusinessLogic
	{
		public PageStatusLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PageStatus> GetAll()
         {
             PageStatusDAC _pageStatusComponent = new PageStatusDAC();
             IDataReader reader =  _pageStatusComponent.GetAllPageStatus().CreateDataReader();
             List<PageStatus> _pageStatusList = new List<PageStatus>();
             while(reader.Read())
             {
             if(_pageStatusList == null)
                 _pageStatusList = new List<PageStatus>();
                 PageStatus _pageStatus = new PageStatus();
                 if(reader["PageStatusId"] != DBNull.Value)
                     _pageStatus.PageStatusId = Convert.ToInt32(reader["PageStatusId"]);
                 if(reader["Name"] != DBNull.Value)
                     _pageStatus.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _pageStatus.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _pageStatus.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _pageStatus.NewRecord = false;
             _pageStatusList.Add(_pageStatus);
             }             reader.Close();
             return _pageStatusList;
         }

        #region Insert And Update
		public bool Insert(PageStatus pagestatus)
		{
			int autonumber = 0;
			PageStatusDAC pagestatusComponent = new PageStatusDAC();
			bool endedSuccessfuly = pagestatusComponent.InsertNewPageStatus( ref autonumber,  pagestatus.Name,  pagestatus.RowGuid,  pagestatus.ModifiedDate);
			if(endedSuccessfuly)
			{
				pagestatus.PageStatusId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PageStatusId,  string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			PageStatusDAC pagestatusComponent = new PageStatusDAC();
			return pagestatusComponent.InsertNewPageStatus( ref PageStatusId,  Name,  RowGuid,  ModifiedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  Guid RowGuid,  DateTime ModifiedDate)
		{
			PageStatusDAC pagestatusComponent = new PageStatusDAC();
            int PageStatusId = 0;

			return pagestatusComponent.InsertNewPageStatus( ref PageStatusId,  Name,  RowGuid,  ModifiedDate);
		}
		public bool Update(PageStatus pagestatus ,int old_pageStatusId)
		{
			PageStatusDAC pagestatusComponent = new PageStatusDAC();
			return pagestatusComponent.UpdatePageStatus( pagestatus.Name,  pagestatus.RowGuid,  pagestatus.ModifiedDate,  old_pageStatusId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  Guid RowGuid,  DateTime ModifiedDate,  int Original_PageStatusId)
		{
			PageStatusDAC pagestatusComponent = new PageStatusDAC();
			return pagestatusComponent.UpdatePageStatus( Name,  RowGuid,  ModifiedDate,  Original_PageStatusId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PageStatusId)
		{
			PageStatusDAC pagestatusComponent = new PageStatusDAC();
			pagestatusComponent.DeletePageStatus(Original_PageStatusId);
		}

        #endregion
         public PageStatus GetByID(int _pageStatusId)
         {
             PageStatusDAC _pageStatusComponent = new PageStatusDAC();
             IDataReader reader = _pageStatusComponent.GetByIDPageStatus(_pageStatusId);
             PageStatus _pageStatus = null;
             while(reader.Read())
             {
                 _pageStatus = new PageStatus();
                 if(reader["PageStatusId"] != DBNull.Value)
                     _pageStatus.PageStatusId = Convert.ToInt32(reader["PageStatusId"]);
                 if(reader["Name"] != DBNull.Value)
                     _pageStatus.Name = Convert.ToString(reader["Name"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _pageStatus.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _pageStatus.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _pageStatus.NewRecord = false;             }             reader.Close();
             return _pageStatus;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PageStatusDAC pagestatuscomponent = new PageStatusDAC();
			return pagestatuscomponent.UpdateDataset(dataset);
		}



	}
}
