using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.FormBuilder;
using BusinessLogicLayer.Entities.FormBuilder;
namespace BusinessLogicLayer.Components.FormBuilder
{
	/// <summary>
	/// This is a Business Logic Component Class  for FormField table
	/// This class RAPs the FormFieldDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class FormFieldLogic : BusinessLogic
	{
		public FormFieldLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<FormField> GetAll()
         {
             FormFieldDAC _formFieldComponent = new FormFieldDAC();
             IDataReader reader =  _formFieldComponent.GetAllFormField().CreateDataReader();
             List<FormField> _formFieldList = new List<FormField>();
             while(reader.Read())
             {
             if(_formFieldList == null)
                 _formFieldList = new List<FormField>();
                 FormField _formField = new FormField();
                 if(reader["FormFieldId"] != DBNull.Value)
                     _formField.FormFieldId = Convert.ToInt32(reader["FormFieldId"]);
                 if(reader["FormDocumentId"] != DBNull.Value)
                     _formField.FormDocumentId = Convert.ToInt32(reader["FormDocumentId"]);
                 if(reader["FormFieldTypeId"] != DBNull.Value)
                     _formField.FormFieldTypeId = Convert.ToInt32(reader["FormFieldTypeId"]);
                 if(reader["FieldParentId"] != DBNull.Value)
                     _formField.FieldParentId = Convert.ToInt32(reader["FieldParentId"]);
                 if(reader["Title"] != DBNull.Value)
                     _formField.Title = Convert.ToString(reader["Title"]);
                 if(reader["HelpText"] != DBNull.Value)
                     _formField.HelpText = Convert.ToString(reader["HelpText"]);
                 if(reader["FormFieldOrder"] != DBNull.Value)
                     _formField.FormFieldOrder = Convert.ToInt32(reader["FormFieldOrder"]);
                 if(reader["FieldDegree"] != DBNull.Value)
                     _formField.FieldDegree = Convert.ToInt32(reader["FieldDegree"]);
                 if(reader["HasOther"] != DBNull.Value)
                     _formField.HasOther = Convert.ToBoolean(reader["HasOther"]);
                 if(reader["DefaultValue"] != DBNull.Value)
                     _formField.DefaultValue = Convert.ToString(reader["DefaultValue"]);
                 if(reader["IsRequired"] != DBNull.Value)
                     _formField.IsRequired = Convert.ToBoolean(reader["IsRequired"]);
                 if(reader["RegularExpValidation"] != DBNull.Value)
                     _formField.RegularExpValidation = Convert.ToString(reader["RegularExpValidation"]);
                 if(reader["ErrorText"] != DBNull.Value)
                     _formField.ErrorText = Convert.ToString(reader["ErrorText"]);
                 if(reader["IsContactEmail"] != DBNull.Value)
                     _formField.IsContactEmail = Convert.ToBoolean(reader["IsContactEmail"]);
                 if(reader["IsContactMobile"] != DBNull.Value)
                     _formField.IsContactMobile = Convert.ToBoolean(reader["IsContactMobile"]);
                 if(reader["ColumnCount"] != DBNull.Value)
                     _formField.ColumnCount = Convert.ToInt32(reader["ColumnCount"]);
                 if(reader["IsSection"] != DBNull.Value)
                     _formField.IsSection = Convert.ToBoolean(reader["IsSection"]);
                 if(reader["IsPageBreak"] != DBNull.Value)
                     _formField.IsPageBreak = Convert.ToBoolean(reader["IsPageBreak"]);
             _formField.NewRecord = false;
             _formFieldList.Add(_formField);
             }             reader.Close();
             return _formFieldList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<FormField> GetAllByFormDocumentId(int FormDocumentId)
        {
            FormFieldDAC _formFieldComponent = new FormFieldDAC();
            IDataReader reader = _formFieldComponent.GetAllFormField("FormDocumentId = " + FormDocumentId).CreateDataReader();
            List<FormField> _formFieldList = new List<FormField>();
            while (reader.Read())
            {
                if (_formFieldList == null)
                    _formFieldList = new List<FormField>();
                FormField _formField = new FormField();
                if (reader["FormFieldId"] != DBNull.Value)
                    _formField.FormFieldId = Convert.ToInt32(reader["FormFieldId"]);
                if (reader["FormDocumentId"] != DBNull.Value)
                    _formField.FormDocumentId = Convert.ToInt32(reader["FormDocumentId"]);
                if (reader["FormFieldTypeId"] != DBNull.Value)
                    _formField.FormFieldTypeId = Convert.ToInt32(reader["FormFieldTypeId"]);
                if (reader["FieldParentId"] != DBNull.Value)
                    _formField.FieldParentId = Convert.ToInt32(reader["FieldParentId"]);
                if (reader["Title"] != DBNull.Value)
                    _formField.Title = Convert.ToString(reader["Title"]);
                if (reader["HelpText"] != DBNull.Value)
                    _formField.HelpText = Convert.ToString(reader["HelpText"]);
                if (reader["FormFieldOrder"] != DBNull.Value)
                    _formField.FormFieldOrder = Convert.ToInt32(reader["FormFieldOrder"]);
                if (reader["FieldDegree"] != DBNull.Value)
                    _formField.FieldDegree = Convert.ToInt32(reader["FieldDegree"]);
                if (reader["HasOther"] != DBNull.Value)
                    _formField.HasOther = Convert.ToBoolean(reader["HasOther"]);
                if (reader["DefaultValue"] != DBNull.Value)
                    _formField.DefaultValue = Convert.ToString(reader["DefaultValue"]);
                if (reader["IsRequired"] != DBNull.Value)
                    _formField.IsRequired = Convert.ToBoolean(reader["IsRequired"]);
                if (reader["RegularExpValidation"] != DBNull.Value)
                    _formField.RegularExpValidation = Convert.ToString(reader["RegularExpValidation"]);
                if (reader["ErrorText"] != DBNull.Value)
                    _formField.ErrorText = Convert.ToString(reader["ErrorText"]);
                if (reader["IsContactEmail"] != DBNull.Value)
                    _formField.IsContactEmail = Convert.ToBoolean(reader["IsContactEmail"]);
                if (reader["IsContactMobile"] != DBNull.Value)
                    _formField.IsContactMobile = Convert.ToBoolean(reader["IsContactMobile"]);
                if (reader["ColumnCount"] != DBNull.Value)
                    _formField.ColumnCount = Convert.ToInt32(reader["ColumnCount"]);
                if (reader["IsSection"] != DBNull.Value)
                    _formField.IsSection = Convert.ToBoolean(reader["IsSection"]);
                if (reader["IsPageBreak"] != DBNull.Value)
                    _formField.IsPageBreak = Convert.ToBoolean(reader["IsPageBreak"]);
                _formField.NewRecord = false;
                _formFieldList.Add(_formField);
            } reader.Close();
            return _formFieldList;
        }

        public int GetTotalSubmissions(int ID)
        {
            FormFieldDAC _formFieldComponent = new FormFieldDAC();
            return _formFieldComponent.GetFieldTotalSubmissions(ID);
        }
        #region Insert And Update
		public bool Insert(FormField formfield)
		{
			int autonumber = 0;
			FormFieldDAC formfieldComponent = new FormFieldDAC();
			bool endedSuccessfuly = formfieldComponent.InsertNewFormField( ref autonumber,  formfield.FormDocumentId,  formfield.FormFieldTypeId,  formfield.FieldParentId,  formfield.Title,  formfield.HelpText,  formfield.FormFieldOrder,  formfield.FieldDegree,  formfield.HasOther,  formfield.DefaultValue,  formfield.IsRequired,  formfield.RegularExpValidation,  formfield.ErrorText,  formfield.IsContactEmail,  formfield.IsContactMobile,  formfield.ColumnCount,  formfield.IsSection,  formfield.IsPageBreak);
			if(endedSuccessfuly)
			{
				formfield.FormFieldId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int FormFieldId,  int FormDocumentId,  int FormFieldTypeId,  int FieldParentId,  string Title,  string HelpText,  int FormFieldOrder,  int FieldDegree,  bool HasOther,  string DefaultValue,  bool IsRequired,  string RegularExpValidation,  string ErrorText,  bool IsContactEmail,  bool IsContactMobile,  int ColumnCount,  bool IsSection,  bool IsPageBreak)
		{
			FormFieldDAC formfieldComponent = new FormFieldDAC();
			return formfieldComponent.InsertNewFormField( ref FormFieldId,  FormDocumentId,  FormFieldTypeId,  FieldParentId,  Title,  HelpText,  FormFieldOrder,  FieldDegree,  HasOther,  DefaultValue,  IsRequired,  RegularExpValidation,  ErrorText,  IsContactEmail,  IsContactMobile,  ColumnCount,  IsSection,  IsPageBreak);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int FormDocumentId,  int FormFieldTypeId,  int FieldParentId,  string Title,  string HelpText,  int FormFieldOrder,  int FieldDegree,  bool HasOther,  string DefaultValue,  bool IsRequired,  string RegularExpValidation,  string ErrorText,  bool IsContactEmail,  bool IsContactMobile,  int ColumnCount,  bool IsSection,  bool IsPageBreak)
		{
			FormFieldDAC formfieldComponent = new FormFieldDAC();
            int FormFieldId = 0;

			return formfieldComponent.InsertNewFormField( ref FormFieldId,  FormDocumentId,  FormFieldTypeId,  FieldParentId,  Title,  HelpText,  FormFieldOrder,  FieldDegree,  HasOther,  DefaultValue,  IsRequired,  RegularExpValidation,  ErrorText,  IsContactEmail,  IsContactMobile,  ColumnCount,  IsSection,  IsPageBreak);
		}
		public bool Update(FormField formfield ,int old_formFieldId)
		{
			FormFieldDAC formfieldComponent = new FormFieldDAC();
			return formfieldComponent.UpdateFormField( formfield.FormDocumentId,  formfield.FormFieldTypeId,  formfield.FieldParentId,  formfield.Title,  formfield.HelpText,  formfield.FormFieldOrder,  formfield.FieldDegree,  formfield.HasOther,  formfield.DefaultValue,  formfield.IsRequired,  formfield.RegularExpValidation,  formfield.ErrorText,  formfield.IsContactEmail,  formfield.IsContactMobile,  formfield.ColumnCount,  formfield.IsSection,  formfield.IsPageBreak,  old_formFieldId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int FormDocumentId,  int FormFieldTypeId,  int FieldParentId,  string Title,  string HelpText,  int FormFieldOrder,  int FieldDegree,  bool HasOther,  string DefaultValue,  bool IsRequired,  string RegularExpValidation,  string ErrorText,  bool IsContactEmail,  bool IsContactMobile,  int ColumnCount,  bool IsSection,  bool IsPageBreak,  int Original_FormFieldId)
		{
			FormFieldDAC formfieldComponent = new FormFieldDAC();
			return formfieldComponent.UpdateFormField( FormDocumentId,  FormFieldTypeId,  FieldParentId,  Title,  HelpText,  FormFieldOrder,  FieldDegree,  HasOther,  DefaultValue,  IsRequired,  RegularExpValidation,  ErrorText,  IsContactEmail,  IsContactMobile,  ColumnCount,  IsSection,  IsPageBreak,  Original_FormFieldId);
		}

        #endregion

        #region DeleteData
        public void Delete(string questionIds, string surveyId)
        {
            DataAccessLayer.DataAccessComponents.DataAccessComponent DAC = new DataAccessLayer.DataAccessComponents.DataAccessComponent("","");
            DAC.EXQuery(String.Format("Delete From FormBuilder.FormField where FormFieldId Not In({0}) AND FormDocumentId = {1}", questionIds, surveyId));
        }
        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_FormFieldId)
		{
			FormFieldDAC formfieldComponent = new FormFieldDAC();
			formfieldComponent.DeleteFormField(Original_FormFieldId);
		}

        #endregion
         public FormField GetByID(int _formFieldId)
         {
             FormFieldDAC _formFieldComponent = new FormFieldDAC();
             IDataReader reader = _formFieldComponent.GetByIDFormField(_formFieldId);
             FormField _formField = null;
             while(reader.Read())
             {
                 _formField = new FormField();
                 if(reader["FormFieldId"] != DBNull.Value)
                     _formField.FormFieldId = Convert.ToInt32(reader["FormFieldId"]);
                 if(reader["FormDocumentId"] != DBNull.Value)
                     _formField.FormDocumentId = Convert.ToInt32(reader["FormDocumentId"]);
                 if(reader["FormFieldTypeId"] != DBNull.Value)
                     _formField.FormFieldTypeId = Convert.ToInt32(reader["FormFieldTypeId"]);
                 if(reader["FieldParentId"] != DBNull.Value)
                     _formField.FieldParentId = Convert.ToInt32(reader["FieldParentId"]);
                 if(reader["Title"] != DBNull.Value)
                     _formField.Title = Convert.ToString(reader["Title"]);
                 if(reader["HelpText"] != DBNull.Value)
                     _formField.HelpText = Convert.ToString(reader["HelpText"]);
                 if(reader["FormFieldOrder"] != DBNull.Value)
                     _formField.FormFieldOrder = Convert.ToInt32(reader["FormFieldOrder"]);
                 if(reader["FieldDegree"] != DBNull.Value)
                     _formField.FieldDegree = Convert.ToInt32(reader["FieldDegree"]);
                 if(reader["HasOther"] != DBNull.Value)
                     _formField.HasOther = Convert.ToBoolean(reader["HasOther"]);
                 if(reader["DefaultValue"] != DBNull.Value)
                     _formField.DefaultValue = Convert.ToString(reader["DefaultValue"]);
                 if(reader["IsRequired"] != DBNull.Value)
                     _formField.IsRequired = Convert.ToBoolean(reader["IsRequired"]);
                 if(reader["RegularExpValidation"] != DBNull.Value)
                     _formField.RegularExpValidation = Convert.ToString(reader["RegularExpValidation"]);
                 if(reader["ErrorText"] != DBNull.Value)
                     _formField.ErrorText = Convert.ToString(reader["ErrorText"]);
                 if(reader["IsContactEmail"] != DBNull.Value)
                     _formField.IsContactEmail = Convert.ToBoolean(reader["IsContactEmail"]);
                 if(reader["IsContactMobile"] != DBNull.Value)
                     _formField.IsContactMobile = Convert.ToBoolean(reader["IsContactMobile"]);
                 if(reader["ColumnCount"] != DBNull.Value)
                     _formField.ColumnCount = Convert.ToInt32(reader["ColumnCount"]);
                 if(reader["IsSection"] != DBNull.Value)
                     _formField.IsSection = Convert.ToBoolean(reader["IsSection"]);
                 if(reader["IsPageBreak"] != DBNull.Value)
                     _formField.IsPageBreak = Convert.ToBoolean(reader["IsPageBreak"]);
             _formField.NewRecord = false;             }             reader.Close();
             return _formField;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			FormFieldDAC formfieldcomponent = new FormFieldDAC();
			return formfieldcomponent.UpdateDataset(dataset);
		}



	}
}
