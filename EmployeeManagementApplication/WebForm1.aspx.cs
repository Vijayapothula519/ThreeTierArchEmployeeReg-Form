using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayerApplication;
using DataLayerApplication;

namespace EmployeeManagementApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        
            EmployeeClass employee = new EmployeeClass();
            EmpLogicClass blLogic = new EmpLogicClass();
            public void loaddata()
            {
                EmployeeGrid.DataSource = blLogic.getEmployeeData();
                EmployeeGrid.DataBind();
                BtnUpdate.Enabled = false;
            }
            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)  
                {
                    loaddata();
                }

            }
        protected void EmployeeGrid_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = EmployeeGrid.Rows[e.RowIndex];
            txt_empId.Text = (row.FindControl("lbl_empno") as Label).Text;
            txt1.Text = (row.FindControl("lbl_fname") as Label).Text;
            txt2.Text = (row.FindControl("lbl_lname") as Label).Text;
            rblGender.Text = (row.FindControl("lbl_gender") as Label).Text;
            txt3.Text = (row.FindControl("lbl_email") as Label).Text;
            txt4.Text = (row.FindControl("lbl_mobile") as Label).Text;
            ddlstate.Text = (row.FindControl("lbl_state") as Label).Text;
            ddlcountry.Text = (row.FindControl("lbl_country") as Label).Text;
            BtnSave.Enabled = false;
            BtnUpdate.Enabled = true;
            lbl_Message.Text = "";
        }
        protected void EmployeeGrid_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            EmployeeGrid.EditIndex = -1;
            loaddata();  
        }

        protected void EmployeeGrid_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = EmployeeGrid.Rows[e.RowIndex];
            Label lbl_empno = (Label)row.FindControl("lbl_empno");
            var EmpNo = Convert.ToInt32(lbl_empno.Text);
            int rows = blLogic.DeleteData(EmpNo);
            if (rows == 1)
            {
                //lbl_Message.Text = "Employee Number -" + EmpNo.ToString() + " : Record Is Deleted";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);

            }
            else
            {
                //lbl_Message.Text = "Employee Number -" + EmpNo.ToString() + " : Record is not Deleted";
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record not deleted')", true);
            }
            loaddata();

        }
        protected void Insert_Data(object sender, EventArgs e)
        {
            if (rfvname.IsValid && rfvGender.IsValid && rvf3.IsValid && rfv4.IsValid)
            {
                employee.FIRSTNAME = txt1.Text;
                employee.LASTNAME = txt2.Text;
                employee.GENDER = rblGender.Text;
                employee.EMAIL = txt3.Text;
                employee.MOBILE = txt4.Text;
                employee.STATE = ddlstate.Text;
                employee.COUNTRY = ddlcountry.Text;
                EmpLogicClass blLogic = new EmpLogicClass();
                blLogic.InsertData(employee);
                loaddata();
                clearFields();
                lbl_Message.Text = "";
            }

        }

        protected void Update_Data(object sender, EventArgs e)
        {
            if (rfvname.IsValid && rfvGender.IsValid && rvf3.IsValid && rfv4.IsValid)
            {
                employee.EMPNO = int.Parse(txt_empId.Text);
                employee.FIRSTNAME = txt1.Text;
                employee.LASTNAME = txt2.Text;
                employee.GENDER = rblGender.Text;
                employee.EMAIL = txt3.Text;
                employee.MOBILE = txt4.Text;
                employee.STATE = ddlstate.Text;
                employee.COUNTRY = ddlcountry.Text;
                EmpLogicClass blLogic = new EmpLogicClass();
                blLogic.UpdateData(employee);
                loaddata();
                clearFields();
                BtnSave.Enabled = true;
                lbl_Message.Text = "";
                clearFields();
            }

        }
        private void clearFields()
        {
            
            txt_empId.Text = string.Empty;
            txt1.Text = string.Empty;
            txt2.Text = string.Empty;
            rblGender.ClearSelection();
            txt3.Text = string.Empty;
            txt4.Text = string.Empty;
            ddlstate.ClearSelection();
            ddlcountry.ClearSelection();
        }

        protected void BtnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
