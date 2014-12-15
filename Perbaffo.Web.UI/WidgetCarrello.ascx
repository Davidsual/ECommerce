<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WidgetCarrello.ascx.cs"
    Inherits="Perbaffo.Web.UI.WidgetCarrello" %>
<table border="0" cellpadding="0" cellspacing="0" width="200px">
    <tbody>
        <tr>
            <td>
                <img src="images/Sconto-Spese-Spedizioni.gif" border="0" title="Sconto spese di spedizione" alt="Sconto spese di spedizione" />
            </td>
        </tr>
    </tbody>
</table>
<br />
<table border="0" cellpadding="0" cellspacing="0" class="headerCellContornoDuecento">
    <tr>
        <td align="left" class="topLeftStyle">
        </td>
        <td align="center" valign="bottom">
            <h2>
                <b>Carrello</b></h2>
        </td>
        <td align="right" class="topRightStyle">
        </td>
    </tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="200px">
    <tr>
        <td class="yellow_left" width="11">
        </td>
        <td class="dark_red" width="178px" valign="top">
            <table border="0" cellpadding="0" cellspacing="0" width="176">
                <tr>
                    <td>
                        <img src="images/spacer.gif" width="1px" height="10px" alt="" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <table border="0" cellpadding="0" cellspacing="5" width="100%">
                            <tbody>
                                <tr>
                                    <td align="center" valign="top">
                                        <asp:UpdatePanel ID="updPnlCarrello" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <a href="Carrello-Prodotti.aspx" title="Visualizza gli articoli all'interno del tuo carrello"
                                                    id="lnkDettCarrello" runat="server" style="font-size: 12px;" class="black"><b>Articoli
                                                        nel carrello:
                                                        <asp:Label ID="lblNumeroProdotti" runat="server" Text=""></asp:Label></b></a><br />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        &nbsp;<asp:Button class="standardsubmit" ID="btnVisualizzaProdotti" CommandName="VISUALIZZA"
                                            runat="server" Text="Dettagli" ToolTip="Visualizza i prodotti all'interno del carrello" OnClick="btnVisualizzaProdotti_Click" />
                                    </td>
                                </tr>                               
                            </tbody>
                        </table>
                    </td>
                </tr>
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
        </td>
    </tr>
    <tr>
        <td>
            <img src="images/spacer.gif" width="1px" height="5px" alt="" />
        </td>
    </tr>
</table>
