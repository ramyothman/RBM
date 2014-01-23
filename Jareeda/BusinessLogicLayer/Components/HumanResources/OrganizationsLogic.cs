using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for Organizations table
	/// This class RAPs the OrganizationsDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class OrganizationsLogic : BusinessLogic
	{
		public OrganizationsLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<Organizations> GetAll()
         {
             OrganizationsDAC _organizationsComponent = new OrganizationsDAC();
             IDataReader reader =  _organizationsComponent.GetAllOrganizations().CreateDataReader();
             List<Organizations> _organizationsList = new List<Organizations>();
             while(reader.Read())
             {
             if(_organizationsList == null)
                 _organizationsList = new List<Organizations>();
                 Organizations _organizations = new Organizations();
                 if(reader["OrganizationId"] != DBNull.Value)
                     _organizations.OrganizationId = Convert.ToInt32(reader["OrganizationId"]);
                 if(reader["OrganizationName"] != DBNull.Value)
                     _organizations.OrganizationName = Convert.ToString(reader["OrganizationName"]);
                 if(reader["OrganizationDescription"] != DBNull.Value)
                     _organizations.OrganizationDescription = Convert.ToString(reader["OrganizationDescription"]);
                 if(reader["Phone1"] != DBNull.Value)
                     _organizations.Phone1 = Convert.ToString(reader["Phone1"]);
                 if(reader["Phone2"] != DBNull.Value)
                     _organizations.Phone2 = Convert.ToString(reader["Phone2"]);
                 if(reader["Phone3"] != DBNull.Value)
                     _organizations.Phone3 = Convert.ToString(reader["Phone3"]);
                 if(reader["Fax1"] != DBNull.Value)
                     _organizations.Fax1 = Convert.ToString(reader["Fax1"]);
                 if(reader["Fax2"] != DBNull.Value)
                     _organizations.Fax2 = Convert.ToString(reader["Fax2"]);
                 if(reader["AddressLine1"] != DBNull.Value)
                     _organizations.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                 if(reader["AddressLine2"] != DBNull.Value)
                     _organizations.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
             _organizations.NewRecord = false;
             _organizationsList.Add(_organizations);
             }             reader.Close();
             return _organizationsList;
         }

        #region Insert And Update
		public bool Insert(Organizations organizations)
		{
			int autonumber = 0;
			OrganizationsDAC organizationsComponent = new OrganizationsDAC();
			bool endedSuccessfuly = organizationsComponent.InsertNewOrganizations( ref autonumber,  organizations.OrganizationName,  organizations.OrganizationDescription,  organizations.Phone1,  organizations.Phone2,  organizations.Phone3,  organizations.Fax1,  organizations.Fax2,  organizations.AddressLine1,  organizations.AddressLine2);
			if(endedSuccessfuly)
			{
				organizations.OrganizationId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int OrganizationId,  string OrganizationName,  string OrganizationDescription,  string Phone1,  string Phone2,  string Phone3,  string Fax1,  string Fax2,  string AddressLine1,  string AddressLine2)
		{
			OrganizationsDAC organizationsComponent = new OrganizationsDAC();
			return organizationsComponent.InsertNewOrganizations( ref OrganizationId,  OrganizationName,  OrganizationDescription,  Phone1,  Phone2,  Phone3,  Fax1,  Fax2,  AddressLine1,  AddressLine2);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string OrganizationName,  string OrganizationDescription,  string Phone1,  string Phone2,  string Phone3,  string Fax1,  string Fax2,  string AddressLine1,  string AddressLine2)
		{
			OrganizationsDAC organizationsComponent = new OrganizationsDAC();
            int OrganizationId = 0;

			return organizationsComponent.InsertNewOrganizations( ref OrganizationId,  OrganizationName,  OrganizationDescription,  Phone1,  Phone2,  Phone3,  Fax1,  Fax2,  AddressLine1,  AddressLine2);
		}
		public bool Update(Organizations organizations ,int old_organizationId)
		{
			OrganizationsDAC organizationsComponent = new OrganizationsDAC();
			return organizationsComponent.UpdateOrganizations( organizations.OrganizationName,  organizations.OrganizationDescription,  organizations.Phone1,  organizations.Phone2,  organizations.Phone3,  organizations.Fax1,  organizations.Fax2,  organizations.AddressLine1,  organizations.AddressLine2,  old_organizationId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string OrganizationName,  string OrganizationDescription,  string Phone1,  string Phone2,  string Phone3,  string Fax1,  string Fax2,  string AddressLine1,  string AddressLine2,  int Original_OrganizationId)
		{
			OrganizationsDAC organizationsComponent = new OrganizationsDAC();
			return organizationsComponent.UpdateOrganizations( OrganizationName,  OrganizationDescription,  Phone1,  Phone2,  Phone3,  Fax1,  Fax2,  AddressLine1,  AddressLine2,  Original_OrganizationId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_OrganizationId)
		{
			OrganizationsDAC organizationsComponent = new OrganizationsDAC();
			organizationsComponent.DeleteOrganizations(Original_OrganizationId);
		}

        #endregion
         public Organizations GetByID(int _organizationId)
         {
             OrganizationsDAC _organizationsComponent = new OrganizationsDAC();
             IDataReader reader = _organizationsComponent.GetByIDOrganizations(_organizationId);
             Organizations _organizations = null;
             while(reader.Read())
             {
                 _organizations = new Organizations();
                 if(reader["OrganizationId"] != DBNull.Value)
                     _organizations.OrganizationId = Convert.ToInt32(reader["OrganizationId"]);
                 if(reader["OrganizationName"] != DBNull.Value)
                     _organizations.OrganizationName = Convert.ToString(reader["OrganizationName"]);
                 if(reader["OrganizationDescription"] != DBNull.Value)
                     _organizations.OrganizationDescription = Convert.ToString(reader["OrganizationDescription"]);
                 if(reader["Phone1"] != DBNull.Value)
                     _organizations.Phone1 = Convert.ToString(reader["Phone1"]);
                 if(reader["Phone2"] != DBNull.Value)
                     _organizations.Phone2 = Convert.ToString(reader["Phone2"]);
                 if(reader["Phone3"] != DBNull.Value)
                     _organizations.Phone3 = Convert.ToString(reader["Phone3"]);
                 if(reader["Fax1"] != DBNull.Value)
                     _organizations.Fax1 = Convert.ToString(reader["Fax1"]);
                 if(reader["Fax2"] != DBNull.Value)
                     _organizations.Fax2 = Convert.ToString(reader["Fax2"]);
                 if(reader["AddressLine1"] != DBNull.Value)
                     _organizations.AddressLine1 = Convert.ToString(reader["AddressLine1"]);
                 if(reader["AddressLine2"] != DBNull.Value)
                     _organizations.AddressLine2 = Convert.ToString(reader["AddressLine2"]);
             _organizations.NewRecord = false;             }             reader.Close();
             return _organizations;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			OrganizationsDAC organizationscomponent = new OrganizationsDAC();
			return organizationscomponent.UpdateDataset(dataset);
		}



	}
}
