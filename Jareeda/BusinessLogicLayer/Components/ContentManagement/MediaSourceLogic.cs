using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for MediaSource table
	/// This class RAPs the MediaSourceDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class MediaSourceLogic : BusinessLogic
	{
		public MediaSourceLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<MediaSource> GetAll()
         {
             MediaSourceDAC _mediaSourceComponent = new MediaSourceDAC();
             IDataReader reader =  _mediaSourceComponent.GetAllMediaSource().CreateDataReader();
             List<MediaSource> _mediaSourceList = new List<MediaSource>();
             while(reader.Read())
             {
             if(_mediaSourceList == null)
                 _mediaSourceList = new List<MediaSource>();
                 MediaSource _mediaSource = new MediaSource();
                 if(reader["MediaSourceID"] != DBNull.Value)
                     _mediaSource.MediaSourceID = Convert.ToInt32(reader["MediaSourceID"]);
                 if(reader["Name"] != DBNull.Value)
                     _mediaSource.Name = Convert.ToString(reader["Name"]);
                 if(reader["Site"] != DBNull.Value)
                     _mediaSource.Site = Convert.ToString(reader["Site"]);
                 if(reader["Rss"] != DBNull.Value)
                     _mediaSource.Rss = Convert.ToString(reader["Rss"]);
                 if(reader["PrivateUrl"] != DBNull.Value)
                     _mediaSource.PrivateUrl = Convert.ToString(reader["PrivateUrl"]);
             _mediaSource.NewRecord = false;
             _mediaSourceList.Add(_mediaSource);
             }             reader.Close();
             return _mediaSourceList;
         }

        #region Insert And Update
		public bool Insert(MediaSource mediasource)
		{
			int autonumber = 0;
			MediaSourceDAC mediasourceComponent = new MediaSourceDAC();
			bool endedSuccessfuly = mediasourceComponent.InsertNewMediaSource( ref autonumber,  mediasource.Name,  mediasource.Site,  mediasource.Rss,  mediasource.PrivateUrl);
			if(endedSuccessfuly)
			{
				mediasource.MediaSourceID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int MediaSourceID,  string Name,  string Site,  string Rss,  string PrivateUrl)
		{
			MediaSourceDAC mediasourceComponent = new MediaSourceDAC();
			return mediasourceComponent.InsertNewMediaSource( ref MediaSourceID,  Name,  Site,  Rss,  PrivateUrl);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  string Site,  string Rss,  string PrivateUrl)
		{
			MediaSourceDAC mediasourceComponent = new MediaSourceDAC();
            int MediaSourceID = 0;

			return mediasourceComponent.InsertNewMediaSource( ref MediaSourceID,  Name,  Site,  Rss,  PrivateUrl);
		}
		public bool Update(MediaSource mediasource ,int old_mediaSourceID)
		{
			MediaSourceDAC mediasourceComponent = new MediaSourceDAC();
			return mediasourceComponent.UpdateMediaSource( mediasource.Name,  mediasource.Site,  mediasource.Rss,  mediasource.PrivateUrl,  old_mediaSourceID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  string Site,  string Rss,  string PrivateUrl,  int Original_MediaSourceID)
		{
			MediaSourceDAC mediasourceComponent = new MediaSourceDAC();
			return mediasourceComponent.UpdateMediaSource( Name,  Site,  Rss,  PrivateUrl,  Original_MediaSourceID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_MediaSourceID)
		{
			MediaSourceDAC mediasourceComponent = new MediaSourceDAC();
			mediasourceComponent.DeleteMediaSource(Original_MediaSourceID);
		}

        #endregion
         public MediaSource GetByID(int _mediaSourceID)
         {
             MediaSourceDAC _mediaSourceComponent = new MediaSourceDAC();
             IDataReader reader = _mediaSourceComponent.GetByIDMediaSource(_mediaSourceID);
             MediaSource _mediaSource = null;
             while(reader.Read())
             {
                 _mediaSource = new MediaSource();
                 if(reader["MediaSourceID"] != DBNull.Value)
                     _mediaSource.MediaSourceID = Convert.ToInt32(reader["MediaSourceID"]);
                 if(reader["Name"] != DBNull.Value)
                     _mediaSource.Name = Convert.ToString(reader["Name"]);
                 if(reader["Site"] != DBNull.Value)
                     _mediaSource.Site = Convert.ToString(reader["Site"]);
                 if(reader["Rss"] != DBNull.Value)
                     _mediaSource.Rss = Convert.ToString(reader["Rss"]);
                 if(reader["PrivateUrl"] != DBNull.Value)
                     _mediaSource.PrivateUrl = Convert.ToString(reader["PrivateUrl"]);
             _mediaSource.NewRecord = false;             }             reader.Close();
             return _mediaSource;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			MediaSourceDAC mediasourcecomponent = new MediaSourceDAC();
			return mediasourcecomponent.UpdateDataset(dataset);
		}



	}
}
