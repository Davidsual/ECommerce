<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Leggi-Recensioni.aspx.cs"
    Inherits="Perbaffo.Web.UI.Leggi_Recensioni" %>
<%@ Register src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffo.ascx" TagName="Perbaffo" TagPrefix="UserControl" %>
<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="UserControl" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="UserControl" %>
<%@ Register Src="WidgetFoto.ascx" TagName="Foto" TagPrefix="UserControl" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
<%@ Register Src="MenuCategorie.ascx" TagName="Menu" TagPrefix="UserControl" %>
<%@ Register Src="WidgetCarrello.ascx" TagName="Carrello" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNews.ascx" TagName="News" TagPrefix="UserControl" %>
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

    <script language="javascript" type="text/javascript" src="HttpCombinerHandler.ashx?s=Set_JavascriptThumb&amp;t=text/javascript&amp;v=1" ></script>

    <script language="javascript" type="text/javascript">

        fInit();
        function fInit() {
            try {
                $(function() {
                    $("img[src*='L.jpg']").thumbPopup({
                        imgSmallFlag: "L",
                        imgLargeFlag: "H"
                    });
                });
            }
            catch (err) {
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
                            <td rowspan="2" align="center">
                                <h1>
                                    <span id="lblNomeProdotto" runat="server"></span>
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
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
                    <tbody>
                        <tr>
                            <td width="12" class="yellow_left">
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
                                                <asp:UpdatePanel ID="updPnlProdotot" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
                                                        <table border="0" cellspacing="1" cellpadding="0" style="width: 350px; padding: 0;
                                                            margin-bottom: 10px;">
                                                            <tbody>
                                                                <tr>
                                                                    <td class="small_text" valign="top" align="center" style="padding-top: 5px;">
                                                                        <a href="Dettaglio-Prodotto.aspx?Categoria=<%= CurrentIDCategoria %>&amp;Prodotto=<%= CurrentProdotto.ID %>"
                                                                            title="<%= CurrentProdotto.Nome %>"><b>
                                                                                <%= CurrentProdotto.Nome%></b></a><br />
                                                                        <span class="large_text" style="text-align: left; margin-top: 5px; padding-left: 4px;">
                                                                            <%= TagliaStringa(CurrentProdotto.DescrizioneLunga) %></span>
                                                                        <br />
                                                                    </td>
                                                                    <td valign="top">
                                                                        <a href='Dettaglio-Prodotto.aspx?Categoria=<%= CurrentIDCategoria %>&amp;Prodotto=<%= CurrentProdotto.ID%>'
                                                                            title="">
                                                                            <img src='<%= UrlImmagine %><%= CurrentProdotto.UrlImmagine%>' alt='<%= CurrentProdotto.DescrImmagine%>'
                                                                                border="0" width="80px" height="80px" /></a>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td valign="top" colspan="2" align="center" style="height: 50px;">
                                                                        <table cellpadding="0" cellspacing="0" width="90%" style="border-color: black; border-width: 0px;
                                                                            border-style: solid; display: <%= IsOfferta(CurrentProdotto.Prezzo,CurrentProdotto.Totale)%>;">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <span class="small_text"><b>Prezzo:</b></span>
                                                                                    </td>
                                                                                    <td align="right">
                                                                                        <span class="price_medium_black" style="text-decoration: line-through;">€
                                                                                            <%= CurrentProdotto.Prezzo%></span>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <span class="small_text"><b>Prezzo scontato:</b></span>
                                                                                    </td>
                                                                                    <td align="right">
                                                                                        <span class="price_medium">€
                                                                                            <%= CurrentProdotto.Totale%></span>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <table cellpadding="0" cellspacing="0" width="90%" style="border-color: #90989a;
                                                                            border-width: 0px; border-style: solid; display: <%= IsNotOfferta(CurrentProdotto.Prezzo,CurrentProdotto.Totale)%>;">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="left">
                                                                                        <span class="small_text"><b>Prezzo:</b></span>
                                                                                    </td>
                                                                                    <td align="right">
                                                                                        <span class="price_medium">€
                                                                                            <%= CurrentProdotto.Totale%></span>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <table border="0" cellspacing="1" cellpadding="1" width="100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <img src="images/pixel.gif" width="1" height="20" alt="" />
                                                                                    </td>
                                                                                    <td valign="middle" align="right">
                                                                                        <asp:Button class="standardsubmit" ID="btnAcquista" CommandName="ACQUISTA" runat="server"
                                                                                            Text="Acquista" Style="cursor: pointer;" ToolTip="Inserisci il prodotto nel carrello"
                                                                                            OnClick="btnAcquista_Click" />
                                                                                        <asp:Button class="standardsubmit" ID="btnDettagliProd" CommandName="DETTAGLI" runat="server"
                                                                                            Text="Dettagli" Style="cursor: pointer;" ToolTip="Guarda i dettagli del prodotto"
                                                                                            OnClick="btnDettagliProd_Click" />
                                                                                    </td>
                                                                                    <td>
                                                                                        <img src="images/pixel.gif" width="1" height="20" alt="" />
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <br />
                                                <asp:Repeater ID="rptRecensioni" runat="server" OnItemDataBound="rptRecensioni_OnItemDataBound">
                                                    <ItemTemplate>
                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td valign="top" align="left">
                                                                        <span class="small_text"><b>
                                                                            <%#((Perbaffo.Presenter.Model.ProdottiRecensioni)Container.DataItem).Titolo%></b></span>
                                                                        <br>
                                                                        <span class="small_text">Inserito il
                                                                            <%#((Perbaffo.Presenter.Model.ProdottiRecensioni)Container.DataItem).DataInserimento%></span>
                                                                        <br />
                                                                        <span class="small_ten_text">
                                                                            <%#((Perbaffo.Presenter.Model.ProdottiRecensioni)Container.DataItem).Recensione%>
                                                                        </span>
                                                                    </td>
                                                                    <td valign="top" align="right">
                                                                        <table border="0" cellspacing="2" cellpadding="0">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <span class="med_text" style="color: Black;"><b>Voto:</b></span>
                                                                                    <td>
                                                                                    <td>
                                                                                        <div id="divVoto" runat="server">
                                                                                        </div>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">
                                                                        <hr style="background-color: Red; width: 65%; height: 3px;" />
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:Repeater>
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
