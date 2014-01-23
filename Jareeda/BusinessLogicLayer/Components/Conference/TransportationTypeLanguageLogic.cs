using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for TransportationTypeLanguage table
	/// This class RAPs the TransportationTypeLanguageDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class TransportationTypeLanguageLogic : BusinessLogic
	{
		public TransportationTypeLanguageLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<TransportationTypeLanguage> GetAll()
         {
             TransportationTypeLanguageDAC _transportationTypeLanguageComponent = new TransportationTypeLanguageDAC();
             IDataReader reader =  _transportationTypeLanguageComponent.GetAllTransportationTypeLanguage().CreateDataReader();
             List<TransportationTypeLanguage> _transportationTypeLanguageList = new List<TransportationTypeLanguage>();
             while(reader.Read())
             {
             if(_transportationTypeLanguageList == null)
                 _transportationTypeLanguageList = new List<TransportationTypeLanguage>();
                 TransportationTypeLanguage _transportationTypeLanguage = new TransportationTypeLanguage();
                 if(reader["ID"] != DBNull.Value)
                     _transportationTypeLanguage.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["TypeName"] != DBNull.Value)
                     _transportationTypeLanguage.TypeName = Convert.ToString(reader["TypeName"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _transportationTypeLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ParentID"] != DBNull.Value)
                     _transportationTypeLanguage.ParentID = Convert.ToInt32(reader["ParentID"]);
             _transportationTypeLanguage.NewRecord = false;
             _transportationTypeLanguageList.Add(_transportationTypeLanguage);
             }             reader.Close();
             return _transportationTypeLanguageList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public TransportationTypeLanguage GetByTransportationTypeIDandLanguageId(int ParentID, int LanguageID)
        {
            TransportationTypeLanguageDAC _transportationTypeLanguageComponent = new TransportationTypeLanguageDAC();
            IDataReader reader = _transportationTypeLanguageComponent.GetAllTransportationTypeLanguage(string.Format("ParentID={0} and LanguageID={1}",ParentID,LanguageID)).CreateDataReader();
            TransportationTypeLanguage _transportationTypeLanguage = new TransportationTypeLanguage();
            while (reader.Read())
            {
                
                if (reader["ID"] != DBNull.Value)
                    _transportationTypeLanguage.ID = Convert.ToInt32(reader["ID"]);
                if (reader["TypeName"] != DBNull.Value)
                    _transportationTypeLanguage.TypeName = Convert.ToString(reader["TypeName"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _transportationTypeLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["ParentID"] != DBNull.Value)
                    _transportationTypeLanguage.ParentID = Convert.ToInt32(reader["ParentID"]);
                _transportationTypeLanguage.NewRecord = false;
                
            } reader.Close();
            return _transportationTypeLanguage;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<TransportationTypeLanguage> GetAll(int ParentID)
        {
            TransportationTypeLanguageDAC _transportationTypeLanguageComponent = new TransportationTypeLanguageDAC();
            IDataReader reader = _transportationTypeLanguageComponent.GetAllTransportationTypeLanguage("ParentID=" + ParentID).CreateDataReader();
            List<TransportationTypeLanguage> _transportationTypeLanguageList = new List<TransportationTypeLanguage>();
            while (reader.Read())
            {
                if (_transportationTypeLanguageList == null)
                    _transportationTypeLanguageList = new List<TransportationTypeLanguage>();
                TransportationTypeLanguage _transportationTypeLanguage = new TransportationTypeLanguage();
                if (reader["ID"] != DBNull.Value)
                    _transportationTypeLanguage.ID = Convert.ToInt32(reader["ID"]);
                if (reader["TypeName"] != DBNull.Value)
                    _transportationTypeLanguage.TypeName = Convert.ToString(reader["TypeName"]);
                if (reader["LanguageID"] != DBNull.Value)
                    _transportationTypeLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                if (reader["ParentID"] != DBNull.Value)
                    _transportationTypeLanguage.ParentID = Convert.ToInt32(reader["ParentID"]);
                _transportationTypeLanguage.NewRecord = false;
                _transportationTypeLanguageList.Add(_transportationTypeLanguage);
            } reader.Close();
            return _transportationTypeLanguageList;
        }

        #region Insert And Update
		public bool Insert(TransportationTypeLanguage transportationtypelanguage)
		{
			int autonumber = 0;
			TransportationTypeLanguageDAC transportationtypelanguageComponent = new TransportationTypeLanguageDAC();
			bool endedSuccessfuly = transportationtypelanguageComponent.InsertNewTransportationTypeLanguage( ref autonumber,  transportationtypelanguage.TypeName,  transportationtypelanguage.LanguageID,  transportationtypelanguage.ParentID);
			if(endedSuccessfuly)
			{
				transportationtypelanguage.ID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ID,  string TypeName,  int LanguageID,  int ParentID)
		{
			TransportationTypeLanguageDAC transportationtypelanguageComponent = new TransportationTypeLanguageDAC();
			return transportationtypelanguageComponent.InsertNewTransportationTypeLanguage( ref ID,  TypeName,  LanguageID,  ParentID);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string TypeName,  int LanguageID,  int ParentID)
		{
			TransportationTypeLanguageDAC transportationtypelanguageComponent = new TransportationTypeLanguageDAC();
            int ID = 0;

			return transportationtypelanguageComponent.InsertNewTransportationTypeLanguage( ref ID,  TypeName,  LanguageID,  ParentID);
		}
		public bool Update(TransportationTypeLanguage transportationtypelanguage ,int old_iD)
		{
			TransportationTypeLanguageDAC transportationtypelanguageComponent = new TransportationTypeLanguageDAC();
			return transportationtypelanguageComponent.UpdateTransportationTypeLanguage( transportationtypelanguage.TypeName,  transportationtypelanguage.LanguageID,  transportationtypelanguage.ParentID,  old_iD);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string TypeName,  int LanguageID,  int ParentID,  int Original_ID)
		{
			TransportationTypeLanguageDAC transportationtypelanguageComponent = new TransportationTypeLanguageDAC();
			return transportationtypelanguageComponent.UpdateTransportationTypeLanguage( TypeName,  LanguageID,  ParentID,  Original_ID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ID)
		{
			TransportationTypeLanguageDAC transportationtypelanguageComponent = new TransportationTypeLanguageDAC();
			transportationtypelanguageComponent.DeleteTransportationTypeLanguage(Original_ID);
		}

        #endregion
         public TransportationTypeLanguage GetByID(int _iD)
         {
             TransportationTypeLanguageDAC _transportationTypeLanguageComponent = new TransportationTypeLanguageDAC();
             IDataReader reader = _transportationTypeLanguageComponent.GetByIDTransportationTypeLanguage(_iD);
             TransportationTypeLanguage _transportationTypeLanguage = null;
             while(reader.Read())
             {
                 _transportationTypeLanguage = new TransportationTypeLanguage();
                 if(reader["ID"] != DBNull.Value)
                     _transportationTypeLanguage.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["TypeName"] != DBNull.Value)
                     _transportationTypeLanguage.TypeName = Convert.ToString(reader["TypeName"]);
                 if(reader["LanguageID"] != DBNull.Value)
                     _transportationTypeLanguage.LanguageID = Convert.ToInt32(reader["LanguageID"]);
                 if(reader["ParentID"] != DBNull.Value)
                     _transportationTypeLanguage.ParentID = Convert.ToInt32(reader["ParentID"]);
             _transportationTypeLanguage.NewRecord = false;             }             reader.Close();
             return _transportationTypeLanguage;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			TransportationTypeLanguageDAC transportationtypelanguagecomponent = new TransportationTypeLanguageDAC();
			return transportationtypelanguagecomponent.UpdateDataset(dataset);
		}



	}
}
