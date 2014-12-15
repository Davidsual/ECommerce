<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Prodotti-Images.aspx.cs"
    Inherits="Perbaffo.Web.UI.Prodotti_Images" %>

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
    <link rel="Stylesheet" type="text/css" href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />

    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>

    <script language="javascript" type="text/javascript" src="HttpCombinerHandler.ashx?s=Set_JavascriptThumb&amp;t=text/javascript&amp;v=1"></script>

    <script type="text/javascript">
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
            <td valign="top">
                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%; background-color: #cddded;
                    height: 35px;">
                    <tbody>
                        <tr>
                            <td align="left" class="topLeftStyle">
                            </td>
                            <td rowspan="2" align="right">
                                <h1>
                                    Perbaffo Prodotti Images</h1>
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
                                            <td align="center">
                                                <span>Seleziona quale tipologia di accessorio cerchi (per cani,per gatti,per roditori,per
                                                    volatili,per acquariologia), e poi sceglia la categoria di prodotti (abbigliamento,cucce,tiragraffi,gabbie,cibo)
                                                </span>
                                                <br />
                                                <table border="0" cellspacing="0" cellpadding="0"  bgcolor="#CDDDED">
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
                                                            <td valign="bottom" width="12px" align="right" style="background-image: url(images/botleft.gif);
                                                                background-repeat: no-repeat; background-position: bottom;">
                                                            </td>
                                                            <td align="center">
                                                                <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                    border: 1px solid #cddded;" id="tblCani" runat="server">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <a href="Prodotti-Images.aspx?Animali=Cani" title="Prodotti e articoli nella Categoria Cani"
                                                                                    class="dark_red" style="font-size: 11">Cani</a>
                                                                                <br />
                                                                                <br />
                                                                                <a href="Prodotti-Images.aspx?Animali=Cani" title="Prodotti e articoli nella Categoria Cani"
                                                                                    class="dark_red" style="font-size: 11">
                                                                                    <img border="0" width="60" height="60" alt="Visita la categoria Cani" src="images/Visita-categoria-cani.jpg" />
                                                                                </a>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                    border: 1px solid #cddded;" id="tblGatti" runat="server">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <a href="Prodotti-Images.aspx?Animali=Gatti" title="Prodotti e articoli nella Categoria Gatti"
                                                                                    class="dark_red" style="font-size: 11">Gatti</a>
                                                                                <br />
                                                                                <br />
                                                                                <a href="Prodotti-Images.aspx?Animali=Gatti" title="Prodotti e articoli nella Categoria Gatti"
                                                                                    class="dark_red" style="font-size: 11">
                                                                                    <img border="0" width="60" height="60" alt="Visita la categoria Gatti" src="images/Visita-categoria-gatti.jpg" />
                                                                                </a>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                    border: 1px solid #cddded;" id="tblRoditori" runat="server">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <a href="Prodotti-Images.aspx?Animali=Roditori" title="Prodotti e articoli nella Categoria Roditori"
                                                                                    class="dark_red" style="font-size: 11">Roditori</a>
                                                                                <br />
                                                                                <br />
                                                                                <a href="Prodotti-Images.aspx?Animali=Roditori" title="Prodotti e articoli nella Categoria Roditori"
                                                                                    class="dark_red" style="font-size: 11">
                                                                                    <img border="0" width="60" height="60" alt="Visita la categoria Roditori" src="images/Visita-categoria-roditori.jpg" />
                                                                                </a>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                    border: 1px solid #cddded;" id="tblVolatili" runat="server">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <a href="Prodotti-Images.aspx?Animali=Volatili" title="Prodotti e articoli nella Categoria Volatili"
                                                                                    class="dark_red" style="font-size: 11">Volatili</a>
                                                                                <br />
                                                                                <br />
                                                                                <a href="Prodotti-Images.aspx?Animali=Volatili" title="Prodotti e articoli nella Categoria Volatili"
                                                                                    class="dark_red" style="font-size: 11">
                                                                                    <img border="0" width="60" height="60" alt="Visita la categoria Volatili" src="images/Visita-categoria-volatili.jpg" />
                                                                                </a>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                    border: 1px solid #cddded;" id="tblPesci" runat="server">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <a href="Prodotti-Images.aspx?Animali=Acquariologia" title="Prodotti e articoli nella Categoria Acquariologia"
                                                                                    class="dark_red" style="font-size: 11">Acquariologia</a>
                                                                                <br />
                                                                                <br />
                                                                                <a href="Prodotti-Images.aspx?Animali=Acquariologia" title="Prodotti e articoli nella Categoria Acquariologia"
                                                                                    class="dark_red" style="font-size: 11">
                                                                                    <img border="0" width="60" height="60" alt="Visita la categoria Acquariologia" src="images/Visita-categoria-pesci.jpg" />
                                                                                </a>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                                
                                                                <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                    border: 1px solid #cddded;" id="tblRettili" runat="server">
                                                                    <tbody>
                                                                        <tr>
                                                                            <td align="center">
                                                                                <a href="Prodotti-Images.aspx?Animali=Rettili" title="Prodotti e articoli nella Categoria Rettili"
                                                                                    class="dark_red" style="font-size: 11">Rettili</a>
                                                                                <br />
                                                                                <br />
                                                                                <a href="Prodotti-Images.aspx?Animali=Rettili" title="Prodotti e articoli nella Categoria Rettili"
                                                                                    class="dark_red" style="font-size: 11">
                                                                                    <img border="0" width="60" height="60" alt="Visita la categoria Rettili" src="images/Visita-categoria-rettili.jpg" />
                                                                                </a>
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
                                                    <tr>
                                                        <td style="width: 200px; padding: 20px; margin: 0px;" align="left" valign="top">
                                                            <table border="0" cellspacing="0" cellpadding="0" width="100%" bgcolor="#CDDDED">
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
                                                                        <td valign="bottom" width="12px" align="right" style="background-image: url(images/botleft.gif);
                                                                            background-repeat: no-repeat; background-position: bottom;">
                                                                        </td>
                                                                        <td align="left" style="padding-left: 10px;">
                                                                            <asp:Repeater ID="rptMenuCategorie" runat="server" OnItemDataBound="rptMenuCategorie_ItemDataBound"
                                                                                EnableViewState="false">
                                                                                <HeaderTemplate>
                                                                                    <ul style="padding: 0px; margin: 0px;">
                                                                                </HeaderTemplate>
                                                                                <ItemTemplate>
                                                                                    <li><a id="lnkCategoria" runat="server" class="dark_red"></a></li>
                                                                                </ItemTemplate>
                                                                                <FooterTemplate>
                                                                                    </ul></FooterTemplate>
                                                                            </asp:Repeater>
                                                                        </td>
                                                                        <td valign="bottom" width="12" align="right" style="background-image: url(images/botright.gif);
                                                                            background-repeat: no-repeat; background-position: bottom;">
                                                                        </td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                        <td valign="top" runat="server" id="tdShowImageCategory">
                                                            <h2>
                                                                <span runat="server" id="lblTitoloCategoria" enableviewstate="false"></span>
                                                            </h2>
                                                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                                <tbody>
                                                                    <asp:Repeater ID="rptImmaginiProdotti" runat="server" OnItemDataBound="rptImmaginiProdotti_ItemDataBound"
                                                                        EnableViewState="false">
                                                                        <ItemTemplate>
                                                                            <tr>
                                                                                <asp:Repeater ID="rptImmagine" runat="server" OnItemDataBound="rptImmagine_ItemDataBound"
                                                                                    EnableViewState="false">
                                                                                    <ItemTemplate>
                                                                                        <td align="center" valign="top">
                                                                                            
                                                                                                <table cellpadding="0" cellspacing="0" style="padding:10px 5px 5px 5px;height:210px; margin: 5px; border-width: 1px;
                                                                                                    border-style: solid; border-color: gray;">
                                                                                                    <tbody>
                                                                                                        <tr>
                                                                                                            <td valign="top">
                                                                                                            <a id="lnkProdotto" runat="server" class="red">
                                                                                                                <img runat="server" id="imgProdotto" width="80" alt="" height="80" style="border: 0px;" /><br />
                                                                                                                <asp:Label ID="lblDescrProdotto" runat="server" Text=""
                                                                                                                    CssClass="price_medium_black"></asp:Label>
                                                                                                                </a>
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                        <tr>
                                                                                                            <td style="padding-top: 5px;">
                                                                                                                &nbsp;
                                                                                                            </td>
                                                                                                        </tr>
                                                                                                    </tbody>
                                                                                                </table>
                                                                                            
                                                                                        </td>
                                                                                    </ItemTemplate>
                                                                                </asp:Repeater>
                                                                            </tr>
                                                                        </ItemTemplate>
                                                                    </asp:Repeater>
                                                                </tbody>
                                                            </table>
                                                        </td>
                                                    </tr>
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
        </tr>
        <tr>
            <td align="center">
                <UserControl:Footer ID="FooterPerbaffo" runat="server" EnableViewState="false" />
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
