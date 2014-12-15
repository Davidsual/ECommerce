<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrazione-Utente-Dati.aspx.cs" Inherits="Perbaffo.Web.UI.Registrazione_Utente_Dati" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
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
    <script type="text/javascript" language="javascript">
    function fSubmit() {
        try
        {
            __doPostBack('Load', 'Reload'); 
        }
        catch (err) {
            return;
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
                        <b>Modifica i tuoi dati personali</b></h1>
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
                    <span>Aggiorna i tuoi dati personali, indirizzo e numero di telefono.</span>
                            <table class="boundingbox" border="0" cellspacing="0" cellpadding="10" style="margin: 20 0 0 0;
                                width: 600px">
                                <tbody>
                                    <tr>
                                        <td class="bodycopyy" bgcolor="#cddded">
                                            <span><b>Modifica dati personali</b></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="bodycopy">
                                            <asp:UpdatePanel ID="updPnlPreviewFoto" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
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
                                                            <asp:Label ID="lblNome" runat="server" Text="" CssClass="med_text" Style="color: Black;"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Cognome</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCognome" runat="server" Text="" CssClass="med_text" Style="color: Black;"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Codice Fiscale / P.IVA</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblCodiceFiscale" runat="server" Text="" CssClass="med_text" Style="color: Black;"></asp:Label>
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
                                                            <b>Azienda</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtAzienda" runat="server" CssClass="pp_box_registrazione" 
                                                                Width="200" MaxLength="150" TabIndex="3"></asp:TextBox>
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
                                                        <td class="bodycopy" align="left">
                                                            <b>Città</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtCitta" runat="server" CssClass="pp_box_registrazione" 
                                                                Width="300" MaxLength="200" TabIndex="9"></asp:TextBox>&nbsp;*
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
                                                            <asp:TextBox ID="txtVia" runat="server" CssClass="pp_box_registrazione" 
                                                                Width="300" MaxLength="400" TabIndex="10"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Inserire la propria via di residenza"
                                                                ControlToValidate="txtVia" ToolTip="Inserire la propria via di residenza" ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Numero civico</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtNumCivico" runat="server" CssClass="pp_box_registrazione" 
                                                                Width="150" MaxLength="50" TabIndex="11"></asp:TextBox>&nbsp;*
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
                                                            <asp:TextBox ID="txtCAP" runat="server" CssClass="pp_box_registrazione" 
                                                                Width="50" MaxLength="5" TabIndex="12"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Inserire il proprio CAP di residenza"
                                                                ControlToValidate="txtCAP" ToolTip="Inserire il proprio CAP di residenza" ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Numero di telefono</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="pp_box_registrazione" 
                                                                Width="200" MaxLength="40" TabIndex="13"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ToolTip="Inserire il proprio numero di telefono"
                                                                ControlToValidate="txtTelefono" ErrorMessage="Inserire il proprio numero di telefono"
                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="left">
                                                            <span class="small_text">I campi con l’asterisco * sono obbligatori e devono essere
                                                                compilati</span>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table border="0" cellspacing="0" cellpadding="0" style="margin: 20 0 0 0; width: 600px">
                                <tbody>
                                    <tr>                              
                                        <td class="bodycopyy" align="right">  
                                            <asp:Button ID="btnPannello" runat="server" Text="Pannello" CssClass="standardsubmit"
                                                TabIndex="19" ToolTip="Ritorna al pannello di controllo" onclick="btnPannello_Click"  
                                                />&nbsp;&nbsp;                                                                          
                                            <asp:Button ID="btnContinua" runat="server" Text="Aggiorna" CssClass="standardsubmit"
                                                TabIndex="20" ToolTip="Aggiorna dati" onclick="btnContinua_Click" 
                                                ValidationGroup="UTENTE" />                                               
                                        </td>                                    
                                    </tr>
                                </tbody>
                            </table>
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