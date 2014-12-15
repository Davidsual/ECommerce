<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Galleria-Foto-Animali.aspx.cs"
    Inherits="Perbaffo.Web.UI.Galleria_Foto_Animali" %>
<%@ Register src="WidgetRegistrazione.ascx" TagName="Registrazione" TagPrefix="UserControl" %>
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
    <meta name="description" content="<%=DescrizionePagina %>" />
    <meta name="keywords" content="<%=KeywordsPagina %>" />
    <meta name="Robots" content="index,follow" />
    <meta name="Author" content="Davide Trotta" />    
    <link rel="alternate" type="application/rss+xml" title="RSS" href="RssHandler.ashx" />
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />
    <link href="css/jquery.lightbox-0.5.css" rel="stylesheet" type="text/css" />
    <script src="script/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>
    <script src="script/jquery.lightbox-0.5.pack.js" type="text/javascript"></script>

    <script type="text/javascript">
        
        function fInit() {
            try
            {
                $('#gallery a').lightBox();
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
                            <td rowspan="2" align="right">
                                <h1>
                                    Le foto dei nostri amici</h1>
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
                                <table border="0" cellspacing="0" cellpadding="0" style="width: 100%;">
                                    <tbody>
                                        <tr>
                                            <td>
                                                <span class="small_ten_text">Queste sono le foto degli amici degli utenti 
                                                iscritti su Perbaffo.<br />Se vuoi inserire la foto del tuo amico iscriviti su 
                                                Perbaffo, vai nel tuo <a href="Pannello-Utente.aspx" title="Pannello di controllo utente">
                                                pannello di controllo</a> e inserisci la foto.</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <table border="0" cellspacing="0" cellpadding="0" style="width:100%;">
                                                    <tbody>
                                                        <tr>
                                                            <td align="left" style="width: 12px; height: 12px;">
                                                            </td>
                                                            <td class="bodycopy">
                                                            </td>
                                                            <td align="right" style="width: 12px; height: 12px;">
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="bottom" width="12px" align="right" >
                                                            </td>
                                                            <td align="center" >
                                                                <asp:UpdatePanel ID="updPnlFoto" runat="server" UpdateMode="Conditional">
                                                                <ContentTemplate>                                                                      
                                                                <div id="gallery">                                                
                                                                    <asp:Repeater ID="rptPhotoGallery" runat="server">
                                                                    <HeaderTemplate><ul></HeaderTemplate>
                                                                    <ItemTemplate>
                                                                       <li><a href="<%= UrlImmagine %><%#((Perbaffo.Presenter.FotoAmici)Container.DataItem).UrlImage%>" title="<%#((Perbaffo.Presenter.FotoAmici)Container.DataItem).DescrImage%>" style="text-decoration:none;">
                                                                            <img src="<%= UrlImmagine %><%#((Perbaffo.Presenter.FotoAmici)Container.DataItem).UrlImage%>" width="70" height="70" alt="" />
                                                                        </a></li>
                                                                    </ItemTemplate>
                                                                    <FooterTemplate></ul></FooterTemplate>
                                                                    </asp:Repeater>
                                                                
                                                                </div>
                                                                    <br />  
                                                                    <table border="0" cellpadding="0" cellspacing="0" width="95%" style="background-color:#CDDDED;">
                                                                        <tbody>
                                                                            <tr>
                                                                                <td>
                                                                                <UserControl:Pager ID="PagerFooter" runat="server" Separator=" | " FirstText="Primo"
                                                            PreviousText="&lt;" NextText="&gt;" LastText="Ultimo" PageSize="24" NumberOfPages="15"
                                                            ShowGoTo="True" OnChange="Pager_Changed" />   
                                                                                </td>
                                                                            </tr>
                                                                        </tbody>
                                                                    </table>
                                                                                                                         
                                                                </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </td>
                                                            <td valign="bottom" width="12px" align="right">
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
