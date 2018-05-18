<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.master" CodeBehind="frmGerRap.aspx.cs" Inherits="WebSGQ.frmGerRap" %>

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
            width: 880px;
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
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="accountInfo" style="width: 1170px; margin-bottom: 0px">
        <h2 class="titulo">
            Gerência de RAP
        </h2>
        <fieldset class="box" style="color: #87929f ; margin-bottom: 0px">
            <table>
                <tr style="width: 700px">
                    <td style="width: 100px">
                        <asp:Label ID="lbldataber" runat="server" class="label">N° RAP</asp:Label>
                    </td>
                    <td style="width: 100px">
                        <asp:TextBox ID="txtnumrac" runat="server" class="textBox" Width="100px"></asp:TextBox>
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
                            <asp:ListItem Text="Todos" Value="0" />
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
                        <asp:Label ID="Label2" class="label" runat="server">Aberto Por</asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:DropDownList ID="cborespaber" Class="textBox" Width="200px" runat="server">
                            <asp:ListItem Text="Todos" Value="0" />
                            <asp:ListItem Text="David Holanda" Value="1" />
                            <asp:ListItem Text="Francisco Pegado" Value="2" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
            <table>
                <tr style="width: 700px">
                    <td style="width: 100px">
                        <asp:Label ID="Label1" class="label" runat="server">Status</asp:Label>
                    </td>
                    <td style="width: 300px">
                        <asp:DropDownList ID="cbostatus" Class="textBox" Width="200px" runat="server">
                            <asp:ListItem Text="Todos" Value="0" />
                            <asp:ListItem Text="Aberto" Value="1" />
                            <asp:ListItem Text="Fechado" Value="2" />
                            <asp:ListItem Text="Cancelado" Value="3" />
                        </asp:DropDownList>
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
                <asp:Button ID="btnLimpar" runat="server" CommandName="MoveNext" Text="Limpar" class="botao"
                    OnClick="btnLimpar_Click" />
                <asp:Button ID="btnCon" runat="server" CommandName="MoveNext" Text="Filtrar" class="botao"
                    OnClick="btnCon_Click" />
            </p>
        </fieldset>
    </div>
    <div id="divGrid" runat="server" visible="true">
        <fieldset class="box" style="color: #87929f; margin-bottom: 0px">
            <table id="tblGrdData" runat="server" visible="true">
                <tr style="width: 900px">
                    <td style="width: 100px">
                        <asp:GridView ID="grdRap" runat="server" AllowPaging="True" AllowSorting="True" CellPadding="13"
                            Width="830px" OnRowDataBound="grdRap_RowDataBound" PageSize="100" ForeColor="#333333"
                            GridLines="None" Font-Names="Verdana" Font-Size="10px" 
                            onselectedindexchanged="grdRap_SelectedIndexChanged">
                            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                            <Columns>
                                <asp:TemplateField ShowHeader="False">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                            CommandName="Select" Text="Selecione"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <EditRowStyle BackColor="#999999" />
                            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Right" Font-Bold="True" />
                            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>

