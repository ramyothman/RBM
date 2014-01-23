using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for Lookups table
	/// This class RAPs the LookupsDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class LookupsLogic : BusinessLogic
	{
		public LookupsLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Lookups> GetAll()
         {
             LookupsDAC _lookupsComponent = new LookupsDAC();
             IDataReader reader =  _lookupsComponent.GetAllLookups().CreateDataReader();
             List<Lookups> _lookupsList = new List<Lookups>();
             while(reader.Read())
             {
             if(_lookupsList == null)
                 _lookupsList = new List<Lookups>();
                 Lookups _lookups = new Lookups();
                 if(reader["LookupId"] != DBNull.Value)
                     _lookups.LookupId = Convert.ToInt32(reader["LookupId"]);
                 if(reader["LookupName"] != DBNull.Value)
                     _lookups.LookupName = Convert.ToString(reader["LookupName"]);
                 if(reader["LookupFriendlyName"] != DBNull.Value)
                     _lookups.LookupFriendlyName = Convert.ToString(reader["LookupFriendlyName"]);
             _lookups.NewRecord = false;
             _lookupsList.Add(_lookups);
             }             reader.Close();
             return _lookupsList;
         }

        #region Insert And Update
		public bool Insert(Lookups lookups)
		{
			int autonumber = 0;
			LookupsDAC lookupsComponent = new LookupsDAC();
			bool endedSuccessfuly = lookupsComponent.InsertNewLookups( ref autonumber,  lookups.LookupName,  lookups.LookupFriendlyName);
			if(endedSuccessfuly)
			{
				lookups.LookupId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int LookupId,  string LookupName,  string LookupFriendlyName)
		{
			LookupsDAC lookupsComponent = new LookupsDAC();
			return lookupsComponent.InsertNewLookups( ref LookupId,  LookupName,  LookupFriendlyName);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string LookupName,  string LookupFriendlyName)
		{
			LookupsDAC lookupsComponent = new LookupsDAC();
            int LookupId = 0;

			return lookupsComponent.InsertNewLookups( ref LookupId,  LookupName,  LookupFriendlyName);
		}
		public bool Update(Lookups lookups ,int old_lookupId)
		{
			LookupsDAC lookupsComponent = new LookupsDAC();
			return lookupsComponent.UpdateLookups( lookups.LookupName,  lookups.LookupFriendlyName,  old_lookupId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string LookupName,  string LookupFriendlyName,  int Original_LookupId)
		{
			LookupsDAC lookupsComponent = new LookupsDAC();
			return lookupsComponent.UpdateLookups( LookupName,  LookupFriendlyName,  Original_LookupId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_LookupId)
		{
			LookupsDAC lookupsComponent = new LookupsDAC();
			lookupsComponent.DeleteLookups(Original_LookupId);
		}

        #endregion
         public Lookups GetByID(int _lookupId)
         {
             LookupsDAC _lookupsComponent = new LookupsDAC();
             IDataReader reader = _lookupsComponent.GetByIDLookups(_lookupId);
             Lookups _lookups = null;
             while(reader.Read())
             {
                 _lookups = new Lookups();
                 if(reader["LookupId"] != DBNull.Value)
                     _lookups.LookupId = Convert.ToInt32(reader["LookupId"]);
                 if(reader["LookupName"] != DBNull.Value)
                     _lookups.LookupName = Convert.ToString(reader["LookupName"]);
                 if(reader["LookupFriendlyName"] != DBNull.Value)
                     _lookups.LookupFriendlyName = Convert.ToString(reader["LookupFriendlyName"]);
             _lookups.NewRecord = false;             }             reader.Close();
             return _lookups;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			LookupsDAC lookupscomponent = new LookupsDAC();
			return lookupscomponent.UpdateDataset(dataset);
		}



	}
}
