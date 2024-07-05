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
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }
        protected void Btn_Register_Click(object sender, EventArgs e)
        {
            string username = Txt_Username.Text;
            string email = Txt_Email.Text;
            string gender = Register_Btn_Gender.SelectedValue;
            string password = Txt_Password.Text;
            string confirmationPassword = Txt_Confirm_Password.Text;
            string DOB = Txt_DOB.Text;

            Response<MsUser> newUser = UserHandler.checkRegister(username, email, gender, password, confirmationPassword, DOB);

            if (!newUser.Success)
            {
                Lbl_Error.Visible = true;
                Lbl_Error.Text = newUser.Message;
                return;
            }

            Lbl_Error.Visible = true;
            Lbl_Error.Text = "";
            Lbl_Success.Visible = true;
            Lbl_Success.Text = newUser.Message;

            Response.Redirect("~/View/Home.aspx");
        }
    }
}