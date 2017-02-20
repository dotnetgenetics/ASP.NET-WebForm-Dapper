using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASPWebFormDapperDemo.Models;

namespace ASPWebFormDapperDemo
{
    public partial class CRUDSampleNoValidation : System.Web.UI.Page
    {
        private Customer customer;
        private bool result = false;
        private CustomerService customerService = new CustomerService();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
            }
        }

        protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string item = e.Row.Cells[0].Text;
                foreach (Button button in e.Row.Cells[6].Controls.OfType<Button>())
                {
                    if (button.CommandName == "Delete")
                    {
                        button.Attributes["onclick"] = "if(!confirm('Do you want to delete record?')){ return false; };";
                    }
                }
            }
        }

        protected void OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int CustomerId = Convert.ToInt32(gvCustomer.DataKeys[e.RowIndex].Values[0]);
            result = customerService.DeleteCustomer(CustomerId);
            if (result)
            {
                lblMessage.Text = string.Empty;
                lblMessage.Text = "Successfully deleted the reccord!";
            }

            BindGrid();
        }

        protected void OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCustomer.EditIndex = e.NewEditIndex;
            lblMessage.Text = string.Empty;
            this.BindGrid();
        }

        protected void OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            customer = new Customer();
            GridViewRow row = gvCustomer.Rows[e.RowIndex];
            customer.CustomerID = Convert.ToInt32(gvCustomer.DataKeys[e.RowIndex].Values[0]);
            customer.Address = (row.FindControl("txtAddress1") as TextBox).Text;
            customer.City = (row.FindControl("txtCity1") as TextBox).Text;
            customer.State = (row.FindControl("txtState1") as TextBox).Text;
            customer.CompanyName = (row.FindControl("txtCompanyName1") as TextBox).Text;
            customer.IntroDate = Convert.ToDateTime((row.FindControl("txtIntroDate1") as TextBox).Text);
            customer.CreditLimit = Convert.ToDecimal((row.FindControl("txtCreditLimit1") as TextBox).Text);
            result = customerService.UpdateCustomer(customer);

            if (result)
            {
                lblMessage.Text = string.Empty;
                lblMessage.Text = "Successfully updated the reccord";
            }

            gvCustomer.EditIndex = -1;
            BindGrid();
        }

        protected void gvCustomer_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvCustomer.PageIndex = e.NewPageIndex;
            lblMessage.Text = string.Empty;
            BindGrid();
        }

        protected void OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCustomer.EditIndex = -1;
            lblMessage.Text = string.Empty;
            this.BindGrid();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            customer = new Customer();
            customer.Address = txtAddress.Text;
            customer.City = txtCity.Text;
            customer.CompanyName = txtCompanyName.Text;
            customer.State = txtState.Text;
            customer.CreditLimit = Convert.ToDecimal(txtCreditLimit.Text);
            customer.IntroDate = Convert.ToDateTime(txtIntroDate.Text);
            result = customerService.AddCustomer(customer);

            if (result)
            {
                lblMessage.Text = string.Empty;
                lblMessage.Text = "Successfully added a new reccord";
            }

            BindGrid();
        }

        private void BindGrid()
        {
            gvCustomer.DataSource = customerService.GetAll();
            gvCustomer.DataBind();
        }           
    }
}