<%@ Page Title="" Language="C#" MasterPageFile="PerbaffoMaster.Master" ValidateRequest="false"
    AutoEventWireup="true" CodeBehind="DettaglioProdotto.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.DettaglioProdotto" %>

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
                                Gestione prodotti - Creazione/Modifica
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
            <tr>
                <td height="10">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="font-size: 12px;">
                        <tr>
                            <td align="center" style="width: 16%">
                                <asp:LinkButton ID="btnCategoria" runat="server" CommandName="CATEGORIA" OnClick="lnkAction_Click">Categoria</asp:LinkButton>
                            </td>
                            <td align="center" style="width: 16%">
                                <asp:LinkButton ID="btnPhoto" runat="server" CommandName="PHOTO" OnClick="lnkAction_Click">Foto</asp:LinkButton>
                            </td>
                            <td align="center" style="width: 16%">
                                <asp:LinkButton ID="btnPhotoGallery" runat="server" CommandName="PHOTOGALLERY" OnClick="lnkAction_Click">Fotogallery</asp:LinkButton>
                            </td>
                            <td align="center" style="width: 16%">
                                <asp:LinkButton ID="btnTaglia" runat="server" CommandName="TAGLIA" OnClick="lnkAction_Click">Taglia</asp:LinkButton>
                            </td>
                            <td align="center" style="width: 16%">
                                <asp:LinkButton ID="btnColori" runat="server" CommandName="COLORE" OnClick="lnkAction_Click">Variazioni</asp:LinkButton>
                            </td>
                            <td align="center" style="width: 16%">
                                <asp:LinkButton ID="btnRelazioni" runat="server" CommandName="RELAZIONE" OnClick="lnkAction_Click">Prodotti correlati</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <asp:UpdatePanel ID="updPnlTotale" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table border="0" cellpadding="1" cellspacing="2" align="center" style="font-size: 10px;
                    width: 750px; font-family: Verdana; font-weight: bold">
                    <tr>
                        <td width="25%" align="right">
                            Nome prodotto:
                        </td>
                        <td width="25%" align="left">
                            <asp:TextBox ID="txtNome" runat="server" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome"
                                Text="!"  ErrorMessage="Nome prodotto obbligatorio" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                        <td width="25%" align="right">
                            Codice prodotto:
                        </td>
                        <td width="25%" align="left">
                            <asp:TextBox ID="txtCodice" runat="server" Width="150px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCodice"
                               Text="!" ErrorMessage="Codice prodotto obbligatorio" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Unità di misura:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtUnita" runat="server">1</asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUnita"
                                Text="!" ErrorMessage="Unità di misura obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                            Aliquota iva:
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlIva" runat="server" Width="126px">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="ddlIva"
                               Text="!" ErrorMessage="Aliquota iva obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Prezzo(€):
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPrezzo" runat="server" Text="0,00"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPrezzo"
                               Text="!" ErrorMessage="Prezzo obbligatorio" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                            Sconto(%):
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtSconto" runat="server" Text="0"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Sconto(€):
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtScontoEuro" runat="server" Text="0,00"></asp:TextBox>
                        </td>
                        <td align="right">
                            Totale Prodotto:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTotale" runat="server" Text="da Calcolare" ReadOnly="true" Width="100px"></asp:TextBox>
                            <asp:Button ID="btnCalcola" runat="server" Text="Calcola" OnClick="btnCalcola_Click"
                                Height="20px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Giacenza:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtGiacenza" runat="server" Text="10"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtGiacenza"
                               Text="!" ErrorMessage="Giacenza obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                            Livello di riordino:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtRiordino" runat="server" Text="1"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtRiordino"
                               Text="!" ErrorMessage="Livello di riordino obbligatorio" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Taglia
                        </td>
                        <td align="left" colspan="2">
                            <asp:TextBox ID="txtDescrTaglia" runat="server" Width="200px"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td align="right">
                            E' un prodotto omaggio
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="chkIsOmaggio" runat="server" />
                        </td>
                        <td align="right">
                            Prezzo minimo omaggio
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPrezzoMinimoOmaggio" runat="server">0,00</asp:TextBox>
                        </td>                        
                    </tr>
                    <tr>
                        <td align="left" colspan="4">
                            Keywords parole separate con &quot;,&quot; (100)<br/>
                            <asp:TextBox ID="txtKeyWords" runat="server" Width="599px" MaxLength="100"></asp:TextBox>
                            <asp:Button ID="btnKeyWord" runat="server" Height="20px" OnClick="btnKeyWord_Click"
                                Text="Calcola" />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4">
                            Descrizione:<br/>
                            <textarea id="descrizione" name="descrizione" rows="10" style="width: 700px; height: 250"
                                runat="server"></textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="descrizione"
                               Text="!" ErrorMessage="descrizione prodotto obbligatorio" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>                                
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Prodotto Attivo
                        </td>
                        <td align="left">
                            <asp:CheckBox ID="chkAttivo" runat="server" Checked="True" />
                        </td>
                        <td align="right">
                            Prodotto inserito il
                        </td>
                        <td align="left">
                            <asp:Label ID="lblDataInserimento" runat="server"></asp:Label>
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
                    &nbsp;
                    <asp:Button ID="btnSendAsNew" runat="server" Text="Salva come Nuovo"  
                        ValidationGroup="Prodotto" BackColor="#33CC33" onclick="btnSendAsNew_Click" />
                </td>
                <td align="left">
                    &nbsp;<asp:Button ID="btnCancella" runat="server" Text="Cancella" OnClick="btnCancella_Click" />
                    <asp:Button ID="btnDupplica" runat="server" BackColor="#FFFF99" 
                        onclick="btnDupplica_Click" Text="Duplica" />
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="Prodotto" />
    </div>
</asp:Content>
