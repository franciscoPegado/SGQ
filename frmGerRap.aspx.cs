using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebSGQ
{
    public partial class frmGerRap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                preencheGrid();
            }
            else
            {
                grdRap.DataBind();
            }
        }

        public void preencheGrid()
        {
            //cria uma conexão usando a string de conexão definida
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=qualidade;Integrated Security=True");
            //abre a conexão
            conn.Open();
            String sql = "SELECT r.Id as 'RAP', Modalidade, ResponsavelAbertura as 'Aberto por', Convert(varchar(10),DataAbertura,103) as 'Data Abertura', Convert(varchar(10),DataFechamento,103) as 'Data Fechamento', Status FROM Rap r left join RapFechamento rf on r.Id = rf.CodigoRap";
            if (cboMod.SelectedValue == "3")
            {
                sql = sql + " where Modalidade = 3";
            }
            else if (cboMod.SelectedValue == "2")
            {
                sql = sql + " where Modalidade = 2";
            }
            else if (cboMod.SelectedValue == "1")
            {
                sql = sql + " where Modalidade = 1";
            }
            else if (cboMod.SelectedValue == "4")
            {
                sql = sql + " where Modalidade = 4";
            }
            else
            {
                sql = sql + " where 1 = 1";
            }

            if (cborespaber.SelectedValue == "2")
            {
                sql = sql + " and ResponsavelAbertura like '%Francisco Pegado%'";
            }
            else if (cborespaber.SelectedValue == "1")
            {
                sql = sql + " and ResponsavelAbertura like '%David Holanda%'";
            }
            else
            {
                sql = sql + " and 1 = 1";
            }

            if (cbostatus.SelectedValue == "1")
            {
                sql = sql + " and Status = 1";
            }
            else if (cbostatus.SelectedValue == "2")
            {
                sql = sql + " and Status = 2";
            }
            else if (cbostatus.SelectedValue == "3")
            {
                sql = sql + " and Status = 3";
            }
            else
            {
                sql = sql + " and 1 = 1";
            }

            if (txtnumrac.Text != "")
            {
                sql = sql + " and r.Id = " + txtnumrac.Text;
            }

            sql = sql + " order by r.Id desc";

            //define um objeto Command para a conexão criada
            SqlCommand cmd = new SqlCommand(sql, conn);
            //realizar um acesso somente-leitura no banco de dados
            SqlDataReader dr = cmd.ExecuteReader();
            //cria um datatable que conterá os dados
            DataTable dt = new DataTable();
            //carrega o datatable com os dados do datareader
            dt.Load(dr);
            //exibe os dados no GridView
            grdRap.DataSource = dt;
            grdRap.DataBind();
        }

        protected void btnCon_Click(object sender, EventArgs e)
        {
            grdRap.DataBind();
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {

        }

        public void grdRap_RowDataBound(Object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[6].Text == "1")
                {
                    e.Row.Cells[6].Text = "Aberto";
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                }
                if (e.Row.Cells[6].Text == "2")
                {
                    e.Row.Cells[6].Text = "Fechado";
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }
                if (e.Row.Cells[6].Text == "3")
                {
                    e.Row.Cells[6].Text = "Cancelado";
                    e.Row.ForeColor = System.Drawing.Color.Red;
                }

                if (e.Row.Cells[2].Text == "1")
                {
                    e.Row.Cells[2].Text = "NC Potencial";
                }
                else if (e.Row.Cells[2].Text == "2")
                {
                    e.Row.Cells[2].Text = "Observação de Auditoria";
                }
                else if (e.Row.Cells[2].Text == "3")
                {
                    e.Row.Cells[2].Text = "Oportunidade de Melhoria";
                }
                else
                {
                    e.Row.Cells[2].Text = "Sugestão";
                }

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes["onClick"] = "alert('Valor= " + Convert.ToInt32(grdRac.DataKeys[e.Row.RowIndex].Value) + "');";
                //e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(sender, "Select$" + e.Row.RowIndex.ToString));
            }
        }

        protected void grdRap_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("frmDetalhesRap.aspx?Id=" + grdRap.Rows[grdRap.SelectedIndex].Cells[1].Text);
        }
    }
}