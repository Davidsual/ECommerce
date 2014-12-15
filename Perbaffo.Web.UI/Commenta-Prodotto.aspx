<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Commenta-Prodotto.aspx.cs"
    Inherits="Perbaffo.Web.UI.Commenta_Prodotto" %>

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
        <b>Recensisci questo prodotto</b></p>
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
                                    <table border="0" cellpadding="0" cellspacing="2" width="100%">
                                        <tr>
                                            <td colspan="3" align="center">
                                                <b><span id="lblTitoloProdotto" runat="server"></span></b>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <img src="images/pixel.gif" width="12" height="12" alt="" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <b>
                                                    Nome Visualizzato:
                                                </b>
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <span class="small_text">Nome che verrà visualizzato sulla recensione</span>
                                                <br />
                                                <asp:TextBox ID="txtNomeRecensione" MaxLength="20" runat="server" Width="200" TabIndex="1"></asp:TextBox>&nbsp;*
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNomeRecensione"
                                                    ErrorMessage="Nome visualizzato per la recensione obbligatorio" ValidationGroup="SEGNALA">!</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <b>
                                                    Titolo Recensione:
                                                </b>
                                            </td>
                                            <td>
                                                <img border="0" src="images/spacer.gif" width="10px" alt="" />
                                            </td>
                                            <td align="left">
                                                <span class="small_text">Titolo breve della recensione es. 'Mi piace', 'Bello'</span>
                                                <br />
                                                <asp:TextBox ID="txtTitolo" MaxLength="30" runat="server" Width="200" TabIndex="2"></asp:TextBox>&nbsp;*
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitolo"
                                                    ErrorMessage="Titolo della recensione obbligatoria" ValidationGroup="SEGNALA">!</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="left">
                                                <b>
                                                    Voto qualità:
                                                </b>
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <span class="small_text">Valutazione del prodotto</span>
                                                <br />
                                                <asp:DropDownList ID="ddlQualita" runat="server">
                                                    <asp:ListItem Value="" Text="Seleziona"></asp:ListItem>
                                                    <asp:ListItem Value="5" Text="Ottima"></asp:ListItem>
                                                    <asp:ListItem Value="4" Text="Buona"></asp:ListItem>
                                                    <asp:ListItem Value="3" Text="Discreta"></asp:ListItem>
                                                    <asp:ListItem Value="2" Text="Sufficente"></asp:ListItem>
                                                    <asp:ListItem Value="1" Text="Scarsa"></asp:ListItem>
                                                </asp:DropDownList>
                                                &nbsp;*
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlQualita"
                                                    ErrorMessage="Qualità del prodotto obbligatoria" ValidationGroup="SEGNALA">!</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" align="left">
                                                <b>
                                                    Recensione:
                                                </b>
                                            </td>
                                            <td>
                                            </td>
                                            <td align="left">
                                                <span class="small_text">La tua recensione del prodotto</span>
                                                <br />
                                                <textarea id="txtTesto" runat="server" rows="5" cols="35"></textarea>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTesto"
                                                    ErrorMessage="Recensione obbligatoria" ValidationGroup="SEGNALA">!</asp:RequiredFieldValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="3">
                                                <img src="images/pixel.gif" width="12" height="12" alt="" />
                                            </td>
                                        </tr>                                        
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Button class="standardsubmit" ID="btnInvia" runat="server" Text="Invia" Style="cursor: pointer;"
                                                    ValidationGroup="SEGNALA" ToolTip="Invia la tua recensione" OnClick="btnInvia_Click" />
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
