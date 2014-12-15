<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrello-Prodotti.aspx.cs"
    Inherits="Perbaffo.Web.UI.Carrello_Prodotti" %>

<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="UserControl" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
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
    <form id="frmPerbaffo" runat="server">
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
                <table border="0" cellspacing="0" cellpadding="0" style="width:100%;background-color:#cddded;height:35;">
                    <tbody>
                        <tr>
                            <td align="left" class="topLeftStyle">
                            </td>
                            <td align="right" valign="middle">
                                <h1>
                                    <b>Carrello</b></h1>
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
                                <table class="boundingbox" border="0" cellpadding="10" cellspacing="0">
                                    <tr>
                                        <td align="left"><span class="small_ten_text">Qui vengono visualizzati i prodotti che hai messo nel tuo carrello. Gli sconti e i costi di spedizione vengono calcolati al momento dell'acquisto!</span></td>                                        
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:UpdatePanel ID="updPnlCarrello" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <table border="0" cellspacing="1" cellpadding="0" width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td class="basket_item_header" width="30" align="center">
                                                                    Rimuovi
                                                                </td>
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
                                                                            <asp:HiddenField ID="hdKeyProduct" runat="server" Value="<%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).IDCarrelloItem.ToString() %>" />
                                                                            <asp:ImageButton ID="btnRemoveProdotto" runat="server" Width="17" Height="17" CommandName="DEL"
                                                                                CommandArgument="<%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.ID %>"
                                                                                BorderWidth="0" OnClientClick="return confirm('Sei sicuro di voler eliminare dal tuo carrello questo prodotto?');"
                                                                                ImageUrl="images/carrello_delete.gif" AlternateText="Rimuove il prodotto dal carrello" />
                                                                             elimina
                                                                        </td>
                                                                        <td class="basket_item" align="center">
                                                                            <img src="<%= UrlImmagine %><%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.UrlImmagine %>"
                                                                                border="0" width="70" height="70" alt="<%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.Nome %>" />
                                                                        </td>
                                                                        <td class="basket_item" valign="top" align="left">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-bottom: 7px;">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                            <a href="#" id="lnkProdotto" runat="server" title="<%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.DescrizioneLunga %>" style="font-size: 10;"><b>
                                                                                                <%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.Nome %></b></a>
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
                                                                                                <span class="small_text" style="color: Black;"><b>Variazione selezionata:&nbsp;</b></span><span
                                                                                                    class="small_text" id="lblColore" runat="server"></span>
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </div>
                                                                        </td>
                                                                        <td class="basket_item" align="right">
                                                                            <div id="divPrezzoParzialeOfferta" runat="server" visible="false">
                                                                                <span><b>€&nbsp;</b></span><span style="text-decoration: line-through;" id="lblPrezzoProdottoDaScontare" runat="server"></span>
                                                                                <span style="color:Red;"><b>€&nbsp;</b></span><span id="lblPrezzoProdottoScontato" runat="server" style="color:Red;"></span>
                                                                            </div>
                                                                            <div id="divPrezzoParziale" runat="server" visible="true">
                                                                                <span><b>€&nbsp;</b></span><span id="lblPrezzoProdotto" runat="server"></span>
                                                                            </div>
                                                                        </td>
                                                                        <td class="basket_item" align="center">
                                                                            <asp:TextBox class="basket_qty" ID="txtQuantita" MaxLength="2" runat="server" Text="<%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Quantita %>"></asp:TextBox>
                                                                        </td>
                                                                        <td class="basket_item" align="right">
                                                                            <span><b>€&nbsp;</b></span><span id="lblTotaleCalcolato" runat="server"></span>
                                                                        </td>
                                                                    </tr>
                                                                </ItemTemplate>
                                                                <AlternatingItemTemplate>
                                                                    <tr>
                                                                        <td class="basket_item_alternate" align="center">
                                                                            <asp:HiddenField ID="hdKeyProduct" runat="server" Value="<%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).IDCarrelloItem.ToString() %>" />
                                                                            <asp:ImageButton ID="btnRemoveProdotto" runat="server" Width="17" Height="17" CommandName="DEL"
                                                                                OnClientClick="return confirm('Sei sicuro di voler eliminare dal tuo carrello questo prodotto?');"
                                                                                CommandArgument="<%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.ID %>"
                                                                                BorderWidth="0" ImageUrl="images/carrello_delete.gif" AlternateText="Rimuove il prodotto dal carrello" />
                                                                            elimina
                                                                        </td>
                                                                        <td class="basket_item_alternate" align="center">
                                                                            <img src="<%= UrlImmagine %><%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.UrlImmagine %>"
                                                                                border="0" width="70" height="70" alt="<%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.DescrizioneLunga %>" />
                                                                        </td>
                                                                        <td class="basket_item_alternate" valign="top" align="left">
                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="margin-bottom: 7px;">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td align="left">
                                                                                           <a href="#" id="lnkProdotto" runat="server"  style="font-size: 10;"><b>
                                                                                                <%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Prodotto.Nome %></b></a>
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
                                                                                <span><b>€&nbsp;</b></span><span style="text-decoration: line-through;" id="lblPrezzoProdottoDaScontare" runat="server"></span>
                                                                                <span><b>€&nbsp;</b></span><span id="lblPrezzoProdottoScontato" runat="server"></span>
                                                                            </div>
                                                                            <div id="divPrezzoParziale" runat="server" visible="true">
                                                                                <span><b>€&nbsp;</b></span><span id="lblPrezzoProdotto" runat="server"></span>
                                                                            </div>
                                                                        </td>
                                                                        <td class="basket_item_alternate" align="center">
                                                                            <asp:TextBox class="basket_qty" ID="txtQuantita" MaxLength="2" runat="server" Text="<%# ((Perbaffo.Presenter.CarrelloItem)Container.DataItem).Quantita %>"></asp:TextBox>
                                                                        </td>
                                                                        <td class="basket_item_alternate" align="right">
                                                                            <span><b>€&nbsp;</b></span><span id="lblTotaleCalcolato" runat="server"></span>
                                                                        </td>
                                                                    </tr>
                                                                </AlternatingItemTemplate>
                                                            </asp:Repeater>
                                                            <tr>
                                                                <td class="basket_item_header" colspan="6" align="right">
                                                                    <asp:ImageButton ID="btnUpdateCarrello" CommandName="UPD" 
                                                                        CommandArgument="UPD"  style="border:0px;"
                                                                        runat="server" Width="80" Height="21" AlternateText="Aggiorna carrello" 
                                                                        ImageUrl="images/cart_aggiorna.gif" onclick="btnUpdateCarrello_Click" 
                                                                        BorderStyle="None" />
                                                                </td>
                                                            </tr>                                                            
                                                            <tr>
                                                                <td colspan="3" align="left">
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
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <br />
                                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td valign="top" align="right">
                                                            <asp:Button ID="btnAcquista" runat="server" Text="Acquista" CssClass="standardsubmit"
                                                                OnClick="btnAcquista_Click" ToolTip="Acquista i prodotti nel carrello" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
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
    <script language="javascript" type="text/javascript">
        var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
        document.write(unescape("%3Cscript src='" + gaJsHost + "google-analytics.com/ga.js' type='text/javascript'%3E%3C/script%3E"));
    </script>

    <script language="javascript" type="text/javascript">
        try {
            var pageTracker = _gat._getTracker("UA-3824773-1");
            pageTracker._trackPageview();
        } catch (err) { }
    </script>    
</body>
</html>
