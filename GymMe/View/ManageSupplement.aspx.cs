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
    public partial class ManageSupplement : System.Web.UI.Page
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
                GridView.DataSource = SupplementHandler.GetAllSupplements();
                GridView.DataBind();
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
        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridView.Rows[e.NewEditIndex];
            string supplementID = row.Cells[0].Text;
            Response.Redirect("~/View/UpdateSupplement.aspx?supplementID=" + supplementID);
        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView.Rows[e.RowIndex];
            string id = row.Cells[0].Text;
            SupplementHandler.DeleteSupplementByID(id);
            Response.Redirect("~/View/ManageSupplement.aspx");
        }

        protected void ButtonInsert_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertSupplement.aspx");
        }
    }
}