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
    public partial class Profile : System.Web.UI.Page
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
        protected void Btn_UpdateProfile_Click(object sender, EventArgs e)
        {
            string id = Request["ID"];
            MsUser user = UserHandler.GetUserByID(id);
            string username = Txt_Username.Text;
            string email = Txt_Email.Text;
            string gender = RBtn_Gender.SelectedValue;
            string dob = Txt_DOB.Text;

            Response<MsUser> updatedProfile = UserHandler.checkUpdateProfile(user.UserID, username, email, gender, dob);
            if (!updatedProfile.Success)
            {
                Lbl_error.Visible = true;
                Lbl_error.Text = updatedProfile.Message;
                return;
            }

            Lbl_scs.Visible = true;
            Lbl_scs.Text = updatedProfile.Message;
        }
        protected void Btn_updatePassword_Click(object sender, EventArgs e)
        {
            string id = Request["ID"];
            MsUser user = UserHandler.GetUserByID(id);
            string currentPassword = Txt_currentPassword.Text;
            string newPassword = Txt_newPassword.Text;
            string confirmationPassword = Txt_confirmationPassword.Text;

            Response<MsUser> checkPassword = UserController.validateConfirmationPassword(newPassword, confirmationPassword);
            if (!checkPassword.Success)
            {
                Lbl_error2.Visible = true;
                Lbl_error2.Text = checkPassword.Message;
                Lbl_scs2.Visible = false;
                return;
            }

            Response<MsUser> updatePassword = UserHandler.checkUpdatePassword(user.UserID, user.UserPassword, newPassword, currentPassword);
            if (!updatePassword.Success)
            {
                Lbl_error2.Visible = true;
                Lbl_error2.Text = updatePassword.Message;
                Lbl_scs2.Visible = false;
                return;
            }

            Lbl_error2.Text = "";
            Lbl_error2.Visible = false;
            Lbl_scs2.Visible = true;
            Lbl_scs2.Text = updatePassword.Message;
        }

    }
}