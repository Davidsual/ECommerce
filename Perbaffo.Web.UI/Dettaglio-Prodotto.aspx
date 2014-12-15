<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dettaglio-Prodotto.aspx.cs"
    Inherits="Perbaffo.Web.UI.Dettaglio_Prodotto" %>

<%@ Register Src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffo.ascx" TagName="Perbaffo" TagPrefix="UserControl" %>
<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="UserControl" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="UserControl" %>
<%@ Register Src="WidgetFoto.ascx" TagName="Foto" TagPrefix="UserControl" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
<%@ Register Src="MenuCategorie.ascx" TagName="Menu" TagPrefix="UserControl" %>
<%@ Register Src="WidgetCarrello.ascx" TagName="Carrello" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNews.ascx" TagName="News" TagPrefix="UserControl" %>
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
    <link rel="Stylesheet" type="text/css" href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />

    <script language="javascript" type="text/javascript" src="HttpCombinerHandler.ashx?s=Set_JavascriptThumb&amp;t=text/javascript&amp;v=1"></script>

    <script language="javascript" type="text/javascript">

        $(function() {
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
        });


        ///
        /// Visualizza il thumbnail della foto (photogallery) se e solo se esiste almeno un immagine
        ///
        function fInitPhotoGallery(idProdotto) {
            try {
                $(function() {
                    $("img[src*='" + idProdotto + "G']").thumbPopup({
                    //                        imgSmallFlag: idProdotto+"G",
                    //                        imgLargeFlag: idProdotto+"G"
                });
            });
        }
        catch (err) {
            return;
        }
    }
    //    function fShow(ctrl) {
    //        try {
    //            var _default = document.getElementById("imgProdotto");
    //            if (ctrl != null && _default != null) {
    //                _default.src = ctrl.src;
    //            }
    //        }
    //        catch (err) {
    //            return;
    //        }
    //    }

    //    function fHide() {
    //        try {
    //            var _default = document.getElementById("imgProdotto");
    //            var _value = document.getElementById("hdImageProdotto");

    //            if (_value != null && _default != null) {
    //                _default.src = _value.value;
    //            }
    //        }
    //        catch (err) {
    //            return;
    //        }
    //    }

    function bmkURL(bookmark, paramUrl, valueUrl, paramTitle, valueTitle) {
        try {
            var new_url = bookmark + paramUrl + '=' + encodeURIComponent(valueUrl) + '&' + paramTitle + '=' + encodeURIComponent(valueTitle);
            window.open(new_url);
        }
        catch (err) {
            return;
        }
    }
    </script>

</head>
<body>
    <form id="frmPerbaffoPetShop" runat="server">
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
            <td valign="top">
                <table border="0" cellspacing="0" cellpadding="0" width="590px">
                    <tbody>
                        <tr>
                            <td>
                                <div style="margin: 5px 10px 10px 10px; clear: both;">
                                    <span class="small_text">Questo prodotto è presente in queste categorie:</span>
                                    <div id="divCategorie" runat="server" class="small_text">
                                    </div>
                                </div>
                                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                                    <tbody>
                                        <tr>
                                            <td bgcolor="#ffffff" valign="middle" align="center">
                                                <asp:UpdatePanel ID="updPnlProdotto" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <table border="0" cellspacing="0" cellpadding="0" style="width: 100%; background-color: #cddded;
                                                            height: 35px;">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="left" class="topLeftStyle">
                                                                    </td>
                                                                    <td rowspan="2">
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td height="20" valign="middle" align="left">
                                                                                        <h1>
                                                                                            <span id="lblNomeProdotto" runat="server"></span>
                                                                                        </h1>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                    <td align="right" class="topRightStyle">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="bottom" width="11">
                                                                    </td>
                                                                    <td width="11">
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
                                                                    <td>
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td valign="top" style="padding-left: 3px;">
                                                                                        &nbsp;<br />
                                                                                        <div style="width: 550px; height: 250px; clear: both;">
                                                                                            <img src="#" alt="" width="240" height="240" id="imgProdotto" runat="server" style="float: left;" />
                                                                                            <div id="divFotoGallery" runat="server" visible="false" style="margin-right: 60px;">
                                                                                                <table border="0" cellspacing="0" cellpadding="0">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="left">
                                                                                                                <span class="small_text_justify"><b>PhotoGallery:</b></span>
                                                                                                                <asp:HiddenField ID="hdImageProdotto" runat="server" />
                                                                                                                <asp:DataList ID="dtlFoto" Width="170px" runat="server" CellPadding="0" CellSpacing="0"
                                                                                                                    RepeatColumns="2" RepeatDirection="Horizontal">
                                                                                                                    <ItemTemplate>
                                                                                                                        <img src="<%# UrlImmagine %><%#((Perbaffo.Presenter.Model.ProdottiFotogallery)Container.DataItem).UrlImmagine%>"
                                                                                                                            alt="<%#((Perbaffo.Presenter.Model.ProdottiFotogallery)Container.DataItem).DescrImmagine%>"
                                                                                                                            title="<%#((Perbaffo.Presenter.Model.ProdottiFotogallery)Container.DataItem).DescrImmagine%>"
                                                                                                                            width="80px" height="80px" style="border: 0px; margin: 10px;" />
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:DataList>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </div>
                                                                                        </div>
                                                                                        <div style="position: relative; top: 0px; left: 0px;">
                                                                                            <span class="small_text_justify" id="lblDescrProdotto" runat="server"></span>
                                                                                            <br />
                                                                                            <div id="divMisura" runat="server" visible="false">
                                                                                                <span class="small_text_justify"><b>Misura selezionata:</b>&nbsp;</span><span class="small_text_justify"
                                                                                                    id="lblTagliaProdotto" runat="server"></span>
                                                                                            </div>
                                                                                            <div id="divTaglia" runat="server" visible="false" style="padding: 0 0 10px 0; clear: both;">
                                                                                                <table border="0" cellspacing="0" cellpadding="0" style="float: left; margin-top: 10px;">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="left">
                                                                                                                <span class="small_text_justify"><b>Altre taglie disponibili:</b></span>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left">
                                                                                                                <asp:Repeater ID="rptTaglie" runat="server">
                                                                                                                    <ItemTemplate>
                                                                                                                        <div style="font-size: 12px; font-weight: bold; padding-top: 3px">
                                                                                                                            <span class="small_text"><b>Misura:&nbsp;&nbsp;</b></span><asp:LinkButton ID="lnkTaglia"
                                                                                                                                runat="server" CommandArgument='<%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).ID%>'
                                                                                                                                ToolTip="<%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).DescrTaglia%>"
                                                                                                                                OnClick="LinkTaglia_Click"><%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).DescrTaglia%>&nbsp;(€ <%#CheckTagliaPrice(((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem))%>)</asp:LinkButton>
                                                                                                                        </div>
                                                                                                                    </ItemTemplate>
                                                                                                                </asp:Repeater>
                                                                                                                <br />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </div>
                                                                                            <div id="divColori" runat="server" visible="false" style="clear: both; margin-bottom: 15px;">
                                                                                                <table border="0" cellspacing="0" cellpadding="0" style="float: left; margin-top: 10px;">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td align="left">
                                                                                                                <span class="small_text_justify"><b>Varianti disponibili:</b></span>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td align="left">
                                                                                                                <select class="combo" id="ddlVarianti" runat="server" style="width: 200px;">
                                                                                                                </select>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </div>
                                                                                            <br />
                                                                                        </div>
                                                                                        <div id="divOfferta" runat="server" visible="false">
                                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border-top: 1px;
                                                                                                border-left: 1px; border-right: 1px; border-bottom: 0px; border-color: red; border-style: solid;
                                                                                                margin-top: 20px;">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td align="left" style="width: 45%;">
                                                                                                            <span class="small_text_justify"><b>Prezzo:</b></span>
                                                                                                        </td>
                                                                                                        <td style="width: 20%;" align="right">
                                                                                                            <span id="lblPrezzoPrecedente" runat="server" class="price_large_black" style="text-decoration: line-through;">
                                                                                                            </span>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border-width: 1px;
                                                                                                border-color: red; border-style: solid;">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td align="left" style="width: 45%;">
                                                                                                            <span class="small_text_justify"><b>Prezzo scontato:</b></span>
                                                                                                        </td>
                                                                                                        <td align="right">
                                                                                                            <span id="lblTotale" runat="server" class="price_large"></span>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </div>
                                                                                        <div id="divPrezzo" runat="server" style="clear: both;">
                                                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%" style="border-width: 1px;
                                                                                                border-color: red; border-style: solid; margin: 20px 0 0 0;">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td align="left" style="width: 45%;">
                                                                                                            <span class="small_text_justify"><b>Prezzo:</b></span>
                                                                                                        </td>
                                                                                                        <td align="right">
                                                                                                            <span id="lblPrezzoTotale" runat="server" class="price_large"></span>
                                                                                                        </td>
                                                                                                    </tr>
                                                                                                </tbody>
                                                                                            </table>
                                                                                        </div>
                                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%" style="margin-top: 10px;">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td valign="middle" align="right">
                                                                                                        <asp:Button class="standardsubmitAcquista" ID="btnAdd" CommandName="ACQUISTA" runat="server"
                                                                                                            ToolTip="Metti questo prodotto nel carrello" Text="Aggiungi al carrello" OnClick="btnAdd_Click" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                        <br />
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td bgcolor="#ffffff" align="right">
                                                                                        <table border="0" cellspacing="0" cellpadding="0" width="70%" style="margin-top: 10px;">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td valign="middle" align="right">
                                                                                                        <asp:Button class="standardsubmitDettaglio" ID="btnFavorito" CommandName="FAVORITI"
                                                                                                            runat="server" ToolTip="Aggiungilo alla tua lista dei desideri" Text="Agg. Lista desideri"
                                                                                                            Style="cursor: pointer;" OnClick="btnFavorito_Click" />
                                                                                                    </td>
                                                                                                    <td valign="middle" align="right">
                                                                                                        <asp:Button class="standardsubmitDettaglio" ID="btnAmico" CommandName="AMICO" runat="server"
                                                                                                            Style="cursor: pointer;" Text="Segnala ad un amico" ToolTip="Invia un E-Mail al tuo amico segnalandogli questo prodotto" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td bgcolor="#ffffff">
                                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                            <tbody>
                                                                                                <tr>
                                                                                                    <td>
                                                                                                        <img src="images/pixel.gif" width="12px" height="12px" alt="" />
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="left">
                                                                                                        <div id="divNoRecensione" runat="server" visible="false">
                                                                                                            <span id="lblNessunaRecensione" class="small_text"><b>Nessuna recensione presente</b></span>
                                                                                                        </div>
                                                                                                        <asp:Repeater ID="rptRecensioni" runat="server" OnItemDataBound="rptRecensioni_ItemDataBound">
                                                                                                            <ItemTemplate>
                                                                                                                <div id="divVoto" runat="server">
                                                                                                                </div>
                                                                                                                <span class="small_text"><b>
                                                                                                                    <%#((Perbaffo.Presenter.Model.ProdottiRecensioni)Container.DataItem).Titolo%></b>&nbsp;(inserita
                                                                                                                    il:
                                                                                                                    <%#((Perbaffo.Presenter.Model.ProdottiRecensioni)Container.DataItem).DataInserimento.ToShortDateString()%>
                                                                                                                    da
                                                                                                                    <%#((Perbaffo.Presenter.Model.ProdottiRecensioni)Container.DataItem).Nome%></span>)
                                                                                                                <br />
                                                                                                                <span class="small_ten_text">
                                                                                                                    <%# TagliaStringa(((Perbaffo.Presenter.Model.ProdottiRecensioni)Container.DataItem).Recensione)%></span>
                                                                                                                <br />
                                                                                                            </ItemTemplate>
                                                                                                        </asp:Repeater>
                                                                                                        <br />
                                                                                                        <span class="small_text"><a href="#" id="lnkReadAll" runat="server" title="Leggi tutte le recensioni"
                                                                                                            class="dark_red" style="padding-left: 16px;">Leggi tutte le recensioni</a></span>&nbsp;
                                                                                                        <br />
                                                                                                        <span class="small_text"><a href="#" id="lnkScrivi" runat="server" title="Scrivi una recensione"
                                                                                                            class="dark_red">
                                                                                                            <img src="images/pencil.gif" alt="Vota e recensisci questo prodotto" width="16" height="16"
                                                                                                                style="border: 0;" />Vota e recensisci questo prodotto</a></span>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td align="right">
                                                                                                        <br />
                                                                                                        <div id="bookmark">
                                                                                                            <ul style="list-style: none; display: inline;">
                                                                                                                <li style="display: inline;"><span class="small_text"><strong>Condividi &gt;&nbsp;</strong></span>
                                                                                                                </li>
<li style="display: inline; cursor: pointer;"><a onclick="return bmkURL('http://www.facebook.com/sharer.php?', 'u', document.location.href);"
                                                                                                                    style="margin-right: 5px;">
                                                                                                                    <img height="16" width="16" src="images/facebook.png" alt="Facebook" border="0" title="Facebook" /></a></li>                                                                                                                
                                                                                                                <li style="display: inline; cursor: pointer;"><a onclick="return bmkURL('http://oknotizie.alice.it/post.html.php?','url', document.location.href, 'title', document.title);"
                                                                                                                    style="margin-right: 5px;">
                                                                                                                    <img height="16" width="16" border="0" src="images/oknotizie.png" alt="Ok Notizie"
                                                                                                                        title="Ok Notizie" /></a></li>
                                                                                                                <li style="display: inline; cursor: pointer;"><a onclick="return bmkURL('https://favorites.live.com/quickadd.aspx?marklet=1&','url', document.location.href , 'title', document.title);"
                                                                                                                    style="margin-right: 5px;">
                                                                                                                    <img height="16" border="0" width="16" src="images/microsoftlive.png" alt="Microsoft Live"
                                                                                                                        title="Microsoft Live" /></a></li>
                                                                                                                <li style="display: inline; cursor: pointer;"><a onclick="return bmkURL('http://del.icio.us/save?','url', document.location.href, 'title', document.title);"
                                                                                                                    style="margin-right: 5px;">
                                                                                                                    <img height="16" width="16" src="images/delicious.png" alt="Delicious" title="Delicious"
                                                                                                                        border="0" /></a></li>
                                                                                                                <li style="display: inline; cursor: pointer;"><a onclick="return bmkURL('http://digg.com/submit?','url', document.location.href, 'title', document.title);"
                                                                                                                    style="margin-right: 5px;">
                                                                                                                    <img height="16" width="16" src="images/digg.png" border="0" alt="Digg" title="Digg" /></a></li>                                                                                                                
                                                                                                                <li style="display: inline; cursor: pointer;"><a onclick="return bmkURL('http://www.google.com/bookmarks/mark?op=edit&','bkmk', document.location.href,'title', document.title);"
                                                                                                                    style="margin-right: 5px;">
                                                                                                                    <img height="16" width="16" border="0" src="images/google.png" alt="Google Bookmark"
                                                                                                                        title="Google Bookmark" /></a></li>
                                                                                                                <li style="display: inline; cursor: pointer;"><a onclick="return bmkURL('http://reddit.com/submit?','url', document.location.href, document.title);"
                                                                                                                    style="margin-right: 5px;">
                                                                                                                    <img height="16" width="16" src="images/reddit.png" border="0" alt="Reddit" title="Reddit" /></a></li>
                                                                                                                <li style="display: inline; cursor: pointer;"><a onclick="return bmkURL('http://technorati.com/faves?','add', document.location.href, document.title);"
                                                                                                                    style="margin-right: 5px;">
                                                                                                                    <img height="16" width="16" src="images/technorati.png" border="0" alt="Technorati"
                                                                                                                        title="Technorati" /></a></li>
                                                                                                                <li style="display: inline; cursor: pointer;"><a onclick="return bmkURL('http://bookmarks.yahoo.com/toolbar/savebm?','u', document.location.href, document.title);"
                                                                                                                    style="margin-right: 5px;">
                                                                                                                    <img height="16" width="16" src="images/yahoo.png" border="0" alt="Yahoo Bookmark"
                                                                                                                        title="Yahoo Bookmark" /></a></li>
                                                                                                            </ul>
                                                                                                        </div>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </tbody>
                                                                                        </table>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                    <td class="ppmainrightline" width="10">
                                                                        <img src="images/pixel.gif" width="12" height="12" alt="" />
                                                                    </td>
                                                                </tr>
                                                                <tr style="height: 10px;">
                                                                    <td align="left" style="width: 12px; height: 12px; background-image: url(images/main_botleft.gif);
                                                                        background-repeat: no-repeat;">
                                                                    </td>
                                                                    <td class="ppmainbotline" style="height: 12px;">
                                                                    </td>
                                                                    <td align="right" style="width: 12px; height: 12px; background-image: url(images/main_botright.gif);
                                                                        background-repeat: no-repeat;">
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <img src="images/spacer.gif" width="1" height="5" alt="" />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div id="divProdottiAllegati" runat="server" visible="false">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr>
                                <td valign="top" width="100%">
                                    <table border="0" cellspacing="0" cellpadding="0" style="width: 100%; height: 35px;
                                        background-color: #cddded;">
                                        <tbody>
                                            <tr>
                                                <td align="left" class="topLeftStyle">
                                                </td>
                                                <td align="center">
                                                    <h2>
                                                        Potrebbe interessarti anche..
                                                    </h2>
                                                </td>
                                                <td align="right" class="topRightStyle">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td class="yellow_left" width="12">
                                                </td>
                                                <td class="bodycopy">
                                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td align="center">
                                                                    &nbsp;
                                                                    <asp:UpdatePanel ID="updPnlProdottiAllegati" runat="server" UpdateMode="Conditional">
                                                                        <ContentTemplate>
                                                                            <asp:DataList ID="dtlProdottiAllegati" runat="server" GridLines="None" RepeatColumns="2"
                                                                                RepeatDirection="Horizontal" CellPadding="0" CellSpacing="0" OnItemCommand="dtlProdottiAllegati_ItemCommand">
                                                                                <ItemTemplate>
                                                                                    <table border="0" cellspacing="1" cellpadding="0" style="width: 260px; height: 190px;
                                                                                        padding: 0; margin-bottom: 10px;">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td class="small_text" valign="top" align="center" style="padding-top: 5px;">
                                                                                                    <a href="Dettaglio-Prodotto.aspx?Categoria=<%= CurrentIDCategoria %>&amp;Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                                        title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%>">
                                                                                                        <b>
                                                                                                            <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%></b></a><br />
                                                                                                    <span class="large_text" style="text-align: left; margin-top: 5px; padding-left: 4px;">
                                                                                                        <%# TagliaStringa(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrizioneLunga)%></span>
                                                                                                    <br />
                                                                                                </td>
                                                                                                <td valign="top">
                                                                                                    <a href='Dettaglio-Prodotto.aspx?Categoria=<%= CurrentIDCategoria %>&amp;Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>'
                                                                                                        title="">
                                                                                                        <img src="<%= UrlImmagine %><%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).UrlImmagine%>"
                                                                                                            alt="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>"
                                                                                                            title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>"
                                                                                                            border="0" width="80px" height="80px" /></a>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td valign="top" colspan="2" align="center" style="height: 50px;">
                                                                                                    <table cellpadding="0" cellspacing="0" width="90%" style="border-color: black; border-width: 0px;
                                                                                                        border-style: solid; display: <%# IsOfferta(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Prezzo,((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale)%>;">
                                                                                                        <tbody>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <span class="small_text"><b>Prezzo:</b></span>
                                                                                                                </td>
                                                                                                                <td align="right">
                                                                                                                    <span class="price_medium_black" style="text-decoration: line-through;">€
                                                                                                                        <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Prezzo%></span>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <span class="small_text"><b>Prezzo scontato:</b></span>
                                                                                                                </td>
                                                                                                                <td align="right">
                                                                                                                    <span class="price_medium">€
                                                                                                                        <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale%></span>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                    <table cellpadding="0" cellspacing="0" width="90%" style="border-color: #90989a;
                                                                                                        border-width: 0px; border-style: solid; display: <%# IsNotOfferta(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Prezzo,((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale)%>;">
                                                                                                        <tbody>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <span class="small_text"><b>Prezzo:</b></span>
                                                                                                                </td>
                                                                                                                <td align="right">
                                                                                                                    <span class="price_medium">€
                                                                                                                        <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale%></span>
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                    <table border="0" cellspacing="1" cellpadding="1" width="100%">
                                                                                                        <tbody>
                                                                                                            <tr>
                                                                                                                <td>
                                                                                                                    <img src="images/pixel.gif" width="1" height="20" alt="" />
                                                                                                                </td>
                                                                                                                <td valign="middle" align="right">
                                                                                                                    <asp:Button class="standardsubmit" ID="btnAcquista" CommandName="ACQUISTA" CommandArgument="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                                                        runat="server" Text="Acquista" Style="cursor: pointer;" ToolTip="Inserisci il prodotto nel carrello" />
                                                                                                                    <asp:Button class="standardsubmit" ID="btnDettagliProd" CommandName="DETTAGLI" runat="server"
                                                                                                                        CommandArgument="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                                                        Text="Dettagli" Style="cursor: pointer;" ToolTip="Guarda i dettagli del prodotto" />
                                                                                                                </td>
                                                                                                                <td>
                                                                                                                    <img src="images/pixel.gif" width="1" height="20" alt="" />
                                                                                                                </td>
                                                                                                            </tr>
                                                                                                        </tbody>
                                                                                                    </table>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="center" valign="middle" colspan="2" style="height: 10px;">
                                                                                                    <hr style="background-color: Red; width: 65%; height: 3px;" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </ItemTemplate>
                                                                            </asp:DataList>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </td>
                                                <td class="yellow_right" width="12">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" style="width: 12px; height: 12px; background-image: url(images/main_botleft.gif);
                                                    background-repeat: no-repeat;">
                                                    &nbsp;
                                                </td>
                                                <td class="ppmainbotline" style="height: 12px;">
                                                </td>
                                                <td align="right" style="width: 12px; height: 12px; background-image: url(images/main_botright.gif);
                                                    background-repeat: no-repeat;">
                                                    &nbsp;
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </td>
            <td>
                <img src="images/pixel.gif" width="5px" height="1px" alt="" />
            </td>
            <td valign="top">
                <UserControl:Registrazione ID="regist" runat="server" />
                <UserControl:Newsletter ID="WidgetNewsletter" runat="server" />
                <UserControl:Foto ID="WidgetFoto" runat="server" Visible="false" />
                <UserControl:Carrello ID="usrCarrello" runat="server" />
                <UserControl:Assistenza ID="WidgetAssistenza" runat="server" />
                <UserControl:Perbaffo ID="WidgetPerbaffo" runat="server" />
                <UserControl:PerbaffoWorld ID="WidgetPerbaffoWorld" runat="server" />
                <UserControl:News ID="Notizie" runat="server" />
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
