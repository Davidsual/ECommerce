<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acquisto-Riepilogo.aspx.cs"
    Inherits="Perbaffo.Web.UI.Acquisto_Riepilogo" %>

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
    <link rel="Stylesheet" type="text/css" href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />

    <script language="javascript" type="text/javascript" src="HttpCombinerHandler.ashx?s=Set_JavascriptThumb&amp;t=text/javascript&amp;v=1"></script>

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
    <usercontrol:header id="Header1" runat="server" />
    <table border="0" cellspacing="0" cellpadding="0" style="width: 1000px; background-color: #cddded;
        height: 35px;">
        <tbody>
            <tr>
                <td align="left" class="topLeftStyle">
                </td>
                <td align="right" valign="middle">
                    <h1>
                        <b>Riepilogo e conferma ordine</b></h1>
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
                    <img src="images/ordine_step_4.gif" title="Riepilogo Ordine" width="479" height="59"
                        border="0" style="display: block" />
                    <asp:UpdatePanel ID="updPnlUtente" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="boundingbox" border="0" cellspacing="0" cellpadding="10" style="margin: 20 0 0 0;
                                width: 800px">
                                <tbody>
                                    <tr>
                                        <td class="bodycopyy" bgcolor="#cddded">
                                            <b>Riepilogo e conferma dell'ordine</b>
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
                                                </tbody>
                                            </table>
                                            <br />
                                            <table cellspacing="0" cellpadding="2" width="100%" style="border-color: #000000;
                                                border-width: 1px; border-style: solid;">
                                                <tbody>
                                                    <tr>
                                                        <td class="bodycopy" style="padding-left: 4px;" valign="top" align="left">
                                                            <span class="small_text"><b>Riepilogo Ordine:</b></span><br />
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
                                                                                        border="0" width="70" height="70" alt="<%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.DescrizioneLunga %>" />
                                                                                </td>
                                                                                <td class="basket_item" valign="top" align="left">
                                                                                    <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-bottom: 7px;">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    <span style="font-size: 10;"><b>
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
                                                                                                    <span style="font-size: 10;"><b>
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
                                                                        <td class="basket_item_header_alternate" align="center" colspan="2">
                                                                            <table border="0" cellspacing="0" cellpadding="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td class="basket_item_header_alternate" valign="top" style="width: 90px;" align="left">
                                                                                            Tipo Pagamento:&nbsp;
                                                                                        </td>
                                                                                        <td class="basket_item_header_alternate" valign="top" style="width: 400px;" align="left">
                                                                                            <span id="lblDescrTipoPagamento" runat="server"></span>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td class="basket_item_header_alternate" align="right" colspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td class="basket_item" align="right">
                                                                            <span id="lblPrezzoPagamento" runat="server"></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="basket_item_header" align="center" colspan="2">
                                                                            <table border="0" cellspacing="0" cellpadding="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td class="basket_item_header" valign="top" style="width: 90px;" align="left">
                                                                                            Tipo Spedizione:&nbsp;
                                                                                        </td>
                                                                                        <td class="basket_item_header" valign="top" style="width: 400px;" align="left">
                                                                                            <span id="lblDescTipoSpedizione" runat="server"></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td class="basket_item_header" align="right" colspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td class="basket_item" align="right">
                                                                            <span id="lblPrezzoSpedizione" runat="server"></span>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td class="basket_item_header_alternate" align="center" colspan="2">
                                                                            <table border="0" cellspacing="0" cellpadding="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td class="basket_item_header_alternate" valign="top" style="width: 90px;" align="left">
                                                                                            Codice sconto:&nbsp;
                                                                                        </td>
                                                                                        <td class="basket_item_header_alternate" valign="top" style="width: 400px;" align="left">
                                                                                            <span id="lblCodiceSconto" runat="server"></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td class="basket_item_header_alternate" align="right" colspan="2">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td class="basket_item" align="right">
                                                                            <span id="lblTotaleCodiceSconto" runat="server"></span>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                            <table id="tblScontoSpedizione" runat="server" border="0" cellspacing="1" cellpadding="0"
                                                                width="100%" visible="false">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="basket_item_header" align="center" style="width: 525;">
                                                                            <table border="0" cellspacing="0" cellpadding="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td class="basket_item_header" valign="top" style="width: 490px;" align="left">
                                                                                            <span>Sconto Spedizione (ordini superiori a € 35.00)</span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td class="basket_item_header" align="right" width="108">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td class="basket_item" align="right">
                                                                            <span id="lblScontoSpedizione" runat="server"></span>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>                                                            
                                                            <table id="tblScontoPerbaffo" runat="server" border="0" cellspacing="1" cellpadding="0"
                                                                width="100%" visible="false">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="basket_item_header" align="center" style="width: 525;">
                                                                            <table border="0" cellspacing="0" cellpadding="0">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td class="basket_item_header" valign="top" style="width: 490px;" align="left">
                                                                                            <span id="lblScontoPerbaffo" runat="server"></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                        <td class="basket_item_header" align="right" width="108">
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
                                                                        <td align="left">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td class="basket_total">
                                                                            &nbsp;
                                                                        </td>
                                                                        <td class="basket_total">
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
                                            <br />
                                            <table cellspacing="0" cellpadding="2" width="100%" style="border-color: #000000;
                                                border-width: 1px; border-style: solid;">
                                                <tbody>
                                                    <tr>
                                                        <td class="bodycopy" style="padding-left: 4px;" valign="top" align="left">
                                                            <span class="small_text"><b>Omaggio:</b></span><br />
                                                            <table cellspacing="0" cellpadding="0" width="100%" style="border-color: #000000;
                                                                border-width: 0px; border-style: solid;">
                                                                <tbody>
                                                                    <tr>
                                                                        <td class="basket_item" align="center" style="width: 90px;">
                                                                            <img id="imgOmaggio" runat="server" src='' border="0" width="70" height="70" alt="" />
                                                                        </td>
                                                                        <td class="basket_item" valign="top">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-bottom: 7px;">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td>
                                                                                            <span id="lblNomeOmaggio" class="small_text" runat="server"></span>
                                                                                            <br />
                                                                                            <span id="lblDescrizioneOmaggio" class="small_text" runat="server"></span>
                                                                                        </td>
                                                                                    </tr>
                                                                                </tbody>
                                                                            </table>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
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
                                        <td class="bodycopyy" align="center">
                                            <asp:Button ID="btnContinua" runat="server" Text="Conferma Ordine" CssClass="standardsubmitGrande"
                                                TabIndex="19" ToolTip="Conferma Ordine" ValidationGroup="ORDINE" OnClick="btnContinua_Click" />
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
