<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Termini-Condizioni.aspx.cs"
    Inherits="Perbaffo.Web.UI.Termini_Condizioni" %>

<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffo.ascx" TagName="Perbaffo" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="UserControl" %>
<%@ Register Src="WidgetFoto.ascx" TagName="Foto" TagPrefix="UserControl" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
<%@ Register Src="MenuCategorie.ascx" TagName="Menu" TagPrefix="UserControl" %>
<%@ Register Src="WidgetCarrello.ascx" TagName="Carrello" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNews.ascx" TagName="News" TagPrefix="UserControl" %>
<%@ OutputCache Location="Any" Duration="3600" VaryByParam="None" %>
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
    <meta name="Author" content="Davide Trotta"/>
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
                                    Termini e Condizioni
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
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>1. Introduzione</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Le presenti Condizioni Generali di vendita (in seguito “Condizioni Generali” ) disciplinano la vendita dei prodotti commercializzati da Perbaffo di Albanesi Silvia (in seguito il “Venditore”) tramite il sito web <a href="http://www.perbaffo.it" title="Sito Perbaffo" target="_blank">www.perbaffo.it</a>
                                                Tutti i contratti di acquisto di prodotti di cui sopra, conclusi tramite il sito "www.perbaffo.it” seguendo le procedure ivi indicate (online, via telefono o fax ), saranno regolati dalle presenti Condizioni Generali, le quali formano parte integrante e sostanziale degli stessi.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>2. Prezzi, spese di spedizione e pagamento</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                I prezzi di vendita dei Prodotti, che non costituiscono offerta al pubblico ai sensi dell'art. 1336 Cod. civ., le spese di spedizione e i pagamenti saranno quelli scelti dal cliente nel sito <a href="http://www.perbaffo.it" title="Sito Perbaffo" target="_blank">“www.perbaffo.it”</a> al momento dell’invio dell’ordine. I prezzi dei Prodotti vengono indicati I.V.A. inclusa, e le spese di spedizione sono pari a 9,00 € iva inclusa (per consegne al piano strada) per ordine, le spedizioni assicurate (ovvero che danno diritto al rimborso dell’intero importo speso in caso di danneggiamento da parte del corriere) sono pari a 12,00 € iva inclusa.
                                                Il Venditore si riserva il diritto di cambiare i prezzi pubblicati in questo sito in qualsiasi momento. I prezzi dei prodotti di volta in volta pubblicati annullano e sostituiscono quelli precedenti.
                                                Il Venditore si riserva altresì la facoltà di cambiare le condizioni di pagamento del Cliente in ogni momento quando le registrazioni di pagamenti precedenti o altre condizioni suggerissero tali cambiamenti.
                                                Perbaffo effettua consegne su tutto il territorio italiano.
                                                In caso di acquisto in Contrassegno, il pagamento dovrà essere eseguito esclusivamente con denaro contante 
                                            </td>
                                        </tr>
                                    </tbody>
                                </table> 
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>3. Comunicazioni</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Il Venditore si riserva, a sua insindacabile scelta, il diritto di annullare qualsiasi ordine in caso di errori materiali connessi con l’ordine del Cliente o con le informazioni inviate dal Cliente tramite il sito <a href="http://www.perbaffo.it" title="Sito Perbaffo" target="_blank">“www.perbaffo.it”</a>, oppure se ogni ulteriore verifica delle condizioni di credito del Cliente suggerisse tale annullamento.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>        
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>4. Ordini</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                I Prodotti vengono consegnati secondo l’opzione di spedizione selezionata, come specificato nel sito <a href="http://www.perbaffo.it" title="Sito Perbaffo" target="_blank">“www.perbaffo.it”</a> e come determinato dal Cliente al momento dell’invio dell’ordine.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>       
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>5. Diritto di proprietà</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Il diritto di proprietà sui Prodotti passa al Cliente dopo il completo pagamento dei prodotti o della loro consegna, se questa avviene per ultima.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>          
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>6. Consegne</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                I Prodotti vengono consegnati a seconda della opzione di spedizione selezionata sul sito <a href="http://www.perbaffo.it" title="Sito Perbaffo" target="_blank">www.perbaffo.it</a> dal Cliente al momento dell’invio dell’ordine.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>    
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>7. Diritto di recesso</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <ol>
                                                    <li>Ai sensi del D. Lgs. n. 206/05, se il cliente è un consumatore (ossia una persona fisica che acquista la merce per scopi non riferibili alla propria attività professionale, ovvero non effettua l'acquisto indicando nel modulo d'ordine a Perbaffo di Albanesi Silvia un riferimento di Partita IVA), ha diritto a recedere dal contratto di acquisto per qualsiasi motivo, senza alcuna penalità e fatto salvo quanto indicato al successivo punto 3. </li>
                                                    <li>Per esercitare tale diritto, il cliente dovrà inviare richiesta scritta tramite fax o email entro 10 giorni dalla data di ricevimento della merce. Ricevuta la richiesta, Perbaffo di Albanesi Silvia invierà via mail/fax al cliente il modulo di autorizzazione al reso che dovrà essere firmato e inserito all’interno dell’imballo in cui verrà spedito il prodotto e fatto pervenire ad Perbaffo di Albanesi Silvia entro 7 giorni lavorativi dall'autorizzazione.</li>
                                                    <li>Il diritto di recesso è comunque sottoposto alle seguenti inderogabili condizioni:
                                                        <ul>
                                                            <li>il diritto si applica al prodotto acquistato nella sua interezza; non è possibile esercitare recesso solamente su parte del prodotto acquistato</li>
                                                            <li>il diritto non si applica a prodotti alimentari una volta aperti</li>
                                                            <li>il bene acquistato dovrà essere integro e restituito nella confezione originale, completa in tutte le sue parti (compresi imballo ed eventuale documentazione e dotazione accessoria: manuali, etc, etc…); per limitare danneggiamenti alla confezione originale, raccomandiamo, quando possibile, di inserirla in una seconda scatola</li>
                                                            <li>le spese di spedizione relative alla restituzione del bene sono a carico del cliente</li>
                                                            <li>la spedizione, fino all'attestato di avvenuto ricevimento nel nostro magazzino, è sotto la completa responsabilità del cliente</li>
                                                            <li>in caso di danneggiamento del bene durante il trasporto, Perbaffo di Albanesi Silvia darà comunicazione al cliente dell'accaduto (entro 5 giorni lavorativi dal ricevimento del bene nel proprio magazzino), per consentirgli di sporgere tempestivamente denuncia nei confronti del corriere da lui scelto e ottenere il rimborso del valore del bene (se assicurato); in questa eventualità, il prodotto sarà messo a disposizione del cliente per la sua restituzione, contemporaneamente annullando la richiesta di recesso</li>
                                                            <li>Perbaffo di Albanesi Silvia non risponde in nessun modo per danneggiamenti o furto/smarrimento di beni restituiti con spedizioni non assicurate</li>
                                                        </ul>
                                                     </li>
                                                     <li>Il diritto di recesso decade totalmente, per mancanza della condizione essenziale di integrità del bene (confezione e/o suo contenuto), nei casi in cui Perbaffo di Albanesi Silvia accerti:
                                                        <ul>
                                                            <li>la mancata restituzione del modulo di autorizzazione firmato rilasciato da Perbaffo di Albanesi Silvia</li>
                                                            <li>la mancanza della confezione esterna e/o dell'imballo interno originale</li>
                                                            <li>l'assenza di elementi integranti del prodotto (accessori, manuali, parti, ...) o anomalie al prodotto stesso</li>                                                            
                                                            <li>il danneggiamento del prodotto per cause diverse dal suo trasporto</li>
                                                        </ul>
                                                     </li>
                                                     <li>Dopo aver verificato l’integrità della confezione e/o suo contenuto, Perbaffo di Albanesi Silvia provvederà ad emettere nota di credito e a rimborsare al cliente l'intero importo già pagato, entro 7 giorni lavorativi dal rientro della merce, tramite procedura di storno dell'importo sul sito <a href="http://www.paypal.it" title="Sito Paypal" target="_blank">www.paypal.it</a> per i pagamenti con carta di credito o a mezzo Bonifico Bancario per tutti gli altri tipi di pagamento. In quest'ultimo caso, sarà cura del cliente fornire tempestivamente le coordinate bancarie sulle quali ottenere il rimborso (Nome e cognome dell’intestatario del conto nonché il codice IBAN).
                                                        Nel caso di decadenza del diritto di recesso, Perbaffo di Albanesi Silvia provvederà a mettere il prodotto a disposizione del cliente per la sua restituzione.
                                                        </li>
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
                                                <strong>8. Accettazione e Restituzioni </strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                I Prodotti si riterranno accettati da parte del Cliente al momento della loro consegna.
                                                Fatto salvo il caso in cui il Cliente eserciti il diritto di recesso di cui all’art. 7 che precede, tale accettazione si presume fino a quando il Cliente non comunichi al Venditore, nel più breve tempo possibile ed in ogni caso non oltre 10 giorni lavorativi dal giorno del ricevimento dei Prodotti, che i Prodotti stessi sono stati consegnati in condizioni di inoperabilità o comunque sono difettosi.
                                                Il diritto di recesso consiste nella possibilità di restituire la merce acquistata al venditore con il conseguente rimborso del relativo prezzo di acquisto. 
                                                A seguito di tale ultima comunicazione, il Venditore provvederà, a sua scelta, a sostituire i prodotti difettosi o a rimborsare l’importo pagato dal Cliente per il loro acquisto.
                                                Il Venditore ha facoltà di testare i Prodotti al momento della loro restituzione e di addebitare al Cliente ogni costo sostenuto dal Venditore in caso di falsa denuncia di inoperabilita’ o difettosità dei Prodotti.
                                                La restituzione di prodotti acquistati mediante speciali offerte o promozioni o come parte di un “pacchetto” di prodotti può essere soggetta a specifiche condizioni, come descritto nelle stesse o altrimenti comunicato al Cliente. Nessun rimborso è consentito per singoli prodotti inoperativi acquistati come parte di un “pacchetto”, bensì il Venditore potrà, in via alternativa:                                                                                                                                              
                                                <ol>
                                                    <li>sostituire quel singolo prodotto</li>
                                                    <li>pretendere la restituzione dell’intero “pacchetto” di prodotti e rimborsare quanto corrisposto dal Cliente per l’acquisto di quello stesso “pacchetto”.
                                                    Il Venditore si riserva il diritto di chiedere il rimborso di ogni sconto promozionale su Prodotti diversi da quelli difettosi acquistati dal Cliente quando tali sconti sono stati concessi sull’acquisto del Prodotto, che è stato restituito ed il cui prezzo è stato rimborsato dal Venditore.</li>
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
                                                <strong>9. Garanzia </strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Tutti i venditori sono tenuti all’applicazione della nuova disciplina legislativa in materia di garanzia dei beni di consumo (D.Lgs. 24/2002).
                                                Perbaffo rispetta tutti gli adempimenti richiesti dalla nuova disciplina in merito alla garanzia legale, ma spetterà al singolo produttore decidere la durata e il contenuto della garanzia convenzionale o commerciale o di buon funzionamento, facente riferimento a vizi per effetto dell’uso protratto nel tempo. Con quest’ultima si intende la garanzia fornita volontariamente dal singolo produttore. Perbaffo garantira’ a seconda delle indicazioni dei produttori 12 o 24 mesi dalla consegna se il difetto lamentato dal consumatore costituisce un difetto di conformita’ cosi’ come indicato dal D.Lgs. 24/2002.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>    
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>10. Limitazioni di responsabilità</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Fatte salve le ipotesi di dolo o colpa grave del Venditore, è sin d’ora convenuto che, qualora fosse accertata la responsabilità del Venditore a qualsiasi titolo nei confronti del Cliente – ivi compreso il caso di inadempimento, totale o parziale, agli obblighi assunti dal Venditore nei confronti del Cliente per effetto dell'esecuzione di un ordine - la responsabilità del Venditore non potrà essere superiore al prezzo dei Prodotti acquistati dal Cliente e per i quali sia sorta la contestazione.
                                                La responsabilità del Venditore per i ritardi nella consegna non può superare l’ammontare delle spese di spedizione sostenute dal Cliente.
                                                Il Venditore non è responsabile dell’eventuale uso fraudolento ed illecito che possa essere fatto da parte di terzi, di carte di credito all’atto del pagamento dei prodotti acquistati. Il Venditore, infatti, in nessun momento della procedura d’acquisto è in grado di conoscere il numero di carta di credito dell’acquirente. 
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>     
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>11. Obblighi del Cliente</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Il Cliente si impegna, una volta conclusa la procedura di acquisto prevista dal sito <a href="http://www.perbaffo.it" title="Sito Perbaffo" target="_blank">www.perbaffo.it</a> , a provvedere alla stampa ed alla conservazione delle presenti condizioni generali, che, peraltro, avrà già visionato e accettato quale passaggio obbligato all’acquisto.
                                                È fatto severo divieto al Cliente di inserire dati falsi, e/o inventati, e/o di fantasia, nella procedura di registrazione necessaria ad attivare nei suoi confronti l’iter per l’esecuzione del presente contratto e le relative ulteriori comunicazioni; i dati anagrafici e la e-mail devono essere esclusivamente i propri reali dati personali e non di terze persone oppure di fantasia. È espressamente vietato inserire dati di terze persone. E’ fatto altresì divieto a persone minorenni di effettuare ordinativi. Il Venditore si riserva di perseguire legalmente ogni violazione ed abuso.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>  
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>12. Protezione dei dati personali</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Ogni dato personale che viene trasmesso in connessione con la registrazione al sito www.perbaffo.it verrà trattato in conformità all’informativa prevista dal D. Lgs.vo n. 196/2003 contenuta nel sito <a href="http://www.perbaffo.it" title="Sito Perbaffo" target="_blank">www.perbaffo.it</a> alla pagina web di registrazione del Cliente.
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>     
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>13. Giurisdizione e legge applicabile</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Qualsiasi controversia relativa all’applicazione, esecuzione, interpretazione e violazione dei contratti d’acquisto stipulati “on line” tramite il sito web <a href="http://www.perbaffo.it" title="Sito Perbaffo" target="_blank">www.perbaffo.it</a> è sottoposta alla giurisdizione italiana.
                                                Le presenti condizioni generali sono regolate dalla legge italiana e si riportano, per quanto non espressamente ivi previsto, al D.Lgs. n. 50/92 e al D.Lgs. n. 185/99.
                                                Reclami
                                                Ogni eventuale reclamo dovrà essere inviato a Perbaffo di Albanesi Silvia - Via Nino Costa 16 - 10044 Pianezza (TO).
                                            </td>
                                        </tr>
                                    </tbody>
                                </table> 
                                <br />
                                <table border="0" cellpadding="1" cellspacing="1" width="100%">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <strong>14. Foro competente</strong>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Qualsiasi controversia che dovesse sorgere in relazione ai contratti regolati dalle presenti Condizioni Generali o che fosse comunque connessa ad esse, sarà devoluta al Foro di Torino.
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
