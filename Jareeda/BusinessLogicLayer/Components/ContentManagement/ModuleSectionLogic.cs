using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for ModuleSection table
	/// This class RAPs the ModuleSectionDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class ModuleSectionLogic : BusinessLogic
	{
		public ModuleSectionLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<ModuleSection> GetAll()
         {
             ModuleSectionDAC _moduleSectionComponent = new ModuleSectionDAC();
             IDataReader reader =  _moduleSectionComponent.GetAllModuleSection().CreateDataReader();
             List<ModuleSection> _moduleSectionList = new List<ModuleSection>();
             while(reader.Read())
             {
             if(_moduleSectionList == null)
                 _moduleSectionList = new List<ModuleSection>();
                 ModuleSection _moduleSection = new ModuleSection();
                 if(reader["ModuleSectionID"] != DBNull.Value)
                     _moduleSection.ModuleSectionID = Convert.ToInt32(reader["ModuleSectionID"]);
                 if(reader["HomePageID"] != DBNull.Value)
                     _moduleSection.HomePageID = Convert.ToInt32(reader["HomePageID"]);
                 if(reader["SectionID"] != DBNull.Value)
                     _moduleSection.SectionID = Convert.ToInt32(reader["SectionID"]);
                 if(reader["OrderNumber"] != DBNull.Value)
                     _moduleSection.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                 if(reader["ItemsNumber"] != DBNull.Value)
                     _moduleSection.ItemsNumber = Convert.ToInt32(reader["ItemsNumber"]);
                 if(reader["ItemsPerPage"] != DBNull.Value)
                     _moduleSection.ItemsPerPage = Convert.ToInt32(reader["ItemsPerPage"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _moduleSection.IsActive = Convert.ToBoolean(reader["IsActive"]);
             _moduleSection.NewRecord = false;
             _moduleSectionList.Add(_moduleSection);
             }             reader.Close();
             return _moduleSectionList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ModuleSection> GetAllByHomePageID(int HomePageID)
        {
            ModuleSectionDAC _moduleSectionComponent = new ModuleSectionDAC();
            IDataReader reader = _moduleSectionComponent.GetAllModuleSection("HomePageID = " + HomePageID).CreateDataReader();
            List<ModuleSection> _moduleSectionList = new List<ModuleSection>();
            while (reader.Read())
            {
                if (_moduleSectionList == null)
                    _moduleSectionList = new List<ModuleSection>();
                ModuleSection _moduleSection = new ModuleSection();
                if (reader["ModuleSectionID"] != DBNull.Value)
                    _moduleSection.ModuleSectionID = Convert.ToInt32(reader["ModuleSectionID"]);
                if (reader["HomePageID"] != DBNull.Value)
                    _moduleSection.HomePageID = Convert.ToInt32(reader["HomePageID"]);
                if (reader["SectionID"] != DBNull.Value)
                    _moduleSection.SectionID = Convert.ToInt32(reader["SectionID"]);
                if (reader["OrderNumber"] != DBNull.Value)
                    _moduleSection.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                if (reader["ItemsNumber"] != DBNull.Value)
                    _moduleSection.ItemsNumber = Convert.ToInt32(reader["ItemsNumber"]);
                if (reader["ItemsPerPage"] != DBNull.Value)
                    _moduleSection.ItemsPerPage = Convert.ToInt32(reader["ItemsPerPage"]);
                if (reader["IsActive"] != DBNull.Value)
                    _moduleSection.IsActive = Convert.ToBoolean(reader["IsActive"]);
                _moduleSection.NewRecord = false;
                _moduleSectionList.Add(_moduleSection);
            } reader.Close();
            return _moduleSectionList;
        }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<ModuleSection> GetAllBySectionIDs(string SectionIDs)
        {
            ModuleSectionDAC _moduleSectionComponent = new ModuleSectionDAC();
            IDataReader reader = _moduleSectionComponent.GetAllModuleSection("SectionID IN( " + SectionIDs + ")").CreateDataReader();
            List<ModuleSection> _moduleSectionList = new List<ModuleSection>();
            while (reader.Read())
            {
                if (_moduleSectionList == null)
                    _moduleSectionList = new List<ModuleSection>();
                ModuleSection _moduleSection = new ModuleSection();
                if (reader["ModuleSectionID"] != DBNull.Value)
                    _moduleSection.ModuleSectionID = Convert.ToInt32(reader["ModuleSectionID"]);
                if (reader["HomePageID"] != DBNull.Value)
                    _moduleSection.HomePageID = Convert.ToInt32(reader["HomePageID"]);
                if (reader["SectionID"] != DBNull.Value)
                    _moduleSection.SectionID = Convert.ToInt32(reader["SectionID"]);
                if (reader["OrderNumber"] != DBNull.Value)
                    _moduleSection.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                if (reader["ItemsNumber"] != DBNull.Value)
                    _moduleSection.ItemsNumber = Convert.ToInt32(reader["ItemsNumber"]);
                if (reader["ItemsPerPage"] != DBNull.Value)
                    _moduleSection.ItemsPerPage = Convert.ToInt32(reader["ItemsPerPage"]);
                if (reader["IsActive"] != DBNull.Value)
                    _moduleSection.IsActive = Convert.ToBoolean(reader["IsActive"]);
                _moduleSection.NewRecord = false;
                _moduleSectionList.Add(_moduleSection);
            } reader.Close();
            return _moduleSectionList;
        }

        #region Insert And Update
		public bool Insert(ModuleSection modulesection)
		{
			int autonumber = 0;
			ModuleSectionDAC modulesectionComponent = new ModuleSectionDAC();
			bool endedSuccessfuly = modulesectionComponent.InsertNewModuleSection( ref autonumber,  modulesection.HomePageID,  modulesection.SectionID,  modulesection.OrderNumber,  modulesection.ItemsNumber,  modulesection.ItemsPerPage,  modulesection.IsActive);
			if(endedSuccessfuly)
			{
				modulesection.ModuleSectionID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int ModuleSectionID,  int HomePageID,  int SectionID,  int OrderNumber,  int ItemsNumber,  int ItemsPerPage,  bool IsActive)
		{
			ModuleSectionDAC modulesectionComponent = new ModuleSectionDAC();
			return modulesectionComponent.InsertNewModuleSection( ref ModuleSectionID,  HomePageID,  SectionID,  OrderNumber,  ItemsNumber,  ItemsPerPage,  IsActive);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int HomePageID,  int SectionID,  int OrderNumber,  int ItemsNumber,  int ItemsPerPage,  bool IsActive)
		{
			ModuleSectionDAC modulesectionComponent = new ModuleSectionDAC();
            int ModuleSectionID = 0;

			return modulesectionComponent.InsertNewModuleSection( ref ModuleSectionID,  HomePageID,  SectionID,  OrderNumber,  ItemsNumber,  ItemsPerPage,  IsActive);
		}
		public bool Update(ModuleSection modulesection ,int old_moduleSectionID)
		{
			ModuleSectionDAC modulesectionComponent = new ModuleSectionDAC();
			return modulesectionComponent.UpdateModuleSection( modulesection.HomePageID,  modulesection.SectionID,  modulesection.OrderNumber,  modulesection.ItemsNumber,  modulesection.ItemsPerPage,  modulesection.IsActive,  old_moduleSectionID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int HomePageID,  int SectionID,  int OrderNumber,  int ItemsNumber,  int ItemsPerPage,  bool IsActive,  int Original_ModuleSectionID)
		{
			ModuleSectionDAC modulesectionComponent = new ModuleSectionDAC();
			return modulesectionComponent.UpdateModuleSection( HomePageID,  SectionID,  OrderNumber,  ItemsNumber,  ItemsPerPage,  IsActive,  Original_ModuleSectionID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_ModuleSectionID)
		{
			ModuleSectionDAC modulesectionComponent = new ModuleSectionDAC();
			modulesectionComponent.DeleteModuleSection(Original_ModuleSectionID);
		}

        #endregion
         public ModuleSection GetByID(int _moduleSectionID)
         {
             ModuleSectionDAC _moduleSectionComponent = new ModuleSectionDAC();
             IDataReader reader = _moduleSectionComponent.GetByIDModuleSection(_moduleSectionID);
             ModuleSection _moduleSection = null;
             while(reader.Read())
             {
                 _moduleSection = new ModuleSection();
                 if(reader["ModuleSectionID"] != DBNull.Value)
                     _moduleSection.ModuleSectionID = Convert.ToInt32(reader["ModuleSectionID"]);
                 if(reader["HomePageID"] != DBNull.Value)
                     _moduleSection.HomePageID = Convert.ToInt32(reader["HomePageID"]);
                 if(reader["SectionID"] != DBNull.Value)
                     _moduleSection.SectionID = Convert.ToInt32(reader["SectionID"]);
                 if(reader["OrderNumber"] != DBNull.Value)
                     _moduleSection.OrderNumber = Convert.ToInt32(reader["OrderNumber"]);
                 if(reader["ItemsNumber"] != DBNull.Value)
                     _moduleSection.ItemsNumber = Convert.ToInt32(reader["ItemsNumber"]);
                 if(reader["ItemsPerPage"] != DBNull.Value)
                     _moduleSection.ItemsPerPage = Convert.ToInt32(reader["ItemsPerPage"]);
                 if(reader["IsActive"] != DBNull.Value)
                     _moduleSection.IsActive = Convert.ToBoolean(reader["IsActive"]);
             _moduleSection.NewRecord = false;             }             reader.Close();
             return _moduleSection;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			ModuleSectionDAC modulesectioncomponent = new ModuleSectionDAC();
			return modulesectioncomponent.UpdateDataset(dataset);
		}



	}
}
