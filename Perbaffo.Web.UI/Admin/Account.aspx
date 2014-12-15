<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PerbaffoMaster.Master"
    CodeBehind="Account.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.Account" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%" style="font-family: Verdana; font-size: 16pt; font-weight: bold">
        <tr>
            <td rowspan="2" width="80" height="64" align="center">
                <img border="0" src="img/admin.gif" width="48" height="48"/>
            </td>
            <td>
                <table border="0" width="100%" style="font-family: Verdana; font-size: 16pt; font-weight: bold;
                    border-bottom: 1px solid #D6DFF5; padding: 0">
                    <tr>
                        <td align="left" valign="middle" style="color: #3366CC">
                            Gestione account - Modifica
                        </td>
                        <td align="right" valign="top">
                            <table border="0" style="padding: 0">
                                <tr>
                                    <td align="right" valign="top">
                                        <a href="HomePage.aspx" style="font-size: 8pt; font-weight: normal">Livello superiore</a>
                                    </td>
                                    <td width="22">
                                        <a href="HomePage.aspx">
                                            <img border="0" src="img/up2.gif" width="22" height="22" alt="Livello superiore"></a>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="height: 10;">
                &nbsp;
            </td>
        </tr>
    </table>
    <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
        <tr>
            <td align="right">
                Username:
            </td>
            <td align="left">
                <asp:TextBox ID="txtUsername" runat="server" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsername"
                    ErrorMessage="Popolare Username" ToolTip="Popolare Username" ValidationGroup="LOGIN">!</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                Password:
            </td>
            <td align="left">
                <asp:TextBox ID="txtPassword" runat="server" MaxLength="12" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword"
                    ErrorMessage="Popolare Password" ToolTip="Popolare Password" ValidationGroup="LOGIN">!</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                Ripeti Password:
            </td>
            <td align="left">
                <asp:TextBox ID="txtRePassword" runat="server" MaxLength="12" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRePassword"
                    ErrorMessage="Popolare Ridigitazione Password" ToolTip="Popolare Ridigitazione Password"
                    ValidationGroup="LOGIN">!</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                    ControlToValidate="txtRePassword" ErrorMessage="Le due password devono coincidere"
                    ValidationGroup="LOGIN" ToolTip="Le due password devono coincidere">!</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnLogin" runat="server" Text="Cambia" OnClick="btnLogin_Click" ValidationGroup="LOGIN" />
            </td>
            <td align="left">
                &nbsp;<asp:Button ID="btnAnnulla" runat="server" Text="Annulla" OnClick="btnAnnulla_Click" />
            </td>
        </tr>
    </table>
    <table align="center" bordercolor="#FFFFFF" cellpadding="2" style="font-size: 10px;
        font-family: Verdana; border: 1px solid #D6DFF5">
        <tr>
            <td align="left">
                <b>Attenzione</b> = La username e la password devono essere comprese tra 8 e 15
                caratteri, e possono contenere solo numeri o lettere.<br>
                Il sistema inoltre fa differenza tra lettere minuscole e maiuscole.<asp:ValidationSummary
                    ID="ValidationSummary1" runat="server" ShowMessageBox="True" ShowSummary="False"
                    ValidationGroup="LOGIN" />
                <br>
            </td>
        </tr>
    </table>
</asp:Content>
