using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for Multimedia table
	/// This class RAPs the MultimediaDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class MultimediaLogic : BusinessLogic
	{
		public MultimediaLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Multimedia> GetAll()
         {
             MultimediaDAC _multimediaComponent = new MultimediaDAC();
             IDataReader reader =  _multimediaComponent.GetAllMultimedia().CreateDataReader();
             List<Multimedia> _multimediaList = new List<Multimedia>();
             while(reader.Read())
             {
             if(_multimediaList == null)
                 _multimediaList = new List<Multimedia>();
                 Multimedia _multimedia = new Multimedia();
                 if(reader["MultimediaID"] != DBNull.Value)
                     _multimedia.MultimediaID = Convert.ToInt32(reader["MultimediaID"]);
                 if(reader["MultimediaTypeID"] != DBNull.Value)
                     _multimedia.MultimediaTypeID = Convert.ToInt32(reader["MultimediaTypeID"]);
                 if(reader["Url"] != DBNull.Value)
                     _multimedia.Url = Convert.ToString(reader["Url"]);
                 if(reader["ThumbnainUrl"] != DBNull.Value)
                     _multimedia.ThumbnainUrl = Convert.ToString(reader["ThumbnainUrl"]);
                 if(reader["Title"] != DBNull.Value)
                     _multimedia.Title = Convert.ToString(reader["Title"]);
                 if(reader["Description"] != DBNull.Value)
                     _multimedia.Description = Convert.ToString(reader["Description"]);
                 if(reader["PublishDate"] != DBNull.Value)
                     _multimedia.PublishDate = Convert.ToDateTime(reader["PublishDate"]);
                 if(reader["CreatedDate"] != DBNull.Value)
                     _multimedia.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
             _multimedia.NewRecord = false;
             _multimediaList.Add(_multimedia);
             }             reader.Close();
             return _multimediaList;
         }

        #region Insert And Update
		public bool Insert(Multimedia multimedia)
		{
			int autonumber = 0;
			MultimediaDAC multimediaComponent = new MultimediaDAC();
			bool endedSuccessfuly = multimediaComponent.InsertNewMultimedia( ref autonumber,  multimedia.MultimediaTypeID,  multimedia.Url,  multimedia.ThumbnainUrl,  multimedia.Title,  multimedia.Description,  multimedia.PublishDate,  multimedia.CreatedDate);
			if(endedSuccessfuly)
			{
				multimedia.MultimediaID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int MultimediaID,  int MultimediaTypeID,  string Url,  string ThumbnainUrl,  string Title,  string Description,  DateTime PublishDate,  DateTime CreatedDate)
		{
			MultimediaDAC multimediaComponent = new MultimediaDAC();
			return multimediaComponent.InsertNewMultimedia( ref MultimediaID,  MultimediaTypeID,  Url,  ThumbnainUrl,  Title,  Description,  PublishDate,  CreatedDate);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int MultimediaTypeID,  string Url,  string ThumbnainUrl,  string Title,  string Description,  DateTime PublishDate,  DateTime CreatedDate)
		{
			MultimediaDAC multimediaComponent = new MultimediaDAC();
            int MultimediaID = 0;

			return multimediaComponent.InsertNewMultimedia( ref MultimediaID,  MultimediaTypeID,  Url,  ThumbnainUrl,  Title,  Description,  PublishDate,  CreatedDate);
		}
		public bool Update(Multimedia multimedia ,int old_multimediaID)
		{
			MultimediaDAC multimediaComponent = new MultimediaDAC();
			return multimediaComponent.UpdateMultimedia( multimedia.MultimediaTypeID,  multimedia.Url,  multimedia.ThumbnainUrl,  multimedia.Title,  multimedia.Description,  multimedia.PublishDate,  multimedia.CreatedDate,  old_multimediaID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int MultimediaTypeID,  string Url,  string ThumbnainUrl,  string Title,  string Description,  DateTime PublishDate,  DateTime CreatedDate,  int Original_MultimediaID)
		{
			MultimediaDAC multimediaComponent = new MultimediaDAC();
			return multimediaComponent.UpdateMultimedia( MultimediaTypeID,  Url,  ThumbnainUrl,  Title,  Description,  PublishDate,  CreatedDate,  Original_MultimediaID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_MultimediaID)
		{
			MultimediaDAC multimediaComponent = new MultimediaDAC();
			multimediaComponent.DeleteMultimedia(Original_MultimediaID);
		}

        #endregion
         public Multimedia GetByID(int _multimediaID)
         {
             MultimediaDAC _multimediaComponent = new MultimediaDAC();
             IDataReader reader = _multimediaComponent.GetByIDMultimedia(_multimediaID);
             Multimedia _multimedia = null;
             while(reader.Read())
             {
                 _multimedia = new Multimedia();
                 if(reader["MultimediaID"] != DBNull.Value)
                     _multimedia.MultimediaID = Convert.ToInt32(reader["MultimediaID"]);
                 if(reader["MultimediaTypeID"] != DBNull.Value)
                     _multimedia.MultimediaTypeID = Convert.ToInt32(reader["MultimediaTypeID"]);
                 if(reader["Url"] != DBNull.Value)
                     _multimedia.Url = Convert.ToString(reader["Url"]);
                 if(reader["ThumbnainUrl"] != DBNull.Value)
                     _multimedia.ThumbnainUrl = Convert.ToString(reader["ThumbnainUrl"]);
                 if(reader["Title"] != DBNull.Value)
                     _multimedia.Title = Convert.ToString(reader["Title"]);
                 if(reader["Description"] != DBNull.Value)
                     _multimedia.Description = Convert.ToString(reader["Description"]);
                 if(reader["PublishDate"] != DBNull.Value)
                     _multimedia.PublishDate = Convert.ToDateTime(reader["PublishDate"]);
                 if(reader["CreatedDate"] != DBNull.Value)
                     _multimedia.CreatedDate = Convert.ToDateTime(reader["CreatedDate"]);
             _multimedia.NewRecord = false;             }             reader.Close();
             return _multimedia;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			MultimediaDAC multimediacomponent = new MultimediaDAC();
			return multimediacomponent.UpdateDataset(dataset);
		}



	}
}
