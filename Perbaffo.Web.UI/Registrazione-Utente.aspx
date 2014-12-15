<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrazione-Utente.aspx.cs"
    Inherits="Perbaffo.Web.UI.Registrazione_Utente" %>

<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
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
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />
    

    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>
    <script language="javascript" type="text/javascript">
        function RequiredPrivacy(oSrc, args) 
        {
            var _chk = document.getElementById("chkAccetta");
            if (_chk == null) {
                args.IsValid = true;
                return;
            }
            if (_chk.checked == false) 
            {
                    args.IsValid = false;
            }
         }
</script>
</head>
<body>
    <UserControl:Header ID="Header1" runat="server" />
    <form runat="server" id="frmLogin">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" cellspacing="0" cellpadding="0" style="width: 1000px; background-color: #cddded;
        height: 35px;">
        <tbody>
            <tr>
                <td align="left" class="topLeftStyle">
                </td>
                <td align="right" valign="middle">
                    <h1>
                        <b>Registrazione dati personali</b></h1>
                </td>
                <td align="right" class="topRightStyle">
                </td>
            </tr>
        </tbody>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="1000">
        <tbody>
            <tr>
                <td class="ppmainleftline" width="10">
                    <img src="images/pixel.gif" width="12" height="12" alt="" />
                </td>
                <td class="bodycopy" align="center">
                    <img src="images/Registrazione_passo_1.gif" alt="Registrazione dati personali" width="256" height="59" border="0" style="display:block"/>
                    <span>In questa mascherra verranno richiesti i tuoi dati personali per 
                    registrarti su Perbaffo.it. </span>
                    <asp:UpdatePanel ID="updPnlUtente" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="boundingbox" border="0" cellspacing="0" cellpadding="10" style="margin: 20 0 0 0;
                                width: 600px">
                                <tbody>
                                    <tr>
                                        <td class="bodycopyy" bgcolor="#cddded">
                                            <b>Dati personali</b> - I tuoi dati personali
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="bodycopy">
                                            <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Indirizzo E-Mail</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblEMail" runat="server" Text="" CssClass="med_text" Style="color: Black;"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Nome</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtNome" runat="server" CssClass="pp_box_registrazione" Width="200"
                                                                MaxLength="50" TabIndex="1"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome"
                                                                ErrorMessage="Inserire il proprio nome" ToolTip="Inserire il proprio nome" ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Cognome</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCognome" runat="server" CssClass="pp_box_registrazione" Width="200"
                                                                MaxLength="50" TabIndex="2"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCognome"
                                                                ErrorMessage="Inserire il proprio cognome" ToolTip="Inserire il proprio cognome"
                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Azienda</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtAzienda" runat="server" CssClass="pp_box_registrazione" Width="200"
                                                                MaxLength="150" TabIndex="3"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Codice Fiscale / P.IVA</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCodiceFiscale" runat="server" CssClass="pp_box_registrazione"
                                                                Width="150" MaxLength="16" TabIndex="4"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCodiceFiscale"
                                                                ErrorMessage="Inserire il proprio codice fiscale" ToolTip="Inserire il proprio codice fiscale"
                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Data di Nascita</b>
                                                        </td>
                                                        <td align="left">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="250">
                                                                <tbody>
                                                                    <tr>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlGiorno" runat="server" CssClass="pp_box_registrazione" Width="50"
                                                                                TabIndex="5">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlGiorno"
                                                                                ErrorMessage="Inserire il proprio giorno di nascita" InitialValue="" ToolTip="Inserire il proprio giorno di nascita"
                                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlMese" runat="server" CssClass="pp_box_registrazione" Width="80"
                                                                                TabIndex="6">
                                                                            </asp:DropDownList>
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Inserire il proprio mese di nascita"
                                                                                ControlToValidate="ddlMese" InitialValue="" ToolTip="Inserire il proprio mese di nascita"
                                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                                        </td>
                                                                        <td align="left">
                                                                            <asp:DropDownList ID="ddlAnno" runat="server" CssClass="pp_box_registrazione" Width="60"
                                                                                TabIndex="7">
                                                                            </asp:DropDownList>
                                                                            &nbsp;*
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Inserire il proprio anno di nascita"
                                                                                ControlToValidate="ddlAnno" InitialValue="" ToolTip="Inserire il proprio anno di nascita"
                                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Provincia</b>
                                                        </td>
                                                        <td align="left">
                                                            <select name="ddlProvincie" id="ddlProvincie" runat="server" style="width: 200px;"
                                                                class="pp_box_registrazione" tabindex="8">
                                                                <option value="" selected="selected">Seleziona</option>
                                                                <option value="AG">Agrigento</option>
                                                                <option value="AL">Alessandria</option>
                                                                <option value="AN">Ancona</option>
                                                                <option value="AO">Aosta</option>
                                                                <option value="AR">Arezzo</option>
                                                                <option value="AP">Ascoli Piceno</option>
                                                                <option value="AT">Asti</option>
                                                                <option value="AV">Avellino</option>
                                                                <option value="BA">Bari</option>
                                                                <option value="BL">Belluno</option>
                                                                <option value="BN">Benevento</option>
                                                                <option value="BG">Bergamo</option>
                                                                <option value="BI">Biella</option>
                                                                <option value="BO">Bologna</option>
                                                                <option value="BZ">Bolzano</option>
                                                                <option value="BS">Brescia</option>
                                                                <option value="BR">Brindisi</option>
                                                                <option value="CA">Cagliari</option>
                                                                <option value="CL">Caltanissetta</option>
                                                                <option value="CB">Campobasso</option>
                                                                <option value="CE">Caserta</option>
                                                                <option value="CT">Catania</option>
                                                                <option value="CZ">Catanzaro</option>
                                                                <option value="CH">Chieti</option>
                                                                <option value="CO">Como</option>
                                                                <option value="CS">Cosenza</option>
                                                                <option value="CR">Cremona</option>
                                                                <option value="KR">Crotone</option>
                                                                <option value="CN">Cuneo</option>
                                                                <option value="EN">Enna</option>
                                                                <option value="FE">Ferrara</option>
                                                                <option value="FI">Firenze</option>
                                                                <option value="FG">Foggia</option>
                                                                <option value="FC">Forli-Cesena</option>
                                                                <option value="FR">Frosinone</option>
                                                                <option value="GE">Genova</option>
                                                                <option value="GO">Gorizia</option>
                                                                <option value="GR">Grosseto</option>
                                                                <option value="IM">Imperia</option>
                                                                <option value="IS">Isernia</option>
                                                                <option value="SP">La Spezia</option>
                                                                <option value="AQ">L&#39;Aquila</option>
                                                                <option value="LT">Latina</option>
                                                                <option value="LE">Lecce</option>
                                                                <option value="LC">Lecco</option>
                                                                <option value="LI">Livorno</option>
                                                                <option value="LO">Lodi</option>
                                                                <option value="LU">Lucca</option>
                                                                <option value="MC">Macerata</option>
                                                                <option value="MN">Mantova</option>
                                                                <option value="MS">Massa-Carrara</option>
                                                                <option value="MT">Matera</option>
                                                                <option value="ME">Messina</option>
                                                                <option value="MI">Milano</option>
                                                                <option value="MO">Modena</option>
                                                                <option value="NA">Napoli</option>
                                                                <option value="NO">Novara</option>
                                                                <option value="NU">Nuoro</option>
                                                                <option value="OR">Oristano</option>
                                                                <option value="PD">Padova</option>
                                                                <option value="PA">Palermo</option>
                                                                <option value="PR">Parma</option>
                                                                <option value="PV">Pavia</option>
                                                                <option value="PG">Perugia</option>
                                                                <option value="PU">Pesaro-Urbino</option>
                                                                <option value="PE">Pescara</option>
                                                                <option value="PC">Piacenza</option>
                                                                <option value="PI">Pisa</option>
                                                                <option value="PT">Pistoia</option>
                                                                <option value="PN">Pordenone</option>
                                                                <option value="PZ">Potenza</option>
                                                                <option value="PO">Prato</option>
                                                                <option value="RG">Ragusa</option>
                                                                <option value="RA">Ravenna</option>
                                                                <option value="RC">Reggio Calabria</option>
                                                                <option value="RE">Reggio Emilia</option>
                                                                <option value="RI">Rieti</option>
                                                                <option value="RN">Rimini</option>
                                                                <option value="RM">Roma</option>
                                                                <option value="RO">Rovigo</option>
                                                                <option value="SA">Salerno</option>
                                                                <option value="SS">Sassari</option>
                                                                <option value="SV">Savona</option>
                                                                <option value="SI">Siena</option>
                                                                <option value="SR">Siracusa</option>
                                                                <option value="SO">Sondrio</option>
                                                                <option value="TA">Taranto</option>
                                                                <option value="TE">Teramo</option>
                                                                <option value="TR">Terni</option>
                                                                <option value="TO">Torino</option>
                                                                <option value="TP">Trapani</option>
                                                                <option value="TN">Trento</option>
                                                                <option value="TV">Treviso</option>
                                                                <option value="TS">Trieste</option>
                                                                <option value="UD">Udine</option>
                                                                <option value="VA">Varese</option>
                                                                <option value="VB">Verbano-Cusio-Ossola</option>
                                                                <option value="VC">Vercelli</option>
                                                                <option value="VE">Venezia</option>
                                                                <option value="VI">Vicenza</option>
                                                                <option value="VR">Verona</option>
                                                                <option value="VT">Viterbo</option>
                                                                <option value="VV">Vibo Valentia</option>
                                                            </select>
                                                            &nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlProvincie"
                                                                InitialValue="" ErrorMessage="Inserire la propria provincia di residenza" ToolTip="Inserire la propria provincia di residenza"
                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Città</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCitta" runat="server" CssClass="pp_box_registrazione" Width="300"
                                                                MaxLength="200" TabIndex="9"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Inserire la propria città di residenza"
                                                                ControlToValidate="txtCitta" ToolTip="Inserire la propria città di residenza"
                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Indirizzo (indica via/corso/piazza..)</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtVia" runat="server" CssClass="pp_box_registrazione" Width="300"
                                                                MaxLength="400" TabIndex="10"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Inserire la propria via di residenza"
                                                                ControlToValidate="txtVia" ToolTip="Inserire la propria via di residenza" ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Numero civico</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtNumCivico" runat="server" CssClass="pp_box_registrazione" Width="150"
                                                                MaxLength="50" TabIndex="11"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNumCivico"
                                                                ErrorMessage="Inserire il proprio numero civico di residenza" ToolTip="Inserire il proprio numero civico di residenza"
                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>CAP</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCAP" runat="server" CssClass="pp_box_registrazione" Width="50"
                                                                MaxLength="5" TabIndex="12"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Inserire il proprio CAP di residenza"
                                                                ControlToValidate="txtCAP" ToolTip="Inserire il proprio CAP di residenza" ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Numero di telefono</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="pp_box_registrazione" Width="200"
                                                                MaxLength="40" TabIndex="13"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ToolTip="Inserire il proprio numero di telefono"
                                                                ControlToValidate="txtTelefono" ErrorMessage="Inserire il proprio numero di telefono"
                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Legge privacy</b>
                                                        </td>
                                                        <td align="left">
                                                            <textarea rows="10" name="S1" cols="47" class="pp_box_registrazione" readonly="readonly">
                                                                Informativa
                                                                 
                                                                Informativa art. 13 D.Lgs. 196/2003
                                                                 
                                                                Si informa il sottoscrittore della presente che il decreto legislativo n. 196/2003 prevede la tutela delle persone e di altri soggetti rispetto al trattamento dei dati personali. Secondo le leggi indicate, tale trattamento sarà improntato ai principi di correttezza, liceità e trasparenza tutelando la riservatezza e i diritti del sottoscrittore. Le seguenti informazioni vengono fornite ai sensi dell&#39;articolo 13 del decreto legislativo n. 196/2003.
                                                                Il trattamento che intendiamo effettuare:
                                                                 
                                                                a)	ha la finalità di concludere, gestire ed eseguire i contratti di fornitura dei servizi richiesti; di organizzare, gestire ed eseguire la fornitura dei servizi anche mediante comunicazione dei dati a terzi nostri fornitori; di assolvere agli obblighi di legge o agli altri adempimenti richiesti dalle competenti Autorità;
                                                                b)	sarà effettuato con le seguenti modalità: informatizzato/manuale;
                                                                c)	salvo quanto strettamente necessario per la corretta esecuzione del contratto di fornitura, i dati non saranno comunicati ad altri soggetti, se non chiedendoLe espressamente il consenso. 
                                                                 
                                                                Informiamo ancora che la comunicazione dei dati è indispensabile ma non obbligatoria e l&#39;eventuale rifiuto non ha alcuna conseguenza ma potrebbe comportare il mancato puntuale adempimento delle obbligazioni assunte da Perbaffo per la fornitura del servizio da Lei richiesto. Il titolare del trattamento è Perbaffo con sede legale Via Nino Costa 16, 10044 Pianezza(TO), alla quale può rivolgersi per far valere i Suoi diritti così come previsto dall&#39;articolo 7 del decreto legislativo n. 196/2003, che riportiamo di seguito per esteso: 
                                                                 
                                                                 
                                                                Art. 7
                                                                Diritto di accesso ai dati personali ed altri diritti
                                                                1. L&#39;interessato ha diritto di ottenere la conferma dell&#39;esistenza o meno di dati personali che lo riguardano, anche se non ancora registrati, e la loro comunicazione in forma intelligibile.
                                                                2. L&#39;interessato ha diritto di ottenere l&#39;indicazione:
                                                                a) dell&#39;origine dei dati personali;
                                                                b) delle finalità e modalità del trattamento;
                                                                c) della logica applicata in caso di trattamento effettuato con l&#39;ausilio di strumenti elettronici;
                                                                d) degli estremi identificativi del titolare, dei responsabili e del rappresentante designato ai sensi dell&#39;articolo 5, comma 2;
                                                                e) dei soggetti o delle categorie di soggetti ai quali i dati personali possono essere comunicati o che possono venirne a conoscenza in qualità di rappresentante designato nel territorio dello Stato, di responsabili o incaricati.
                                                                3. L&#39;interessato ha diritto di ottenere:
                                                                a) l&#39;aggiornamento, la rettificazione ovvero, quando vi ha interesse, l&#39;integrazione dei dati;
                                                                b) la cancellazione, la trasformazione in forma anonima o il blocco dei dati trattati in violazione di legge, compresi quelli di cui non è necessaria la conservazione in relazione agli scopi per i quali i dati sono stati raccolti o successivamente trattati;
                                                                c) l&#39;attestazione che le operazioni di cui alle lettere a) e b) sono state portate a conoscenza, anche per quanto riguarda il loro contenuto, di coloro ai quali i dati sono stati comunicati o diffusi, eccettuato il caso in cui tale adempimento si rivela impossibile o comporta un impiego di mezzi manifestamente sproporzionato rispetto al diritto tutelato.
                                                                4. L&#39;interessato ha diritto di opporsi, in tutto o in parte:
                                                                a) per motivi legittimi al trattamento dei dati personali che lo riguardano, ancorché pertinenti allo scopo della raccolta;
                                                                b) al trattamento di dati personali che lo riguardano a fini di invio di materiale pubblicitario o di vendita diretta o per il compimento di ricerche di mercato o di comunicazione commerciale.
                                                                 
                                                                 
                                                                 
                                                                 
                                                                Formula di consenso
                                                                 
                                                                Acquisite le informazioni che precedono, rese ai sensi dell&#39;art. 13 del D.Lgs. 196/2003, consento al trattamento dei miei dati come sopra descritto.
                                                                </textarea><br />
                                                            <asp:CheckBox ID="chkAccetta" CssClass="small_text" runat="server" Text="Autorizzo" />
                                                            <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Per proseguire con la registrazione bisogna autorizzare il trattamento dei propri dati ai sensi di legge" ValidationGroup="UTENTE" ClientValidationFunction="RequiredPrivacy">!</asp:CustomValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="left">
                                                            <span class="small_text">I campi con l’asterisco * sono obbligatori e devono 
                                                            essere compilati</span>
                                                        </td>
                                                    </tr>                                                    
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="boundingbox" border="0" cellspacing="0" cellpadding="30" style="margin: 20 0 0 0;
                                width: 600px">
                                <tbody>
                                    <tr>
                                        <td class="bodycopyy" bgcolor="#cddded">
                                            <b>NewsLetter</b> - Indica a quale categoria di newsletter intendi iscriverti 
                                            (facoltativo)
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="bodycopy">
                                            <table border="0" cellspacing="2" cellpadding="2" align="center">
                                                <tbody>
                                                    <tr>
                                                        <td align="center">
                                                            <img border="0" width="80" height="80" alt="Newsletter Cani" src="images/newsletter/Newsletter_Cani.jpg" />
                                                        </td>
                                                        <td align="center">
                                                            <img border="0" alt="Newsletter Gatti" src="images/newsletter/Neswsletter_gatti.jpg"
                                                                width="80" height="80" />
                                                        </td>
                                                        <td align="center">
                                                            <img border="0" alt="Newsletter Roditori" src="images/newsletter/Newsletter_roditori.jpg"
                                                                width="80" height="80" />
                                                        </td>
                                                        <td align="center">
                                                            <img border="0" alt="Newsletter Uccelli" src="images/newsletter/Newsletter_volatili.jpg"
                                                                width="80" height="80" />
                                                        </td>
                                                        <td align="center">
                                                            <img border="0" alt="Newsletter Pesci" src="images/newsletter/Newsletter_pesci.jpg"
                                                                width="80" height="80" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:CheckBox ID="chkDog" runat="server" EnableViewState="false" TabIndex="14" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:CheckBox ID="chkGatto" runat="server" EnableViewState="false" TabIndex="15" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:CheckBox ID="chkRoditori" runat="server" EnableViewState="false" TabIndex="16" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:CheckBox ID="chkVolatili" runat="server" EnableViewState="false" TabIndex="17" />
                                                        </td>
                                                        <td align="center">
                                                            <asp:CheckBox ID="chkPesci" runat="server" EnableViewState="false" TabIndex="18" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table border="0" cellspacing="0" cellpadding="0" style="margin: 20 0 0 0; width: 600px">
                                <tbody>
                                    <tr>
                                        <td class="bodycopyy" align="right">
                                            <asp:Button ID="btnContinua" runat="server" Text="Continua &gt;&gt;" CssClass="standardsubmitCancella"
                                                TabIndex="19" ToolTip="Continua la registrazione" ValidationGroup="UTENTE" OnClick="btnContinua_Click" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="UTENTE" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <img border="0" src="/images/pixel.gif" width="1" height="5" alt="" /><br />
                    <img border="0" src="/images/pixel.gif" width="1" height="5" alt="" /><br />
                </td>
                <td class="ppmainrightline" width="10">
                    <img src="images/pixel.gif" width="12" height="12" alt="" />
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
        </tbody>
    </table>
    </form>
</body>
</html>
