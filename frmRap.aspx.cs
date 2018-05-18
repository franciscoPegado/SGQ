using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebSGQ
{
    public partial class frmRap : System.Web.UI.Page
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
                string sql = "INSERT INTO RAP(DataAbertura ,ResponsavelAbertura, Modalidade, HistoricoSugestao, AnaliseRecomendacoes, ResponsavelAnaliseRecomendacoes, Justificativa, Status) VALUES (@DataAbertura, @ResponsavelAbertura, @Modalidade, @HistoricoSugestao, @AnaliseRecomendacoes, @ResponsavelAnaliseRecomendacoes, @Justificativa, @Status)";

                SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@DataAbertura", txtDatAber.Text));
                comando.Parameters.Add(new SqlParameter("@ResponsavelAbertura", lblrespaber1.Text));
                comando.Parameters.Add(new SqlParameter("@Modalidade", cboMod.SelectedValue));
                comando.Parameters.Add(new SqlParameter("@HistoricoSugestao", txtHistSuge.Text));
                comando.Parameters.Add(new SqlParameter("@AnaliseRecomendacoes", txtAnaRec.Text));
                comando.Parameters.Add(new SqlParameter("@ResponsavelAnaliseRecomendacoes", txtResp.Text));
                comando.Parameters.Add(new SqlParameter("@Justificativa", cboJust.SelectedValue));
                comando.Parameters.Add(new SqlParameter("@Status", 1));

                lblMsg.Text = "RAP incluído com sucesso!";
                limpaCampos();
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
            }
        }
        
        protected void btnLimpar_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        public void limpaCampos()
        {
            txtDatAber.Text = "";
            cboMod.SelectedValue = "0";
            cboJust.SelectedValue = "0";
            txtHistSuge.Text = "";
            txtAnaRec.Text = "";
            txtResp.Text = "";
        }

        public Boolean criticaCampos()
        {
            if (txtDatAber.Text == "")
            {
                lblMsg.Text = "Informe data de abertura";
                SetFocus(txtDatAber);
                return false;
            }
            if (cboMod.SelectedValue == "0")
            {
                lblMsg.Text = "Escolha modalidade";
                return false;
            }
            if (txtHistSuge.Text == "")
            {
                lblMsg.Text = "Informe histórico/Sugestão";
                SetFocus(txtHistSuge);
                return false;
            }
            return true;
        }

        [System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
        public static string[] GetCompletionListFuncionario(string prefixText, int count, string contextKey)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=192.168.200.203;Initial Catalog=RH_FAST_HML;Integrated Security=True");
            string sql = "Select Nome from DO_FUNCIONARIOS Where NOME like @prefixText";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            da.SelectCommand.Parameters.Add("@prefixText", System.Data.SqlDbType.VarChar, 50).Value = prefixText + "%";
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            string[] items = new string[dt.Rows.Count];
            int i = 0;
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                items.SetValue(dr["Nome"].ToString(), i);
                i++;
            }
            return items;
        }
    }
}