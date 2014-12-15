<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadImagePhotogallery.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.LoadImagePhotogallery" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Form1" enctype="multipart/form-data" RUNAT="server"> 
                <table border="0" align="center" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                <tr>
                    <td width="50%" align="left">
                        Descrizione immagine (80 X 80)
                    </td>
                    <td width="50%" align="left">
                        <asp:TextBox ID="txtDescrizione" runat="server" Width="221px"></asp:TextBox>
                    </td>
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
