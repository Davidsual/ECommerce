﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Controlla-Spedizione.aspx.cs"
    Inherits="Perbaffo.Web.UI.Controlla_Spedizione" %>
<%@ Register src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffo.ascx" TagName="Perbaffo" TagPrefix="UserControl" %>
<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
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

    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>

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
                            <td rowspan="2" align="right">
                                <h1>
                                    Ordini in spedizione
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
                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                    <tbody>
                        <tr>
                            <td class="yellow_left" width="11">
                            </td>
                            <td class="bodycopy" align="center">
                                <div id="divOrdini" runat="server">
                                    <table border="0" cellspacing="1" cellpadding="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" align="left">
                                                    <span id="lblDescrDettaglio" runat="server" class="small_text"></span>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="basket_item_header" width="40%" align="center">
                                                    Ordine
                                                </td>
                                                <td class="basket_item_header" width="60%" align="center">
                                                    Codice Spedizione
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <asp:UpdatePanel ID="test" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <table border="0" cellspacing="1" cellpadding="0" width="100%">
                                                <tbody>
                                                    <asp:Repeater ID="rptOrdiniSpediti" runat="server" OnItemDataBound="rptOrdiniSpediti_ItemDataBound"
                                                        OnItemCommand="rptOrdiniSpediti_ItemCommand">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td align="center">
                                                                    <span id="lblDescrizioneDettaglio" runat="server" class="small_text"></span>
                                                                </td>
                                                                <td align="left" style="padding-left: 10px;">
                                                                    <asp:LinkButton ID="lnkSpedizione" CommandName="CODICE" CommandArgument="<%# ((Perbaffo.Presenter.Model.Ordini)Container.DataItem).CodiceSpedizione %>"
                                                                        runat="server" CssClass="small_text"><%# ((Perbaffo.Presenter.Model.Ordini)Container.DataItem).CodiceSpedizione %></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <AlternatingItemTemplate>
                                                            <tr>
                                                                <td align="center">
                                                                    <span id="lblDescrizioneDettaglio" runat="server" class="small_text"></span>
                                                                </td>
                                                                <td align="left" style="padding-left: 10px;">
                                                                    <asp:LinkButton ID="lnkSpedizione" CommandName="CODICE" CommandArgument="<%# ((Perbaffo.Presenter.Model.Ordini)Container.DataItem).CodiceSpedizione %>"
                                                                        runat="server" CssClass="small_text"><%# ((Perbaffo.Presenter.Model.Ordini)Container.DataItem).CodiceSpedizione %></asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                        </AlternatingItemTemplate>
                                                    </asp:Repeater>
                                                </tbody>
                                            </table>
                                            <table border="0" cellspacing="1" cellpadding="0" width="100%">
                                                <tbody>
                                                    <tr>
                                                        <td align="center" style="padding-top: 20px;">
                                                            <iframe id="frmBartolini" width="100%" height="600px" runat="server" frameborder="0"
                                                                marginwidth="0"></iframe>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
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
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <img src="images/spacer.gif" width="1px" height="5px" alt="" />
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
</body>
</html>
