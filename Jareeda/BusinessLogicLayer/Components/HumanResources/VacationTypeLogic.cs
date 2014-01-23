using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for VacationType table
	/// This class RAPs the VacationTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class VacationTypeLogic : BusinessLogic
	{
		public VacationTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<VacationType> GetAll()
         {
             VacationTypeDAC _vacationTypeComponent = new VacationTypeDAC();
             IDataReader reader =  _vacationTypeComponent.GetAllVacationType().CreateDataReader();
             List<VacationType> _vacationTypeList = new List<VacationType>();
             while(reader.Read())
             {
             if(_vacationTypeList == null)
                 _vacationTypeList = new List<VacationType>();
                 VacationType _vacationType = new VacationType();
                 if(reader["VacationTypeID"] != DBNull.Value)
                     _vacationType.VacationTypeID = Convert.ToInt32(reader["VacationTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _vacationType.Name = Convert.ToString(reader["Name"]);
             _vacationType.NewRecord = false;
             _vacationTypeList.Add(_vacationType);
             }             reader.Close();
             return _vacationTypeList;
         }

        #region Insert And Update
		public bool Insert(VacationType vacationtype)
		{
			int autonumber = 0;
			VacationTypeDAC vacationtypeComponent = new VacationTypeDAC();
			bool endedSuccessfuly = vacationtypeComponent.InsertNewVacationType( ref autonumber,  vacationtype.Name);
			if(endedSuccessfuly)
			{
				vacationtype.VacationTypeID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int VacationTypeID,  string Name)
		{
			VacationTypeDAC vacationtypeComponent = new VacationTypeDAC();
			return vacationtypeComponent.InsertNewVacationType( ref VacationTypeID,  Name);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name)
		{
			VacationTypeDAC vacationtypeComponent = new VacationTypeDAC();
            int VacationTypeID = 0;

			return vacationtypeComponent.InsertNewVacationType( ref VacationTypeID,  Name);
		}
		public bool Update(VacationType vacationtype ,int old_vacationTypeID)
		{
			VacationTypeDAC vacationtypeComponent = new VacationTypeDAC();
			return vacationtypeComponent.UpdateVacationType( vacationtype.Name,  old_vacationTypeID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int Original_VacationTypeID)
		{
			VacationTypeDAC vacationtypeComponent = new VacationTypeDAC();
			return vacationtypeComponent.UpdateVacationType( Name,  Original_VacationTypeID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_VacationTypeID)
		{
			VacationTypeDAC vacationtypeComponent = new VacationTypeDAC();
			vacationtypeComponent.DeleteVacationType(Original_VacationTypeID);
		}

        #endregion
         public VacationType GetByID(int _vacationTypeID)
         {
             VacationTypeDAC _vacationTypeComponent = new VacationTypeDAC();
             IDataReader reader = _vacationTypeComponent.GetByIDVacationType(_vacationTypeID);
             VacationType _vacationType = null;
             while(reader.Read())
             {
                 _vacationType = new VacationType();
                 if(reader["VacationTypeID"] != DBNull.Value)
                     _vacationType.VacationTypeID = Convert.ToInt32(reader["VacationTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _vacationType.Name = Convert.ToString(reader["Name"]);
             _vacationType.NewRecord = false;             }             reader.Close();
             return _vacationType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			VacationTypeDAC vacationtypecomponent = new VacationTypeDAC();
			return vacationtypecomponent.UpdateDataset(dataset);
		}



	}
}
