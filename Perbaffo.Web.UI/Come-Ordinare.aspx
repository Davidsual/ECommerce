<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Come-Ordinare.aspx.cs"
    Inherits="Perbaffo.Web.UI.Come_Ordinare" %>

<%@ Register Src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
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
                                    Come Ordinare
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
                                    Effettuare ordini su Perbaffo è semplice, facile e veloce:</h3>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>1)&nbsp;&nbsp;Per prima cosa è necessario <a href="Login-Utente.aspx" title="Registrazione nuovo utente">
                                                    registrarsi</a></strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Compila l’apposito modulo elettronico; durante la registrazione potrai impostare
                                                la tua password, che sarà necessaria, insieme alla tua email, per effettuare il
                                                Login, per fare acquisti e per poter verificare lo stato del Tuo ordine in tempo
                                                reale.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>2)&nbsp;&nbsp;Scegli i <a href="Default.aspx" title="Homepage Perbaffo">
                                                    prodotti</a> che ti interessano</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Naviga tra le categorie di prodotti per trovare quello che t'interessa. Per aggiungere
                                                un prodotto nel carrello basta cliccare su “acquista” nelle varie vetrine prodotti
                                                o su “aggiungi al carrello” nel dettaglio del prodotto. Una volta inserito il prodotto
                                                nel carrello comparirà immediatamente un pop up che confermerà l’operazione.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>3)&nbsp;&nbsp;Riempi il carrello</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Potrai continuare a riempire il carrello con altri prodotti. Nel carrello virtuale
                                                potrai modificare le quantità di ogni singolo prodotto, oppure eliminarne qualcuno.
                                                Ti ricordiamo di cliccare su <b>“aggiorna”</b> dopo aver effettuato le modifiche
                                                sulla quantità, per vedere il totale aggiornato.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>4)&nbsp;&nbsp;Acquista i prodotti</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Dopo aver cliccato su <b>“acquista”</b>, comparirà una schermata dove inserire l’indirizzo
                                                di spedizione. Il sito riporta in modo automatico l’indirizzo che avete indicato
                                                al momento della registrazione. Se preferite che la merce venga spedito a un altro
                                                indirizzo, vi preghiamo di indicarcelo in questo modulo, cliccate su <b>“modifica”</b>
                                                e scrivete il nuovo indirizzo di spedizione e le eventuali note. Dopo aver effettuato
                                                le opportune modifiche cliccate su aggiorna. Se non siete mai a casa e non avete
                                                indirizzi alternativi a cui spedire il pacco potete anche richiedere il fermo deposito
                                                presso la sede Bartolini a Voi più vicina, in questo caso basta scrivere nelle note
                                                <b>“fermo deposito Bartolini”</b>. Dopo aver aggiornato i dati cliccare su <b>“continua”</b>.
                                                Comparirà ora il riepilogo del vostro ordine oltre all’indirizzo di spedizione e
                                                alle note, modificabili anche in questa pagina. A questo punto dovrete scegliere
                                                il metodo di pagamento e il tipo di spedizione. Se avete buoni sconti dovrete inserirli
                                                nel campo “codice sconto” e cliccare su <b>“aggiorna”</b>. Una volta controllati
                                                i dati inseriti cliccate su <b>“continua”</b>.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>5)&nbsp;&nbsp;Omaggio</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                In questa schermata potrete scegliere l’omaggio che preferite. È possibile scegliere
                                                un solo omaggio per ogni ordine. Si ha diritto a un solo omaggio per spedizione
                                                pertanto se unite più ordini ricevete un omaggio solo. Per selezionare l’omaggio
                                                basta cliccare su <b>“scegli”</b>. Dopo aver scelto l’omaggio cliccare su <b>“continua”</b>.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>6)&nbsp;&nbsp;Conferma ordine</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                In questa pagina ti riepiloghiamo tutti i dati da te inseriti, i prodotti e l’omaggio
                                                selezionati. Cliccare su <b>“conferma”</b> per inoltrare l’ordine. Gli ordini vengono
                                                entro 5 giorni lavorativi dalla data del pagamento salvo diversa indicazione nei
                                                dettagli dei prodotti acquistati. Nella pagina successiva alla conferma vengono
                                                indicati i dati per il pagamento da voi selezionato. È possibile stampare la pagina
                                                con i dati cliccando su <b>“stampa”.</b>.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>Come faccio ad annullare un ordine?</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Gli acquisti su Perbaffo sono assolutamente liberi ed annullabili fino al momento
                                                della spedizione.
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Se desiderate annullare un ordine seguite questa semplice procedura:
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <ol>
                                                    <li>Contattate il nostro <a href="Contatti.aspx" title="Contatti e servizio clienti">
                                                        <u>SERVIZIO CLIENTI</u></a> indicando nome, cognome, numero d'ordine e chiedendo
                                                        espressamente l'annullamento dell'ordine.</li>
                                                    <li>Se avete già effettuato il pagamento con bonifico o ricarica Postepay non dimenticate
                                                        di indicarci le vostre coordinate bancarie: nome e cognome dell’intestatario e codice
                                                        IBAN. Provvederemo a restituirvi l'importo tramite bonifico bancario alle coordinate
                                                        da Voi indicate entro 7 giorni lavorativi.</li>
                                                    <li>Se avete effettuato il pagamento con Paypal vi riaccrediteremo l’importo da voi
                                                        pagato sul vostro conto Paypal. Non è possibile riaccreditare il pagamento su un
                                                        conto Paypal diverso da quello da cui è stato effettuato il pagamento</li>
                                                </ol>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>Come faccio a sapere se un prodotto è disponibile?</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tutti i prodotti presenti sul sito Perbaffo sono ordinabili. Se un prodotto non
                                                è presente a magazzino verrà immediatamente richiesto ai fornitori ed entro 48h
                                                lavorative sarà disponibile presso il nostro magazzino. Ci sono prodotti speciali
                                                la cui consegna può richiedere più giorni, questo viene espressamente indicato nel
                                                dettaglio del prodotto stesso.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>Posso modificare il mio ordine? Posso aggiungere o togliere un prodotto?</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Se desiderate aggiungere o togliere un prodotto dal Vostro ordine, oppure modificarne
                                                la quantità è sufficiente che ci inviate un’email con indicate le modifiche ed il
                                                numero d’ordine su cui effettuarle. Vi invieremo un’email di conferma a modifiche
                                                ricevute. Naturalmente le modifiche sono effettuabili solo se l’ordine non è ancora
                                                stato spedito
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>C'è un limite minimo di prodotti ordinabili oppure un importo minimo?</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Non c'è nessun limite all'acquisto.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>Sono residente all'estero posso effettuare un ordine su Perbaffo?</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Al momento spediamo solo entro i confini nazionali.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>Avete dei negozi dove poter acquistare?</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Perbaffo vende esclusivamente on-line.
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
