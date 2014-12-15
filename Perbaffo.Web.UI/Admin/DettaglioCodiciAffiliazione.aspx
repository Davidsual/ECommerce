<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PerbaffoMaster.Master"
    CodeBehind="DettaglioCodiciAffiliazione.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.DettaglioCodiciAffiliazione" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="height: 688px; overflow: hidden;">
        <table border="0" width="98%" style="font-family: Verdana; font-size: 16pt; font-weight: bold">
            <tr>
                <td rowspan="2" width="80" height="64" align="center">
                    <img border="0" src="img/prodotti.gif" width="48" height="48">
                </td>
                <td>
                    <table border="0" width="100%" style="font-family: Verdana; font-size: 16pt; font-weight: bold;
                        border-bottom: 1px solid #D6DFF5; padding: 0">
                        <tr>
                            <td align="left" valign="middle" style="color: #3366CC">
                                Gestione Codice affiliazione Inserisci/Modifica/Cancella
                            </td>
                            <td align="right" valign="top">
                                <table border="0" style="padding: 0">
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:LinkButton ID="returnLink" runat="server" Style="font-size: 8pt; font-weight: normal"
                                                OnClick="returnLink_Click">Livello superiore</asp:LinkButton>
                                        </td>
                                        <td width="22">
                                            <asp:LinkButton ID="returnLink2" runat="server" OnClick="returnLink_Click"> <img border="0" src="img/up2.gif" width="22" height="22" alt="Livello superiore"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <asp:UpdatePanel ID="updPnlDettagli" runat="server">
            <ContentTemplate>
                <table border="0" cellpadding="1" cellspacing="2" align="center" style="font-size: 10px;
                    width: 750px; font-family: Verdana; font-weight: bold">
                    <tr>
                        <td width="30%" align="right">
                            Sito:
                        </td>
                        <td width="70%" align="left">
                            <asp:TextBox ID="txtSito" runat="server" Width="300px"  Text=""></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSito"
                                Text="!" ErrorMessage="Sito obbligratorio" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Codice affiliazione:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtCodiceAffiliazione" runat="server" Width="300px"  Text=""></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCodiceAffiliazione"
                                Text="!" ErrorMessage="Codice affiliazione obbligatorio" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                                                         
                    <tr>
                        <td align="right">
                            Data Inserimento:
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDataInserimento" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>                                      
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table border="0" cellpadding="1" cellspacing="2" align="center" style="font-size: 10px;
            width: 750px; font-family: Verdana; font-weight: bold">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSend" runat="server" Text="Salva" OnClick="btnSend_Click" ValidationGroup="Prodotto" />
                </td>
                <td align="left">
                    &nbsp;<asp:Button ID="btnCancella" runat="server" Text="Cancella" 
                        OnClick="btnCancella_Click" BackColor="Red" ForeColor="White" OnClientClick="return confirm('Sei sicuro di voler cancellare questo codice affiliazione?');" />
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="Prodotto" />
    </div>
</asp:Content>
