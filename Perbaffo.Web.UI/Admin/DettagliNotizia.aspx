<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PerbaffoMaster.Master"
    CodeBehind="DettagliNotizia.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.DettagliNotizia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function fSubmit() {
            __doPostBack('Load', 'Reload');
        }
    </script>

    <div style="height: 688px; overflow: hidden;">
        <table border="0" width="98%" style="font-family: Verdana; font-size: 16pt; font-weight: bold">
            <tr>
                <td rowspan="2" width="80" height="64" align="center">
                    <img border="0" src="img/prodotti.gif" width="48" height="48">
                </td>
                <td>
                    <table border="0" width="100%" style="font-family: Verdana; font-size: 16pt; font-weight: bold;
                        border-bottom: 1px solid #D6DFF5; padding: 0">
                        <tr>
                            <td align="left" valign="middle" style="color: #3366CC">
                                Gestione News Inserisci/Modifica/Cancella
                            </td>
                            <td align="right" valign="top">
                                <table border="0" style="padding: 0">
                                    <tr>
                                        <td align="right" valign="top">
                                            <asp:LinkButton ID="returnLink" runat="server" Style="font-size: 8pt; font-weight: normal"
                                                OnClick="returnLink_Click">Livello superiore</asp:LinkButton>
                                        </td>
                                        <td width="22">
                                            <asp:LinkButton ID="returnLink2" runat="server" OnClick="returnLink_Click"> <img border="0" src="img/up2.gif" width="22" height="22" alt="Livello superiore"></asp:LinkButton>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <br />
        <asp:UpdatePanel ID="updPnlDettagli" runat="server">
            <ContentTemplate>
                <table border="0" cellpadding="1" cellspacing="2" align="center" style="font-size: 10px;
                    width: 750px; font-family: Verdana; font-weight: bold">
                    <tr>
                        <td width="10%" align="right">
                            Data inserimento:
                        </td>
                        <td width="90%" align="left">
                            <span id="lblDataInserimento" runat="server"></span>
                        </td>
                    </tr>
                    <tr>
                        <td width="10%" align="right">
                            Titolo:
                        </td>
                        <td width="90%" align="left">
                            <asp:TextBox ID="txtTitolo" runat="server" Width="500px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitolo"
                                Text="!" ErrorMessage="Titolo obbligatorio" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Fonte:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtFonte" runat="server" Width="500px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFonte"
                                Text="!" ErrorMessage="Fonte obbligatorio" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Url Fonte:
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtUrlFonte" runat="server" Text="http://www.perbaffo.it" 
                                Width="500px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUrlFonte"
                                Text="!" ErrorMessage="url fonte obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            Notizia:<br />
                            <textarea id="descrizione" name="descrizione" rows="15" style="width: 700px; height: 250"
                                runat="server"></textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="descrizione"
                                Text="!" ErrorMessage="Notizia obbligatoria" ValidationGroup="Prodotto"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <iframe id="Load" width="500px" height="100px" runat="server" frameborder="0" marginwidth="0">
                            </iframe>
                            <img src="../images/no-image.jpg" alt="" id="imgNews" runat="server" width="80" height="80"
                                border="0" />
                            <asp:ImageButton ID="btnDelete" CommandName="DELETE" CommandArgument='<%# Eval("ID") %>'
                            runat="server" ImageUrl="img/delete16.gif" Width="16px" Height="16px" 
                                onclick="btnDelete_Click" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table border="0" cellpadding="1" cellspacing="2" align="center" style="font-size: 10px;
            width: 750px; font-family: Verdana; font-weight: bold">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSend" runat="server" Text="Salva" OnClick="btnSend_Click" ValidationGroup="Prodotto" />
                </td>
                <td align="left">
                    &nbsp;<asp:Button ID="btnCancella" runat="server" Text="Cancella" OnClick="btnCancella_Click" />
                    <asp:Button ID="btnElimina" runat="server" BackColor="#FFFF99" OnClick="btnElimina_Click"
                        Text="Elimina la notizia" />
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="Prodotto" />
    </div>
</asp:Content>
