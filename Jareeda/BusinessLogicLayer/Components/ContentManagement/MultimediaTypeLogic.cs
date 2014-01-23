using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for MultimediaType table
	/// This class RAPs the MultimediaTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class MultimediaTypeLogic : BusinessLogic
	{
		public MultimediaTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<MultimediaType> GetAll()
         {
             MultimediaTypeDAC _multimediaTypeComponent = new MultimediaTypeDAC();
             IDataReader reader =  _multimediaTypeComponent.GetAllMultimediaType().CreateDataReader();
             List<MultimediaType> _multimediaTypeList = new List<MultimediaType>();
             while(reader.Read())
             {
             if(_multimediaTypeList == null)
                 _multimediaTypeList = new List<MultimediaType>();
                 MultimediaType _multimediaType = new MultimediaType();
                 if(reader["MultimediaTypeID"] != DBNull.Value)
                     _multimediaType.MultimediaTypeID = Convert.ToInt32(reader["MultimediaTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _multimediaType.Name = Convert.ToString(reader["Name"]);
             _multimediaType.NewRecord = false;
             _multimediaTypeList.Add(_multimediaType);
             }             reader.Close();
             return _multimediaTypeList;
         }

        #region Insert And Update
		public bool Insert(MultimediaType multimediatype)
		{
			int autonumber = 0;
			MultimediaTypeDAC multimediatypeComponent = new MultimediaTypeDAC();
			bool endedSuccessfuly = multimediatypeComponent.InsertNewMultimediaType( ref autonumber,  multimediatype.Name);
			if(endedSuccessfuly)
			{
				multimediatype.MultimediaTypeID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int MultimediaTypeID,  string Name)
		{
			MultimediaTypeDAC multimediatypeComponent = new MultimediaTypeDAC();
			return multimediatypeComponent.InsertNewMultimediaType( ref MultimediaTypeID,  Name);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name)
		{
			MultimediaTypeDAC multimediatypeComponent = new MultimediaTypeDAC();
            int MultimediaTypeID = 0;

			return multimediatypeComponent.InsertNewMultimediaType( ref MultimediaTypeID,  Name);
		}
		public bool Update(MultimediaType multimediatype ,int old_multimediaTypeID)
		{
			MultimediaTypeDAC multimediatypeComponent = new MultimediaTypeDAC();
			return multimediatypeComponent.UpdateMultimediaType( multimediatype.Name,  old_multimediaTypeID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int Original_MultimediaTypeID)
		{
			MultimediaTypeDAC multimediatypeComponent = new MultimediaTypeDAC();
			return multimediatypeComponent.UpdateMultimediaType( Name,  Original_MultimediaTypeID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_MultimediaTypeID)
		{
			MultimediaTypeDAC multimediatypeComponent = new MultimediaTypeDAC();
			multimediatypeComponent.DeleteMultimediaType(Original_MultimediaTypeID);
		}

        #endregion
         public MultimediaType GetByID(int _multimediaTypeID)
         {
             MultimediaTypeDAC _multimediaTypeComponent = new MultimediaTypeDAC();
             IDataReader reader = _multimediaTypeComponent.GetByIDMultimediaType(_multimediaTypeID);
             MultimediaType _multimediaType = null;
             while(reader.Read())
             {
                 _multimediaType = new MultimediaType();
                 if(reader["MultimediaTypeID"] != DBNull.Value)
                     _multimediaType.MultimediaTypeID = Convert.ToInt32(reader["MultimediaTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _multimediaType.Name = Convert.ToString(reader["Name"]);
             _multimediaType.NewRecord = false;             }             reader.Close();
             return _multimediaType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			MultimediaTypeDAC multimediatypecomponent = new MultimediaTypeDAC();
			return multimediatypecomponent.UpdateDataset(dataset);
		}



	}
}
