<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Scelta-della-taglia.aspx.cs"
    Inherits="Perbaffo.Web.UI.Scelta_della_taglia" %>

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
    <meta name="keywords" content="<%=KeywordsPagina %>" />
    <meta name="description" content="<%=DescrizionePagina %>" />
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
                                    Guida alla scelta delle taglie</h1>
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
                                                                <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>
                                                                                <h2>
                                                                                    Come scegliere la taglia giusta</h2>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="med_text_dodici" style="color: Black;">Le misure vanne prese con un metro
                                                                                    morbido come quelli da sarta. </span>
                                                                                    <br /><br />
                                                                                <center>
                                                                                    <img src="images/come-scegliere-la-taglia-per-cani.jpg" alt="Come scegliere la taglia giusta per il proprio cane"
                                                                                        title="Come scegliere la taglia giusta per il proprio cane" style="border: 0;
                                                                                        width: 369px; height: 298px;" />
                                                                                </center>
                                                                                <strong><a href="http://www.perbaffo.it/Dettaglio-Categoria.aspx?Categoria=58" title="Abbigliamento per cani"
                                                                                    target="_blank">Abbigliamento per cani</a></strong>
                                                                                <br />
                                                                                <span class="med_text_dodici" style="color: Black;">Per scegliere la taglia giusta dovrete
                                                                                    misurare la lunghezza del dorso del vostro cane, ovvero la distanza tra la base
                                                                                    del collo e l’inizio della coda.<br /> Il cane va misurato quando è in piedi non mentre
                                                                                    è seduto o disteso. </span>
                                                                                <br />
                                                                                <br />
                                                                                <br />
                                                                                <strong><a href="http://www.perbaffo.it/Dettaglio-Categoria.aspx?Categoria=27" title="Collari per cani"
                                                                                    target="_blank">Collari per cani</a></strong>
                                                                                <br />
                                                                                <span class="med_text_dodici" style="color: Black;">Per scegliere la taglia giusta dovrete
                                                                                    misurare la circonferenza del collo del vostro cane.<br />
                                                                                    Le misure indicate sul sito si riferiscono alla circonferenza minima e a quella
                                                                                    massima di vestibilità del collare.
                                                                                    <br />
                                                                                    <br />
                                                                                    <b>Esempio:</b><br />
                                                                                    se la circonferenza del collo del vostro cane è di 26 cm dovrete acquistare la taglia
                                                                                    20 – 30 cm </span>
                                                                                <br />
                                                                                <br />
                                                                                <br />
                                                                                <strong><a href="http://www.perbaffo.it/Dettaglio-Categoria.aspx?Categoria=29" title="Pettorine per cani"
                                                                                    target="_blank">Pettorine per cani</a></strong>
                                                                                <br />
                                                                                <span class="med_text_dodici" style="color: Black;">Per scegliere la taglia giusta dovrete
                                                                                    misurare la circonferenza toracica del vostro cane.<br />
                                                                                    Le misure indicate sul sito si riferiscono alla circonferenza minima e a quella
                                                                                    massima di vestibilità della pettorina.<br />
                                                                                    Se la circonferenza toracica del vostro cane corrisponde alla vestibilità massima,
                                                                                    Vi consigliamo di prendere la taglia successiva.</span>
                                                                                    <br />
                                                                                    <br />
                                                                                    <b>Esempi:</b>
                                                                                    <ul class="med_text_dodici" style="color: Black;">
                                                                                        <li>Se la circonferenza toracica del vostro cane è 35 cm allora la taglia da prendere
                                                                                            della pettorina sarà 30 / 40 cm</li>
                                                                                        <li>Se la circonferenza toracica del vostro cane è di 39 cm non dovrete prendere la
                                                                                            taglia 30 – 40 cm ma bensì la misura 40 – 50 cm.</li>
                                                                                    </ul>
                                                                                
                                                                                <br />
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
