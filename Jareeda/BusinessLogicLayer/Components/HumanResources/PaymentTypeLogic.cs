using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for PaymentType table
	/// This class RAPs the PaymentTypeDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PaymentTypeLogic : BusinessLogic
	{
		public PaymentTypeLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PaymentType> GetAll()
         {
             PaymentTypeDAC _paymentTypeComponent = new PaymentTypeDAC();
             IDataReader reader =  _paymentTypeComponent.GetAllPaymentType().CreateDataReader();
             List<PaymentType> _paymentTypeList = new List<PaymentType>();
             while(reader.Read())
             {
             if(_paymentTypeList == null)
                 _paymentTypeList = new List<PaymentType>();
                 PaymentType _paymentType = new PaymentType();
                 if(reader["PaymentTypeID"] != DBNull.Value)
                     _paymentType.PaymentTypeID = Convert.ToInt32(reader["PaymentTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _paymentType.Name = Convert.ToString(reader["Name"]);
                 if(reader["IsRecurring"] != DBNull.Value)
                     _paymentType.IsRecurring = Convert.ToBoolean(reader["IsRecurring"]);
                 if(reader["RecurringNumberinDays"] != DBNull.Value)
                     _paymentType.RecurringNumberinDays = Convert.ToInt32(reader["RecurringNumberinDays"]);
                 if(reader["IsPerItem"] != DBNull.Value)
                     _paymentType.IsPerItem = Convert.ToBoolean(reader["IsPerItem"]);
                 if(reader["ItemNumber"] != DBNull.Value)
                     _paymentType.ItemNumber = Convert.ToInt32(reader["ItemNumber"]);
             _paymentType.NewRecord = false;
             _paymentTypeList.Add(_paymentType);
             }             reader.Close();
             return _paymentTypeList;
         }

        #region Insert And Update
		public bool Insert(PaymentType paymenttype)
		{
			int autonumber = 0;
			PaymentTypeDAC paymenttypeComponent = new PaymentTypeDAC();
			bool endedSuccessfuly = paymenttypeComponent.InsertNewPaymentType( ref autonumber,  paymenttype.Name,  paymenttype.IsRecurring,  paymenttype.RecurringNumberinDays,  paymenttype.IsPerItem,  paymenttype.ItemNumber);
			if(endedSuccessfuly)
			{
				paymenttype.PaymentTypeID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PaymentTypeID,  string Name,  bool IsRecurring,  int RecurringNumberinDays,  bool IsPerItem,  int ItemNumber)
		{
			PaymentTypeDAC paymenttypeComponent = new PaymentTypeDAC();
			return paymenttypeComponent.InsertNewPaymentType( ref PaymentTypeID,  Name,  IsRecurring,  RecurringNumberinDays,  IsPerItem,  ItemNumber);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name,  bool IsRecurring,  int RecurringNumberinDays,  bool IsPerItem,  int ItemNumber)
		{
			PaymentTypeDAC paymenttypeComponent = new PaymentTypeDAC();
            int PaymentTypeID = 0;

			return paymenttypeComponent.InsertNewPaymentType( ref PaymentTypeID,  Name,  IsRecurring,  RecurringNumberinDays,  IsPerItem,  ItemNumber);
		}
		public bool Update(PaymentType paymenttype ,int old_paymentTypeID)
		{
			PaymentTypeDAC paymenttypeComponent = new PaymentTypeDAC();
			return paymenttypeComponent.UpdatePaymentType( paymenttype.Name,  paymenttype.IsRecurring,  paymenttype.RecurringNumberinDays,  paymenttype.IsPerItem,  paymenttype.ItemNumber,  old_paymentTypeID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  bool IsRecurring,  int RecurringNumberinDays,  bool IsPerItem,  int ItemNumber,  int Original_PaymentTypeID)
		{
			PaymentTypeDAC paymenttypeComponent = new PaymentTypeDAC();
			return paymenttypeComponent.UpdatePaymentType( Name,  IsRecurring,  RecurringNumberinDays,  IsPerItem,  ItemNumber,  Original_PaymentTypeID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PaymentTypeID)
		{
			PaymentTypeDAC paymenttypeComponent = new PaymentTypeDAC();
			paymenttypeComponent.DeletePaymentType(Original_PaymentTypeID);
		}

        #endregion
         public PaymentType GetByID(int _paymentTypeID)
         {
             PaymentTypeDAC _paymentTypeComponent = new PaymentTypeDAC();
             IDataReader reader = _paymentTypeComponent.GetByIDPaymentType(_paymentTypeID);
             PaymentType _paymentType = null;
             while(reader.Read())
             {
                 _paymentType = new PaymentType();
                 if(reader["PaymentTypeID"] != DBNull.Value)
                     _paymentType.PaymentTypeID = Convert.ToInt32(reader["PaymentTypeID"]);
                 if(reader["Name"] != DBNull.Value)
                     _paymentType.Name = Convert.ToString(reader["Name"]);
                 if(reader["IsRecurring"] != DBNull.Value)
                     _paymentType.IsRecurring = Convert.ToBoolean(reader["IsRecurring"]);
                 if(reader["RecurringNumberinDays"] != DBNull.Value)
                     _paymentType.RecurringNumberinDays = Convert.ToInt32(reader["RecurringNumberinDays"]);
                 if(reader["IsPerItem"] != DBNull.Value)
                     _paymentType.IsPerItem = Convert.ToBoolean(reader["IsPerItem"]);
                 if(reader["ItemNumber"] != DBNull.Value)
                     _paymentType.ItemNumber = Convert.ToInt32(reader["ItemNumber"]);
             _paymentType.NewRecord = false;             }             reader.Close();
             return _paymentType;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PaymentTypeDAC paymenttypecomponent = new PaymentTypeDAC();
			return paymenttypecomponent.UpdateDataset(dataset);
		}



	}
}
