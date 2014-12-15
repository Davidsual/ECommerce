<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Help.aspx.cs" Inherits="Perbaffo.Web.UI.Help" %>
<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="UserControl" %>
<%@ Register src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffo.ascx" TagName="Perbaffo" TagPrefix="UserControl" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="UserControl" %>
<%@ Register Src="WidgetFoto.ascx" TagName="Foto" TagPrefix="UserControl" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
<%@ Register Src="MenuCategorie.ascx" TagName="Menu" TagPrefix="UserControl" %>
<%@ Register Src="WidgetCarrello.ascx" TagName="Carrello" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNews.ascx" TagName="News" TagPrefix="UserControl" %>
<%@ OutputCache Duration="120"  VaryByParam="none" %>
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
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />

    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>
    <script language="javascript" type="text/javascript">
        function fShowVisible(tipo) {
            try {
                var _gen = document.getElementById("divGenerale");
                var _pag = document.getElementById("divPagamenti");
                var _sped = document.getElementById("divSpedizioni");
                var _carr = document.getElementById("divCarrello");
                var _scon = document.getElementById("divSconti");
                var _priv = document.getElementById("divPrivacy");

                if (tipo == null || tipo == "" || _gen == null || _pag == null || _sped == null || _carr == null || _scon == null || _priv == null)
                    return;

                _gen.style.display = 'none';
                _pag.style.display = 'none';
                _sped.style.display = 'none';
                _carr.style.display = 'none';
                _scon.style.display = 'none';
                _priv.style.display = 'none';
                
                if (tipo == "GEN") 
                    _gen.style.display = 'block';
                else if (tipo == "PAG")
                    _pag.style.display = 'block';
                else if (tipo == "SPED")
                    _sped.style.display = 'block';
                else if (tipo == "CARR")
                    _carr.style.display = 'block';
                else if (tipo == "SCON")
                    _scon.style.display = 'block';
                else if (tipo == "PRIV")
                    _priv.style.display = 'block';
            }
            catch (Error) {
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
                <table border="0" cellspacing="0" cellpadding="0" style="width:590px;background-color:#cddded;height:35px;">
                    <tbody>
                        <tr>
                            <td align="left" class="topLeftStyle">
                            </td>
                            <td rowspan="2" align="right">
                                <h1>
                                    Help - F.A.Q.</h1>
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
                                                <table border="0" cellspacing="0" cellpadding="0" width="95%" bgcolor="#CDDDED">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left" class="topLeftStyle">
                                                            </td>
                                                            <td class="bodycopy">    
                                                            <span class="med_text" style="color:Black;"><b>Domande frequenti</b></span>              
                                                            <a name="menu"></a>
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
                                                                    <li><a href="#uno" class="dark_red" style="font-size:12;" title="C'è un limite minimo di prodotti ordinabili oppure un importo minimo?">C'è un limite minimo di prodotti ordinabili oppure un importo minimo?</a></li>
                                                                    <li><a href="#due" class="dark_red" style="font-size:12;" title="A cosa serve la lista dei desideri?">A cosa serve la lista dei desideri?</a></li>
                                                                    <li><a href="#tre" class="dark_red" style="font-size:12;" title="Come posso utilizzare la lista dei desideri?">Come posso utilizzare la lista dei desideri?</a></li>
                                                                    <li><a href="#quattro" class="dark_red" style="font-size:12;" title="Come posso ordinare?">Come posso ordinare?</a></li>
                                                                    <li><a href="#cinque" class="dark_red" style="font-size:12;" title="È possibile annullare un ordine?">È possibile annullare un ordine?</a></li>
                                                                    <li><a href="#sei" class="dark_red" style="font-size:12;" title="Come faccio a sapere se un prodotto è disponibile?">Come faccio a sapere se un prodotto è disponibile?</a></li>
                                                                    <li><a href="#sette" class="dark_red" style="font-size:12;" title="Posso modificare il mio ordine? Posso aggiungere o togliere un prodotto?">Posso modificare il mio ordine? Posso aggiungere o togliere un prodotto?</a></li>
                                                                    <li><a href="#otto" class="dark_red" style="font-size:12;" title="Sono residente all'estero posso effettuare un ordine?">Sono residente all'estero posso effettuare un ordine?</a></li>                                                                    
                                                                    <li><a href="#nove" class="dark_red" style="font-size:12;" title="Avete dei negozi dove poter acquistare?">Avete dei negozi dove poter acquistare?</a></li>
                                                                    <li><a href="#dieci" class="dark_red" style="font-size:12;" title="Riceverò una conferma d'ordine?">Riceverò una conferma d'ordine?</a></li>
                                                                    <li><a href="#undici" class="dark_red" style="font-size:12;" title="Mi informerete quando l'ordine sarà spedito?">Mi informerete quando l'ordine sarà spedito?</a></li>                                                                    
                                                                    <li><a href="#dodici" class="dark_red" style="font-size:12;" title="Come posso monitorare lo stato del mio ordine?">Come posso monitorare lo stato del mio ordine? </a></li>
                                                                    <li><a href="#tredici" class="dark_red" style="font-size:12;" title="Ho ricevuto un prodotto ma non è quello da me ordinato… Cosa fare?">Ho ricevuto un prodotto ma non è quello da me ordinato… Cosa fare?</a></li>
                                                                    <li><a href="#quattordici" class="dark_red" style="font-size:12;" title="Ho ricevuto un pacco (o più pacchi) con imballo in condizioni non perfette. Cosa fare?">Ho ricevuto un pacco (o più pacchi) con imballo in condizioni non perfette. Cosa fare?</a></li>                                                                    
                                                                    <li><a href="#quindici" class="dark_red" style="font-size:12;" title="Ho ricevuto un pacco (o più pacchi) danneggiato o aperto. Cosa fare?">Ho ricevuto un pacco (o più pacchi) danneggiato o aperto. Cosa fare?</a></li>
                                                                    <li><a href="#sedici" class="dark_red" style="font-size:12;" title="All'apertura del pacco mi sono accorto che mancano alcuni degli articoli che dovevano essere inclusi nella confezione… Cosa fare?">All'apertura del pacco mi sono accorto che mancano alcuni degli articoli che dovevano essere inclusi nella confezione… Cosa fare?</a></li>
                                                                    <li><a href="#diciasette" class="dark_red" style="font-size:12;" title="Potete cambiare il prodotto che erroneamente ho sbagliato ad ordinare?">Potete cambiare il prodotto che erroneamente ho sbagliato ad ordinare?</a></li>                                                                                                                                        
                                                                    <li><a href="#diciotto" class="dark_red" style="font-size:12;" title="Posso usufruire del diritto di recesso?">Posso usufruire del diritto di recesso?</a></li>
                                                                    <li><a href="#diciannove" class="dark_red" style="font-size:12;" title="Come posso riscuotere uno sconto?">Come posso riscuotere uno sconto?</a></li>
                                                                    <li><a href="#venti" class="dark_red" style="font-size:12;" title="Posso utilizzare più di un buono sconto per ordine?">Posso utilizzare più di un buono sconto per ordine?</a></li>
                                                                    <li><a href="#ventuno" class="dark_red" style="font-size:12;" title="Posso convertire un buono acquisto in contanti?">Posso convertire un buono acquisto in contanti?</a></li>                                                                    
                                                                    <li><a href="#ventidue" class="dark_red" style="font-size:12;" title="Come posso essere informato sulle vostre offerte speciali?">Come posso essere informato sulle vostre offerte speciali?</a></li>
                                                                    <li><a href="#ventitre" class="dark_red" style="font-size:12;" title="Come posso cancellarmi dal mailing delle offerte di Perbaffo?">Come posso cancellarmi dal mailing delle offerte di Perbaffo?</a></li>                                 
                                                                </ul>
                                                            </td>
                                                            <td valign="bottom" width="12" align="right" style="background-image: url(images/botright.gif);
                                                                background-repeat: no-repeat; background-position: bottom;">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <br /><br />
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td align="left"><a name="uno"></a>
                                                        <strong>C'è un limite minimo di prodotti ordinabili oppure un importo minimo?</strong><br />
                                                        Non c'è nessun limite all'acquisto.
                                                        <br />
                                                        <a href="#menu">[Torna su]</a>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td align="left"><a name="due"></a>
                                                         <br />
                                                        <strong>A cosa serve la lista dei desideri?</strong><br />
                                                        La lista dei desideri serve a creare un elenco dei tuoi prodotti preferiti. Puoi inserire nella lista fino a 30 prodotti
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                    <td align="left"><a name="tre"></a>
                                                         <br />
                                                        <strong>Come posso utilizzare la lista dei desideri?</strong><br />
                                                        Per aggiungere un prodotto nella lista basta cliccare sul pulsante “lista dei desideri” che si trova in tutte le schede dettaglio dei prodotti. Per cancellare un prodotto dalla lista basta accedere alla propria lista e cliccare su cancella
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>                                                    
                                                    <tr>
                                                    <td align="left"><a name="quattro"></a>
                                                         <br />
                                                        <strong>Come posso ordinare?</strong><br />
                                                        Per aiutarti nella compilazione degli ordini abbiamo preparato per te una guida, clicca qui per visualizzarla
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>  
                                                    <tr>
                                                    <td align="left"><a name="cinque"></a>
                                                         <br />
                                                        <strong>È possibile annullare un ordine?</strong><br />
                                                        Gli acquisti su Perbaffo sono assolutamente liberi ed annullabili fino al momento della spedizione.
                                                        Se desiderate annullare un ordine seguite questa semplice procedura:
                                                        <ol>
                                                            <li>Contattate il nostro <a href="Contatti.aspx" title="Contatti e servizio clienti" class="dark_red">SERVIZIO CLIENTI</a> indicando nome, cognome, numero d'ordine e chiedendo espressamente l'annullamento dell'ordine.</li>
                                                            <li>Se avete già effettuato il pagamento con bonifico o ricarica Postepay non dimenticate di indicarci le vostre coordinate bancarie: nome e cognome dell’intestatario e codice IBAN. Provvederemo a restituirvi l'importo tramite bonifico bancario alle coordinate da Voi indicate entro 7 giorni lavorativi.</li>
                                                            <li>Se avete effettuato il pagamento con Paypal vi riaccrediteremo l’importo da voi pagato sul vostro conto Paypal. Non è possibile riaccreditare il pagamento su un conto Paypal diverso da quello da cui è stato effettuato il pagamento</li>
                                                        </ol>                                                        
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>  
                                                    <tr>
                                                    <td align="left"><a name="sei"></a>
                                                        <br />
                                                        <strong>Come faccio a sapere se un prodotto è disponibile? </strong><br />
                                                        Tutti i prodotti presenti sul sito Perbaffo sono ordinabili. Se un prodotto non è presente a magazzino verrà immediatamente richiesto ai fornitori ed entro 48h lavorative sarà disponibile presso il nostro magazzino.
                                                        Ci sono prodotti speciali la cui consegna può richiedere più giorni, questo viene espressamente indicato nel dettaglio del prodotto stesso.                                                       
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>   
                                                    <tr>
                                                    <td align="left"><a name="sette"></a>
                                                        <br />
                                                        <strong>Posso modificare il mio ordine? Posso aggiungere o togliere un prodotto?</strong><br />
                                                        Se desiderate aggiungere o togliere un prodotto dal Vostro ordine, oppure modificarne la quantità è sufficiente che ci inviate un’email con indicate le modifiche ed il numero d’ordine su cui effettuarle. Vi invieremo un’email di conferma a modifiche ricevute. Naturalmente le modifiche sono effettuabili solo se l’ordine non è ancora stato spedito                                                     
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>      
                                                    <tr>
                                                    <td align="left"><a name="otto"></a>
                                                        <br />
                                                        <strong>Sono residente all'estero posso effettuare un ordine?</strong><br />
                                                        Al momento spediamo solo entro i confini nazionali.                                                   
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>    
                                                    <tr>
                                                    <td align="left"><a name="nove"></a>
                                                        <br />
                                                        <strong>Avete dei negozi dove poter acquistare?</strong><br />
                                                        Perbaffo vende esclusivamente on-line.                                                  
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>    
                                                    <tr>
                                                    <td align="left"><a name="dieci"></a>
                                                        <br />
                                                        <strong>Riceverò una conferma d'ordine?</strong><br />
                                                        Sì, dopo pochi istanti dall’ordine riceverete una conferma d’ordine via email con il riepilogo dei prodotti ordinati                                                 
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>  
                                                    <tr>
                                                    <td align="left"><a name="undici"></a>
                                                        <br />
                                                        <strong>Mi informerete quando l'ordine sarà spedito?</strong><br />
                                                        Sì, appena la merce sarà evasa dal nostro magazzino riceverete un’email in cui vi comunicheremo il numero di spedizione                                                
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>      
                                                    <tr>
                                                    <td align="left"><a name="dodici"></a>
                                                        <br />
                                                        <strong>Come posso monitorare lo stato del mio ordine? </strong><br />
                                                        Per monitorare lo stato del vostro ordine vi basterà entrare nel vostro spazio personale su www.perbaffo.it                                               
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>     
                                                    <tr>
                                                    <td align="left"><a name="tredici"></a>
                                                        <br />
                                                        <strong>Ho ricevuto un prodotto ma non è quello da me ordinato… Cosa fare?</strong><br />
                                                        Contattate il nostro <a href="Contatti.aspx" title="Contatti e servizio clienti" class="dark_red">SERVIZIO CLIENTI</a> entro 5 giorni lavorativi dal ricevimento del prodotto indicando nome, cognome, nome prodotto e breve descrizione del motivo per cui chiedete la sostituzione. La sostituzione dei prodotti avviene indicativamente in 10 giorni lavorativi, salvo disponibilità.                                              
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>  
                                                    <tr>
                                                    <td align="left"><a name="quattordici"></a>
                                                        <br />
                                                        <strong>Ho ricevuto un pacco (o più pacchi) con imballo in condizioni non perfette. Cosa fare?</strong><br />
                                                        Accettate la merce apponendo sui documenti di trasporto la scritta “riserva di controllo”; potrete controllare con cura i prodotti contenuti e testarli.
                                                        Se eventualmente riscontraste un problema di funzionamento vi consigliamo di segnalare entro 5 giorni lavorativi dal ricevimento del prodotto l'accaduto, contattando il nostro <a href="Contatti.aspx" title="Contatti e servizio clienti" class="dark_red">SERVIZIO CLIENTI</a> e indicando nome, cognome, numero d’ordine Perbaffo e prodotto danneggiato.                                              
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>      
                                                    <tr>
                                                    <td align="left"><a name="quindici"></a>
                                                        <br />
                                                        <strong>Ho ricevuto un pacco (o più pacchi) danneggiato o aperto. Cosa fare? </strong><br />
                                                        consigliamo di rifiutare la consegna e di segnalare entro 5 giorni lavorativi l'accaduto contattando il nostro <a href="Contatti.aspx" title="Contatti e servizio clienti" class="dark_red">SERVIZIO CLIENTI</a> e indicando nome, cognome, numero d'ordine Perbaffo.                                             
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>  
                                                    <tr>
                                                    <td align="left"><a name="sedici"></a>
                                                        <br />
                                                        <strong>All'apertura del pacco mi sono accorto che mancano alcuni degli articoli che dovevano essere inclusi nella confezione… Cosa fare? </strong><br />
                                                        Contattate il nostro <a href="Contatti.aspx" title="Contatti e servizio clienti" class="dark_red">SERVIZIO CLIENTI</a> entro 5 giorni lavorativi dal ricevimento del prodotto, indicando nome, cognome, numero d'ordine Perbaffo, nome prodotto mancante. Perbaffo dopo aver verificato in magazzino la veridicità della segnalazione provvederà a reintegrare la parte mancante, inviandola a domicilio con corriere indicativamente in 10 lavorativi. Sarà nostra premura informarvi tempestivamente qual'ora i tempi di consegna dovessero subire dei ritardi.                                            
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>    
                                                    <tr>
                                                    <td align="left"><a name="diciasette"></a>
                                                        <br />
                                                        <strong>Potete cambiare il prodotto che erroneamente ho sbagliato ad ordinare? </strong><br />
                                                        Contattate il nostro <a href="Contatti.aspx" title="Contatti e servizio clienti" class="dark_red">SERVIZIO CLIENTI</a> entro 10 giorni lavorativi dal ricevimento del prodotto indicando nome, cognome, numero d'ordine Perbaffo, nome prodotto e richiesta esplicita del cambio.
                                                        Vi comunicheremo la procedura da seguire per effettuare il reso.
                                                        Resta inteso che tutte le spese per effettuare tale operazione sono a carico Vostro. 
                                                        Il cambio dei prodotti avviene indicativamente in 10 giorni lavorativi, salvo disponibilità prodotti.                                           
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>   
                                                    <tr>
                                                    <td align="left"><a name="diciotto"></a>
                                                        <br />
                                                        <strong>Posso usufruire del diritto di recesso? </strong><br />
                                                        Certamente puoi rendere gli articoli da te acquistati senza doverci fornire alcuna spiegazione, per avere maggiori informazioni consultare il paragrafo “diritto di recesso” nella pagina <a href="Termini-Condizioni.aspx" title="Termini e condizioni" class="dark_red">TERMINI E CONDIZIONI</a>                                          
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>      
                                                    <tr>
                                                    <td align="left"><a name="diciannove"></a>
                                                        <br />
                                                        <strong>Come posso riscuotere uno sconto? </strong><br />
                                                            Se avete buoni sconti dovrete inserirli in fase di conferma d’ordine.
                                                            Il buono sconto va inserito  nel campo “codice sconto”  e poi bisogna cliccare su “aggiorna”
                                                            l’importo dello sconto verrà automaticamente detratto dal totale ordine.
                                                            Il buono è utilizzabile solo per un acquisto. 
                                                            Non è possibile riscuotere un buono per ordini già evasi. Vi consigliamo di fare attenzione alle condizioni di riscossione del buono, come data di scadenza e importo minimo d'ordine.                                        
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>   
                                                    <tr>
                                                    <td align="left"><a name="venti"></a>
                                                        <br />
                                                        <strong>Posso utilizzare più di un buono sconto per ordine? </strong><br />
                                                        E' possibile utilizzare un solo sconto per ogni ordine effettuato.                                     
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>   
                                                    <tr>
                                                    <td align="left"><a name="ventuno"></a>
                                                        <br />
                                                        <strong>Posso convertire un buono acquisto in contanti? </strong><br />
                                                        Non è possibile riscuotere un buono in contanti o incassare buoni usando ordini precedentemente effettuati.                                    
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>    
                                                    <tr>
                                                    <td align="left"><a name="ventidue"></a>
                                                        <br />
                                                        <strong>Come posso essere informato sulle vostre offerte speciali? </strong><br />
                                                        Potete tenervi sempre aggiornati iscrivendovi alla nostra Newsletter. 
                                                        Vi invieremo ogni 15 giorni una newsletter commerciale con tutte le ultime offerte e le novità.
                                                        Se siete un nuovo cliente zooplus potrete iscrivervi al mailing delle offerte al momento della registrazione come utente.                                  
                                                        <br />
                                                        <a href="#menu">[Torna su]</a> 
                                                        </td>
                                                    </tr>  
                                                    <tr>
                                                    <td align="left"><a name="ventitre"></a>
                                                        <br />
                                                        <strong>Come posso cancellarmi dal mailing delle offerte di Perbaffo?</strong><br />
                                                        siete registrati su Perbaffo potete cancellarvi dalla newsletter accedendo alla vostra area personale. Se siete utenti non registrati dovrete cliccare sul link cancellami che si trova al fondo di ogni newsletter                                 
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