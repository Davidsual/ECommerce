<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="PerbaffoMaster.Master" CodeBehind="DettaglioCuriosita.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.DettaglioCuriosita" %>
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
                    <img border="0" src="img/prodotti.gif" width="48" height="48"/>
                </td>
                <td>
                    <table border="0" width="100%" style="font-family: Verdana; font-size: 16pt; font-weight: bold;
                        border-bottom: 1px solid #D6DFF5; padding: 0">
                        <tr>
                            <td align="left" valign="middle" style="color: #3366CC">
                                Gestione Curiosità Inserisci/Modifica/Cancella
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
                        <td width="10%" align="left">
                            Categoria:
                        </td>
                        <td width="90%" align="left">
                            <asp:DropDownList ID="ddlCategorie"
                            runat="server" Width="200">
                        </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlCategorie"
                                Text="!" ErrorMessage="Categirua obbligatoria" ValidationGroup="curiosita"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" colspan="2">
                            Notizia:<br />
                            <textarea id="descrizione" name="descrizione" rows="10" style="width: 700px; height: 150"
                                runat="server"></textarea>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="descrizione"
                                Text="!" ErrorMessage="Notizia obbligatoria" ValidationGroup="curiosita"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <table border="0" cellpadding="1" cellspacing="2" align="center" style="font-size: 10px;
            width: 750px; font-family: Verdana; font-weight: bold">
            <tr>
                <td align="right">
                    <asp:Button ID="btnSend" runat="server" Text="Salva" OnClick="btnSend_Click" ValidationGroup="curiosita" />
                </td>
                <td align="left">
                    &nbsp;<asp:Button ID="btnCancella" runat="server" Text="Cancella" OnClick="btnCancella_Click" />
                    <asp:Button ID="btnElimina" runat="server" BackColor="#FFFF99" OnClick="btnElimina_Click" OnClientClick="javascript:confirm('Vuoi cancellare questa curiosità?');"
                        Text="Elimina la curiosità" />
                </td>
            </tr>
        </table>
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
            ShowSummary="False" ValidationGroup="curiosita" />
    </div>
</asp:Content>