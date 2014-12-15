<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PerbaffoMaster.Master"
    CodeBehind="DettaglioOrdine.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.DettaglioOrdine" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="height: 688px; overflow: scroll;">
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
                                Gestione Ordini - Creazione/Modifica
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
        </table>
        <asp:UpdatePanel ID="updPnlTotale" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table border="0" cellpadding="1" cellspacing="2" align="center" style="font-size: 10px;
                    width: 750px; font-family: Verdana; font-weight: bold">
                    <tr>
                        <td width="17%" align="right">
                            Cliente:
                        </td>
                        <td align="left">
                            <asp:Label ID="lblCliente" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">
                            Numero Ordine:
                        </td>
                        <td align="left">
                            <asp:Label ID="lblNumeroOrdine" runat="server" Text=""></asp:Label>
                        </td>                        
                    </tr>                    
                    <tr>
                        <td align="right">
                            Tipo Pagamento:
                        </td>
                        <td align="left">
                            <asp:Label ID="lblTipoPagamento" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">
                            Tipo Spedizione:
                        </td>
                        <td align="left">
                            <asp:Label ID="lblTipoSpedizione" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td width="17%" align="right">
                            Stato Ordine:
                        </td>
                        <td align="left" colspan="3">
                            <asp:DropDownList ID="ddlStato" runat="server" Width="200px" 
                                AutoPostBack="True" onselectedindexchanged="ddlStato_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlStato"
                                Text="!" ErrorMessage="Stato Ordine Obbligatorio" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                                <asp:Button ID="btnPagamento" runat="server" 
                                Text="Mail Pagamento Ricevuto" 
                                Enabled="False" onclick="btnPagamento_Click" />
                        </td>
                    </tr>                    
                    <tr>
                        <td align="right">
                            Codice Spedizione:
                        </td>
                        <td align="left" colspan="3">
                            <asp:TextBox ID="txtCodSpedizione" runat="server" Text="" Width="200px"></asp:TextBox>
                            &nbsp;&nbsp;<asp:Button ID="btnCodiceOrdine" runat="server" 
                                Text="Invia Mail al Cliente" onclick="btnCodiceOrdine_Click" 
                                Enabled="False" />
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Codice Sconto:
                        </td>
                        <td align="left">
                            <asp:Label ID="lblCodiceSconto" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="right">
                            Sconto Utente:
                        </td>
                        <td align="left">
                            <asp:Label ID="lblScontoUtente" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Note Perbaffo:
                        </td>
                        <td colspan="3">
                        <asp:TextBox ID="txtNotePerbaffo" runat="server" Text="" Columns="50" Rows="4" 
                                        TextMode="MultiLine"></asp:TextBox> 
                        </td>
                    </tr>

                    <tr>
                        <td align="left" colspan="4">
                            <b>Dati destinatario:</b><br />
                            <br />
                            <table cellpadding="0" cellspacing="0" width="90%" style="border:1px solid black;background-color:#f5f5f5;">
                            <tr>
                                <td style="width:20%;">Nome:</td>
                                <td><asp:TextBox ID="txtNome" runat="server" Text="" Width="200"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtNome"
                                Text="!" ErrorMessage="Nome obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                                &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnIndirizzo" runat="server" Text="Vis. Indirizzo Sped" 
                                        onclick="btnIndirizzo_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>Cognome:</td>
                                <td><asp:TextBox ID="txtCognome" runat="server" Text="" Width="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtCognome"
                                Text="!" ErrorMessage="Cognome obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>                                
                                </td>
                            </tr>                         
                            <tr>
                                <td>Città</td>
                                <td><asp:TextBox ID="txtCitta" runat="server" Text="" Width="200"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtCitta"
                                Text="!" ErrorMessage="Citta obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>                                   
                                </td>
                            </tr>
                            <tr>
                                <td>Provincia</td>
                                <td>
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
<asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlProvincie"
                                Text="!" ErrorMessage="Provincia obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>                                                                
                                </td>
                            </tr>
                            <tr>
                                <td>Indirizzo</td>
                                <td><asp:TextBox ID="txtIndirizzo" runat="server" Text="" Width="300"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtIndirizzo"
                                Text="!" ErrorMessage="Indirizzo obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>                                    
                                </td>
                            </tr>
                            <tr>
                                <td>Numero Civico</td>
                                <td><asp:TextBox ID="txtNumeroCivico" runat="server" Text=""></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtNumeroCivico"
                                Text="!" ErrorMessage="Numero Civico obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>                                 
                                </td>
                            </tr>  
                            <tr>
                                <td>CAP</td>
                                <td><asp:TextBox ID="txtCAP" runat="server" Text="" MaxLength="5"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtCAP"
                                Text="!" ErrorMessage="CAP obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>                                     
                                </td>
                            </tr>     
                            <tr>
                                <td>E-Mail</td>
                                <td><asp:TextBox ID="txtEMail" runat="server" Text="" Width="200"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtEMail"
                                Text="!" ErrorMessage="EMail obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>                                    
                                </td>
                            </tr>   
                            <tr>
                                <td>CFisc/Piva:</td>
                                <td><asp:TextBox ID="txtCodFisc" runat="server" Text="" Width="200"></asp:TextBox>                              
                                </td>
                            </tr>                               
                            <tr>
                               <td>Telefono</td>
                                <td><asp:TextBox ID="txtTelefono" runat="server" Text="" Width="200"></asp:TextBox>
                               <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtTelefono"
                                Text="!" ErrorMessage="Telefono obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>                                 
                                </td>
                            </tr>         
                            <tr>
                               <td>Note</td>
                                <td><asp:TextBox ID="txtNote" runat="server" Text="" Columns="50" Rows="4" 
                                        TextMode="MultiLine"></asp:TextBox>                             
                                </td>
                            </tr>                                                                                                                                                                                      
                            </table>
                        </td>
                    </tr>                    
                    <tr>
                        <td align="left" colspan="4">
                            <b>Prodotti acquistati:</b><br />
                            <asp:GridView ID="grdListProdotti" runat="server" AutoGenerateColumns="False" BorderColor="White"
                                CellPadding="4" ForeColor="#333333" GridLines="None" Width="700px" CellSpacing="2"
                                
                                EmptyDataText="&lt;p&gt;&lt;b&gt;Nessun Ordine trovato&lt;/b&gt;&lt;/p&gt;" 
                                OnRowDataBound="grdListProdotti_RowDataBound">
                                <RowStyle BackColor="#EFF3FB" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Codice" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle">
                                        <ItemTemplate>
                                            <span id="lblCodiceProd" runat="server"></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Quantita" DataField="Quantita" ItemStyle-HorizontalAlign="Center" ItemStyle-VerticalAlign="Middle"/>
                                    <asp:TemplateField HeaderText="Descrizione">
                                        <ItemTemplate>
                                            <a href="#" id="lblDescrProd" runat="server"></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Totale" ItemStyle-HorizontalAlign="Right" ItemStyle-VerticalAlign="Middle">
                                        <ItemTemplate>
                                            <span id="lblTotale" runat="server"></span>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <EditRowStyle BackColor="#2461BF" />
                                <AlternatingRowStyle BackColor="White" />
                            </asp:GridView>                       
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="4">
                            <b>Omaggio:</b><br />
                            <span id="lblOmaggio" runat="server"></span>
                        </td>
                    </tr>
                    </table>
                    <table cellpadding="0" cellspacing="0" width="50%" style="border:1px solid black;background-color:#f5f5f5;">
                    <tr>
                        <td align="center">
                            <strong>Totale Prodotti(€):</strong>
                        </td>
                        <td align="left">
                            <asp:Label ID="lblTotaleProdotti" runat="server" Text=""></asp:Label> 
                        </td>
                    </tr>                     
                    <tr>
                        <td align="center">
                           <strong>Totale Carrello(€):</strong>                          
                        </td>
                        <td align="left">
                            <asp:Label ID="lblTotaleCarrello" runat="server" Text=""></asp:Label>
                        </td>
                    </tr> 
                </table>

        <table border="0" cellpadding="1" cellspacing="2" align="center" style="font-size: 10px;
            width: 750px; font-family: Verdana; font-weight: bold">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSend" runat="server" Text="Salva" OnClick="btnSend_Click" ValidationGroup="Prodotto" />
                </td>
                <td align="left">
                    &nbsp;<asp:Button ID="btnCancella" runat="server" Text="Cancella" OnClick="btnCancella_Click" />
                </td>
            </tr>
        </table>
            </ContentTemplate>
        </asp:UpdatePanel>        
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="Prodotto" />
    </div>
</asp:Content>
