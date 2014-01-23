using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.FormBuilder;
using BusinessLogicLayer.Entities.FormBuilder;
namespace BusinessLogicLayer.Components.FormBuilder
{
	/// <summary>
	/// This is a Business Logic Component Class  for FormFieldValue table
	/// This class RAPs the FormFieldValueDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class FormFieldValueLogic : BusinessLogic
	{
		public FormFieldValueLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<FormFieldValue> GetAll()
         {
             FormFieldValueDAC _formFieldValueComponent = new FormFieldValueDAC();
             IDataReader reader =  _formFieldValueComponent.GetAllFormFieldValue().CreateDataReader();
             List<FormFieldValue> _formFieldValueList = new List<FormFieldValue>();
             while(reader.Read())
             {
             if(_formFieldValueList == null)
                 _formFieldValueList = new List<FormFieldValue>();
                 FormFieldValue _formFieldValue = new FormFieldValue();
                 if(reader["FormFieldValueId"] != DBNull.Value)
                     _formFieldValue.FormFieldValueId = Convert.ToInt32(reader["FormFieldValueId"]);
                 if(reader["FormFieldId"] != DBNull.Value)
                     _formFieldValue.FormFieldId = Convert.ToInt32(reader["FormFieldId"]);
                 if(reader["FieldValue"] != DBNull.Value)
                     _formFieldValue.FieldValue = Convert.ToString(reader["FieldValue"]);
                 if(reader["FieldValueHelp"] != DBNull.Value)
                     _formFieldValue.FieldValueHelp = Convert.ToString(reader["FieldValueHelp"]);
                 if(reader["FieldGrade"] != DBNull.Value)
                     _formFieldValue.FieldGrade = Convert.ToInt32(reader["FieldGrade"]);
                 if(reader["IsOther"] != DBNull.Value)
                     _formFieldValue.IsOther = Convert.ToBoolean(reader["IsOther"]);
                 if(reader["ScaleStart"] != DBNull.Value)
                     _formFieldValue.ScaleStart = Convert.ToDecimal(reader["ScaleStart"]);
                 if(reader["ScaleEnd"] != DBNull.Value)
                     _formFieldValue.ScaleEnd = Convert.ToDecimal(reader["ScaleEnd"]);
             _formFieldValue.NewRecord = false;
             _formFieldValueList.Add(_formFieldValue);
             }             reader.Close();
             return _formFieldValueList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<FormFieldValue> GetAllByFormFieldId(int FormFieldId)
        {
            FormFieldValueDAC _formFieldValueComponent = new FormFieldValueDAC();
            IDataReader reader = _formFieldValueComponent.GetAllFormFieldValue("FormFieldId = " + FormFieldId).CreateDataReader();
            List<FormFieldValue> _formFieldValueList = new List<FormFieldValue>();
            while (reader.Read())
            {
                if (_formFieldValueList == null)
                    _formFieldValueList = new List<FormFieldValue>();
                FormFieldValue _formFieldValue = new FormFieldValue();
                if (reader["FormFieldValueId"] != DBNull.Value)
                    _formFieldValue.FormFieldValueId = Convert.ToInt32(reader["FormFieldValueId"]);
                if (reader["FormFieldId"] != DBNull.Value)
                    _formFieldValue.FormFieldId = Convert.ToInt32(reader["FormFieldId"]);
                if (reader["FieldValue"] != DBNull.Value)
                    _formFieldValue.FieldValue = Convert.ToString(reader["FieldValue"]);
                if (reader["FieldValueHelp"] != DBNull.Value)
                    _formFieldValue.FieldValueHelp = Convert.ToString(reader["FieldValueHelp"]);
                if (reader["FieldGrade"] != DBNull.Value)
                    _formFieldValue.FieldGrade = Convert.ToInt32(reader["FieldGrade"]);
                if (reader["IsOther"] != DBNull.Value)
                    _formFieldValue.IsOther = Convert.ToBoolean(reader["IsOther"]);
                if (reader["ScaleStart"] != DBNull.Value)
                    _formFieldValue.ScaleStart = Convert.ToDecimal(reader["ScaleStart"]);
                if (reader["ScaleEnd"] != DBNull.Value)
                    _formFieldValue.ScaleEnd = Convert.ToDecimal(reader["ScaleEnd"]);
                _formFieldValue.NewRecord = false;
                _formFieldValueList.Add(_formFieldValue);
            } reader.Close();
            return _formFieldValueList;
        }

        public int GetTotalSubmissions(int ID)
        {
            FormFieldValueDAC _formFieldValueComponent = new FormFieldValueDAC();
            return _formFieldValueComponent.GetFieldValueTotalSubmissions(ID);
        }

        #region Insert And Update
		public bool Insert(FormFieldValue formfieldvalue)
		{
			int autonumber = 0;
			FormFieldValueDAC formfieldvalueComponent = new FormFieldValueDAC();
			bool endedSuccessfuly = formfieldvalueComponent.InsertNewFormFieldValue( ref autonumber,  formfieldvalue.FormFieldId,  formfieldvalue.FieldValue,  formfieldvalue.FieldValueHelp,  formfieldvalue.FieldGrade,  formfieldvalue.IsOther,  formfieldvalue.ScaleStart,  formfieldvalue.ScaleEnd);
			if(endedSuccessfuly)
			{
				formfieldvalue.FormFieldValueId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int FormFieldValueId,  int FormFieldId,  string FieldValue,  string FieldValueHelp,  int FieldGrade,  bool IsOther,  decimal ScaleStart,  decimal ScaleEnd)
		{
			FormFieldValueDAC formfieldvalueComponent = new FormFieldValueDAC();
			return formfieldvalueComponent.InsertNewFormFieldValue( ref FormFieldValueId,  FormFieldId,  FieldValue,  FieldValueHelp,  FieldGrade,  IsOther,  ScaleStart,  ScaleEnd);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int FormFieldId,  string FieldValue,  string FieldValueHelp,  int FieldGrade,  bool IsOther,  decimal ScaleStart,  decimal ScaleEnd)
		{
			FormFieldValueDAC formfieldvalueComponent = new FormFieldValueDAC();
            int FormFieldValueId = 0;

			return formfieldvalueComponent.InsertNewFormFieldValue( ref FormFieldValueId,  FormFieldId,  FieldValue,  FieldValueHelp,  FieldGrade,  IsOther,  ScaleStart,  ScaleEnd);
		}
		public bool Update(FormFieldValue formfieldvalue ,int old_formFieldValueId)
		{
			FormFieldValueDAC formfieldvalueComponent = new FormFieldValueDAC();
			return formfieldvalueComponent.UpdateFormFieldValue( formfieldvalue.FormFieldId,  formfieldvalue.FieldValue,  formfieldvalue.FieldValueHelp,  formfieldvalue.FieldGrade,  formfieldvalue.IsOther,  formfieldvalue.ScaleStart,  formfieldvalue.ScaleEnd,  old_formFieldValueId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int FormFieldId,  string FieldValue,  string FieldValueHelp,  int FieldGrade,  bool IsOther,  decimal ScaleStart,  decimal ScaleEnd,  int Original_FormFieldValueId)
		{
			FormFieldValueDAC formfieldvalueComponent = new FormFieldValueDAC();
			return formfieldvalueComponent.UpdateFormFieldValue( FormFieldId,  FieldValue,  FieldValueHelp,  FieldGrade,  IsOther,  ScaleStart,  ScaleEnd,  Original_FormFieldValueId);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_FormFieldValueId)
		{
			FormFieldValueDAC formfieldvalueComponent = new FormFieldValueDAC();
			formfieldvalueComponent.DeleteFormFieldValue(Original_FormFieldValueId);
		}

        public void Delete(string ids, string questionId)
        {
            DataAccessLayer.DataAccessComponents.DataAccessComponent c = new DataAccessLayer.DataAccessComponents.DataAccessComponent("","");
            c.EXQuery(String.Format("Delete From FormBuilder.FormFieldValue Where FormFieldValueId Not In({0}) and FormFieldId = {1}", ids, questionId));
        }

        #endregion
         public FormFieldValue GetByID(int _formFieldValueId)
         {
             FormFieldValueDAC _formFieldValueComponent = new FormFieldValueDAC();
             IDataReader reader = _formFieldValueComponent.GetByIDFormFieldValue(_formFieldValueId);
             FormFieldValue _formFieldValue = null;
             while(reader.Read())
             {
                 _formFieldValue = new FormFieldValue();
                 if(reader["FormFieldValueId"] != DBNull.Value)
                     _formFieldValue.FormFieldValueId = Convert.ToInt32(reader["FormFieldValueId"]);
                 if(reader["FormFieldId"] != DBNull.Value)
                     _formFieldValue.FormFieldId = Convert.ToInt32(reader["FormFieldId"]);
                 if(reader["FieldValue"] != DBNull.Value)
                     _formFieldValue.FieldValue = Convert.ToString(reader["FieldValue"]);
                 if(reader["FieldValueHelp"] != DBNull.Value)
                     _formFieldValue.FieldValueHelp = Convert.ToString(reader["FieldValueHelp"]);
                 if(reader["FieldGrade"] != DBNull.Value)
                     _formFieldValue.FieldGrade = Convert.ToInt32(reader["FieldGrade"]);
                 if(reader["IsOther"] != DBNull.Value)
                     _formFieldValue.IsOther = Convert.ToBoolean(reader["IsOther"]);
                 if(reader["ScaleStart"] != DBNull.Value)
                     _formFieldValue.ScaleStart = Convert.ToDecimal(reader["ScaleStart"]);
                 if(reader["ScaleEnd"] != DBNull.Value)
                     _formFieldValue.ScaleEnd = Convert.ToDecimal(reader["ScaleEnd"]);
             _formFieldValue.NewRecord = false;             }             reader.Close();
             return _formFieldValue;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			FormFieldValueDAC formfieldvaluecomponent = new FormFieldValueDAC();
			return formfieldvaluecomponent.UpdateDataset(dataset);
		}



	}
}
