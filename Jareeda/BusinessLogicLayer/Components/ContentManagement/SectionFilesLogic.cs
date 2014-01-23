using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.ContentManagement;
using BusinessLogicLayer.Entities.ContentManagement;
namespace BusinessLogicLayer.Components.ContentManagement
{
	/// <summary>
	/// This is a Business Logic Component Class  for SectionFiles table
	/// This class RAPs the SectionFilesDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class SectionFilesLogic : BusinessLogic
	{
		public SectionFilesLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<SectionFiles> GetAll()
         {
             SectionFilesDAC _sectionFilesComponent = new SectionFilesDAC();
             IDataReader reader =  _sectionFilesComponent.GetAllSectionFiles().CreateDataReader();
             List<SectionFiles> _sectionFilesList = new List<SectionFiles>();
             while(reader.Read())
             {
             if(_sectionFilesList == null)
                 _sectionFilesList = new List<SectionFiles>();
                 SectionFiles _sectionFiles = new SectionFiles();
                 if(reader["SectionFileId"] != DBNull.Value)
                     _sectionFiles.SectionFileId = Convert.ToInt32(reader["SectionFileId"]);
                 if(reader["SectionFileName"] != DBNull.Value)
                     _sectionFiles.SectionFileName = Convert.ToString(reader["SectionFileName"]);
                 if(reader["SectionFilePath"] != DBNull.Value)
                     _sectionFiles.SectionFilePath = Convert.ToString(reader["SectionFilePath"]);
                 if(reader["SectionId"] != DBNull.Value)
                     _sectionFiles.SectionId = Convert.ToInt32(reader["SectionId"]);
                 if(reader["SecurityAccessTypeId"] != DBNull.Value)
                     _sectionFiles.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
             _sectionFiles.NewRecord = false;
             _sectionFilesList.Add(_sectionFiles);
             }             reader.Close();
             return _sectionFilesList;
         }

        #region Insert And Update
		public bool Insert(SectionFiles sectionfiles)
		{
			SectionFilesDAC sectionfilesComponent = new SectionFilesDAC();
			return sectionfilesComponent.InsertNewSectionFiles( sectionfiles.SectionFileId,  sectionfiles.SectionFileName,  sectionfiles.SectionFilePath,  sectionfiles.SectionId,  sectionfiles.SecurityAccessTypeId);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int SectionFileId,  string SectionFileName,  string SectionFilePath,  int SectionId,  int SecurityAccessTypeId)
		{
			SectionFilesDAC sectionfilesComponent = new SectionFilesDAC();
			return sectionfilesComponent.InsertNewSectionFiles( SectionFileId,  SectionFileName,  SectionFilePath,  SectionId,  SecurityAccessTypeId);
		}
		public bool Update(SectionFiles sectionfiles ,int old_sectionFileId)
		{
			SectionFilesDAC sectionfilesComponent = new SectionFilesDAC();
			return sectionfilesComponent.UpdateSectionFiles( sectionfiles.SectionFileId,  sectionfiles.SectionFileName,  sectionfiles.SectionFilePath,  sectionfiles.SectionId,  sectionfiles.SecurityAccessTypeId,  old_sectionFileId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int SectionFileId,  string SectionFileName,  string SectionFilePath,  int SectionId,  int SecurityAccessTypeId,  int Original_SectionFileId)
		{
			SectionFilesDAC sectionfilesComponent = new SectionFilesDAC();
			return sectionfilesComponent.UpdateSectionFiles( SectionFileId,  SectionFileName,  SectionFilePath,  SectionId,  SecurityAccessTypeId,  Original_SectionFileId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_SectionFileId)
		{
			SectionFilesDAC sectionfilesComponent = new SectionFilesDAC();
			sectionfilesComponent.DeleteSectionFiles(Original_SectionFileId);
		}

        #endregion
         public SectionFiles GetByID(int _sectionFileId)
         {
             SectionFilesDAC _sectionFilesComponent = new SectionFilesDAC();
             IDataReader reader = _sectionFilesComponent.GetByIDSectionFiles(_sectionFileId);
             SectionFiles _sectionFiles = null;
             while(reader.Read())
             {
                 _sectionFiles = new SectionFiles();
                 if(reader["SectionFileId"] != DBNull.Value)
                     _sectionFiles.SectionFileId = Convert.ToInt32(reader["SectionFileId"]);
                 if(reader["SectionFileName"] != DBNull.Value)
                     _sectionFiles.SectionFileName = Convert.ToString(reader["SectionFileName"]);
                 if(reader["SectionFilePath"] != DBNull.Value)
                     _sectionFiles.SectionFilePath = Convert.ToString(reader["SectionFilePath"]);
                 if(reader["SectionId"] != DBNull.Value)
                     _sectionFiles.SectionId = Convert.ToInt32(reader["SectionId"]);
                 if(reader["SecurityAccessTypeId"] != DBNull.Value)
                     _sectionFiles.SecurityAccessTypeId = Convert.ToInt32(reader["SecurityAccessTypeId"]);
             _sectionFiles.NewRecord = false;             }             reader.Close();
             return _sectionFiles;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			SectionFilesDAC sectionfilescomponent = new SectionFilesDAC();
			return sectionfilescomponent.UpdateDataset(dataset);
		}



	}
}
