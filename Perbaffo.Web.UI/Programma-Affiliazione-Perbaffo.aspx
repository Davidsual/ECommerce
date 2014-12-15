<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Programma-Affiliazione-Perbaffo.aspx.cs"
    Inherits="Perbaffo.Web.UI.Programma_Affiliazione_Perbaffo" %>

<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffo.ascx" TagName="Perbaffo" TagPrefix="UserControl" %>
<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
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

    <style type="text/css">
        .style1
        {
            height: 307px;
        }
    </style>
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
                                    Programma affiliazione
                                </h1>
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
                            <td class="yellow_left" width="11">
                            </td>
                            <td class="bodycopy" align="left">
                                <h3>
                                    Programma di affiliazione Perbaffo</h3>
                                <h4>
                                    Da oggi con Perbaffo potrete guadagnare su internet grazie al Vostro sito, forum
                                    o blog in modo semplice, automatico,senza rischi e perdite di tempo!!
                                </h4>
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                Se possedete un forum, un sito o un blog potete iscrivervi al nostro Programma di
                                                Affiliazione e guadagnate il 5% degli ordini fatti tramite il vostro codice.
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Come funziona:</strong>
                                                <ul>
                                                    <li>Sponsorizzate <a href="http://www.perbaffo.it/" title="Perbaffo" target="_blank">
                                                        www.perbaffo.it</a> sul vostro sito/blog aggiungendo il nostro banner.</li>
                                                    <li>Ogni volta che riceviamo un ordine con il vostro codice, vi invieremo un’email con
                                                        il totale dell’ordine ricevuto e il totale della vostra provvigione. In ogni momento
                                                        potrete richiederci la scheda con il totale delle provvigioni accumulate inviandoci
                                                        una semplice email. </li>
                                                    <li>Perbaffo provvede a pagarVi le commissioni maturate ogni bimestre. </li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Come partecipare:</strong>
                                                <ul>
                                                    <li>Compilate il <a href="Documents/Modulo-affiliazione-Perbaffo.pdf" class="dark_red"
                                                        title="Modulo per iscriversi al programma di affiliazione di Perbaffo" target="_blank">
                                                        modulo di iscrizione.</a></li>
                                                    <li>Inviatecelo via email o via fax, vi invieremo il contratto a garanzia degli impegni
                                                        presi, con riepilogati i vostri e i nostri dati, la percentuale di commissione e
                                                        i metodi e i tempi di pagamento delle commisioni</li>
                                                    <li>Entro 48 ore lavorative dall’invio del modulo di iscrizione riceverete due banner
                                                        con il vostro codice personale che dovrete pubblicare sul vostro sito, blog o forum.
                                                        Da questo momento in poi comincerete a guadagnare!!</li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Tariffe:</strong><br />
                                                <span>Guadagnerete il 5% fisso di tutti gli ordini che ci arriveranno tramite il banner
                                                    inserito sul vostro sito. le commissioni vengono conteggiate solo sul totale dei
                                                    prodotti e non sulle spese di spedizione. </span>
                                                <br />
                                                FAQ:
                                                <ul>
                                                    <li>Cos’è e come funziona un programma di affiliazione? </li>
                                                    <li>Quali sono i vantaggi degli affiliati perbaffo.it? </li>
                                                    <li>Il Programma di Affiliazione è gratuito? </li>
                                                    <li>Chi può diventare affiliato?</li>
                                                    <li>Posso partecipare con più siti? </li>
                                                    <li>Riceverò informazioni relative all’andamento degli ordini pervenuti attraverso il
                                                        mio sito?</li>
                                                    <li>Come posso registrarmi? </li>
                                                    <li>A chi posso rivolgermi per ulteriori informazioni? </li>
                                                </ul>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Cos’è e come funziona un programma di affiliazione?</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                L’affiliazione è un accordo tra due soggetti, in questo caso tra Perbaffo e chiunque
                                                di voi voglia lavorare con noi.<br />
                                                Il concetto di Affiliazione è semplice: se avete un sito web dovrete solamente inserire
                                                il nostro banner o il nostro link sul vostro sito in questo modo indirizzerete i
                                                vostri visitatori al nostro partale Perbaffo.<br />
                                                Se i vostri visitatori comprano vi paghiamo una commissione.<br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Quali sono i vantaggi degli affiliati Perbaffo.it? </strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                L’affiliato di Perbaffo.it guadagnerà in modo semplice una commissione del 5% su
                                                tutti gli ordini che arrivano dal suo sito. Perbaffo vi offre la possibilità di
                                                arrotondare il vostro stipendio comodamente da casa vostra. Più clienti indirizzerete
                                                al nostro sito e maggiori saranno le possibilità di guadagno.<br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Il Programma di Affiliazione è gratuito?</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Certamente, aderire al programma è gratuito.<br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Chi può diventare affiliato?</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tutti coloro che possiedono un sito web, un forum o un blog ed un conto corrente
                                                bancario in Italia possono partecipare al nostro Programma di Affiliazione.
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Posso partecipare con più siti? </strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Certamente, non c’è nessun limite al numero di banner o link che potete pubblicare.<br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Riceverò informazioni relative all’andamento degli ordini pervenuti attraverso
                                                    il mio sito?</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Si. Ogni settimana riceverete un report con il numero di ordini ricevuti dal vostro
                                                sito.
                                                <br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Come posso registrarmi? </strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Per registrarvi compilate il modulo d’iscrizione e inviatecelo via fax.<br />
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>A chi posso rivolgermi per ulteriori informazioni? </strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Per ulteriori domande riguardo al Programma di Affiliazione Perbaffo, inviateci
                                                un’email a <a href="mailto:info@perbaffo.it?subject=Informazioni" title="Contatti Perbaffo">
                                                    info@perbaffo.it.</a><br />
                                                <br />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table cellpadding="0" cellspacing="0" border="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>Codice da inserire sul proprio sito/blog/forum</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="font-size:8pt;">
                                                &lt;a href="http://www.perbaffo.it/?AFL=CODICE" target="_black" title="Perbaffo
                                                Pet Shop" &gt;<br />
                                                &lt;img src="http://www.perbaffo.it/images/Banner/BANNER-SCELTO" border="0" alt="Perbaffo
                                                Pet Shop" /&gt;<br />
                                                &lt;/a&gt;
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellspacing="0" cellpadding="0" width="97%" bgcolor="#CDDDED">
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
                                            <td align="center">
                                                <h3>
                                                    Banner di Perbaffo per l'affiliazione</h3>
                                                <table width="100%" cellpadding="1" cellspacing="2">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left">
                                                                <img src="images/Banner/banner-Perbaffo-120x300.gif" alt="Banner Perbaffo Pet Shop statico 120x300" />
                                                            </td>
                                                            <td>
                                                                <span>Banner Perbaffo Pet Shop 120 x 300</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <img src="images/Banner/banner-Perbaffo-180x174.gif" alt="Banner Perbaffo Pet Shop statico 180x174" />
                                                            </td>
                                                            <td>
                                                                <span>Banner Perbaffo Pet Shop 180 x 174</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <img src="images/Banner/banner-Perbaffo-Animato-120x300.gif" alt="Banner Perbaffo Pet Shop animato 120x300" />
                                                            </td>
                                                            <td>
                                                                <span>Banner Perbaffo Pet Shop 120 x 300</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <img src="images/Banner/banner-Perbaffo-animato-150x51.gif" alt="Banner Perbaffo Pet Shop animato 150x51" />
                                                            </td>
                                                            <td>
                                                                <span>Banner Perbaffo Pet Shop 150 x 51</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <img src="images/Banner/banner-Perbaffo-statico-150x51.gif" alt="Banner Perbaffo Pet Shop statico 150x51" />
                                                            </td>
                                                            <td>
                                                                <span>Banner Perbaffo Pet Shop 150 x 51</span>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <br />
                                                <br />
                                                <table width="100%" cellpadding="1" cellspacing="2">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left">
                                                                <br />
                                                                <span>Banner Perbaffo Pet Shop 350 x 250</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <img src="images/Banner/banner_perbaffo_300_x_250.gif" alt="Banner Perbaffo Pet Shop statico 300x250" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <br />
                                                                <span>Banner Perbaffo Pet Shop 468 x 60</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <img src="images/Banner/banner_perbaffo_468_x_60.gif" alt="Banner Perbaffo Pet Shop statico 468x60" />
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <br />
                                                                <span>Banner Perbaffo Pet Shop 728 x 90</span>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="left">
                                                                <img src="images/Banner/banner_perbaffo_728_x_90.gif" width="468" height="57" alt="Banner Perbaffo Pet Shop statico 728x90" />
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
                            <td class="yellow_right" width="11" align="right">
                            </td>
                        </tr>
                        <tr>
                            <td align="left" class="bottomLeftStyle">
                            </td>
                            <td class="yellow_bottom" style="height: 12px;">
                            </td>
                            <td align="right" class="bottomRightStyle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <img src="images/spacer.gif" width="1px" height="5px" alt="" />
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
