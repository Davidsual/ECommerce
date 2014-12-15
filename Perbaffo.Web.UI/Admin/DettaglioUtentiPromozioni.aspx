<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PerbaffoMaster.Master"
    CodeBehind="DettaglioUtentiPromozioni.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.DettaglioUtentiPromozioni" %>
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
                                Gestione Utente Promozioni Inserisci/Modifica/Cancella
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
                            Utente:
                        </td>
                        <td width="70%" align="left">
                            <asp:DropDownList ID="ddlUtenti" runat="server" Width="400px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlUtenti"
                                Text="!" ErrorMessage="Utente obbligatorio" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Sconto Euro:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtScontoEuro" runat="server" Width="100px" MaxLength="8" Text="0.00"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="height: 26px">
                            Sconto Perc:
                        </td>
                        <td align="left" style="height: 26px">
                            <asp:TextBox ID="txtScontoPerc" runat="server" Width="100px" MaxLength="2" Text="0"></asp:TextBox>
                        </td>
                    </tr>                    
                    <tr>
                        <td align="right">
                            Data Scadenza:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDataScadenza" runat="server" MaxLength="10" Text="" Width="100px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtDataScadenza"
                                Text="!" ErrorMessage="Data Scadenza obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Numero Volte:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtNumeroVolte" runat="server" MaxLength="10" Text="0" Width="100px"></asp:TextBox>
                        </td>
                    </tr>                    
                    <tr>
                        <td align="right">
                            Descrizione:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtDescrPromozione" runat="server" MaxLength="299" Text="" Width="400px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDescrPromozione"
                                Text="!" ErrorMessage="Descrizione promozione obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                    
                    <tr>
                        <td align="right">
                            Minimo d'ordine:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMinimoOrdine" runat="server" Width="100px" MaxLength="8" Text="0.00"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMinimoOrdine"
                                Text="!" ErrorMessage="Minimo d'ordine obbligatorio" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Attivo:
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="chkAttivo" Checked="true" runat="server" />
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
                    &nbsp;<asp:Button ID="btnCancella" runat="server" Text="Cancella" OnClick="btnCancella_Click" />
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="Prodotto" />
    </div>
</asp:Content>
