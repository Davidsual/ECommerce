<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CaricaImmagineUtente.aspx.cs"
    Inherits="Perbaffo.Web.UI.CaricaImmagineUtente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Caricamento immagine</title>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />

    <script type="text/javascript" src="script/Perbaffo.Web.UI.Function.js"></script>

</head>
<body>
    <form id="Form1" enctype="multipart/form-data" runat="server">
    <table border="0" align="center" cellpadding="0" cellspacing="0" width="540px">
        <tr>
            <td width="25%" align="left">
                <b>Nome del tuo amico:</b>
            </td>
            <td width="75%" align="left">
                <asp:TextBox ID="txtDescrizione" runat="server" CssClass="pp_box_registrazione" 
                    Width="370px" MaxLength="98"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescrizione"
                                                                ErrorMessage="Inserisci il nome del tuo amico" ToolTip="Inserisci il nome del tuo amico"
                                                                ValidationGroup="FOTO">!</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td width="25%" align="left">
                <b>Percorso immagine:</b>
                
            </td>
            <td width="75%" align="left">
                <input id="inputFile" type="file" runat="server" class="pp_box_registrazione" style="width: 370px;" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="inputFile"
                                                                ErrorMessage="Seleziona la foto" ToolTip="Seleziona la foto"
                                                                ValidationGroup="FOTO">!</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="left" style="padding-top:4px;padding-bottom:4px"><span class="small_text">La dimensione della foto è consigliabile che sia al <strong>massimo 300 X 300</strong> e di <strong>dimensioni massime di 500kb</strong>. </span></td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                <asp:Button ID="btnContinua" runat="server" Text="Carica" CssClass="standardsubmit"
                    TabIndex="19" ToolTip="Carica immagine" ValidationGroup="FOTO" 
                    onclick="btnContinua_Click" />
            </td>
        </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
        ShowMessageBox="True" ShowSummary="False" ValidationGroup="FOTO" />
    </form>
</body>
</html>
