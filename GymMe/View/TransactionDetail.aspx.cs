using Final_Project.Handler;
using Final_Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project.View
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MsUser user = GetUserFromSessionOrCookie();
                if (user == null)
                {
                    Response.Redirect("~/View/Login.aspx");
                    return;
                }
                SetView(user);

                string transactionID = Request["transactionID"];

                if (!string.IsNullOrEmpty(transactionID))
                {
                    LoadTransactionDetails(transactionID);
                }
                else
                {
                    Lbl_Status.Text = "Transaction ID is missing.";
                    Lbl_Status.Visible = true;
                }

            }
        }
        private void LoadTransactionDetails(string transactionID)
        {
            var transactionHeader = TransactionHandler.GetTransactionHeaderByID(transactionID);
            var transactionDetail = TransactionHandler.GetTransactionDetailByID(transactionID);
            if (transactionHeader != null && transactionDetail != null)
            {
                Lbl_Username.Text = "Username: " + transactionHeader.MsUser.UserName;
                Lbl_SupplementID.Text = "Supplement ID: " + transactionDetail. SupplementID.ToString();
                Lbl_SupplementName.Text = "Supplement Name: " + transactionDetail.MsSupplement.SupplementName;
                Lbl_Quantity.Text = "Quantity: " + transactionDetail.Quantity.ToString();
                Lbl_TransactionDate.Text = "Transaction Date: " + transactionHeader.TransactionDate.ToString("%d MMM yyyy");
                Lbl_Status.Text = "Status: " + transactionHeader.Status;
            }
            else
            {
                Lbl_Status.Text = "Transaction not found.";
                Lbl_Status.Visible = true;
            }
        }
        private MsUser GetUserFromSessionOrCookie()
        {
            MsUser user = null;
            if (Session["user"] != null)
            {
                user = Session["user"] as MsUser;
            }
            else if (Request.Cookies["user_cookie"] != null)
            {
                string id = Request.Cookies["user_cookie"].Value;
                user = UserHandler.GetUserByID(id);
                Session["user"] = user;
            }
            return user;
        }
        private void SetView(MsUser user)
        {
            Panel navbarAdmin = (Panel)Master.FindControl("navbar_admin");
            Panel navbarCustomer = (Panel)Master.FindControl("navbar_customer");

            if (UserHandler.isAdmin(user))
            {
                if (navbarAdmin != null) navbarAdmin.Visible = true;
                if (navbarCustomer != null) navbarCustomer.Visible = false;
            }
            else
            {
                if (navbarAdmin != null) navbarAdmin.Visible = false;
                if (navbarCustomer != null) navbarCustomer.Visible = true;
            }
        }
    }
}