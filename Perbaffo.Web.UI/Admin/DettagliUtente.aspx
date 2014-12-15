<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PerbaffoMaster.Master"
    CodeBehind="DettagliUtente.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.DettagliUtente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="98%" style="font-family: Verdana; font-size: 16pt; font-weight: bold">
        <tr>
            <td rowspan="2" width="80" height="64" align="center">
                <img border="0" src="img/prodotti.gif" width="48" height="48">
            </td>
            <td>
                <table border="0" width="100%" style="font-family: Verdana; font-size: 16pt; font-weight: bold;
                    border-bottom: 1px solid #D6DFF5; padding: 0">
                    <tr>
                        <td align="left" valign="middle" style="color: #3366CC">
                            Gestione Utente
                        </td>
                        <td align="right" valign="top">
                            <table border="0" style="padding: 0">
                                <tr>
                                    <td align="right" valign="top">
                                        <asp:LinkButton ID="returnLink" runat="server" Style="font-size: 8pt; font-weight: normal"
                                            OnClick="returnLink_Click">Livello superiore</asp:LinkButton>
                                    </td>
                                    <td width="22">
                                        <asp:LinkButton ID="returnLink2" runat="server" OnClick="returnLink_Click"> <img border="0" src="img/up2.gif" width="22" height="22" alt="Livello superiore"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td height="10">
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="updPnlUtente" UpdateMode="Conditional" runat="server">
        <ContentTemplate>
            <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                <tr>
                    <td>
                        Nome
                    </td>
                    <td>
                        <asp:TextBox ID="txtNome" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNome"
                            ErrorMessage="Nome obbligatorio" ValidationGroup="Utente">!</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Cognome
                    </td>
                    <td>
                        <asp:TextBox ID="txtCognome" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtCognome"
                            ErrorMessage="Cognome obbligatorio" ValidationGroup="Utente">!</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Ragione sociale
                    </td>
                    <td>
                        <asp:TextBox ID="txtRagioneSociale" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Codice Fiscale / P.Iva
                    </td>
                    <td>
                        <asp:TextBox ID="txtCodFisc" runat="server" Width="250px" MaxLength="16"></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                            ControlToValidate="txtCodFisc" ErrorMessage="Codice fiscale/PIva obbligatoria" 
                            ValidationGroup="Utente">!</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td >
                        <b>Data di Nascita</b>
                    </td>
                    <td>
                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                            <tbody>
                                <tr>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlGiorno" runat="server" CssClass="pp_box_registrazione" 
                                            Width="50" TabIndex="5">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="ddlGiorno"
                                            ErrorMessage="Inserire il proprio giorno di nascita" InitialValue="" ToolTip="Inserire il proprio giorno di nascita"
                                            ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlMese" runat="server" CssClass="pp_box_registrazione" 
                                            Width="80" TabIndex="6">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Inserire il proprio mese di nascita"
                                            ControlToValidate="ddlMese" InitialValue="" ToolTip="Inserire il proprio mese di nascita"
                                            ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                    </td>
                                    <td align="left">
                                        <asp:DropDownList ID="ddlAnno" runat="server" CssClass="pp_box_registrazione" 
                                            Width="60" TabIndex="7">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Inserire il proprio anno di nascita"
                                            ControlToValidate="ddlAnno" InitialValue="" ToolTip="Inserire il proprio anno di nascita"
                                            ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>                
                <tr>
                    <td>
                        Indirizzo
                    </td>
                    <td>
                        <asp:TextBox ID="txtIndirizzo" runat="server" Width="250px" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtIndirizzo"
                            ErrorMessage="Indirizzo obbligatorio" ValidationGroup="Utente">!</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Num Civico
                    </td>
                    <td>
                        <asp:TextBox ID="txtNumCivico" runat="server" Width="250px" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtNumCivico"
                            ErrorMessage="Numero civico obbligatorio" ValidationGroup="Utente">!</asp:RequiredFieldValidator>
                    </td>
                </tr>                
                <tr>
                    <td>
                        C.A.P.
                    </td>
                    <td>
                        <asp:TextBox ID="txtCap" runat="server" MaxLength="5"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCap"
                            ErrorMessage="Cap obbligatorio" ValidationGroup="Utente">!</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Citta
                    </td>
                    <td>
                        <asp:TextBox ID="txtCitta" runat="server" Width="250px" MaxLength="200"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCitta"
                            ErrorMessage="Citta obbligatoria" ValidationGroup="Utente">!</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Provincia
                    </td>
                    <td>
                        <select name="ddlProvincie" id="ddlProvincie" runat="server" style="width: 200px;">
                            <option value="" selected="selected">Seleziona</option>
                            <option value="Extra Italy">Extra Italy</option>
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
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlProvincie"
                            ErrorMessage="Provincia obbligatoria" InitialValue="0" ValidationGroup="Utente">!</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Telefono (casa o cellulare)
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelefono" runat="server" Width="250px" MaxLength="20"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtTelefono"
                            ErrorMessage="Telefono obbligatorio" ValidationGroup="Utente">!</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Note di Perbaffo
                    </td>
                    <td>
                        <asp:TextBox ID="txtNotePerbaffo" runat="server" TextMode="MultiLine" 
                            Width="250px" Rows="5"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        E-Mail
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="E-Mail obbligatoria" ValidationGroup="Utente">!</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Password
                    </td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" MaxLength="20" Width="200px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtPassword"
                            ErrorMessage="Password obbligatoria" ValidationGroup="Utente">!</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        Data iscrizione
                    </td>
                    <td>
                        <asp:TextBox ID="txtDataIscrizione" runat="server" ReadOnly="true" 
                            Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Data ultimo login
                    </td>
                    <td>
                        <asp:TextBox ID="txtDataLastLogin" runat="server" ReadOnly="true" 
                            Enabled="False"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Attivo
                    </td>
                    <td>
                        <asp:CheckBox ID="chkAttivo" runat="server" Checked="true" />
                    </td>
                </tr>
            </table>
            <br />
            <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                <tr>
                    <td>
                        Iscrizione alla Newsletter
                    </td>
                </tr>
            </table>
            <br />
            <table border="1" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                <tr>
                    <td align="center" style="width: 16%">
                        Gatti
                    </td>
                    <td align="center" style="width: 16%">
                        Cani
                    </td>
                    <td align="center" style="width: 16%">
                        Roditori
                    </td>
                    <td align="center" style="width: 16%">
                        Volatili
                    </td>
                    <td align="center" style="width: 16%">
                        Rettili
                    </td>
                    <td align="center" style="width: 16%">
                        Acquarologia
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:CheckBox ID="chkGatti" runat="server" />
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkCani" runat="server" />
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkRoditori" runat="server" />
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkVolatili" runat="server" />
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkRettili" runat="server" />
                    </td>
                    <td align="left">
                        <asp:CheckBox ID="chkAcquarologia" runat="server" />
                    </td>
                </tr>
            </table>
            <br />
            <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                <tr>
                    <td align="right">
                        <asp:Button ID="btnSalva" runat="server" Text="Salva modifiche" OnClick="btnSalva_Click"
                            ValidationGroup="Utente" />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                            ShowSummary="False" ValidationGroup="Utente" />
                    </td>
                    <td align="left">
                        &nbsp;<asp:Button ID="btnCancella" runat="server" Text="Annulla" OnClick="btnCancella_Click" />
                    </td>
                    <td>
                        &nbsp;<asp:Button ID="btnDelete" runat="server" Text="Cancella" Style="background-color: #BD0000;
                            color: White;" OnClick="btnDelete_Click" OnClientClick="return confirm('Attenzione l\'utente sarà cancellabile solo se non è legato a degli ordini!');" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
