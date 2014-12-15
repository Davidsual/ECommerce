<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrazione-Utente-Foto.aspx.cs"
    Inherits="Perbaffo.Web.UI.Registrazione_Utente_Foto" %>

<%@ OutputCache Location="None" VaryByParam="None" %>
<%@ Register Src="Header.ascx" TagName="Header" TagPrefix="UserControl" %>
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
    <meta http-equiv="Pragma" content="no-cache" />
    <meta http-equiv="Expires" content="-1" />
    <meta http-equiv="CACHE-CONTROL" content="NO-CACHE" />        
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />
    

    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>
    <script type="text/javascript" language="javascript">
    function fSubmit() {
        try
        {
            __doPostBack('Load', 'Reload'); 
        }
        catch (err) {
            return;
        }
    }
    </script>
</head>
<body>
    <UserControl:Header ID="Header1" runat="server" />
    <form runat="server" id="frmLogin">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <table border="0" cellspacing="0" cellpadding="0" style="width: 1000px; background-color: #cddded;
        height: 35px;">
        <tbody>
            <tr>
                <td align="left" class="topLeftStyle">
                </td>
                <td align="right" valign="middle">
                    <h1>
                        <b>Inserisci la foto del tuo animale</b></h1>
                </td>
                <td align="right" class="topRightStyle">
                </td>
            </tr>
        </tbody>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="1000">
        <tbody>
            <tr>
                <td class="ppmainleftline" width="10">
                    <img src="images/pixel.gif" width="12" height="12" alt="" />
                </td>
                <td class="bodycopy" align="center">
                    <span>Se vuoi puoi inserire la foto del tuo piccolo amico. Questa foto comparirà nel tuo
                        profilo, e nella gallery delle immagini degli amici di Perbaffo.
                        <br />
                        (Potrai inserire/modificare la foto anche in un secondo momento)</span>
                    <asp:UpdatePanel ID="updPnlUtente" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="boundingbox" border="0" cellspacing="0" cellpadding="10" style="margin: 20 0 0 0;
                                width: 600px">
                                <tbody>
                                    <tr>
                                        <td class="bodycopyy" bgcolor="#cddded">
                                            <span><b>Inserisci Foto del tuo amico</b></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="bodycopy">
                                            <asp:UpdatePanel ID="updPnlPreviewFoto" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <table cellspacing="0" cellpadding="2" width="100%" style="border-color: #000000;
                                                        border-width: 1px; border-style: solid;">
                                                        <tbody>
                                                            <tr>
                                                                <td valign="top" align="center">
                                                                    <asp:Image ID="imgFriend" runat="server" ImageUrl="images/no-image.jpg" Width="240"
                                                                        Height="240" BorderWidth="0" /><br />
                                                                    <span id="lblNomeFriend" runat="server" class="small_text"></span>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td valign="top" align="right">
                                                                <asp:Button ID="btnElimina" runat="server" Text="Cancella foto" CssClass="standardsubmit"
                                                                    TabIndex="1" ToolTip="Cancella foto" onclick="btnElimina_Click" />
                                                                </td>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                            <table cellspacing="0" cellpadding="2" width="100%" style="border-color: #000000;
                                                border-width: 1px; border-style: solid;">
                                                <tbody>
                                                    <tr>
                                                        <td class="bodycopy" style="padding-left: 4px;" valign="top">
                                                            <iframe id="Load" width="550px" height="100px" runat="server" frameborder="0" marginwidth="0">
                                                            </iframe>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table border="0" cellspacing="0" cellpadding="0" style="margin: 20 0 0 0; width: 600px">
                                <tbody>
                                    <tr>                              
                                        <td class="bodycopyy" align="right">
                                            <asp:Button ID="btnCarrello" runat="server" Text="Vai al Carrello" CssClass="standardsubmit"
                                                TabIndex="19" ToolTip="Vai al carrello"  style="margin-right:20px;" 
                                                onclick="btnCarrello_Click"/>                                        
                                            <asp:Button ID="btnContinua" runat="server" Text="Home Page" CssClass="standardsubmit"
                                                TabIndex="19" ToolTip="Torna all Home Page" OnClick="btnContinua_Click" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <img border="0" src="/images/pixel.gif" width="1" height="5" alt="" /><br />
                    <img border="0" src="/images/pixel.gif" width="1" height="5" alt="" /><br />
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
    </form>
</body>
</html>
