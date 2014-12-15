<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contatti.aspx.cs" Inherits="Perbaffo.Web.UI.Contatti" %>

<%@ Register Src="WidgetAssistenza.ascx" TagName="Assistenza" TagPrefix="UserControl" %>
<%@ Register Src="WidgetNewsletter.ascx" TagName="Newsletter" TagPrefix="UserControl" %>
<%@ Register Src="WidgetPerbaffoWorld.ascx" TagName="PerbaffoWorld" TagPrefix="UserControl" %>
<%@ Register Src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
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

    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>
    <script type="text/javascript" src="http://download.skype.com/share/skypebuttons/js/skypeCheck.js"></script>
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
                                    Chi Siamo
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
                                <br />
                                <table border="0" cellspacing="0" cellpadding="0" width="70%">
                                    <tbody>
                                        <tr>
                                            <td class="bodycopy" valign="middle" align="left">
                                                <strong>Telefono</strong>
                                            </td>
                                            <td width="12">
                                                <img src="images/pixel.gif" width="12" height="12" alt="" />
                                            </td>
                                            <td align="left">
                                                <br />
                                                011-19567088
                                                <br />
                                                <br />
                                                dal lunedi al venerdi<br />
                                                8.30 - 13.30
                                                <br />
                                                15.30 - 18.00
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bodycopy">
                                            </td>
                                            <td width="12">
                                            </td>
                                            <td class="bodycopy" align="left">
                                                <img style="width: 450px; height: 2px" src="images/horiz_bar.gif" width="609" height="2"
                                                    alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bodycopy" align="left">
                                                <strong>Fax</strong>
                                            </td>
                                            <td width="12">
                                            </td>
                                            <td class="bodycopy" align="left">
                                                011/4785123
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bodycopy">
                                            </td>
                                            <td width="12">
                                            </td>
                                            <td class="bodycopy" align="left">
                                                <img style="width: 450px; height: 2px" src="images/horiz_bar.gif" width="350" height="2"
                                                    alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bodycopy" align="left">
                                                <strong>E-Mail</strong>
                                            </td>
                                            <td width="12">
                                            </td>
                                            <td class="bodycopy" align="left">
                                                <a href="mailto:info@perbaffo.it?subject=Informazioni" title="Contatti Perbaffo">info@perbaffo.it</a>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bodycopy">
                                            </td>
                                            <td width="12">
                                            </td>
                                            <td class="bodycopy" align="left">
                                                <img style="width: 450px; height: 2px" src="images/horiz_bar.gif" width="609" height="2"
                                                    alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bodycopy" align="left">
                                                <strong>MSN</strong>
                                            </td>
                                            <td width="12">
                                            </td>
                                            <td class="bodycopy" align="left" >
                                                <script type="text/javascript" src="http://settings.messenger.live.com/controls/1.0/PresenceButton.js"></script>
                                                Clicca qui 
                                                <div
                                                  id="Microsoft_Live_Messenger_PresenceButton_3fd39ea463071922"
                                                  msgr:width="100"
                                                  msgr:backColor="#D7E8EC"
                                                  msgr:altBackColor="#FFFFFF"
                                                  msgr:foreColor="#424542"
                                                  msgr:conversationUrl="http://settings.messenger.live.com/Conversation/IMMe.aspx?invitee=3fd39ea463071922@apps.messenger.live.com&mkt=it-IT"></div>&nbsp;Contatta l'assistenza clienti
                                                <script type="text/javascript" src="http://messenger.services.live.com/users/3fd39ea463071922@apps.messenger.live.com/presence?dt=&mkt=it-IT&cb=Microsoft_Live_Messenger_PresenceButton_onPresence"></script>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bodycopy">
                                            </td>
                                            <td width="12">
                                            </td>
                                            <td class="bodycopy" align="left">
                                                <img style="width: 450px; height: 2px" src="images/horiz_bar.gif" width="609" height="2"
                                                    alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bodycopy" align="left">
                                                <strong>Skype</strong>
                                            </td>
                                            <td width="12">
                                            </td>
                                            <td class="bodycopy" align="left" style="display:block;">
                                                <a href="skype:perbaffo?call">
                                                    <img src="http://download.skype.com/share/skypebuttons/buttons/call_green_white_92x82.png"
                                                        style="border: none;" width="92" height="82" alt="Skype Me™!" /></a>&nbsp;ID Skype 'perbaffo'
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bodycopy">
                                            </td>
                                            <td width="12">
                                            </td>
                                            <td class="bodycopy" align="left">
                                                <img style="width: 450px; height: 2px" src="images/horiz_bar.gif" width="350" height="2"
                                                    alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="bodycopy" valign="top" align="left">
                                                <strong>Informazioni aziendali</strong>
                                            </td>
                                            <td width="12">
                                            </td>
                                            <td class="bodycopy" align="left">
                                                Perbaffo di Albanesi Silvia<br />
                                                Sede legale:<br />
                                                Via Nino Costa n°16<br />
                                                10044 Pianezza (TO)<br />
                                                <br />
                                                P.IVA 09741830013
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
