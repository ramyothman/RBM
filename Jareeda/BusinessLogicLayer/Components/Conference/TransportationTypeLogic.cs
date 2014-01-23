using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Conference;
using BusinessLogicLayer.Entities.Conference;
namespace BusinessLogicLayer.Components.Conference
{
	/// <summary>
	/// This is a Business Logic Component Class  for TransportationType table
	/// This class RAPs the TransportationTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class TransportationTypeLogic : BusinessLogic
	{
		public TransportationTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<TransportationType> GetAll()
         {
             TransportationTypeDAC _transportationTypeComponent = new TransportationTypeDAC();
             IDataReader reader =  _transportationTypeComponent.GetAllTransportationType().CreateDataReader();
             List<TransportationType> _transportationTypeList = new List<TransportationType>();
             while(reader.Read())
             {
             if(_transportationTypeList == null)
                 _transportationTypeList = new List<TransportationType>();
                 TransportationType _transportationType = new TransportationType();
                 if(reader["ID"] != DBNull.Value)
                     _transportationType.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["TypeName"] != DBNull.Value)
                     _transportationType.TypeName = Convert.ToString(reader["TypeName"]);
             _transportationType.NewRecord = false;
             _transportationTypeList.Add(_transportationType);
             }             reader.Close();
             return _transportationTypeList;
         }

        #region Insert And Update
		public bool Insert(TransportationType transportationtype)
		{
			int autonumber = 0;
			TransportationTypeDAC transportationtypeComponent = new TransportationTypeDAC();
			bool endedSuccessfuly = transportationtypeComponent.InsertNewTransportationType( ref autonumber,  transportationtype.TypeName);
			if(endedSuccessfuly)
			{
				transportationtype.ID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ID,  string TypeName)
		{
			TransportationTypeDAC transportationtypeComponent = new TransportationTypeDAC();
			return transportationtypeComponent.InsertNewTransportationType( ref ID,  TypeName);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string TypeName)
		{
			TransportationTypeDAC transportationtypeComponent = new TransportationTypeDAC();
            int ID = 0;

			return transportationtypeComponent.InsertNewTransportationType( ref ID,  TypeName);
		}
		public bool Update(TransportationType transportationtype ,int old_iD)
		{
			TransportationTypeDAC transportationtypeComponent = new TransportationTypeDAC();
			return transportationtypeComponent.UpdateTransportationType( transportationtype.TypeName,  old_iD);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string TypeName,  int Original_ID)
		{
			TransportationTypeDAC transportationtypeComponent = new TransportationTypeDAC();
			return transportationtypeComponent.UpdateTransportationType( TypeName,  Original_ID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ID)
		{
			TransportationTypeDAC transportationtypeComponent = new TransportationTypeDAC();
			transportationtypeComponent.DeleteTransportationType(Original_ID);
		}

        #endregion
         public TransportationType GetByID(int _iD)
         {
             TransportationTypeDAC _transportationTypeComponent = new TransportationTypeDAC();
             IDataReader reader = _transportationTypeComponent.GetByIDTransportationType(_iD);
             TransportationType _transportationType = null;
             while(reader.Read())
             {
                 _transportationType = new TransportationType();
                 if(reader["ID"] != DBNull.Value)
                     _transportationType.ID = Convert.ToInt32(reader["ID"]);
                 if(reader["TypeName"] != DBNull.Value)
                     _transportationType.TypeName = Convert.ToString(reader["TypeName"]);
             _transportationType.NewRecord = false;             }             reader.Close();
             return _transportationType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			TransportationTypeDAC transportationtypecomponent = new TransportationTypeDAC();
			return transportationtypecomponent.UpdateDataset(dataset);
		}



	}
}
