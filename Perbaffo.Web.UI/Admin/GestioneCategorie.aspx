<%@ Page Title="" Language="C#" MasterPageFile="PerbaffoMaster.Master" AutoEventWireup="true"
    CodeBehind="GestioneCategorie.aspx.cs" Inherits="Perbaffo.Web.UI.Admin.GestioneCategorie" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                            Gestione categorie
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
        <tr>
            <td height="10">
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="updPnlTree" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table border="0" align="left" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                <tr>
                    <td>
                        <asp:TreeView ID="treeCategorie" runat="server">
                            <ParentNodeStyle Font-Bold="False" />
                            <SelectedNodeStyle BackColor="#D6DFF7" Font-Underline="False" HorizontalPadding="0px"
                                VerticalPadding="0px" />
                        </asp:TreeView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>         
   <asp:UpdatePanel ID="updPnlCateg" runat="server" UpdateMode="Conditional">
        <ContentTemplate>       
            <asp:Panel ID="pnlButton" runat="server" Visible="false">
                <table border="0" align="left" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                    <tr>
                        <td>
                            <asp:Button ID="btnModifica" runat="server" Text="Modfica" OnClick="btnModifica_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnInserisci" runat="server" Text="Inserisci" OnClick="btnInserisci_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnCancella" runat="server" Text="Cancella" OnClick="btnCancella_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlDeleteCategorie" runat="server" Visible="false">
                <table border="0" align="left" style="font-size: 10px; font-family: Verdana; font-weight: bold" width="60%">
                    <tr>
                        <td colspan="2">
                            <asp:Label ID="lblDetailDelete" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnConfermaDelete" runat="server" Text="Cancella" 
                                onclick="btnConfermaDelete_Click" />
                        </td>
                        <td align="left">
                            <asp:Button ID="btnAnnullaDelete" runat="server" Text="Annulla" OnClick="btnAnnulla_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Panel ID="pnlEditCategoria" runat="server" Visible="false">
                <table border="0" align="left" style="font-size: 10px; font-family: Verdana; font-weight: bold">
                    <tr>
                        <td width="50%" align="right">
                            Descrizione Categoria (100crt):
                        </td>
                        <td width="50%" align="left">
                            <asp:TextBox ID="txtDescrCateg" runat="server" Width="300px" MaxLength="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" align="right">
                            Descrizione breve categoria (50crt):
                        </td>
                        <td width="50%" align="left">
                            <asp:TextBox ID="txtDescrBreveCateg" runat="server" Width="300px" MaxLength="50"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="50%" align="right">
                            Testo descrittivo della categoria:
                        </td>
                        <td width="50%" align="left">
                            <asp:TextBox ID="txtDescrCategoriaEsteso" runat="server" TextMode="MultiLine" Rows="5" Width="300px"></asp:TextBox>
                        </td>
                    </tr>          
                    <tr>
                        <td width="50%" align="right">
                            Keywords (150crt):
                        </td>
                        <td width="50%" align="left">
                            <asp:TextBox ID="txtKeyWords" runat="server" Width="300px" MaxLength="140"></asp:TextBox>
                        </td>
                    </tr>                                
                    <tr>
                        <td colspan="2">
                            <iframe id="Load" width="500px" height="200px" runat="server" frameborder="0" marginwidth="0">
                            </iframe>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="btnSalva" runat="server" Text="Salva" OnClick="btnSalva_Click" />
                        </td>
                        <td align="left">
                            <asp:Button ID="btnAnnulla" runat="server" Text="Annulla" OnClick="btnAnnulla_Click" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
