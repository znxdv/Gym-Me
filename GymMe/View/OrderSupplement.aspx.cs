using Final_Project.Factory;
using Final_Project.Handler;
using Final_Project.Model;
using Final_Project.Modules;
using Final_Project.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project.View
{
    public partial class Order_Supplement : System.Web.UI.Page
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

                GridView1.DataSource = SupplementTypeRepository.GetAllSupplementType();
                GridView1.DataBind();
                GridView2.DataSource = SupplementHandler.GetAllSupplements();
                GridView2.DataBind();
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

        protected void Btn_addToCart_Click(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;
            int i = 0;
            
            foreach (GridViewRow row in GridView2.Rows)
            {
                TextBox Quantity = row.FindControl("QuantityTextBox") as TextBox;

                if (!string.IsNullOrEmpty(Quantity.Text.ToString()))
                {
                    Response<int> cartQuantity = CartHandler.checkQuantity(Quantity.Text);
                    
                    if (!cartQuantity.Success)
                    {
                        Lbl_status.Text = cartQuantity.Message;
                        i++;
                        continue;
                    }
                    else
                    {
                        CartHandler.AddToCart(user.UserID, GridView2.DataKeys[i].Value.ToString(), cartQuantity.Data);
                        Lbl_status.Text = "Order saved to cart successfully!";
                    }
                }
                else
                {
                    Lbl_status.Text = "Quantity cannot be empty!";
                }
                i++;
            }
        }

        protected void Btn_order_Click(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;
            List<MsCart> cart = CartHandler.GetUserCart(user.UserID);
            if (cart == null || cart.Count == 0)
            {
                Lbl_status.Visible = true;
                Lbl_status.Text = "Your cart is empty.";
                return;
            }
            Response<string> transaction = TransactionHandler.CreateTransaction(user.UserID, cart);
            Lbl_status.Visible = true;
            Lbl_status.Text = transaction.Message;
        }

        protected void Btn_clear_Click(object sender, EventArgs e)
        {
            MsUser user = Session["user"] as MsUser;

            if (user != null)
            {
                CartHandler.deleteUserCart(user.UserID);
                Lbl_status.Visible = true;
                Lbl_status.Text = "Your cart has been cleared.";
            }

            foreach (GridViewRow row in GridView2.Rows)
            {
                TextBox quantityTextBox = row.FindControl("TextBox1") as TextBox;
                if (quantityTextBox != null)
                {
                    quantityTextBox.Text = "";
                }
            }

        }

        
    }
}