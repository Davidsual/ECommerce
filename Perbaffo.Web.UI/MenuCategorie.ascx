<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="false" CodeBehind="MenuCategorie.ascx.cs"
    Inherits="Perbaffo.Web.UI.MenuCategorie" %>
<table border="0" cellpadding="0" cellspacing="0" width="200px">
    <tbody>
        <tr>
            <td>
                <a href="Prodotti-Omaggio.aspx" title="Per ogni ordine un omaggio">
                    <img src="images/OMAGGIO.gif" border="0" alt="Per ogni ordine un omaggio" /></a>
            </td>
        </tr>
    </tbody>
</table>
<table border="0" cellpadding="0" cellspacing="0" class="headerCellContornoDuecento">
    <tbody>
        <tr>
            <td align="left" class="topLeftStyle">
            </td>
            <td align="center" valign="bottom">
                <h2>
                    <b>Categorie</b></h2>
            </td>
            <td align="right" class="topRightStyle">
            </td>
        </tr>
    </tbody>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="200px">
    <tr>
        <td bgcolor="#cddded">
            &nbsp;
        </td>
        <td bgcolor="#cddded" valign="bottom">
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <img src="images/pixel.gif" width="1" height="5" border="0" alt="" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtCerca" CssClass="pp_box" runat="server" MaxLength="50"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;
                        <asp:Button ID="btnCerca" CssClass="standardsubmitCerca" ToolTip="Cerca tra i nostri articoli"
                            CommandName="CERCA" runat="server" Text="Cerca" OnClientClick="return fCheckSearch();"
                            OnClick="btnCerca_Click" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <img src="images/pixel.gif" width="1" height="3" border="0" alt="" />
                    </td>
                </tr>
            </table>
        </td>
        <td bgcolor="#cddded">
            &nbsp;
        </td>
    </tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="200px">
    <tr>
        <td class="yellow_left" width="12">
        </td>
        <td width="176px">
            <table border="0" cellspacing="0" cellpadding="0" width="175px">
                <tbody>
                    <tr>
                        <td>
                            <img src="images/pixel.gif" width="1" height="5" border="0" alt="" />
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:UpdatePanel ID="updPnlPreferiti" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table border="0" cellspacing="0" cellpadding="0" width="175px">
                        <tbody>
                            <tr>
                                <td>
                                    <img src="images/pixel.gif" width="1" height="5" border="0" alt="" />
                                </td>
                                <td style="padding: 0px 0px 5px 0px;">
                                    <a href="Lista-Desideri.aspx" title="Lista dei prodotti da tener d'occhio" runat="server"
                                        id="lnkPreferiti" style="font-size: 12px" class="dark_red"><b>Lista desideri (<asp:Label
                                            ID="lblCountProdottiPreferiti" runat="server" Text="0"></asp:Label>)</b></a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
            <table border="0" cellspacing="0" cellpadding="0" width="175px">
                <tbody>
                    <tr>
                        <td>
                            <img src="images/pixel.gif" width="1" height="5" border="0" alt="" />
                        </td>
                        <td>
                            <a href="Tutti-Prodotti.aspx" title="Tutti i prodotti e gli accessori per animali dalla A alla Z"
                                style="font-size: 12px;" class="black"><b>Prodotti A-Z</b></a><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="images/pixel.gif" width="1" height="5" border="0" alt="" />
                        </td>
                        <td>
                            <a href="Prodotti-per-Prezzo.aspx" title="Tutti i prodotti e gli accessori per animali ordinati per prezzo"
                                style="font-size: 12px;" class="black"><b>Prodotti per prezzo</b></a><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="images/pixel.gif" width="1" height="5" border="0" alt="" />
                        </td>
                        <td>
                            <a href="Prodotti-Images.aspx" title="Visualizza le immagini dei prodotti per animali Perbaffo"
                                style="font-size: 12px;" class="black"><b>Ricerca per immagini</b></a><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="images/pixel.gif" width="1" height="5" border="0" alt="" />
                        </td>
                        <td>
                            <a href="Prodotti-Piu-Votati.aspx" title="Articoli e accessori per cani in promozione e scontati"
                                style="font-size: 12px;" class="black"><b>Più votati</b></a><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="images/pixel.gif" width="1" height="5" border="0" alt="" />
                        </td>
                        <td>
                            <a href="Promozioni-Cani.aspx" title="Articoli e accessori per cani in promozione e scontati"
                                style="font-size: 12px;" class="black"><b>Promozioni cani</b></a><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="images/pixel.gif" width="1" height="5" border="0" alt="" />
                        </td>
                        <td>
                            <a href="Promozioni-Gatti.aspx" title="Articoli e accessori per gatti in promozione e scontati"
                                style="font-size: 12px;" class="black"><b>Promozioni gatti</b></a><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="images/pixel.gif" width="1" height="5" border="0" alt="" />
                        </td>
                        <td>
                            <a href="Prodotti-Offerta.aspx" title="Tutti i prodotti e gli articoli in offerta"
                                style="font-size: 12px;" class="black"><b>Offerte</b></a><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="images/pixel.gif" width="1" height="5" border="0" alt="" />
                        </td>
                        <td>
                            <a href="Prodotti-Novita.aspx" title="Gli ultimi prodotti e articoli inseriti" style="font-size: 12px;"
                                class="black"><b>Novità</b></a><br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <img src="images/pixel.gif" width="1" height="5" border="0" alt="" />
                        </td>
                        <td>
                            <a href="Prodotti-Omaggio.aspx" title="I prodotti e gli omaggi che potete scegliere"
                                style="font-size: 12px;" class="black"><b>Omaggi</b></a><br />
                        </td>
                    </tr>
                </tbody>
            </table>
            <table border="0" cellpadding="0" cellspacing="0" style="width: 175px; padding: 0;
                margin: 0;">
                <tbody>
                    <asp:Repeater ID="rptMenuCategorie" runat="server" OnItemDataBound="rptMenuCategorie_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <img src="images/pixel.gif" width="2" height="1" border="0" alt="" />
                                </td>
                                <td style="padding: 0;">
                                    <b><a id="lnkFirstCategoria" runat="server" class="black" style="font-size: 12px;
                                        display: block; font-family: Arial;" title="<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneCategoria%>">
                                        <%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneBreve%></a></b>
                                    <div id="divScelta" runat="server" style="margin: 0; padding: 0;">
                                        <asp:Repeater ID="rptMenuCategorieSecondoLivello" runat="server" DataSource='<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).CategorieFiglie%>'
                                            OnItemDataBound="rptMenuCategorieSecondoLivello_ItemDataBound">
                                            <HeaderTemplate>
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tbody>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr>
                                                    <td>
                                                        <img src="images/pixel.gif" width="4" height="1" border="0" alt="" />
                                                    </td>
                                                    <td style="padding: 0;">
                                                        <a id="lnkSecondCategoria" runat="server" class="black" style="font-size: 11px; display: block;
                                                            font-family: Arial;" title="<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneCategoria%>">
                                                            <%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneBreve%></a>
                                                        <asp:Repeater ID="rptMenuCategorieTerzoLivello" runat="server" OnItemDataBound="rptMenuCategorieTerzoLivello_ItemDataBound">
                                                            <HeaderTemplate>
                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                    <tbody>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <img src="images/pixel.gif" width="4" height="1" border="0" alt="" />
                                                                    </td>
                                                                    <td style="padding: 0;">
                                                                        <a id="lnkTerzaCategoria" runat="server" class="black" style="font-size: 11px; display: block;
                                                                            font-family: Arial;" title="<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneCategoria%>">
                                                                            <%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneBreve%></a>
                                                                        <asp:Repeater ID="rptMenuCategorieQuartoLivello" runat="server" OnItemDataBound="rptMenuCategorieQuartoLivello_ItemDataBound">
                                                                            <HeaderTemplate>
                                                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                                    <tbody>
                                                                            </HeaderTemplate>
                                                                            <ItemTemplate>
                                                                                <tr>
                                                                                    <td>
                                                                                        <img src="images/pixel.gif" width="4" height="1" border="0" alt="" />
                                                                                    </td>
                                                                                    <td style="padding: 0;">
                                                                                        <a id="lnkTerzaCategoria" runat="server" class="black" style="font-size: 10px; display: block;
                                                                                            font-family: Arial;" title="<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneCategoria%>">
                                                                                            <%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneBreve%></a>
                                                                                    </td>
                                                                                </tr>
                                                                            </ItemTemplate>
                                                                            <FooterTemplate>
                                                                                </tbody> </table>
                                                                            </FooterTemplate>
                                                                        </asp:Repeater>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                            <FooterTemplate>
                                                                </tbody> </table>
                                                            </FooterTemplate>
                                                        </asp:Repeater>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                </tbody> </table>
                                            </FooterTemplate>
                                        </asp:Repeater>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
            <br />
            <table border="0" cellspacing="0" cellpadding="0" width="175px">
                <tbody>
                    <tr>
                        <td>
                            <a href="../Documents/Perbaffo-Catalogo-Cani.pdf" target="_blank" title="Scarica il catalogo con tutti i prodotti e gli accessori per cani"
                                style="font-size: 12px;" class="dark_red"><b>Scarica il catalogo articoli cani</b></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="../Documents/Perbaffo-Catalogo-Gatti.pdf" target="_blank" title="Scarica il catalogo con tutti i prodotti e gli accessori per gatti"
                                style="font-size: 12px;" class="dark_red"><b>Scarica il catalogo articoli gatti</b></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="../Documents/Perbaffo-Catalogo-Roditori.pdf" target="_blank" title="Scarica il catalogo con tutti i prodotti e gli accessori per roditori"
                                style="font-size: 12px;" class="dark_red"><b>Scarica il catalogo roditori</b></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="../Documents/Perbaffo-Catalogo-Volatili.pdf" target="_blank" title="Scarica il catalogo con tutti i prodotti e gli accessori per volatili"
                                style="font-size: 12px;" class="dark_red"><b>Scarica il catalogo volatili</b></a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="../Documents/Perbaffo-Catalogo-Acquariologia.pdf" target="_blank" title="Scarica il catalogo con tutti i prodotti e gli accessori per Acquariologia"
                                style="font-size: 12px;" class="dark_red"><b>Scarica il catalogo pesci</b></a>
                        </td>
                    </tr>                                                                                                   
                </tbody>
            </table>
        </td>
        <td class="yellow_right" width="12" align="right">
        </td>
    </tr>
    <tr>
        <td align="left" class="bottomLeftStyle">
        </td>
        <td class="yellow_bottom" style="height: 12px;">
        </td>
        <td align="right" class="bottomRightStyle">
        </td>
    </tr>
</table>
