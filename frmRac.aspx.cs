using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebSGQ
{
    public partial class frmRac : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnInc_Click(object sender, EventArgs e)
        {
            if (criticaCampos())
            {
                lblMsg.Text = "";

                SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=qualidade;Integrated Security=True");
                string sql = "INSERT INTO RAC(DataAbertura ,ResponsavelAbertura, Modalidade, HistoricoProblema, Disposicao, ResponsavelDisposicao, DataDisposicao, Status) VALUES (@DataAbertura, @ResponsavelAbertura, @Modalidade, @HistoricoProblema, @Disposicao, @ResponsavelDisposicao, @DataDisposicao, @Status)";

                SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@DataAbertura", txtdataber.Text));
                comando.Parameters.Add(new SqlParameter("@ResponsavelAbertura", lblrespaber1.Text));
                comando.Parameters.Add(new SqlParameter("@Modalidade", cbomod.SelectedValue));
                comando.Parameters.Add(new SqlParameter("@HistoricoProblema", txthis.Text));
                comando.Parameters.Add(new SqlParameter("@Disposicao", txtdis.Text));
                comando.Parameters.Add(new SqlParameter("@ResponsavelDisposicao", txtrespdis.Text));
                comando.Parameters.Add(new SqlParameter("@DataDisposicao", txtdatdis.Text));
                comando.Parameters.Add(new SqlParameter("@Status", 1));
                
                lblMsg.Text = "RAC incluído com sucesso!";
                limpaCampos();
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
            }
        }

        public Boolean criticaCampos()
        {
            if (txtdataber.Text == "")
            {
                lblMsg.Text = "Informe data de abertura";
                SetFocus(txtdataber);
                return false;
            }
            if (cbomod.SelectedValue == "0")
            {
                lblMsg.Text = "Escolha modalidade";
                return false;
            }
            if (txthis.Text == "")
            {
                lblMsg.Text = "Informe histórico";
                SetFocus(txthis);
                return false;
            }
            return true;
        }

        public void limpaCampos()
        {
            txtdataber.Text = "";
            cbomod.SelectedValue = "0";
            txthis.Text = "";
            txtdis.Text = "";
            txtrespdis.Text = "";
            txtdatdis.Text = "";
        }

        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        

        protected void txthis_TextChanged(object sender, EventArgs e)
        {

        }
    }
}