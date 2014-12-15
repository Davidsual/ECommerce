<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Spedizioni.aspx.cs" Inherits="Perbaffo.Web.UI.Spedizioni" %>

<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
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

    <style type="text/css">
        .style1
        {
            width: 25%;
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
                                    Spedizioni
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
                                    Spedizioni rapide e veloci</h3>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                Il costo del trasporto è pari a 9 euro iva inclusa per consegne normali al piano
                                                strada, indipendentemente dalla quantità di merce acquistata. Le spedizioni assicurate
                                                costano 12 euro iva inclusa.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                La merce viene consegnata all'indirizzo di fatturazione o all’eventuale indirizzo
                                                di spedizione indicato sul modulo d'ordine. Le consegne vengono effettuate nella
                                                seguente fascia oraria: <strong>dalle 09.00 alle 18.00.</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Nel caso in cui il corriere non trovi nessuno in casa, provvederà a ripassare in
                                                un secondo momento. Se anche in questo caso non possa avvenire la consegna, il vostro
                                                prodotto verrà rispedito al magazzino dal corriere più vicino al luogo di consegna
                                                (merce in giacenza). Contattate il nostro <a href="Contatti.aspx" title="Contatti e servizio clienti">
                                                    <u>SERVIZIO CLIENTI</u></a> per sbloccare la giacenza e concordare un’ultima
                                                consegna. Se il corriere non riuscirà a consegnarvi l’ordine la merce ritornerà
                                                al nostro magazzino. Provvederemo allora ad addebitarVi le spese di spedizione sostenute
                                                per il rientro dell’ordine e metteremo la merce a vostra disposizione per un nuovo
                                                invio
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table style="border:1px solid #CDDDED;" cellpadding="0" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td style="background-color: #cddded; width: 40%;">
                                                <strong>Luogo ritiro</strong>
                                            </td>
                                            <td style="background-color: #cddded; width: 30%;">
                                                <strong>Pagamento</strong>
                                            </td>
                                            <td style="background-color: #cddded; width: 15%;">
                                                <strong>Spese Gestione</strong>
                                            </td>
                                            <td style="background-color: #cddded; width: 15%;">
                                                <strong>Spese Trasporto</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="background-color: #f4f4f4;">
                                                <strong>Ritiro presso il nostro magazzino (Pianezza - TO)</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Presso il magazzino di Pianezza (TO)
                                            </td>
                                            <td colspan="3">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                                    <tbody>
                                                        <tr>
                                                            <td style="background-color: #f4f4f4;" colspan="3">
                                                                <strong>Pagamento alla consegna</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                Contanti
                                                            </td>
                                                            <td>
                                                                Nessuna
                                                            </td>
                                                            <td>
                                                                Nessuna
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="background-color: #f4f4f4;" colspan="3">
                                                                <strong>Pagamento On-Line anticipato</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                PostePay
                                                            </td>
                                                            <td>
                                                                Nessuna
                                                            </td>
                                                            <td>
                                                                Nessuna
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                Bonifico
                                                            </td>
                                                            <td>
                                                                Nessuna
                                                            </td>
                                                            <td>
                                                                Nessuna
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                Carta di credito
                                                            </td>
                                                            <td>
                                                                Nessuna
                                                            </td>
                                                            <td>
                                                                Nessuna
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" style="background-color: #f4f4f4;">
                                                <strong>Comodamente a casa tua o in azienda </strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Spedizione tramite corriere Bartolini
                                            </td>
                                            <td colspan="3">
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%" >
                                                    <tbody>
                                                        <tr>
                                                            <td style="background-color: #f4f4f4;" colspan="3">
                                                                <strong>Pagamento alla consegna</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                Contanti
                                                            </td>
                                                            <td style="color: Red; " class="style1">
                                                                <b>€&nbsp;3.50</b>
                                                            </td>
                                                            <td style="width: 25%;">
                                                                €&nbsp;3.90* /€ 9.00
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="background-color: #f4f4f4;" colspan="3">
                                                                <strong>Pagamento On-Line anticipato</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                PostePay
                                                            </td>
                                                            <td class="style1">
                                                                Nessuna
                                                            </td>
                                                            <td>
                                                                €&nbsp;3.90* /€ 9.00
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                Bonifico
                                                            </td>
                                                            <td class="style1">
                                                                Nessuna
                                                            </td>
                                                            <td>
                                                                €&nbsp;3.90* /€ 9.00
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 50%">
                                                                Carta di credito
                                                            </td>
                                                            <td class="style1">
                                                                Nessuna
                                                            </td>
                                                            <td>
                                                                €&nbsp;3.90* /€ 9.00
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <b>*</b><i>Per ordini superiori a € 35.00 (Totale prodotti al netto di eventuali altri sconti)</i>
                                <br /><br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <i>I tempi di consegna sono di 2/3 gg. lavorativi dal momento della spedizione. I tempi
                                                indicati possono variare in periodi particolari, a causa di sovraccarichi della
                                                struttura logistica dei Corrieri.</i>
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
