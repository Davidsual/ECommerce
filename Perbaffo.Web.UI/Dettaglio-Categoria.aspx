<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dettaglio-Categoria.aspx.cs"
    Inherits="Perbaffo.Web.UI.Dettaglio_Categoria" %>

<%@ Register Src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffo.ascx" TagName="Perbaffo" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
<%@ Register Src="PagerFull.ascx" TagName="Pager" TagPrefix="UserControl" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="UserControl" %>
<%@ Register Src="WidgetFoto.ascx" TagName="Foto" TagPrefix="UserControl" %>
<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
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
    <link rel="Stylesheet" type="text/css" href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />

    <script language="javascript" type="text/javascript" src="HttpCombinerHandler.ashx?s=Set_JavascriptThumb&amp;t=text/javascript&amp;v=1"></script>

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
        function fShowBorder(IDCtrl) {

            try {
                var _ctrl = document.getElementById(IDCtrl);
                if (_ctrl == null)
                    return;
                _ctrl.style.border = '1px solid #044bbf';
            }
            catch (err) {
                return;
            }
        }
        function fHideBorder(IDCtrl) {

            try {
                var _ctrl = document.getElementById(IDCtrl);
                if (_ctrl == null)
                    return;
                _ctrl.style.border = '1px solid #cddded';
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
                <table border="0" cellspacing="0" cellpadding="0" style="width: 590px; background-color: #cddded;
                    height: 35px;">
                    <tbody>
                        <tr>
                            <td align="left" class="topLeftStyle">
                            </td>
                            <td rowspan="2" align="center">
                                <h1>
                                    <span id="lblTitoloCategoria" runat="server"></span>
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
                            <td class="bodycopy">
                                <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                    <tbody>
                                        <tr>
                                            <td align="left">
                                                <div id="divPath" runat="server">
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="padding: 4px 0px 6px 2px;">
                                                <h3>
                                                    <span id="lblDescrCategoria" runat="server" class="med_text_dodici" style="color: Black;
                                                        clear: both; font-weight: normal;"></span>
                                                </h3>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                <table border="0" cellspacing="0" cellpadding="2" width="100%">
                                    <tbody>
                                        <tr>
                                            <td align="center" valign="top">
                                                <asp:DataList ID="dtlCategorie" runat="server" RepeatColumns="3" RepeatDirection="Horizontal"
                                                    EnableViewState="false">
                                                    <ItemTemplate>
                                                        <table id='tbl<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).ID%>' cellspacing="0"
                                                            cellpadding="0" style="width: 160px; height: 160px; float: left; border: 1px solid #cddded;">
                                                            <tbody>
                                                                <tr>
                                                                    <td>
                                                                        <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td>
                                                                                        <img src="images/spacer.gif" width="1" height="130" alt="" />
                                                                                    </td>
                                                                                    <td align="center">
                                                                                        <a href="Dettaglio-Categoria.aspx?Categoria=<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).ID%>"
                                                                                            onmouseout="javascript:fHideBorder('tbl<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).ID%>');"
                                                                                            onmouseover="javascript:fShowBorder('tbl<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).ID%>');"
                                                                                            title="<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneCategoria%>">
                                                                                            <span class="small_text"><b>
                                                                                                <%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneBreve%></b></span></a>
                                                                                        <br />
                                                                                        <br />
                                                                                        <a href="Dettaglio-Categoria.aspx?Categoria=<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).ID%>"
                                                                                            title="">
                                                                                            <img title="<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneCategoria%>"
                                                                                                alt="<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneCategoria%>"
                                                                                                src="<%= UrlImmagineCategoria %><%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).UrlImmagine%>"
                                                                                                onmouseout="javascript:fHideBorder('tbl<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).ID%>');"
                                                                                                onmouseover="javascript:fShowBorder('tbl<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).ID%>');"
                                                                                                style="width: 80px; height: 80px; border: 0;" /></a>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>
                                                    </ItemTemplate>
                                                </asp:DataList>
                                                <asp:Panel ID="divListaProdotti" runat="server" Visible="false">
                                                    <br />
                                                    <table id="tblOrder" border="0" cellpadding="0" cellspacing="0" width="100%">
                                                        <tbody>
                                                            <tr>
                                                                <td align="center">
                                                                    <span class="small_text"><b>Ordina per:&nbsp;</b></span>
                                                                    <asp:DropDownList ID="ddlOrdinamento" runat="server" CssClass="combo" AutoPostBack="True"
                                                                        CausesValidation="false" OnSelectedIndexChanged="ddlOrdinamento_SelectedIndexChanged">
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
                                                    <br />
                                                    <asp:UpdatePanel ID="updPnlProdotti" runat="server" UpdateMode="Conditional">
                                                                                                                <ContentTemplate>
                                                    <asp:Repeater ID="rptProdotti" runat="server" OnItemDataBound="rptProdotti_ItemDataBound"
                                                        OnItemCommand="rptProdotti_ItemCommand">
                                                        <ItemTemplate>
                                                            <table border="0" cellspacing="0" cellpadding="0" style="margin-top: 5px; width: 100%;">
                                                                <tbody>
                                                                    <tr>
                                                                        <td valign="top">
                                                                            <table border="0" cellspacing="0" cellpadding="0" style="width: 100%; height: 100%;">
                                                                                <tbody>
                                                                                    <tr>
                                                                                        <td valign="top" align="center" style="width: 100px;">
                                                                                            <a href="Dettaglio-Prodotto.aspx?Categoria=<%= CurrentIDCategoria %>&amp;Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                                title="">
                                                                                                <img src="<%= UrlImmagine %><%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).UrlImmagine%>"
                                                                                                    alt="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>"
                                                                                                    title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>"
                                                                                                    border="0" width="80px" height="80px" />
                                                                                            </a>
                                                                                        </td>
                                                                                        <td rowspan="2" width="1">
                                                                                            <img src="images/spacer.gif" width="5" height="140" alt="" />
                                                                                        </td>
                                                                                        <td valign="top" align="left">
                                                                                            <a href="Dettaglio-Prodotto.aspx?Categoria=<%= CurrentIDCategoria %>&amp;Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                                title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%>"
                                                                                                style="text-decoration: none;"><span class="med_text"><b>
                                                                                                    <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%></b></span>
                                                                                            </a>
                                                                                            <br />
                                                                                            <span class="small_text" style="display: block;">
                                                                                                <%# TagliaStringa(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrizioneLunga)%></span>
                                                                                            <span class="small_text" style="margin-top: 10px;"><b>Misura:</b>
                                                                                                <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrTaglia %></span>
                                                                                            <br />
                                                                                            <table cellpadding="0" cellspacing="0" width="50%" style="margin-top: 10px; border-color: black;
                                                                                                border-width: 1px; border-style: solid; display: <%# IsOfferta(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Prezzo,((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale)%>;">
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
                                                                                            <table cellpadding="0" cellspacing="0" width="50%" style="margin-top: 10px; border-color: #90989a;
                                                                                                border-width: 1px; border-style: solid; display: <%# IsNotOfferta(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Prezzo,((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale)%>;">
                                                                                                <tbody>
                                                                                                    <tr>
                                                                                                        <td>
                                                                                                            <span class="small_text"><b>Prezzo:&nbsp;</b></span>
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
                                                                                                        <a href="Dettaglio-Prodotto.aspx?Categoria=<%= CurrentIDCategoria %>&amp;Prodotto=<%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).IDProdotto%>&amp;Taglia=<%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).ID %>"
                                                                                                            title="<%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).DescrTaglia%>"
                                                                                                            style="color: Black;">Misura:
                                                                                                            <%# ((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).DescrTaglia%>&nbsp;(€ <%# CheckTagliaPrice(((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem))%>)</a></div>
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
                                                                                                            
                                                                                                                    <asp:Button class="standardsubmit" ID="btnAcquista" CommandName="ACQUISTA" runat="server"
                                                                                                                        CommandArgument='<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>'
                                                                                                                        Style="cursor: pointer;" Text="Acquista" ToolTip="Inserisci il prodotto nel carrello" />
                                                                                                                    <asp:Button class="standardsubmit" ID="btnDettagli" CommandName="DETTAGLI" runat="server"
                                                                                                                        CommandArgument='<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>'
                                                                                                                        Style="cursor: pointer;" Text="Dettagli" ToolTip="Guarda i dettagli del prodotto" />
                                                                                                              
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
                                                      </ContentTemplate>
                                                                                                            </asp:UpdatePanel>
                                                    <UserControl:Pager ID="PagerFooter" runat="server" Separator=" | " FirstText="Primo"
                                                        PreviousText="&lt;" NextText="&gt;" LastText="Ultimo" PageSize="10" NumberOfPages="15"
                                                        ShowGoTo="True" OnChange="Pager_Changed" />
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                    </tbody>
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
                            <td colspan="3">
                                <img src="images/spacer.gif" width="1px" height="5px" alt="" />
                            </td>
                        </tr>
                    </tbody>
                </table>
                <div id="divVetrina" runat="server">
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr>
                                <td valign="top" width="100%">
                                    <table border="0" cellspacing="0" cellpadding="0" style="width: 100%; height: 35px;
                                        background-color: #cddded;">
                                        <tbody>
                                            <tr>
                                                <td align="left" class="topLeftStyle">
                                                </td>
                                                <td align="center">
                                                    <h2>
                                                        Vetrina</h2>
                                                </td>
                                                <td align="right" class="topRightStyle">
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                        <tbody>
                            <tr>
                                <td class="yellow_left" width="12">
                                </td>
                                <td class="bodycopy">
                                    <table border="0" cellspacing="0" cellpadding="0" width="100%">
                                        <tbody>
                                            <tr>
                                                <td align="center">
                                                    &nbsp;
                                                    <asp:UpdatePanel ID="updPnlVetrina" runat="server" UpdateMode="Conditional">
                                                        <ContentTemplate>
                                                            <asp:DataList ID="dtlNovita" runat="server" GridLines="None" RepeatColumns="2" RepeatDirection="Horizontal"
                                                                CellPadding="0" CellSpacing="0" OnItemCommand="dtlNovita_ItemCommand">
                                                                <ItemTemplate>
                                                                    <table border="0" cellspacing="0" cellpadding="0" style="width: 260px; height: 190px;
                                                                        padding: 0; margin-bottom: 10px;">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td class="small_text" valign="top" align="center" style="padding-top: 5px;">
                                                                                    <a href="Dettaglio-Prodotto.aspx?Categoria=<%= CurrentIDCategoria %>&amp;Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                        title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%>">
                                                                                        <b>
                                                                                            <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%></b></a><br />
                                                                                    <span class="large_text" style="text-align: left; padding-left: 3px; padding-top: 3px;">
                                                                                        <%# TagliaStringa(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrizioneLunga)%></span>
                                                                                    <br />
                                                                                    <table cellpadding="0" cellspacing="0" width="100%" style="margin-top: 10px; margin-bottom: 6px;
                                                                                        border-color: black; border-width: 0px; border-style: solid; display: <%# IsOfferta(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Prezzo,((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale)%>;">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    <span class="small_text" style="padding-left: 3px;"><b>Prezzo:&nbsp;</b></span>
                                                                                                </td>
                                                                                                <td align="right">
                                                                                                    <span class="small_text" style="text-decoration: line-through;">€
                                                                                                        <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Prezzo%></span>
                                                                                                </td>
                                                                                            </tr>
                                                                                            <tr>
                                                                                                <td align="left">
                                                                                                    <span class="small_text" style="padding-left: 3px;"><b>Prezzo scontato:&nbsp;</b></span>
                                                                                                </td>
                                                                                                <td align="right">
                                                                                                    <span class="price_large" style="font-size: 11px;">€
                                                                                                        <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale%></span>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                    <table cellpadding="0" cellspacing="0" width="100%" style="margin-top: 10px; margin-bottom: 6px;
                                                                                        border-color: #90989a; border-width: 0px; border-style: solid; display: <%# IsNotOfferta(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Prezzo,((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale)%>;">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td style="width: 40%; padding-left: 3px;" align="left">
                                                                                                    <span class="small_text"><b>Prezzo:&nbsp;</b></span>
                                                                                                </td>
                                                                                                <td align="left">
                                                                                                    <span class="price_large" style="font-size: 11px;">€
                                                                                                        <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale%></span>
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </td>
                                                                                <td valign="top">
                                                                                    <a href="Dettaglio-Prodotto.aspx?Categoria=<%= CurrentIDCategoria %>&amp;Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                        title="">
                                                                                        <img src="<%= UrlImmagine %><%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).UrlImmagine%>"
                                                                                            alt="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>"
                                                                                            title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>"
                                                                                            border="0" width="80px" height="80px" /></a>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td valign="middle" colspan="2" align="right">
                                                                                    <table border="0" cellspacing="1" cellpadding="1">
                                                                                        <tbody>
                                                                                            <tr>
                                                                                                <td>
                                                                                                    <img src="images/pixel.gif" width="1" height="20" alt="" />
                                                                                                </td>
                                                                                                <td valign="middle" align="center">
                                                                                                    <asp:Button class="standardsubmit" ID="btnAcquista" CommandName="ACQUISTA" runat="server"
                                                                                                        CommandArgument="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                                        Text="Acquista" Style="cursor: pointer;" ToolTip="Inserisci il prodotto nel carrello" />
                                                                                                    <asp:Button class="standardsubmit" ID="btnDettagliProd" CommandName="DETTAGLI" runat="server"
                                                                                                        Style="cursor: pointer;" CommandArgument="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                                        Text="Dettagli" ToolTip="Guarda i dettagli del prodotto" />
                                                                                                </td>
                                                                                            </tr>
                                                                                        </tbody>
                                                                                    </table>
                                                                                </td>
                                                                            </tr>
                                                                            <tr>
                                                                                <td align="center" valign="middle" colspan="2" style="height: 10px;">
                                                                                    <hr style="background-color: Red; width: 65%; height: 3px;" />
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:DataList>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                                <td class="yellow_right" width="12">
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 12px; height: 12px; background-image: url(images/main_botleft.gif);
                                    background-repeat: no-repeat;">
                                    &nbsp;
                                </td>
                                <td class="ppmainbotline" style="height: 12px;">
                                </td>
                                <td align="right" style="width: 12px; height: 12px; background-image: url(images/main_botright.gif);
                                    background-repeat: no-repeat;">
                                    &nbsp;
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </div>
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
