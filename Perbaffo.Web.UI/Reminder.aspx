<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reminder.aspx.cs" Inherits="Perbaffo.Web.UI.Reminder" %>

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
    <link rel="alternate" type="application/rss+xml" title="RSS" href="RssHandler.ashx" />
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />
    

    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>

    <script language="javascript" type="text/javascript">
        function fCheckRecover() {
            try {
                var _email = document.getElementById("txtEMailUser");

                if (_email == null)
                    return true;

                if (_email.value == "") {
                    alert('Inserire l\'indirizzo E-Mail con cui si è registrati!');
                    return false;
                }
                return true;
            }
            catch (err) {
                return true;
            }
        }
    </script>

</head>
<body>
    <UserControl:Header ID="Header1" runat="server" />
    <form runat="server" id="frmLogin">
    <table border="0" cellspacing="0" cellpadding="0" style="width: 1000px; background-color: #cddded;
        height: 35px;">
        <tbody>
            <tr>
                <td align="left" class="topLeftStyle">
                </td>
                <td align="right" valign="middle">
                    <h1>
                        <b>Recupero Login</b></h1>
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
                    <table class="boundingbox" border="0" cellspacing="0" cellpadding="30" style="width:600px;">
                        <tbody>
                            <tr>
                                <td class="bodycopy">
                                    <b>Recupero dei propri dati di accesso</b><br/>
                                    Inserendo l'indirizzo E-Mail con cui si è registrati si riceverà un' E-Mail con
                                    i dati per accedere a Perbaffo
                                    <table border="0" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td class="bodycopy">
                                                    <center>
                                                        <asp:Label ID="lblAlertLogin" runat="server" Text="" CssClass="warning"></asp:Label></center>
                                                    <img src="images/pixel.gif" width="150" height="1">
                                                </td>
                                            </tr>
                                          </tbody>
                                          </table>
                                    <table border="0" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td class="bodycopy">
                                                    <b>Indirizzo E-Mail</b>
                                                </td>
                                                <td rowspan="3" width="30">
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    <input id="txtEMailUser" class="pp_box" name="userdetails" 
                                                        style="width: 200px;" maxlength="50" tabindex="1" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="right">
                                                    <asp:Button ID="btnRecuperoDati" runat="server" Text="Recupero dati" 
                                                        CssClass="standardsubmit" OnClientClick="return fCheckRecover();" 
                                                        onclick="btnRecuperoDati_Click" 
                                                        ToolTip="Fai Click se vuoi ottenere una mail con i tuoi dati per accedere" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    Ritorna alla pagina di Login <a href="Login-Utente.aspx" title="Ritorna alla pagina di Login per fare accesso al mondo Perbaffo">Click qui</a>
                                </td>
                            </tr>
                        </tbody>
                    </table>
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
