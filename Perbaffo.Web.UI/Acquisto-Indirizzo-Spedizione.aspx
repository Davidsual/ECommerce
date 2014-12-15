<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acquisto-Indirizzo-Spedizione.aspx.cs"
    Inherits="Perbaffo.Web.UI.Acquisto_Indirizzo_Spedizione" %>

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
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />
    <link rel="Stylesheet" type="text/css" href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />

    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>

</head>
<body>
    <form runat="server" id="frmLogin">
    <asp:ScriptManager ID="ScriptManager1" runat="server" LoadScriptsBeforeUI="true">
    </asp:ScriptManager>
    <UserControl:Header ID="Header1" runat="server" />
    <table border="0" cellspacing="0" cellpadding="0" style="width: 1000px; background-color: #cddded;
        height: 35px;">
        <tbody>
            <tr>
                <td align="left" class="topLeftStyle">
                </td>
                <td align="right" valign="middle">
                    <h1>
                        <b>Indirizzo di spedizione</b></h1>
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
                    <img src="images/ordine_step_1.gif" title="Inserisci l'indirizzo in cui desideri venga consegnata la merce"
                        width="479" height="59" border="0" style="display: block" />
                    <span>Inserisci l'indirizzo in cui vuoi che vengano recapitati i prodotti scelti<br />Se durante il giorno non siete reperibili al vostro domicilio potete indicare l'indirizzo del posto di lavoro, di parenti, ...</span>
                    <asp:UpdatePanel ID="updPnlAcquisto" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="boundingbox" border="0" cellspacing="0" cellpadding="10" style="margin: 20 0 0 0;
                                width: 600px">
                                <tbody>
                                    <tr>
                                        <td  bgcolor="#cddded" style="font-size:15px;color:Red;">
                                            <b>Inserisci l'indirizzo in cui desideri venga recapitata la merce<br />Se durante il giorno non siete reperibili al vostro domicilio potete indicare l'indirizzo del posto di lavoro, di parenti, ...</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="bodycopy">
                                            <table border="0" cellspacing="0" cellpadding="0" width="90%">
                                                <tbody>
                                                    <tr>
                                                        <td class="bodycopy" align="left" valign="top">
                                                            <b>E-Mail</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblEMail" runat="server" Text="" CssClass="med_text" Style="color: Black;"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left" valign="top">
                                                            <b>Nome</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtNome" runat="server" CssClass="pp_box_registrazione_disabled"
                                                                Width="200" MaxLength="49" TabIndex="1" ReadOnly="true"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome"
                                                                ErrorMessage="Inserire il proprio nome" ToolTip="Inserire il proprio nome" ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left" valign="top">
                                                            <b>Cognome</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCognome" runat="server" CssClass="pp_box_registrazione_disabled"
                                                                Width="200" MaxLength="49" TabIndex="2" ReadOnly="true"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCognome"
                                                                ErrorMessage="Inserire il proprio cognome" ToolTip="Inserire il proprio cognome"
                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left" valign="top">
                                                            <b>Indirizzo</b> (indica via/corso..)
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtVia" runat="server" CssClass="pp_box_registrazione_disabled"
                                                                Width="300" MaxLength="400" TabIndex="3" ReadOnly="true"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Inserire la propria via di residenza"
                                                                ControlToValidate="txtVia" ToolTip="Inserire la propria via di residenza" ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left" valign="top">
                                                            <b>Numero civico</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtNumCivico" runat="server" CssClass="pp_box_registrazione_disabled"
                                                                Width="150" MaxLength="49" TabIndex="4" ReadOnly="true"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtNumCivico"
                                                                ErrorMessage="Inserire il proprio numero civico di residenza" ToolTip="Inserire il proprio numero civico di residenza"
                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left" valign="top">
                                                            <b>CAP</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCAP" runat="server" CssClass="pp_box_registrazione_disabled"
                                                                Width="50" MaxLength="5" TabIndex="5" ReadOnly="true"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Inserire il proprio CAP di residenza"
                                                                ControlToValidate="txtCAP" ToolTip="Inserire il proprio CAP di residenza" ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left" valign="top">
                                                            <b>Provincia</b>
                                                        </td>
                                                        <td align="left">
                                                            <select name="ddlProvincie" id="ddlProvincie" runat="server" style="width: 200px;"
                                                                class="pp_box_registrazione_disabled" tabindex="6" disabled="true">
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
                                                                <option value="AQ">L'Aquila</option>
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
                                                        <td class="bodycopy" align="left" valign="top">
                                                            <b>Città</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCitta" runat="server" CssClass="pp_box_registrazione_disabled"
                                                                Width="300" MaxLength="198" TabIndex="7" ReadOnly="true"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Inserire la propria città di residenza"
                                                                ControlToValidate="txtCitta" ToolTip="Inserire la propria città di residenza"
                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left" valign="top">
                                                            <b>Numero di telefono</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="pp_box_registrazione_disabled"
                                                                Width="200" MaxLength="40" TabIndex="8" ReadOnly="true"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ToolTip="Inserire il proprio numero di telefono"
                                                                ControlToValidate="txtTelefono" ErrorMessage="Inserire il proprio numero di telefono"
                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left" valign="top">
                                                            <b>Note</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtNote" TextMode="MultiLine" runat="server" CssClass="pp_box_registrazione_disabled"
                                                                Width="300" TabIndex="9" Rows="4" ReadOnly="true" MaxLength="290"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="left">
                                                            <span class="small_text">I campi con l’asterisco * sono obbligatori e devono essere
                                                                compilati</span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="right">
                                                            <asp:Button ID="btnModifica" runat="server" Text="Modifica" CommandName="MOD" CssClass="standardsubmit"
                                                                TabIndex="10" ToolTip="Modifica i dati di spedizione" OnClick="btnModifica_Click" />
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
                                                TabIndex="11" ToolTip="Continua con l'acquisto" ValidationGroup="UTENTE" OnClick="btnContinua_Click" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="UTENTE" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
                <td class="ppmainrightline" width="10">
                    <img src="images/pixel.gif" width="12" height="12" alt="" />
                </td>
            </tr>
            <tr>
                <td align="left" class="bottomLeftStyle">
                </td>
                <td class="ppmainbotline" style="height: 12px;">
                </td>
                <td align="right" class="bottomRightStyle">
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
