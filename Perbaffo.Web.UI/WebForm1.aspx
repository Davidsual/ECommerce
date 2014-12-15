<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Perbaffo.Web.UI.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
        <link rel="alternate" type="application/rss+xml" title="RSS" href="RssHandler.ashx" />
    <link rel="Stylesheet" type="text/css"  href="HttpCombinerHandler.ashx?s=Set_Css&amp;t=text/css&amp;v=1" />
    <link rel="Stylesheet" href="css/block.css" type="text/css"/>
    <link rel="Stylesheet" href="css/jq.css" type="text/css"/>
    <script src="script/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="script/jquery.blockUI.js" type="text/javascript"></script>

</head>
<body>
                <form action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post">
                <input type="hidden" name="cmd" value="_xclick" />
                <input type="hidden" name="business" value="trottadavide@hotmail.com" />
                <input type="hidden" name="currency_code" value="EUR">
                <input type="hidden" name="item_name" id="item_name" value="Ordine n°56" runat="server" />
                <input type="hidden" name="amount" id="amount" value="12.45" runat="server" />
                <input type="image" src="images/btn_buynowCC_LG.gif" style="border-width: 0px;" name="submit"
                    alt="PayPal - Il sistema di pagamento online più facile e sicuro!">
                <img alt="" border="0" src="images/pixel.gif" width="1" height="1">
                </form>
    <form id="Form1" enctype="multipart/form-data" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Button ID="Button1" runat="server" Text="Button" onclick="Button1_Click" />
        </ContentTemplate>
    </asp:UpdatePanel>
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
            <td colspan="2" align="left" style="padding-top:4px;padding-bottom:4px"><span class="small_text">La dimensione della foto deve essere <strong>massimo 240 X 240</strong> e di <strong>dimensioni massime di 500kb</strong>. </span></td>
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
