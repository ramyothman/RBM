using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.Persons;
using BusinessLogicLayer.Entities.Persons;
namespace BusinessLogicLayer.Components.Persons
{
	/// <summary>
	/// This is a Business Logic Component Class  for PersonPublication table
	/// This class RAPs the PersonPublicationDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PersonPublicationLogic : BusinessLogic
	{
		public PersonPublicationLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PersonPublication> GetAll()
         {
             PersonPublicationDAC _personPublicationComponent = new PersonPublicationDAC();
             IDataReader reader =  _personPublicationComponent.GetAllPersonPublication().CreateDataReader();
             List<PersonPublication> _personPublicationList = new List<PersonPublication>();
             while(reader.Read())
             {
             if(_personPublicationList == null)
                 _personPublicationList = new List<PersonPublication>();
                 PersonPublication _personPublication = new PersonPublication();
                 if(reader["PersonPublicationId"] != DBNull.Value)
                     _personPublication.PersonPublicationId = Convert.ToInt32(reader["PersonPublicationId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personPublication.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["PublicationTitle"] != DBNull.Value)
                     _personPublication.PublicationTitle = Convert.ToString(reader["PublicationTitle"]);
                 if(reader["PublicationAbstract"] != DBNull.Value)
                     _personPublication.PublicationAbstract = Convert.ToString(reader["PublicationAbstract"]);
                 if(reader["PublicationAttachmentPath"] != DBNull.Value)
                     _personPublication.PublicationAttachmentPath = Convert.ToString(reader["PublicationAttachmentPath"]);
             _personPublication.NewRecord = false;
             _personPublicationList.Add(_personPublication);
             }             reader.Close();
             return _personPublicationList;
         }

        #region Insert And Update
		public bool Insert(PersonPublication personpublication)
		{
			int autonumber = 0;
			PersonPublicationDAC personpublicationComponent = new PersonPublicationDAC();
			bool endedSuccessfuly = personpublicationComponent.InsertNewPersonPublication( ref autonumber,  personpublication.PersonId,  personpublication.PublicationTitle,  personpublication.PublicationAbstract,  personpublication.PublicationAttachmentPath);
			if(endedSuccessfuly)
			{
				personpublication.PersonPublicationId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PersonPublicationId,  int PersonId,  string PublicationTitle,  string PublicationAbstract,  string PublicationAttachmentPath)
		{
			PersonPublicationDAC personpublicationComponent = new PersonPublicationDAC();
			return personpublicationComponent.InsertNewPersonPublication( ref PersonPublicationId,  PersonId,  PublicationTitle,  PublicationAbstract,  PublicationAttachmentPath);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int PersonId,  string PublicationTitle,  string PublicationAbstract,  string PublicationAttachmentPath)
		{
			PersonPublicationDAC personpublicationComponent = new PersonPublicationDAC();
            int PersonPublicationId = 0;

			return personpublicationComponent.InsertNewPersonPublication( ref PersonPublicationId,  PersonId,  PublicationTitle,  PublicationAbstract,  PublicationAttachmentPath);
		}
		public bool Update(PersonPublication personpublication ,int old_personPublicationId)
		{
			PersonPublicationDAC personpublicationComponent = new PersonPublicationDAC();
			return personpublicationComponent.UpdatePersonPublication( personpublication.PersonId,  personpublication.PublicationTitle,  personpublication.PublicationAbstract,  personpublication.PublicationAttachmentPath,  old_personPublicationId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int PersonId,  string PublicationTitle,  string PublicationAbstract,  string PublicationAttachmentPath,  int Original_PersonPublicationId)
		{
			PersonPublicationDAC personpublicationComponent = new PersonPublicationDAC();
			return personpublicationComponent.UpdatePersonPublication( PersonId,  PublicationTitle,  PublicationAbstract,  PublicationAttachmentPath,  Original_PersonPublicationId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PersonPublicationId)
		{
			PersonPublicationDAC personpublicationComponent = new PersonPublicationDAC();
			personpublicationComponent.DeletePersonPublication(Original_PersonPublicationId);
		}

        #endregion
         public PersonPublication GetByID(int _personPublicationId)
         {
             PersonPublicationDAC _personPublicationComponent = new PersonPublicationDAC();
             IDataReader reader = _personPublicationComponent.GetByIDPersonPublication(_personPublicationId);
             PersonPublication _personPublication = null;
             while(reader.Read())
             {
                 _personPublication = new PersonPublication();
                 if(reader["PersonPublicationId"] != DBNull.Value)
                     _personPublication.PersonPublicationId = Convert.ToInt32(reader["PersonPublicationId"]);
                 if(reader["PersonId"] != DBNull.Value)
                     _personPublication.PersonId = Convert.ToInt32(reader["PersonId"]);
                 if(reader["PublicationTitle"] != DBNull.Value)
                     _personPublication.PublicationTitle = Convert.ToString(reader["PublicationTitle"]);
                 if(reader["PublicationAbstract"] != DBNull.Value)
                     _personPublication.PublicationAbstract = Convert.ToString(reader["PublicationAbstract"]);
                 if(reader["PublicationAttachmentPath"] != DBNull.Value)
                     _personPublication.PublicationAttachmentPath = Convert.ToString(reader["PublicationAttachmentPath"]);
             _personPublication.NewRecord = false;             }             reader.Close();
             return _personPublication;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PersonPublicationDAC personpublicationcomponent = new PersonPublicationDAC();
			return personpublicationcomponent.UpdateDataset(dataset);
		}



	}
}
