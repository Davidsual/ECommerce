<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Curiosita-Animali.aspx.cs" Inherits="Perbaffo.Web.UI.Curiosita_Animali" %>
<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
<%@ Register Src="Pager.ascx" TagName="Pager" TagPrefix="UserControl" %>
<%@ Register src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
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
                                    Info &amp; Curiosità</h1>
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
                                            <td>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%">
                                    <tbody>
                                        <tr>
                                            <td align="center">
                                                <asp:UpdatePanel ID="updPnlOfferta" runat="server" UpdateMode="Conditional">
                                                    <ContentTemplate>
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
                                                                                        <asp:LinkButton ID="LinkButton1" ToolTip="Prodotti e articoli nella Categoria Cani"
                                                                                            CssClass="dark_red" Style="font-size: 11" runat="server" CommandName="CANI" OnClick="lnkAction_Click">Cani</asp:LinkButton>
                                                                                        <br />
                                                                                        <br />
                                                                                        <asp:LinkButton ID="lnkImgCani" ToolTip="Prodotti e articoli nella Categoria Cani"
                                                                                            CssClass="dark_red" Style="font-size: 11" runat="server" CommandName="CANI" OnClick="lnkAction_Click">
                                                                                                        <img border="0" width="60" height="60" alt="Visita la categoria Cani" src="images/Visita-categoria-cani.jpg" />
                                                                                        </asp:LinkButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                            border: 1px solid #cddded;" id="tblGatti" runat="server">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <asp:LinkButton ID="lnkGatti" ToolTip="Prodotti e articoli nella Categoria Gatti"
                                                                                            CssClass="dark_red" Style="font-size: 11" runat="server" CommandName="GATTI"
                                                                                            OnClick="lnkAction_Click">Gatti</asp:LinkButton>
                                                                                        <br />
                                                                                        <br />
                                                                                        <asp:LinkButton ID="lnkImgGatti" ToolTip="Prodotti e articoli nella Categoria Gatti"
                                                                                            CssClass="dark_red" Style="font-size: 11" runat="server" CommandName="GATTI"
                                                                                            OnClick="lnkAction_Click">
                                                                                                        <img border="0" width="60" height="60" alt="Visita la categoria Gatti" src="images/Visita-categoria-gatti.jpg" />
                                                                                        </asp:LinkButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                            border: 1px solid #cddded;" id="tblRoditori" runat="server">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <asp:LinkButton ID="lnkRoditori" ToolTip="Prodotti e articoli nella Categoria Roditori"
                                                                                            CssClass="dark_red" Style="font-size: 11" runat="server" CommandName="RODITORI"
                                                                                            OnClick="lnkAction_Click">Roditori</asp:LinkButton>
                                                                                        <br />
                                                                                        <br />
                                                                                        <asp:LinkButton ID="lnkImgRoditori" ToolTip="Prodotti e articoli nella Categoria Roditori"
                                                                                            CssClass="dark_red" Style="font-size: 11" runat="server" CommandName="RODITORI"
                                                                                            OnClick="lnkAction_Click">
                                                                                                        <img border="0" width="60" height="60" alt="Visita la categoria Roditori" src="images/Visita-categoria-roditori.jpg" />
                                                                                        </asp:LinkButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                            border: 1px solid #cddded;" id="tblVolatili" runat="server">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <asp:LinkButton ID="lnkVolatili" ToolTip="Prodotti e articoli nella Categoria Volatili"
                                                                                            CssClass="dark_red" Style="font-size: 11" runat="server" CommandName="VOLATILI"
                                                                                            OnClick="lnkAction_Click">Volatili</asp:LinkButton>
                                                                                        <br />
                                                                                        <br />
                                                                                        <asp:LinkButton ID="lnkImgVolatili" ToolTip="Prodotti e articoli nella Categoria Volatili"
                                                                                            CssClass="dark_red" Style="font-size: 11" runat="server" CommandName="VOLATILI"
                                                                                            OnClick="lnkAction_Click">
                                                                                                        <img border="0" width="60" height="60" alt="Visita la categoria Volatili" src="images/Visita-categoria-volatili.jpg" />
                                                                                        </asp:LinkButton>
                                                                                    </td>
                                                                                </tr>
                                                                            </tbody>
                                                                        </table>
                                                                        <table cellspacing="0" cellpadding="0" style="width: 95px; height: 90px; float: left;
                                                                            border: 1px solid #cddded;" id="tblPesci" runat="server">
                                                                            <tbody>
                                                                                <tr>
                                                                                    <td align="center">
                                                                                        <asp:LinkButton ID="lnkPesci" ToolTip="Prodotti e articoli necalla Categoria Acquariologia"
                                                                                            CssClass="dark_red" Style="font-size: 11" runat="server" CommandName="PESCI"
                                                                                            OnClick="lnkAction_Click">Acquariologia</asp:LinkButton>
                                                                                        <br />
                                                                                        <br />
                                                                                        <asp:LinkButton ID="lnkImgPesci" ToolTip="Prodotti e articoli nella Categoria Acquariologia"
                                                                                            CssClass="dark_red" Style="font-size: 11" runat="server" CommandName="PESCI"
                                                                                            OnClick="lnkAction_Click">
                                                                                                        <img border="0" width="60" height="60" alt="Visita la categoria Acquariologia" src="images/Visita-categoria-pesci.jpg" />
                                                                                        </asp:LinkButton>
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
                                                        <asp:Panel ID="pnlRighe" runat="server" Visible="false">
                                                            <asp:Label ID="lblMessage" runat="server" CssClass="med_text" Style="font-size: 12;
                                                                font-weight: bold;" Text="Nessuna Info & Curiosità trovata" />
                                                        </asp:Panel>
                                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                                            <tbody>
                                                                <asp:Repeater ID="rptCuriosita" runat="server" 
                                                                    onitemdatabound="rptCuriosita_ItemDataBound">
                                                                    <ItemTemplate>
                                                                        <tr>
                                                                            <td style="width: 100px;">
                                                                                &nbsp;
                                                                            </td>
                                                                            <td align="left" style="padding: 1px 0px 6px 0px;">
                                                                                <font style="font-size:11px;font-family:Tahoma;text-align:justify;">
                                                                                    <asp:Label ID="lblDescrizione" runat="server" Text=""></asp:Label></font>
                                                                            </td>
                                                                        </tr>
                                                                    </ItemTemplate>
                                                                </asp:Repeater>
                                                            </tbody>
                                                        </table>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </td>
                                        </tr>
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