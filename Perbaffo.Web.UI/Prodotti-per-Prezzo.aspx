<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prodotti-per-Prezzo.aspx.cs"
    Inherits="Perbaffo.Web.UI.Prodotti_per_Prezzo" %>

<%@ Register Src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffo.ascx" TagName="Perbaffo" TagPrefix="UserControl" %>
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
    <link rel="Stylesheet" type="text/css" href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />

    <script language="javascript" type="text/javascript" src="HttpCombinerHandler.ashx?s=Set_JavascriptToolTip&amp;t=text/javascript&amp;v=2"></script>

    <style type="text/css">
        #screenshot
        {
            position: absolute;
            border: 1px solid #ccc;
            background: #333;
            padding: 5px;
            display: none;
            color: #fff;
        }
    </style>
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
                <table border="0" cellspacing="0" cellpadding="0" style="width: 590px; background-color: #cddded;
                    height: 35px;">
                    <tbody>
                        <tr>
                            <td align="left" class="topLeftStyle">
                            </td>
                            <td rowspan="2" align="right">
                                <h1>
                                    Prodotti per animali ordinati per prezzo</h1>
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
                            <td width="12" class="yellow_left" bgcolor="#f5f5f5">
                            </td>
                            <td>
                                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%">
                                    <tbody>
                                        <tr>
                                            <td style="padding: 4px 2px 4px 10px;">
                                                <span class="med_text_dodici" style="color: Black; clear: both;">Qui puoi trovare tutti
                                                    i prodotti e gli articoli per animali presenti su Perbaffo.<br />
                                                    I prodotti sono ordinati per fascia di prezzo.<br />
                                                    <strong><font style="color: #C61818;">Se passi il mouse sopra il nome del prodotto vedrai
                                                        l&#39;immagine in anteprima.</font></strong></span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table border="0" cellspacing="0" cellpadding="0" width="90%" bgcolor="#CDDDED">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left" class="topLeftStyle">
                                                            </td>
                                                            <td class="bodycopy">
                                                            </td>
                                                            <td align="right" class="topRightStyle">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="bottom" width="12" align="right" style="background-image: url(images/botleft.gif);
                                                                background-repeat: no-repeat; background-position: bottom;">
                                                            </td>
                                                            <td align="center">
                                                                <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                    border: 1px solid #cddded;" id="tblCani" runat="server">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:HyperLink ID="lnkCani" NavigateUrl="Prodotti-per-Prezzo.aspx?Pet=Cane" ToolTip="Prodotti e articoli nella Categoria Cani"
                                                                                    runat="server" CssClass="dark_red" Style="font-size: 11">Cani</asp:HyperLink>
                                                                                <br />
                                                                                <br />
                                                                                <asp:HyperLink ID="lnkImgCani" ToolTip="Prodotti e articoli nella Categoria Cani"
                                                                                    NavigateUrl="Prodotti-per-Prezzo.aspx?Pet=Cane" runat="server" CssClass="dark_red"
                                                                                    Style="font-size: 11">
                                                                                <img border="0" width="60" height="60" alt="Visita la categoria Cani" src="images/Visita-categoria-cani.jpg" />
                                                                                </asp:HyperLink>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                    border: 1px solid #cddded;" id="tblGatti" runat="server">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="center">
                                                                             <asp:HyperLink ID="lnkGatti" NavigateUrl="Prodotti-per-Prezzo.aspx?Pet=Gatti" ToolTip="Prodotti e articoli nella Categoria Gatti"
                                                                                    runat="server" CssClass="dark_red" Style="font-size: 11">Gatti</asp:HyperLink>
                                                                                <br />
                                                                                <br />
                                                                                <asp:HyperLink ID="lnkImgGatti" NavigateUrl="Prodotti-per-Prezzo.aspx?Pet=Gatti" ToolTip="Prodotti e articoli nella Categoria Gatti"
                                                                                    runat="server" CssClass="dark_red" Style="font-size: 11">
                                                                                                        <img border="0" width="60" height="60" alt="Visita la categoria Gatti" src="images/Visita-categoria-gatti.jpg" />
                                                                                </asp:HyperLink>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                    border: 1px solid #cddded;" id="tblRoditori" runat="server">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="center">
                                                                                     <asp:HyperLink ID="lnkRoditori" NavigateUrl="Prodotti-per-Prezzo.aspx?Pet=Roditori" ToolTip="Prodotti e articoli nella Categoria Roditori"
                                                                                    runat="server" CssClass="dark_red" Style="font-size: 11">Roditori</asp:HyperLink>
                                                                                <br />
                                                                                <br />
                                                                                <asp:HyperLink ID="lnkImgRoditori" NavigateUrl="Prodotti-per-Prezzo.aspx?Pet=Roditori"
                                                                                    ToolTip="Prodotti e articoli nella Categoria Roditori" runat="server" CssClass="dark_red"
                                                                                    Style="font-size: 11">
                                                                                                        <img border="0" width="60" height="60" alt="Visita la categoria Roditori" src="images/Visita-categoria-roditori.jpg" />
                                                                                </asp:HyperLink>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                    border: 1px solid #cddded;" id="tblVolatili" runat="server">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="center">
                                                                                           <asp:HyperLink ID="lnkVolatili" NavigateUrl="Prodotti-per-Prezzo.aspx?Pet=Uccelli" ToolTip="Prodotti e articoli nella Categoria Volatili"
                                                                                    runat="server" CssClass="dark_red" Style="font-size: 11">Volatili</asp:HyperLink>
                                                                                <br />
                                                                                <br />
                                                                                <asp:HyperLink ID="lnkImgVolatili" NavigateUrl="Prodotti-per-Prezzo.aspx?Pet=Uccelli"
                                                                                    ToolTip="Prodotti e articoli nella Categoria Volatili" runat="server" CssClass="dark_red"
                                                                                    Style="font-size: 11">                                                                              
                                                                                                        <img border="0" width="60" height="60" alt="Visita la categoria Volatili" src="images/Visita-categoria-volatili.jpg" />
                                                                                </asp:HyperLink>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                    border: 1px solid #cddded;" id="tblPesci" runat="server">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:HyperLink ID="lnkPesci" NavigateUrl="Prodotti-per-Prezzo.aspx?Pet=Pesci" ToolTip="Prodotti e articoli nella Categoria Acquariologia"
                                                                                    runat="server" CssClass="dark_red" Style="font-size: 11">Acquariologia</asp:HyperLink>
                                                                                <br />
                                                                                <br />
                                                                                <asp:HyperLink ID="lnkImgPesci" NavigateUrl="Prodotti-per-Prezzo.aspx?Pet=Pesci" ToolTip="Prodotti e articoli nella Categoria Acquariologia"
                                                                                    runat="server" CssClass="dark_red" Style="font-size: 11">   
                                                                                        <img border="0" width="60" height="60" alt="Visita la categoria Acquariologia" src="images/Visita-categoria-pesci.jpg" />
                                                                                </asp:HyperLink>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                    border: 1px solid #cddded;" id="tblRettili" runat="server">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <asp:HyperLink ID="lnkRettili" NavigateUrl="Prodotti-per-Prezzo.aspx?Pet=Rettili" ToolTip="Prodotti e articoli nella Categoria Rettili"
                                                                                    runat="server" CssClass="dark_red" Style="font-size: 11">Rettili</asp:HyperLink>
                                                                                <br />
                                                                                <br />
                                                                                <asp:HyperLink ID="lnkImgRettili" NavigateUrl="Prodotti-per-Prezzo.aspx?Pet=Rettili" ToolTip="Prodotti e articoli nella Categoria Rettili"
                                                                                    runat="server" CssClass="dark_red" Style="font-size: 11">   
                                                                                        <img border="0" width="60" height="60" alt="Visita la categoria Rettili" src="images/Visita-categoria-rettili.jpg" />
                                                                                </asp:HyperLink>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>                                                                
                                                            </td>
                                                            <td valign="bottom" width="12" align="right" style="background-image: url(images/botright.gif);
                                                                background-repeat: no-repeat; background-position: bottom;">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <br />
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tbody>
                                                        <tr>
                                                            <td>
                                                                <asp:HyperLink ID="lnk0" title="Cerca tutti i prodotti compresi nella fascia di prezzo €0 - €5"
                                                                    CssClass="dark_red" runat="server" 
                                                                    >€0 - €5</asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:HyperLink ID="lnk1" title="Cerca tutti i prodotti compresi nella fascia di prezzo €5 - €10"
                                                                    CssClass="dark_red" runat="server"
                                                                    >€5 - €10</asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:HyperLink ID="lnk2" title="Cerca tutti i prodotti compresi nella fascia di prezzo €10 - €20"
                                                                    CssClass="dark_red" runat="server" 
                                                                    >€10 - €20</asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:HyperLink ID="lnk3" title="Cerca tutti i prodotti compresi nella fascia di prezzo €20 - €40"
                                                                    CssClass="dark_red" runat="server" 
                                                                    >€20 - €40</asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:HyperLink ID="lnk4" title="Cerca tutti i prodotti compresi nella fascia di prezzo €40 - €70"
                                                                    CssClass="dark_red" runat="server" 
                                                                    >€40 - €70</asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:HyperLink ID="lnk5" title="Cerca tutti i prodotti compresi nella fascia di prezzo €70 - €100"
                                                                    CssClass="dark_red" runat="server"
                                                                    >€70 - €100</asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:HyperLink ID="lnk6" title="Cerca tutti i prodotti compresi nella fascia di prezzo €100 - €150"
                                                                    CssClass="dark_red" runat="server"
                                                                    >€100 - €150</asp:HyperLink>
                                                            </td>
                                                            <td>
                                                                <asp:HyperLink ID="lnk7" title="Cerca tutti i prodotti compresi nella fascia di prezzo Oltre €150"
                                                                    CssClass="dark_red" runat="server" 
                                                                    >Oltre €150</asp:HyperLink>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <br />
                                                <asp:Panel ID="pnlRighe" runat="server" Visible="false">
                                                    <asp:Label ID="lblMessage" runat="server" CssClass="med_text" Style="font-size: 12;
                                                        font-weight: bold;" Text="Nessun prodotto trovato" />
                                                </asp:Panel>
                                                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                    <tbody>
                                                        <asp:Repeater ID="rptProdotti" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td style="width: 100px;">
                                                                        &nbsp;
                                                                    </td>
                                                                    <td align="left" style="padding: 1px 0px 1px 0px;">
                                                                        <a href="Dettaglio-Prodotto.aspx?Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID %>"
                                                                            title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome %>"
                                                                            class="screenshot" style="font-size: 12px; color: black; text-decoration: none;"
                                                                            rel="<%= UrlImmagine %><%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).UrlImmagine%>">
                                                                            <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome %>&nbsp;(Prezzo:&nbsp;€&nbsp;<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale %>)</a>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tbody>
                                                </table>
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
