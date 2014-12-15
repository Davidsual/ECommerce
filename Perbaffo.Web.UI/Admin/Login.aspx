<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <META name="robots" content="noindex,nofollow" />
    <title>Login Perbaffo</title>
</head>
<body>
<form id="login" runat="server">
    <table border="0" width="100%" height="100%">
        <tbody>
            <tr>
                <td height="30%" valign="top" width="100%">
                    <table style="font-family: Verdana; font-size: 10pt" border="0" width="100%">
                        <tbody>
                            <tr>
                                <td align="right">
                                    <img border="0" src="img/chiavi.gif" width="48" height="48">
                                </td>
                                <td style="font-family: Verdana; color: #0a64c8; font-size: 24pt; font-weight: bold"
                                    width="50%" align="left">
                                    Login
                                </td>
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            <tr>
                <td height="70%" width="100%">
                    <table style="margin-top:100px;font-family: Verdana; color: #0a64c8; font-size: 10pt" border="0" width="100%">
                        <tbody>
                            <tr>
                                <td width="50%" align="right">
                                    Username:
                                </td>
                                <td width="50%" align="left">
                                    <asp:TextBox ID="txtUser" runat="server" MaxLength="12" Width="150px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                        ControlToValidate="txtUser" ErrorMessage="Inserire Username" 
                                        ValidationGroup="LOGIN">!</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td width="50%" align="right">
                                    Password:
                                </td>
                                <td width="50%" align="left">
                                    <asp:TextBox ID="txtpass" runat="server" TextMode="Password" MaxLength="15" 
                                        Width="150px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                        ControlToValidate="txtpass" ErrorMessage="Inserire la Password" 
                                        ValidationGroup="LOGIN">!</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click" 
                                        ValidationGroup="LOGIN" />
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                        ShowMessageBox="True" ShowSummary="False" ValidationGroup="LOGIN" />
                </td>
            </tr>
        </tbody>
    </table>
</form>
</body>
</html>
