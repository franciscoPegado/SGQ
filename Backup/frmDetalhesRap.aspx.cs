﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebSGQ
{
    public partial class frmDetalhesRap : System.Web.UI.Page
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
                string sql = "Select ResponsavelAbertura, Convert(varchar(10),DataAbertura,103) as DataAbertura, Status, Modalidade, HistoricoSugestao, ResponsavelAnaliseRecomendacoes, AnaliseRecomendacoes, rp.NomeUsuario as NomeUsuarioProblema, Convert(varchar(10),DataProblema,103) as DataProblema, Problema, rpa.NomeUsuario as NomeUsuarioPlanoAcao, Convert(varchar(10),DataPlanoAcao,103) as DataPlanoAcao, PlanoAcao, rf.NomeUsuario as NomeUsuarioFechamento, Convert(varchar(10),DataFechamento,103) as DataFechamento, Verificacao from Rap r left join RapProblema rp on r.Id = CodigoRap left join RacPlanoAcao rpa on r.Id = CodigoRap left join RacFechamento rf on r.Id = CodigoRap Where r.Id = " + Id;
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                System.Data.DataTable dt = new System.Data.DataTable();
                da.Fill(dt);
                int i = 0;
                foreach (System.Data.DataRow dr in dt.Rows)
                {
                    lblDatAber.Text = dr["DataAbertura"].ToString();
                    lblRespAber.Text = dr["ResponsavelAbertura"].ToString();
                    status = dr["Status"].ToString();
                    mod = dr["Modalidade"].ToString();
                    txtHist.Text = dr["HistoricoSugestao"].ToString();
                    txtRespAnalCrit.Text = dr["ResponsavelAnaliseRecomendacoes"].ToString();
                    txtAnalCrit.Text = dr["AnaliseRecomendacoes"].ToString();
                    txtPro.Text = dr["Problema"].ToString();
                    if (dr["Problema"].ToString() != "")
                    {
                        tblRespCad.Visible = true;
                        tblDatCad.Visible = true;
                    }
                    lblRespPro.Text = dr["ResponsavelAbertura"].ToString();
                    if (dr["DataProblema"].ToString() == "")
                    {
                        lblDataPro.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    }
                    else
                    {
                        lblDataPro.Text = dr["DataProblema"].ToString();
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
                        mod = "NC Potencial";
                    }
                    else if (mod == "2")
                    {
                        mod = "Observação de Auditoria";
                    }
                    else if (mod == "3")
                    {
                        mod = "Oportunidade de Melhoria";
                    }
                    else
                    {
                        mod = "Sugestão";
                    }

                    lblMod.Text = mod;

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

                    lblStatusRap.Text = status;

                    i++;
                }
                conn.Close();
            }
            else
            {
                lblMsgHist.Text = "";
                lblMsgPlanAcao.Text = "";
                lblMsgAnalCrit.Text = "";
                lblMsgVeriFecha.Text = "";
                lblMsgPro.Text = "";
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
            if (txtHist.Text == "")
            {
                lblMsgHist.Text = "Preencha Histórico!";
                return;
            }

            lblMsgHist.Text = "";
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=qualidade;Integrated Security=True");
            string sql = "Update Rap Set HistoricoSugestao=@HistoricoSugestao Where Id = " + Id;
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.Parameters.Add(new SqlParameter("@HistoricoSugestao", txtHist.Text));
            lblMsgHist.Text = "Histórico alterado com sucesso!";
            conn.Open();
            comando.ExecuteNonQuery();
            conn.Close();
        }

        protected void btnSalvarAnalCrit_Click(object sender, EventArgs e)
        {
            if (txtRespAnalCrit.Text == "")
            {
                lblMsgAnalCrit.Text = "Preencha responsável!";
                return;
            }

            if (txtAnalCrit.Text == "")
            {
                lblMsgAnalCrit.Text = "Preencha análise crítica!";
                return;
            }

            lblMsgAnalCrit.Text = "";
            SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=qualidade;Integrated Security=True");
            string sql = "Update Rap Set ResponsavelAnaliseRecomendacoes=@ResponsavelAnaliseRecomendacoes, AnaliseRecomendacoes=@AnaliseRecomendacoes Where Id = " + Id;
            SqlCommand comando = new SqlCommand(sql, conn);
            comando.Parameters.Add(new SqlParameter("@ResponsavelAnaliseRecomendacoes", txtRespAnalCrit.Text));
            comando.Parameters.Add(new SqlParameter("@AnaliseRecomendacoes", txtAnalCrit.Text));
            lblMsgAnalCrit.Text = "Análise Crítica/Recomendações alterado com sucesso!";
            conn.Open();
            comando.ExecuteNonQuery();
            conn.Close();
            tblStatus.Visible = true;
        }

        protected void btnSalvarPro_Click(object sender, EventArgs e)
        {
            if (txtPro.Text == "")
            {
                lblMsgPro.Text = "Preencha problema!";
                return;
            }

            String codigoRac = "";
            lblMsgPro.Text = "";

            SqlConnection conn = new SqlConnection(@"Data Source=localhost;Initial Catalog=qualidade;Integrated Security=True");
            string sqlSelect = "Select CodigoRap from RapProblema Where CodigoRap = " + Id;
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                codigoRac = dr["CodigoRap"].ToString();
                i++;
            }

            if (codigoRac == "")
            {
                string sql = "INSERT INTO RapProblema(CodigoRap, Problema, NomeUsuario, DataProblema) VALUES (@CodigoRap, @Problema, @NomeUsuario, @DataProblema)";

                SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@CodigoRap", Id));
                comando.Parameters.Add(new SqlParameter("@Problema", txtPro.Text));
                comando.Parameters.Add(new SqlParameter("@NomeUsuario", lblRespPro.Text));
                comando.Parameters.Add(new SqlParameter("@DataProblema", lblDataPro.Text));
                lblMsgPro.Text = "Problema potencial incluído com sucesso!";
                conn.Open();
                comando.ExecuteNonQuery();
                conn.Close();
                tblDatCad.Visible = true;
                tblRespCad.Visible = true;
            }
            else
            {
                string sqlUpdate = "Update RapProblema Set Problema=@Problema Where CodigoRap = " + Id;
                SqlCommand comandoUpdate = new SqlCommand(sqlUpdate, conn);
                comandoUpdate.Parameters.Add(new SqlParameter("@Problema", txtPro.Text));
                lblMsgPro.Text = "Problema potencial alterado com sucesso!";
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
            string sqlSelect = "Select CodigoRap from RapPlanoAcao Where CodigoRap = " + Id;
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                codigoRac = dr["CodigoRap"].ToString();
                i++;
            }

            if (codigoRac == "")
            {
                string sql = "INSERT INTO RapPlanoAcao(CodigoRap, PlanoAcao, NomeUsuario, DataPlanoAcao) VALUES (@CodigoRap, @PlanoAcao, @NomeUsuario, @DataPlanoAcao)";

                SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@CodigoRap", Id));
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
                string sqlUpdate = "Update RapPlanoAcao Set PlanoAcao=@PlanoAcao, DataPlanoAcao=@DataPlanoAcao, NomeUsuario=@NomeUsuario Where CodigoRap = " + Id;
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
            string sqlSelect = "Select CodigoRap from RapFechamento Where CodigoRap = " + Id;
            SqlDataAdapter da = new SqlDataAdapter(sqlSelect, conn);
            System.Data.DataTable dt = new System.Data.DataTable();
            da.Fill(dt);
            int i = 0;
            foreach (System.Data.DataRow dr in dt.Rows)
            {
                codigoRac = dr["CodigoRap"].ToString();
                i++;
            }

            if (codigoRac == "")
            {
                string sql = "INSERT INTO RapFechamento(CodigoRap, Verificacao, NomeUsuario, DataFechamento) VALUES (@CodigoRap, @Verificacao, @NomeUsuario, @DataFechamento)";

                SqlCommand comando = new SqlCommand(sql, conn);
                comando.Parameters.Add(new SqlParameter("@CodigoRap", Id));
                comando.Parameters.Add(new SqlParameter("@Verificacao", txtVeriFecha.Text));
                comando.Parameters.Add(new SqlParameter("@NomeUsuario", lblAuditorVeriFecha.Text));
                comando.Parameters.Add(new SqlParameter("@DataFechamento", lblDataVeriFecha.Text));
                lblMsgVeriFecha.Text = "Verificacão/Fechamento incluído com sucesso!";
                conn.Open();
                comando.ExecuteNonQuery();
                tblAuditorVeriFecha.Visible = true;
                tblDataVeriFecha.Visible = true;

                string sqlUpdate = "Update Rap Set Status=@Status Where Id = " + Id;
                SqlCommand comandoUpdate = new SqlCommand(sqlUpdate, conn);
                comandoUpdate.Parameters.Add(new SqlParameter("@Status", 2));
                comandoUpdate.ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                string sqlUpdate = "Update RapFechamento Set Verificacao=@Verificacao Where CodigoRap = " + Id;
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