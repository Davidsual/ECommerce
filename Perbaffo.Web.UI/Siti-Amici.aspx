<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Siti-Amici.aspx.cs" Inherits="Perbaffo.Web.UI.Siti_Amici" %>

<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="UserControl" %>
<%@ Register Src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffo.ascx" TagName="Perbaffo" TagPrefix="UserControl" %>
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

    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>

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
                <table border="0" cellspacing="0" cellpadding="0" style="width: 590px; background-color: #cddded;
                    height: 35px;">
                    <tbody>
                        <tr>
                            <td align="left" class="topLeftStyle">
                            </td>
                            <td rowspan="2" align="right">
                                <h1>
                                    <asp:Label ID="lblTitoloPagina" runat="server" Text=""></asp:Label></h1>
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
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td width="12" class="yellow_left" bgcolor="#f5f5f5">
                            </td>
                            <td>
                                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <a name="menu"></a><a href="http://www.Perbaffo.it" title="Perbaffo.it" target="_blank">
                                                    <img src="images/Banner/banner_perbaffo_468_x_60.gif" alt="Banner di Perbaffo" width="468"
                                                        height="60" style="border: 0px;" /></a><br />
                                                <span class="small_text">In questa sezione si trovano i link e i banner di negozi,forum,blog.</span><br />
                                                <span class="small_text">Per chi fosse interessato a fare uno scambio link/banner scriva
                                                    a quest'indirizzo <a href="mailto:info@perbaffo.it?subject=Scambio Link" title="Contattaci - Scambio banner">
                                                        info@perbaffo.it</a></span>
                                                <table border="0" cellspacing="0" cellpadding="0" width="90%" style="margin-top: 10px;
                                                    background-color: #CDDDED;">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left" class="topLeftStyle">
                                                            </td>
                                                            <td class="bodycopy">
                                                            </td>
                                                            <td align="right" class="topRightStyle">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="bottom" width="12" align="right" style="background-image: url(images/botleft.gif);
                                                                background-repeat: no-repeat;">
                                                            </td>
                                                            <td align="left" valign="top">
                                                                <asp:Label ID="lblScambioBannerTitolo" runat="server" Text="" CssClass="small_text"></asp:Label>
                                                            </td>
                                                            <td valign="bottom" width="12" align="right" style="background-image: url(images/botright.gif);
                                                                background-repeat: no-repeat;">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <br />
                                                <table border="0" cellspacing="0" cellpadding="0" width="90%" style="margin-top: 10px;
                                                    background-color: #CDDDED;">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left" class="topLeftStyle">
                                                            </td>
                                                            <td class="bodycopy">
                                                            </td>
                                                            <td align="right" class="topRightStyle">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="bottom" width="12" align="right" style="background-image: url(images/botleft.gif);
                                                                background-repeat: no-repeat; background-position: bottom;">
                                                            </td>
                                                            <td align="left">
                                                                <ul>
                                                                    <li><a href="Siti-Amici.aspx?Link=Informazioni" class="dark_red" style="font-size: 12;"
                                                                        title="Link informazioni sugli animali">Informazioni sugli animali</a></li>
                                                                    <li><a href="Siti-Amici.aspx?Link=Forum" class="dark_red" style="font-size: 12;"
                                                                        title="Link Forum">Forum</a></li>
                                                                    <li><a href="Siti-Amici.aspx?Link=Blog" class="dark_red" style="font-size: 12;" title="Link Blog">
                                                                        Blog</a></li>
                                                                    <li><a href="Siti-Amici.aspx?Link=Negozi" class="dark_red" style="font-size: 12;"
                                                                        title="Link Negozi">Negozi</a></li>
                                                                    <li><a href="Siti-Amici.aspx?Link=Varie" class="dark_red" style="font-size: 12;"
                                                                        title="Link Varie">Varie</a></li>
                                                                    <li><a href="Siti-Amici.aspx?Link=Allevamenti" class="dark_red" style="font-size: 12;"
                                                                        title="Link Allevamenti">Allevamenti</a></li>
                                                                </ul>
                                                            </td>
                                                            <td valign="bottom" width="12" align="right" style="background-image: url(images/botright.gif);
                                                                background-repeat: no-repeat; background-position: bottom;">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <br />
                                                <table id="tblInfo" runat="server" visible="true" class="boundingbox" border="0"
                                                    cellspacing="0" cellpadding="30" style="margin: 20 0 0 0; width: 540px">
                                                    <tbody>
                                                        <tr>
                                                            <td class="bodycopyy">
                                                                <a name="Informazioni"></a>
                                                                <p>
                                                                    <a href="http://www.Inseparabile.com" title="Inseparabile.com" target="_blank">
                                                                        <img border="0" src="images/ScambioLink/Banner-Inseparabile.jpg" width="472" height="64"
                                                                            alt="Banner Inseparabile.com" /></a></p>
                                                                <p>
                                                                    <a href="http://www.qualazampa.it" title="Quà la zampa" target="_blank">
                                                                        <img border="0" src="http://www.qualazampa.it/zampapiccolo.gif" width="120" height="60"
                                                                            alt="Qua la zampa" /></a></p>
                                                                <p>
                                                                    <a href="http://www.gattolandia.com" title="Gattolandia" target="_blank">
                                                                        <img border="0" src="images/ScambioLink/Banner-Gattolandia.jpg" width="141" height="34"
                                                                            alt="Gattolandia" /></a></p>
                                                                <p>
                                                                    <a href="http://www.CatBook.it" title="CatBook" target="_blank">
                                                                        <img border="0" src="http://www.catbook.it/catbook2.jpg" width="120" height="60"
                                                                            alt="CatBook" /></a></p>
                                                                <p>
                                                                    <a href="http://www.neogea.it" title="NeoGea la libreria degli animali" target="_blank">
                                                                        <img border="0" src="http://i295.photobucket.com/albums/mm135/silvia3891/B1.jpg"
                                                                            width="400" height="158" alt="NeoGea la libreria degli animali" /></a></p>
                                                                <p>
                                                                    <a href="http://www.chihuahuaclub.it/forum/" title="Chihuahua Club" target="_blank">
                                                                        <img border="0" src="http://www.chihuahuaclub.it/forum/styles/prosilver/theme/images/banner.gif"
                                                                            width="478" height="85" alt="Chihuahua Club" /></a></p>
                                                                <br />
                                                                <p>
                                                                    <a href="http://educailcane.jimdo.com/" title="L'Educazione del cane" target="_blank">
                                                                        <img border="0" src="Images/ScambioLink/bannergrande.jpg" width="467" height="59"
                                                                            alt="L'Educazione del cane" /></a></p>
                                                                <br />
                                                                <a href="#menu">[Torna su]</a>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <table id="tblForum" runat="server" visible="false" class="boundingbox" border="0"
                                                    cellspacing="0" cellpadding="30" style="margin: 20 0 0 0; width: 540px">
                                                    <tbody>
                                                        <tr>
                                                            <td class="bodycopyy">
                                                                <a name="Forum"></a>
                                                                <p>
                                                                    <a href="http://canibeagle.altervista.org/" title="Cani Beagle" target="_blank">
                                                                        <img border="0" src="images/ScambioLink/Banner-Cani-Beagle.jpg" width="472" height="64"
                                                                            alt="Cani Beagle" /></a></p>
                                                                <p>
                                                                    <a href="http://retrievers.forumattivo.com/" title="Cani All Retrievers" target="_blank">
                                                                        <img border="0" src="images/ScambioLink/Banner-All-Retrievers.jpg" width="254" height="58"
                                                                            alt="Cani All Retrievers" /></a></p>
                                                                <p>
                                                                    <a href="http://bouledogue.forumfree.net/" title="Bouledogue forumfree" target="_blank">
                                                                        <img border="0" src="images/ScambioLink/bannerinoforum.gif" width="88" height="31"
                                                                            alt="Bouledogue forumfree" /></a></p>
                                                                <br />
                                                                <a href="#menu">[Torna su]</a>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <table id="tblBlog" runat="server" visible="false" class="boundingbox" border="0"
                                                    cellspacing="0" cellpadding="30" style="margin: 20 0 0 0; width: 540px">
                                                    <tbody>
                                                        <tr>
                                                            <td class="bodycopyy">
                                                                <a name="Blog"></a>
                                                                <p>
                                                                    <a href="http://gliangelidipasquale.blogspot.com/" title="Gli Angeli di Pasquale"
                                                                        target="_blank">
                                                                        <img border="0" src="Images/ScambioLink/Banner_Angeli_di_pasquale.jpg" width="450"
                                                                            height="86" alt="Gli Angeli di Pasquale" /></a></p>
                                                                <a href="#menu">[Torna su]</a>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <table id="tblNegozi" runat="server" visible="false" class="boundingbox" border="0"
                                                    cellspacing="0" cellpadding="30" style="margin: 20 0 0 0; width: 540px">
                                                    <tbody>
                                                        <tr>
                                                            <td class="bodycopyy">
                                                                <a name="Negozi"></a>
                                                                <p>
                                                                    <a href="http://xsp.forumfree.net/?t=27558758" title="Il mercatino di Simona" target="_blank">
                                                                        <img border="0" src="images/ScambioLink/Banner-Mercatino-di-Simona.jpg" width="427"
                                                                            height="201" alt="Il mercatino di Simona" /></a></p>
                                                                <p>
                                                                    <a href="http://baffiecode.forumattivo.com/" title="Forum Baffi e Code" target="_blank">
                                                                        <img border="0" src="images/ScambioLink/Banner-Forum-Baffi-Code.jpg" width="304"
                                                                            height="64" alt="Forum Baffi e Code" /></a></p>
                                                                <br />
                                                                <a href="#menu">[Torna su]</a>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <table id="tblVarie" runat="server" visible="false" class="boundingbox" border="0"
                                                    cellspacing="0" cellpadding="30" style="margin: 20 0 0 0; width: 540px">
                                                    <tbody>
                                                        <tr>
                                                            <td class="bodycopyy">
                                                                <a name="Varie"></a>
                                                                 <p>
                                                                    
                                                                    <a href="http://www.alberghitipiciriminesi.it" title="Alberghi Riminesi" target="_blank"><b>La vacanza a Rimini con i vostri amici animali</b><br />
                                                                        <img border="0" src="images/ScambioLink/cani.gif" width="400" height="150"
                                                                            alt="Alberghi Riminesi" /></a></p>
                                                                <p>
                                                                    <a href="http://www.trovaofferte.net/" title="Trova offerte" target="_blank">
                                                                        <img border="0" src="images/ScambioLink/Banner-Trova-Offerte.jpg" width="104" height="64"
                                                                            alt="Trova offerte" /></a></p>
                                                                <p>
                                                                    <a href="http://www.viagginrete-it.it/" title="Viagginrete" target="_blank">
                                                                        <img border="0" src="images/ScambioLink/Banner-Viagginrete.jpg" width="154" height="49"
                                                                            alt="Viagginrete" /></a></p>
                                                                <p>
                                                                    <a href="http://www.shopmania.it/" title="ShopMania" target="_blank">
                                                                        <img border="0" src="images/ScambioLink/Banner-ShopMania.jpg" width="178" height="34"
                                                                            alt="ShopMania" /></a></p>
                                                                <p>
                                                                    <a href="http://recensionando.bestwebsite.it/" target="_blank">Best Web Site</a></p>
                                                                <p>
                                                                    <a href="http://www.allaricerca.net" target="_blank">Allaricerca.net</a></p>
                                                                <p>
                                                                    <a href="http://www.nelweb.biz" title="nelWeb" target="_blank">NelWeb</a></p>
                                                                <p>
                                                                    <a href="http://www.yoweb.it" title="Directory Italiana" target="_blank">Yoweb.it</a></p>
                                                                                                                                    
                                                                <br />
                                                                <a href="#menu">[Torna su]</a>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <table id="tblAllevamenti" runat="server" visible="false" class="boundingbox" border="0"
                                                    cellspacing="0" cellpadding="30" style="margin: 20 0 0 0; width: 540px">
                                                    <tbody>
                                                        <tr>
                                                            <td class="bodycopyy">
                                                                <a name="Allevamenti"></a>
                                                                <p>
                                                                    <a href="http://www.dolcechihuahua.it/" title="DOLCECHIHUAHUA" target="_blank">
                                                                        <img border="0" src="images/ScambioLink/Banner-dolcechihuahua.jpg" width="200" height="150"
                                                                            alt="DOLCECHIHUAHUA" /></a></p>
                                                                            
<p>
                                                                    <a href="http://betulladifreya.com/" title="Allevamento Betulla di Freya" target="_blank">
                                                                        <img border="0" src="http://betulladifreya.com/img_locale/banner.png" width="354" height="111"
                                                                            alt="Allevamento Betulla di Freya" /></a></p>                                                                              
                                                                <br />
                                                                <a href="#menu">[Torna su]</a>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                            <td width="12" align="right" class="yellow_right">
                            </td>
                        </tr>
                        <tr>
                            <td valign="bottom" align="left" class="bottomLeftStyle">
                            </td>
                            <td class="yellow_bottom">
                            </td>
                            <td valign="bottom" align="right" class="bottomRightStyle">
                            </td>
                        </tr>
                    </tbody>
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
