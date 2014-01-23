using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for MediaType table
	/// This class RAPs the MediaTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class MediaTypeLogic : BusinessLogic
	{
		public MediaTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<MediaType> GetAll()
         {
             MediaTypeDAC _mediaTypeComponent = new MediaTypeDAC();
             IDataReader reader =  _mediaTypeComponent.GetAllMediaType().CreateDataReader();
             List<MediaType> _mediaTypeList = new List<MediaType>();
             while(reader.Read())
             {
             if(_mediaTypeList == null)
                 _mediaTypeList = new List<MediaType>();
                 MediaType _mediaType = new MediaType();
                 if(reader["MediaTypeID"] != DBNull.Value)
                     _mediaType.MediaTypeID = Convert.ToInt32(reader["MediaTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _mediaType.Name = Convert.ToString(reader["Name"]);
             _mediaType.NewRecord = false;
             _mediaTypeList.Add(_mediaType);
             }             reader.Close();
             return _mediaTypeList;
         }

        #region Insert And Update
		public bool Insert(MediaType mediatype)
		{
			int autonumber = 0;
			MediaTypeDAC mediatypeComponent = new MediaTypeDAC();
			bool endedSuccessfuly = mediatypeComponent.InsertNewMediaType( ref autonumber,  mediatype.Name);
			if(endedSuccessfuly)
			{
				mediatype.MediaTypeID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int MediaTypeID,  string Name)
		{
			MediaTypeDAC mediatypeComponent = new MediaTypeDAC();
			return mediatypeComponent.InsertNewMediaType( ref MediaTypeID,  Name);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name)
		{
			MediaTypeDAC mediatypeComponent = new MediaTypeDAC();
            int MediaTypeID = 0;

			return mediatypeComponent.InsertNewMediaType( ref MediaTypeID,  Name);
		}
		public bool Update(MediaType mediatype ,int old_mediaTypeID)
		{
			MediaTypeDAC mediatypeComponent = new MediaTypeDAC();
			return mediatypeComponent.UpdateMediaType( mediatype.Name,  old_mediaTypeID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int Original_MediaTypeID)
		{
			MediaTypeDAC mediatypeComponent = new MediaTypeDAC();
			return mediatypeComponent.UpdateMediaType( Name,  Original_MediaTypeID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_MediaTypeID)
		{
			MediaTypeDAC mediatypeComponent = new MediaTypeDAC();
			mediatypeComponent.DeleteMediaType(Original_MediaTypeID);
		}

        #endregion
         public MediaType GetByID(int _mediaTypeID)
         {
             MediaTypeDAC _mediaTypeComponent = new MediaTypeDAC();
             IDataReader reader = _mediaTypeComponent.GetByIDMediaType(_mediaTypeID);
             MediaType _mediaType = null;
             while(reader.Read())
             {
                 _mediaType = new MediaType();
                 if(reader["MediaTypeID"] != DBNull.Value)
                     _mediaType.MediaTypeID = Convert.ToInt32(reader["MediaTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _mediaType.Name = Convert.ToString(reader["Name"]);
             _mediaType.NewRecord = false;             }             reader.Close();
             return _mediaType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			MediaTypeDAC mediatypecomponent = new MediaTypeDAC();
			return mediatypecomponent.UpdateDataset(dataset);
		}



	}
}
