﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prodotti-Offerta.aspx.cs"
    Inherits="Perbaffo.Web.UI.Prodotti_Offerta" %>
<%@ Register src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffo.ascx" TagName="Perbaffo" TagPrefix="UserControl" %>
<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
<%@ Register Src="PagerFull.ascx" TagName="Pager" TagPrefix="UserControl" %>
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
    <meta name="keywords" content="<%=KeywordsPagina %>" />
    <meta name="description" content="<%=DescrizionePagina %>" />    
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
    <asp:ScriptManager ID="ScriptManager1" runat="server" LoadScriptsBeforeUI="true">
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
                <table border="0" cellspacing="0" cellpadding="0"  style="width:590px;background-color:#cddded;height:35px;">
                    <tbody>
                        <tr>
                            <td align="left" class="topLeftStyle">
                            </td>
                            <td rowspan="2" align="center">
                                <h1>
                                    Prodotti in offerta</h1>
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
                                                <span class="med_text_dodici" style="color:Black;clear: both;">In questa categoria, trovi tutti i prodotti e gli accessori per animali in offerta e scontati.
                                                </span>                                               

                                                        <br />
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tbody>
                                                                <tr>
                                                                    <td align="center">
                                                                        <span class="small_text"><b>Ordina per:&nbsp;</b></span>
                                                                        <asp:DropDownList ID="ddlOrdinamento" runat="server" CssClass="combo" AutoPostBack="True"
                                                                            OnSelectedIndexChanged="ddlOrdinamento_SelectedIndexChanged">
                                                                            <asp:ListItem Value="NOME" Text="Nome"></asp:ListItem>
                                                                            <asp:ListItem Value="PREZZO" Text="Prezzo"></asp:ListItem>
                                                                        </asp:DropDownList>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                        <br />                                                    
                                                        <UserControl:Pager ID="PagerHeader" runat="server" Separator=" | " FirstText="Primo"
                                                            PreviousText="&lt;" NextText="&gt;" LastText="Ultimo" PageSize="10" NumberOfPages="15"
                                                            ShowGoTo="True" OnChange="Pager_Changed" />
                                                            
                                                        <asp:Repeater ID="rptOfferte" runat="server" OnItemDataBound="rptOfferte_ItemDataBound"
                                                            OnItemCommand="rptOfferte_ItemCommand">
                                                            <ItemTemplate>
                                                                <table border="0" cellspacing="0" cellpadding="0" style="margin-top: 5px; width: 100%;">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td valign="top">
                                                                                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%; height: 100%;">
                                                                                    <tbody>
                                                                                        <tr>
                                                                                            <td valign="top" align="center" style="width: 100px;">
                                                                                                <a href='Dettaglio-Prodotto.aspx?Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>'
                                                                                                    title="">
                                                                                                    <img src='<%= UrlImmagine %><%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).UrlImmagine%>'
                                                                                                        alt="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>"
                                                                                                        title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>"
                                                                                                        border="0" width="80px" height="80px" /></a>
                                                                                            </td>
                                                                                            <td rowspan="2" width="1">
                                                                                                <img src="images/spacer.gif" width="5" height="140" alt="" />
                                                                                            </td>
                                                                                            <td valign="top" align="left">
                                                                                                <a href='Dettaglio-Prodotto.aspx?Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>'
                                                                                                    title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%>"
                                                                                                    style="text-decoration: none;"><span class="med_text"><b>
                                                                                                        <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%></b></span></a>
                                                                                                <br />
                                                                                                <table border="0" cellspacing="0" cellpadding="5">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                                <span class="small_text" style="display: block;">
                                                                                                    <%# TagliaStringa(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrizioneLunga)%></span>
                                                                                                <span class="small_text" style="margin-top: 10px;"><b>Misura:</b>
                                                                                                    <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrTaglia %></span>
                                                                                                <br />
                                                                                                <table cellpadding="1" cellspacing="0" width="36%" style="margin-top: 5px; border-color: black;
                                                                                                    border-width: 1px; border-style: solid;">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <span class="small_text"><b>Prezzo:&nbsp;</b></span>
                                                                                                            </td>
                                                                                                            <td align="right">
                                                                                                                <span class="price_large_black" style="text-decoration: line-through;">€
                                                                                                                    <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Prezzo%></span>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <span class="small_text"><b>Prezzo scontato:&nbsp;</b></span>
                                                                                                            </td>
                                                                                                            <td align="right">
                                                                                                                <span class="price_large">€
                                                                                                                    <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale%></span>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                                <asp:Repeater ID="rptTaglie" runat="server">
                                                                                                    <HeaderTemplate>
                                                                                                        <br />
                                                                                                        <span class="small_text"><b>Altre taglie disponibili:</b></span>
                                                                                                    </HeaderTemplate>
                                                                                                    <ItemTemplate>
                                                                                                        <div style="font-size: xx-small; font-weight: bold; padding-top: 3px">
                                                                                                            <a href="Dettaglio-Prodotto.aspx?Prodotto=<%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).IDProdotto%>&amp;Taglia=<%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).ID %>"
                                                                                                                title="<%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).DescrTaglia%>">
                                                                                                                Misura:
                                                                                                                <%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).DescrTaglia%></a></div>
                                                                                                    </ItemTemplate>
                                                                                                </asp:Repeater>
                                                                                                <br />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td valign="top" align="left" colspan="3">
                                                                                                <table border="0" cellspacing="0" cellpadding="2">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td>
                                                                                                                <img src="images/pixel.gif" width="1" height="20" alt="" />
                                                                                                            </td>
                                                                                                            <td bgcolor="#f5f5f5" valign="middle" align="center">
                                                                                                                <asp:Button class="standardsubmit" ID="btnAcquista" CommandName="ACQUISTA" CommandArgument="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                                                    runat="server" Text="Acquista" Style="cursor: pointer;" ToolTip="Inserisci il prodotto nel carrello" />
                                                                                                                <asp:Button class="standardsubmit" ID="btnDettagli" CommandName="DETTAGLI" CommandArgument="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                                                    runat="server" Text="Dettagli" Style="cursor: pointer;" ToolTip="Guarda i dettagli del prodotto" />
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="3">
                                                                                                <img src="/images/pixel.gif" width="1" height="4" alt="" />
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td colspan="3" style="background-image: url(images/bar_red.gif); background-repeat: repeat-x"
                                                                                                align="center">
                                                                                                <img src="/images/pixel.gif" width="1" height="4" alt="" />
                                                                                            </td>
                                                                                        </tr>
                                                                                    </tbody>
                                                                                </table>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        <UserControl:Pager ID="PagerFooter" runat="server" Separator=" | " FirstText="Primo"
                                                            PreviousText="&lt;" NextText="&gt;" LastText="Ultimo" PageSize="10" NumberOfPages="15"
                                                            ShowGoTo="True" OnChange="Pager_Changed" />

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
