﻿using Administrator.Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administrator.HumanResources.Employees
{
    public partial class Manage : AdminBasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Save.aspx?Code=0");
        }
    }
}