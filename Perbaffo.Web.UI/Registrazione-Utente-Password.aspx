<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrazione-Utente-Password.aspx.cs"
    Inherits="Perbaffo.Web.UI.Registrazione_Utente_Password" %>

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

</head>
<body>
    <UserControl:Header ID="Header1" runat="server" />
    <form runat="server" id="frmLogin" autocomplete="off">
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
                        <b>Registrazione password</b></h1>
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
                <img src="images/Registrazione_passo_2.gif" title="Registrazione password" width="256" height="59" border="0" style="display:block"/>
                    <span>Scegli solo la tua password e avrai completato la registrazione</span>
                    <asp:UpdatePanel ID="updPnlUtente" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table class="boundingbox" border="0" cellspacing="0" cellpadding="10" style="margin: 20 0 0 0;
                                width: 600px">
                                <tbody>
                                    <tr>
                                        <td class="bodycopyy" bgcolor="#cddded" align="left">
                                            <b>Inserisci Password</b> - Ricorda la password deve contenere almeno 6 caratteri
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="bodycopy">
                                            <table cellspacing="0" cellpadding="2" width="100%" style="border-color:#000000;border-width:1px;border-style:solid;">
                                                <tbody>
                                                    <tr>
                                                        <td class="bodycopy" style="padding-left:4px;" valign="top" align="left">
                                                            <span class="small_text" ><b>Riepilogo dati:</b></span><br />
                                                            <span class="small_text" id="lblRiepilogo" runat="server"></span>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td valign="top" align="right">
                                                            <asp:Button ID="btnModifica" runat="server" Text="Modifica" CssClass="standardsubmit"
                                                                TabIndex="0" ToolTip="Modifica i tuoi dati" onclick="btnModifica_Click" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <table border="0" cellspacing="0" cellpadding="0" width="70%">
                                                <tbody>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Username (E-Mail)</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:Label ID="lblEMail" runat="server" Text="" CssClass="med_text" Style="color: Black;"></asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Password</b> (almeno 6 caratteri)
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox TextMode="Password" ID="txtPassword" runat="server" CssClass="pp_box_registrazione"
                                                                Width="150" MaxLength="15" TabIndex="1"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPassword"
                                                                ErrorMessage="Inserisci la tua password" ToolTip="Inserisci la tua password"
                                                                ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtPassword"
                                                                ControlToValidate="txtRetypePassword" ErrorMessage="Le due password devono coincidere"
                                                                ValidationGroup="UTENTE" ToolTip="Le due password devono coincidere">!</asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="bodycopy" align="left">
                                                            <b>Ridigita Password</b>
                                                        </td>
                                                        <td align="left">
                                                            <asp:TextBox ID="txtRetypePassword" TextMode="Password" runat="server" CssClass="pp_box_registrazione"
                                                                Width="150" MaxLength="15" TabIndex="2"></asp:TextBox>&nbsp;*
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRetypePassword"
                                                                ErrorMessage="Ridigita la tua password" ToolTip="Ridigita la tua password" ValidationGroup="UTENTE">!</asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" align="left">
                                                            <span class="small_text">I campi con l’asterisco * sono obbligatori e devono essere
                                                                compilati</span>
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
                                            <asp:Button ID="btnContinua" runat="server" Text="Conferma Iscrizione" CssClass="standardsubmitGrande"
                                                TabIndex="19" ToolTip="Conferma Iscrizione a Perbaffo" 
                                                ValidationGroup="UTENTE" OnClick="btnContinua_Click" />
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                                                ShowSummary="False" ValidationGroup="UTENTE" />
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
