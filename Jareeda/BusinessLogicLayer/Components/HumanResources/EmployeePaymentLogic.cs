using System;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using DataAccessLayer.DataAccessComponents.HumanResources;
using BusinessLogicLayer.Entities.HumanResources;
namespace BusinessLogicLayer.Components.HumanResources
{
	/// <summary>
	/// This is a Business Logic Component Class  for EmployeePayment table
	/// This class RAPs the EmployeePaymentDAC class and helps the UI to insert,select,update and delete data
	/// </summary>
	[DataObject(true)]
	public partial class EmployeePaymentLogic : BusinessLogic
	{
		public EmployeePaymentLogic(){}

        [DataObjectMethod(DataObjectMethodType.Select)]
         public List<EmployeePayment> GetAll()
         {
             EmployeePaymentDAC _employeePaymentComponent = new EmployeePaymentDAC();
             IDataReader reader =  _employeePaymentComponent.GetAllEmployeePayment().CreateDataReader();
             List<EmployeePayment> _employeePaymentList = new List<EmployeePayment>();
             while(reader.Read())
             {
             if(_employeePaymentList == null)
                 _employeePaymentList = new List<EmployeePayment>();
                 EmployeePayment _employeePayment = new EmployeePayment();
                 if(reader["EmployeePaymentID"] != DBNull.Value)
                     _employeePayment.EmployeePaymentID = Convert.ToInt32(reader["EmployeePaymentID"]);
                 if(reader["EmployeeID"] != DBNull.Value)
                     _employeePayment.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                 if(reader["PaymentTypeID"] != DBNull.Value)
                     _employeePayment.PaymentTypeID = Convert.ToInt32(reader["PaymentTypeID"]);
                 if(reader["PaymentMethodID"] != DBNull.Value)
                     _employeePayment.PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                 if(reader["Amount"] != DBNull.Value)
                     _employeePayment.Amount = Convert.ToDecimal(reader["Amount"]);
                 if(reader["Reason"] != DBNull.Value)
                     _employeePayment.Reason = Convert.ToString(reader["Reason"]);
                 if(reader["Details"] != DBNull.Value)
                     _employeePayment.Details = Convert.ToString(reader["Details"]);
                 if(reader["IsPaid"] != DBNull.Value)
                     _employeePayment.IsPaid = Convert.ToBoolean(reader["IsPaid"]);
                 if(reader["DatePaid"] != DBNull.Value)
                     _employeePayment.DatePaid = Convert.ToDateTime(reader["DatePaid"]);
             _employeePayment.NewRecord = false;
             _employeePaymentList.Add(_employeePayment);
             }             reader.Close();
             return _employeePaymentList;
         }

        #region Insert And Update
		public bool Insert(EmployeePayment employeepayment)
		{
			int autonumber = 0;
			EmployeePaymentDAC employeepaymentComponent = new EmployeePaymentDAC();
			bool endedSuccessfuly = employeepaymentComponent.InsertNewEmployeePayment( ref autonumber,  employeepayment.EmployeeID,  employeepayment.PaymentTypeID,  employeepayment.PaymentMethodID,  employeepayment.Amount,  employeepayment.Reason,  employeepayment.Details,  employeepayment.IsPaid,  employeepayment.DatePaid);
			if(endedSuccessfuly)
			{
				employeepayment.EmployeePaymentID = autonumber;
			}
			return endedSuccessfuly;
		}
		public bool Insert( ref int EmployeePaymentID,  int EmployeeID,  int PaymentTypeID,  int PaymentMethodID,  decimal Amount,  string Reason,  string Details,  bool IsPaid,  DateTime DatePaid)
		{
			EmployeePaymentDAC employeepaymentComponent = new EmployeePaymentDAC();
			return employeepaymentComponent.InsertNewEmployeePayment( ref EmployeePaymentID,  EmployeeID,  PaymentTypeID,  PaymentMethodID,  Amount,  Reason,  Details,  IsPaid,  DatePaid);
		}
         [DataObjectMethod(DataObjectMethodType.Insert)]
		public bool Insert( int EmployeeID,  int PaymentTypeID,  int PaymentMethodID,  decimal Amount,  string Reason,  string Details,  bool IsPaid,  DateTime DatePaid)
		{
			EmployeePaymentDAC employeepaymentComponent = new EmployeePaymentDAC();
            int EmployeePaymentID = 0;

			return employeepaymentComponent.InsertNewEmployeePayment( ref EmployeePaymentID,  EmployeeID,  PaymentTypeID,  PaymentMethodID,  Amount,  Reason,  Details,  IsPaid,  DatePaid);
		}
		public bool Update(EmployeePayment employeepayment ,int old_employeePaymentID)
		{
			EmployeePaymentDAC employeepaymentComponent = new EmployeePaymentDAC();
			return employeepaymentComponent.UpdateEmployeePayment( employeepayment.EmployeeID,  employeepayment.PaymentTypeID,  employeepayment.PaymentMethodID,  employeepayment.Amount,  employeepayment.Reason,  employeepayment.Details,  employeepayment.IsPaid,  employeepayment.DatePaid,  old_employeePaymentID);
		}
		[DataObjectMethod(DataObjectMethodType.Update)]
		public bool Update( int EmployeeID,  int PaymentTypeID,  int PaymentMethodID,  decimal Amount,  string Reason,  string Details,  bool IsPaid,  DateTime DatePaid,  int Original_EmployeePaymentID)
		{
			EmployeePaymentDAC employeepaymentComponent = new EmployeePaymentDAC();
			return employeepaymentComponent.UpdateEmployeePayment( EmployeeID,  PaymentTypeID,  PaymentMethodID,  Amount,  Reason,  Details,  IsPaid,  DatePaid,  Original_EmployeePaymentID);
		}

        #endregion

        #region DeleteData

        [DataObjectMethod(DataObjectMethodType.Delete)]
		public void Delete(int Original_EmployeePaymentID)
		{
			EmployeePaymentDAC employeepaymentComponent = new EmployeePaymentDAC();
			employeepaymentComponent.DeleteEmployeePayment(Original_EmployeePaymentID);
		}

        #endregion
         public EmployeePayment GetByID(int _employeePaymentID)
         {
             EmployeePaymentDAC _employeePaymentComponent = new EmployeePaymentDAC();
             IDataReader reader = _employeePaymentComponent.GetByIDEmployeePayment(_employeePaymentID);
             EmployeePayment _employeePayment = null;
             while(reader.Read())
             {
                 _employeePayment = new EmployeePayment();
                 if(reader["EmployeePaymentID"] != DBNull.Value)
                     _employeePayment.EmployeePaymentID = Convert.ToInt32(reader["EmployeePaymentID"]);
                 if(reader["EmployeeID"] != DBNull.Value)
                     _employeePayment.EmployeeID = Convert.ToInt32(reader["EmployeeID"]);
                 if(reader["PaymentTypeID"] != DBNull.Value)
                     _employeePayment.PaymentTypeID = Convert.ToInt32(reader["PaymentTypeID"]);
                 if(reader["PaymentMethodID"] != DBNull.Value)
                     _employeePayment.PaymentMethodID = Convert.ToInt32(reader["PaymentMethodID"]);
                 if(reader["Amount"] != DBNull.Value)
                     _employeePayment.Amount = Convert.ToDecimal(reader["Amount"]);
                 if(reader["Reason"] != DBNull.Value)
                     _employeePayment.Reason = Convert.ToString(reader["Reason"]);
                 if(reader["Details"] != DBNull.Value)
                     _employeePayment.Details = Convert.ToString(reader["Details"]);
                 if(reader["IsPaid"] != DBNull.Value)
                     _employeePayment.IsPaid = Convert.ToBoolean(reader["IsPaid"]);
                 if(reader["DatePaid"] != DBNull.Value)
                     _employeePayment.DatePaid = Convert.ToDateTime(reader["DatePaid"]);
             _employeePayment.NewRecord = false;             }             reader.Close();
             return _employeePayment;
         }

		public int UpdateDataset(System.Data.DataSet dataset)
		{
			EmployeePaymentDAC employeepaymentcomponent = new EmployeePaymentDAC();
			return employeepaymentcomponent.UpdateDataset(dataset);
		}



	}
}
