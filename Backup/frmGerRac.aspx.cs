using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace WebSGQ
{
    public partial class frmGerRac : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                preencheGrid();
            }
            else
            {
                grdRac.DataBind();
            }
        }

        public void preencheGrid()
        {
            //cria uma conexão usando a string de conexão definida
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=qualidade;Integrated Security=True");
            //abre a conexão
            conn.Open();
            String sql = "SELECT r.Id as 'RAC', Modalidade, ResponsavelAbertura as 'Aberto por', Convert(varchar(10),DataAbertura,103) as 'Data Abertura', Convert(varchar(10),DataDisposicao,103) as 'Data Disposição', Convert(varchar(10),DataCausa,103) as 'Data Causa', Convert(varchar(10),DataPlanoAcao,103) as 'Data PA', rf.NomeUsuario as 'Fechado por', Convert(varchar(10),DataFechamento,103) as 'Data Fechamento', Status FROM Rac r left join RacCausas rc on r.Id = rc.CodigoRac left join RacPlanoAcao rpa on r.Id = rpa.CodigoRac left join RacFechamento rf on r.Id = rf.CodigoRac";
            if (cbomod.SelectedValue == "3")
            {
                sql = sql + " where Modalidade = 3";
            }
            else if (cbomod.SelectedValue == "2")
            {
                sql = sql + " where Modalidade = 2";
            }
            else if (cbomod.SelectedValue == "1")
            {
                sql = sql + " where Modalidade = 1";
            }
            else if (cbomod.SelectedValue == "4")
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
            grdRac.DataSource = dt;
            grdRac.DataBind();
        }

        protected void btnCon_Click(object sender, EventArgs e)
        {
            grdRac.DataBind();
        }
        protected void btnLimpar_Click(object sender, EventArgs e)
        {

        }

        protected void btnRelData_Click(object sender, EventArgs e)
        {

        }

        public void grdRac_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if ((e.Row.RowType == DataControlRowType.DataRow) && (e.Row.RowIndex != ((GridView)sender).EditIndex))
            {
                e.Row.Attributes["onclick"] = ClientScript.GetPostBackClientHyperlink(this.grdRac, "Select$" + e.Row.RowIndex.ToString());
            }
            
        }

        public void grdRac_RowDataBound(Object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.Cells[10].Text == "1")
                {
                    e.Row.Cells[10].Text = "Aberto";
                    e.Row.ForeColor = System.Drawing.Color.Blue;
                }
                if (e.Row.Cells[10].Text == "2")
                {
                    e.Row.Cells[10].Text = "Fechado";
                    e.Row.ForeColor = System.Drawing.Color.Red; 
                }
                if (e.Row.Cells[10].Text == "3")
                {
                    e.Row.Cells[10].Text = "Cancelado";
                    e.Row.ForeColor = System.Drawing.Color.Red; 
                }
                             
                if (e.Row.Cells[2].Text == "1")
                {
                    e.Row.Cells[2].Text = "NC Auditoria";
                }
                else if (e.Row.Cells[2].Text == "2")
                {
                    e.Row.Cells[2].Text = "NC Fornecedor";
                }
                else if (e.Row.Cells[2].Text == "3")
                {
                    e.Row.Cells[2].Text = "NC Processo";
                }
                else
                {
                    e.Row.Cells[2].Text = "Reclamação de Cliente";
                }

            }
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //e.Row.Attributes["onClick"] = "alert('Valor= " + Convert.ToInt32(grdRac.DataKeys[e.Row.RowIndex].Value) + "');";
                //e.Row.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(sender, "Select$" + e.Row.RowIndex.ToString));
            }
        }

        protected void grdRac_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("frmDetalhesRac.aspx?Id=" + grdRac.Rows[grdRac.SelectedIndex].Cells[1].Text);
        }
    }
}