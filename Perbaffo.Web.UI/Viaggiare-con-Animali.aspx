<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Viaggiare-con-Animali.aspx.cs"
    Inherits="Perbaffo.Web.UI.Viaggiare_con_Animali" %>

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
                                    Viaggiare con animali</h1>
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
                                                                    <li><a href="#viaggire-con-cane-e-gatto" class="dark_red" style="font-size: 12;"
                                                                        title="Viaggiare in auto con il vostro cane o gatto">Viaggiare in auto con il vostro
                                                                        cane o gatto</a></li>
                                                                </ul>
                                                            </td>
                                                            <td valign="bottom" width="12" align="right" style="background-image: url(images/botright.gif);
                                                                background-repeat: no-repeat; background-position: bottom;">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <br />
                                                <a name="viaggire-con-cane-e-gatto"></a>
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
                                                                <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>
                                                                                <h2>
                                                                                    Viaggiare in auto con il vostro cane o gatto</h2>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="med_text_dodici" style="color: Black;">Le modalità di trasporto degli animali
                                                                                    in auto sono regolamentate dall'<strong>articolo 169 del Codice Stradale</strong>
                                                                                    (D.Lgs. 285/1992) che stabilisce che:
                                                                                    </span>
                                                                                    <br />
                                                                                    <ul>
                                                                                        <li>è consentito trasportare un solo animale in auto libero nell'abitacolo purchè non
                                                                                            disturbi o distragga il conducente </li>
                                                                                        <li>due o più animali trasportati in auto devono viaggiare in apposite <a href="http://www.perbaffo.it/Dettaglio-Categoria.aspx?Categoria=77"
                                                                                            title="gabbie" target="_blank">gabbie</a> o nel vano posteriore dell'auto separato
                                                                                            da una apposita <a href="http://www.perbaffo.it/Dettaglio-Categoria.aspx?Categoria=76"
                                                                                                title="rete divisoria" target="_blank">rete divisoria</a></li>
                                                                                    </ul>
                                                                                    <span class="med_text_dodici" style="color: Black;">
                                                                                    Chi trasporta gli animali in modo non idoneo rischia una multa tra i <strong>71 e i
                                                                                        286 Euro</strong> e la perdita di <strong>un punto</strong> dalla patente.<br />
                                                                                    <br />
                                                                                    Quando portiamo il nostro cane in auto bisogna assegnargli una sistemazione comoda
                                                                                    e sicura, sia per il cane che per il guidatore.<br />
                                                                                    <br />
                                                                                    Lasciarlo libero nell’abitacolo è pericoloso non solo perché il cane potrebbe distrarci
                                                                                    mentre guidiamo ma anche perché in caso di incidente verrebbe sbalzato via dal sedile.
                                                                                    Pertanto se decidiamo di fare viaggiare il nostro cane o gatto sul sedile posteriore
                                                                                    la soluzione migliore è utilizzare le apposite <a href="http://www.perbaffo.it/Dettaglio-Categoria.aspx?Categoria=74"
                                                                                        title="cinture di sicurezza" target="_blank">cinture di sicurezza</a>.<br />
                                                                                    <br />
                                                                                    Se decidiamo di trasportarlo nel bagagliaio potrete utilizzare i <a href="http://www.perbaffo.it/Dettaglio-Categoria.aspx?Categoria=77"
                                                                                        title="kennel - gabbie da trasporto" target="_blank">kennel</a>: queste robuste gabbie li proteggono
                                                                                    meglio in caso di incidenti. Inoltre un cane che subisce un incidente in auto molto
                                                                                    spesso è talmente spaventato che non appena trova una via di fuga scappa mettendosi
                                                                                    in grave pericolo e rischiando di venire investito o di perdersi.
                                                                                    <br />
                                                                                    <br />
                                                                                    È consigliabile che il vostro animale sia stomaco vuoto durante i viaggi.<br />
                                                                                    <br />
                                                                                    È indispensabile tenere sempre a portata di mano una ciotola e una abbondante scorta
                                                                                    di acqua. Esistono diversi modelli di <a href="http://www.perbaffo.it/Dettaglio-Categoria.aspx?Categoria=82"
                                                                                        title="Ciotole da viaggio" target="_blank">ciotole da viaggio</a>, in nylon
                                                                                    pieghevoli o in plastica con dispenser per l’acqua o pieghevoli in silicone.
                                                                                    <br />
                                                                                    <br />
                                                                                    Bisogna effettuare frequenti soste in modo che il cane possa sgranchirsi le zampe
                                                                                    e dissetarsi.
                                                                                    <br />
                                                                                    <br />
                                                                                    Se si viaggia in periodi caldi bisogna tenere il finestrino leggermente abbassato
                                                                                    in modo da far circolare l'aria, evitiamo però che il cane metta la testa fuori
                                                                                    perché un colpo d'aria potrebbe causargli una dolorosa otite. A tal fine sono disponibili
                                                                                    <a href="http://www.perbaffo.it/Dettaglio-Prodotto.aspx?Categoria=76&amp;Prodotto=1031"
                                                                                        title="Griglie di aereazione" target="_blank">griglie di aereazione</a> che
                                                                                    per mettono il riciclo dell’aria ma impediscono al vostro cane di mettere la testa
                                                                                    fuori dal finestrino</span><br />
                                                                                &nbsp;
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                            <td valign="bottom" width="12" align="right" style="background-image: url(images/botright.gif);
                                                                background-repeat: no-repeat; background-position: bottom;">
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
