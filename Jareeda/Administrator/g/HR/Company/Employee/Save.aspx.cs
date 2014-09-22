using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Administrator.Code;
using CommonWeb.Common;

namespace Administrator.g.HR.Company.Employee
{
    public partial class Save : Code.AdminBase
    {
        #region Declarations and Properties
        public BusinessLogicLayer.Entities.HumanResources.Employees CurrentEmployee
        {
            get
            {
                if (Session["AMCurrentEmployee"] == null)
                {
                    Session["AMCurrentEmployee"] = new BusinessLogicLayer.Entities.HumanResources.Employees();
                }
                return Session["AMCurrentEmployee"] as BusinessLogicLayer.Entities.HumanResources.Employees;
            }
            set
            {
                Session["AMCurrentEmployee"] = value;
            }
        }
        public BusinessLogicLayer.Entities.Persons.Person CurrentPerson
        {
            get
            {
                if (Session["AMCurrentEmployeePerson"] == null)
                {
                    Session["AMCurrentEmployeePerson"] = new BusinessLogicLayer.Entities.Persons.Person();
                }
                return Session["AMCurrentEmployeePerson"] as BusinessLogicLayer.Entities.Persons.Person;
            }
            set
            {
                Session["AMCurrentEmployeePerson"] = value;
            }
        }

        #endregion

        #region Methods
        private void SetData()
        {
            CurrentPerson = CurrentEmployee.EmployeePerson;
            CurrentEmployee.DepartmentId = Convert.ToInt32(employeeDepartment.Value);
            if (!string.IsNullOrEmpty(employeeBirthDate.Text))
            {
                CurrentEmployee.BirthDate = employeeBirthDate.Date;
                CurrentPerson.DateofBirth = employeeBirthDate.Date;
            }
            if (!string.IsNullOrEmpty(employeeHireDate.Text))
                CurrentEmployee.HireDate = employeeHireDate.Date;
            CurrentEmployee.EmployeeNumber = employeeNumber.Text;
            CurrentEmployee.Position = employeePosition.Text;
            CurrentEmployee.ModifiedDate = DateTime.Now;
            if (CurrentEmployee.NewRecord)
                CurrentEmployee.RowGuid = Guid.NewGuid();
            string title = "", firstName = "", middleName = "", lastName = "", displayName = "";
            displayName = miPersonName.Text;
            string[] nameSplit = miPersonName.Text.Trim().Split(' ');
            int nameCount = 0;
            int lastIndex = nameSplit.Length - 1;
            if (IsTitle(nameSplit[nameCount]))
            {
                title = nameSplit[nameCount];
                lastIndex--;
                nameCount++;
            }
            if (nameCount <= lastIndex)
            {
                firstName = nameSplit[nameCount];
                if (nameCount != lastIndex)
                    lastName = nameSplit[lastIndex];
                nameCount++;
            }
            middleName = "";
            for (int i = nameCount; i < lastIndex; i++)
            {
                middleName += nameSplit[i] + " ";
            }
            middleName = middleName.Trim();

            CurrentPerson.ModifiedDate = DateTime.Now;

            CurrentPerson.PersonImage = miPersonImage.ImagePath;

            CurrentPerson.Title = title;
            CurrentPerson.FirstName = firstName;
            CurrentPerson.DisplayName = displayName;
            CurrentPerson.LastName = lastName;
            CurrentPerson.MiddleName = middleName;

            CurrentPerson.Email = employeeEmail.Text;

            if (!string.IsNullOrEmpty(employeePassword.Text) && employeePassword.Text.Length > 5)
            {
                CurrentPerson.Credentials.PasswordSalt = Guid.NewGuid().ToString().Substring(0, 5);
                CurrentPerson.Credentials.PasswordHash = Tools.MD5(employeePassword.Text + CurrentPerson.Credentials.PasswordSalt);
                CurrentPerson.Credentials.IsActive = true;
                CurrentPerson.Credentials.IsActivated = true;
                if (CurrentPerson.Credentials.NewRecord)
                {
                    CurrentPerson.Credentials.RowGuid = Guid.NewGuid();
                }
                CurrentPerson.Credentials.ModifiedDate = DateTime.Now;

                CurrentPerson.Credentials.Username = employeeCredential.Text;
            }

        }

        private void LoadData()
        {

            employeeOrganization.DataBind();
            employeeOrganization.SelectedIndex = employeeOrganization.Items.FindByValue(CurrentEmployee.Department.OrganizationId).Index;
            SectionObjectDS.SelectParameters[0].DefaultValue = CurrentEmployee.Department.OrganizationId.ToString();
            employeeDepartment.DataBind();
            employeeDepartment.SelectedIndex = employeeDepartment.Items.FindByValue(CurrentEmployee.DepartmentId).Index;
            if (CurrentEmployee.BirthDate != DateTime.MinValue)
                employeeBirthDate.Date = CurrentEmployee.BirthDate;
            if (CurrentEmployee.HireDate != DateTime.MinValue)
                employeeHireDate.Date = CurrentEmployee.HireDate;

            employeeNumber.Text = CurrentEmployee.EmployeeNumber;
            employeePosition.Text = CurrentEmployee.Position;
            miPersonName.Text = CurrentEmployee.DisplayName;


            CurrentPerson.ModifiedDate = DateTime.Now;
            if (!string.IsNullOrEmpty(CurrentPerson.PersonImage))
                miPersonImage.ImagePath = CurrentPerson.PersonImage;

            if (!CurrentPerson.Credentials.NewRecord)
            {
                employeeCredential.Text = CurrentPerson.Credentials.Username;
            }

            employeeEmail.Text = CurrentPerson.Email;



        }

        private bool IsTitle(string x)
        {
            bool result = false;
            if (x == "أستاذ" || x == "أستاذة" || x == "أستاذه" || x == "استاذ" || x == "استاذه" || x == "استاذة" || x == "دكتور" || x == "دكتورة" || x == "دكتوره" || x == "د." || x == "مهندس" || x == "مهندسة" || x == "مهندسه" || x == "Mr." || x == "Mrs." || x == "Ms." || x == "Dr." || x == "Eng" || x == "dr" || x == "Dr" || x == "Eng." || x == "eng." || x == "eng")
                result = true;
            return result;
        }



        private bool SaveData()
        {
            bool result = true;
            SetData();
            if (CurrentPerson.NewRecord)
            {
                BusinessLogicLayer.Common.PersonLogic.Insert(CurrentPerson);
                CurrentEmployee.EmployeeId = CurrentPerson.BusinessEntityId;
                BusinessLogicLayer.Common.EmployeesLogic.Insert(CurrentEmployee);
                if (!string.IsNullOrEmpty(CurrentPerson.Credentials.Username))
                {
                    CurrentPerson.Credentials.BusinessEntityId = CurrentPerson.BusinessEntityId;
                    BusinessLogicLayer.Common.CredentialLogic.Insert(CurrentPerson.Credentials);
                }

                if (!string.IsNullOrEmpty(CurrentPerson.Email))
                {
                    BusinessLogicLayer.Common.EmailAddressLogic.Insert(CurrentPerson.BusinessEntityId, 1, CurrentPerson.Email, true, "", Guid.NewGuid(), DateTime.Now);
                }
            }
            else
            {
                BusinessLogicLayer.Common.PersonLogic.Update(CurrentPerson, CurrentPerson.BusinessEntityId);
                foreach (BusinessLogicLayer.Entities.Persons.PersonLanguages lang in CurrentPerson.PersonLanguages)
                {
                    lang.PersonId = CurrentPerson.BusinessEntityId;
                    if (lang.NewRecord)
                        BusinessLogicLayer.Common.PersonLanguagesLogic.Insert(lang);
                    else
                        BusinessLogicLayer.Common.PersonLanguagesLogic.Update(lang, lang.PersonLanguageId);
                }
                if (CurrentEmployee.NewRecord)
                {
                    CurrentEmployee.EmployeeId = CurrentPerson.BusinessEntityId;
                    BusinessLogicLayer.Common.EmployeesLogic.Insert(CurrentEmployee);

                }
                else
                {
                    BusinessLogicLayer.Common.EmployeesLogic.Update(CurrentEmployee, CurrentEmployee.EmployeeId);
                }
                if (CurrentPerson.Credentials.NewRecord)
                {
                    if (!string.IsNullOrEmpty(CurrentPerson.Credentials.Username))
                    {
                        CurrentPerson.Credentials.BusinessEntityId = CurrentPerson.BusinessEntityId;
                        BusinessLogicLayer.Common.CredentialLogic.Insert(CurrentPerson.Credentials);
                    }
                }
                else
                {
                    BusinessLogicLayer.Common.CredentialLogic.Update(CurrentPerson.Credentials, CurrentPerson.Credentials.BusinessEntityId);
                }

                if (CurrentPerson.EmailAddressPrimaryObject.NewRecord)
                {
                    BusinessLogicLayer.Common.EmailAddressLogic.Insert(CurrentPerson.BusinessEntityId, 1, CurrentPerson.Email, true, "", Guid.NewGuid(), DateTime.Now);
                }
                else
                {
                    BusinessLogicLayer.Common.EmailAddressLogic.Update(CurrentPerson.EmailAddressPrimaryObject, CurrentPerson.EmailAddressPrimaryObject.EmailAddressId);
                }
            }
            return result;
        }
        #endregion

        #region Events Handlers

        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            if (!IsPostBack)
            {
                CurrentPerson = null;
                CurrentEmployee = null;
                int x = 0;
                Int32.TryParse(Request["Code"], out x);
                if (x != 0)
                {
                    BusinessLogicLayer.Entities.HumanResources.Employees emp = new BusinessLogicLayer.Components.HumanResources.EmployeesLogic().GetByID(x);
                    if (emp != null)
                    {
                        CurrentEmployee = emp;
                        CurrentPerson = emp.EmployeePerson;
                        LoadData();
                    }
                }
            }
        }

        protected void SaveandNew_Click(object sender, EventArgs e)
        {
            try
            {
                SaveData();
                Session["Notification"] = "success";
                Response.Redirect("Save.aspx?Code=0");
                
            }
            catch (Exception ex)
            {
                SetNotification("fail", ex.Message, "", this);
            }
        }

        protected void btnSaveandClose_Click(object sender, EventArgs e)
        {
            try
            {
                SaveData();
                Session["Notification"] = "success";
                Response.Redirect("~/g/HR/Company/Employee");

            }
            catch (Exception ex)
            {
                SetNotification("fail", ex.Message, "", this);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveData();
                Session["Notification"] = "success";
                Response.Redirect("Save.aspx?Code=" + CurrentEmployee.EmployeeId);
            }
            catch (Exception ex)
            {
                SetNotification("fail", ex.Message, "", this);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/g/HR/Company/Employee");
        }

        protected void employeeDepartment_Callback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            SectionObjectDS.SelectParameters[0].DefaultValue = e.Parameter;
            employeeDepartment.DataBind();
        }
        #endregion
    }
}