<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Allevamenti.aspx.cs" Inherits="Perbaffo.Web.UI.Allevamenti" %>

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

    <script type="text/javascript" language="javascript" src="script/Perbaffo.Web.UI.Function.js"></script>

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
                                    Allevamenti</h1>
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
                                                            <td align="left">
                                                                <span class="med_text_dodici" style="color:Black;line-height:17px;">
                                                                Se hai un allevamento e vuoi inserire gratuitamente i tuoi dati nel nostro database per essere raggiunto più facilmente da nuovi clienti, clicca sul link sottostante per scaricare il modulo e dopo averlo compilato, inviacelo via email <a href="mailto:info@perbaffo.it?subject=Allevamenti" class="dark_red" title="Manda l'E-Mail per allevamento"><b>info@perbaffo.it</b></a> o mezzo fax.
                                                                </span>
                                                                <br /><br />
                                                                <a href="Documents/modulo-iscrizione-allevamento.pdf" class="dark_red" title="Modulo iscrizione allevamento" target="_blank"><b>Modulo iscrizione allevamento (.pdf)</b></a>
                                                            </td>
                                                            <td valign="bottom" width="12" align="right" style="background-image: url(images/botright.gif);
                                                                background-repeat: no-repeat; background-position: bottom;">
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                                <br />
                                                <table border="0" width="90%" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>DOLCECHIHUAHUA</b></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text">Selezione esclusiva del CHIHUAHUA pelo corto e lungo</span></td>
                                                    </tr>                                                    
                                                    <tr>
                                                        <td align="left"><span class="large_text">San Cesareo - Roma - Italia</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Tel:</b>328-3225525</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>E-Mail:</b> <a href="mailto:dolcechihuahua@libero.it?subject=Informazioni" title="Contattaci">dolcechihuahua@libero.it</a></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Sito:</b> <a href="http://www.dolcechihuahua.it" target="_blank" title="DOLCECHIHUAHUA">www.dolcechihuahua.it</a></span></td>
                                                    </tr>
                                                </tbody>
                                                </table>
                                                <br />
                                                <table border="0" width="90%" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Allevamento della Valle di Suessola (canarini e cardellini)</b></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text">Associazione campania Felix</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text">Rosso mosaico,Gloster Fancy,razza spagnola,selezione del cardellino</span></td>
                                                    </tr>                                                    
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Tel:</b>347-6653746</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>E-Mail:</b> <a href="mailto:allevamentosuessola@live.it?subject=Informazioni" title="Contattaci">allevamentosuessola@live.it</a></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Sito:</b> <a href="http://www.allevamentocanarini.netsons.org/" target="_blank" title="Allevamento della Valle di Suessola (canarini e cardellini)">http://www.allevamentocanarini.netsons.org/</a></span></td>
                                                    </tr>
                                                </tbody>
                                                </table>  
                                                <br />
                                                <table border="0" width="90%" cellpadding="0" cellspacing="0">
                                                <tbody>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Allevamento Betulla di Freya</b></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text">Gatti razza Maine Coon</span></td>
                                                    </tr>                                                       
                                                    <tr>
                                                        <td align="left"><span class="large_text">Allevamento amatoriale - Via Bonvino 65 41018 Scesario Modena</span></td>
                                                    </tr>                                                 
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Tel:</b>328-8236796</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>E-Mail:</b> <a href="mailto:info@betulladifreya.com?subject=Informazioni" title="Contattaci">info@betulladifreya.com</a></span></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left"><span class="large_text"><b>Sito:</b> <a href="http://betulladifreya.com/" target="_blank" title="Allevamento Betulla di Freya">http://betulladifreya.com/</a></span></td>
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
