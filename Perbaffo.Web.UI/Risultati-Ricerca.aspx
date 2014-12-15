<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Risultati-Ricerca.aspx.cs"
    Async="true" Inherits="Perbaffo.Web.UI.Risultati_Ricerca" %>

<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="UserControl" %>
<%@ Register Src="Footer.ascx" TagName="Footer" TagPrefix="UserControl" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
<%@ Register Src="MenuCategorie.ascx" TagName="Menu" TagPrefix="UserControl" %>
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
    <link rel="stylesheet" type="text/css" href="css/ajax.css" media="screen" />
<script language="javascript" type="text/javascript" src="HttpCombinerHandler.ashx?s=Set_JavascriptThumb&amp;t=text/javascript&amp;v=1" ></script>

    <script language="javascript" type="text/javascript">
        function fCheckSearchProdotti() {
            try {
                var _cerca = document.getElementById("txtCercaProdotto");
                if (_cerca == null) {
                    return true;
                }
                var _value = trim(_cerca.value);
                if (_value == null || _value == "" || _value.length < 3) {
                    alert('Inserire almeno 3 caratteri nel campo ricerca!');
                    return false;
                }

                return true;
            }
            catch (err) {
                alert('456');
                return true;
            }
        }
        function trim(stringa) {
            stringa = stringa + "";
            return stringa.replace(/^ */, "").replace(/ *$/, "");
        }

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
    <br />
    <table border="0" cellpadding="0" cellspacing="0" width="1000px">
        <tr>
            <td align="left" valign="top">
                <UserControl:Menu ID="MenuPerbaffo" runat="server" />
                <img src="images/pixel.gif" width="1px" height="5px" border="0" alt="" /><br />
            </td>
            <td width="5" valign="top">
                <img src="images/pixel.gif" height="50" width="5" border="0" alt="" />
            </td>
            <td valign="top" width="100%" align="left">
                <table border="0" cellspacing="0" cellpadding="0" style="width:800px;background-color:#cddded;height:35;">
                    <tbody>
                        <tr>
                            <td align="left" class="topLeftStyle">
                            </td>
                            <td align="right" valign="middle">
                                <h1>
                                    <b>Risultati della ricerca</b></h1>
                            </td>
                            <td align="right" class="topRightStyle">
                            </td>
                        </tr>
                    </tbody>
                </table>
                <table border="0" cellspacing="0" cellpadding="0" width="800">
                    <tbody>
                        <tr>
                            <td class="ppmainleftline" width="10">
                                <img src="images/pixel.gif" width="12" height="12" alt="" />
                            </td>
                            <td class="bodycopy" align="center" valign="top">
                                <asp:UpdatePanel ID="updPnlProdotti" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tbody>
                                                <tr>
                                                    <td style="width: 19%;">
                                                        <span class="med_text" style="color: Black;"><b>Articolo ricercato:</b></span>
                                                    </td>
                                                    <td style="width: 81%;" align="left">
                                                        <span class="med_text" id="lblProdottoRicercato" runat="server" style="color: Black;">
                                                        </span>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" valign="middle">
                                                        <asp:TextBox ID="txtCercaProdotto" CssClass="pp_box" runat="server" MaxLength="50"
                                                            Width="200px"></asp:TextBox>&nbsp;&nbsp;
                                                        <asp:Button ID="btnCerca" CssClass="standardsubmitCerca" ToolTip="Cerca tra i nostri articoli"
                                                            CommandName="CERCA" runat="server" Text="Cerca" OnClientClick="return fCheckSearchProdotti();"
                                                            OnClick="btnCerca_Click" style="margin-right:10px;"/>
                                                      <a href="Prodotti-Images.aspx" title="Ricerca i prodotti tramite la loro foto"><img src="images/Preferiti.gif" alt="Ricerca i prodotti tramite la loro foto" width="16px" height="16px" style="border:none 0px;"/><strong><small>Cerca i prodotti tramite immagine</small></strong></a>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <br />
                                        <table id="tblCategorie" runat="server" border="0" cellspacing="0" cellpadding="0"
                                            width="90%" style="background-color: #CDDDED;">
                                            <tbody>
                                                <tr>
                                                    <td align="left" class="topLeftStyle">
                                                    </td>
                                                    <td class="bodycopy" align="left">
                                                    <span class="small_text_justify" style="color:Black;"><b>Categorie trovate:</b></span>
                                                    </td>
                                                    <td align="right" class="topRightStyle">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="bottom" width="12" align="right" style="background-image: url(images/botleft.gif);
                                                        background-repeat: no-repeat; background-position: bottom;">
                                                    </td>
                                                    <td align="left">
                                                        <ul style="padding:0;margin:0;">
                                                            <asp:Repeater ID="rptSearchCategorie" runat="server">
                                                            <ItemTemplate>
                                                                <li style="display: inline;margin-right:15px;"><a href='Dettaglio-Categoria.aspx?Categoria=<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).ID %>' title="<%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneCategoria %>" class="dark_red" style="font-size:12;"><%#((Perbaffo.Presenter.Model.Categorie)Container.DataItem).DescrizioneBreve %></a></li>
                                                            </ItemTemplate>
                                                            </asp:Repeater>
                                                        </ul>
                                                    </td>
                                                    <td valign="bottom" width="12" align="right" style="background-image: url(images/botright.gif);
                                                        background-repeat: no-repeat; background-position: bottom;">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <table id="tblNessuno" runat="server" border="0" cellpadding="0" cellspacing="0"
                                            width="100%">
                                            <tbody>
                                                <tr>
                                                    <td align="center">
                                                        <span class="large_text_bold">Nessun articolo trovato!</span>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        <UserControl:Pager ID="PagerHeader" runat="server" Separator=" | " FirstText="Primo"
                                            PreviousText="&lt;" NextText="&gt;" LastText="Ultimo" PageSize="20" NumberOfPages="15"
                                            ShowGoTo="True" OnChange="Pager_Changed" />
                                        <br />
                                        <asp:DataList ID="dtlRisultati" runat="server" GridLines="None" RepeatColumns="2"
                                            RepeatDirection="Horizontal" OnItemDataBound="dtlRisultati_ItemDataBound" OnItemCommand="dtlRisultati_ItemCommand">
                                            <ItemTemplate>
                                                <table border="0" cellspacing="1" cellpadding="0" style="width: 380px; height: 160px;">
                                                    <tbody>
                                                        <tr>
                                                            <td class="small_text" valign="top" align="center">
                                                                <a title="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%>"
                                                                    href='Dettaglio-Prodotto.aspx?Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>'>
                                                                    <b>
                                                                        <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Nome%></b></a><br />
                                                                <span class="large_text" style="text-align: left; padding-left: 3px; padding-top: 3px;">
                                                                    <%# TagliaStringa(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrizioneLunga)%></span>
                                                                <asp:Repeater ID="rptTaglie" runat="server">
                                                                    <HeaderTemplate>
                                                                        <br />
                                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                            <tr>
                                                                                <td align="left">
                                                                                    <span class="small_text"><b>Altre taglie disponibili:</b></span>
                                                                                </td>
                                                                            </tr>
                                                                            <tbody>
                                                                    </HeaderTemplate>
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td align="left">
                                                                                <div style="font-size: xx-small; font-weight: bold; padding-top: 3px">
                                                                                    <a href="Dettaglio-Prodotto.aspx?Prodotto=<%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).IDProdotto%>&amp;Taglia=<%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).ID %>"
                                                                                        style="color: Black;" title="<%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).DescrTaglia%>">
                                                                                        Misura:
                                                                                        <%#((Perbaffo.Presenter.Model.ProdottiTaglie)Container.DataItem).DescrTaglia%></a></div>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate>
                                                                        </tbody> </table>
                                                                        <br />
                                                                    </FooterTemplate>
                                                                </asp:Repeater>
                                                            </td>
                                                            <td valign="top">
                                                                <a href='Dettaglio-Prodotto.aspx?Prodotto=<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>'
                                                                    title="">
                                                                    <img src='<%= UrlImmagine %><%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).UrlImmagine%>'
                                                                        alt='<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).DescrImmagine%>'
                                                                        border="0" width="80px" height="80px" /></a>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="bottom" colspan="2" align="right" style="padding-right: 3px;">
                                                                <table cellpadding="0" cellspacing="0" width="50%" style="border-color: black; border-width: 0px;
                                                                    border-style: solid; display: <%# IsOfferta(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Prezzo,((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale)%>;">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="small_text"><b>Prezzo:</b></span>
                                                                            </td>
                                                                            <td align="right">
                                                                                <span class="price_large_black" style="text-decoration: line-through;">€
                                                                                    <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Prezzo%></span>
                                                                            </td>
                                                                        </tr>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="small_text"><b>Prezzo scontato:</b></span>
                                                                            </td>
                                                                            <td align="right">
                                                                                <span class="price_large">€
                                                                                    <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale%></span>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <table cellpadding="0" cellspacing="0" width="50%" style="border-color: #90989a;
                                                                    border-width: 0px; border-style: solid; display: <%# IsNotOfferta(((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Prezzo,((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale)%>;">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>
                                                                                <span class="small_text"><b>Prezzo:</b></span>
                                                                            </td>
                                                                            <td align="right">
                                                                                <span class="price_large">€
                                                                                    <%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).Totale%></span>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="bottom" colspan="2" align="right">
                                                                <table border="0" cellspacing="0" cellpadding="2">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td>
                                                                                <img src="images/pixel.gif" width="1" height="20" alt="" />
                                                                            </td>
                                                                            <td bgcolor="#f5f5f5" valign="middle" align="center">
                                                                                <asp:Button CssClass="standardsubmit" ID="btnAcquista" CommandName="ACQUISTA" CommandArgument="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                    runat="server" Text="Acquista" Style="cursor: pointer;" ToolTip="Inserisci il prodotto nel carrello" />
                                                                                <asp:Button CssClass="standardsubmit" ID="btnDettagli" CommandName="DETTAGLI" CommandArgument="<%#((Perbaffo.Presenter.Model.ProdottoImmagine)Container.DataItem).ID%>"
                                                                                    runat="server" Text="Dettagli" Style="cursor: pointer;" ToolTip="Guarda i dettagli del prodotto" />
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td align="center" colspan="2">
                                                                <hr style="background-color: red; width: 65%; height: 3px;" />
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </ItemTemplate>
                                        </asp:DataList>
                                        <UserControl:Pager ID="PagerFooter" runat="server" Separator=" | " FirstText="Primo"
                                            PreviousText="&lt;" NextText="&gt;" LastText="Ultimo" PageSize="20" NumberOfPages="15"
                                            ShowGoTo="True" OnChange="Pager_Changed" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td class="ppmainrightline" width="10">
                                <img src="images/pixel.gif" width="12" height="12" alt="" />
                            </td>
                        </tr>
                        <tr>
                            <td align="left" style="width: 12px; height: 12px; background-image: url(images/main_botleft.gif);
                                background-repeat: no-repeat;">
                            </td>
                            <td class="ppmainbotline" style="height: 12px;">
                            </td>
                            <td align="right" style="width: 12px; height: 12px; background-image: url(images/main_botright.gif);
                                background-repeat: no-repeat;">
                            </td>
                        </tr>
                    </tbody>
                </table>
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
