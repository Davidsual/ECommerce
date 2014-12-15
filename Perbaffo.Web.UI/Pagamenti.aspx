<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pagamenti.aspx.cs" Inherits="Perbaffo.Web.UI.Pagamenti" %>

<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="UserControl" %>
<%@ Register Src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffo.ascx" TagName="Perbaffo" TagPrefix="UserControl" %>
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
                                    Pagamenti
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
                                    Pagamenti in contanti e On-Line</h3>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                Per i pagamenti anticipati accettiamo <strong>bonifici bancari</strong>, ricariche
                                                <strong>Postepay</strong> e <strong>carte di credito</strong> tramite il sistema
                                                PayPal.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Se invece preferisci pagare il tuo ordine in <strong>contanti</strong> alla consegna
                                                puoi scegliere di utilizzare il <strong>contrassegno</strong> al costo aggiuntivo
                                                di <strong>€&nbsp;3,50</strong>.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Ai clienti di Torino e dintorni</strong> offriamo la possibilità di ritirare
                                                l’ordine direttamente presso il nostro magazzino pagando in contanti alla consegna
                                                senza costi aggiuntivi o con i metodi di pagamento anticipati sopra elencati.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>1 - Bonifico bancario</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Il <strong>bonifico</strong> è una operazione bancaria che consente il trasferimento
                                                di fondi da una banca ad un'altra. Il trasferimento dei fondi può avvenire addebitando
                                                l’importo sul vostro conto corrente oppure presentando il corrispettivo in contanti
                                                alla banca che origina il pagamento.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>2 - Ricarica Postepay</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                La carta Postepay è una carta di credito ricaricabile emessa dalle Poste Italiane.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table style="border: 1px solid #CDDDED;" cellpadding="1" cellspacing="1" width="100%">
                                                    <tbody>
                                                        <tr>
                                                            <td colspan="2" style="background-color: #cddded;">
                                                                <strong>COME EFFETTUARE UNA RICARICA POSTEPAY</strong>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td style="width: 40%;" valign="top">
                                                                Negli uffici postali
                                                            </td>
                                                            <td style="width: 60%;">
                                                                <ul>
                                                                    <li>con versamento in contanti </li>
                                                                    <li>con una carta Postamat Maestro </li>
                                                                    <li>trasferendo denaro da una carta postepay a un'altra </li>
                                                                </ul>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                Presso gli sportelli automatici (ATM) Postamat
                                                            </td>
                                                            <td>
                                                                <ul>
                                                                    <li>con una carta Postamat Maestro</li>
                                                                    <li>trasferendo denaro da una carta postepay a un'altra </li>
                                                                    <li>trasferendo denaro da una Inps Card </li>
                                                                    <li>utilizzando qualsiasi carta di pagamento abilitata ai circuiti internazionali Visa,
                                                                        Visa Electron, Mastercard o Maestro </li>
                                                                </ul>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                Sul sito <a href="http://www.poste.it" title="Poste italiane" target="_blank">www.poste.it</a>
                                                                (*)
                                                            </td>
                                                            <td>
                                                                <ul>
                                                                    <li>addebitando l'importo sul Conto BancoPosta</li>
                                                                    <li>trasferendo denaro da una carta postepay a un'altra </li>
                                                                </ul>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                Con una SIM PosteMobile
                                                            </td>
                                                            <td>
                                                                <ul>
                                                                    <li>da oggi puoi ricaricare la tua Postepay o un'altra Postepay direttamente dal menù
                                                                        del tuo cellulare con la tua Postepay o con il tuo Conto BancoPosta</li>
                                                                </ul>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top">
                                                                Presso le ricevitorie Sisal
                                                            </td>
                                                            <td>
                                                                <ul>
                                                                    <li>esclusivamente in contanti </li>
                                                                </ul>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>3 - Paypal</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>PayPal</strong> è un semplice e sicuro sistema di pagamento via internet.
                                                Il suo funzionamento è molto simile a quello di un comune conto corrente bancario.
                                                Se non hai già un conto <strong>PayPal</strong> puoi crearlo gratuitamente sul sito
                                                <a href="http://www.paypal.it" title="Pagamento carta di credito su PayPal" target="_blank">
                                                    www.paypal.it</a>. Per "caricare" il tuo conto puoi utilizzare una <strong>carta di
                                                        credito</strong> o un <strong>conto corrente bancario</strong>. Per maggiori
                                                informazioni, puoi visitare questa pagina.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <font style="color: Red"><strong>Attenzione:</strong></font><br />
                                                l'addebito avviene alla fine del processo di acquisto, in caso di indisponibilità
                                                di alcuni prodotti, verrà effettuato uno storno sul conto <strong>PayPal</strong>
                                                per l'importo relativo ai prodotti non spediti.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>4 - Contrassegno</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Se desideri pagare la merce al momento della consegna, scegli il contrassegno e
                                                pagherai il tuo ordine in <strong>contanti</strong>, <strong>direttamente ed <u>esclusivamente</u>
                                                    al corriere</strong> che recapiterà il tuo pacco.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>5 - Ritiro presso il nostro magazzino (Pianezza - TO)</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <strong>Ai clienti di Torino e dintorni</strong> offriamo la possibilità di ritirare
                                                l’ordine direttamente presso il nostro magazzino pagando in contanti alla consegna
                                                senza costi aggiuntivi o con i metodi di pagamento anticipati sopra elencati. <strong>
                                                    Il pagamento presso il magazzino può essere effettuato <u>solo in contanti</u>.</strong>
                                                Se preferisci pagare con carta di credito o con Postepay puoi fare un pagamento
                                                anticipato.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <br />
                                                <strong>Prima di venire a ritirare il tuo ordine attendi sempre la nostra conferma</strong>,
                                                ti contatteremo via e-mail per comunicarti che i prodotti richiesti sono pronti
                                                per il ritiro..
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
