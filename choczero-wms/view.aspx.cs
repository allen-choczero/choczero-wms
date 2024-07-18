using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace choczero_wms
{
    public partial class view : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("server=localhost; database=choczero-wms; integrated security=sspi");
            con.Open();
            SqlCommand cmd = new SqlCommand(
                "SELECT asin, inventory_quantity, sale_quantity, thirty_day_sales_estimate, " + "" +
                "days_remaining FROM remainder_calc ORDER BY days_remaining ASC", con);
            // cmd.CommandType = System.Data.CommandType.StoredProcedure
            SqlDataAdapter adater = new SqlDataAdapter(cmd);
            DataTable dtInv = new DataTable("a");

            adater.Fill(dtInv);
            this.GridView1.DataSource = dtInv;
            this.GridView1.DataBind();
        }

        protected void OnRowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = e.Row.DataItem as DataRowView;
                Object ob = drv["days_remaining"];
                int days = Int16.Parse(ob.ToString());

                if (days < 30)
                {

                    foreach (TableCell cell in e.Row.Cells)
                    {
                        cell.BackColor = System.Drawing.Color.Orange;
                    }

                }
                if (days < 5)
                {

                    foreach (TableCell cell in e.Row.Cells)
                    {
                        cell.BackColor = System.Drawing.Color.Red;
                    }

                }

            }
        }
    }
}