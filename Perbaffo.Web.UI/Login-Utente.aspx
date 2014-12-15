<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login-Utente.aspx.cs" Inherits="Perbaffo.Web.UI.LoginUtente" %>

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
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />
    
    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>
    <script language="javascript" type="text/javascript">
        function fCheckRegister() {
            try 
            {
                var _email = document.getElementById("txtEmail");

                if (_email == null)
                    return true;

                if (_email.value == "") {
                    alert('Inserire l\'indirizzo E-Mail con cui ci si vuole registrare!');
                    return false;
                }
                return true;
            }
            catch (err) {
                return true;
            }
        }
        function fCheckFields() {

            try {
                var _email = document.getElementById("txtEmailUtente");
                var _password = document.getElementById("txtpassword");


                if (_email == null || _password == null)
                    return true;

                if (_email.value == "" || _password.value == "") {
                    alert('Inserire E-Mail e la relativa password con cui si è registrati su Perbaffo!');
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
<form runat="server" id="frmLogin">
    <UserControl:Header ID="Header1" runat="server" />
    
    <table border="0" cellspacing="0" cellpadding="0" style="width:1000px; background-color:#cddded;height:35px;">
        <tbody>
            <tr>
                <td align="left" class="topLeftStyle">
                </td>
                <td align="right" valign="middle">
                    <h1>
                        <b>Registrazione e Accesso a Perbaffo</b></h1>
                </td>
                <td align="right" class="topRightStyle">
                </td>
            </tr>
        </tbody>
    </table>
    <table border="0" cellspacing="0" cellpadding="0" width="1000px">
        <tbody>
            <tr>
                <td class="ppmainleftline" width="10">
                    <img src="images/pixel.gif" width="12" height="12" alt="" />
                </td>
                <td class="bodycopy" align="center">
                    <span id="lblDescrizioneAcquisto" runat="server">Se sei già iscritto a Perbaffo inserisci l'indirizzo E-Mail con cui ti sei iscritto e la password da te scelta. Altrimenti,
                        se desideri diventare un utente di Perbaffo per accedere al Pet Shop e alle sue offerte e promozioni, alla newsletter inserisci
                        l'indirizzo e-mail con cui intendi iscriverti e in pochi istanti diventerai un utente di Perbaffo.</span>
                    <table class="boundingbox" border="0" cellspacing="0" cellpadding="30" style="margin:20 0 0 0;width:450px">
                        <tbody>
                            <tr>
                                <td class="bodycopyy" style="background-color:#cddded;background-image:url(images/lucchetto.gif);background-repeat:no-repeat;background-position:left;">
                                    <b>Perbaffo Login</b> - Inserisci qui E-Mail e password per accedere
                                </td>
                            </tr>
                            <tr>
                                <td class="bodycopy">
                                    <table border="0" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td class="bodycopy" colspan="3">
                                                <center>
                                                    <asp:Label ID="lblAlertLogin" runat="server" Text="" CssClass="warning"></asp:Label></center>
                                                    <img src="images/pixel.gif" width="150" height="1" alt="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bodycopy">
                                                    <b>Indirizzo E-Mail</b>
                                                </td>
                                                <td rowspan="3" width="30">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <input id="txtEmailUtente" class="pp_box" name="txtEmailUtente" runat="server" 
                                                        style="width: 200px;" maxlength="50" tabindex="1" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bodycopy">
                                                    <b>Password</b>
                                                </td>
                                                <td>
                                                    <input id="txtpassword" class="pp_box" value="" type="password" 
                                                        name="txtpassword" maxlength="20" 
                                                        runat="server" style="width: 200px;" tabindex="2" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="right">
                                                    <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="standardsubmit" OnClientClick="return fCheckFields();"
                                                        onclick="btnLogin_Click" TabIndex="3" ToolTip="Entra in Perbaffo" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <br />
                                    <span>Se hai dimenticato la tua password? <a href="Reminder.aspx" title="Se hai dimenticato la tua password fai click qui">Clicca qui</a></span>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <br />
                    <table class="boundingbox" border="0" cellspacing="0" cellpadding="30" style="margin: 20 0 0 0;width:450px">
                        <tbody>
                            <tr>
                                <td class="bodycopyy" style="background-color:#cddded;background-image:url(images/lucchetto.gif);background-repeat:no-repeat;background-position:left;">
                                    <b>Registrati</b> - Inserisci la tua E-Mail e registrati su Perbaffo
                                </td>
                            </tr>
                            <tr>
                                <td class="bodycopy">
                                    <table border="0" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td class="bodycopy" colspan="3">
                                                <center>
                                                    <asp:Label ID="lblAlertRegistrazione" runat="server" Text="" CssClass="warning"></asp:Label></center>
                                                    <img src="images/pixel.gif" width="150" height="1" alt="" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="bodycopy">
                                                    <b>Indirizzo E-Mail</b>
                                                </td>
                                                <td width="30">
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <input id="txtEmail" class="pp_box" name="txtEmail" runat="server" 
                                                        style="width: 200px;" maxlength="50" tabindex="5" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="right">
                                                    <asp:Button ID="btnRegister" runat="server" Text="Registrati" OnClientClick="return fCheckRegister();"
                                                        CssClass="standardsubmit" onclick="btnRegister_Click" 
                                                        ToolTip="Registrati su Perbaffo" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
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
