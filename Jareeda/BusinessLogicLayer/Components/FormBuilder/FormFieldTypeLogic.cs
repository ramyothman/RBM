using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.FormBuilder;
using BusinessLogicLayer.Entities.FormBuilder;
namespace BusinessLogicLayer.Components.FormBuilder
{
	/// <summary>
	/// This is a Business Logic Component Class  for FormFieldType table
	/// This class RAPs the FormFieldTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class FormFieldTypeLogic : BusinessLogic
	{
		public FormFieldTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<FormFieldType> GetAll()
         {
             FormFieldTypeDAC _formFieldTypeComponent = new FormFieldTypeDAC();
             IDataReader reader =  _formFieldTypeComponent.GetAllFormFieldType().CreateDataReader();
             List<FormFieldType> _formFieldTypeList = new List<FormFieldType>();
             while(reader.Read())
             {
             if(_formFieldTypeList == null)
                 _formFieldTypeList = new List<FormFieldType>();
                 FormFieldType _formFieldType = new FormFieldType();
                 if(reader["FormFieldTypeId"] != DBNull.Value)
                     _formFieldType.FormFieldTypeId = Convert.ToInt32(reader["FormFieldTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _formFieldType.Name = Convert.ToString(reader["Name"]);
                 if(reader["Template"] != DBNull.Value)
                     _formFieldType.Template = Convert.ToString(reader["Template"]);
             _formFieldType.NewRecord = false;
             _formFieldTypeList.Add(_formFieldType);
             }             reader.Close();
             return _formFieldTypeList;
         }

        #region Insert And Update
		public bool Insert(FormFieldType formfieldtype)
		{
			FormFieldTypeDAC formfieldtypeComponent = new FormFieldTypeDAC();
			return formfieldtypeComponent.InsertNewFormFieldType( formfieldtype.FormFieldTypeId,  formfieldtype.Name,  formfieldtype.Template);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int FormFieldTypeId,  string Name,  string Template)
		{
			FormFieldTypeDAC formfieldtypeComponent = new FormFieldTypeDAC();
			return formfieldtypeComponent.InsertNewFormFieldType( FormFieldTypeId,  Name,  Template);
		}
		public bool Update(FormFieldType formfieldtype ,int old_formFieldTypeId)
		{
			FormFieldTypeDAC formfieldtypeComponent = new FormFieldTypeDAC();
			return formfieldtypeComponent.UpdateFormFieldType( formfieldtype.FormFieldTypeId,  formfieldtype.Name,  formfieldtype.Template,  old_formFieldTypeId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int FormFieldTypeId,  string Name,  string Template,  int Original_FormFieldTypeId)
		{
			FormFieldTypeDAC formfieldtypeComponent = new FormFieldTypeDAC();
			return formfieldtypeComponent.UpdateFormFieldType( FormFieldTypeId,  Name,  Template,  Original_FormFieldTypeId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_FormFieldTypeId)
		{
			FormFieldTypeDAC formfieldtypeComponent = new FormFieldTypeDAC();
			formfieldtypeComponent.DeleteFormFieldType(Original_FormFieldTypeId);
		}

        #endregion
         public FormFieldType GetByID(int _formFieldTypeId)
         {
             FormFieldTypeDAC _formFieldTypeComponent = new FormFieldTypeDAC();
             IDataReader reader = _formFieldTypeComponent.GetByIDFormFieldType(_formFieldTypeId);
             FormFieldType _formFieldType = null;
             while(reader.Read())
             {
                 _formFieldType = new FormFieldType();
                 if(reader["FormFieldTypeId"] != DBNull.Value)
                     _formFieldType.FormFieldTypeId = Convert.ToInt32(reader["FormFieldTypeId"]);
                 if(reader["Name"] != DBNull.Value)
                     _formFieldType.Name = Convert.ToString(reader["Name"]);
                 if(reader["Template"] != DBNull.Value)
                     _formFieldType.Template = Convert.ToString(reader["Template"]);
             _formFieldType.NewRecord = false;             }             reader.Close();
             return _formFieldType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			FormFieldTypeDAC formfieldtypecomponent = new FormFieldTypeDAC();
			return formfieldtypecomponent.UpdateDataset(dataset);
		}



	}
}
