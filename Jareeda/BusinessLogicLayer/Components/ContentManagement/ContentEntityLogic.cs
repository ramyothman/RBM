using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ContentEntity table
	/// This class RAPs the ContentEntityDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ContentEntityLogic : BusinessLogic
	{
		public ContentEntityLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ContentEntity> GetAll()
         {
             ContentEntityDAC _contentEntityComponent = new ContentEntityDAC();
             IDataReader reader =  _contentEntityComponent.GetAllContentEntity().CreateDataReader();
             List<ContentEntity> _contentEntityList = new List<ContentEntity>();
             while(reader.Read())
             {
             if(_contentEntityList == null)
                 _contentEntityList = new List<ContentEntity>();
                 ContentEntity _contentEntity = new ContentEntity();
                 if(reader["ContentEntityId"] != DBNull.Value)
                     _contentEntity.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                 if(reader["ContentEntityType"] != DBNull.Value)
                     _contentEntity.ContentEntityType = Convert.ToString(reader["ContentEntityType"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _contentEntity.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _contentEntity.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _contentEntity.NewRecord = false;
             _contentEntityList.Add(_contentEntity);
             }             reader.Close();
             return _contentEntityList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ContentEntity> GetAllView(string ContentEntityType)
        {
            ContentEntityDAC _contentEntityComponent = new ContentEntityDAC();
            if (string.IsNullOrEmpty(ContentEntityType))
                return new List<ContentEntity>();
            IDataReader reader = _contentEntityComponent.GetAllContentEntityByType(ContentEntityType).CreateDataReader();
            List<ContentEntity> _contentEntityList = new List<ContentEntity>();
            while (reader.Read())
            {
                if (_contentEntityList == null)
                    _contentEntityList = new List<ContentEntity>();
                ContentEntity _contentEntity = new ContentEntity();
                if (reader["ContentEntityId"] != DBNull.Value)
                    _contentEntity.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                if (reader["ContentEntityType"] != DBNull.Value)
                    _contentEntity.ContentEntityType = Convert.ToString(reader["ContentEntityType"]);
                if (reader["RowGuid"] != DBNull.Value)
                    _contentEntity.RowGuid = new Guid(reader["RowGuid"].ToString());
                if (reader["ModifiedDate"] != DBNull.Value)
                    _contentEntity.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
                if (reader["Name"] != DBNull.Value)
                    _contentEntity.ContentEntityName = Convert.ToString(reader["Name"]);
                _contentEntity.NewRecord = false;
                _contentEntityList.Add(_contentEntity);
            } reader.Close();
            return _contentEntityList;
        }

        #region Insert And Update
		public bool Insert(ContentEntity contententity)
		{
			int autonumber = 0;
			ContentEntityDAC contententityComponent = new ContentEntityDAC();
			bool endedSuccessfuly = contententityComponent.InsertNewContentEntity( ref autonumber,  contententity.ContentEntityType,  contententity.RowGuid,  contententity.ModifiedDate);
			if(endedSuccessfuly)
			{
				contententity.ContentEntityId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ContentEntityId,  string ContentEntityType,  Guid RowGuid,  DateTime ModifiedDate)
		{
			ContentEntityDAC contententityComponent = new ContentEntityDAC();
			return contententityComponent.InsertNewContentEntity( ref ContentEntityId,  ContentEntityType,  RowGuid,  ModifiedDate);
		}

        // by ahmed
        public bool Insert(ref int ContentEntityId, string ContentEntityType)
        {
            ContentEntityDAC contententityComponent = new ContentEntityDAC();
            return contententityComponent.InsertNewContentEntity(ref ContentEntityId, ContentEntityType, Guid.NewGuid(), DateTime.Today);
        }

    
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string ContentEntityType,  Guid RowGuid,  DateTime ModifiedDate)
		{
			ContentEntityDAC contententityComponent = new ContentEntityDAC();
            int ContentEntityId = 0;

			return contententityComponent.InsertNewContentEntity( ref ContentEntityId,  ContentEntityType,  RowGuid,  ModifiedDate);
		}
     
		public bool Update(ContentEntity contententity ,int old_contentEntityId)
		{
			ContentEntityDAC contententityComponent = new ContentEntityDAC();
			return contententityComponent.UpdateContentEntity( contententity.ContentEntityType,  contententity.RowGuid,  contententity.ModifiedDate,  old_contentEntityId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string ContentEntityType,  Guid RowGuid,  DateTime ModifiedDate,  int Original_ContentEntityId)
		{
			ContentEntityDAC contententityComponent = new ContentEntityDAC();
			return contententityComponent.UpdateContentEntity( ContentEntityType,  RowGuid,  ModifiedDate,  Original_ContentEntityId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ContentEntityId)
		{
			ContentEntityDAC contententityComponent = new ContentEntityDAC();
			contententityComponent.DeleteContentEntity(Original_ContentEntityId);
		}

        #endregion
         public ContentEntity GetByID(int _contentEntityId)
         {
             ContentEntityDAC _contentEntityComponent = new ContentEntityDAC();
             IDataReader reader = _contentEntityComponent.GetByIDContentEntity(_contentEntityId);
             ContentEntity _contentEntity = null;
             while(reader.Read())
             {
                 _contentEntity = new ContentEntity();
                 if(reader["ContentEntityId"] != DBNull.Value)
                     _contentEntity.ContentEntityId = Convert.ToInt32(reader["ContentEntityId"]);
                 if(reader["ContentEntityType"] != DBNull.Value)
                     _contentEntity.ContentEntityType = Convert.ToString(reader["ContentEntityType"]);
                 if(reader["RowGuid"] != DBNull.Value)
                     _contentEntity.RowGuid = new Guid(reader["RowGuid"].ToString());
                 if(reader["ModifiedDate"] != DBNull.Value)
                     _contentEntity.ModifiedDate = Convert.ToDateTime(reader["ModifiedDate"]);
             _contentEntity.NewRecord = false;             }             reader.Close();
             return _contentEntity;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ContentEntityDAC contententitycomponent = new ContentEntityDAC();
			return contententitycomponent.UpdateDataset(dataset);
		}



	}
}
