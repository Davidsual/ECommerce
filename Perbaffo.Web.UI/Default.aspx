<%@ Page Language="C#" Async="true" AutoEventWireup="true" EnableViewState="false"
    CodeBehind="Default.aspx.cs" Inherits="Perbaffo.Web.UI.Default" %>

<%@ Register src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffo.ascx" TagName="Perbaffo" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="UserControl" %>
<%@ Register Src="WidgetFoto.ascx" TagName="Foto" TagPrefix="UserControl" %>
<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
<%@ Register Src="MenuCategorie.ascx" TagName="Menu" TagPrefix="UserControl" %>
<%@ Register Src="WidgetCarrello.ascx" TagName="Carrello" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNews.ascx" TagName="News" TagPrefix="UserControl" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Perbaffo: Articoli per cani, gatti, roditori, ornitologia e acquariologia</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="shortcut icon" href="images/favicon.ico" />
    <meta name="Title" content="Perbaffo: Articoli per cani, gatti, roditori, ornitologia e acquariologia" /> 
    <meta name="keywords" content="Articoli per animali, tiragraffi, collari per cani, cucce per cani, guinzagli, cibo per animali, gabbie, pettorine, trasportini per animali, abbigliamento per cani, lettiere,recinti, acquari, roditori,cibo per gatti,alimentazione per animali" />    
    <meta name="description" content="Perbaffo, articoli e prodotti per cani, gatti, roditori e ornitologia. Per ogni ordine hai diritto ad un omaggio." />
    <meta name="Robots" content="index,follow" />
    <meta name="robots" content="noarchive" /> 
    <meta name="Author" content="Davide Trotta" />
    <meta name="google-site-verification" content="XtK1QsvCXqtl-ubjyFomTJHeS98kviPlkK-r5xZMBow" />
    <meta name="verify-v1" content="pX0eUkr1MfoJSd2BDCJ5A5GuSVxZtkUehmpHz8svgEA=" /> 
    <meta name="y_key" content="14607de736186a24" />
    <meta name="msvalidate.01" content="239F36FEFD6B9CB311B9D2F36A948A90" />
    <link rel="alternate" type="application/rss+xml" title="RSS" href="RssHandler.ashx" />
    <link rel="Stylesheet" type="text/css" href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=3" />
    <script language="javascript" type="text/javascript" src="HttpCombinerHandler.ashx?s=Set_Javascript&amp;t=text/javascript&amp;v=2"></script>
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
        try
        {
            $(document).ready(function() {

                    $('#divImages').crossSlide({
                                sleep: 3,
                                fade: 1
                            }, <%= ListFoto %>);

            });  
            
//             $(document).ready(function() {
//                $('#divImagesBanner').crossSlide({
//                        sleep: 2,
//                        fade: 1
//                    }, [
//                          { src: 'images/Banner/Banner1.gif' },
//                          { src: 'images/Banner/banner2.gif' },
//                          { src: 'images/Banner/banner5.gif' },
//                          { src: 'images/Banner/banner3.gif' },
//                          { src: 'images/Banner/banner4.gif' }
//                        ]);
//            }); 
            
         }
         catch (err) {
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
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="center" valign="top" height="200px">
				            
                            <img src="images/Banner/banner-perbaffo.gif" title="Perbaffo E-Commerce" alt="Perbaffo prodotti per animali" width="550px" height="200px" style="border:0px;" />
				            
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="bodycopyx2" valign="top" colspan="3">
                            Benvenuto su Perbaffo.it,<strong> il Pet Shop online per animali</strong>, garantisce i <strong>prezzi
                                più bassi</strong> su tutti i prodotti. Qui puoi trovare articoli e prodotti
                            per cani e gatti ,roditori,volatili e acquarologia. In più ad ogni ordine potrai
                            scegliere un <strong>omaggio</strong>. Senza contare la sempre presente assistenza
                            clienti.
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <img src="images/pixel.gif" width="5px" height="10px" alt="" />
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" class="headerCellContorno">
                                <tr>
                                    <td align="left" class="topLeftStyle">
                                    </td>
                                    <td align="center" valign="bottom">
                                        <h2>
                                            <b>In offerta</b></h2>
                                    </td>
                                    <td align="right" class="topRightStyle">
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="yellow_left" width="11">
                                    </td>
                                    <td class="bodycopy">
                                        <asp:Repeater ID="rptPiuVenduti" runat="server">
                                            <ItemTemplate>
                                                <table width="100%" border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <img src="images/spacer.gif" width="1px" height="1px" alt="" />
                                                        </td>
                                                        <td valign="top">
                                                            <table border="0" cellpadding="3" cellspacing="0" width="100%">
                                                                <tr>
                                                                    <td>
                                                                        <a href="Dettaglio-Prodotto.aspx?Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                            title="">
                                                                            <img src="<%= UrlImmagine %><%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).UrlImmagine%>"
                                                                                alt="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>"
                                                                                title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>"
                                                                                border="0" width="80px" height="80px" /></a>
                                                                    </td>
                                                                    <td>
                                                                        <table>
                                                                            <tr>
                                                                                <td valign="top" class="bodycopyx">
                                                                                    <a href="Dettaglio-Prodotto.aspx?Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                        title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%>">
                                                                                        <b>
                                                                                            <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%></b></a>
                                                                                    <br />
                                                                                    <table cellpadding="1" cellspacing="0" width="100%" style="border-color: black; border-width: 0px;
                                                                                        border-style: solid;">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <span class="small_text"><b>Prezzo:</b></span>
                                                                                                </td>
                                                                                                <td align="right">
                                                                                                    <span class="price_large_black" style="text-decoration: line-through;">€
                                                                                                        <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Prezzo%></span>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <span class="small_text"><b>Prezzo scontato:</b></span>
                                                                                                </td>
                                                                                                <td align="right">
                                                                                                    <span class="price_large">€
                                                                                                        <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale%></span>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        &nbsp;
                                    </td>
                                    <td class="yellow_right" width="11" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="bottomLeftStyle">
                                    </td>
                                    <td class="yellow_bottom" style="height: 12px;">
                                    </td>
                                    <td align="right" class="bottomRightStyle">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="images/spacer.gif" width="1px" height="5px" alt="" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <img src="images/pixel.gif" width="5px" height="1px" alt="" />
                        </td>
                        <td width="50%" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" class="headerCellContorno">
                                <tr>
                                    <td align="left" class="topLeftStyle">
                                    </td>
                                    <td align="center" valign="bottom">
                                        <h2>
                                            <b>Gli amici di Perbaffo</b></h2>
                                    </td>
                                    <td align="right" class="topRightStyle">
                                    </td>
                                </tr>
                            </table>
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="yellow_left" width="11">
                                    </td>
                                    <td class="bodycopy" align="center" valign="middle">
                                        <div id="divImages" style="width: 240px; height: 240px;">
                                            Caricamento…</div>
                                    </td>
                                    <td class="yellow_right" width="11" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" class="bottomLeftStyle">
                                    </td>
                                    <td class="yellow_bottom" style="height: 12px;">
                                    </td>
                                    <td align="right" class="bottomRightStyle">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <img src="images/spacer.gif" width="1px" height="5px" alt="" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" class="headerCellContorno">
                    <tr>
                        <td align="left" class="topLeftStyle">
                        </td>
                        <td align="center" valign="bottom">
                            <h2>
                                <b>Vetrina</b></h2>
                        </td>
                        <td align="right" class="topRightStyle">
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="590px">
                    <tr>
                        <td class="ppmainleftline" width="11">
                        </td>
                        <td class="bodycopyx">
                            <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                <tr>
                                    <td>
                                        <img src="images/spacer.gif" width="1px" height="5px" alt="" />
                                    </td>
                                </tr>
                                <asp:Repeater ID="rptVetrina" runat="server" OnItemDataBound="rptVetrina_ItemDataBound">
                                    <ItemTemplate>
                                        <tr>
                                            <td colspan="5">
                                                <img src="images/spacer.gif" width="1px" height="5px" alt="" />
                                            </td>
                                        </tr>
                                        <asp:Repeater ID="rptRigaVetrina" runat="server" EnableViewState="false">
                                            <HeaderTemplate>
                                                <tr>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <td width="20%" valign="top">
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="center">
                                                                <a href="Dettaglio-Prodotto.aspx?Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                    title="">
                                                                    <img src="<%= UrlImmagine %><%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).UrlImmagine%>"
                                                                        alt="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>"
                                                                        title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>"
                                                                        border="0" width="80px" height="80px" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" class="bodycopyx">
                                                                <span class="small_text"><a href="Dettaglio-Prodotto.aspx?Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                    title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%>">
                                                                    <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%>
                                                                </a></span>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tr>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </td>
                        <td class="ppmainrightline" width="11" align="right">
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
                    <tr>
                        <td colspan="3">
                            <img src="images/spacer.gif" width="1px" height="5px" alt="" />
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" class="headerCellContorno">
                    <tr>
                        <td align="left" class="topLeftStyle">
                        </td>
                        <td align="center" valign="bottom">
                            <h2>
                                <b>Novità</b></h2>
                        </td>
                        <td align="right" class="topRightStyle">
                        </td>
                    </tr>
                </table>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td class="ppmainleftline" width="10">
                            <img src="images/pixel.gif" height="12" width="12" alt="" />
                        </td>
                        <td class="bodycopy">
                            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                <tr>
                                    <td class="bodycopyx" valign="top" width="280" align="center">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr>
                                                    <td valign="top" align="center" style="height: 80px;">
                                                        <h2>
                                                            <a href="#" title="" runat="server" id="NomeProdottoNovita1"></a>
                                                            <br />
                                                            <asp:Label ID="lblPrezzo1" runat="server" Text="" Style="color: #ad0e2a;"></asp:Label></h2>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" align="center">
                                                        <a href="#" title="" runat="server" id="NomeProdottoImmagine1">
                                                            <asp:Image ID="imgProdotto1" Width="80" Height="80" BorderWidth="0px" runat="server"
                                                                AlternateText="" />
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" align="center">
                                                        <asp:Label ID="lblDescrizioneProdotto1" runat="server" Text="" CssClass="small_text"></asp:Label><br />
                                                        <span id="lblDataInseriemnto1" runat="server" class="small_text"></span>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                    <td width="10">
                                        <img src="images/pixel.gif" height="10" width="10" alt="" />
                                    </td>
                                    <td class="ppmainleftline" width="12">
                                        <img src="images/pixel.gif" height="12" width="12" alt="" />
                                    </td>
                                    <td class="bodycopyx" valign="top" width="280" align="center">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr>
                                                    <td valign="top" align="center" style="height: 80px;">
                                                        <h2>
                                                            <a href="#" title="" runat="server" id="NomeProdottoNovita2"></a>
                                                            <br />
                                                            <asp:Label ID="lblPrezzo2" runat="server" Text="" Style="color: #ad0e2a;"></asp:Label></h2>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" align="center">
                                                        <a href="#" title="" runat="server" id="NomeProdottoImmagine2">
                                                            <asp:Image ID="imgProdotto2" Width="80" Height="80" BorderWidth="0px" runat="server"
                                                                AlternateText="" />
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" align="center">
                                                        <asp:Label ID="lblDescrizioneProdotto2" runat="server" Text="" CssClass="small_text"></asp:Label><br />
                                                        <span id="lblDataInseriemnto2" runat="server" class="small_text"></span>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                    <td width="10">
                                        <img src="images/pixel.gif" height="10" width="10" alt="" />
                                    </td>
                                    <td class="ppmainleftline" width="12">
                                        <img src="images/pixel.gif" height="12" width="12" alt="" />
                                    </td>
                                    <td class="bodycopyx" valign="top" width="280" align="center">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr>
                                                    <td valign="top" align="center" style="height: 80px;">
                                                        <h2>
                                                            <a href="#" title="" runat="server" id="NomeProdottoNovita3"></a>
                                                            <br />
                                                            <asp:Label ID="lblPrezzo3" runat="server" Text="" Style="color: #ad0e2a;"></asp:Label></h2>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" align="center">
                                                        <a href="#" title="" runat="server" id="NomeProdottoImmagine3">
                                                            <asp:Image ID="imgProdotto3" Width="80" Height="80" BorderWidth="0px" runat="server"
                                                                AlternateText="" />
                                                        </a>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" align="center">
                                                        <asp:Label ID="lblDescrizioneProdotto3" runat="server" Text="" CssClass="small_text"></asp:Label><br />
                                                        <span id="lblDataInseriemnto3" runat="server" class="small_text"></span>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="ppmainrightline" width="10">
                            <img src="images/pixel.gif" height="12" width="12" alt="" />
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
                    <tr>
                        <td>
                            <img src="images/spacer.gif" width="1px" height="5px" alt="" />
                        </td>
                    </tr>
                </table>
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
