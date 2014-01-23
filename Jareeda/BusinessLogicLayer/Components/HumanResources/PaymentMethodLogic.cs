using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for PaymentMethod table
	/// This class RAPs the PaymentMethodDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class PaymentMethodLogic : BusinessLogic
	{
		public PaymentMethodLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<PaymentMethod> GetAll()
         {
             PaymentMethodDAC _paymentMethodComponent = new PaymentMethodDAC();
             IDataReader reader =  _paymentMethodComponent.GetAllPaymentMethod().CreateDataReader();
             List<PaymentMethod> _paymentMethodList = new List<PaymentMethod>();
             while(reader.Read())
             {
             if(_paymentMethodList == null)
                 _paymentMethodList = new List<PaymentMethod>();
                 PaymentMethod _paymentMethod = new PaymentMethod();
                 if(reader["PaymentMethodID"] != DBNull.Value)
                     _paymentMethod.PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                 if(reader["Name"] != DBNull.Value)
                     _paymentMethod.Name = Convert.ToString(reader["Name"]);
             _paymentMethod.NewRecord = false;
             _paymentMethodList.Add(_paymentMethod);
             }             reader.Close();
             return _paymentMethodList;
         }

        #region Insert And Update
		public bool Insert(PaymentMethod paymentmethod)
		{
			int autonumber = 0;
			PaymentMethodDAC paymentmethodComponent = new PaymentMethodDAC();
			bool endedSuccessfuly = paymentmethodComponent.InsertNewPaymentMethod( ref autonumber,  paymentmethod.Name);
			if(endedSuccessfuly)
			{
				paymentmethod.PaymentMethodID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int PaymentMethodID,  string Name)
		{
			PaymentMethodDAC paymentmethodComponent = new PaymentMethodDAC();
			return paymentmethodComponent.InsertNewPaymentMethod( ref PaymentMethodID,  Name);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( string Name)
		{
			PaymentMethodDAC paymentmethodComponent = new PaymentMethodDAC();
            int PaymentMethodID = 0;

			return paymentmethodComponent.InsertNewPaymentMethod( ref PaymentMethodID,  Name);
		}
		public bool Update(PaymentMethod paymentmethod ,int old_paymentMethodID)
		{
			PaymentMethodDAC paymentmethodComponent = new PaymentMethodDAC();
			return paymentmethodComponent.UpdatePaymentMethod( paymentmethod.Name,  old_paymentMethodID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( string Name,  int Original_PaymentMethodID)
		{
			PaymentMethodDAC paymentmethodComponent = new PaymentMethodDAC();
			return paymentmethodComponent.UpdatePaymentMethod( Name,  Original_PaymentMethodID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_PaymentMethodID)
		{
			PaymentMethodDAC paymentmethodComponent = new PaymentMethodDAC();
			paymentmethodComponent.DeletePaymentMethod(Original_PaymentMethodID);
		}

        #endregion
         public PaymentMethod GetByID(int _paymentMethodID)
         {
             PaymentMethodDAC _paymentMethodComponent = new PaymentMethodDAC();
             IDataReader reader = _paymentMethodComponent.GetByIDPaymentMethod(_paymentMethodID);
             PaymentMethod _paymentMethod = null;
             while(reader.Read())
             {
                 _paymentMethod = new PaymentMethod();
                 if(reader["PaymentMethodID"] != DBNull.Value)
                     _paymentMethod.PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                 if(reader["Name"] != DBNull.Value)
                     _paymentMethod.Name = Convert.ToString(reader["Name"]);
             _paymentMethod.NewRecord = false;             }             reader.Close();
             return _paymentMethod;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			PaymentMethodDAC paymentmethodcomponent = new PaymentMethodDAC();
			return paymentmethodcomponent.UpdateDataset(dataset);
		}



	}
}
