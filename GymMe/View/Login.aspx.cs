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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["user_cookie"] != null)
            {
                Response.Redirect("~/View/Home.aspx");
            }
        }

        protected void Btn_Login_Click(object sender, EventArgs e)
        {
            Response<MsUser> user = UserHandler.checkLogin(Txt_Username.Text, Txt_Password.Text);

            if (!user.Success)
            {
                Lbl_Error.Visible = true;
                Lbl_Error.Text = user.Message;
                return;
            }

            Lbl_Error.Text = "Login success!";
            Lbl_Error.CssClass = "Login-Success";

            if (Chk_Remember.Checked)
            {
                HttpCookie cookie = new HttpCookie("user_cookie");
                cookie.Value = user.Data.UserID.ToString();
                cookie.Expires = DateTime.Now.AddHours(1);
                Response.Cookies.Add(cookie);
            }

            Session["user"] = user.Data;
            Response.Redirect("~/View/Home.aspx");
        }
    }
}