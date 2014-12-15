<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pannello-Utente.aspx.cs"
    Inherits="Perbaffo.Web.UI.Pannello_Utente" %>

<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="UserControl" %>
<%@ Register Src="MenuCategorie.ascx" TagName="Menu" TagPrefix="UserControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>
        <%=TitoloPagina%></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />        
    <link rel="shortcut icon" href="images/favicon.ico" />
    <meta name="Title" content="<%=TitoloPagina%>" /> 
    <meta name="description" content="<%=DescrizionePagina %>" />
    <meta name="keywords" content="<%=KeywordsPagina %>" />
    <meta name="Robots" content="index,follow" />
    <meta name="Author" content="Davide Trotta" />    
    <link rel="alternate" type="application/rss+xml" title="RSS" href="RssHandler.ashx" />
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />

    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>

</head>
<body>
    <form id="frmPerbaffo" runat="server" autocomplete="off">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <UserControl:Header ID="Header1" runat="server" />
    <table border="0" cellpadding="0" cellspacing="0" width="1000px">
        <tr>
            <td align="left" valign="top">
                <UserControl:Menu ID="MenuPerbaffo" runat="server" />
                <img src="images/pixel.gif" width="1px" height="5px" border="0" alt="" /><br />
            </td>
            <td width="5" valign="top">
                <img src="images/pixel.gif" height="50" width="5" border="0" alt="" />
            </td>
            <td valign="top" width="100%" align="left">
                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%; background-color: #cddded;
                    height: 35;">
                    <tbody>
                        <tr>
                            <td align="left" class="topLeftStyle">
                            </td>
                            <td align="right" valign="middle">
                                <h1>
                                    <b>Pannello utente</b></h1>
                            </td>
                            <td align="right" class="topRightStyle">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="ppmainleftline" width="10">
                                <img src="images/pixel.gif" width="12" height="12" alt="" />
                            </td>
                            <td class="bodycopy" align="center">
                                <table class="boundingbox" border="0" cellpadding="10" cellspacing="0" width="95%">
                                    <tr>
                                        <td align="left">
                                            <span class="med_text" style="color: Black;"><b>Carica la foto del tuo amico:</b></span><span
                                                class="small_text"> (carica/cancella la foto del tuo amico che compare nella 
                                            galleria immagini)</span><br />
                                            <table border="0" cellspacing="1" cellpadding="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td align="left">
                                                            <asp:Image ID="imgFriend" ImageUrl="images/no-image.jpg" runat="server" Width="150"
                                                                Height="150" BorderWidth="0" />
                                                            <span id="lblDescrFriend" runat="server" class="med_text" style="color: Black;">
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Button CssClass="standardsubmit" ID="btnModificaFoto" CommandName="FOTO" runat="server"
                                                                Style="cursor: pointer;" Text="Modifica" ToolTip="Aggiungi/Elimina la foto del tuo amico"
                                                                OnClick="btnModificaFoto_Click" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <table class="boundingbox" border="0" cellpadding="10" cellspacing="0" width="95%">
                                    <tr>
                                        <td>
                                            <table border="0" cellspacing="1" cellpadding="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td align="left">
                                                            <span class="med_text" style="color: Black;"><b>Riepilogo dati:</b></span><span class="small_text">
                                                                (riepilogo dei tuoi dati personali)</span><br />
                                                            <span id="lblRiepilogoDati" runat="server" class="med_text" style="color: Black;">
                                                            </span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Button CssClass="standardsubmit" ID="btnModificaIndirizzo" CommandName="DATI" runat="server"
                                                                Style="cursor: pointer;" Text="Modifica" ToolTip="Modifica il tuo indirizzo o il tuo numero di telefono"
                                                                OnClick="btnModificaIndirizzo_Click" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:UpdatePanel ID="updPnlPassword" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table class="boundingbox" border="0" cellpadding="10" cellspacing="0" width="95%">
                                            <tr>
                                                <td>
                                                    <table border="0" cellspacing="1" cellpadding="0" width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <span class="med_text" style="color: Black;"><b>Cambio Password:</b></span><span
                                                                        class="small_text"> (qui puoi cambiare la tua password)</span><br />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="bodycopy" style="width: 30%;" align="left">
                                                                    <b>Nuova Password</b> (almeno 6 caratteri)
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" CssClass="pp_box_registrazione"
                                                                        Width="150" MaxLength="15" TabIndex="1"></asp:TextBox>&nbsp;*
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
                                                                        ErrorMessage="Inserisci la tua password" ToolTip="Inserisci la tua password"
                                                                        ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                                                                        ControlToValidate="txtRetypePassword" ErrorMessage="Le due password devono coincidere"
                                                                        ValidationGroup="UTENTE" ToolTip="Le due password devono coincidere">!</asp:CompareValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="bodycopy" style="width: 30%;" align="left">
                                                                    <b>Ridigita Password</b>
                                                                </td>
                                                                <td align="left">
                                                                    <asp:TextBox ID="txtRetypePassword" TextMode="Password" runat="server" CssClass="pp_box_registrazione"
                                                                        Width="150" MaxLength="15" TabIndex="2"></asp:TextBox>&nbsp;*
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRetypePassword"
                                                                        ErrorMessage="Ridigita la tua password" ToolTip="Ridigita la tua password" ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" align="left">
                                                                    <span class="small_text">I campi con l’asterisco * sono obbligatori e devono 
                                                                    essere compilati</span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right" colspan="2">
                                                                    <asp:Button CssClass="standardsubmit" ID="btnAggiornaPassword" CommandName="PASSWORD"
                                                                        runat="server" Style="cursor: pointer;" Text="Modifica" ValidationGroup="UTENTE"
                                                                        ToolTip="Aggiorna la tua Password" OnClick="btnAggiornaPassword_Click" />
                                                                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                                        ShowSummary="False" ValidationGroup="UTENTE" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                <asp:UpdatePanel ID="updPnlNewsletter" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table class="boundingbox" border="0" cellpadding="10" cellspacing="0" width="95%">
                                            <tr>
                                                <td  align="left">
                                                    <span class="med_text" style="color: Black;"><b>Iscriviti o cancellati dalla 
                                                    Newsletter:</b></span><span
                                                        class="small_text"> (seleziona/deseleziona la newsletter che intendi 
                                                    ricevere)</span><br />
                                                    <table border="0" cellspacing="1" cellpadding="0" width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td align="left">
                                                                    <table border="0" cellspacing="2" cellpadding="2">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <img border="0" width="80" height="80" alt="Newsletter Cani" src="images/newsletter/Newsletter_Cani.jpg" />
                                                                                </td>
                                                                                <td align="center">
                                                                                    <img border="0" alt="Newsletter Gatti" src="images/newsletter/Neswsletter_gatti.jpg"
                                                                                        width="80" height="80" />
                                                                                </td>
                                                                                <td align="center">
                                                                                    <img border="0" alt="Newsletter Roditori" src="images/newsletter/Newsletter_roditori.jpg"
                                                                                        width="80" height="80" />
                                                                                </td>
                                                                                <td align="center">
                                                                                    <img border="0" alt="Newsletter Uccelli" src="images/newsletter/Newsletter_volatili.jpg"
                                                                                        width="80" height="80" />
                                                                                </td>
                                                                                <td align="center">
                                                                                    <img border="0" alt="Newsletter Pesci" src="images/newsletter/Newsletter_pesci.jpg"
                                                                                        width="80" height="80" />
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center">
                                                                                    <asp:CheckBox ID="chkDog" runat="server" EnableViewState="false" />
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:CheckBox ID="chkGatto" runat="server" EnableViewState="false" />
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:CheckBox ID="chkRoditori" runat="server" EnableViewState="false" />
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:CheckBox ID="chkVolatili" runat="server" EnableViewState="false" />
                                                                                </td>
                                                                                <td align="center">
                                                                                    <asp:CheckBox ID="chkPesci" runat="server" EnableViewState="false" />
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td align="right">
                                                                    <asp:Button CssClass="standardsubmit" ID="btnModificaNewsletter" CommandName="NEWS"
                                                                        runat="server" Style="cursor: pointer;" Text="Aggiorna" ToolTip="Sottoscrivi o meno una newsletter"
                                                                        OnClick="btnModificaNewsletter_Click" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <br />
                                <table class="boundingbox" border="0" cellpadding="10" cellspacing="0" width="95%">
                                    <tr>
                                        <td>
                                            <table border="0" cellspacing="1" cellpadding="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td  align="left">
                                                            <span class="med_text" style="color: Black;"><b>Riepilogo ordini effettuati: </b>
                                                            </span><span class="small_text">(Riepilogo degli ordini effettuati su Perbaffo)</span>
                                                            <br />
                                                            <div id="divOrdineAttivo" runat="server" visible="false">
                                                                <table border="0" cellspacing="1" cellpadding="0" width="100%" style="border-style: solid;
                                                                    border-width: 1px; border-color: Black;">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td colspan="4" align="left">
                                                                                <span class="small_text"><b>Ordini attivi:</b></span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td class="basket_item_header" width="60" align="center">
                                                                                Cod. Ordine
                                                                            </td>
                                                                            <td class="basket_item_header" width="180" align="center">
                                                                                Descrizione
                                                                            </td>
                                                                            <td class="basket_item_header" width="200" align="center">
                                                                                Pagamento
                                                                            </td>
                                                                            <td class="basket_item_header" width="*" align="center">
                                                                                Stato
                                                                            </td>
                                                                        </tr>
                                                                        <asp:Repeater ID="rptOrdiniAttivi" runat="server" OnItemDataBound="rptOrdiniAttivi_ItemDataBound">
                                                                            <ItemTemplate>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <span class="small_text">
                                                                                            <%# ((Perbaffo.Presenter.Model.OrdiniDettagliato)Container.DataItem).ID %></span>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <a href="Dettaglio-Ordini-Effettuati.aspx" title="Dettaglio degli ordini effettuati su Perbaffo">
                                                                                            <span id="lblDescrizione" runat="server" class="small_text"></span></a>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <a href="Pagamenti.aspx" title="Dettagli dei pagamenti possibili su Perbaffo"><span
                                                                                            id="lblPagamento" runat="server" class="small_text"></span></a>
                                                                                    </td>
                                                                                    <td align="left">
                                                                                        <span id="lblStato" runat="server" class="small_text"></span>
                                                                                    </td>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                            <AlternatingItemTemplate>
                                                                                <tr>
                                                                                    <td align="center" style="background-color: #f5f5f5;">
                                                                                        <span class="small_text">
                                                                                            <%# ((Perbaffo.Presenter.Model.OrdiniDettagliato)Container.DataItem).ID %></span>
                                                                                    </td>
                                                                                    <td align="left" style="background-color: #f5f5f5;">
                                                                                        <a href="Dettaglio-Ordini-Effettuati.aspx" title="Dettaglio degli ordini effettuati su Perbaffo">
                                                                                            <span id="lblDescrizione" runat="server" class="small_text"></span></a>
                                                                                    </td>
                                                                                    <td align="left" style="background-color: #f5f5f5;">
                                                                                        <a href="Pagamenti.aspx" title="Dettagli dei pagamenti possibili su Perbaffo"><span
                                                                                            id="lblPagamento" runat="server" class="small_text"></span></a>
                                                                                    </td>
                                                                                    <td align="left" style="background-color: #f5f5f5;">
                                                                                        <span id="lblStato" runat="server" class="small_text"></span>
                                                                                    </td>
                                                                                </tr>
                                                                            </AlternatingItemTemplate>
                                                                        </asp:Repeater>
                                                                        <tr>
                                                                            <td align="left">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td class="basket_total">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td class="basket_total">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td class="basket_total" align="right">
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <br />
                                                                <a href="Controlla-Spedizione.aspx" title="Controlla dove si trova il tuo ordine tramite il codice di spedizione"
                                                                    style="color: Red;" id="lnkOrdineSpedito" runat="server">Controlla dove si 
                                                                trova il tuo ordine tramite il codice di spedizione</a>
                                                                <br />
                                                            </div>
                                                            <span id="lblOrdini" runat="server" class="med_text" style="color: Black;"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Button CssClass="standardsubmit" ID="btnVisualizza" CommandName="ORDINI" runat="server"
                                                                Style="cursor: pointer;" Text="Visualizza" ToolTip="Visualizza gli ordini già effettuati"
                                                                OnClick="btnVisualizza_Click" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                <br />
                                <asp:UpdatePanel ID="updPnlSconto" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                <table class="boundingbox" border="0" cellpadding="10" cellspacing="0" width="95%">
                                    <tr>
                                        <td>
                                            <table border="0" cellspacing="1" cellpadding="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td colspan="2"  align="left">
                                                            <span class="med_text" style="color: Black;"><b>Sconti: </b></span><span class="small_text">
                                                                (Sconti personali o codici sconto)</span>
                                                            <br />
                                                            <div id="divScontoPersonale" runat="server" visible="false">
                                                                <img src="images/sconto.gif" alt="Sconto Utente" border="0" />&nbsp;<span id="lblScontoPersonale"
                                                                    runat="server" class="small_text" style="color: red;"></span>
                                                            </div>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" style="width: 80%;"  align="left">
                                                            <span class="small_text" style="display:block;">Inserisci il codice sconto in 
                                                            tuo possesso e controlla l&#39;entità dello sconto</span>
                                                            <asp:TextBox ID="txtCodiceSconto" runat="server" CssClass="pp_box_registrazione"
                                                                Width="150" MaxLength="10"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator32" runat="server" ControlToValidate="txtCodiceSconto"
                                                                ErrorMessage="Codice sconto obbligatorio" ToolTip="Codice sconto obbligatorio"
                                                                ValidationGroup="SCONTO">!</asp:RequiredFieldValidator>
                                                                <span id="lblEntitaSconto" runat="server" class="small_text" style="display:block;"></span>
                                                        </td>
                                                        <td align="right">
                                                            <asp:Button CssClass="standardsubmit" ID="btnControlla" CommandName="SCONTOCHECK" 
                                                                ValidationGroup="SCONTO" runat="server"
                                                                Style="cursor: pointer;" Text="Controlla" onclick="btnControlla_Click" 
                                                                ToolTip="Controlla il codice sconto in tuo possesso"  />
                                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True"
                                                                        ShowSummary="False" ValidationGroup="SCONTO" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                                </ContentTemplate>
                                </asp:UpdatePanel>                                
                            </td>
                            <td class="ppmainrightline" width="10">
                                <img src="images/pixel.gif" width="12" height="12" alt="" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 12px; height: 12px; background-image: url(images/main_botleft.gif);
                                background-repeat: no-repeat;">
                            </td>
                            <td class="ppmainbotline" style="height: 12px;">
                            </td>
                            <td align="right" style="width: 12px; height: 12px; background-image: url(images/main_botright.gif);
                                background-repeat: no-repeat;">
                            </td>
                        </tr>
                    </tbody>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="5" align="center">
                <UserControl:Footer ID="FooterPerbaffo" runat="server" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
