using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebSGQ
{
    public partial class frmDetalhesRac : System.Web.UI.Page
    {
        String Id;

        protected void Page_Load(object sender, EventArgs e)
        {
            Id = Request.QueryString["Id"];

            if (!Page.IsPostBack)
            {

                

                String mod = "";
                String status = "";

                SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=qualidade;Integrated Security=True");
                string sql = "Select ResponsavelAbertura, Convert(varchar(10),DataAbertura,103) as DataAbertura, Status, Modalidade, HistoricoProblema, ResponsavelDisposicao,Convert(varchar(10),DataDisposicao,103) as DataDisposicao, Disposicao, rc.NomeUsuario as NomeUsuarioCausa, Convert(varchar(10),DataCausa,103) as DataCausa, Causa, rpa.NomeUsuario as NomeUsuarioPlanoAcao, Convert(varchar(10),DataPlanoAcao,103) as DataPlanoAcao, PlanoAcao, rf.NomeUsuario as NomeUsuarioPlanoAcao, Convert(varchar(10),DataFechamento,103) as DataFechamento, Verificacao from Rac r left join RacCausas rc on r.Id = rc.CodigoRac left join RacPlanoAcao rpa on r.Id = rpa.CodigoRac left join RacFechamento rf on r.Id = rf.CodigoRac Where r.Id = " + Id;
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                int i = 0;
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    lbldataber.Text = dr["DataAbertura"].ToString();
                    lblrespaber.Text = dr["ResponsavelAbertura"].ToString();
                    status = dr["Status"].ToString();
                    mod = dr["Modalidade"].ToString();
                    txthist.Text = dr["HistoricoProblema"].ToString();
                    txtrespdis.Text = dr["ResponsavelDisposicao"].ToString();
                    txtdatadis.Text = dr["DataDisposicao"].ToString();
                    txtdis.Text = dr["Disposicao"].ToString();
                    txtCausa.Text = dr["Causa"].ToString();
                    if (dr["Causa"].ToString() != "")
                    {
                        tblRespCad.Visible = true;
                        tblDatCad.Visible = true;
                    }
                    lblRespCausa.Text = dr["ResponsavelAbertura"].ToString();
                    if (dr["DataCausa"].ToString() == "")
                    {
                        lblDataCausa.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        lblDataCausa.Text = dr["DataCausa"].ToString();
                    }
                    txtPlanAção.Text = dr["PlanoAcao"].ToString();
                    txtRespPlan.Text = dr["NomeUsuarioPlanoAcao"].ToString();
                    txtDatConPlan.Text = dr["DataPlanoAcao"].ToString();
                    txtVeriFecha.Text = dr["Verificacao"].ToString();
                    if (dr["Verificacao"].ToString() != "")
                    {
                        tblAuditorVeriFecha.Visible = true;
                        tblDataVeriFecha.Visible = true;
                    }
                    lblAuditorVeriFecha.Text = dr["ResponsavelAbertura"].ToString();
                    if (dr["DataFechamento"].ToString() == "")
                    {
                        lblDataVeriFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        lblDataVeriFecha.Text = dr["DataFechamento"].ToString();
                    }

                    if (mod == "1")
                    {
                        mod = "NC Auditoria";
                    }
                    else if (mod == "2")
                    {
                        mod = "NC Fornecedor";
                    }
                    else if (mod == "3")
                    {
                        mod = "NC Processo";
                    }
                    else
                    {
                        mod = "Reclamação de Cliente";
                    }

                    lblmod.Text = mod;

                    if (status == "1")
                    {
                        status = "Aberto";
                    }
                    else if (status == "2")
                    {
                        status = "Fechado";
                    }
                    else if (status == "3")
                    {
                        status = "Cancelado";
                    }

                    lblstatus.Text = status;

                    i++;
                }
                conn.Close();
            }
            else
            {
                lblMsgHist.Text = "";
                lblMsgPlanAcao.Text = "";
                lblmsgdispo.Text = "";
                lblMsgVeriFecha.Text = "";
                lblMsgCausa.Text = "";
            }
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
            conn.Close();
            return items;
        }

        protected void btnSalvarHist_Click(object sender, EventArgs e)
        {
                if (txthist.Text == "")
                {
                    lblMsgHist.Text = "Preencha Histórico!";
                    return;
                }

                lblMsgHist.Text = "";
                SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=qualidade;Integrated Security=True");
                string sql = "Update Rac Set HistoricoProblema=@HistoricoProblema Where Id = " + Id;
                SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@HistoricoProblema", txthist.Text));
                lblMsgHist.Text = "Histórico alterado com sucesso!";
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
        }

        protected void btnSalvarDisp_Click(object sender, EventArgs e)
        {
                if (txtrespdis.Text == "")
                {
                    lblmsgdispo.Text = "Preencha responsável!";
                    return;
                }

                if (txtdatadis.Text == "")
                {
                    lblmsgdispo.Text = "Preencha data!";
                    return;
                }

                if (txtdis.Text == "")
                {
                    lblmsgdispo.Text = "Preencha a disposição!";
                    return;
                }

                lblmsgdispo.Text = "";
                SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=qualidade;Integrated Security=True");
                string sql = "Update Rac Set ResponsavelDisposicao=@ResponsavelDisposicao, DataDisposicao=@DataDisposicao, Disposicao=@Disposicao Where Id = " + Id;
                SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@ResponsavelDisposicao", txtrespdis.Text));
                comando.Parameters.Add(new SqlParameter("@DataDisposicao", txtdatadis.Text));
                comando.Parameters.Add(new SqlParameter("@Disposicao", txtdis.Text));
                lblmsgdispo.Text = "Disposição alterado com sucesso!";
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
        }

        protected void btnSalvarCausa_Click(object sender, EventArgs e)
        {
            if (txtCausa.Text == "")
            {
                lblMsgCausa.Text = "Preencha Causa!";
                return;
            }

            String codigoRac = "";
            lblMsgCausa.Text = "";

            SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=qualidade;Integrated Security=True");
            string sqlSelect = "Select CodigoRac from RacCausas Where CodigoRac = " + Id;
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                codigoRac = dr["CodigoRac"].ToString();
                i++;
            }

            if (codigoRac == "")
            {
                string sql = "INSERT INTO RacCausas(CodigoRac, Causa, NomeUsuario, DataCausa) VALUES (@CodigoRac, @Causa, @NomeUsuario, @DataCausa)";

                SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@CodigoRac", Id));
                comando.Parameters.Add(new SqlParameter("@Causa", txtCausa.Text));
                comando.Parameters.Add(new SqlParameter("@NomeUsuario", lblRespCausa.Text));
                comando.Parameters.Add(new SqlParameter("@DataCausa", lblDataCausa.Text));
                lblMsgCausa.Text = "Causa incluída com sucesso!";
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
                tblDatCad.Visible = true;
                tblRespCad.Visible = true;
            }
            else
            {
                string sqlUpdate = "Update RacCausas Set Causa=@Causa Where CodigoRac = " + Id;
                SqlCommand comandoUpdate = new SqlCommand(sqlUpdate, conn);
                comandoUpdate.Parameters.Add(new SqlParameter("@Causa", txtCausa.Text));
                lblMsgCausa.Text = "Causa alterada com sucesso!";
                conn.Open();
                comandoUpdate.ExecuteNonQuery();
                conn.Close();
                tblDatCad.Visible = true;
                tblRespCad.Visible = true;
            }
            conn.Close();

        }

        protected void btnSalvarPlanAcao_Click(object sender, EventArgs e)
        {
            if (txtRespPlan.Text == "")
            {
                lblMsgPlanAcao.Text = "Preencha responsável!";
                return;
            }

            if (txtDatConPlan.Text == "")
            {
                lblMsgPlanAcao.Text = "Preencha data!";
                return;
            }

            if (txtPlanAção.Text == "")
            {
                lblMsgPlanAcao.Text = "Preencha plano ação!";
                return;
            }

            String codigoRac = "";
            lblMsgPlanAcao.Text = "";

            SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=qualidade;Integrated Security=True");
            string sqlSelect = "Select CodigoRac from RacPlanoAcao Where CodigoRac = " + Id;
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                codigoRac = dr["CodigoRac"].ToString();
                i++;
            }

            if (codigoRac == "")
            {
                string sql = "INSERT INTO RacPlanoAcao(CodigoRac, PlanoAcao, NomeUsuario, DataPlanoAcao) VALUES (@CodigoRac, @PlanoAcao, @NomeUsuario, @DataPlanoAcao)";

                SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@CodigoRac", Id));
                comando.Parameters.Add(new SqlParameter("@PlanoAcao", txtPlanAção.Text));
                comando.Parameters.Add(new SqlParameter("@NomeUsuario", txtRespPlan.Text));
                comando.Parameters.Add(new SqlParameter("@DataPlanoAcao", txtDatConPlan.Text));
                lblMsgPlanAcao.Text = "Plano de ação incluído com sucesso!";
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                string sqlUpdate = "Update RacPlanoAcao Set PlanoAcao=@PlanoAcao, DataPlanoAcao=@DataPlanoAcao, NomeUsuario=@NomeUsuario Where CodigoRac = " + Id;
                SqlCommand comandoUpdate = new SqlCommand(sqlUpdate, conn);
                comandoUpdate.Parameters.Add(new SqlParameter("@PlanoAcao", txtPlanAção.Text));
                comandoUpdate.Parameters.Add(new SqlParameter("@DataPlanoAcao", txtDatConPlan.Text));
                comandoUpdate.Parameters.Add(new SqlParameter("@NomeUsuario", txtRespPlan.Text));
                lblMsgPlanAcao.Text = "Plano de ação alterado com sucesso!";
                conn.Open();
                comandoUpdate.ExecuteNonQuery();
                conn.Close();
                tblDatCad.Visible = true;
                tblRespCad.Visible = true;
            }
            conn.Close();
        }

        protected void btnSalvarVeriFecha_Click(object sender, EventArgs e)
        {
            if (txtVeriFecha.Text == "")
            {
                lblMsgVeriFecha.Text = "Preencha verificação!";
                return;
            }

            String codigoRac = "";
            lblMsgVeriFecha.Text = "";

            SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=qualidade;Integrated Security=True");
            string sqlSelect = "Select CodigoRac from RacFechamento Where CodigoRac = " + Id;
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                codigoRac = dr["CodigoRac"].ToString();
                i++;
            }

            if (codigoRac == "")
            {
                string sql = "INSERT INTO RacFechamento(CodigoRac, Verificacao, NomeUsuario, DataFechamento) VALUES (@CodigoRac, @Verificacao, @NomeUsuario, @DataFechamento)";

                SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@CodigoRac", Id));
                comando.Parameters.Add(new SqlParameter("@Verificacao", txtVeriFecha.Text));
                comando.Parameters.Add(new SqlParameter("@NomeUsuario", lblAuditorVeriFecha.Text));
                comando.Parameters.Add(new SqlParameter("@DataFechamento", lblDataVeriFecha.Text));
                lblMsgVeriFecha.Text = "Verificacão/Fechamento incluído com sucesso!";
                conn.Open();
                comando.ExecuteNonQuery();
                tblAuditorVeriFecha.Visible = true;
                tblDataVeriFecha.Visible = true;

                string sqlUpdate = "Update Rac Set Status=@Status Where Id = " + Id;
                SqlCommand comandoUpdate = new SqlCommand(sqlUpdate, conn);
                comandoUpdate.Parameters.Add(new SqlParameter("@Status", 2));
                comandoUpdate.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                string sqlUpdate = "Update RacFechamento Set Verificacao=@Verificacao Where CodigoRac = " + Id;
                SqlCommand comandoUpdate = new SqlCommand(sqlUpdate, conn);
                comandoUpdate.Parameters.Add(new SqlParameter("@Verificacao", txtVeriFecha.Text));
                lblMsgVeriFecha.Text = "Verificacão/Fechamento alterado com sucesso!";
                conn.Open();
                comandoUpdate.ExecuteNonQuery();
                conn.Close();
                tblAuditorVeriFecha.Visible = true;
                tblDataVeriFecha.Visible = true;
            }
            conn.Close();

        }
    }
}