using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.FormBuilder;
using BusinessLogicLayer.Entities.FormBuilder;
namespace BusinessLogicLayer.Components.FormBuilder
{
	/// <summary>
	/// This is a Business Logic Component Class  for FormFieldColumn table
	/// This class RAPs the FormFieldColumnDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class FormFieldColumnLogic : BusinessLogic
	{
		public FormFieldColumnLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<FormFieldColumn> GetAll()
         {
             FormFieldColumnDAC _formFieldColumnComponent = new FormFieldColumnDAC();
             IDataReader reader =  _formFieldColumnComponent.GetAllFormFieldColumn().CreateDataReader();
             List<FormFieldColumn> _formFieldColumnList = new List<FormFieldColumn>();
             while(reader.Read())
             {
             if(_formFieldColumnList == null)
                 _formFieldColumnList = new List<FormFieldColumn>();
                 FormFieldColumn _formFieldColumn = new FormFieldColumn();
                 if(reader["FormFieldColumnId"] != DBNull.Value)
                     _formFieldColumn.FormFieldColumnId = Convert.ToInt32(reader["FormFieldColumnId"]);
                 if(reader["FormFieldId"] != DBNull.Value)
                     _formFieldColumn.FormFieldId = Convert.ToInt32(reader["FormFieldId"]);
                 if(reader["FieldColumnValue"] != DBNull.Value)
                     _formFieldColumn.FieldColumnValue = Convert.ToString(reader["FieldColumnValue"]);
                 if(reader["FieldColumnHelp"] != DBNull.Value)
                     _formFieldColumn.FieldColumnHelp = Convert.ToString(reader["FieldColumnHelp"]);
                 if(reader["FieldColumnGrade"] != DBNull.Value)
                     _formFieldColumn.FieldColumnGrade = Convert.ToInt32(reader["FieldColumnGrade"]);
             _formFieldColumn.NewRecord = false;
             _formFieldColumnList.Add(_formFieldColumn);
             }             reader.Close();
             return _formFieldColumnList;
         }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public List<FormFieldColumn> GetAllByFormFieldId(int FormFieldId)
        {
            FormFieldColumnDAC _formFieldColumnComponent = new FormFieldColumnDAC();
            IDataReader reader = _formFieldColumnComponent.GetAllFormFieldColumn("FormFieldId = " + FormFieldId).CreateDataReader();
            List<FormFieldColumn> _formFieldColumnList = new List<FormFieldColumn>();
            while (reader.Read())
            {
                if (_formFieldColumnList == null)
                    _formFieldColumnList = new List<FormFieldColumn>();
                FormFieldColumn _formFieldColumn = new FormFieldColumn();
                if (reader["FormFieldColumnId"] != DBNull.Value)
                    _formFieldColumn.FormFieldColumnId = Convert.ToInt32(reader["FormFieldColumnId"]);
                if (reader["FormFieldId"] != DBNull.Value)
                    _formFieldColumn.FormFieldId = Convert.ToInt32(reader["FormFieldId"]);
                if (reader["FieldColumnValue"] != DBNull.Value)
                    _formFieldColumn.FieldColumnValue = Convert.ToString(reader["FieldColumnValue"]);
                if (reader["FieldColumnHelp"] != DBNull.Value)
                    _formFieldColumn.FieldColumnHelp = Convert.ToString(reader["FieldColumnHelp"]);
                if (reader["FieldColumnGrade"] != DBNull.Value)
                    _formFieldColumn.FieldColumnGrade = Convert.ToInt32(reader["FieldColumnGrade"]);
                _formFieldColumn.NewRecord = false;
                _formFieldColumnList.Add(_formFieldColumn);
            } reader.Close();
            return _formFieldColumnList;
        }


                #region Insert And Update
		public bool Insert(FormFieldColumn formfieldcolumn)
		{
			int autonumber = 0;
			FormFieldColumnDAC formfieldcolumnComponent = new FormFieldColumnDAC();
			bool endedSuccessfuly = formfieldcolumnComponent.InsertNewFormFieldColumn( ref autonumber,  formfieldcolumn.FormFieldId,  formfieldcolumn.FieldColumnValue,  formfieldcolumn.FieldColumnHelp,  formfieldcolumn.FieldColumnGrade);
			if(endedSuccessfuly)
			{
				formfieldcolumn.FormFieldColumnId = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int FormFieldColumnId,  int FormFieldId,  string FieldColumnValue,  string FieldColumnHelp,  int FieldColumnGrade)
		{
			FormFieldColumnDAC formfieldcolumnComponent = new FormFieldColumnDAC();
			return formfieldcolumnComponent.InsertNewFormFieldColumn( ref FormFieldColumnId,  FormFieldId,  FieldColumnValue,  FieldColumnHelp,  FieldColumnGrade);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int FormFieldId,  string FieldColumnValue,  string FieldColumnHelp,  int FieldColumnGrade)
		{
			FormFieldColumnDAC formfieldcolumnComponent = new FormFieldColumnDAC();
            int FormFieldColumnId = 0;

			return formfieldcolumnComponent.InsertNewFormFieldColumn( ref FormFieldColumnId,  FormFieldId,  FieldColumnValue,  FieldColumnHelp,  FieldColumnGrade);
		}
		public bool Update(FormFieldColumn formfieldcolumn ,int old_formFieldColumnId)
		{
			FormFieldColumnDAC formfieldcolumnComponent = new FormFieldColumnDAC();
			return formfieldcolumnComponent.UpdateFormFieldColumn( formfieldcolumn.FormFieldId,  formfieldcolumn.FieldColumnValue,  formfieldcolumn.FieldColumnHelp,  formfieldcolumn.FieldColumnGrade,  old_formFieldColumnId);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int FormFieldId,  string FieldColumnValue,  string FieldColumnHelp,  int FieldColumnGrade,  int Original_FormFieldColumnId)
		{
			FormFieldColumnDAC formfieldcolumnComponent = new FormFieldColumnDAC();
			return formfieldcolumnComponent.UpdateFormFieldColumn( FormFieldId,  FieldColumnValue,  FieldColumnHelp,  FieldColumnGrade,  Original_FormFieldColumnId);
		}

        #endregion

        #region DeleteData
        public void DeleteByFormFieldId(int FormFieldId)
        {
            DataAccessLayer.DataAccessComponents.DataAccessComponent DAC = new DataAccessLayer.DataAccessComponents.DataAccessComponent("","");
            DAC.EXQuery("Delete From FormBuilder.FormFieldColumn where FormFieldId = " + FormFieldId);
        }

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_FormFieldColumnId)
		{
			FormFieldColumnDAC formfieldcolumnComponent = new FormFieldColumnDAC();
			formfieldcolumnComponent.DeleteFormFieldColumn(Original_FormFieldColumnId);
		}

        #endregion
         public FormFieldColumn GetByID(int _formFieldColumnId)
         {
             FormFieldColumnDAC _formFieldColumnComponent = new FormFieldColumnDAC();
             IDataReader reader = _formFieldColumnComponent.GetByIDFormFieldColumn(_formFieldColumnId);
             FormFieldColumn _formFieldColumn = null;
             while(reader.Read())
             {
                 _formFieldColumn = new FormFieldColumn();
                 if(reader["FormFieldColumnId"] != DBNull.Value)
                     _formFieldColumn.FormFieldColumnId = Convert.ToInt32(reader["FormFieldColumnId"]);
                 if(reader["FormFieldId"] != DBNull.Value)
                     _formFieldColumn.FormFieldId = Convert.ToInt32(reader["FormFieldId"]);
                 if(reader["FieldColumnValue"] != DBNull.Value)
                     _formFieldColumn.FieldColumnValue = Convert.ToString(reader["FieldColumnValue"]);
                 if(reader["FieldColumnHelp"] != DBNull.Value)
                     _formFieldColumn.FieldColumnHelp = Convert.ToString(reader["FieldColumnHelp"]);
                 if(reader["FieldColumnGrade"] != DBNull.Value)
                     _formFieldColumn.FieldColumnGrade = Convert.ToInt32(reader["FieldColumnGrade"]);
             _formFieldColumn.NewRecord = false;             }             reader.Close();
             return _formFieldColumn;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			FormFieldColumnDAC formfieldcolumncomponent = new FormFieldColumnDAC();
			return formfieldcolumncomponent.UpdateDataset(dataset);
		}



	}
}
