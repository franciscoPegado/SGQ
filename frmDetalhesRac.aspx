<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="frmDetalhesRac.aspx.cs"
    Inherits="WebSGQ.frmDetalhesRac" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 855px;
        }
    </style>
    <style type="text/css">
        .botao
        {
            border: 0px solid #f47436;
            font-size: 12px;
            color: #fff;
            background-image: url('imagens/background_btn_laranja.png');
            height: 27px;
            float: right;
            position: relative;
            cursor: pointer;
            border-top-left-radius: 2px;
            border-top-right-radius: 2px;
            border-botton-right-radius: 2px;
            border-botton-left-radius: 2px;
            padding-top: 0px;
            padding-right: 10px;
            padding-bottom: opx;
            padding-left: 10px;
            margin-top: opx;
            margin-right: 5px;
            margin-bottom: 0px;
            margin-left: 5px;
            top: 0px;
            left: 0px;
        }
    </style>
    <style type="text/css">
        .label
        {
            width: 110px;
            text-align: right;
            padding-right: 10px;
            float: left;
            display: block;
            font-family: Calibri;
        }
    </style>
    <style type="text/css">
        .textBox
        {
            color: #bababa;
            padding-top: 5px;
            padding-right: 5px;
            padding-bottom: 5px;
            padding-left: 5px;
            border-top-color: #efefef;
            border-right-color: #efefef;
            border-bottom-color: #efefef;
            border-left-color: #efefef;
            border-top-width: 1px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 1px;
            border-top-style: solid;
            border-right-style: solid;
            border-left-style: solid;
            border-bottom-style: solid;
            font-size: 12px;
            background-image: url("imagens/background_input_text_busca_rapida.png");
        }
    </style>
    <style type="text/css">
        .textBox
        {
            color: #bababa;
            padding-top: 5px;
            padding-right: 5px;
            padding-bottom: 5px;
            padding-left: 5px;
            border-top-color: #efefef;
            border-right-color: #efefef;
            border-bottom-color: #efefef;
            border-left-color: #efefef;
            border-top-width: 1px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 1px;
            border-top-style: solid;
            border-right-style: solid;
            border-left-style: solid;
            border-bottom-style: solid;
            font-size: 12px;
            background-image: url("imagens/background_input_text_busca_rapida.png");
        }
    </style>
    <style type="text/css">
        .dropDownList
        {
            color: #bababa;
            padding-top: 5px;
            padding-right: 5px;
            padding-bottom: 5px;
            padding-left: 5px;
            border-top-color: #efefef;
            border-right-color: #efefef;
            border-bottom-color: #efefef;
            border-left-color: #efefef;
            border-top-width: 1px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 1px;
            border-top-style: solid;
            border-right-style: solid;
            border-left-style: solid;
            border-bottom-style: solid;
            font-size: 12px;
            background-image: url("imagens/background_input_text_busca_rapida.png");
        }
    </style>
    <style type="text/css">
        .lblMsg
        {
            font-family: Calibri;
        }
    </style>
    <style type="text/css">
        .box
        {
            width: 830px;
            color: #87929f;
            padding-top: 20px;
            padding-right: 20px;
            padding-bottom: 20px;
            padding-left: 20px;
            margin-bottom: 20px;
            border-top-color: #efeff1;
            border-right-color: #efeff1;
            border-bottom-color: #efeff1;
            border-left-color: #efeff1;
            border-top-width: 1px;
            border-right-width: 1px;
            border-bottom-width: 1px;
            border-left-width: 1px;
            border-top-style: solid;
            border-right-style: solid;
            border-left-style: solid;
            border-bottom-style: solid;
            float: left;
            position: relative;
        }
    </style>
    <style type="text/css">
        .titulo
        {
            color: #0057a8;
            padding-top: 0px;
            padding-right: 0px;
            padding-bottom: 0px;
            padding-left: 0px;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            margin-left: 0px;
            font-size: 27px;
            font-weight: normal;
            font-family: Calibri;
            height: 20px;
        }
    </style>
    <style type="text/css">
        .grid
        {
            text-align: left;
            color: #fff;
            padding-top: 5px;
            padding-right: 0px;
            padding-bottom: 5px;
            padding-left: 10px;
            font-size: 12px;
            font-weight: normal;
            background-color: rgb(81, 134, 183);
            font-family: Calibri;
            margin-top: 0px;
            margin-right: 0px;
            margin-bottom: 0px;
            margin-left: 0px;
        }
    </style>
    <style type="text/css">
        .BackColorTab
        {
            color: #4682b4;
            font-family: Calibri;
            font-size: 14px;
            font-weight: bold;
            background-color: #ffffff;
            margin-left: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div>
        <h2 class="titulo">
            RAC
        </h2>
        <fieldset class="box" style="color: #87929f; margin-bottom: 0px">
            <asp:TabContainer ID="TabContainer1" runat="server" Width="800px" AutoPostBack="true">
                <asp:TabPanel runat="server" HeaderText="Detalhes do RAC">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label111" runat="server" class="label">Data Abertura:</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lbldataber" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" class="label">Resp. Abertura:</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblrespaber" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" class="label" runat="server">Status:</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblstatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="lblfon" class="label" runat="server">Modalidade:</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblmod" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Histórico do Problema" Enabled="true"
                    ScrollBars="Auto" OnDemandMode="Once">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" class="label">Histórico:</asp:Label>
                                    <asp:TextBox ID="txthist" TextMode="MultiLine" class="textBox" runat="server" Rows="10"
                                        Width="550px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr style="width: 700px; text-align: center">
                                <td style="text-align: center" class="style1">
                                    <asp:Label ID="lblMsgHist" ForeColor="Red" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <p class="submitButton">
                            <asp:Button ID="btnSalvarHist" runat="server" CommandName="MoveNext" Text="Salvar"
                                class="botao" OnClick="btnSalvarHist_Click" />
                        </p>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Disposição" Enabled="true"
                    ScrollBars="Auto" OnDemandMode="Once">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" class="label">Responsável:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtrespdis" runat="server" class="textBox" AutoPostBack="true" Width="300px"></asp:TextBox>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender1" MinimumPrefixLength="1" TargetControlID="txtrespdis"
                                        runat="server" ServiceMethod="GetCompletionListFuncionario" UseContextKey="True" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" class="label">Data:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtdatadis" class="textBox" runat="server" Width="80px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" TargetControlID="txtdatadis" Animated="true"
                                        Format="dd/MM/yyyy" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" class="label">Disposição:</asp:Label>
                                    <asp:TextBox ID="txtdis" TextMode="MultiLine" class="textBox" runat="server" Rows="10"
                                        Width="550px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr style="width: 700px; text-align: center">
                                <td style="text-align: center" class="style1">
                                    <asp:Label ID="lblmsgdispo" ForeColor="Red" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <p class="submitButton">
                            <asp:Button ID="btnSalvarDisp" runat="server" CommandName="MoveNext" Text="Salvar"
                                class="botao" OnClick="btnSalvarDisp_Click" />
                        </p>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Identificação da Causa" Enabled="true"
                    ScrollBars="Auto" OnDemandMode="Once">
                    <ContentTemplate>
                        <table id="tblRespCad" runat="server" visible="false">
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" class="label">Resp. Cadastro:</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblRespCausa" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tblDatCad" runat="server" visible="false">
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" class="label">Data Cadastro:</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDataCausa" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" class="label">Causa:</asp:Label>
                                    <asp:TextBox ID="txtCausa" TextMode="MultiLine" class="textBox" runat="server" Rows="10"
                                        Width="550px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr style="width: 700px; text-align: center">
                                <td style="text-align: center" class="style1">
                                    <asp:Label ID="lblMsgCausa" ForeColor="Red" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <p class="submitButton">
                            <asp:Button ID="btnSalvarCausa" runat="server" CommandName="MoveNext" Text="Salvar"
                                class="botao" OnClick="btnSalvarCausa_Click" />
                        </p>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Plano de Ação" Enabled="true"
                    ScrollBars="Auto" OnDemandMode="Once">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" class="label">Responsável:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRespPlan" runat="server" class="textBox" AutoPostBack="true"
                                        Width="300px"></asp:TextBox>
                                    <asp:AutoCompleteExtender ID="AutoCompleteExtender4" MinimumPrefixLength="1" TargetControlID="txtRespPlan"
                                        runat="server" ServiceMethod="GetCompletionListFuncionario" UseContextKey="True" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label13" runat="server" class="label">Data Conclusão:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDatConPlan" class="textBox" runat="server" Width="80px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDatConPlan" Animated="true"
                                        Format="dd/MM/yyyy" runat="server" />
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label14" runat="server" class="label">Plano de Ação:</asp:Label>
                                    <asp:TextBox ID="txtPlanAção" TextMode="MultiLine" class="textBox" runat="server"
                                        Rows="10" Width="550px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr style="width: 700px; text-align: center">
                                <td style="text-align: center" class="style1">
                                    <asp:Label ID="lblMsgPlanAcao" ForeColor="Red" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <p class="submitButton">
                            <asp:Button ID="Button1" runat="server" CommandName="MoveNext" Text="Salvar" class="botao"
                                OnClick="btnSalvarPlanAcao_Click" />
                        </p>
                    </ContentTemplate>
                </asp:TabPanel>
                <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Verificacão/Fechamento" Enabled="true"
                    ScrollBars="Auto" OnDemandMode="Once">
                    <ContentTemplate>
                        <table id="tblAuditorVeriFecha" runat="server" visible="false">
                            <tr>
                                <td>
                                    <asp:Label ID="Label18" runat="server" class="label">RD/Auditor:</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblAuditorVeriFecha" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table id="tblDataVeriFecha" runat="server" visible="false">
                            <tr>
                                <td>
                                    <asp:Label ID="Label20" runat="server" class="label">Data:</asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="lblDataVeriFecha" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label16" runat="server" class="label">Verificacão:</asp:Label>
                                    <asp:TextBox ID="txtVeriFecha" TextMode="MultiLine" class="textBox" runat="server"
                                        Rows="10" Width="550px"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <table>
                            <tr style="width: 700px; text-align: center">
                                <td style="text-align: center" class="style1">
                                    <asp:Label ID="lblMsgVeriFecha" ForeColor="Red" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                        <p class="submitButton">
                            <asp:Button ID="Button2" runat="server" CommandName="MoveNext" Text="Salvar" class="botao"
                                OnClick="btnSalvarVeriFecha_Click" />
                        </p>
                    </ContentTemplate>
                </asp:TabPanel>
            </asp:TabContainer>
        </fieldset>
        <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </asp:ToolkitScriptManager>
    </div>
</asp:Content>
