using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Net;
using System.Text;
using System.IO;
using System.Globalization;

namespace calendario
{
    public partial class FlipGridView : System.Web.UI.Page
    {
        public static int diasmes = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
        
        protected void Page_Load(object sender, EventArgs e)
        {
          if (IsPostBack == false)
            
            {
                 ddl_mes.SelectedValue =  Convert.ToString(DateTime.Now.Month);
                 GridView1.DataSource = FlipDataSet(c()); 
                 GridView1.DataBind();  
            } 
           
            
            


        }
        public DataSet c()
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable("Company");
            DataRow dr;
            dt.Columns.Add(new DataColumn("Dia", typeof(Int32)));
            dt.Columns.Add(new DataColumn(" ", typeof(string)));
            dt.Columns.Add(new DataColumn("Cabaña 1", typeof(string)));
            dt.Columns.Add(new DataColumn("Cabaña 2", typeof(string)));
            dt.Columns.Add(new DataColumn("Cabaña 3", typeof(string)));
            dt.Columns.Add(new DataColumn("Cabaña 4", typeof(string)));
            dt.Columns.Add(new DataColumn("Cabaña 5", typeof(string)));
            dt.Columns.Add(new DataColumn("Cabaña 6", typeof(string)));
            /*dt.Columns[1].DefaultCellStyle.BackColor*/

            /* if (ddl_mes.SelectedValue.ToString() == "2")
             {
                 diasmes = 28;
             }*/
            Diadelmes();
            DateTime dateValue = new DateTime();
           

            for (int i = 1; i <= diasmes; i++)
            {
                dateValue = Convert.ToDateTime(Convert.ToString(ddl_ano.SelectedValue+"/"+ddl_mes.SelectedValue+"/"+i));
                /*TextBox1.Text += dateValue.ToString("ddd", new CultureInfo("es-ES"));*/
                dr = dt.NewRow();

                dr[0] = i ;
                dr[1] = dateValue.ToString("ddd", new CultureInfo("es-ES"));
                if (i == 3)
                {
                    dr[2] = "ok";
                    
                }
                else
                {
                    dr[2] = "--";
                }
                
                dr[3] = "--";
                dr[4] = "ok";
                dr[5] = "--";
                dr[6] = "--";
                dr[7] = "ok";
                dt.Rows.Add(dr);
            }
            ds.Tables.Add(dt);
            return ds;
        }
        public DataSet FlipDataSet(DataSet my_DataSet)
        {
            DataSet ds = new DataSet();
            foreach (DataTable dt in my_DataSet.Tables)
            {
                DataTable table = new DataTable();
                for (int i = 0; i <= dt.Rows.Count; i++)
                {
                    table.Columns.Add(Convert.ToString(i));
                }
                DataRow r = null;
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    r = table.NewRow();
                    r[0] = dt.Columns[k].ToString();
                    for (int j = 1; j <= dt.Rows.Count; j++)
                        r[j] = dt.Rows[j - 1][k];
                    table.Rows.Add(r);
                }
                ds.Tables.Add(table);
            }
            
            return ds;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
            /* if (ddl_mes.SelectedValue.ToString() == "2")
             {
                 diasmes = 28;
             }*/

            Diadelmes();

            if (e.Row.RowType== DataControlRowType.DataRow)
            {
                
                for (int i = 0; i <= diasmes; i++)
                {

                    string notas = DataBinder.Eval(e.Row.DataItem, Convert.ToString(i)).ToString();


                    if (notas == "--")
                    {
                        e.Row.Cells[i].BackColor = System.Drawing.Color.LightGreen;

                    }
                    else
                    {

                        if (notas == "ok")
                            e.Row.Cells[i].BackColor = System.Drawing.Color.Red;
                    }
                    if (GridView1.Rows.Count > 1)
                    {

                        if (GridView1.Rows[1].Cells[i].Text == "s&#225;." || GridView1.Rows[1].Cells[i].Text == "do.")
                        {
                            if (notas != "ok")
                            {
                                /*e.Row.Cells[i].BackColor = System.Drawing.Color.Red;*/
                                GridView1.Rows[0].Cells[i].BackColor = System.Drawing.Color.Yellow;
                                e.Row.Cells[i].BackColor = System.Drawing.Color.Yellow;
                            }
                        }
                    }
                    else
                    {
                        if (notas == "sá." || notas == "do.")
                        {
                            e.Row.Cells[i].BackColor = System.Drawing.Color.Yellow;
                            /*GridView1.Rows[0].Cells[i].BackColor = System.Drawing.Color.Yellow;*/
                        }
                    }
                }
            }
        }

        protected void btn_buscar_find(object sender, EventArgs e)
        {
            GridView1.DataSource = FlipDataSet(c());
            GridView1.DataBind();
        }
        protected void Diadelmes()
        {
           diasmes = DateTime.DaysInMonth(Convert.ToInt32(ddl_ano.SelectedValue), Convert.ToInt32(ddl_mes.SelectedValue));
            
        }
    }
}   