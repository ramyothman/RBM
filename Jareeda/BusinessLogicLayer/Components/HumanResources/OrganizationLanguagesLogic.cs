using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for OrganizationLanguages table
	/// This class RAPs the OrganizationLanguagesDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class OrganizationLanguagesLogic : BusinessLogic
	{
		public OrganizationLanguagesLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<OrganizationLanguages> GetAll()
         {
             OrganizationLanguagesDAC _organizationLanguagesComponent = new OrganizationLanguagesDAC();
             IDataReader reader =  _organizationLanguagesComponent.GetAllOrganizationLanguages().CreateDataReader();
             List<OrganizationLanguages> _organizationLanguagesList = new List<OrganizationLanguages>();
             while(reader.Read())
             {
             if(_organizationLanguagesList == null)
                 _organizationLanguagesList = new List<OrganizationLanguages>();
                 OrganizationLanguages _organizationLanguages = new OrganizationLanguages();
                 if(reader["OrganizationLanguagesId"] != DBNull.Value)
                     _organizationLanguages.OrganizationLanguagesId = Convert.ToInt32(reader["OrganizationLanguagesId"]);
                 if(reader["OrganizationId"] != DBNull.Value)
                     _organizationLanguages.OrganizationId = Convert.ToInt32(reader["OrganizationId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _organizationLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["OrganizationName"] != DBNull.Value)
                     _organizationLanguages.OrganizationName = Convert.ToString(reader["OrganizationName"]);
                 if(reader["OrganizationDescription"] != DBNull.Value)
                     _organizationLanguages.OrganizationDescription = Convert.ToString(reader["OrganizationDescription"]);
                 if(reader["AddressLine1"] != DBNull.Value)
                     _organizationLanguages.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                 if(reader["AddressLine2"] != DBNull.Value)
                     _organizationLanguages.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
             _organizationLanguages.NewRecord = false;
             _organizationLanguagesList.Add(_organizationLanguages);
             }             reader.Close();
             return _organizationLanguagesList;
         }


        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<OrganizationLanguages> GetAllByOrganizationId(int OrganizationId)
        {
            OrganizationLanguagesDAC _organizationLanguagesComponent = new OrganizationLanguagesDAC();
            IDataReader reader = _organizationLanguagesComponent.GetAllOrganizationLanguages("OrganizationId = " + OrganizationId).CreateDataReader();
            List<OrganizationLanguages> _organizationLanguagesList = new List<OrganizationLanguages>();
            while (reader.Read())
            {
                if (_organizationLanguagesList == null)
                    _organizationLanguagesList = new List<OrganizationLanguages>();
                OrganizationLanguages _organizationLanguages = new OrganizationLanguages();
                if (reader["OrganizationLanguagesId"] != DBNull.Value)
                    _organizationLanguages.OrganizationLanguagesId = Convert.ToInt32(reader["OrganizationLanguagesId"]);
                if (reader["OrganizationId"] != DBNull.Value)
                    _organizationLanguages.OrganizationId = Convert.ToInt32(reader["OrganizationId"]);
                if (reader["LanguageId"] != DBNull.Value)
                    _organizationLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                if (reader["OrganizationName"] != DBNull.Value)
                    _organizationLanguages.OrganizationName = Convert.ToString(reader["OrganizationName"]);
                if (reader["OrganizationDescription"] != DBNull.Value)
                    _organizationLanguages.OrganizationDescription = Convert.ToString(reader["OrganizationDescription"]);
                if (reader["AddressLine1"] != DBNull.Value)
                    _organizationLanguages.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                if (reader["AddressLine2"] != DBNull.Value)
                    _organizationLanguages.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
                _organizationLanguages.NewRecord = false;
                _organizationLanguagesList.Add(_organizationLanguages);
            } reader.Close();
            return _organizationLanguagesList;
        }

        #region Insert And Update
		public bool Insert(OrganizationLanguages organizationlanguages)
		{
			int autonumber = 0;
			OrganizationLanguagesDAC organizationlanguagesComponent = new OrganizationLanguagesDAC();
			bool endedSuccessfuly = organizationlanguagesComponent.InsertNewOrganizationLanguages( ref autonumber,  organizationlanguages.OrganizationId,  organizationlanguages.LanguageId,  organizationlanguages.OrganizationName,  organizationlanguages.OrganizationDescription,  organizationlanguages.AddressLine1,  organizationlanguages.AddressLine2);
			if(endedSuccessfuly)
			{
				organizationlanguages.OrganizationLanguagesId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int OrganizationLanguagesId,  int OrganizationId,  int LanguageId,  string OrganizationName,  string OrganizationDescription,  string AddressLine1,  string AddressLine2)
		{
			OrganizationLanguagesDAC organizationlanguagesComponent = new OrganizationLanguagesDAC();
			return organizationlanguagesComponent.InsertNewOrganizationLanguages( ref OrganizationLanguagesId,  OrganizationId,  LanguageId,  OrganizationName,  OrganizationDescription,  AddressLine1,  AddressLine2);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int OrganizationId,  int LanguageId,  string OrganizationName,  string OrganizationDescription,  string AddressLine1,  string AddressLine2)
		{
			OrganizationLanguagesDAC organizationlanguagesComponent = new OrganizationLanguagesDAC();
            int OrganizationLanguagesId = 0;

			return organizationlanguagesComponent.InsertNewOrganizationLanguages( ref OrganizationLanguagesId,  OrganizationId,  LanguageId,  OrganizationName,  OrganizationDescription,  AddressLine1,  AddressLine2);
		}
		public bool Update(OrganizationLanguages organizationlanguages ,int old_organizationLanguagesId)
		{
			OrganizationLanguagesDAC organizationlanguagesComponent = new OrganizationLanguagesDAC();
			return organizationlanguagesComponent.UpdateOrganizationLanguages( organizationlanguages.OrganizationId,  organizationlanguages.LanguageId,  organizationlanguages.OrganizationName,  organizationlanguages.OrganizationDescription,  organizationlanguages.AddressLine1,  organizationlanguages.AddressLine2,  old_organizationLanguagesId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int OrganizationId,  int LanguageId,  string OrganizationName,  string OrganizationDescription,  string AddressLine1,  string AddressLine2,  int Original_OrganizationLanguagesId)
		{
			OrganizationLanguagesDAC organizationlanguagesComponent = new OrganizationLanguagesDAC();
			return organizationlanguagesComponent.UpdateOrganizationLanguages( OrganizationId,  LanguageId,  OrganizationName,  OrganizationDescription,  AddressLine1,  AddressLine2,  Original_OrganizationLanguagesId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_OrganizationLanguagesId)
		{
			OrganizationLanguagesDAC organizationlanguagesComponent = new OrganizationLanguagesDAC();
			organizationlanguagesComponent.DeleteOrganizationLanguages(Original_OrganizationLanguagesId);
		}

        #endregion
         public OrganizationLanguages GetByID(int _organizationLanguagesId)
         {
             OrganizationLanguagesDAC _organizationLanguagesComponent = new OrganizationLanguagesDAC();
             IDataReader reader = _organizationLanguagesComponent.GetByIDOrganizationLanguages(_organizationLanguagesId);
             OrganizationLanguages _organizationLanguages = null;
             while(reader.Read())
             {
                 _organizationLanguages = new OrganizationLanguages();
                 if(reader["OrganizationLanguagesId"] != DBNull.Value)
                     _organizationLanguages.OrganizationLanguagesId = Convert.ToInt32(reader["OrganizationLanguagesId"]);
                 if(reader["OrganizationId"] != DBNull.Value)
                     _organizationLanguages.OrganizationId = Convert.ToInt32(reader["OrganizationId"]);
                 if(reader["LanguageId"] != DBNull.Value)
                     _organizationLanguages.LanguageId = Convert.ToInt32(reader["LanguageId"]);
                 if(reader["OrganizationName"] != DBNull.Value)
                     _organizationLanguages.OrganizationName = Convert.ToString(reader["OrganizationName"]);
                 if(reader["OrganizationDescription"] != DBNull.Value)
                     _organizationLanguages.OrganizationDescription = Convert.ToString(reader["OrganizationDescription"]);
                 if(reader["AddressLine1"] != DBNull.Value)
                     _organizationLanguages.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                 if(reader["AddressLine2"] != DBNull.Value)
                     _organizationLanguages.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
             _organizationLanguages.NewRecord = false;             }             reader.Close();
             return _organizationLanguages;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			OrganizationLanguagesDAC organizationlanguagescomponent = new OrganizationLanguagesDAC();
			return organizationlanguagescomponent.UpdateDataset(dataset);
		}



	}
}
