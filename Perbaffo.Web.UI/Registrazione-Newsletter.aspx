<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrazione-Newsletter.aspx.cs"
    Inherits="Perbaffo.Web.UI.RegistrazioneNewsletter" %>
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
        function fCheckFields() {

            try {
                var _email = document.getElementById("txtEMail");
                var _chkDog = document.getElementById("chkDog");
                var _chkCat = document.getElementById("chkGatto");
                var _chkRoditore = document.getElementById("chkRoditori");
                var _chkVolatili = document.getElementById("chkVolatili");
                var _chkPesci = document.getElementById("chkPesci");

                if (_email == null || _chkDog == null || _chkCat == null || _chkRoditore == null || _chkVolatili == null || _chkPesci == null)
                    return true;

                if (_email.value == "") {
                    alert('Inserire il proprio indirizzo E-Mail!');
                    return false;
                }

                if (!_chkDog.checked && !_chkCat.checked && !_chkRoditore.checked && !_chkVolatili.checked && !_chkPesci.checked) {
                    alert('Scegliere la categoria per la quale si desidera ricevere le offerte e le promozioni!');
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
    <form runat="server" id="frmNewsletter">
    <UserControl:Header ID="Header1" runat="server" />
    <table border="0" cellspacing="0" cellpadding="0" width="1000" bgcolor="#cddded"
        height="35">
        <tbody>
            <tr>
                <td align="left" class="topLeftStyle">
                </td>
                <td align="right" valign="middle">
                    <h1>
                        <b>Iscrizione alla newsletter</b></h1>
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
                    <img src="images/pixel.gif" width="12" height="12" />
                </td>
                <td class="bodycopy" align="center">
                    <span>Se sei già un utente registrato su Perbaffo, perfavore vai alla pagina di <a href="Login-Utente.aspx" title="Login Utente">Login
                        utente</a>. Altrimenti, scegli le categorie per cui desideri ricevere le offerte speciali,
                        gli sconti e le promozioni che Perbaffo rilascia continuamente e inserisci il tuo
                        indirizzo E-Mail cosi da poterle consultare comodamente.</span>
                    <table border="0" cellspacing="0" cellpadding="30" width="650px" style="margin: 20 0 0 0;">
                        <tbody>
                            <tr>
                                <td class="bodycopy">
                                    <table border="0" cellspacing="2" cellpadding="2" align="center">
                                        <tbody>
                                            <tr>
                                                <td align="center">
                                                    <img border="0" width="80" height="80" alt="Newsletter Cani" src="images/newsletter/Newsletter_Cani.jpg" />
                                                </td>
                                                <td align="center">
                                                    <img border="0" alt="Newsletter Gatti" src="images/newsletter/Neswsletter_gatti.jpg"
                                                        width="80" height="80" />
                                                </td>
                                                <td align="center">
                                                    <img border="0" alt="Newsletter Roditori" src="images/newsletter/Newsletter_roditori.jpg"
                                                        width="80" height="80" />
                                                </td>
                                                <td align="center">
                                                    <img border="0" alt="Newsletter Uccelli" src="images/newsletter/Newsletter_volatili.jpg"
                                                        width="80" height="80" />
                                                </td>
                                                <td align="center">
                                                    <img border="0" alt="Newsletter Pesci" src="images/newsletter/Newsletter_pesci.jpg"
                                                        width="80" height="80" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:CheckBox ID="chkDog" runat="server" EnableViewState="false" />
                                                </td>
                                                <td align="center">
                                                    <asp:CheckBox ID="chkGatto" runat="server" EnableViewState="false" />
                                                </td>
                                                <td align="center">
                                                    <asp:CheckBox ID="chkRoditori" runat="server" EnableViewState="false" />
                                                </td>
                                                <td align="center">
                                                    <asp:CheckBox ID="chkVolatili" runat="server" EnableViewState="false" />
                                                </td>
                                                <td align="center">
                                                    <asp:CheckBox ID="chkPesci" runat="server" EnableViewState="false" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <br />
                                    <span>Inserite il vostro indirizzo e-mail e cliccate su "Registrati". Otterrete le notizie
                                        e le offerte. I vostri dati verranno trattati nel rispetto delle leggi vigenti sulla
                                        privacy.</span>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" valign="top">
                                    <table border="0" cellspacing="0" cellpadding="0">
                                        <tbody>
                                            <tr>
                                                <td class="bodycopy" colspan="3" align="center">
                                                    <span class="warning"><b>
                                                        <asp:Label ID="lblErrorMessage" runat="server" Text="" Visible="false"></asp:Label></b></span>
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
                                                    <asp:TextBox ID="txtEMail" runat="server" CssClass="pp_box" Style="width: 200px;" MaxLength="50"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="right">
                                                    <asp:Button CssClass="standardsubmit" ID="btnRegistrati" OnClientClick="return fCheckFields();"
                                                        runat="server" Text="Registrati" OnClick="btnRegistrati_Click" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" align="right" class="bodycopy">
                                                    Se sei già un utente di Perbaffo <a href="Login-Utente.aspx" title="Vai alla pagina di Login">Clicca qui?</a>
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
