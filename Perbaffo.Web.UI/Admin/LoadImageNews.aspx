<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadImageNews.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.LoadImageNews" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="Form1" enctype="multipart/form-data" RUNAT="server"> 
                <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                <tr>
                    <td colspan="2"><b>Immagini grandi 240 X 240</b></td>
                </tr>
                <tr>                
                    <td width="50%" align="left">
                         <input id="inputFile" type="file" RUNAT="server" />
                    </td>
                    <td width="50%" align="center">
                        <asp:Button ID="btnCarica" runat="server" Text="Carica" 
                            onclick="btnCarica_Click" />
                    </td>
                </tr>
                </table>                
    </form>
</body>
</html>
