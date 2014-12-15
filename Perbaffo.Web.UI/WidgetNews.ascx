<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WidgetNews.ascx.cs"
    EnableViewState="false" Inherits="Perbaffo.Web.UI.WidgetNews" %>
<table border="0" cellpadding="0" cellspacing="0" class="headerCellContornoDuecento">
    <tr>
        <td align="left" class="topLeftStyle">
        </td>
        <td align="center" valign="bottom">
            <h2>
                <b>Notizie</b></h2>
        </td>
        <td align="right" class="topRightStyle">
        </td>
    </tr>
</table>
<table border="0" cellpadding="0" cellspacing="0" width="200">
    <tr>
        <td class="yellow_left" width="11">
        </td>
        <td class="bodycopy">
            <asp:Repeater ID="rptNotizie" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <table width="100%" border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td valign="top">
                                <img src="images/news_bullet.gif" alt="" width="5" height="5" style="border: 0;" />
                            </td>
                            <td>
                                <img src="images/spacer.gif" width="12px" alt="" />
                            </td>
                            <td align="left" class="bodycopyx2">
                                <a href="Dettaglio-Notizia.aspx?IDNotizia=<%#((Perbaffo.Presenter.Model.News)Container.DataItem).ID%>"
                                    title=""><b>
                                        <%#((Perbaffo.Presenter.Model.News)Container.DataItem).Titolo%></b></a>
                                <span class="small_text">(<%#((Perbaffo.Presenter.Model.News)Container.DataItem).DataInserimento.ToShortDateString()%>)</span>
                                <br />
                                <span class="small_text">
                                    <%# TagliaStringa(((Perbaffo.Presenter.Model.News)Container.DataItem).Notizia)%></span>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/spacer.gif" width="1px" height="6px" alt="" />
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>
            <table width="100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td>
                        <img src="images/spacer.gif" width="10px" alt="" />
                    </td>
                    <td>
                        <span class="small_text"><a href="Lista-Notizie.aspx" class="dark_red"><b>Leggi tutte
                            le news...</b></a></span>
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
