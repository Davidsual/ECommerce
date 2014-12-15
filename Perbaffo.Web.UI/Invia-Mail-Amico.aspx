<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invia-Mail-Amico.aspx.cs"
    Inherits="Perbaffo.Web.UI.Invia_Mail_Amico" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Dillo ad un amico</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta name="Robots" content="index,follow" />
    <meta name="Author" content="Davide Trotta" />    
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />
</head>
<body>
<form id="frmPerbaffo" runat="server">
    <p>
        <b>Segnala il prodotto ad un tuo amico</b></p>
    <hr />
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr>
                <td align="center">
                    <table border="0" cellspacing="0" cellpadding="0" width="95%" bgcolor="#CDDDED">
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
                                    
                                    <table border="0" cellpadding="0" cellspacing="4" width="100%">
                                        <tr>
                                            <td align="left" style="color:Red;">
                                                <b>
                                                    Nome del tuo amico:
                                                </b>
                                            </td>
                                            <td>
                                                <img border="0" src="images/spacer.gif" width="10px" alt="" />
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtNomeAmico" MaxLength="50" runat="server" Width="200"></asp:TextBox>&nbsp;*
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNomeAmico"
                                                    ErrorMessage="Inserire il nome del tuo amico" ValidationGroup="SEGNALA">!</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left" style="color:Red;">
                                                <b>
                                                    E-Mail del tuo amico:
                                                </b>
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtEmailAmico" MaxLength="50" runat="server" Width="200"></asp:TextBox>&nbsp;*
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmailAmico"
                                                    ErrorMessage="Inserire E-Mail del tuo amico" ValidationGroup="SEGNALA">!</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>   
                                        <tr>
                                            <td colspan="3"><hr /></td>
                                        </tr>  
                                        <tr>
                                            <td align="left">
                                                <b>
                                                    Tuo nome:
                                                </b>
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtTuoNome" MaxLength="50" runat="server" Width="200"></asp:TextBox>&nbsp;*
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTuoNome"
                                                    ErrorMessage="Inserire il tuo nome" ValidationGroup="SEGNALA">!</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <b>
                                                    Tua E-Mail:
                                                </b>
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <asp:TextBox ID="txtTuaEmail" MaxLength="50" runat="server" Width="200"></asp:TextBox>&nbsp;*
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTuaEmail"
                                                    ErrorMessage="Inserire la tua E-Mail" ValidationGroup="SEGNALA">!</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left">
                                                <b>
                                                    Messaggio:
                                                </b>
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <textarea id="txtTesto" runat="server" rows="5" cols="35">Navigando su www.perbaffo.it ho trovato un prodotto interessante che vorrei mostrarti. Cliccando sul link proposto potrai vederlo anche tu!</textarea>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left">
                                                Gli indirizzi E-Mail non saranno utilizzati a scopo commerciale
                                            </td>
                                        </tr>   
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button class="standardsubmit" ID="btnSendMail" runat="server" Text="Invia E-Mail"
                                                    Style="cursor: pointer;" ValidationGroup="SEGNALA" ToolTip="Segnala il prodotto ad un tuo amico"
                                                    OnClick="btnSendMail_Click" />
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                    ShowSummary="False" ValidationGroup="SEGNALA" />
                                            </td>
                                        </tr>                                                                                                                                                        
                                    </table>
                                    
                                </td>
                                <td valign="bottom" width="12" align="right" style="background-image: url(images/botright.gif);
                                    background-repeat: no-repeat; background-position: bottom;">
                                </td>
                            </tr>
                        </tbody>
                    </table>
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
