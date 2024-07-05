using Final_Project.Handler;
using Final_Project.Model;
using Final_Project.Repository;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project.View
{
    public partial class Home : System.Web.UI.Page
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

                customer_list.Visible = true;
                Lbl_user.Text = user.UserRole;
                GridView.DataSource = UserHandler.getAllUser();
                GridView.DataBind();
            }
            else
            {
                if (navbarAdmin != null) navbarAdmin.Visible = false;
                if (navbarCustomer != null) navbarCustomer.Visible = true;

                customer_list.Visible = false;
                Lbl_user.Text = user.UserRole;
                Lbl_Greet.Text = "Hello, " + user.UserName;
            }
        }

        protected void GridView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewRow row = GridView.Rows[e.NewEditIndex];
            string id = row.Cells[0].Text;
            Response.Redirect("~/View/Profile.aspx?ID=" + id);
        }

        protected void GridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView.Rows[e.RowIndex];
            string id = row.Cells[0].Text;
            UserHandler.DeleteUserByID(id);
            Response.Redirect("~/View/Home.aspx");
        }
    }
}
