using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ContentModuleType table
	/// This class RAPs the ContentModuleTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
    public partial class ContentModuleTypeLogic : BusinessLogic
    {
        public ContentModuleTypeLogic() { }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ContentModuleType> GetAll()
        {
            ContentModuleTypeDAC _contentModuleTypeComponent = new ContentModuleTypeDAC();
            IDataReader reader = _contentModuleTypeComponent.GetAllContentModuleType().CreateDataReader();
            List<ContentModuleType> _contentModuleTypeList = new List<ContentModuleType>();
            while (reader.Read())
            {
                if (_contentModuleTypeList == null)
                    _contentModuleTypeList = new List<ContentModuleType>();
                ContentModuleType _contentModuleType = new ContentModuleType();
                if (reader["ContentModuleTypeID"] != DBNull.Value)
                    _contentModuleType.ContentModuleTypeID = Convert.ToInt32(reader["ContentModuleTypeID"]);
                if (reader["SiteID"] != DBNull.Value)
                    _contentModuleType.SiteID = Convert.ToInt32(reader["SiteID"]);
                if (reader["Name"] != DBNull.Value)
                    _contentModuleType.Name = Convert.ToString(reader["Name"]);
                if (reader["Code"] != DBNull.Value)
                    _contentModuleType.Code = Convert.ToString(reader["Code"]);
                if (reader["ImagePreview"] != DBNull.Value)
                    _contentModuleType.ImagePreview = Convert.ToString(reader["ImagePreview"]);
                if (reader["PositionID"] != DBNull.Value)
                    _contentModuleType.PositionID = Convert.ToInt32(reader["PositionID"]);
                if (reader["ControlPath"] != DBNull.Value)
                    _contentModuleType.ControlPath = Convert.ToString(reader["ControlPath"]);
                _contentModuleType.NewRecord = false;
                _contentModuleTypeList.Add(_contentModuleType);
            } reader.Close();
            return _contentModuleTypeList;
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ContentModuleType> GetAllBySiteID(int SiteID)
        {
            ContentModuleTypeDAC _contentModuleTypeComponent = new ContentModuleTypeDAC();
            IDataReader reader = _contentModuleTypeComponent.GetAllContentModuleType("SiteID = " + SiteID).CreateDataReader();
            List<ContentModuleType> _contentModuleTypeList = new List<ContentModuleType>();
            while (reader.Read())
            {
                if (_contentModuleTypeList == null)
                    _contentModuleTypeList = new List<ContentModuleType>();
                ContentModuleType _contentModuleType = new ContentModuleType();
                if (reader["ContentModuleTypeID"] != DBNull.Value)
                    _contentModuleType.ContentModuleTypeID = Convert.ToInt32(reader["ContentModuleTypeID"]);
                if (reader["SiteID"] != DBNull.Value)
                    _contentModuleType.SiteID = Convert.ToInt32(reader["SiteID"]);
                if (reader["Name"] != DBNull.Value)
                    _contentModuleType.Name = Convert.ToString(reader["Name"]);
                if (reader["Code"] != DBNull.Value)
                    _contentModuleType.Code = Convert.ToString(reader["Code"]);
                if (reader["ImagePreview"] != DBNull.Value)
                    _contentModuleType.ImagePreview = Convert.ToString(reader["ImagePreview"]);
                if (reader["PositionID"] != DBNull.Value)
                    _contentModuleType.PositionID = Convert.ToInt32(reader["PositionID"]);
                if (reader["ControlPath"] != DBNull.Value)
                    _contentModuleType.ControlPath = Convert.ToString(reader["ControlPath"]);
                _contentModuleType.NewRecord = false;
                _contentModuleTypeList.Add(_contentModuleType);
            } reader.Close();
            return _contentModuleTypeList;
        }

        #region Insert And Update
        public bool Insert(ContentModuleType contentmoduletype)
        {
            int autonumber = 0;
            ContentModuleTypeDAC contentmoduletypeComponent = new ContentModuleTypeDAC();
            bool endedSuccessfuly = contentmoduletypeComponent.InsertNewContentModuleType(ref autonumber, contentmoduletype.SiteID, contentmoduletype.Name, contentmoduletype.Code,contentmoduletype.ImagePreview,contentmoduletype.PositionID,contentmoduletype.ControlPath);
            if (endedSuccessfuly)
            {
                contentmoduletype.ContentModuleTypeID = autonumber;
            }
            return endedSuccessfuly;
        }
        public bool Insert(ref int ContentModuleTypeID, int SiteID, string Name, string Code,string ImagePreview,int PositionID,string ControlPath)
        {
            ContentModuleTypeDAC contentmoduletypeComponent = new ContentModuleTypeDAC();
            return contentmoduletypeComponent.InsertNewContentModuleType(ref ContentModuleTypeID, SiteID, Name, Code,ImagePreview,PositionID,ControlPath);
        }
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public bool Insert(int SiteID, string Name, string Code, string ImagePreview, int PositionID, string ControlPath)
        {
            ContentModuleTypeDAC contentmoduletypeComponent = new ContentModuleTypeDAC();
            int ContentModuleTypeID = 0;

            return contentmoduletypeComponent.InsertNewContentModuleType(ref ContentModuleTypeID, SiteID, Name, Code,ImagePreview,PositionID,ControlPath);
        }
        public bool Update(ContentModuleType contentmoduletype, int old_contentModuleTypeID)
        {
            ContentModuleTypeDAC contentmoduletypeComponent = new ContentModuleTypeDAC();
            return contentmoduletypeComponent.UpdateContentModuleType(contentmoduletype.SiteID, contentmoduletype.Name, contentmoduletype.Code,contentmoduletype.ImagePreview,contentmoduletype.PositionID,contentmoduletype.ControlPath, old_contentModuleTypeID);
        }
        [DataObjectMethod(DataObjectMethodType.Update)]
        public bool Update(int SiteID, string Name, string Code, string ImagePreview, int PositionID, string ControlPath, int Original_ContentModuleTypeID)
        {
            ContentModuleTypeDAC contentmoduletypeComponent = new ContentModuleTypeDAC();
            return contentmoduletypeComponent.UpdateContentModuleType(SiteID, Name, Code,ImagePreview,PositionID,ControlPath, Original_ContentModuleTypeID);
        }

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
        public void Delete(int Original_ContentModuleTypeID)
        {
            ContentModuleTypeDAC contentmoduletypeComponent = new ContentModuleTypeDAC();
            contentmoduletypeComponent.DeleteContentModuleType(Original_ContentModuleTypeID);
        }

        #endregion
        public ContentModuleType GetByID(int _contentModuleTypeID)
        {
            ContentModuleTypeDAC _contentModuleTypeComponent = new ContentModuleTypeDAC();
            IDataReader reader = _contentModuleTypeComponent.GetByIDContentModuleType(_contentModuleTypeID);
            ContentModuleType _contentModuleType = null;
            while (reader.Read())
            {
                _contentModuleType = new ContentModuleType();
                if (reader["ContentModuleTypeID"] != DBNull.Value)
                    _contentModuleType.ContentModuleTypeID = Convert.ToInt32(reader["ContentModuleTypeID"]);
                if (reader["SiteID"] != DBNull.Value)
                    _contentModuleType.SiteID = Convert.ToInt32(reader["SiteID"]);
                if (reader["Name"] != DBNull.Value)
                    _contentModuleType.Name = Convert.ToString(reader["Name"]);
                if (reader["Code"] != DBNull.Value)
                    _contentModuleType.Code = Convert.ToString(reader["Code"]);
                if (reader["ImagePreview"] != DBNull.Value)
                    _contentModuleType.ImagePreview = Convert.ToString(reader["ImagePreview"]);
                if (reader["PositionID"] != DBNull.Value)
                    _contentModuleType.PositionID = Convert.ToInt32(reader["PositionID"]);
                if (reader["ControlPath"] != DBNull.Value)
                    _contentModuleType.ControlPath = Convert.ToString(reader["ControlPath"]);
                _contentModuleType.NewRecord = false;
            } reader.Close();
            return _contentModuleType;
        }

        public int UpdateDataset(System.Data.DataSet dataset)
        {
            ContentModuleTypeDAC contentmoduletypecomponent = new ContentModuleTypeDAC();
            return contentmoduletypecomponent.UpdateDataset(dataset);
        }



    }

}
