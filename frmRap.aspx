<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="frmRap.aspx.cs" Inherits="WebSGQ.frmRap" %>

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
            font-size: 12px;
            color: #fff;
            background-image: url("imagens/background_btn_laranja.png");
            height: 27px;
            float: right;
            position: relative;
            cursor: pointer;
            border-top-left-radius: 2px;
            border-top-right-radius: 2px;
            border-botton-right-radius: 2px;
            border-botton-left-radius: 2px;
            border-top-color: #f47436;
            border-right-color: #f47436;
            border-left-color: #f47436;
            border-bottom-color: #f47436;
            border-top-width: 0px;
            border-right-width: 0px;
            border-left-width: 0px;
            border-bottom-width: 0px;
            border-top-style: solid;
            border-bottom-style: solid;
            border-left-style: solid;
            border-right-style: solid;
            padding-top: 0px;
            padding-right: 10px;
            padding-bottom: opx;
            padding-left: 10px;
            margin-top: opx;
            margin-right: 5px;
            margin-bottom: 0px;
            margin-left: 5px;
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
            width: 718px;
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
        .header
        {
            color: #333;
            width: 100%;
            float: left;
            height: 93px;
            background-image: url(../images/background_header.png);
            background-repeat: repeat-x;
        }
    </style>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="accountInfo" style="width: 770px; margin-bottom: 0px;margin: auto">
        <h2 class="titulo">
            Abrir RAP
        </h2>
        <fieldset class="box" style="color: #87929f; margin-bottom: 0px">
            <table>
                <tr style="width: 700px">
                    <td style="width: 100px">
                        <asp:Label ID="lblrespaber" runat="server" class="label">Resp. Abertura</asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:Label ID="lblrespaber1" runat="server" class="label">Francisco Pegado</asp:Label>
                    </td>
                </tr>
            </table>
            <table>
                <tr style="width: 700px">
                    <td style="width: 100px">
                        <asp:Label ID="lbldataber" runat="server" class="label" AssociatedControlID="txtdataber">Data Abertura</asp:Label>
                    </td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtDatAber" runat="server" class="textBox" Width="100px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" TargetControlID="txtdataber" Animated="true"
                            Format="dd/MM/yyyy" runat="server"/>
                    </td>
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
                        </asp:ToolkitScriptManager>
                </tr>
            </table>
            <table>
                <tr style="width: 700px">
                    <td style="width: 100px">
                        <asp:Label ID="lblfon" class="label" runat="server">Modalidade</asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:DropDownList ID="cboMod" Class="textBox" Width="200px" runat="server">
                            <asp:ListItem Text="Selecione..." Value="0" />
                            <asp:ListItem Text="NC Potencial" Value="1" />
                            <asp:ListItem Text="Observação de Auditoria" Value="2" />
                            <asp:ListItem Text="Oportunidade de Melhoria" Value="3" />
                            <asp:ListItem Text="Sugestão" Value="4" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table>
                <tr style="width: 700px">
                    <td style="width: 100px">
                        <asp:Label ID="lblhis" runat="server" class="label">Histórico/Sugestão</asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtHistSuge" class="textBox" TextMode="MultiLine" runat="server" Rows="4" Width="554px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table>
                <tr style="width: 700px">
                    <td style="width: 100px">
                        <asp:Label ID="Label1" class="label" runat="server">Justificativa</asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:DropDownList ID="cboJust" Class="textBox" Width="200px" runat="server">
                            <asp:ListItem Text="Selecione..." Value="0" />
                            <asp:ListItem Text="Aprovado" Value="1" />
                            <asp:ListItem Text="Reprovado" Value="2" />
                            <asp:ListItem Text="Manter Pendente" Value="3" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table>
                <tr style="width: 700px">
                    <td style="width: 100px">
                        <asp:Label ID="lbldis" runat="server" class="label">Análise Crítica/Recomendações</asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtAnaRec" class="textBox" TextMode="MultiLine" runat="server" Rows="4" Width="554px"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table>
                <tr style="width: 700px">
                    <td style="width: 100px">
                        <asp:Label ID="lblrespdis" class="label" runat="server">Responsável</asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:TextBox ID="txtResp" runat="server" AutoPostBack="true" CssClass="textBox" Width="300px"></asp:TextBox>
                        <asp:AutoCompleteExtender ID="AutoCompleteExtender1" MinimumPrefixLength="1" TargetControlID="txtResp"
                            runat="server" ServiceMethod="GetCompletionListFuncionario" UseContextKey="True" />
                    </td>
                </tr>
            </table>
            <table>
                <tr style="width: 700px; text-align: center">
                    <td style="text-align: center" class="style1">
                        <asp:Label ID="lblMsg" ForeColor="Red" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            <p class="submitButton">
                <asp:Button ID="btnLimpar" runat="server" CommandName="MoveNext" Text="Limpar"
                    class="botao" onclick="btnLimpar_Click" />
                <asp:Button ID="btnInc" runat="server" CommandName="MoveNext" Text="Incluir"
                    class="botao" onclick="btnInc_Click"/>
            </p>
        </fieldset>
    </div>
</asp:Content>

