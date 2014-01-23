using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for EducationType table
	/// This class RAPs the EducationTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class EducationTypeLogic : BusinessLogic
	{
		public EducationTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<EducationType> GetAll()
         {
             EducationTypeDAC _educationTypeComponent = new EducationTypeDAC();
             IDataReader reader =  _educationTypeComponent.GetAllEducationType().CreateDataReader();
             List<EducationType> _educationTypeList = new List<EducationType>();
             while(reader.Read())
             {
             if(_educationTypeList == null)
                 _educationTypeList = new List<EducationType>();
                 EducationType _educationType = new EducationType();
                 if(reader["EducationTypeId"] != DBNull.Value)
                     _educationType.EducationTypeId = Convert.ToInt32(reader["EducationTypeId"]);
                 if(reader["EducationTypeName"] != DBNull.Value)
                     _educationType.EducationTypeName = Convert.ToString(reader["EducationTypeName"]);
             _educationType.NewRecord = false;
             _educationTypeList.Add(_educationType);
             }             reader.Close();
             return _educationTypeList;
         }

        #region Insert And Update
		public bool Insert(EducationType educationtype)
		{
			int autonumber = 0;
			EducationTypeDAC educationtypeComponent = new EducationTypeDAC();
			bool endedSuccessfuly = educationtypeComponent.InsertNewEducationType( ref autonumber,  educationtype.EducationTypeName);
			if(endedSuccessfuly)
			{
				educationtype.EducationTypeId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int EducationTypeId,  string EducationTypeName)
		{
			EducationTypeDAC educationtypeComponent = new EducationTypeDAC();
			return educationtypeComponent.InsertNewEducationType( ref EducationTypeId,  EducationTypeName);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string EducationTypeName)
		{
			EducationTypeDAC educationtypeComponent = new EducationTypeDAC();
            int EducationTypeId = 0;

			return educationtypeComponent.InsertNewEducationType( ref EducationTypeId,  EducationTypeName);
		}
		public bool Update(EducationType educationtype ,int old_educationTypeId)
		{
			EducationTypeDAC educationtypeComponent = new EducationTypeDAC();
			return educationtypeComponent.UpdateEducationType( educationtype.EducationTypeName,  old_educationTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string EducationTypeName,  int Original_EducationTypeId)
		{
			EducationTypeDAC educationtypeComponent = new EducationTypeDAC();
			return educationtypeComponent.UpdateEducationType( EducationTypeName,  Original_EducationTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_EducationTypeId)
		{
			EducationTypeDAC educationtypeComponent = new EducationTypeDAC();
			educationtypeComponent.DeleteEducationType(Original_EducationTypeId);
		}

        #endregion
         public EducationType GetByID(int _educationTypeId)
         {
             EducationTypeDAC _educationTypeComponent = new EducationTypeDAC();
             IDataReader reader = _educationTypeComponent.GetByIDEducationType(_educationTypeId);
             EducationType _educationType = null;
             while(reader.Read())
             {
                 _educationType = new EducationType();
                 if(reader["EducationTypeId"] != DBNull.Value)
                     _educationType.EducationTypeId = Convert.ToInt32(reader["EducationTypeId"]);
                 if(reader["EducationTypeName"] != DBNull.Value)
                     _educationType.EducationTypeName = Convert.ToString(reader["EducationTypeName"]);
             _educationType.NewRecord = false;             }             reader.Close();
             return _educationType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			EducationTypeDAC educationtypecomponent = new EducationTypeDAC();
			return educationtypecomponent.UpdateDataset(dataset);
		}



	}
}
