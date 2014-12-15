<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acquisto-Pagamenti.aspx.cs"
    Inherits="Perbaffo.Web.UI.Acquisto_Pagamenti" %>

<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
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
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />
    <script language="javascript" type="text/javascript" src="HttpCombinerHandler.ashx?s=Set_JavascriptThumb&amp;t=text/javascript&amp;v=1" ></script>

    <script language="javascript" type="text/javascript">


        fInit();
        function fInit() {
            try {
                $(function() {
                    $("img[src*='L.jpg']").thumbPopup({
                        imgSmallFlag: "L",
                        imgLargeFlag: "H"
                    });
                });
            }
            catch (err) {
                return;
            }
        }
    </script>

</head>
<body>
    <form runat="server" id="frmLogin">
    <asp:ScriptManager ID="ScriptManager1" runat="server" LoadScriptsBeforeUI="true">
    </asp:ScriptManager>
    <UserControl:Header ID="Header1" runat="server" />
    <table border="0" cellspacing="0" cellpadding="0" style="width: 1000px; background-color: #cddded;
        height: 35px;">
        <tbody>
            <tr>
                <td align="left" class="topLeftStyle">
                </td>
                <td align="right" valign="middle">
                    <h1>
                        <b>Pagamento - Spedizione - Sconti</b></h1>
                </td>
                <td align="right" class="topRightStyle">
                </td>
            </tr>
        </tbody>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="1000">
        <tbody>
            <tr>
                <td class="ppmainleftline" width="10">
                    <img src="images/pixel.gif" width="12" height="12" alt="" />
                </td>
                <td class="bodycopy" align="center">
                    <img src="images/ordine_step_2.gif" title="Seleziona il tipo di Pagamento e Spedizione ed inserici eventuali codici sconto" width="479" height="59" border="0" style="display:block"/>
                    <span>Scegli il tipo di pagamento e il tipo di spedizione che desideri</span>
                    <asp:UpdatePanel ID="updPnlUtente" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="boundingbox" border="0" cellspacing="0" cellpadding="10" style="margin: 20 0 0 0;
                                width: 800px">
                                <tbody>
                                    <tr>
                                        <td class="bodycopyy" bgcolor="#cddded">
                                            <b>Seleziona il tipo di pagamento e il tipo di spedizione</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="bodycopy">
                                            <table cellspacing="0" cellpadding="2" width="100%" style="border-color: #000000;
                                                border-width: 1px; border-style: solid;">
                                                <tbody>
                                                    <tr>
                                                        <td class="bodycopy" style="padding-left: 4px;" valign="top" align="left">
                                                            <span class="small_text"><b>Riepilogo dati destinatario:</b></span><br />
                                                            <span class="small_text" id="lblRiepilogo" runat="server"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="left">
                                                            <asp:Button ID="btnModifica" runat="server" Text="Modifica" CssClass="standardsubmit"
                                                                TabIndex="0" ToolTip="Modifica i tuoi dati" OnClick="btnModifica_Click" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <table border="0" cellspacing="1" cellpadding="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td class="basket_item_header" width="80">
                                                            &nbsp;
                                                        </td>
                                                        <td class="basket_item_header" width="445" align="left">
                                                            Prodotto
                                                        </td>
                                                        <td class="basket_item_header" width="40" align="center">
                                                            Prezzo
                                                        </td>
                                                        <td class="basket_item_header" width="35" align="center">
                                                            Quantità
                                                        </td>
                                                        <td class="basket_item_header" width="110" align="center">
                                                            Totale (iva incl.)
                                                        </td>
                                                    </tr>
                                                    <asp:Repeater ID="rptCarrello" runat="server" OnItemCommand="rptCarrello_ItemCommand"
                                                        OnItemDataBound="rptCarrello_ItemDataBound">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td class="basket_item" align="center">
                                                                    <img src="<%= UrlImmagine %><%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.UrlImmagine %>"
                                                                        border="0" width="70" height="70" alt="<%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.Nome %>" />
                                                                </td>
                                                                <td class="basket_item" valign="top">
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-bottom: 7px;">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <span class="small_text"><b>
                                                                                        <%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.Nome %></b></span>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                    <div id="divTaglia" runat="server" visible="false">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <span class="small_text" style="color: Black;"><b>Misura selezionata:&nbsp;</b></span><span
                                                                                            class="small_text" id="lblTaglia" runat="server"></span>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                    <div id="divColore" runat="server" visible="false">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <span class="small_text" style="color: Black;"><b>Colore selezionato:&nbsp;</b></span><span
                                                                                            class="small_text" id="lblColore" runat="server"></span>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                                <td class="basket_item" align="right">
                                                                    <div id="divPrezzoParzialeOfferta" runat="server" visible="false">
                                                                        <span><b>€&nbsp;</b></span><span style="text-decoration: line-through;" id="lblPrezzoProdottoDaScontare"
                                                                            runat="server"></span> <span style="color: Red;"><b>€&nbsp;</b></span><span id="lblPrezzoProdottoScontato"
                                                                                runat="server" style="color: Red;"></span>
                                                                    </div>
                                                                    <div id="divPrezzoParziale" runat="server" visible="true">
                                                                        <span><b>€&nbsp;</b></span><span id="lblPrezzoProdotto" runat="server"></span>
                                                                    </div>
                                                                </td>
                                                                <td class="basket_item" align="center">
                                                                    <span class="small_text">
                                                                        <%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Quantita %></span>
                                                                </td>
                                                                <td class="basket_item" align="right">
                                                                    <span><b>€&nbsp;</b></span><span id="lblTotaleCalcolato" runat="server"></span>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <AlternatingItemTemplate>
                                                            <tr>
                                                                <td class="basket_item_alternate" align="center">
                                                                    <img src="<%= UrlImmagine %><%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.UrlImmagine %>"
                                                                        border="0" width="70" height="70" alt="<%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.DescrizioneLunga %>" />
                                                                </td>
                                                                <td class="basket_item_alternate" valign="top" align="left">
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-bottom: 7px;">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <span class="small_text"><b>
                                                                                        <%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.Nome %></b></span>
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                    <div id="divTaglia" runat="server" visible="false">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <span class="small_text" style="color: Black;"><b>Misura selezionata:&nbsp;</b></span><span
                                                                                            class="small_text" id="lblTaglia" runat="server"></span>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                    <div id="divColore" runat="server" visible="false">
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <span class="small_text" style="color: Black;"><b>Colore selezionato:&nbsp;</b></span><span
                                                                                            class="small_text" id="lblColore" runat="server"></span>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </div>
                                                                </td>
                                                                <td class="basket_item_alternate" align="right">
                                                                    <div id="divPrezzoParzialeOfferta" runat="server" visible="false">
                                                                        <span><b>€&nbsp;</b></span><span style="text-decoration: line-through;" id="lblPrezzoProdottoDaScontare"
                                                                            runat="server"></span> <span><b>€&nbsp;</b></span><span id="lblPrezzoProdottoScontato"
                                                                                runat="server"></span>
                                                                    </div>
                                                                    <div id="divPrezzoParziale" runat="server" visible="true">
                                                                        <span><b>€&nbsp;</b></span><span id="lblPrezzoProdotto" runat="server"></span>
                                                                    </div>
                                                                </td>
                                                                <td class="basket_item_alternate" align="center">
                                                                    <span class="small_text">
                                                                        <%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Quantita %></span>
                                                                </td>
                                                                <td class="basket_item_alternate" align="right">
                                                                    <span><b>€&nbsp;</b></span><span id="lblTotaleCalcolato" runat="server"></span>
                                                                </td>
                                                            </tr>
                                                        </AlternatingItemTemplate>
                                                    </asp:Repeater>
                                                    <tr>
                                                        <td colspan="3" class="basket_total" align="center">
                                                            Totale prodotti:
                                                        </td>
                                                        <td class="basket_total">
                                                            &nbsp;
                                                        </td>
                                                        <td class="basket_total" align="right">
                                                            <span><b>€&nbsp;</b></span><span id="lblTotaleParziale" runat="server"></span>
                                                        </td>
                                                    </tr>            
                                                    <tr>
                                                        <td class="basket_item_header" align="center" colspan="4">
                                                            <table border="0" cellspacing="0" cellpadding="0" width="90%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="basket_item_header" valign="top" align="left">
                                                                            Tipo Pagamento:&nbsp;
                                                                        </td>
                                                                        <td valign="top" colspan="2" align="left">
                                                                            <asp:DropDownList ID="ddlPagamento" runat="server" CssClass="combo" Width="350" AutoPostBack="true"
                                                                                OnSelectedIndexChanged="ddlPagamento_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            &nbsp;
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlPagamento"
                                                                                ErrorMessage="Seleziona il tipo di pagamento" ToolTip="Seleziona il tipo di pagamento"
                                                                                ValidationGroup="ORDINE">!</asp:RequiredFieldValidator>                                                                            
                                                                            <br />
                                                                            <span id="lblDettaglioPagamento" runat="server" class="small_text"></span>
                                                                            <table border="0" cellpadding="0" cellspacing="0" visible="false" runat="server" id="tblCarte">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td><img src="images/CreditCardMaster.gif" alt="Pagamento con MasterCard" border="0" width="37" height="23"/></td>
                                                                                        <td><img src="images/CreditCardVisa2.gif" alt="Pagamento con Visa" border="0" width="37" height="23"/></td>
                                                                                        <td><img src="images/CreditCardVisa.gif" alt="Pagamento con Visa Electron" border="0" width="37" height="23"/></td>
                                                                                        <td><img src="images/CreditCardAmerican.gif" alt="Pagamento con American Express" border="0" width="37" height="23"/></td>
                                                                                        <td><img src="images/CreditCardAurora.gif" alt="Pagamento con Carta Aurora" border="0" width="37" height="23"/></td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                            &nbsp;
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                        <td class="basket_item" align="right">
                                                            <span id="lblPrezzoPagamento" runat="server"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="basket_item_header_alternate" align="center" colspan="4">
                                                            <table border="0" cellspacing="0" cellpadding="0" width="90%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="basket_item_header_alternate" valign="top" align="left">
                                                                            Tipo Spedizione*:&nbsp;&nbsp;&nbsp;&nbsp;
                                                                        </td>
                                                                        <td valign="top" colspan="2" align="left">
                                                                            <asp:DropDownList ID="ddlSpedizione" runat="server" CssClass="combo" AutoPostBack="true"
                                                                                Width="350" OnSelectedIndexChanged="ddlSpedizione_SelectedIndexChanged">
                                                                            </asp:DropDownList>
                                                                            &nbsp;
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlSpedizione"
                                                                                ErrorMessage="Seleziona il tipo di spedizione" ToolTip="Seleziona il tipo di spedizione"
                                                                                ValidationGroup="ORDINE">!</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                    <td colspan="3" align="left" style="padding:3px;">
                                                                    <strong><font style="color:Red;">* Se il totale dei prodotti al netto di eventuali buoni sconti supera i € 35,00 riceverai uno sconto sulle spese di spedizione di € 5,10. Lo sconto sarà visibile nel riepilogo ordine finale.</font></strong>
                                                                    </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                        <td class="basket_item" align="right">
                                                            <span id="lblPrezzoSpedizione" runat="server"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="basket_item_header" align="center" colspan="2">
                                                            <table border="0" cellspacing="0" cellpadding="0" width="88%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="basket_item_header" valign="top" align="left" style="width:25%">
                                                                            Codice sconto:&nbsp;
                                                                        </td>
                                                                        <td valign="top" colspan="2" align="left">
                                                                            <asp:TextBox class="basket_voucher_box" ID="txtCodiceSconto" MaxLength="10" runat="server" Width="150"></asp:TextBox>
                                                                            &nbsp;
                                                                            <div id="divDescrCodice" runat="server" visible="false">
                                                                            <br />
                                                                            <span id="lblDescrCodSconto" runat="server"></span>    
                                                                            </div>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                        <td class="basket_item_header" align="right" colspan="2">
                                                            &nbsp;
                                                        </td>
                                                        <td class="basket_item" align="right">
                                                            <span id="lblTotaleCodiceSconto" runat="server"></span>
                                                        </td>
                                                    </tr>                                                      
                                                    </tbody>
                                                    </table>
                                                    <table id="tblScontoPerbaffo" runat="server" border="0" cellspacing="1" cellpadding="0" width="100%" visible="false">
                                                    <tbody>
                                                    <tr>
                                                        <td class="basket_item_header_alternate" align="center" style="width:525;"> 
                                                            <table border="0" cellspacing="0" cellpadding="0" width="88%">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="basket_item_header_alternate" valign="top" align="left">
                                                                            <span id="lblScontoPerbaffo" runat="server"></span>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                        <td class="basket_item_header_alternate" align="right" width="108">
                                                            &nbsp;
                                                        </td>
                                                        <td class="basket_item" align="right">
                                                            <span id="lblTotaleScontoPerbaffo" runat="server"></span>
                                                        </td>
                                                    </tr>
                                                    </tbody>
                                                    </table>  
                                                    <table border="0" cellspacing="1" cellpadding="0" width="100%">
                                                    <tbody>                                               
                                                    <tr>
                                                        <td class="basket_item_header" colspan="2" align="right">
                                                            <asp:ImageButton ID="btnUpdateCarrello" CommandName="UPD" CommandArgument="UPD" BorderWidth="0"
                                                                runat="server" Width="80" Height="21" AlternateText="Aggiorna carrello" ImageUrl="images/cart_aggiorna.gif"
                                                                OnClick="btnUpdateCarrello_Click" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="basket_total" align="center" style="width:71%;">
                                                            Totale
                                                        </td>
                                                        <td class="basket_total" align="right">
                                                            <span><b>€&nbsp;</b></span><span id="lblTotaleCarrello" runat="server"></span>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table border="0" cellspacing="0" cellpadding="0" style="margin: 20 0 0 0; width: 800px">
                                <tbody>
                                    <tr>
                                        <td class="bodycopyy" align="right">
                                            <asp:Button ID="btnContinua" runat="server" Text="Continua &gt;&gt;" CssClass="standardsubmitCancella"
                                                TabIndex="19" ToolTip="Continua il tuo acquisto scegliendo l'omaggio a cui hai diritto"
                                                ValidationGroup="ORDINE" OnClick="btnContinua_Click" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="ORDINE" />
                                        </td>
                                    </tr>
                                </tbody>
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
    </form>
</body>
</html>
