using Final_Project.Controller;
using Final_Project.Handler;
using Final_Project.Model;
using Final_Project.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project.View
{
    public partial class UpdateSupplement : System.Web.UI.Page
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
            }
            else
            {
                if (navbarAdmin != null) navbarAdmin.Visible = false;
                if (navbarCustomer != null) navbarCustomer.Visible = true;
            }
        }

        protected void Btn_updateSupplement_Click(object sender, EventArgs e)
        {
            string id = Request["supplementID"];
            MsUser user = UserHandler.GetUserByID(id);
            string name = Txt_supplementName.Text;
            string expiryDate = Txt_supplementExpiryDate.Text;
            string price = Txt_supplementPrice.Text;
            string typeID = Txt_supplementTypeID.Text;

            Response<MsSupplement> checkSupplement = SupplementHandler.validateUpdateSupplement(id, name, expiryDate, price, typeID);
            if (!checkSupplement.Success)
            {
                Lbl_error.Visible = true;
                Lbl_error.Text = checkSupplement.Message;
                Lbl_scs.Visible = false;
                return;
            }
            Response.Redirect("~/View/ManageSupplement.aspx");
        }
    }
}