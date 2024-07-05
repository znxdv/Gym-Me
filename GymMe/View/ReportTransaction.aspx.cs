using Final_Project.Dataset;
using Final_Project.Handler;
using Final_Project.Model;
using Final_Project.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Final_Project.View
{
    public partial class ReportTransaction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MsUser user = GetUserFromSessionOrCookie();
                if (user == null)
                {
                    Response.Redirect("~/View/Login.aspx");
                    return;
                }
                SetView(user);

            }

            TransactionReport report = new TransactionReport();
            ReportViewer.ReportSource = report;
            List<TransactionHeader> transactions = TransactionHandler.GetAllTransactions();
            report.SetDataSource(getDataset(transactions));
        }

        private fDataset getDataset(List<TransactionHeader> transactions)
        {
            fDataset data = new fDataset();
            var headerTable = data.Header;
            var detailTable = data.Details;
            var supplementTable = data.Supplement;

            foreach(TransactionHeader t in transactions)
            {
                var headerRow = headerTable.NewRow();
                headerRow["DataColumn1"] = t.UserID;
                headerRow["TransactionID"] = t.TransactionID;
                headerRow["Transaction_Date"] = t.TransactionDate;
                headerRow["Status"] = t.Status;
                headerTable.Rows.Add(headerRow);

                var detailRow = detailTable.NewRow();
                detailRow["TransactionID"] = t.TransactionDetail.TransactionID;
                detailRow["SupplementID"] = t.TransactionDetail.SupplementID;
                detailRow["Quantity"] = t.TransactionDetail.Quantity;
                detailTable.Rows.Add(detailRow);

                var supplementRow = supplementTable.NewRow();
                supplementRow["SupplementID"] = t.TransactionDetail.MsSupplement.SupplementID;
                supplementRow["SupplementName"] = t.TransactionDetail.MsSupplement.SupplementName;
                supplementRow["SupplementExpiryDate"] = t.TransactionDetail.MsSupplement.SupplementExpiryDate;
                supplementRow["SupplementPrice"] = t.TransactionDetail.MsSupplement.SupplementPrice;
                supplementRow["SupplementTypeID"] = t.TransactionDetail.MsSupplement.SupplementTypeID;
                supplementTable.Rows.Add(supplementRow);
            }

            return data;
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
    }
}